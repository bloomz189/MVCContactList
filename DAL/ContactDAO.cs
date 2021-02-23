using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ContactDAO : WebDBContext
    {
        public static List<ContactDTO> GetAlls()
        {
            try
            {
                var list = db.Contacts.ToList();
                List<ContactDTO> model = new List<ContactDTO>();
                foreach (var item in list)
                {
                    ContactDTO dto = new ContactDTO();
                    dto.ID = item.Id;
                    dto.CompanyName = item.company_name;
                    dto.CompanyAddress = item.company_addr;
                    dto.CompanyTel = item.company_tel;
                    dto.ContactPerson = item.company_contact_person;
                    model.Add(dto);
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateContact(ContactDTO model)
        {
            Contact contact = db.Contacts.First(x => x.Id == model.ID);
            contact.Id = model.ID;
            contact.company_name = model.CompanyName;
            contact.company_addr = model.CompanyAddress;
            contact.company_tel = model.CompanyTel;
            contact.company_contact_person = model.ContactPerson;
            db.SaveChanges();
        }

        public ContactDTO DeleteContact(ContactDTO model)
        {
            try
            {
                Contact contact = db.Contacts.First(x => x.Id == model.ID);
                db.Contacts.Remove(contact);
                db.SaveChanges();
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ContactDTO GetDetail(int id)
        {
            Contact contact = db.Contacts.First(x => x.Id == id);
            ContactDTO dto = new ContactDTO();
            dto.ID = contact.Id;
            dto.CompanyName = contact.company_name;
            dto.CompanyAddress = contact.company_addr;
            dto.CompanyTel = contact.company_tel;
            dto.ContactPerson = contact.company_contact_person;
            return dto;
        }

        public int AddContact(Contact contact)
        {
            try
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return contact.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
