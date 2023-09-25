using FileConvertor.Dtos.DocumentDto;

namespace FileConvertor.Integrated.Interfaces;

public interface IDocumentService
{
    public Task<bool> CreateAsync(DocumentDto dto);
}
