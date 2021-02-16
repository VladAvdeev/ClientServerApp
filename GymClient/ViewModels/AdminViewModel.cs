using CommonLibrary1.Models;
using GymClient.ClientsREST;
using GymClient.Core;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GymClient.ViewModels
{
    public class AdminViewModel : NotifyPropertyChanged, IPageViewModel
    {
        AdminServer admin;
        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set => SetProperty(ref employees, value);
        }
        //private Employee employee;
        //public Employee Employee
        //{
        //    get => employee;
        //    set
        //    {
        //        SetProperty(ref employee, value);

        //    }
        //}
        private int? id;
        public int? Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }
        private string lastName;
        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }
        private DateTime birthDay;
        public DateTime BirthDay
        {
            get => birthDay;
            set => SetProperty(ref birthDay, value);
        }
        private string phone;
        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }
        private string email;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public int empId;
        public int EmpId
        {
            get => empId;
            set => SetProperty(ref empId, value);
        }
        public ICommand RefreshCommand { get; }
        public AdminViewModel()
        {
            admin = new AdminServer();
            RefreshCommand = new Command(Refresh);
        }
        private void Refresh()
        {
            Employees = new ObservableCollection<Employee>(admin.GetEmployees());
        }
    }
}
