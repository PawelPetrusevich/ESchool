// --------------------------------------------------------------------------------------------------------------------
// <copyright company="ESchool" file=" IdentityServerConfiguration.cs">
//  Creator name: 
//  Solution: ESchool
//  Project: ESchool.IDP    
// </copyright>
// <summary>
//  Filename: IdentityServerConfiguration.cs
//  Created day: 14.05.2018    21:48
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

namespace ESchool.IDP
{
    using System.Collections.Generic;

    using IdentityServer4.Models;

    public class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
                       {
                           new ApiResource("api", "My Api")
                       };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
                       {
                           new Client
                               {
                                   ClientId = "client",
                                   AllowedGrantTypes = GrantTypes.ClientCredentials,
                                   ClientSecrets =
                                       {
                                           new Secret("secret".Sha256())
                                       },
                                   AllowedScopes = { "api" }
                               }
                       };
        }
    }
}