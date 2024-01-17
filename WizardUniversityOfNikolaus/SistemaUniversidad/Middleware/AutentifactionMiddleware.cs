using Persistance.Repositories;
using Service;
using UniSmart.Contracts.Services;

namespace UniSmart.API.Middleware
{
    public class AutentifactionMiddleware
    {
        public RequestDelegate next;
        public IStudentService studentService;
        public IProfessorService professorService;

        public AutentifactionMiddleware(RequestDelegate next,IProfessorService professorService,IStudentService studentService)
        {
            this.next = next;
            this.studentService = studentService;
            this.professorService = professorService;
        }   

        public async Task InvokeAsync(HttpContext context)
        {
            var header = context.Request.Headers;
            if(header.ContainsKey("User") && header.ContainsKey("Password"))
            {
                if(await CheckPasswordAsync(header["User"], header["Password"], header["Status"]))
                {
                    await this.next(context);
                }
                else
                {
                    context.Response.StatusCode = 401;
                }
            }
        }
        public async Task<bool> CheckPasswordAsync(string user,string password,string status)
        {
            if( status == "Student")
            {
                return await studentService.CheckPasswordAsync(user, password);
            }
            else if (status == "Professor")
            {
                return await professorService.CheckPasswordAsync(user, password);
            }
            else
            {
                return false;
            }
        }

    }
}
