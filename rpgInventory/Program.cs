using System;
using System.Collections.Generic;

/// <summary>
/// Title: RPG Inventory
/// Author: Clark Roda
/// </summary>
namespace rpgInventory
{
    class Program
    {
        /// <summary>
        /// The main method and execution of the program.
        /// </summary>
        static void Main(string[] args)
        {
            //Instatiate all items for the Game Inventory
            Inventory GameInventory = new Inventory();
            Inventory PlayerInventory = new Inventory();
            Weapon Sword = new Weapon(GameInventory, "Excaliber", 100, "the legendary sword", 3, 10, 100);
            Weapon Axe = new Weapon(GameInventory, "Hammer", 25, "a two handed gold axe", 1, 2, 20);
            Weapon Dagger = new Weapon(GameInventory, "Sting", 10, "a wooden dagger", 0, 0, 10);
            Armor Helmet = new Armor(GameInventory, "Helm", 50, "a dwarven helmet", 1, 2, 25);
            Armor Chainmail = new Armor(GameInventory, "Chainy", 185, "silver elf mail", 3, 10, 100);
            Potion HealingPotion = new Potion(GameInventory, "Healing Potion", 5, "A potion that restores health", 0, 5, "health");
            Food Pie = new Food(GameInventory, "Pie", 3, "A wonderful fruit pie", 0, 1, "apples");
            Wearable Necklace = new Wearable(GameInventory, "Necklace of Wonder", 85, "A magical necklace of wonder", 3, 2, 8);
            Usable Hearthstone = new Usable(GameInventory, "Hearthstone", 40, "A stone that teleports a player back home", 1);
            Armor Defaultarmor = new Armor(GameInventory, "Default Armor", 10, "Starting Armor", 0, 0, 20);
            Weapon SmallSword = new Weapon(GameInventory, "Small sword", 5, "A small sword you start the game with", 0, 0, 100);
            Potion ManaPotion = new Potion(GameInventory, "Mana Potion", 5, "A potion that restores mana", 0, 4, "mana");
            Consumable Charm = new Consumable(GameInventory, "Magic Charm", 60, "A strange magic charm", 3, 2);

            //Transfer starting items
            GameInventory.Transfer(ref PlayerInventory, SmallSword.Id);
            GameInventory.Transfer(ref PlayerInventory, Defaultarmor.Id);
            GameInventory.Transfer(ref PlayerInventory, HealingPotion.Id);
            GameInventory.Transfer(ref PlayerInventory, ManaPotion.Id);
            Console.Clear();

            //Display Menu
            Console.WriteLine("*********************");
            Console.WriteLine("RPG Inventory Manager");
            Console.WriteLine("*********************");
            Console.WriteLine("by: Clark Roda");
            Console.WriteLine("SODV1202 - Final Project");
            bool repeatProgram = false;
            do
            {
                repeatProgram = Menu();
                Console.ReadLine();
            }
            while (repeatProgram);

            ///<summary>
            ///Shows the Main menu with options for the user to select
            ///</summary>
            ///<returns>A bool that controls the do-while loop in Main</returns>
            bool Menu()
            {
                bool repeat = true;
                Console.WriteLine("\n\nMain Menu");
                Console.WriteLine("Select an option:\n");
                Console.WriteLine("1. View My Inventory");
                Console.WriteLine("2. Go on an Adventure"); // discover an item
                Console.WriteLine("3. Battle a Monster!");
                Console.WriteLine("4. Sell an Item");
                Console.WriteLine("5. View Game Inventory");
                Console.WriteLine("6. Exit\n");
                Console.Write("Please enter a number: ");
                if (Int32.TryParse(Console.ReadLine(), out int selection))
                {
                    switch (selection)
                    {
                        case 1:
                            //View Inventory
                            Console.WriteLine("\nMy Inventory: ");
                            Console.WriteLine(PlayerInventory.ShowInv());
                            break;
                        case 2:
                            Adventure();
                            break;
                        case 3:
                            Battle();
                            break;
                        case 4:
                            RemoveItem();
                            break;
                        case 5:
                            Console.WriteLine(GameInventory.ShowInv());
                            break;
                        case 6:
                            //exit
                            repeat = false;
                            break;
                        default:
                            //a number was entered as selection, but not between 1 - 5
                            Console.WriteLine("Not a valid selection, please enter a number from 1 - 6");
                            break;
                    }
                }
                else
                //TryParse faild, therefore no valid integer was entered in menu by user.
                {
                    Console.WriteLine("Not a valid selection, please enter a number from 1 - 5");
                }
                return repeat;
            }

            ///<summary>
            ///Sell an item and remove from player inventory
            ///</summary>
            void RemoveItem()
            {
                Console.WriteLine(PlayerInventory.ShowInv());
                Console.WriteLine("Please input the index of the item you would like to sell: ");

                if (Int32.TryParse(Console.ReadLine(), out int itemIndex))
                {
                    if (itemIndex >= PlayerInventory.ShowCapacity() || itemIndex < 0)
                    {
                        Console.WriteLine("Invalid index selected.");
                    }
                    else
                    {
                        int value = PlayerInventory.inventory[itemIndex].Value;
                        PlayerInventory.RemoveItemAtIndex(itemIndex);
                        Wearable.equipped = false;
                        Console.WriteLine("Item removed! \nYou have gained {0} gold", value);

                    }
                }
                else
                {
                    Console.WriteLine("Invalid index selected.");
                }
            }

            /// <summary>
            /// Adds a random item from the game inventory to the player's 
            /// </summary>
            void Adventure()
            {
                Random r = new Random(DateTime.Now.Millisecond);
                Console.WriteLine("\nGoing on adventure, have fun!\n");
                Console.WriteLine("Found a new item!!");
                //Move an item selected at random from the Game inventory to the Player inventory
                GameInventory.Transfer(ref PlayerInventory, GameInventory.inventory[r.Next(0, GameInventory.inventory.Count)].Id);
            }

            /// <summary>
            /// Allows a user to simulate a battle
            /// </summary>
            void Battle()
            {
                //Battle!!
                Random r = new Random(DateTime.Now.Millisecond);
                Console.WriteLine("Oh no! A monster! Prepare to battle!!!\n");
                Console.WriteLine("*********************************\n");
                int beastHealth = 20;
                Console.WriteLine($"You have encountered a DemiGorgon! He has {beastHealth} health remaining.");
                int beastAttack = 0;
                /*int weaponIndex = 0;
                int armorIndex = 0;*/
                int itemIndex = 0;
                int attack = 0;
                while (beastHealth > 0)
                {
                    string input;

                    do
                    {
                        Console.WriteLine("\n***** EQUIP AN ARMOR FIRST BEFORE YOU EQUIP A WEAPON!!! *****\n");
                        Console.WriteLine("1. Equip or Change my Weapon");
                        Console.WriteLine("2. Equip or Change my Armor");
                        Console.WriteLine("3. Use a Potion");
                        Console.WriteLine("Press any other key to Attack!");
                        input = Console.ReadLine();

                        switch (input)
                        {
                            case "1":
                                //Change weapon method
                                Console.WriteLine("Choose the index from your inventory: ");
                                Dictionary<int, int> weaponList = PlayerInventory.ShowInv("Weapon");

                                bool weaponLoop = true;
                                do
                                {
                                    bool indexChoiceSuccess = Int32.TryParse(Console.ReadLine(), out itemIndex);
                                    if (!indexChoiceSuccess || itemIndex > weaponList.Count || itemIndex < 1)
                                    {
                                        Console.WriteLine("Not valid input! Try again: ");
                                    }
                                    else weaponLoop = false;
                                } while (weaponLoop);

                                Weapon playerweap = (Weapon)PlayerInventory.inventory[weaponList[itemIndex]];
                                playerweap.Equip();

                                break;
                            case "2":
                                //Change armor method
                                Console.WriteLine("Choose the index from your inventory: ");
                                Dictionary<int, int> armorList = PlayerInventory.ShowInv("Armor");

                                bool armorLoop = true;
                                do
                                {
                                    bool indexChoiceSuccess = Int32.TryParse(Console.ReadLine(), out itemIndex);
                                    if (!indexChoiceSuccess || itemIndex > armorList.Count || itemIndex < 1)
                                    {
                                        Console.WriteLine("Not valid input! Try again: ");
                                    }
                                    else armorLoop = false;
                                } while (armorLoop);

                                Armor playerArmor = (Armor)PlayerInventory.inventory[armorList[itemIndex]];
                                playerArmor.Equip();

                                break;
                            case "3":
                                //take potion
                                PlayerInventory.inventory.Find(delegate (Item item)
                                {
                                    if (item.GetType().Equals(Type.GetType("rpgInventory.Potion")))
                                    {
                                        item.Use();
                                        return true;
                                    }
                                    else
                                        return false;
                                });
                                break;
                            default:
                                if (Wearable.equipped)
                                {
                                    if (PlayerInventory.inventory[PlayerInventory.FindIndex(Wearable.equippedId)] is Armor)
                                    {
                                        Console.WriteLine("Please equip a weapon!!!");
                                    }
                                    else
                                    {
                                        Weapon playerWep = (Weapon)PlayerInventory.inventory[PlayerInventory.FindIndex(Wearable.equippedId)];
                                        attack = playerWep.Attack();
                                        beastHealth -= attack;
                                        Console.WriteLine($"The DemiGorgon has {beastHealth} health remaining.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You don't have a weapon equipped!!");
                                }
                                break;
                        }
                    } while (input == "1" || input == "2" || input == "3" || input == "4");

                    beastAttack = r.Next(1, 15);
                    Console.WriteLine($"The DemiGorgon attacked you for {beastAttack} damage!");
                    if (beastAttack > 0)
                    {
                        Console.WriteLine($"You absorbed a total of {beastAttack} damage!");
                    }
                    else
                    {
                        Console.WriteLine("You absorbed no damage!");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("You have defeated the DemiGorgon!");
                Console.WriteLine();
            }
        }
    }
}
