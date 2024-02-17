using CRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Infrastructure.Interfaces
{
    public interface IUserRepo
    {
        Task<Users> GetById(int id);
        Task Add(Users entity);
        void Update(Users entity);
        void Delete(Users entity);
        Task<IEnumerable<Users>> GetAll();
    }
}
