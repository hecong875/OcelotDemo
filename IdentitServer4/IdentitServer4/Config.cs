using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitServer4
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api","UserApi")
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<Client> GetClients()
        {

            return new List<Client> {
                new Client()
                {
                    ClientId ="Client",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets={
                        new Secret("secrect".Sha256())
                    },
                    AllowedScopes={"api"}
                },
                new Client()
                {
                    ClientId="pwdClient",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    ClientSecrets=
                    {
                        new Secret("pwdSecrect".Sha256())
                    },
                    AllowedScopes = {"api"}
                },
                new Client()
                {
                    ClientId="impClient",
                    AllowedGrantTypes = GrantTypes.Implicit,
                    RedirectUris={ "http://localhost:5004/signin-oidc" },
                    PostLogoutRedirectUris={ "http://localhost:5004/signout-callback-oidc" },
                    AllowedScopes ={ IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                    }
                }
             }; 
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser> { new TestUser() { SubjectId = "1", Username = "allen", Password = "123456" ,Claims=new List<Claim>
              {
                  new Claim("name","Allen"),
                  new Claim("address","http://allen.com")
              }}, new TestUser() { SubjectId = "2", Username = "alisa", Password = "123456",  Claims=new List<Claim>
                {
                    new Claim("name","Alisa"),
                    new Claim("address","http://alisa.com")
              }
              } };
        }
    }

}
