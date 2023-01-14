using HamburgerAppMvc.Models;

namespace HamburgerAppMvc.VMs
{
    public class TotalOrdersVM
    {
        public decimal Endorsement { get; set; }

        public int CountOfOrdered { get; set; }

        public int CountOfExtras { get; set; }

        public int CountOfMenus { get; set; }

        public List<Order> Orders { get; set; }

        public TotalOrdersVM()
        {
            Orders= new List<Order>();
        }
    }
}
