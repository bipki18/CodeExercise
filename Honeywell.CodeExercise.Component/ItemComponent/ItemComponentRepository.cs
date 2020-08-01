using Honeywell.CodeExercise.DataBase.ItemDataContext;
using Honeywell.CodeExercise.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.CodeExercise.Component.ItemComponent
{
    public class ItemComponentRepository : IItemComponentRepository
    {
        private readonly IItemRepository itemRepository;

        public ItemComponentRepository(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public async Task<Item> AddNewItem(Item item)
        {
            try
            {
                return await itemRepository.AddItem(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Item>> GetAllItem()
        {
            try
            {
                return await itemRepository.GetItem();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Item> GetItemById(int itemId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ItemViewModel>> GetItemsByName(string name)
        {
            try
            {
                return await itemRepository.GetItemsByName(name);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
