using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ContactBLL
    {
        ContactDAO dao = new ContactDAO();
        public List<ContactDTO> GetAlls()
        {
            return ContactDAO.GetAlls();
        }

        public bool AddContact(ContactDTO model)
        {
            Contact contact = new Contact();
            contact.Id = model.ID;
            contact.company_name = model.CompanyName;
            contact.company_addr = model.CompanyAddress;
            contact.company_tel = model.CompanyTel;
            contact.company_contact_person = model.ContactPerson;
            dao.AddContact(contact);
            return true;
        }

        public ContactDTO GetDetail(int id)
        {
            return dao.GetDetail(id);
        }

        public bool UpdateContact(ContactDTO model)
        {
            dao.UpdateContact(model);
            return true;
        }

        public ContactDTO DeleteContact(ContactDTO model)
        {
            return dao.DeleteContact(model);
        }
    }
}
