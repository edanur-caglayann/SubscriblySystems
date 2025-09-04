using subscriblySystem.Domain.Entities;
using SubscriblySystems.Aplication.Dto.BoardDto;
using SubscriblySystems.Aplication.Repositories.BoardRepositories;
using SubscriblySystems.Aplication.Repositories.UserRepositories;
using SubscriblySystems.Aplication.Services.UserService;

namespace SubscriblySystems.Aplication.Services.BoardService;

public class BoardService(IBoardWriteRepository boardWrite, IBoardReadRepository boardRead)
{

    public async Task<bool> CreateBoard(CreateBoardDto createBoardDto)
    {
        var Board = await boardWrite.AddAsync(new Board
        {
            IsActive = true,
            BoardName = createBoardDto.BoardName,
            description = createBoardDto.description,
            BoardType = createBoardDto.BoardType,
            
        });

        var boardResult = await boardWrite.SaveAsync();
        
        if(!Board)
            throw new Exception("Failed to create board");
        
       return true;
    }

    public async Task<bool> DeleteBoard(DeleteBoardDto deleteBoardDto)
    {
        var board = await boardRead.GetByIdAsync(deleteBoardDto.Id);
        if(board == null) return false;
        
        var deleteResult = await boardWrite.DeleteAsync(board.Id);
        if(!deleteResult)
            throw new Exception("Failed to delete board");
        
        var saveResult = await boardWrite.SaveAsync();
        return saveResult > 0;
    }
}