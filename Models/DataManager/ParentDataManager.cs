using AddressBookWebAPI.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookWebAPI.Models.DataManager
{
    public class ParentDataManager : IDataRepository<Parent>
    {
        readonly AddressBookDBContext addressBookDBContext;
        public ParentDataManager(AddressBookDBContext context)
        {
            addressBookDBContext = context;
        }
        public IEnumerable<Parent> GetAll()
        {
            return addressBookDBContext.Parents.ToList();
        }
        public Parent Get(int id)
        {
            return addressBookDBContext.Parents
                  .FirstOrDefault(e => e.UserId == id);
        }
        public void Add(Parent entity)
        {
            addressBookDBContext.Parents.Add(entity);
            addressBookDBContext.SaveChanges();
        }
        public void Update(Parent parent, Parent entity)
        {
            parent.UserId = entity.UserId;
            parent.FatherId = entity.FatherId;
            parent.MotherId = entity.MotherId;
            addressBookDBContext.SaveChanges();
        }
        public void Delete(Parent parent)
        {
            addressBookDBContext.Parents.Remove(parent);
            addressBookDBContext.SaveChanges();
        }
    }
}
