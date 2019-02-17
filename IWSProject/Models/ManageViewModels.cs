
namespace IWSProject.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }
    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }

    public class JournalViewModel
    {
        public int pk { get; set; }
        public int ItemID { get; set; }
        public int OID { get; set; }
        public string ItemType { get; set; }
        public string CustSupplierID { get; set; }
        public string Owner { get; set; }
        public string StoreID { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime ItemDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string Periode { get; set; }
        public string oYear { get; set; }
        public string oMonth { get; set; }
        public string Account { get; set; }
        public string AccountName { get; set; }
        public string OAccount { get; set; }
        public string OAccountName { get; set; }
        public decimal Amount { get; set; }
        public decimal DebitBefore { get; set; }
        public decimal CreditBefore { get; set; }
        public decimal DebitAfter { get; set; }
        public decimal CreditAfter { get; set; }
        public string Side { get; set; }
        public string CompanyID { get; set; }
        public string CompanyIBAN { get; set; }
        public string IBAN { get; set; }
        public string Currency { get; set; }
        public string Info { get; set; }
        public string TypeJournal { get; set; }
        public string CostCenterId { get; set; }
        public int ModelId { get; set; }
    }
    public class JournauxViewModel
    {
        public int Id { get; set; }
        public int OId { get; set; }
        public string CostCenter { get; set; }
        public string Account { get; set; }
        public string HeaderText { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime ItemDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string CompanyId { get; set; }
        public bool IsValidated { get; set; }
        public decimal OTotal { get; set; }
        public string OCurrency { get; set; }
        public string OPeriode { get; set; }
        public string OYear { get; set; }
        public string OMonth { get; set; }
        public string TypeJournal { get; set; }
        public int ModelId { get; set; }
        public string AccountingAccount { get; set; }
       
    }
    public class LineJournauxViewModel
    {
        public int Id { get; set; }
        public int TransId { get; set; }
        public string Account { get; set; }
        public bool Side { get; set; }
        public string OAccount { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string Text { get; set; }
        public string Currency { get; set; }
        public int? ModelId { get; set; }
     
    }
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
    public class FiscalYearViewModel
    {
        public string CompanyId { get; set; }
        public string CStart { get; set; }
        public string CEnd { get; set; }
        public string OStart { get; set; }
        public string OEnd { get; set; }
    }
    public class BeforeAmountViewModel
    {
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
    public class ValidateDocsViewModel
    {
        [Key]
        [Column(Order = 1)]
        public int ItemID { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ItemType { get; set; }
        public DateTime DueDate { get; set; }
        public string Periode { get; set; }
        public string SupplierID { get; set; }
        public bool Area { get; set; }
        public string CompanyID { get; set; }
        public decimal VAT { get; set; }
        public decimal TotalVAT { get; set; }
        public decimal TotalHVAT { get; set; }
        public string Currency { get; set; }
        public bool IsValidated { get; set; }
    }
    public class DocumentsViewModel
    {
        [Key]
        [Column(Order = 1)]
        public int ItemID { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ItemType { get; set; }
        public DateTime DueDate { get; set; }
        public string SupplierID { get; set; }
        public bool Area { get; set; }
        public string CompanyID { get; set; }
        public decimal TotalVAT { get; set; }
        public decimal TotalHVAT { get; set; }
        public string Currency { get; set; }
        public bool IsValidated { get; set; }
    }
    public class AccountAmountViewModel
    {
        [Key]
        public string AccountCode { get; set; }
        public decimal AccountAmount { get; set; }
    }

    public class ValidateInvoiceViewModel
    {
        [Key]
        public int ID { get; set; }
        public int OID { get; set; }
        public string StoreID { get; set; }
        public string SupplierID { get; set; }
        public int ModelID { get; set; }
        public string CompanyID { get; set; }
        public DateTime ItemDate { get; set; }
        public string Text { get; set; }
        public string LineText { get; set; }
        public decimal Vat { get; set; }
        public string VatAccountID { get; set; }
        public string Periode { get; set; }
        public string DebitAccountID { get; set; }
        public string CreditAccountID { get; set; }
        public decimal TotHTVA { get; set; }
        public decimal TotTVA { get; set; }
        public string Currency { get; set; }
    }
    public class ValidateStockViewModel
    {
        [Key]
        [Column(Order = 1)]
        public string StoreID { get; set; }
        [Key]
        [Column(Order = 2)]
        public string ItemID { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public bool IsService { get; set; }
        public string Currency { get; set; }
        public string Text { get; set; }
    }
    public class AccountBalanceViewModel
    {
        public int pk { get; set; }

        [Key]
        public string AccountID { get; set; }
        public string Name { get; set; }
        public string Periode { get; set; }
        public string OYear { get; set; }
        public string OMonth { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal IDebit { get; set; }
        public decimal ICredit { get; set; }
        public decimal Balance { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal FinalBalance { get; set; }
        public decimal FDebit { get; set; }
        public decimal FCredit { get; set; }
        public decimal SDebit { get; set; }
        public decimal SCredit { get; set; }
        public string Currency { get; set; }
        public bool IsBalance { get; set; }
        public string CompanyID { get; set; }
    }
    public class StockViewModel
    {
        [Key]
        public string ItemName { get; set; }
        public string StoreName { get; set; }
        public int Quantity { get; set; }
        public string ItemUnit { get; set; }
        public decimal AveragePrice { get; set; }
        public string Currency { get; set; }
        public string CompanyID { get; set; }
    }
    public class ReportViewModel
    {
        [Key]
        public string Account { get; set; }
        public string Owner { get; set; }
        public string ItemType { get; set; }
        public DateTime TransDate { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
    public class BankStatementViewModel
    {
        [Key]
        public int id { get; set; }
        public string Auftragskonto { get; set; }
        public DateTime? Buchungstag { get; set; }
        public DateTime? Valutadatum { get; set; }
        public string Buchungstext { get; set; }
        public string Verwendungszweck { get; set; }
        public string BeguenstigterZahlungspflichtiger { get; set; }
        public string Kontonummer { get; set; }
        public string BLZ { get; set; }
        public decimal? Betrag { get; set; }
        public string Waehrung { get; set; }
        public string Info { get; set; }
        public string CompanyIBAN { get; set; }
        public string CompanyID { get; set; }
        public bool? IsValidated { get; set; }
    }
    public class LineDetailComptaViewModel
    {
        public int Id { get; set; }
        public int TransId { get; set; }
        public int OID { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Text { get; set; }
    }
    public class ImmoDetailViewModel
    {
        public string CostCenter { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime ItemDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string Account { get; set; }
        public string OAccount { get; set; }
        public bool Side { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string CompanyId { get; set; }
        public int ModelId { get; set; }
        public bool IsValidated { get; set; }
    }
    public class BrouillardViewModel
    {
        public int OID { get; set; }
        public string Account { get; set; }
        public string AccountID { get; set; }
        public bool Side { get; set; }
        public string OAccountID { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime ItemDate { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public string HeaderText { get; set; }
        public string Currency { get; set; }
        public string TypeDoc { get; set; }
        public string CompanyId { get; set; }
        public bool IsValidated { get; set; }
    }
    public class BrouillardHeaderViewModel
    {
        public string Oid { get; set; }
        public string CostCenter { get; set; }
        public string Account { get; set; }
        public string HeadeText { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime ItemDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string CompanyId { get; set; }
        public bool IsValidated { get; set; }
    }
    public class BrouillardLineViewModel
    {
        public int TransId { get; set; }
        public string Account { get; set; }
        public bool Side { get; set; }
        public string OAccount { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string Text { get; set; }
        public string Currency { get; set; }
    }
    public class AssetViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string OAccount { get; set; }
        public DateTime Period { get; set; }
        public DateTime AssetStartDate { get; set; }
        public int LifeSpan { get; set; }
        public int Frequency { get; set; }
        public decimal BookValue { get; set; }
        public decimal ScrapValue { get; set; }
        public decimal Rate { get; set; }
        public string Currency { get; set; }
        public int DepreciationType { get; set; }
        public string CompanyId { get; set; }
    }
    public class StatementDetailViewModel
    {
        public string Id { get; set; }
        public string AccountID { get; set; }
        public string OAccountID { get; set; }
        public string BankAccountID { get; set; }
        public string Info { get; set; }
        public string Waehrung { get; set; }
        public decimal Betrag { get; set; }
        public DateTime Buchungstag { get; set; }
        public DateTime Valutadatum { get; set; }
        public string Periode { get; set; }
        public string Buchungstext { get; set; }
        public string Verwendungszweck { get; set; }
        public string BeguenstigterZahlungspflichtiger { get; set; }
        public string IBAN { get; set; }
    }
    public class InvoiceViewModel
    {
        public string Account { get; set; }
        public string OAccount { get; set; }
        public decimal? PVat { get; set; }
        public string CostCenter { get; set; }
        public string HeaderText { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime ItemDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string CompanyId { get; set; }
        public decimal? OTotal { get; set; }
        public decimal? Amount { get; set; }
        public decimal? VatAmount { get; set; }
        public string OCurrency { get; set; }
        public string OPeriode { get; set; }
        public DateTime DueDate { get; set; }
        public string Text { get; set; }
        public string AccountId { get; set; }
        public string VatAccountId { get; set; }
        public int Modelid { get; set; }
    }
    public class DebitViewModel
    {
        public int TransID { get; set; }
        public string ODebit { get; set; }
        public string OCredit { get; set; }
        public bool Side { get; set; }
        public DateTime ItemDate { get; set; }
        public decimal? OVat { get; set; }
        public decimal? OTotal { get; set; }
        public string Currency { get; set; }
        public string HeaderText { get; set; }
        public int ModelId { get; set; }

    }
    public class CreditViewModel
    {
        public string OCreditVAT { get; set; }
        public string OCreditTotal { get; set; }
        public string InputVatAccount { get; set; }
        public string ExpenseAccount { get; set; }
        public decimal? OTotal { get; set; }
        public decimal? OVAT { get; set; }
    }
    public class DetailDetailViewModel
    {
        public int TransId { get; set; }
        public int OID { get; set; }
        public decimal Amount { get; set; }
        public int ModelId { get; set; }
    }
    public class LineInvoiceViewModel
    {
        public int TransID { get; set; }
        public string Account { get; set; }
        public bool Side { get; set; }
        public string OAccount { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public string Text { get; set; }
        public string Currency { get; set; }
    }
    public class OwnerViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string OwnerType { get; set; }
    }
    public class ResultsViewModel
    {
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public string SubClassId { get; set; }
        public string SubClassName { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public decimal TDebit { get; set; }
        public decimal TCredit { get; set; }
        public decimal SDebit { get; set; }
        public decimal SCredit { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
    }
    public class ResultsDialogViewModel
    {
        public string Start { get; set; }
        public string End { get; set; }
        public string ClassId { get; set; }
        public string CompanyId { get; set; }
    }
    public class ChildViewModel
    {
        public string ChildId { get; set; }
        public string ChildName { get; set; }
        public string ParentId { get; set; }
        public string ParentName { get; set; }
    }
}

