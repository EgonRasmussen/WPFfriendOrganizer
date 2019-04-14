using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private FriendOrganizerDbContext _contextCreator;

        public FriendDataService(FriendOrganizerDbContext contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<List<Friend>> GetAllAsync()
        {
            using (var ctx = _contextCreator)
            {
                return await ctx.Friends.AsNoTracking().ToListAsync();
            }
        }
    }
}
