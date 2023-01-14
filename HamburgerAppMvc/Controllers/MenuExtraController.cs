using HamburgerAppMvc.Context;
using HamburgerAppMvc.Models;
using HamburgerAppMvc.Models.Enum;
using HamburgerAppMvc.VMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HamburgerAppMvc.Controllers
{
    public class MenuExtraController : Controller
    {
        MenuExtraVM menuExtra;
        HamburgerDbContext _context;
        public MenuExtraController(HamburgerDbContext context)
        {
            menuExtra=new MenuExtraVM();
           _context=context;
        }
        public async Task<IActionResult> MenuExtra()
        {
            menuExtra.Menus = await _context.Menus.Where(x=>x.Status==Status.Active).ToListAsync();
            menuExtra.Extras = await _context.Extras.Where(x => x.Status == Status.Active).ToListAsync();

            return View(menuExtra);
        }
        public async Task<IActionResult> AddMenu(Menu menu)
        {
            if(ModelState.IsValid)
            {
                _context.Menus.Add(menu);
                _context.SaveChanges();
                return RedirectToAction(nameof(MenuExtra));
            }
            else
            {
                TempData["EksikMenu"] = "Eksik veri var";
                return RedirectToAction(nameof(MenuExtra));
            }
           
        }
        public async Task<IActionResult> AddExtra(Extra extra)
        {
            if (ModelState.IsValid)
            {
                _context.Extras.Add(extra);
                _context.SaveChanges();
                return RedirectToAction(nameof(MenuExtra));
            }
            else
            {
                TempData["EksikExtra"] = "Eksik veri var";
                return RedirectToAction(nameof(MenuExtra));
            }

        }
        [HttpGet]
        public async Task<IActionResult> UpdateMenu(int id)
        {
            var selectedMenu = await _context.Menus.FindAsync(id);
            return View(selectedMenu);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateMenu(Menu menu)
        {
            var selectedMenu = await _context.Menus.FindAsync(menu.MenuID);
            selectedMenu.MenuName = menu.MenuName;
            selectedMenu.Price = menu.Price;
            _context.Menus.Update(selectedMenu);
            _context.SaveChanges();
            return RedirectToAction(nameof(MenuExtra));

        }
        [HttpGet]
        public async Task<IActionResult> UpdateExtra(int id)
        {
          var selectedExtra=await _context.Extras.FindAsync(id);
            return View(selectedExtra);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateExtra(Extra extra)
        {
            var selectedExtra = await _context.Extras.FindAsync(extra.ExtraID);
            selectedExtra.ExtraName=extra.ExtraName;
            selectedExtra.Price=extra.Price;
            _context.Extras.Update(selectedExtra);
            _context.SaveChanges();
            return RedirectToAction(nameof(MenuExtra));

        }

        public async Task<IActionResult> DeleteMenu(int id)
        {
            var selectedMenu = await _context.Menus.FindAsync(id);
            _context.Menus.Remove(selectedMenu);
            _context.SaveChanges();
            return RedirectToAction(nameof(MenuExtra));

        }
        public async Task<IActionResult> DeleteExtra(int id)
        {
            var selectedExtra = await _context.Extras.FindAsync(id);
            _context.Extras.Remove(selectedExtra);
            _context.SaveChanges();
            return RedirectToAction(nameof(MenuExtra));

        }
    }
}
