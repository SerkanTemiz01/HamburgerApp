using HamburgerAppMvc.Models.Enum;

namespace HamburgerAppMvc.Models
{
    public class Menu
    {
        public int MenuID { get; set; }

        public string MenuName { get; set; }

        public decimal Price { get; set; }

        public Status Status { get; set; } = Status.Active;
        public override string ToString()
        {
            return MenuName;
        }
    }
}
