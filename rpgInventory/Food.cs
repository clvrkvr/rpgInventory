using System;

/// <summary>
/// Title: RPG Inventory
/// Author: Clark Roda
/// </summary>
namespace rpgInventory
{
    /// <summary>
    /// For Food items
    /// </summary>
    public class Food : Consumable
    {

        public string FoodIngredient { get; set; }
        /// <summary>
        /// Creates a Food item
        /// </summary>
        /// <param name="name">Food's Name</param>
        /// <param name="value">Food's Value</param>
        /// <param name="description">Food's Description</param>
        /// <param name="rarity">Food's RRarity</param>
        /// <param name="ingredient">Food's Ingredient</param>
        public Food(Inventory whereILive, string name, int value, string description, int rarity, int numOfUse, string ingredient) : base(whereILive, name, value, description, rarity, numOfUse)
        {
            NumberOfUses = 1;
            FoodIngredient = ingredient;
        }

        /// <summary>
        /// Eat some food.
        /// </summary>
        public override void Use()
        {
            Console.WriteLine($"You eat {Name}, it has {FoodIngredient}!");
            NumberOfUses--;
            if (NumberOfUses < 1)
            {
                Console.WriteLine($"That was yummy!");
                Delete();
            }
            else
            {
                Console.WriteLine($"There are {NumberOfUses} uses left.");
            }
        }

    }
}
