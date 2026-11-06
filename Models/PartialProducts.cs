using Avalonia.Media;
using System;
using System.Linq;
 
namespace MyApp.Models
{
    public partial class Product
    {
        public int TotalQuantity
        {
            get
            {
                int sum = 0;
                foreach (var item in Stockitems)
                {
                    sum += item.Availablequantity;
                }
                return sum;
            }
        }
 
        public string QuantityText
        {
            get
            {
                if (TotalQuantity > 5)
                {
                    return "много";
                }
                else
                {
                    return "мало";
                }
            }
        }
 
        public bool HasDiscount
        {
            get
            {
                DateTime monthStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime prevMonthStart = monthStart.AddMonths(-1);
 
                bool wasOrdered = Orderitems.Any(x => x.IdordersNavigation.Dateorder >= prevMonthStart
                                                   && x.IdordersNavigation.Dateorder < monthStart);
                return !wasOrdered;
            }
        }
 
        public decimal PriceWithDiscount
        {
            get
            {
                if (HasDiscount)
                {
                    return Math.Round(Price * 0.75m, 2);
                }
                else
                {
                    return Price;
                }
            }
        }
 
        public SolidColorBrush ColorBackground
        {
            get
            {
                if (TotalQuantity <= 3)
                {
                    return new SolidColorBrush(Color.FromRgb(255, 204, 204));
                }
                else
                {
                    return new SolidColorBrush(Color.FromRgb(255, 255, 255));
                }
            }
        }
    }
}
 