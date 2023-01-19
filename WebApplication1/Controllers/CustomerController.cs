using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController(projectContext context)
        {
            Context = context;
        }

        public projectContext Context { get; }

        [Route("Customer")]
        public async Task<IActionResult> Index()
        {
            var cutomers = await Context.tblCustomers.AsNoTracking().ToListAsync();
            return View(cutomers);
        }
        [Route("Customer/add")]
        [HttpGet]
        public IActionResult AddCustomer()
        {
            var cities = Context.tblCitie.ToList();
            ViewBag.Cities = new SelectList(cities, "City_id", "City_name");
            return View();
        }
        [Route("Customer/add")]
        [HttpPost]
        public async Task<IActionResult> AddCustomer(tblCustomers obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await Context.tblCustomers.AddAsync(obj);
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

        [Route("Customer/Update")]
        [HttpGet]
        public async Task<IActionResult> UpdateCustomer(int id)
        { 
            var result = await Context.tblCustomers.AsNoTracking().FirstOrDefaultAsync(x => x.Customer_id == id);
            var cities = Context.tblCitie.ToList();
            ViewBag.Cities = new SelectList(cities, "City_id", "City_name",result.City_id);
            return View(result);
        }
        [Route("Customer/Update")]
        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(tblCustomers obj)
        {
            try
            {
                Context.tblCustomers.Update(obj);
                await Context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                throw;
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await Context.tblCustomers.AsNoTracking().FirstOrDefaultAsync(x => x.Customer_id == id);

            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(tblCustomers obj, int id)
        {
            var result = await Context.tblCustomers.FirstOrDefaultAsync(x => x.Customer_id == id);

            Context.tblCustomers.Remove(result);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
