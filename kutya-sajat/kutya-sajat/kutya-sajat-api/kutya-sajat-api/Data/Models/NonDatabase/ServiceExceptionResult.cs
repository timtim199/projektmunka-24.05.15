using System;

namespace kutya_sajat_api.Data.Models.NonDatabase
{
    public abstract class IServiceExceptionResult : Exception
    {
        public int StatusCode { get; }
        public abstract object? GetData();

        public IServiceExceptionResult(string message, int code = 50000, Exception? inner = default)
            : base(message, inner)
        {
            StatusCode = code;
        }
    }

    public class ServiceExceptionResult<T> : IServiceExceptionResult where T : class
    {
        private readonly T Data;

        public ServiceExceptionResult(string message, int code = 50000, T? data = default, Exception? inner = default)
            : base(message, code, inner)
        {
            Data = data;
        }

        public override object? GetData()
        {
            return Data;
        }
    }
}
