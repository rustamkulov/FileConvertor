using FileConvertor.Dtos.Constants;
using FileConvertor.Dtos.Login;
using FileConvertor.Integrated.Interfaces.Login;
using FileConvertor.Integrated.Security;
using Newtonsoft.Json;

namespace FileConvertor.Integrated.Services.Login;

public class LoginService : ILoginService
{
    public async Task<bool> Login(LoginDto loginDto)
    {
        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Post, BaseUrlConstants.BASE_URL + "/api/auth/login");
            var content = new StringContent(JsonConvert.SerializeObject(loginDto), null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var token = IdentitySingelton.GetInstance();

                string responseContent = await response.Content.ReadAsStringAsync();
                dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent)!;
                token.Token = jsonResponse.token.ToString();

                return true;
            }
            return false;
        }   
    }
}
