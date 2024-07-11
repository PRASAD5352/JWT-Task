using Microsoft.Owin.Security.OAuth;
using MontCrest_Task_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MontCrest_Task_API.Models
{
    public class MyAuthProvider : OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            MontCrestEntities obj = new MontCrestEntities();
            var userdata = obj.sp_checklogin(context.UserName, context.Password).FirstOrDefault();
            if (userdata != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, userdata.Fname));
                identity.AddClaim(new Claim(ClaimTypes.Email, userdata.Email));
                identity.AddClaim(new Claim(ClaimTypes.SerialNumber, userdata.Adharno));

                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                context.Rejected();
            }
        }

    }
}