using System;

/// <summary>
/// Title: RPG Inventory
/// Author: Clark Roda
/// </summary>
namespace rpgInventory
{
    /// <summary>
    /// Items that have a set number of uses
    /// </summary>
    public class Consumable : Usable
    {
        private int numberofUses;
        public int NumberOfUses
        {
            get
            {
                return numberofUses;
            }
            set
            {
                if (value > 0)
                {
                    numberofUses = value;
                }
                else
                {
                    throw new System.ArgumentException("Number of Uses must be larger than 0", "numOfUse");
                }
            }
        }
        public Consumable(Inventory whereILive, string name, int value, string description, int rarity, int numOfUse) : base(whereILive, name, value, description, rarity)
        {
            NumberOfUses = numOfUse;
        }
        public override void Use()
        {
            Console.WriteLine($"Used consumable item: {Name}");
            NumberOfUses--;
            if (NumberOfUses > 0)
            {
                Console.WriteLine($"Number of uses left: {NumberOfUses}");
            }
            else
            {
                Console.WriteLine($"This item is all used up!!");
                Delete();
            }

        }
    }
}
