using System.Globalization;

namespace Dapper.PostgreSql.Core7.Api.Helpers
{
    public class AppException : Exception
    {
        public AppException(): base() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
