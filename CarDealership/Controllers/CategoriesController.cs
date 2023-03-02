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
  }
}