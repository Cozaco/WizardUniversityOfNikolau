using UniSmart.Persistance.Repositories;
using UniSmart.Service;
using UniSmart.Contracts.Services;
using UniSmart.Contracts.Exceptions;

namespace UniSmart.API.Middleware
{
    public class AuthenticationMiddleware
    {
        public RequestDelegate next;
        public IStudentService studentService;
        private readonly IUserService userService;
        public IProfessorService professorService;

        public AuthenticationMiddleware(RequestDelegate next,IProfessorService professorService,IStudentService studentService,IUserService userService)
        {
            this.next = next;
            this.studentService = studentService;
            this.userService = userService;
            this.professorService = professorService;
        }
 
        public async Task InvokeAsync(HttpContext context)
        {
            if(!context.Request.Path.StartsWithSegments("/api"))
            {
                await this.next(context);
            }
            else
            {
                var headers = context.Request.Headers;
                if(headers.ContainsKey("Authentication"))
                {
                    string authHeader = headers["Authentication"];
                    if (authHeader.StartsWith("BASIC") && authHeader.Split(":", 2).Length == 2)
                    {
                        authHeader = authHeader.Replace("BASIC ", "");
                        string mail = authHeader.Split(":",2)[0];
                        string password = authHeader.Split(":",2)[1];
                        if (await userService.CheckPasswordAsync(mail,password))
                        {

                            //TODO Generar Token e inyectarlo en el header authentication de la respuesta en el formato BEARER :token 

                            await this.next(context);
                        }
                        else
                        {
                            throw new UnauthorizedException("Mail or password incorrect");
                        }
                    }
                    else if (authHeader.StartsWith("BEARER"))
                    {
                        string token = authHeader.Replace("BEARER ", "");
                        //TODO FUNCION que valida el token
                    }
                    else
                    {
                        throw new UnauthorizedException("Unknown authorization type");
                    }
                }
                else
                {
                    throw new UnauthorizedException("Missing authentication header");
                }
            }
        }
       
    }
}
