using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using Kursach3.Models;
using Microsoft.Owin.Security.Twitter;
using Microsoft.Owin.Security;

namespace Kursach3
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                { 
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            
            app.UseTwitterAuthentication(new TwitterAuthenticationOptions
            {
                ConsumerKey = "36u1h1DDp2rw5x3aYnsFPbig0",
                ConsumerSecret = "hk81X9kqwQv9xCahuB30Vk0RiYVWad4mtwrkFqgSruNtaRHUCy",
                BackchannelCertificateValidator = new CertificateSubjectKeyIdentifierValidator(new[]
                {
                    "A5EF0B11CEC04103A34A659048B21CE0572D7D47", // VeriSign Class 3 Secure Server CA - G2 
                    "0D445C165344C1827E1D20AB25F40163D8BE79A5", // VeriSign Class 3 Secure Server CA - G3 
                    "7FD365A7C2DDECBBF03009F34339FA02AF333133", // VeriSign Class 3 Public Primary Certification Authority - G5 
                    "39A55D933676616E73A761DFA16A7E59CDE66FAD", // Symantec Class 3 Secure Server CA - G4 
                    "5168FF90AF0207753CCCD9656462A212B859723B", //DigiCert SHA2 High Assurance Server CA 
                    "B13EC36903F8BF4701D498261A0802EF63642BC3" //DigiCert High Assurance EV Root CA 
                })
            });

            app.UseFacebookAuthentication(
                appId: "979967035458809",
                appSecret: "4023e3403c77aa6dbf18fffc4ed51807");

            app.UseVkontakteAuthentication(
                "5564971", "AFbEOxXeJUQ42mqq4euH", "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}