using Avalonia.Collections;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;
 
namespace MyApp.ViewModels
{
    internal class ShowPageViewModel : ViewModelBase
    {
        public AvaloniaList<Product> Products =>
            new AvaloniaList<Product>(MainViewModel.myConnection.Products.
                Include(x => x.IdcategoriesNavigation).
                Include(x => x.IdmanufactureNavigation).
                Include(x => x.Stockitems).
                Include(x => x.Orderitems).ThenInclude(x => x.IdordersNavigation)
                );
    }
}
 