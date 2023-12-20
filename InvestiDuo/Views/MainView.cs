
namespace InvestiDuo.Views
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            ButtonAtivos.Click += delegate { ShowAtivoView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler? ShowAtivoView;
        public event EventHandler? ShowOwnerView;
        public event EventHandler? ShowChartView;
    }
}
