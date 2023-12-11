using FurnitureStore.API.Entities;

namespace FurnitureStore.API.Services.Interfaces
{
    public interface IDolarRepository
    {
        Task<DolarResponse> GetDolar();
    }
}
