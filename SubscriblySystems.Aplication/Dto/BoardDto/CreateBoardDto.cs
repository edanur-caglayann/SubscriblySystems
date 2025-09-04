using subscriblySystem.Domain.Enum;

namespace SubscriblySystems.Aplication.Dto.BoardDto;

public class CreateBoardDto
{
    public string BoardName { get; set; }
    public string description { get; set; }
    public BoardTypeEnum BoardType { get; set; }
}