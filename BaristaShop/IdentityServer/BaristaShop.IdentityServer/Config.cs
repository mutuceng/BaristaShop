// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security;

namespace BaristaShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog") { Scopes = {"CatalogFullPermission","CatalogReadPermission"} },
            new ApiResource("ResourceDiscount") { Scopes = {"DiscountFullPermission"} },
            new ApiResource("ResourceOrder") { Scopes = {"OrderFullPermission","OrderReadPermission"} },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),  // tokenını aldığımız kullanıcının hangi bilgilerine erişeceğiz
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Has full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Has only read permission for catalog operations"),
            new ApiScope("DiscountFullPermission","Has full authority for discount operations"),
            new ApiScope("OrderFullPermission","Has full authority for order operations"),
            new ApiScope("OrderReadPermission","Has only read permission for order operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        // Client'lar
        public static IEnumerable<Client> Clients => new Client[]
        {
            // Visitor
            new Client
            {
                ClientId = "BaristaShopVisitorId",
                ClientName = "BaristaShop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret( "baristashopsecret".Sha256() ) },
                AllowedScopes = { "CatalogReadPermission" }  
            },

            // Manager
            new Client
            {
                ClientId = "BaristaShopManagerId",
                ClientName = "BaristaShop Manager User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret( "baristashopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "DiscountFullPermission",  }

            },

            // Administrator
            new Client
            {
                ClientId = "BaristaShopAdminId",
                ClientName = "BaristaShop Admin User",
                AllowedGrantTypes= GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret( "baristashopsecret".Sha256()) },              
                AllowedScopes = { "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission", 
                // AllowedScopes'un içerisine yazmaya devam ediyorum.
                IdentityServerConstants.LocalApi.ScopeName, // bu identity service'ı için yetki veriyor.
                IdentityServerConstants.StandardScopes.OpenId,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.Profile
                },

                AccessTokenLifetime = 3600 //defaultu 3600 zaten saniye cinsinden
            }
        };

        //public static IEnumerable<Client> Clients =>
        //    new Client[]
        //    {
        //        // m2m client credentials flow client
        //        new Client
        //        {
        //            ClientId = "m2m.client",
        //            ClientName = "Client Credentials Client",

        //            AllowedGrantTypes = GrantTypes.ClientCredentials,
        //            ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

        //            AllowedScopes = { "scope1" }
        //        },

        //        // interactive client using code flow + pkce
        //        new Client
        //        {
        //            ClientId = "interactive",
        //            ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

        //            AllowedGrantTypes = GrantTypes.Code,

        //            RedirectUris = { "https://localhost:44300/signin-oidc" },
        //            FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
        //            PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

        //            AllowOfflineAccess = true,
        //            AllowedScopes = { "openid", "profile", "scope2" }
        //        },
        //    };
    }
}