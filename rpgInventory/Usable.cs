using System;

/// <summary>
/// Title: RPG Inventory
/// Author: Clark Roda
/// </summary>
namespace rpgInventory
{
    /// <summary>
    /// The Usable class - for items that have unlimited number of uses.
    /// </summary>
    public class Usable : Item
    {
        public Usable(Inventory whereILive, string name, int value, string description, int rarity) : base(whereILive, name, value, description, rarity)
        {

        }

        /// <summary>
        /// This function is called when an item is to be used.
        /// </summary>
        public override void Use()
        {
            Console.WriteLine($"Item {Name} used!");
        }
    }
}
