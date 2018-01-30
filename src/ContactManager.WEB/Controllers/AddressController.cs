using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactManager.Domain.Abstract;
using ContactManager.WEB.Modules;
using ContactManager.Domain.Entitites;
using ContactManager.WEB.Extensions;
using ContactManager.WEB.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManager.WEB.Controllers
{
    public class AddressController : Controller
    {
        private IUnitOfWork context;

        public AddressController(IUnitOfWork context)
        {
            this.context = context;
        }

        // GET: /Address/Locations/
        public async Task<IActionResult> Locations([FromBody] Options options)
        {
            IQueryable<Address> query;
            long count;
            if (string.IsNullOrWhiteSpace(options.SearchBy))
            {
                query = await context.Addresses.GetAsync();
                count = await context.Addresses.CountAsync();
            }
            else
            {
                var search = SearchManager.GenerateWhere<Address>(options.SearchBy);
                query = await context.Addresses.GetAsync(search);
                count = await context.Addresses.CountAsync(search);
            }

            if (!string.IsNullOrEmpty(options.SortDirection))
            {
                query = query.OrderByField(options.SortBy, options.SortDirection == "asc");
            }

            query = query.Skip(options.PageIndex * options.PageSize).Take(options.PageSize);

            var model = new LocationsModel(count, query.Select(adr => new AddressTableModel
            {
                Id = adr.Id,
                Country = adr.Country,
                Region = adr.Region,
                City = adr.City,
                Street = adr.Street,
                Postal = adr.Postal
            }).ToList());

            return model.ToJsonResult();
        }
    }
}
