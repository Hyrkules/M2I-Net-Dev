using ExoEFC.Data;
using ExoEFC.Models;

namespace ExoEFC.Repository
{
    internal class ContactRepository
    {
        public Contact Add(Contact contact)
        {
            using (var db = new ContactDbContext())
            {
                try
                {
                    db.contacts.Add(contact);
                    db.SaveChanges();
                    return contact;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public List<Contact> Get()
        {
            using (var db = new ContactDbContext())
            {
                try
                {
                    return db.contacts.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erreur lors de la récupération des contacts : " + ex.Message);
                }
            }
        }

        public Contact Get(int id)
        {
            using (var db = new ContactDbContext())
            {
                try
                {
                    return db.contacts.Find(id);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public bool Update(int id, Contact contact)
        {
            using (var db = new ContactDbContext())
            {
                Contact contactFound = Get(id);
                if (contactFound == null)
                {
                    return false;
                }
                foreach (var prop in typeof(Contact).GetProperties())
                {
                    if (prop.Name != "Id" && prop.GetValue(contact) != null)
                    {
                        prop.SetValue(contactFound, prop.GetValue(contact));
                    }
                }
                db.SaveChanges();
            }

        }

        public bool Delete(int id)
        {
            using (var db = new ContactDbContext())
            {
                Contact contactFound = Get(id);
                if (contactFound == null)
                {
                    return false;
                }
                db.contacts.Remove(contactFound);
                db.SaveChanges();
                return true;
            }
        }
    }
}