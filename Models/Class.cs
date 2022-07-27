using PayPal.Api;
using System;
using System.Collections.Generic;

namespace BT2MWG.Models
{
    public static class Configuration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;

        static Configuration()
        {
            var config = GetConfig();
            clientId = config["clientId"];
        }

        private static Dictionary<string,string> GetConfig()
        {
            return ConfigManager.Instance.GetProperties();
        }

        private static string GetAccessToken()
        {
            string accessToken = new OAuthTokenCredential
                (clientId, clientSecret, GetConfig()).GetAccessToken();

            return accessToken;
        }

        public static APIContext GetAPIContext()
        {
            APIContext context = new APIContext(GetAccessToken());
            context.Config = GetConfig();
            return context;
        }
    }
}
