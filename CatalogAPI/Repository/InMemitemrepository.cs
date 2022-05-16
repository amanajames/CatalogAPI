using CatalogApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogApi.Repository
{
    public class InMemitemrepository : IInMemitemrepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = System.Guid.NewGuid(), Name = "potion", Price = 9, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = System.Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = System.Guid.NewGuid(), Name = "Bronze Shield", Price = 15, CreatedDate = DateTimeOffset.UtcNow },
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid Id)
        {
            return items.Where(item => item.Id == Id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(exixtingItem => exixtingItem.Id == item.Id);
            items[index] = item;
        }

        public void Delete(Guid id)
        {
            var index = items.FindIndex(exixtingItem => exixtingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}
