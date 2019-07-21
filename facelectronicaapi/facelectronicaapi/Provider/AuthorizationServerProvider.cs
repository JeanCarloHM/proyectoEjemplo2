using FacElectronicaApi.DBContext;
using FacElectronicaApi.DBContext.Entities;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FacElectronicaApi.Provider
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// Valida la autenticación y en este caso dejamos que sea el propio OAuth quien haga la validación
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        /// <summary>
        /// Valida los datos del usuario que se esta logueando y retorna el token
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                Boolean esValido = false;
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

                using(UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Decimal nitEmpresa = Convert.ToDecimal(context.UserName);

                    EmpresasEntity empresa = unitOfWork.EmpresasRepository.Obtener(nitEmpresa);

                    if (empresa != null)
                    {
                        if (empresa.Password == context.Password)
                        {
                            esValido = true;
                        }
                    }
                }

                if (esValido)
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim("sub", context.UserName));
                    identity.AddClaim(new Claim("role", "user"));

                    context.Validated(identity);
                }
                else
                {
                    context.SetError("invalid_grant", "Usuario o contraseña incorrecta");
                    return;
                }
            }
            catch (Exception ex)
            {
                var exception = Utils.UtilException.GetInnerException(ex);
                context.SetError(exception.Message);
            }
        }
    }
}