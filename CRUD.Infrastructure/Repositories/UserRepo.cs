using CRUD.Domain.Entities;
using CRUD.Infrastructure.Data;
using CRUD.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Infrastructure.Repositories
{
    public class UserRepo : IUserRepo
    {
        public readonly AppDBContext _appDBContext;
        public UserRepo(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }

        public async Task<Users> GetById(int id)
        {
            return await _appDBContext.Users.FindAsync(id);
        }

        public async Task Add(Users entity)
        {
            await _appDBContext.Users.AddAsync(entity);
            await _appDBContext.SaveChangesAsync();
        }

        public void Update(Users entity)
        {
            _appDBContext.Entry(entity).State = EntityState.Modified;
            _appDBContext.SaveChanges();
        }

        public void Delete(Users entity)
        {
            _appDBContext.Users.Remove(entity);
            _appDBContext.SaveChanges();
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            return await _appDBContext.Users.ToListAsync();
        }
    }
}
