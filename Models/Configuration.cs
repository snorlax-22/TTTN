using PayPal.Api;
using System;
using System.Collections.Generic;

namespace TTTN.Models
{
    public static class Configuration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;

        static Configuration()
        {
            var config = GetConfig();
            clientId = "AcIz46PS64aX6ejDyRGIDqzGi3lshgMVDcwZX20GPXMEWC00TB0cpujGM6L0NegrZ7eZJVN0LVT7RuAl";
            clientSecret = "EMps02UHQYUAB-l_7EUo5lUOc9QrOpEd3tmYRYvHNxA_WGYW5IRRKgqz_SzdZogLBfK62u7AaHT4KAtO";
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
