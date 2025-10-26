using System.Net;
using System.Text;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace FunctionalsTests.StepsDefintions.Partner;

[Binding]
public class CreatePartnerStepDefinitions
{
    private HttpClient _httpClient;
    private HttpResponseMessage _httpResponseMessage;
    public CreatePartnerStepDefinitions()
    {
        _httpClient = new ApplicationFactory().CreateClient();
    }

    [Given(@"que eu queira adicionar um novo parceiro")]
    public void Initialize() { }

    [When(@"eu chamar o endpoint de criação de parceiro passando o email ""(.*)"" e o usuario ""(.*)""")]
    public async Task SendRequest(string email,string usuario) => await Send(email, usuario);

    [Then(@"eu devo receber o status ""(.*)"" e a mensagem ""(.*)""")]
    public async Task ValidateResponse(HttpStatusCode statusCode, string messageResponse)
    {
        string responseContent = await _httpResponseMessage.Content.ReadAsStringAsync();

        Assert.Equal(statusCode, _httpResponseMessage.StatusCode);

        Assert.Contains(messageResponse, responseContent);
    }

    private async Task Send(string email, string nome)
    {
        string content = JsonSerializer.Serialize(new Application.Models.Partner() { Email = email, Nome = nome });

        StringContent body = new(content, Encoding.UTF8, "application/json");

        _httpResponseMessage = await _httpClient.PostAsync("/Partner", body);
    }
    [AfterFeature]
    public static void DeletePartnerOfTest()
    {
        HttpClient httpClient = new ApplicationFactory().CreateClient();

        httpClient.DeleteAsync("Partner/TESTE@GMAIL.COM");
    }
}
