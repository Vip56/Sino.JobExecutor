using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using Sino.JobExecutor.Biz;
using Sino.JobExecutor.Biz.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace JobExecutorUnitTest
{
    public class AdminBizClientTest
    {
        private string _addressUrl = "http://127.0.0.1:8081/xxl-job";
        private string _accessToken = "";

        public AdminBizClientTest()
        {

        }

        private IAdminBiz CreateService(MockHttpMessageHandler handler)
        {
            return new AdminBizClient(FakeHttpClientFactory.Create(handler.ToHttpClient()), Mock.Of<ILogger<AdminBizClient>>(), _addressUrl, _accessToken);
        }

        [Fact]
        public async Task CallBackTest()
        {
            var request = new List<HandleCallbackParam>();
            request.Add(new HandleCallbackParam(1, DateTime.Now.Ticks, ReturnT<string>.SUCCESS));

            var mock = new MockHttpMessageHandler();
            mock.When(HttpMethod.Post, _addressUrl + "/api/callback")
                .WithContent(JsonConvert.SerializeObject(request))
                .Respond("application/json", JsonConvert.SerializeObject(ReturnT<string>.SUCCESS));

            var service = CreateService(mock);

            var result = await service.CallBack(request);

            Assert.Equal(ReturnT<string>.SUCCESS_CODE, result.Code);
        }

        [Fact]
        public async Task CallBackWithTokenTest()
        {
            _accessToken = "abcdefg123456";

            var request = new List<HandleCallbackParam>();
            request.Add(new HandleCallbackParam(1, DateTime.Now.Ticks, ReturnT<string>.SUCCESS));

            var mock = new MockHttpMessageHandler();
            mock.When(HttpMethod.Post, _addressUrl + "/api/callback")
                .WithHeaders(AdminBizClient.XXL_RPC_ACCESS_TOKEN, _accessToken)
                .WithContent(JsonConvert.SerializeObject(request))
                .Respond("application/json", JsonConvert.SerializeObject(ReturnT<string>.FAIL));

            var service = CreateService(mock);

            var result = await service.CallBack(request);

            Assert.Equal(ReturnT<string>.FAIL_CODE, result.Code);
        }

        [Fact]
        public async Task RegistryTest()
        {
            var request = new RegistryParam();
            request.RegistryGroup = "tms";
            request.RegistryKey = "job";
            request.RegistryValue = "export";

            var mock = new MockHttpMessageHandler();
            mock.When(HttpMethod.Post, _addressUrl + "/api/registry")
                .WithContent(JsonConvert.SerializeObject(request))
                .Respond("application/json", JsonConvert.SerializeObject(ReturnT<string>.SUCCESS));

            var service = CreateService(mock);

            var result = await service.Registry(request);

            Assert.Equal(ReturnT<string>.SUCCESS_CODE, result.Code);
        }

        [Fact]
        public async Task RegistryWithTokenTest()
        {
            var request = new RegistryParam();
            request.RegistryGroup = "tms";
            request.RegistryKey = "job";
            request.RegistryValue = "export";

            var mock = new MockHttpMessageHandler();
            mock.When(HttpMethod.Post, _addressUrl + "/api/registry")
                .WithHeaders(AdminBizClient.XXL_RPC_ACCESS_TOKEN, _accessToken)
                .WithContent(JsonConvert.SerializeObject(request))
                .Respond("application/json", JsonConvert.SerializeObject(ReturnT<string>.FAIL));

            var service = CreateService(mock);

            var result = await service.Registry(request);

            Assert.Equal(ReturnT<string>.FAIL_CODE, result.Code);
        }

        [Fact]
        public async Task RegistryRemoveTest()
        {
            var request = new RegistryParam();
            request.RegistryGroup = "ccp";
            request.RegistryKey = "job";
            request.RegistryValue = "export";

            var mock = new MockHttpMessageHandler();
            mock.When(HttpMethod.Post, _addressUrl + "/api/registryRemove")
                .WithContent(JsonConvert.SerializeObject(request))
                .Respond("application/json", JsonConvert.SerializeObject(ReturnT<string>.SUCCESS));

            var service = CreateService(mock);

            var result = await service.RegistryRemove(request);

            Assert.Equal(ReturnT<string>.SUCCESS_CODE, result.Code);
        }

        [Fact]
        public async Task RegistryRemoveWithTokenTest()
        {
            _accessToken = "123456abcdef";

            var request = new RegistryParam();
            request.RegistryGroup = "ccp";
            request.RegistryKey = "job";
            request.RegistryValue = "export";

            var mock = new MockHttpMessageHandler();
            mock.When(HttpMethod.Post, _addressUrl + "/api/registryRemove")
                .WithHeaders(AdminBizClient.XXL_RPC_ACCESS_TOKEN, _accessToken)
                .WithContent(JsonConvert.SerializeObject(request))
                .Respond("application/json", JsonConvert.SerializeObject(ReturnT<string>.FAIL));

            var service = CreateService(mock);

            var result = await service.RegistryRemove(request);

            Assert.Equal(ReturnT<string>.FAIL_CODE, result.Code);
        }
    }
}
