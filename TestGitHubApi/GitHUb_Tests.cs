using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestGitHubApi
{
    public class GitHUb_Tests
    {
        private RestClient client;
        private RestRequest request;

        [SetUp]
        public void Setup()
        {
            this.client = new RestClient("https://api.github.com");
            string url = "/repos/RumenRaychev74/postman/issues";

            this.request = new RestRequest(url);
        }

        [Test]
        public async Task Test_Get_Issue()
        {
            var response = await client.ExecuteAsync(request);

            var issues = JsonSerializer.Deserialize<System.Collections.Generic.List<Issue>>(response.Content);

            foreach (var issue in issues)
            {
                Assert.IsNotNull(issue.html_url);
                //Assert.IsNull(issue.id, "Issue id must not be null");
            }

            Assert.IsNotNull(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}