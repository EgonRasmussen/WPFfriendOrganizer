using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private FriendOrganizerDbContext _context;

        public FriendDataService(FriendOrganizerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Friend>> GetAllAsync()
        {
                return await _context.Friends.AsNoTracking().ToListAsync();
        }
    }
}
