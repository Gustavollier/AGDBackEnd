using Application.Enum;
using System.Net;
using System.Text;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace FunctionalsTests.StepsDefintions.Complaint;

[Binding]
public class CreateComplanitStepDefinitions
{
    private HttpClient _httpClient;
    private HttpResponseMessage _httpResponseMessage;

    public CreateComplanitStepDefinitions()
    {
        _httpClient = new ApplicationFactory().CreateClient();
    }

    [Given(@"que eu queira criar uma nova denuncia")]
    public void Initialize() { }

    [When(@"eu chamar o endpoint de criação de denuncia passando a category ""(.*)"", description ""(.*)"" e parceiro com email ""(.*)"" e nome ""(.*)""")]
    public async Task Send(EESGCategory category, string description, string email, string nome)
    {
        string content;

        if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(nome))
            content = JsonSerializer.Serialize(new Application.Models.Complaint() { Category = category, Description = description, Partner = null });
        else
            content = JsonSerializer.Serialize(new Application.Models.Complaint() { Category = category, Description = description, Partner = new Application.Models.Partner() { Email = email, Nome = nome } });

        StringContent body = new(content, Encoding.UTF8, "application/json");

        _httpResponseMessage = await _httpClient.PostAsync("/Complaint", body);
    }

    [Then(@"eu devo receber o status ""(.*)"" e a mensagem de retorno ""(.*)""")]
    public async Task ValidateResponse(HttpStatusCode statusCode, string messageResponse)
    {
        string responseContent = await _httpResponseMessage.Content.ReadAsStringAsync();

        Assert.Equal(statusCode, _httpResponseMessage.StatusCode);

        Assert.Contains(messageResponse, responseContent);
    }
   
    //[AfterFeature]
    //public static void DeletePartnerOfTest()
    //{
    //    HttpClient httpClient = new() { BaseAddress = new Uri("http://localhost:5280") };

    //    httpClient.DeleteAsync("Partner/TESTE@GMAIL.COM");
    //}
}
