using Core.Services;

namespace Core.Interfaces
{
    public interface ICustomer
    {
        Task<dynamic> PostData(SeminarData seminar);
    }
}
