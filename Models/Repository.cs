using System.Collections.Generic;
using PartyInvites.Repository;

namespace PartyInvites.Models
{
    public class Repository
    {
        public static AppDbContext Context = new AppDbContext();

        public static IEnumerable<GuestResponse> Responses => Context.guestResponses;

        public static void AddResponse(GuestResponse guestResponse)
        {
            Context.guestResponses.Add(guestResponse);
            Context.SaveChangesAsync();
        }
    }
}
