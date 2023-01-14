using HamburgerAppMvc.Models.Enum;

namespace HamburgerAppMvc.Models
{
    public class Order
    {
        public int ID { get; set; }
        public virtual Menu Menu { get; set; }
        public int? MenuID { get; set; }
        public virtual List<Extra> Extras { get; set; }
       
        public decimal TotalPrice { get; set; }

        public Status Status { get; set; } = Status.Active;

        public Size Size { get; set; }
        public int Quantity { get; set; }

        public Order()
        {
            Extras= new List<Extra>();
            Menu= new Menu();
        }

        public async void CalculateTotalPrice()
        {
            TotalPrice=Menu.Price*Quantity;   
            switch (Size)
            {
                case Size.Small:
                    TotalPrice *= 0.7M;
                    break;
                        case Size.Medium:
                    TotalPrice *= 1M;
                    break;
                case Size.Large:
                    TotalPrice *= 1.6M;
                    break;

            }
            TotalPrice += Extras.Sum(x => x.Price);
          

        }
    }
}
