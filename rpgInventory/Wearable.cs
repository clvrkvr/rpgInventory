using System;

/// <summary>
/// Title: RPG Inventory
/// Author: Clark Roda
/// </summary>
namespace rpgInventory
{
    /// <summary>
    /// The Wearable class is for items that players are meant to equip.
    /// </summary>
    public class Wearable : Item
    {
        public static bool equipped = false;
        public static int equippedId;
        protected int StatBuff { get; set; }
        protected int Durability { get; set; }
        protected bool EquipStatus { get; set; } = false;

        public Wearable(Inventory whereILive, string name, int value, string description, int rarity, int statBuff, int durability) : base(whereILive, name, value, description, rarity)
        {
            switch (rarity)
            {
                case 0:
                    StatBuff = 0;
                    Durability = 0;
                    break;
                case 1:
                    ApplyBonusStat(statBuff);
                    ApplyBonusDurability(durability);
                    break;
                case 2:
                    ApplyBonusStat(statBuff, statBuff);
                    ApplyBonusDurability(durability, durability);
                    break;
                case 3:
                    ApplyBonusStat(statBuff, statBuff, statBuff);
                    ApplyBonusDurability(durability, durability, durability);
                    break;
                default:
                    Console.WriteLine("Rarity doesn't exist!");
                    break;
            }
        }

        /// <summary>
        /// This function sets the value of the Equip Status to true.
        /// </summary>
        public void Equip()
        {
            Wearable.equipped = true;
            Wearable.equippedId = this.Id;
            Console.WriteLine("Item has been equipped!");
        }

        /// <summary>
        /// This function sets the value of the Equip Status to false.
        /// </summary>
        public void Unequip()
        {
            Wearable.equipped = false;
            Console.WriteLine("Item has been unequipped!");
        }

        /// <summary>
        /// This function is called when the item is of a common type and sets the StatBuff value accordingly.
        /// </summary>
        /// <param name="statBuff">The value to be assigned to the StatBuff.</param>
        public void ApplyBonusStat(int statBuff)
        {
            StatBuff = statBuff;
        }

        /// <summary>
        /// This function is called when the item is of a rare type and sets the StatBuff value accordingly.
        /// In this case, there will be two parameters containing two values to be added to StatBuff due to the rarity of the item.
        /// </summary>
        /// <param name="statBuff">The value to be assigned to the StatBuff.</param>
        /// <param name="statBuff1">Extra value to be added to the StatBuff.</param>
        public void ApplyBonusStat(int statBuff, int statBuff1)
        {
            StatBuff = statBuff + statBuff1;
        }

        /// <summary>
        /// This function is called when the item is of a legendary type and sets the StatBuff value accordingly.
        /// In this case, there will be three parameters containing three values to be added to StatBuff due to the item being a legendary type.
        /// </summary>
        /// <param name="statBuff">The value to be assigned to the StatBuff.</param>
        /// <param name="statBuff1">Extra value added to the StatBuff.</param>
        /// <param name="statBuff2">Another extra value added to the StatBuff.</param>
        public void ApplyBonusStat(int statBuff, int statBuff1, int statBuff2)
        {
            StatBuff = statBuff + statBuff1 + statBuff2;
        }

        /// <summary>
        /// This function is called when the item is of a common type and sets the Durability value accordingly.
        /// </summary>
        /// <param name="durability">The value to be assigned to the Durability.</param>
        public void ApplyBonusDurability(int durability)
        {
            Durability = durability;
        }

        /// <summary>
        /// This function is called when the item is of a rare type and sets the Durability value accordingly.
        /// In this case, there will be two parameters containing two values to be added to Durability due to the rarity of the item.
        /// </summary>
        /// <param name="durability">The value to be assigned to the Durability.</param>
        /// <param name="durability1">Extra value to be added to the Durability.</param>
        public void ApplyBonusDurability(int durability, int durability1)
        {
            Durability = durability + durability1;
        }

        /// <summary>
        /// This function is called when the item is of a legendary type and sets the Durability value accordingly.
        /// In this case, there will be three parameters containing three values to be added to Durability due to the item being a legendary type.
        /// </summary>
        /// <param name="durability">The value to be assigned to the Durability.</param>
        /// <param name="durability1">Extra value added to the Durability.</param>
        /// <param name="durability2">Another extra value added to the Durability.</param>
        public void ApplyBonusDurability(int durability, int durability1, int durability2)
        {
            Durability = durability + durability1 + durability2;
        }

        /// <summary>
        /// Wearable Use - uses the item if equipped
        /// </summary>
        public override void Use()
        {
            if (Wearable.equipped)
            {
                Console.WriteLine($"Item {Name} used!");
            }
            else
            {
                Console.WriteLine($"Item not equipped!!");
            }
        }

    }
}
