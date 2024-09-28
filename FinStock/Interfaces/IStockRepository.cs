using FinStock.Dtos.Stock;
using FinStock.Models;

namespace FinStock.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id); // FirstOrDefault can be null;
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateByIdAsync(int id, UpdateStockRequestDto stockDto);
        Task<Stock?> DeleteByIdAsync(int id);
        Task<bool> StockExist(int id);
    }
}