using System.Net;
using System.Text;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace FunctionalsTests.StepsDefintions.Partner;

[Binding]
public class GetPartnerStepDefintions
{
    private readonly HttpClient _httpClient;
    private HttpResponseMessage _httpResponseMessage;
    public GetPartnerStepDefintions()
    {
        _httpClient = new ApplicationFactory().CreateClient();
    }

    [BeforeFeature]
    public static void CreatePartnerForGetTest()
    {
        HttpClient httpClient = new ApplicationFactory().CreateClient();

        string content = JsonSerializer.Serialize(new Application.Models.Partner() { Email = "TESTEGET@GMAIL.COM", Nome = "Teste" });

        StringContent body = new(content, Encoding.UTF8, "application/json");

        httpClient.PostAsync("/Partner", body);
    }

    [Given(@"que eu queira resgatar um parceiro")]
    public void Initialize() { }

    [When(@"eu chamar o endpoint de get de parceiro com o email ""(.*)""")]
    public async Task SendRequest(string email) => _httpResponseMessage = await _httpClient.GetAsync($"/Partner?email={email}");

    [Then(@"eu devo receber o status ""(.*)"" e o conteudo da mensagem contendo ""(.*)""")]
    public async Task ValidateResponse(HttpStatusCode statusCode, string containsResponse)
    {
        string responseContent = await _httpResponseMessage.Content.ReadAsStringAsync();

        Assert.Equal(statusCode, _httpResponseMessage.StatusCode);

        Assert.Contains(containsResponse, responseContent);
    }

    [AfterFeature]
    public static void DeletePartnerOfTest()
    {
        HttpClient httpClient = new ApplicationFactory().CreateClient();

        httpClient.DeleteAsync("Partner/TESTEGET@GMAIL.COM");
    }

}
