using MyApp.Models;
using ReactiveUI;
 
namespace MyApp.ViewModels;
 
public class MainViewModel : ViewModelBase
{

    public static _43pPotapov2026Context myConnection = new _43pPotapov2026Context();
 
    public static MainViewModel Instance = null!;
 
    public MainViewModel()
    {
        Instance = this;
    }
 
    ViewModelBase _uc = new ShowPageViewModel();
 
    public ViewModelBase Uc
    {
        get => _uc;
        set => this.RaiseAndSetIfChanged(ref _uc, value);
    }
}
 