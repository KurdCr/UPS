using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using UPS_.Models;
using UPS_.Services;

namespace UPS_.ViewModels
{
    public class ViewEmployeeViewModel : ViewModelBase
    {
        public ObservableCollection<Employee> Employees { get; private set; }
        public ICommand LoadEmployeesCommand { get; private set; }

        private readonly EmployeeService _employeeService;

        public ViewEmployeeViewModel()
        {
            _employeeService = new EmployeeService();
            Employees = new ObservableCollection<Employee>();
            LoadEmployeesCommand = new RelayCommand(async () => await LoadEmployees());
            LoadEmployeesCommand.Execute(null);
        }

        private async Task LoadEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            if (employees != null)
            {
                Employees.Clear();
                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }
            }
        }
    }
}
