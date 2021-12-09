using AddressBookWebAPI.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookWebAPI.Models.DataManager
{
    public class UserDataManager : IDataRepository<User>
    {
        readonly AddressBookDBContext addressBookDBContext;
        public UserDataManager(AddressBookDBContext context)
        {
            addressBookDBContext = context;
        }
        public IEnumerable<User> GetAll()
        {
            return addressBookDBContext.Users.ToList();
        }
        public User Get(int id)
        {
            return addressBookDBContext.Users
                  .FirstOrDefault(e => e.UserId == id);
        }
        public void Add(User entity)
        {
            addressBookDBContext.Users.Add(entity);
            addressBookDBContext.SaveChanges();
        }
        public void Update(User user, User entity)
        {
            user.UserFirstName = entity.UserFirstName;
            user.UserLastName = entity.UserLastName;
            user.UserEmail = entity.UserEmail;
            user.UserDateOfBirth = entity.UserDateOfBirth;
            user.UserPhoneNumber = entity.UserPhoneNumber;
            addressBookDBContext.SaveChanges();
        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        public void Delete(User user)
        {
            addressBookDBContext.Users.Remove(user);
            addressBookDBContext.SaveChanges();
        }

    }
}
