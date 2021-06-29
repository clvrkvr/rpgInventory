using System;

/// <summary>
/// Title: RPG Inventory
/// Author: Clark Roda
/// </summary>
namespace rpgInventory
{
    /// <summary>
    /// The Item class. This is the Base class for all Items.
    /// </summary>
    public abstract class Item
    {
        public Inventory myInventory;
        public string Name { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public int Rarity { get; set; } = 0; //default rarity is 0
        //Rarity: 0 - Common
        //        1 - Uncommon
        //        2 - Rare
        //        3 - Legendary
        public int Id { get; protected set; }

        /// <summary>
        /// Item Constructor, sets values for it's properties
        /// </summary>
        /// <param name="name">The Name of the Item.</param>
        /// <param name="val">The monitary value of the Item.</param>
        /// <param name="desc">The Item's description.</param>
        /// <param name="rarity">The item's rarity, 0 (common) to 3 (legendary)</param>
        public Item(Inventory whereILive, string name, int val, string desc, int rarity)
        {
            Name = name;
            Value = val;
            Description = desc;
            Rarity = rarity;
            Id = GenId();
            whereILive.AddItem(this);
        }

        /// <summary>
        /// Generates a random 4 digit Id that is not in use.
        /// </summary>
        /// <returns>The unique Id</returns>
        private int GenId()
        {
            Random r = new Random(DateTime.Now.Millisecond);
            int newId = r.Next(1000, 10000);
            while (Inventory.itemId.Exists(id => id == newId))
            {
                newId = r.Next(1000, 10000);
            }
            Inventory.itemId.Add(newId);
            return newId;
        }

        /// <summary>
        /// Generic Use method - will be overwitten by all subclasses
        /// </summary>
        public abstract void Use();

        public void Delete()
        {
            Inventory.DeleteMe(Id);
        }
    }
}
