using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepositoy : IDatingRepository
    {
        private readonly DataContext _context;
        public DatingRepositoy(DataContext context)
        {
            this._context = context;

        }

        public void Add<T>(T enitity) where T : class
        {
            
            _context.Add(enitity);
        }

        public void Delete<T>(T enitity) where T : class
        {
            _context.Remove(enitity);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
            return photo;
        }
        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p=>p.Photos).FirstOrDefaultAsync(u => u.Id == id);
           return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
           return await _context.SaveChangesAsync() > 0;
           
        }
    }
}