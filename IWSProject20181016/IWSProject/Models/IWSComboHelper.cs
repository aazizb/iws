using DevExpress.Web;
using DevExpress.Web.Mvc;

namespace IWSProject.Models
{
    public static class IWSComboBoxHelper
    {

        public static MVCxColumnComboBoxProperties CreateComboBox(string controller, string action, 
                                                    string textField, string valueField, object dataObject)
        {
            MVCxColumnComboBoxProperties combo = new MVCxColumnComboBoxProperties
            {
                CallbackRouteValues = new
                {
                    Controller = controller,
                    Action = action
                },
                TextField = textField,
                ValueField = valueField,
                ValueType = typeof(string),
                CallbackPageSize = 15,
                DropDownStyle = DropDownStyle.DropDown
            };
            combo.BindList(dataObject);
            return combo;
        }
    }
}