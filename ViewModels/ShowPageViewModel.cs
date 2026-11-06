using Avalonia.Collections;
using Microsoft.EntityFrameworkCore;
using MyApp.Models;
using ReactiveUI;
using System.Collections.Generic;
using System.Linq;
 
namespace MyApp.ViewModels
{
    internal class ShowPageViewModel : ViewModelBase
    {
       
 
        AvaloniaList<Product> _products = new AvaloniaList<Product>();
 
        public AvaloniaList<Product> Products
        {
            get => _products;
            set => this.RaiseAndSetIfChanged(ref _products, value);
        }
 
        public ShowPageViewModel()
        {
            AllFilters();
        }
 
        #region Фильтрация и сортировка
 
        string _searchText = string.Empty;
 
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                AllFilters(); 
            }
        }
 
 
        List<Category> _allCategories = MainViewModel.myConnection.Categories.ToList().Prepend
                                        (new Category { Name = "Все категории" }).ToList();
 
        public List<Category> AllCategories => _allCategories;
 
        Category? _selectedCategory = null;
 
        public Category SelectedCategory
        {
            get
            {
                if (_selectedCategory == null) 
                    return AllCategories[0];
                else
                    return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
                AllFilters();
            }
        }
 
 
        int _selectedIndexSort = 0;
 
        public int SelectedIndexSort
        {
            get => _selectedIndexSort;
            set
            {
                _selectedIndexSort = value;
                AllFilters();
            }
        }
 
 
        void AllFilters()
        {
            List<Product> products = MainViewModel.myConnection.Products.
                Include(x => x.IdcategoriesNavigation).
                Include(x => x.IdmanufactureNavigation).
                Include(x => x.Stockitems).
                Include(x => x.Orderitems).ThenInclude(x => x.IdordersNavigation).ToList();
 
            if (!string.IsNullOrWhiteSpace(_searchText))
            {
                string search = _searchText.ToLower();
                products = products.Where(x => x.Name.ToLower().Contains(search)
                                || (x.Description != null && x.Description.ToLower().Contains(search))).ToList();
            }
 
            if (_selectedCategory != null && _selectedCategory != AllCategories[0])
            {
                products = products.Where(x => x.Idcategories == _selectedCategory.Idcategories).ToList();
            }
 
            switch (_selectedIndexSort)
            {
                case 1:
                    products = products.OrderBy(x => x.PriceWithDiscount).ToList();
                    break;
                case 2:
                    products = products.OrderByDescending(x => x.PriceWithDiscount).ToList();
                    break;
            }
 
            Products = new AvaloniaList<Product>(products);
        }
        #endregion
    }
}
 