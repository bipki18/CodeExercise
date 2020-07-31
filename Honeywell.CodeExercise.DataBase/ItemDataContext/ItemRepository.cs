using Honeywell.CodeExercise.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeywell.CodeExercise.DataBase.ItemDataContext
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext appDbContext;

        public ItemRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Item> AddItem(Item item)
        {
            var result = await appDbContext.Items.AddAsync(item);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteItem(int itemId)
        {
            var result = await appDbContext.Items
                .FirstOrDefaultAsync(e => e.Id == itemId);
            if (result != null)
            {
                appDbContext.Items.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Item>> GetItem()
        {
            return await appDbContext.Items.ToListAsync();
        }

        public async Task<Item> GetItem(int itemId)
        {
            return await appDbContext.Items.FirstOrDefaultAsync(e => e.Id == itemId);
        }

        public async Task<Item> GetItemsByName(string name)
        {
            return await appDbContext.Items.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<Item> UpdateItem(Item item)
        {
            var result = await appDbContext.Items
                .FirstOrDefaultAsync(e => e.Id == item.Id);

            if (result != null)
            {
                result.Name = item.Name;
                result.Description = item.Description;
                result.SubCategoryId = item.SubCategoryId;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
