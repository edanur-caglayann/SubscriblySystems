using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SubscriblySystems.Api.Dto.BoardDto;
using SubscriblySystems.Aplication.Dto.BoardDto;
using SubscriblySystems.Aplication.Services.BoardService;

namespace SubscriblySystems.Api.Controller;

[ApiController]
[Route("api/board")]
public class BoardController(BoardService boardService, Mapper mapper) : ControllerBase
{
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateBoard([FromBody] CreateBoardRequestDto createBoard)
    {
        if (createBoard == null)
            throw new ArgumentNullException(nameof(createBoard));

        var response = await boardService.CreateBoard(new CreateBoardDto
        {
        BoardName = createBoard.BoardName,
        BoardType = createBoard.BoardType,
        description = createBoard.description,
        });
        
        if(response == true) return Ok();
        return BadRequest("Pano olusturulamadi");
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteBoard(DeleteBoardRequestDto deleteBoardRequestDto)
    {
        if(deleteBoardRequestDto is null) throw new ArgumentNullException(nameof(deleteBoardRequestDto));
        
        var dto = mapper.Map<DeleteBoardDto>(deleteBoardRequestDto);
        var deleteResponse = await boardService.DeleteBoard(dto);
        
        if(deleteResponse == true) return Ok();
        return BadRequest("Pano olusturulamadi");
    }
    
}