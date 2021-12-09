using AddressBookWebAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookWebAPI.Models.DataManager
{
    public class PhoneDataManager : IDataRepository<Phone>
    {
        readonly AddressBookDBContext addressBookDBContext;
        public PhoneDataManager(AddressBookDBContext context)
        {
            addressBookDBContext = context;
        }
        public IEnumerable<Phone> GetAll()
        {
            return addressBookDBContext.Phones.ToList();
        }
        public Phone Get(int id)
        {
            return addressBookDBContext.Phones
                  .FirstOrDefault(e => e.UserId == id);
        }
        public void Add(Phone entity)
        {
            addressBookDBContext.Phones.Add(entity);
            addressBookDBContext.SaveChanges();
        }
        public void Update(Phone phone, Phone entity)
        {
            phone.UserId = entity.UserId;
            phone.PhonNumber = entity.PhonNumber;
            addressBookDBContext.SaveChanges();
        }
        public void Delete(Phone phone)
        {
            addressBookDBContext.Phones.Remove(phone);
            addressBookDBContext.SaveChanges();
        }
    }
}
