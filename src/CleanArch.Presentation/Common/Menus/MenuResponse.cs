namespace CleanArch.Presentation.Common.Menus;

public record MenuResponse(Guid Id,
                           string Name,
                           string Description,
                           float AverageRating,
                           List<MenuSectionResponse> Sections,
                           string HostId,
                           DateTime CreateDateTime,
                           DateTime UpdateDateTime);

public record MenuSectionResponse(Guid Id,
                                  string Name,
                                  string Description,
                                  List<MenuItemResponse> Items);

public record MenuItemResponse(Guid Id,
                               string Name,
                               string Description);