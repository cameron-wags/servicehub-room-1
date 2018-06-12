using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceHub.Room.Context.Repository
{
    public interface IRoomsRepository
    {

        void Insert(Models.Room room);
        List<Models.Room> Get();
        Models.Room GetById(Guid id);
        void Update(Models.Room room);
        void Delete(Guid id);

    }
}
