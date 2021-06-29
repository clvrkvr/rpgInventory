using System;
using System.Collections.Generic;

/// <summary>
/// Title: RPG Inventory
/// Author: Clark Roda
/// </summary>
namespace rpgInventory
{
    // <summary>
    /// The inventory class stores lists of items, and methods to track which list items are in. 
    /// </summary>
    public class Inventory
    {

        public List<Item> inventory = new List<Item>();
        static public List<int> itemId = new List<int>();
        static public Dictionary<int, Inventory> masterList = new Dictionary<int, Inventory>();

        /// <summary>
        /// Deletes an Item From all existing list and dictionary
        /// </summary>
        /// <param name="id"> the id of the item</param>
        public static void DeleteMe(int id)
        {
            //removes the item from the inventory assigned to id
            Inventory.masterList[id].RemoveItem(id);
            //removes the item from the dictionary
            Inventory.masterList.Remove(id);
            //removes the item from the item ID list
            Inventory.itemId.Remove(id);
        }

        /// <summary>
        /// Transfer an item to another inventory
        /// </summary>
        /// <param name="otherInventory">a reference to the inventory recieveing the item</param>
        /// <param name="id">the id of the item getting transfered</param>
        public void Transfer(ref Inventory otherInventory, int id)
        {
            //finds item in our list
            int index = FindIndex(id);
            if (index > -1)
            {
                //transfer by adding then removing
                Console.WriteLine(this.inventory[index].Name);
                otherInventory.AddItem(this.inventory[index]);
                this.RemoveItem(id);
            }
            else
                Console.WriteLine("The item with Id: {0} does not exist within this inventory, could not transfer!", id);
        }

        /// <summary>
        /// Returns a string with all names & Ids of the items contained within the inventory.
        /// </summary>
        public string ShowInv()
        {
            string AllItems = "This Inventory contains the following items : \n";
            int itemIndex = 0;
            this.inventory.ForEach(delegate (Item item)
            {
                AllItems += itemIndex + ". " + item.Name + " Id: " + item.Id + "\n";
                itemIndex++;
            });
            return AllItems;
        }

        /// <summary>
        /// Create a dictionary to display a list of items of a specific class. 
        /// </summary>
        /// <param name="type">Name of the class to filter for</param>
        /// <returns></returns>
        public Dictionary<int, int> ShowInv(string type)
        {

            //iterate
            //find all of type
            //add to list base on order found
            //asign index of order found to index of real position in inventory
            //return dictionary.
            Dictionary<int, int> tempList = new Dictionary<int, int>();
            int index = 1;
            this.inventory.ForEach(delegate (Item item)
            {
                if (item.GetType().IsSubclassOf(Type.GetType("rpgInventory." + type)) || item.GetType().Equals(Type.GetType("rpgInventory." + type)))
                {
                    Console.WriteLine(index + ". " + item.Name);
                    tempList[index] = this.FindIndex(item.Id);
                    index++;
                }
            });
            return tempList;
        }

        /// <summary>
        /// This method adds the item passed to it to the list.
        /// </summary>
        /// <param name="item"> The item to be added to the list </param>
        public void AddItem(Item item)
        {
            this.inventory.Add(item);
            Inventory.masterList[item.Id] = this;
        }

        /// <summary>
        /// removes an item by the Id supplied.
        /// </summary>
        /// <param name="id">the id of the item being removed</param>
        public void RemoveItem(int id)
        {
            //check if the inventory contains the item
            int index = FindIndex(id);
            try
            {
                inventory.RemoveAt(index);
            }
            catch
            {
                Console.WriteLine("Sorry, That item doesn't exist.");
            }
        }

        /// <summary>
        /// removes an item index supplied
        /// </summary>
        /// <param name="itemIndex">the index</param>
        public void RemoveItemAtIndex(int itemIndex)
        {
            inventory.RemoveAt(itemIndex);
            //also remove Id from idList
        }

        /// <summary>
        /// finds the index of an item from the given ID
        /// </summary>
        /// <param name="id">id of the item being searched for</param>
        /// <returns></returns>
        public int FindIndex(int id)
        {
            int index;
            for (int i = 0; i < this.inventory.Count; i++)
            {
                //if found, remove it from the first occurence and end.
                if (id == this.inventory[i].Id)
                {
                    index = i;
                    return index;
                }
            }
            //if nothing is found, returns -1
            return -1;
        }

        /// <summary>
        /// Displays the number of items stored in the inventory.
        /// </summary>
        /// <returns></returns>
        public int ShowCapacity()
        {
            return this.inventory.Count;
        }

        /// <summary>
        /// Sorts the inventory based on the given catagory
        /// "name" - sorts by item name A-Z
        /// "value" - sorts by item value 0-X
        /// </summary>
        /// <param name="catagory">sorts the list by name/value</param>
        public void SortItems(string catagory)
        {
            switch (catagory)
            {
                case "name":
                    List<Item> newList = new List<Item>();
                    int numbOfAttempts = this.inventory.Count;

                    for (int i = 0; i < numbOfAttempts; i++)
                    {
                        int NumOfElementsInArray = this.inventory.Count;
                        Item currentItem = inventory[0];
                        for (int x = 1; x < NumOfElementsInArray; x++)
                        {
                            //current value is larger... set current item to the other item
                            if (string.Compare(currentItem.Name, inventory[x].Name) == 1)
                            {
                                currentItem = inventory[x];
                            }
                        }
                        //addd item to new list
                        newList.Add(currentItem);
                        inventory.Remove(currentItem);
                    }
                    //adds the last item int the list
                    //set new list to inventory
                    //newList.Add(inventory[0]);
                    inventory = newList;
                    break;
                case "value":
                    List<Item> newListforValue = new List<Item>();
                    int numbOfAttemptsforValue = this.inventory.Count;

                    for (int i = 0; i < numbOfAttemptsforValue; i++)
                    {
                        int NumOfElementsInArray = this.inventory.Count;
                        Item currentItem = inventory[0];
                        for (int x = 1; x < NumOfElementsInArray; x++)
                        {
                            //current value is larger... set current item to the other item
                            if (currentItem.Value > inventory[x].Value)
                            {
                                currentItem = inventory[x];
                            }
                        }
                        //addd item to new list
                        newListforValue.Add(currentItem);
                        inventory.Remove(currentItem);
                    }
                    //adds the last item int the list
                    //set new list to inventory
                    inventory = newListforValue;
                    break;
            }
        }
    }
}
