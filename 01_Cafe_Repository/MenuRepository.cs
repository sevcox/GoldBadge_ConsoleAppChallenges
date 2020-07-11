using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repository
{
    public class MenuRepository
    {
        //Cafe has several menus... breakfast, lunch, dinner etc...
        protected readonly List<Menu> _itemDirectory = new List<Menu>();

        //CRUD
        //Create Menu Items (rather it be of type meal or of type appetizer)
        public bool AddItemsToMenu(Menu item)
        {
            int startingCount = _itemDirectory.Count;
            _itemDirectory.Add(item);
            bool wasAdded = (_itemDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Delete Menu Items
        public bool DeleteExistingMenuItem (Menu existingItem)
        {
            bool wasDeleted = _itemDirectory.Remove(existingItem);
            return wasDeleted;
        }

        //Get Menu Items By Name
        public Menu GetMenuItemsByName (string name)
        {
            foreach (Menu item in _itemDirectory)
            {
                if(item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        //Receive a List of Menu Items
        public List<Menu> GetItemsFromMenu()
        {
            return _itemDirectory;
        }
       
    }
}
