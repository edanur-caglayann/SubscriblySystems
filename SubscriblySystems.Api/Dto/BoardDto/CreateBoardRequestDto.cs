using subscriblySystem.Domain.Enum;

namespace SubscriblySystems.Api.Dto.BoardDto;

public class CreateBoardRequestDto
{
    public string BoardName { get; set; }
    public string description { get; set; }
    public BoardTypeEnum BoardType { get; set; }
}