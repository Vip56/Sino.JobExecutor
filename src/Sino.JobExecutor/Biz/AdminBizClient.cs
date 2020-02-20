using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Sino.JobExecutor.Biz.Model;

namespace Sino.JobExecutor.Biz
{
    public class AdminBizClient : IAdminBiz
    {
        public const string DEFAULT_HTTP_CLIENT_NAME = "SinoJobExecutorHttpClient";
        public const string XXL_RPC_ACCESS_TOKEN = "XXL-RPC-ACCESS-TOKEN";

        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<AdminBizClient> _logger;
        private readonly string _addressUrl;
        private readonly string _accessToken;

        public AdminBizClient(IHttpClientFactory clientFactory, ILogger<AdminBizClient> logger, string addressUrl, string accessToken)
        {
            if (string.IsNullOrEmpty(addressUrl))
                throw new ArgumentNullException(nameof(addressUrl));

            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _addressUrl = addressUrl.EndsWith("/") ? addressUrl : addressUrl + "/";
            _accessToken = accessToken;
        }

        public Task<ReturnT<string>> CallBack(IList<HandleCallbackParam> callbackParamList)
        {
            return InvokeService<string>(_addressUrl + "api/callback", _accessToken, callbackParamList, 3);
        }

        public Task<ReturnT<string>> Registry(RegistryParam registryParam)
        {
            return InvokeService<string>(_addressUrl + "api/registry", _accessToken, registryParam, 3);
        }

        public Task<ReturnT<string>> RegistryRemove(RegistryParam registryParam)
        {
            return InvokeService<string>(_addressUrl + "api/registryRemove", _accessToken, registryParam, 3);
        }

        private async Task<ReturnT<T>> InvokeService<T>(string url, string accessToken, object requestObj, int timeout) where T : class
        {
            string requestStr = JsonConvert.SerializeObject(requestObj);

            using (var client = _clientFactory.CreateClient(DEFAULT_HTTP_CLIENT_NAME))
            {
                var content = new StringContent(requestStr, Encoding.UTF8);
                content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");

                if (!string.IsNullOrEmpty(accessToken))
                {
                    content.Headers.Add(XXL_RPC_ACCESS_TOKEN, accessToken);
                }

                HttpResponseMessage responseMessage = null;
                try
                {
                    responseMessage = await client.PostAsync(url, content);
                    responseMessage.EnsureSuccessStatusCode();
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, $"request url {url} error {ex.Message}.");
                    return new ReturnT<T>(ReturnT<T>.FAIL_CODE, $"request url {url} error {ex.Message}.");
                }

                var responseStr = await responseMessage.Content.ReadAsStringAsync();

                try
                {
                    ReturnT<T> result = JsonConvert.DeserializeObject<ReturnT<T>>(responseStr);
                    return result;
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, $"remoting {url} response content invalid(\"{responseStr}\")");
                    return new ReturnT<T>(ReturnT<T>.FAIL_CODE, $"remoting {url} response content invalid(\"{responseStr}\")");
                }
            }
        }
    }
}
