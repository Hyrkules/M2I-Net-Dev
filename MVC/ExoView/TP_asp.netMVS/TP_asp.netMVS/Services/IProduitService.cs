using TP_asp.netMVS.ViewModel.Produits;
using TP_asp.netMVS.ViewModels.Produits;

namespace TP_asp.netMVS.Services
{
    public interface IProduitService
    {
        List<ProduitListItemViewModel> GetAll();

        ProduitDetailsViewModel? GetById(int id);

        ProduitFormViewModel GetFormViewModel(int? id);

        bool Create(ProduitFormViewModel viewModel);

        bool Update(int id, ProduitFormViewModel viewModel);

        bool Delete(int id);
    }
}
