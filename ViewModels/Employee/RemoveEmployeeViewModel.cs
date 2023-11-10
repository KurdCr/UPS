using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using UPS_.Models;
using UPS_.Services;

namespace UPS_.ViewModels
{
    public class RemoveEmployeeViewModel : ViewModelBase
    {
        public ObservableCollection<Employee> Employees { get; private set; }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                if (_selectedEmployee != value)
                {
                    _selectedEmployee = value;
                    RaisePropertyChanged(nameof(SelectedEmployee));
                }
            }
        }


        private async void LoadEmployees()
        {
            var employeesData = await _employeeService.GetEmployeesAsync();
            if (employeesData != null)
            {
                foreach (var employee in employeesData)
                {
                    Employees.Add(employee);
                }
            }
        }

        public RelayCommand RemoveCommand { get; private set; }

        private readonly EmployeeService _employeeService;

        public RemoveEmployeeViewModel()
        {
            _employeeService = new EmployeeService();


            RemoveCommand = new RelayCommand(RemoveEmployee);

            _employeeService = new EmployeeService();
            Employees = new ObservableCollection<Employee>();

            LoadEmployees();
        }

        private void RemoveEmployee()
        {
            if (SelectedEmployee != null)
            {
                _employeeService.DeleteEmployeeAsync(SelectedEmployee.Id);
                Employees.Remove(SelectedEmployee);
            }
        }
    }
}
