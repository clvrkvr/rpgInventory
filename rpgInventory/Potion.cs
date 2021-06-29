using System;

/// <summary>
/// Title: RPG Inventory
/// Author: Clark Roda
/// </summary>
namespace rpgInventory
{
    /// <summary>
    /// For Potion items
    /// </summary>
    public class Potion : Consumable
    {
        public string Effect { get; set; }

        /// <summary>
        /// Creates a Potion item.
        /// </summary>
        /// <param name="name">Potion's Name</param>
        /// <param name="value">Potion's Value</param>
        /// <param name="description">Potion's Description</param>
        /// <param name="rarity">Potion's Rarity</param>
        /// <param name="effect">Potion's Effect (ex: health || mana)</param>
        public Potion(Inventory whereILive, string name, int value, string description, int rarity, int numOfUse, string effect) : base(whereILive, name, value, description, rarity, numOfUse)
        {
            Effect = effect;
        }

        /// <summary>
        /// Drink a potion
        /// </summary>
        public override void Use()
        {
            Console.WriteLine($"You drank {Name}! Your {Effect} has been restored!");
            NumberOfUses--;
            if (NumberOfUses < 1)
            {
                Console.WriteLine("Potion all used up!");
                Delete();
            }
            else
            {
                Console.WriteLine($"There are {NumberOfUses} uses left.");
            }
        }
    }
}
