using MenuItemRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class MenuItemRepositoryTests
    {
        [TestMethod]
        public void Add_ItemIsNull_ReturnFalse()
        {
            //Arrange
            //create any variables we need to test this method
            MenuItems menuItems = null;
            MenuItemsRepository repo = new MenuItemsRepository();

            //Act
            //actually calling the method
            bool result = repo.AddItem(menuItems);

            //Assert
            //making sure the method did what it was supposed to
            Assert.IsFalse(result);
        }
    }

    internal class MenuItems
    {
    }
}
