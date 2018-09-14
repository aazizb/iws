using DevExpress.Web.Mvc;
using IWSProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;

namespace IWSProject.Controllers
{
    public class PdfUpdateController : IWSBaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {
            int modelId = (int)IWSLookUp.ComptaMasterModelId.Default;
            if (Session["ModelId"] != null)
                modelId = (int)Session["ModelId"];

            return PartialView("_GridViewPartial", IWSLookUp.GetMasterCompta((IWSLookUp.ComptaMasterModelId)modelId));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult CallbackPanelPartialView(int currentModelId)
        {
            Session["ModelId"] = currentModelId;
            return PartialView("CallbackPanelPartialView",
                    IWSLookUp.GetMasterCompta((IWSLookUp.ComptaMasterModelId)currentModelId));
        }

        public ActionResult UploadFile(string documentId)
        {
            Session["documentId"] = documentId;
            return null;
        }

        public FileResult DownloadFile(int itemId, string fileName)
        {
            List<FileDetailsViewModel> files = GetFileDetail(itemId);

            var file = (from f in files
                            where f.Id.Equals(itemId)
                            select new { f.FileName, f.FileContent, f.ContentType }).ToList().FirstOrDefault();

            return File(file.FileContent, file.ContentType, file.FileName);
        }

        public ActionResult UploadControlCallbackAction()
        {

            UploadControlExtension.GetUploadedFiles("uploadControl", UploadControlSettings.UploadValidationSettings,
                                                                        UploadControlSettings.FileUploadComplete);
            return null;
        }

        #region Convert from/to object/byte

        private static byte[] ObjectToByteArray(object o)
        {
            BinaryFormatter binary = new BinaryFormatter();

            using (var stream = new MemoryStream())
            {
                binary.Serialize(stream, o);

                return stream.ToArray();
            }
        }

        private static object ByteArrayToObject(byte[] bytesArray)
        {
            using (var stream = new MemoryStream())
            {
                var binary = new BinaryFormatter();

                stream.Write(bytesArray, 0, bytesArray.Length);

                stream.Seek(0, SeekOrigin.Begin);

                var o = binary.Deserialize(stream);

                return o;
            }
        }

        #endregion

        private List<FileDetailsViewModel> GetFileDetailX(int Id)
        {
            List<FileDetailsViewModel> filesDetail = new List<FileDetailsViewModel>();

            FileDetailsViewModel fileDetail = new FileDetailsViewModel();

            string query = "Select id, FileName, FileContent, ContentType From MasterCompta Where Id= @Id";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {

                        SqlParameter p = new SqlParameter("@Id", Id);
                        connection.Open();
                        command.Parameters.Add(p);
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        List<DataRow> dataRows = dataTable.Select().ToList();
                        filesDetail = (from DataRow dr in dataTable.Rows
                                   select new FileDetailsViewModel()
                                   {
                                       Id = Convert.ToInt32(dr["Id"]),
                                       FileName = dr["FileName"].ToString(),
                                       FileContent = ObjectToByteArray(dr["FileContent"]),
                                       ContentType = dr["ContentType"].ToString()
                                   }).ToList();
                    }
                    catch (Exception ex)
                    {
                        IWSLookUp.LogException(ex);
                    }
                }
            }
            return filesDetail;
        }
        private static List<FileDetailsViewModel> GetFileDetail(int Id)
        {
            List<FileDetailsViewModel> files = new List<FileDetailsViewModel>();
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = "Select id, FileName, FileContent, ContentType From MasterCompta Where Id= @Id";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    try
                    {
                        SqlParameter p = new SqlParameter("@Id", Id);
                        cmd.Parameters.Add(p);
                        cmd.Connection = con;
                        con.Open();
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                files.Add(new FileDetailsViewModel
                                {
                                    Id = Convert.ToInt32(sdr["Id"]),
                                    FileName = sdr["FileName"].ToString(),
                                    FileContent = ObjectToByteArray(sdr["FileContent"]),
                                    ContentType = sdr["ContentType"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        IWSLookUp.LogException(ex);
                    }
                    con.Close();
                }
            }
            return files;
        }

        private void RemoveFile(string path)
        {
            System.IO.File.Delete(path);
        }

        private void CommitUploadedFiles(string documentUrl)
        {
            UploadedFileInfo file = Session[UploadControlSettings.UploadedFileSessionKey] as UploadedFileInfo;
            if (file == null ||
                !Equals(UploadControlSettings.GetFileRelativePath(file), documentUrl))
            {
                return;
            }

            System.IO.File.WriteAllBytes(UploadControlSettings.GetFileFullPath(documentUrl), file.FileContent);
        }
    }
    public class UploadControlSettings
    {
        public const string UploadDirectory = "~/Documents/";

        public static DevExpress.Web.UploadControlValidationSettings UploadValidationSettings = new DevExpress.Web.UploadControlValidationSettings()
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".pdf" },
            MaxFileSize = 3072000
            // { ".jpg", ".jpeg", ".png", ".bmp", ".pdf", ".xml", ".rtf", ".docx", ".xls", ".xlsx" }
        };

        public static void FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {
                
                int itemId = Convert.ToInt32(HttpContext.Current.Session["documentId"]);



                FileDetailsViewModel fileInfo = new FileDetailsViewModel()
                {
                    Id = itemId,
                    FileName = e.UploadedFile.FileName,
                    FileContent = e.UploadedFile.FileBytes,
                    ContentType = e.UploadedFile.ContentType
                };

                SaveFileDetails(fileInfo);

                e.CallbackData += fileInfo.FileName;

            }
        }

        public static string UploadedFileSessionKey = "UploadedFile";
        public static string GetFileFullPath(string relativePath)
        {
            return HttpContext.Current.Server.MapPath(relativePath);
        }
        public static string GetFileRelativePath(UploadedFileInfo file)
        {
            return Path.Combine("~/Documents", file.FileName);
        }
        private static void SaveFileDetails(FileDetailsViewModel fileDetails)
        {
            string query = "Update MasterCompta Set FileName = @FileName, FileContent = @FileContent, ContentType = @ContentType Where Id= @Id;";
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {

                        List<SqlParameter> p = new List<SqlParameter>
                        {
                            new SqlParameter("@Id", fileDetails.Id),
                            new SqlParameter("@FileName", fileDetails.FileName),
                            new SqlParameter("@FileContent", fileDetails.FileContent),
                            new SqlParameter("@ContentType", fileDetails.ContentType)
                        };

                        connection.Open();
                        AddParameters(command, p.ToArray());
                        command.ExecuteScalar();            //.ExecuteNonQuery();
                        command.Parameters.Clear();
                    }
                    catch (Exception ex)
                    {
                        IWSLookUp.LogException(ex);
                    }
                }
            }
        }

        private static void AddParameters(SqlCommand command, params SqlParameter[] p)
        {
            if (p != null && p.Any())
            {
                command.Parameters.AddRange(p);
            }
        }

    }

    public class UploadedFileInfo
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
    }

    public class FileDetailsViewModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public string ContentType { get; set; }
    }
}
