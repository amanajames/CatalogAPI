using CatalogApi.Dto;
using CatalogApi.Model;
using CatalogApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogApi.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IInMemitemrepository _inMemItems;

        public ItemsController(IInMemitemrepository inMemItems)
        {
            _inMemItems = inMemItems;
        }
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = _inMemItems.GetItems().Select(item => item.AsDto());
            return items;
        }
        [HttpGet("{Id}")]
        public ActionResult<ItemDto> GetItem(Guid Id)
        {
            var item = _inMemItems.GetItem(Id);

            if(item == null)
            {
                return NotFound();
            }
            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            _inMemItems.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = _inMemItems.GetItem(id);

            if(existingItem == null)
            {
                return NotFound();
            }
            existingItem.Name = itemDto.Name;
            existingItem.Price = itemDto.Price;

            _inMemItems.UpdateItem(existingItem);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = _inMemItems.GetItem(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            _inMemItems.Delete(id);

            return NoContent();
        }
    }
}
