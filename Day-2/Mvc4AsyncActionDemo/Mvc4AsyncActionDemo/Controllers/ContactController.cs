using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Mvc4AsyncActionDemo.DAL.Entities;
using Mvc4AsyncActionDemo.DAL.Repository;
using Mvc4AsyncActionDemo.Models.Contact;

namespace Mvc4AsyncActionDemo.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController()
        {
            _contactRepository = new ContactRepository();
        }

        //
        // GET: /Contact/
        [HttpGet]
        [AsyncTimeout(8000)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "TimedOut")]
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            ContactFormModel model = new ContactFormModel()
                {
                    NewContact = new CreateContactModel()
                };
            model.Contacts = await _contactRepository.GetAllAsync(cancellationToken);

            return View(model);
        }


        [HttpPost]
        [AsyncTimeout(2000)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "TimedOut")]
        public async Task<ActionResult> Create(CreateContactModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var contact = new Contact()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Email = model.Email
                    };

                await _contactRepository.CreateAsync(contact, cancellationToken);

                return RedirectToAction("Index");
            }

            ContactFormModel formModel = new ContactFormModel()
            {
                NewContact = new CreateContactModel()
            };
            formModel.Contacts = await _contactRepository.GetAllAsync(cancellationToken);

            return View("Index", formModel);
        }

        [HttpGet]
        [AsyncTimeout(2000)]
        [HandleError(ExceptionType = typeof(TimeoutException), View = "TimedOut")]
        public async Task<ActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            await _contactRepository.DeleteAsync(id, cancellationToken);
            return RedirectToAction("Index");
        }
    }
}
