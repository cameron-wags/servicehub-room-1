using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceHub.Room.Context.Repository
{
    public class RoomsRepository: IRoomsRepository
    {
        public void Insert(Models.Room room)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Models.Room> Get()
        {
            throw new NotImplementedException();
        }

        public Models.Room GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.Room room)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
