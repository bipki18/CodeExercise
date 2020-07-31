﻿using Honeywell.CodeExercise.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.CodeExercise.Component.ItemComponent
{
    public interface IItemComponentRepository
    {
        Task<IEnumerable<Item>> GetAllItem();
        Task<Item> GetItemById(int itemId);
        Task<Item> GetItemsByName(string name);
        Task<Item> AddNewItem(Item item);

    }
}
