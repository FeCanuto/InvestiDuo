using InvestiDuo.Models;
using InvestiDuo.Views;

namespace InvestiDuo.Presenters
{
    public class AtivoPresenter
    {
        private IAtivoView view;
        private IAtivoRepository repository;
        private BindingSource assetsBindingSource;
        private IEnumerable<AtivoModel> assetList;
        //Constructor
        public AtivoPresenter(IAtivoView view, IAtivoRepository repository)
        {
            this.assetsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchAsset;
            this.view.AddEvent += AddAsset;
            this.view.EditEvent += LoadSelectedAssetToEdit;
            this.view.DeleteEvent += DeleteSelectedAsset;
            this.view.SaveEvent += SaveAsset;
            this.view.CancelEvent += CancelAction;
            //Set assets bindind source
            this.view.SetAssetListBindingSource(assetsBindingSource);
            //Load assets list view
            LoadAllAssetList();
            //Show view
            this.view.Show();
        }

        private void SaveAsset(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteSelectedAsset(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadSelectedAssetToEdit(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void AddAsset(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        //Methods
        private void LoadAllAssetList()
        {
            assetList = repository.GetAll();
            assetsBindingSource.DataSource = assetList;//Set data source.
        }
        private void SearchAsset(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                assetList = repository.GetByValue(this.view.SearchValue);
            else assetList = repository.GetAll();
            assetsBindingSource.DataSource = assetList;
        }
        private void CancelAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
