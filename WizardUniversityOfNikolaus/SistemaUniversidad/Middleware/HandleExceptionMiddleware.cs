using UniSmart.Contracts.Exceptions;

namespace UniSmart.API.Middleware
{
    public class HandleExceptionMiddleware
    {
        public RequestDelegate next;
        public HandleExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;   
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (ExpectedException ex)
            {
                context.Response.StatusCode = ex.Code;
                await context.Response.WriteAsync(ex.Message);
                return;
            }
        }
    }
}
