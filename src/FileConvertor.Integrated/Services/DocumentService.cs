using FileConvertor.Dtos.Constants;
using FileConvertor.Dtos.DocumentDto;
using FileConvertor.Integrated.Interfaces;
using FileConvertor.Integrated.Security;

namespace FileConvertor.Integrated.Services;

public class DocumentService : IDocumentService
{
    async public Task<bool> CreateAsync(DocumentDto dto)
    {
        var token = IdentitySingelton.GetInstance().Token;
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, BaseUrlConstants.BASE_URL + "/api/convertor/convert");
        request.Headers.Add("Authorization", $"Bearer {token}");
        var content = new MultipartFormDataContent();

        content.Add(new StringContent(dto.DocumentType), "fileType");
        content.Add(new StreamContent(File.OpenRead(dto.Document)), "file", dto.Document);

        request.Content = content;
        var response = await client.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            var res = await response.Content.ReadAsStringAsync();
            return true;
        }
        return false;
    }
}
