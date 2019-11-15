using System.Windows;

namespace CommandImplementation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowModel();
        }
    }
}