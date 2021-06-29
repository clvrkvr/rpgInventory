using System;

/// <summary>
/// Title: RPG Inventory
/// Author: Clark Roda
/// </summary>
namespace rpgInventory
{
    /// <summary>
    /// Armor class inherited from wearable class
    /// </summary>
    public class Armor : Wearable
    {
        public int BlockValue { get; set; }
        private readonly Random r = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// The Armor constuctor
        /// </summary>
        /// <param name="whereILive">The inventory to add this item to upon instantiation</param>
        public Armor(Inventory whereILive, string name, int value, string description, int rarity, int statBuff, int durability, int blockValue = 1) : base(whereILive, name, value, description, rarity, statBuff, durability)
        {
            BlockValue = blockValue;
        }

        /// <summary>
        /// Using armor
        /// </summary>
        public override void Use()
        {
            int block;
            // when player is struck roll to apply a block damage value
            if (EquipStatus)
            {
                block = r.Next(1, 3 * (Rarity + 1));
                Durability -= 1;
                // do durability check
                if (Durability < 1)
                {
                    Console.WriteLine($"Your {Name} armor is broken!");
                    Delete();
                }
                else
                {
                    Console.WriteLine($"You can absorb {Durability} more attacks.");
                }
                Console.WriteLine($"Your {Name} armor blocked {block} damage!");
            }
            else
            {
                Console.WriteLine($"Your {Name} armor is not equipped!");
            }
        }
    }
}
