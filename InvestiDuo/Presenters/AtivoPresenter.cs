using InvestiDuo.Models;
using InvestiDuo.Views;

namespace InvestiDuo.Presenters
{
    public class AtivoPresenter
    {
        private IAtivoView view;
        private IAtivoRepository repository;
        private BindingSource assetsBindingSource;
        private IEnumerable<AtivoModel>? assetList;

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

        private void SearchAsset(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                assetList = repository.GetByValue(this.view.SearchValue);
            else assetList = repository.GetAll();
            assetsBindingSource.DataSource = assetList;
        }

        private void SaveAsset(object? sender, EventArgs e)
        {
            var model = new AtivoModel();
            model.Id = view.Id;
            model.Name = view.Name;
            model.Ticket = view.Ticket;
            model.Quantity = view.Quantity;
            model.Value = view.Value;
            model.Total = view.Total;

            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit)//Edit model
                {
                    repository.Edit(model);
                    view.Message = "Ativo editado com sucesso!";
                }
                else //Add new model
                {
                    repository.Add(model);
                    view.Message = "Ativo adicionado com sucesso!";
                }
                view.IsSuccessful = true;
                LoadAllAssetList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void CleanviewFields()
        {
            view.Id = 0;
            view.Name = "";
            view.Ticket = "";
            view.Quantity = 0;
            view.Value = 0.00M;
            view.Date = new DateTime();
        }

        private void LoadAllAssetList()
        {
            assetList = repository.GetAll();
            assetsBindingSource.DataSource = assetList;//Set data source.
        }

        private void DeleteSelectedAsset(object? sender, EventArgs e)
        {
            try
            {
                var asset = (AtivoModel)assetsBindingSource.Current;
                repository.Delete(asset.Id);
                view.IsSuccessful = true;
                view.Message = "Ativo deletado com sucesso!";
                LoadAllAssetList();
            }
            catch (Exception)
            {
                view.IsSuccessful = false;
                view.Message = "Ocorreu um erro, não foi possível excluir o ativo";
            }
        }

        private void AddAsset(object? sender, EventArgs e)
        {
            view.IsEdit = false;
        }
        private void LoadSelectedAssetToEdit(object? sender, EventArgs e)
        {
            var asset = (AtivoModel)assetsBindingSource.Current;
            view.Id = asset.Id;
            view.Name = asset.Name;
            view.Ticket = asset.Ticket;
            view.Quantity = asset.Quantity;
            view.Value = asset.Value;
            view.Total = asset.Total;
            view.Date = asset.Date;
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }
    }
}
