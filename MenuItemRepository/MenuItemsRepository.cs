using MenuItem.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItemRepository
{
    public class MenuItemsRepository
    {
        private readonly List<MenuItems> _menuItemsDatabase = new List<MenuItems>();
        private int _Count = 0;
        
        public bool AddItem(MenuItems menuItems)
        {
            if (menuItems is null)
            {
                return false;
            }

            _Count++;
            menuItems.MealNumber = _Count;
            _menuItemsDatabase.Add(menuItems);
            return true;                
            
        }


        public IEnumerable<MenuItems> GetMenuItems()
        {
            return _menuItemsDatabase;
        }


        public bool DeleteItem(int mealNumber)
        {
            foreach (MenuItems menuItems in _menuItemsDatabase)
            {
                if (mealNumber == menuItems.MealNumber)
                {
                    _menuItemsDatabase.Remove(menuItems);
                    return true;
                }
            }
            return false;
        }

        //public List<MenuItems> GetAll()
        //{
          //  return _menuItemsData;
        //}
    }
}
