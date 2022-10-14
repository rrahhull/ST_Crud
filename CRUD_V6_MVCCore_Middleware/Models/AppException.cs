using System.Globalization;

namespace CRUD_V6_MVCCore_Middleware.Models
{
    public class AppException : Exception
    {
        public AppException():base(){}
        public AppException(string message):base(message){}
        public AppException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        { }
       
    }
}
