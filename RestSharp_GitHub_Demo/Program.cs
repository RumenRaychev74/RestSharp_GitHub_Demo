


using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Text.Json;

var client = new RestClient("https://api.github.com");
client.Authenticator = new HttpBasicAuthenticator("RumenRaychev74", "");

string url = "/repos/RumenRaychev74/postman/issues";

var request = new RestRequest(url);

request.AddUrlSegment("user", "RumenRaychev74");
request.AddUrlSegment("repos", "postman");


var response = await client.ExecuteAsync(request, Method.Post);

//var repos = JsonSerializer.Deserialize<System.Collections.Generic.List<Repo>>(response.Content);

var issues = JsonSerializer.Deserialize<System.Collections.Generic.List<Issue>>(response.Content);

foreach (var issue in issues)
{
    Console.WriteLine("ISSUE NUMBERS:" + issue.number);
}

