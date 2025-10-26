using Gherkin.Ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FunctionalsTests.StepsDefintions.Partner;

[Binding]
public class DeletePartnerStepDefinitions
{
    private readonly HttpClient _httpClient;
    private HttpResponseMessage _httpResponseMessage;

    public DeletePartnerStepDefinitions()
    {
        _httpClient = new ApplicationFactory().CreateClient();
    }

    [BeforeFeature]
    public static void CreatePartnerForDeleteTest()
    {
        HttpClient httpClient = new() { BaseAddress = new Uri("http://localhost:5280") };

        string content = JsonSerializer.Serialize(new Application.Models.Partner() { Email = "TESTEDELETE@GMAIL.COM", Nome = "Teste" });

        StringContent body = new(content, Encoding.UTF8, "application/json");

        httpClient.PostAsync("/Partner", body); 
    }

    [Given(@"que eu queira deletar um parceiro")]
    public void Initialize() { }

    [When(@"eu chamar o endpoint de deleção de parceiro com o email ""(.*)""")]
    public async Task SendRequest(string email) => _httpResponseMessage =  await _httpClient.DeleteAsync($"/Partner/{email}");

    [Then(@"eu devo receber o status ""(.*)"" com a mensagem ""(.*)""")]
    public async Task ValidateResponse(HttpStatusCode statusCode, string messageResponse)
    {
        string responseContent = await _httpResponseMessage.Content.ReadAsStringAsync();

        Assert.Equal(statusCode, _httpResponseMessage.StatusCode);

        Assert.Contains(messageResponse, responseContent);
    }
}
