using CatalogApi.Model;
using CatalogApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CatalogApi.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly InMemitemrepository _inMemItems;

        public ItemsController()
        {
            _inMemItems = new InMemitemrepository();
        }
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = _inMemItems.GetItems();
            return items;
        }
    }
}
