using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Online.Application;
using Online.Domain;

namespace Online.Input.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class OnlineController : ControllerBase
{

    private readonly ILogger<OnlineController> _logger;
    private readonly IOnlineUseCase _onlineUseCase;

    public OnlineController(ILogger<OnlineController> logger, IOnlineUseCase onlineUseCase)
    {
        _logger = logger;
        _onlineUseCase = onlineUseCase;
    }

    [HttpGet(Name = "GetOnlineItems")]
    public IActionResult Get()
    {

        var res = _onlineUseCase.GetOnlineItems("jdklsa");
        
        var result = new OnlineItemsDto(res);
        var json = JsonSerializer.Serialize(result);
        return Ok(json);
    }
}

public class OnlineItemsDto
{
    public OnlineItemsDto(List<OnlineItem> items) {
            onlineItems = [];
            items.ForEach (
                item => onlineItems.Add(new OnlineItemDto(item))
            );

    }
   public List<OnlineItemDto> onlineItems {get; set;}
}

public class OnlineItemDto
{
    public OnlineItemDto(OnlineItem onlineItem) {
        field1 = onlineItem.field1;
    }

    public String field1 {get; set;}
}