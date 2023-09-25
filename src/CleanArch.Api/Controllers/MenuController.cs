using CleanArch.Application.Data.Interfaces;
using CleanArch.Application.Menus.Command.Create;
using CleanArch.Presentation.Common.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenuController : ApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public MenuController(IUnitOfWork unitOfWork, ISender sender, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));

        var createMenuResult = await _sender.Send(command);

        return createMenuResult.Match(menu => Ok(_mapper.Map<MenuResponse>(menu)),
        error => Problem(error));
    }

}