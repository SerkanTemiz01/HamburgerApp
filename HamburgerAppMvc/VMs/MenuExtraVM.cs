using HamburgerAppMvc.Models;

namespace HamburgerAppMvc.VMs
{
    public class MenuExtraVM
    {
        public Menu Menu { get; set; }
        public Extra Extra { get; set; }
        public List<Menu> Menus { get; set; }
        public List<Extra> Extras { get; set; }

        public MenuExtraVM()
        {
            Menus=new List<Menu>();
            Extras=new List<Extra>();
        }
    }
}
