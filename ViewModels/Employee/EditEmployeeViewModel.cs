using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using UPS_.Models;
using UPS_.Services;

namespace UPS_.ViewModels
{
    public class EditEmployeeViewModel : ViewModelBase
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

                    RaisePropertyChanged(nameof(EditEmployeeName));
                    RaisePropertyChanged(nameof(EditEmployeeEmail));
                }
            }
        }

        public string EditEmployeeName
        {
            get => SelectedEmployee?.Name;
            set
            {
                if (SelectedEmployee != null)
                {
                    SelectedEmployee.Name = value;
                    RaisePropertyChanged(nameof(EditEmployeeName));
                }
            }
        }

        public string EditEmployeeEmail
        {
            get => SelectedEmployee?.Email;
            set
            {
                if (SelectedEmployee != null)
                {
                    SelectedEmployee.Email = value;
                    RaisePropertyChanged(nameof(EditEmployeeEmail));
                }
            }
        }

        public RelayCommand UpdateCommand { get; private set; }

        private readonly EmployeeService _employeeService;

        public EditEmployeeViewModel()
        {
            _employeeService = new EmployeeService();
            Employees = new ObservableCollection<Employee>();

            UpdateCommand = new RelayCommand(UpdateEmployee);

            LoadEmployees();
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

        private void UpdateEmployee()
        {
            if (SelectedEmployee != null)
            {
                _employeeService.UpdateEmployeeAsync(SelectedEmployee.Id, SelectedEmployee);
            }
        }
    }
}
