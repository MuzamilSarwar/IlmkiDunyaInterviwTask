using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CityController : Controller
    {
        public CityController(projectContext context)
        {
            Context = context;
        }
        public projectContext Context { get; }

        [Route("City")]
        public async Task<IActionResult> Index()
        {
            var citylist = await Context.tblCitie.AsNoTracking().ToListAsync();
            return View(citylist);
        }
        [Route("City/add")]
        [HttpGet]
        public IActionResult AddCity()
        {
            return View();
        }
        [Route("City/add")]
        [HttpPost]
        public async Task<IActionResult> AddCity(tblCity obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await Context.tblCitie.AddAsync(obj);
                    await Context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", " kinldy enter correct details");
                }

            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }
    }
}
