using bdd_backend_tests.Apis.Models;
using bdd_backend_tests.Utils.Settings;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace bdd_backend_tests.Apis
{
    public class BaseApiTests : Settings
    {
        public static RestClient Client;
        public static IRestRequest Request;
        public static IRestResponse Response;

        public static void SetBaseUriAndAuth()
        {
            Client = new RestClient(baseUrl);
            Client.Authenticator = AuthTwitter();
        }

        public static void PostTweet(string message)
        {
            Request = new RestRequest("/update.json", Method.POST);
            Request.AddParameter("status", message, ParameterType.GetOrPost);
            GetResponse();
        }

        public static void GetResponseOfResource(string apiResource)
        {
            Request = new RestRequest();
            Request.Resource = apiResource;
            GetResponse();
        }

        public static void AssertTweetWasPosted(string tweet)
        {
            var result = DeserializeResponse<List<HomeTimeline>>();
            Assert.True(result[0]
                .text
                .Equals(tweet));
        }

        private static void GetResponse()
        {
            Response = Client.Execute(Request);
        }

        private static T DeserializeResponse<T>()
        {
            var jsonDeserializer = new JsonDeserializer();
            return jsonDeserializer.Deserialize<T>(Response);
        }

        private static OAuth1Authenticator AuthTwitter()
        {
            var authenticator = OAuth1Authenticator.ForProtectedResource(consumerKey, consumerSecret, accessToken, accessTokenSecret);
            return authenticator;
        }
    }
}
