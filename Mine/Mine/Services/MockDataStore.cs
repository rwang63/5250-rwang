using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Master Sword", Description="A legendary sword only to be wielded by a true hero.", Value=10 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Hylian Shield", Description="A light and sturdy shield wielded by knights of the highest order.", Value=8 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Bow of Light", Description="A powerful bow blessed by the Princess to seal away the darkness.", Value=9 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Pot Lid", Description="A basic wooden pot lid that can be used as a shield.", Value=1 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Soup Ladle", Description="A kitchen tool used for cooking and serving soup. Can be used as a weapon if necessary.", Value=2 },
            };
        }

        public async Task<bool> CreateAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}