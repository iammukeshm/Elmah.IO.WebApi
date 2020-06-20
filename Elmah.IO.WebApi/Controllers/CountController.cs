using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elmah.IO.WebApi.Controllers
{
[Route("api/[controller]")]
public class CountController : Controller
{
    [HttpGet]
    public void ErrorThrower()
    {
        int count;
        try
        {
            for (count = 0; count <= 5; count++)
            {
                if (count == 3)
                {
                    throw new Exception($"Random Exception Occured at iteration {count}");
                }
            }
        }
        catch (Exception ex)
        {
            ex.Ship(HttpContext);
            throw;
        }
    }
}
}
