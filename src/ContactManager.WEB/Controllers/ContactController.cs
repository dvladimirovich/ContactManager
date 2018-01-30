using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactManager.WEB.Extensions;
using ContactManager.Domain.Abstract;
using ContactManager.WEB.Modules;
using ContactManager.Domain.Entitites;
using Newtonsoft.Json;
using ContactManager.WEB.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManager.WEB.Controllers
{
    public class ContactController : Controller
    {
        private IUnitOfWork context;

        public ContactController(IUnitOfWork context)
        {
            this.context = context;
        }

        // GET: /Contact/Contacts/
        public async Task<IActionResult> Contacts([FromBody] Options options)
        {
            IQueryable<Person> query;
            long count;
            if (string.IsNullOrWhiteSpace(options.SearchBy))
            {
                query = await context.People.GetAsync();
                count = await context.People.CountAsync();
            }
            else
            {
                var search = SearchManager.GenerateWhere<Person>(options.SearchBy);
                query = await context.People.GetAsync(search);
                count = await context.People.CountAsync(search);
            }
            
            if (!string.IsNullOrEmpty(options.SortDirection))
            {
                query = query.OrderByField(options.SortBy == "FullName" ? "FirstName" : options.SortBy, options.SortDirection == "asc");
            }

            query = query.Skip(options.PageIndex * options.PageSize).Take(options.PageSize);

            var model = new ContactsModel(count, query.Select(p => new PersonTableModel
            {
                Id = p.Id,
                FullName = p.FirstName + " " + p.LastName,
                Birth = p.Birth.ToString("d MMM yyyy"),
                Email = p.Email,
                Phone = p.Phone,
                AddressId = p.AddressId
            }).ToList());

            return model.ToJsonResult();
        }
    }
}
