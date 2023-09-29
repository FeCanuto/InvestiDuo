using InvestiDuo._Repositories;
using InvestiDuo.Models;
using InvestiDuo.Views;

namespace InvestiDuo.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private readonly string sqlConnectionString;
        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;
            this.mainView.ShowAtivoView += ShowAtivosView;
        }

        private void ShowAtivosView(object sender, EventArgs e)
        {
            IAtivoView view = AtivoView.GetInstance((Form)mainView);
            IAtivoRepository repository = new AtivoRepository(sqlConnectionString);
            new AtivoPresenter(view, repository);
        }
    }
}
