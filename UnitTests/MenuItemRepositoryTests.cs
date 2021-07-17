using MenuItem.POCOs;
using MenuItemRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class MenuItemRepositoryTests
    {
        [TestMethod]
        public void Add_ItemIsNull_ReturnFalse()
        {
            //Arrange
            MenuItems menuItems = null;
            MenuItemsRepository repo = new MenuItemsRepository();

            //Act
            bool result = repo.AddItem(menuItems);

            //Assert
            Assert.IsFalse(result);
            
        }

        [TestMethod]
        public void Add_ItemIsNotNull_ReturnTrue()
        {
            //Arrange
            MenuItems menuItems = new MenuItems("Chicken Sandwich", "A Crispy Chicken Sandwich with a juicy and tender center.", "Chicken, Buns, Lettuce, Cheese, Tomatoes", "5.99");
            MenuItemsRepository repo = new MenuItemsRepository();

            //Act
            bool result = repo.AddItem(menuItems);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Delete_ItemDoesNotExist_ReturnsFalse()
        {
            int mealNumber = 3;
            MenuItemsRepository repo = new MenuItemsRepository();
            bool result = repo.DeleteItem(mealNumber);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Delete_ItemDoesExist_ReturnsTrue()
        {
            int mealNumber = 3;
            MenuItemsRepository repo = new MenuItemsRepository();
            bool result = repo.DeleteItem(mealNumber);
            Assert.IsTrue(result);

        }
    }

    
}
