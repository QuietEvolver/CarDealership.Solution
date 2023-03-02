using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarDealership.Models;
using System.Collections.Generic;
using System;

namespace CarDealership.Tests
{
  [TestClass]
  public class CategoryTests : IDisposable
  { 
    // running Tests, increases _instances which increased ID's which is a moving target; We fix by disposing of all Categorys between tests with a teardown method similar to the one we implemented in our Triangle: 

    public void Dispose()   // && define this ClearAll() method: in Models
    {
      Category.ClearAll();
    }
  
    // confirm our constructor can successfully create Category objects
    [TestMethod]
    public void CategoryConstructor_CreatesInstanceOfCategory_Category()
    {
      Category newCategory = new Category("test category");
      Assert.AreEqual(typeof(Category), newCategory.GetType());    
    }
    // test that a Category can successfully retrieve its name
    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "Test Category";
      Category newCategory = new Category(name);

      //Act
      string result = newCategory.Name;
      
      //Assert
      Assert.AreEqual(name, result);    
    }

    // test that we can retrieve Category IDs
    [TestMethod]
    public void GetId_ReturnsCategoryId_Int()
    {
      //Arrange
      string name = "Test Category";
      Category newCategory = new Category(name);

      //Act
      int result = newCategory.Id;
      
      //Assert
      Assert.AreEqual(1, result);    
    }

    // l also need functionality to retrieve all Category objects to display in our app. Let's add that next. We'll start with a test:
    [TestMethod]
    public void GetAll_ReturnsAllCategoryObjects_CategoryList()
    {
    //Arrange
    string name01 = "Work";
    string name02 = "School";
    Category newCategory1 = new Category(name01);
    Category newCategory2 = new Category(name02);
    List<Category> newList = new List<Category> { newCategory1, newCategory2 };

    //Act
    List<Category> result = Category.GetAll();

    //Assert
    CollectionAssert.AreEqual(newList, result);
    }

    // Find() method to locate and display specific Category objects.
    [TestMethod]
    public void Find_ReturnsCorrectCategory_Category()
    {
      //Arrange
      string name01 = "Work";
      string name02 = "School";
      Category newCategory1 = new Category(name01);
      Category newCategory2 = new Category(name02);

      //Act
      Category result = Category.Find(2);

      //Assert
      Assert.AreEqual(newCategory2, result);
    }

    //make sure we can add an Item object into the Items property of a Category object.
    [TestMethod]
    public void AddItem_AssociatesItemWithCategory_ItemList()
    {
      //Arrange
      string description = "Walk dog";
      Item newItem = new Item(description);
      List<Item> newList = new List<Item> { newItem };
      string name = "Work";
      Category newCategory = new Category (name);
      newCategory.AddItem(newItem); 
      //Act
      List<Item> result = newCategory.Items;
      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}