using AddressBookWebAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookWebAPI.Models.DataManager
{
    public class FriendDataManager : IDataRepository<Friend>
    {
        readonly AddressBookDBContext addressBookDBContext;
        public FriendDataManager(AddressBookDBContext context)
        {
            addressBookDBContext = context;
        }
        public IEnumerable<Friend> GetAll()
        {
            return addressBookDBContext.Friends.ToList();
        }
        public Friend Get(int id)
        {
            return addressBookDBContext.Friends
                  .FirstOrDefault(e => e.FriendId == id);
        }
        public void Add(Friend entity)
        {
            addressBookDBContext.Friends.Add(entity);
            addressBookDBContext.SaveChanges();
        }
        public void Update(Friend friend, Friend entity)
        {
            friend.UserId = entity.UserId;
            friend.FriendId = entity.FriendId;
            addressBookDBContext.SaveChanges();
        }
        public void Delete(Friend friend)
        {
            addressBookDBContext.Friends.Remove(friend);
            addressBookDBContext.SaveChanges();
        }
    }
}
