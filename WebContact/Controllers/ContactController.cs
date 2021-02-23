using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebContact.Controllers
{
    public class ContactController : Controller
    {
        List<ContactDTO> contactLists = new List<ContactDTO>();
        ContactBLL bll = new ContactBLL();
        // GET: Contact
        public ActionResult Index()
        {
            contactLists = bll.GetAlls();
            return View(contactLists);
        }
        public ActionResult Add()
        {
            ContactDTO model = new ContactDTO();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(ContactDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.AddContact(model))
                {
                    ViewBag.ProcessState = General.Notify.InsertSuccess;
                    ModelState.Clear();
                    contactLists = bll.GetAlls();
                    return View("Index", contactLists);
                }
                else
                {
                    ViewBag.ProcessState = General.Notify.UpdateFail;
                    return View("Add", model);
                }
            }
            else
            {
                ViewBag.ProcessState = General.Notify.EmptyData;
            }
            return View("Add", model);
        }

        public ActionResult Edit(int id)
        {
            ContactDTO dto = new ContactDTO();
            dto = bll.GetDetail(id);
            return View(dto);
        }
        [HttpPost]
        public ActionResult Edit(ContactDTO model)
        {
            if (ModelState.IsValid)
            {
                if (bll.UpdateContact(model))
                {
                    ViewBag.ProcessState = General.Notify.UpdateSuccess;
                    ModelState.Clear();
                        contactLists = bll.GetAlls();
                        return View("Index", contactLists);
                    }
                else
                {
                    ViewBag.ProcessState = General.Notify.UpdateFail;
                    return View("Edit", model);
                }
            }
            else
            {
                ViewBag.ProcessState = General.Notify.EmptyData;
            }
                return View("Edit", model);
                
        }

        public ActionResult View(int id)
        {
            ViewBag.ViewType = "ReadOnly";
            ContactDTO dto = new ContactDTO();
            dto = bll.GetDetail(id);
            return View(dto);
        }
        
        public ActionResult Delete(int id)
        {
            ViewBag.ViewType = "ReadOnly";
            ContactDTO dto = new ContactDTO();
            dto = bll.GetDetail(id);
            return View(dto);
        }
        [HttpPost]
        public ActionResult Delete(ContactDTO model)
        {
            ContactDTO dto = new ContactDTO();
            dto = bll.GetDetail(model.ID);
            if (dto != null)
            {
                bll.DeleteContact(model);
                var abc = ModelState;
                ViewBag.ProcessState = General.Notify.UpdateSuccess;
            } 
            else
            {
                ViewBag.ProcessState = General.Notify.EmptyData;
            }

            ViewBag.ViewType = "ReadOnly";
            return View(dto);
        }
    }

}