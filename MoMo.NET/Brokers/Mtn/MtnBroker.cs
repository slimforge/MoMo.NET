// --------------------------------------------------------------- 
// Copyright (c) Coalition of the Good-Hearted Engineers 
// ---------------------------------------------------------------

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MoMo.NET.Models.Configurations;
using RESTFulSense.Clients;

namespace MoMo.NET.Brokers.Mtn
{
    internal partial class MtnBroker : IMtnBroker
    {
        private readonly ApiConfigurations apiConfigurations;
        private readonly IRESTFulApiFactoryClient apiClient, authClient;
        private readonly HttpClient httpClient, authHttpClient;

        public MtnBroker(ApiConfigurations apiConfigurations)
        {
            this.apiConfigurations = apiConfigurations;
            this.httpClient = SetupHttpClient();
            this.apiClient = SetupApiClient();
            this.authHttpClient = SetupAuthHttpClient();
            this.authClient = SetupAuthClient();
        }

        private async ValueTask<T> GetAsync<T>(string relativeUrl) =>
            await this.apiClient.GetContentAsync<T>(relativeUrl);

        private async ValueTask<T> PostAsync<T>(string relativeUrl, T content) =>
            await this.apiClient.PostContentAsync(relativeUrl, content);
        private async ValueTask<TResult> PostAsyncForAuth<TRequest, TResult>(string relativeUrl, TRequest content) =>
            await this.authClient.PostContentAsync<TRequest, TResult>(relativeUrl, content, mediaType: "application/json");

        private async ValueTask<TResult> PostAsync<TRequest, TResult>(string relativeUrl, TRequest content) =>
            await this.apiClient.PostContentAsync<TRequest, TResult>(relativeUrl, content, mediaType: "application/json");

        private async ValueTask<T> PutAsync<T>(string relativeUrl, T content) =>
            await this.apiClient.PutContentAsync(relativeUrl, content);

        private async ValueTask<T> DeleteAsync<T>(string relativeUrl) =>
            await this.apiClient.DeleteContentAsync<T>(relativeUrl);

        private HttpClient SetupHttpClient()
        {
            var httpClient =  new HttpClient()
            {
                BaseAddress =
                    new Uri(uriString: this.apiConfigurations.BaseUrl),
            };

            httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue(
                    scheme: "Bearer",
                    parameter: this.apiConfigurations.AccessToken);

            httpClient.DefaultRequestHeaders.Add(
                name: "Ocp-Apim-Subscription-Key",
                value: this.apiConfigurations.SubscriptionKey);

            httpClient.DefaultRequestHeaders.Add (
                name: "X-Target-Environment", 
                value: this.apiConfigurations.TargetEnvironment);
                        
            return httpClient;
        }

        private HttpClient SetupAuthHttpClient()
        {
            var httpClient =  new HttpClient()
            {
                BaseAddress =
                    new Uri(uriString: this.apiConfigurations.BaseUrl),
            };

            httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue(
                    scheme: "Bearer",
                    parameter: this.apiConfigurations.AccessToken);

            httpClient.DefaultRequestHeaders.Add(
                name: "Ocp-Apim-Subscription-Key",
                value: this.apiConfigurations.SubscriptionKey);


            httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue(
                    scheme: "Basic", 
                    parameter: Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{this.apiConfigurations.ApiUser}:{this.apiConfigurations.ApiKey}")));

            return httpClient;
        }

        private IRESTFulApiFactoryClient SetupAuthClient() =>
            new RESTFulApiFactoryClient(this.authHttpClient);

        private IRESTFulApiFactoryClient SetupApiClient() =>
            new RESTFulApiFactoryClient(this.httpClient);

    }
}