using CatalogApi.Model;
using System;
using System.Collections.Generic;

namespace CatalogApi.Repository
{
    public interface IInMemitemrepository
    {
        Item GetItem(Guid Id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void Delete(Guid id);
    }
}