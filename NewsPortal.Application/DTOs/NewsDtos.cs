namespace NewsPortal.Application.DTOs;

public record NewsCreateDto(
    string Title,
    string Slug,
    string Summary,
    string Content,
    int CategoryId,
    bool IsPublished);

public record NewsUpdateDto(
    int Id,
    string Title,
    string Slug,
    string Summary,
    string Content,
    int CategoryId,
    bool IsPublished);
