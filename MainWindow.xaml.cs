using System.Windows;
using UPS_.ViewModels;

namespace UPS_
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var editEmployeeViewModel = new EditEmployeeViewModel();
            var removeEmployeeViewModel = new RemoveEmployeeViewModel();
            var viewEmployeeViewModel = new ViewEmployeeViewModel();

            EditEmployeeSection.DataContext = editEmployeeViewModel;
            RemoveEmployeeSection.DataContext = removeEmployeeViewModel;
            ViewEmployeeSection.DataContext = viewEmployeeViewModel;
        }


    }
}
