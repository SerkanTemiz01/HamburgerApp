using HamburgerAppMvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace HamburgerAppMvc.DTOs
{
    public class OrderDTO
    {
        public Order Order { get; set; }
        public List<Order> Orders { get; set; }
        public List<Extra> Extras { get; set; }
        public List<Menu> Menus { get; set; }

        public string extraName { get; set; }

        public int MenuID { get; set; }
        public List<SelectListItem> AddingExtras { get; set; }
        public string MenuName { get; set; }
        public OrderDTO()
        {
            //Orders= new List<Order>();
            //Extras= new List<Extra>();
            //Menus= new List<Menu>();
            AddingExtras = new List<SelectListItem>();
            
        }
    }
}
