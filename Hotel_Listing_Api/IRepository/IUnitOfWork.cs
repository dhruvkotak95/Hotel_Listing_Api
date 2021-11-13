using Hotel_Listing_Api.DataModel;
using System;
using System.Threading.Tasks;

namespace Hotel_Listing_Api.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> countries { get; }

        IGenericRepository<Hotel> hotels { get; }

        Task Save();
    }
}
