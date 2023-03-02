using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using CarDealership.Models;


namespace CarDealership.Controllers
{
  public class CategoriesController : Controller
  {
    // create an Index() route to display all Categorys
    [HttpGet("/categories")]
    public ActionResult Index()
    {
      List<Category> allCategories = Category.GetAll();
      return View(allCategories);
    }

    // ensure users can create new Categorys with a form
    [HttpGet("/categories/new")]
    public ActionResult New()
    {
      return View();
    }

    // create&process submissions from this form
// This one creates new Items within a given Category, not new Categories:
    [HttpPost("/categories/{categoryId}/items")]
    public ActionResult Create( int categoryId, string itemDescription)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category foundCategory = Category.Find(categoryId);
      Item newItem = new Item(itemDescription);
      foundCategory.AddItem(newItem);
      List<Item> categoryItems = foundCategory.Items;
      model.Add("Items", categoryItems);
      model.Add("category", foundCategory);
      return View("Show", model);
    }
// so a user can click an individual Category from the list of all categories and navigate to a detail page displaying its information, including a list of the Items associated with it. 
    [HttpGet("/categories/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(id);
      List<Item> categoryItems = selectedCategory.Items;
      model.Add("category", selectedCategory);
      model.Add("items", categoryItems);
      return View(model);
    }

    // to add functionality to clear the items from a Category, we'll need to create a new Category method that handles clearing out the Category.Items property
    [HttpPost("category{id}/items/delete")]
    public ActionResult DeleteAll()
    {
      Item.ClearAll();
      return View();
    }
  }
}