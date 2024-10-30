using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ministery_of_Education.Models;

namespace AspnetCoreMvcFull.Controllers;

public class DashboardsController : Controller
{
  public IActionResult Index() => View();
}
