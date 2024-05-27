using kutya_sajat_api.Data.Models.NonDatabase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace kutya_sajat_api.Services
{
    public class ResultBuilder<T>
    {

        public bool Success { get; set; } = true;
        public int Code { get; set; } = 20000;
        public string Message { get; set; } = String.Empty;
        public T? Data { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        private ResultBuilder(bool @success = true, int @code = 20000, string @message = "", T? @data = default)
        {
            Success = @success;
            Code = @code;
            Message = @message;
            Data = @data;
        }

        public static IActionResult ProtectedCall(Func<IActionResult> toCall)
        {
            try
            {
                return toCall();
            }
            catch (IServiceExceptionResult ex)
            {
                return ResultBuilder<object>.Build(success: false, ex.StatusCode, message: ex.Message, data: ex.GetData()).AsJson();
            }
            catch (Exception ex)
            {
                return ResultBuilder<object>.Build(success: false, 500, message: ex.Message, data: ex.StackTrace).AsJson();
            }
        }

        public static ResultBuilder<T> Build(bool @success = true, int @code = 200, string @message = "", T? @data = default)
        {
            ResultBuilder<T> resultBuilder = new ResultBuilder<T>(@success, @code, @message, @data);
            return resultBuilder;
        }

        public JsonResult AsJson()
        {
            return new JsonResult(this);
        }

        public string AsText()
        {
            return JsonSerializer.Serialize(this);
        }

        public async void AsHttpResponse(HttpResponse httpResponse)
        {
            httpResponse.ContentType = "application/json";
            httpResponse.StatusCode = Convert.ToInt32(Code.ToString().Substring(0, 3));
            await httpResponse.WriteAsync(
                AsText()
            );
        }
    }
}
