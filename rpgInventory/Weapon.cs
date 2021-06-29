using System;

/// <summary>
/// Title: RPG Inventory
/// Author: Clark Roda
/// </summary>
namespace rpgInventory
{
    /// <summary>
    /// For Weapon items.
    /// </summary>
    public class Weapon : Wearable
    {

        public int AttackValue { get; set; }
        public int AttackSpeed { get; set; }

        private readonly Random r = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// The Weapon Constructor!
        /// </summary>
        /// <param name="whereILive">The inventory to add this item to upon instantiation</param>
        public Weapon(Inventory whereILive, string name, int value, string description, int rarity, int statBuff, int durability, int attackValue = 1, int attackSpeed = 1) : base(whereILive, name, value, description, rarity, statBuff, durability)
        {
            Durability = durability;
            AttackValue = attackValue;
            AttackSpeed = attackSpeed;
        }

        /// <summary>
        /// Preforms the attack action during battle.
        /// </summary>
        /// <returns></returns>
        public int Attack()
        {
            int damageDelt = AttackValue;

            // roll dice to apply an attack value
            // check if worn, apply bonus parameters?
            if (Wearable.equipped)
            {
                for (int i = 0; i < AttackSpeed + Rarity; i++)
                {
                    damageDelt += r.Next(1, 3 + Rarity);
                    Console.WriteLine($"Your {Name} weapon attacked for {damageDelt} damage!");
                    Durability--;

                    // do durability is 0 check
                    if (Durability < 1)
                    {
                        Console.WriteLine($"Your {Name} weapon just broke!");
                        Delete();
                    }
                    else
                    {
                        Console.WriteLine($"You have {Durability} attacks remaining.");
                    }
                }
                return damageDelt;
            }
            else
            {
                Console.WriteLine($"{Name} is not equipped");
                return 0;
            }

        }
    }
}
