using Hotel_Listing_Api.DataModel;
using Hotel_Listing_Api.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_Listing_Api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        private IGenericRepository<Country> _countries;
        private IGenericRepository<Hotel> _hotels;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IGenericRepository<Country> countries => _countries ??= new GenericRepository<Country>(_databaseContext);

        public IGenericRepository<Hotel> hotels => _hotels ??= new GenericRepository<Hotel>(_databaseContext);

        public void Dispose()
        {
            _databaseContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
