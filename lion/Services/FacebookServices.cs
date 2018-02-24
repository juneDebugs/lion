﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using lion.Models;
using Newtonsoft.Json;

namespace lion.Services
{
    public class FacebookServices
    {

        public async Task<FacebookProfileModel> GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl =
                "https://graph.facebook.com/v2.7/me/?fields=name,picture,work,website,religion,location,locale,link,cover,age_range,bio,birthday,devices,email,first_name,last_name,gender,hometown,is_verified,languages&access_token="
                + accessToken;

            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);

            var facebookProfile = JsonConvert.DeserializeObject<FacebookProfileModel>(userJson);

            return facebookProfile;
        }
    }
}
