using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace App.UI.Web.MVC.Common
{
    public static class SecurityHelper
    {
        public static List<Claim> CreateClaimsUsuario( Usuario usuario ) {

            //Ingreso a la aplicación
            var claims = new List<Claim>();
            //Creando pedazos de la informacion pa que se guarden en la cookie de seguridad

            claims.Add(new Claim(ClaimTypes.Name, $"{usuario.Nombres} {usuario.Apellidos}"));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.Login));
            claims.Add(new Claim(ClaimTypes.Email, usuario.Email));
            claims.Add(new Claim("UsuarioID", usuario.UsuarioID.ToString()));

            //Creando claims de roles para ser utilizados en conjunto con el atributo de 
            //authorize de MVC                

            string[] roles = usuario.Roles.Split(';');

            foreach (string rol in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, rol));
            }

            return claims;
        }

        public static IEnumerable<Claim> GetClaimsByType(string type) {

            var identity =(ClaimsIdentity)HttpContext.Current.User.Identity;

            var claims = identity.Claims.Where( item => item.Type == type).ToList();

            return claims;
        }

        public static string GetUserFullName() {

            var claimValue = GetClaimsByType(ClaimTypes.Name).FirstOrDefault()?.Value;
            return claimValue;
        }

        public static int GetUsuarioID() {
            var claimValue = GetClaimsByType("UsuarioID").FirstOrDefault() != null ?
                        Convert.ToInt32(GetClaimsByType("UsuarioID").FirstOrDefault().Value) : 0;

            return claimValue;
        }

        public static bool IsLogged() {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static bool IsAdmin() {

            return HttpContext.Current.User.IsInRole("Admin");
        }

    }
}