using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HamburgerAppMvc.Context;
using HamburgerAppMvc.Models;
using HamburgerAppMvc.DTOs;
using HamburgerAppMvc.Models.Enum;
using HamburgerAppMvc.VMs;
using System.Globalization;

namespace HamburgerAppMvc.Controllers
{
    public class OrdersController : Controller
    {
        private readonly HamburgerDbContext _context;
        private readonly OrderDTO _orderDTO;
        public OrdersController(HamburgerDbContext context)
        {
            _context = context;
            _orderDTO=new OrderDTO();
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var ri = new RegionInfo("tr-TR");
            _orderDTO.Orders = await _context.Orders.Where(x => x.Status == Status.Active).Include(x => x.Extras ).ToListAsync();
            foreach (var item in _orderDTO.Menus = await _context.Menus.ToListAsync())
            {
                _orderDTO.AddingExtras.Add(new SelectListItem
                {
                    Value = item.MenuID.ToString(),
                    Text = item.MenuName+"-"+item.Price+" TL"
                });
            }
            _orderDTO.Menus=await _context.Menus.ToListAsync();
            _orderDTO.Extras=await _context.Extras.ToListAsync();

              return _context.Orders != null ? 
                          View(_orderDTO) :
                          Problem("Entity set 'HamburgerDbContext.Orders'  is null.");
        }
        public async Task<IActionResult> GiveOrder(Order order,string MenuName,List<string> extraName,List<Extra> extras,int MenuID)
        {
            
                Menu menu1 = await _context.Menus.FindAsync(MenuID);
                foreach (var item in extraName)
                {
                    if (item != "false")
                    {
                        Extra extra1 = await _context.Extras.FirstOrDefaultAsync(x => x.ExtraName == item);
                        order.Extras.Add(extra1);
                    }

                }
                order.Menu = menu1;
                order.MenuID = MenuID;
               order.CalculateTotalPrice();
            if(order.Menu!=null&&order.Quantity>0&&order.Size>0) 
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
            }               
            else 
            {
                TempData["Hatalı"] = "Eksik bilgiler var";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var list=await _context.Orders.Where(x=>x.Status==Status.Active).ToListAsync();

            foreach(var item in list)
            {
                item.Status = Status.Ordered;
                _context.Orders.Update(item);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .FirstOrDefaultAsync(m => m.ID == id);
            if (order == null)
            {
                return NotFound();
            }
            order.Status = Status.Passive;
            _context.Update(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ResultOfOrders()
        {

            TotalOrdersVM orders = new TotalOrdersVM();
            var orderList = await _context.Orders.Where(x => x.Status == Status.Ordered).Include(x => x.Menu).Include(x=>x.Extras) .ToListAsync(); 
           orders.CountOfOrdered=orderList.Count;
            orders.Endorsement = orderList.Sum(x => x.TotalPrice);
            orders.CountOfMenus = orderList.Sum(x => x.Quantity);
            orders.CountOfExtras=orderList.Sum(x => x.Extras.Count*x.Quantity);
            orders.Orders = orderList;
            return View(orders);
        }

        public async Task<IActionResult> DeleteAllOrders()
        {
            var allOrders = await _context.Orders.Where(x => x.Status == Status.Ordered).ToListAsync();

            foreach (var item in allOrders)
            {
                _context.Remove(item);
                await _context.SaveChangesAsync(true);
            }
            return RedirectToAction(nameof(ResultOfOrders));
        }


        
     
    
      
    }
}
