using CommonLibrary1;
using CommonLibrary1.Models;
using GymClient.ClientsREST;
using GymClient.Core;
using GymClient.Entities;
using GymClient.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GymClient.ViewModels.Admin
{
    public class AdminEmployeeViewModel : NotifyPropertyChanged, IPageViewModel
    {
        AdminServer admin;
        #region Employee
        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set => SetProperty(ref employees, value);
        }
        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                SetProperty(ref selectedEmployee, value);
                Id = SelectedEmployee?.Id;
                FirstName = SelectedEmployee?.FirstName;
                LastName = SelectedEmployee?.LastName;
                Phone = SelectedEmployee?.Phone;
                Email = SelectedEmployee?.Email;
                EmpId = SelectedEmployee?.EmpId;
                PostId = SelectedEmployee.CareerPost.Id;
                ClubId = SelectedEmployee?.ClubId;
                ScheduleId = SelectedEmployee?.ScheduleId;
                if(SelectedEmployee != null)
                {
                    SelectedCareerPost = CareerPosts.Where(x => x.Id == SelectedEmployee.CareerPost.Id).FirstOrDefault();
                }

            }
        }
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
        public int? empId;
        public int? EmpId
        {
            get => empId;
            set => SetProperty(ref empId, value);
        }
        private int? clubId;
        public int? ClubId
        {
            get => clubId;
            set => SetProperty(ref clubId, value);
        }
        private int? scheduleId;
        public int? ScheduleId
        {
            get => scheduleId;
            set => SetProperty(ref scheduleId, value);
        }
        private int? postId;
        public int? PostId
        {
            get => postId;
            set => SetProperty(ref postId, value);
        }

        private CareerPost selectedCareerPost;
        public CareerPost SelectedCareerPost
        {
            get => selectedCareerPost;
            set => SetProperty(ref selectedCareerPost, value);
        }
        private List<CareerPost> careerPosts;
        public List<CareerPost> CareerPosts
        {
            get => careerPosts;
            set => SetProperty(ref careerPosts, value);
        }
        private ObservableCollection<Gym> selectedGyms;
        public ObservableCollection<Gym> SelectedGyms
        {
            get => selectedGyms;
            set => SetProperty(ref selectedGyms, value);
        }
        private Gym gym;
        public Gym Gym
        {
            get => gym;
            set => SetProperty(ref gym, value);
        }
        #endregion

        public ICommand RefreshCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand ChangeCommand { get; }
        public ICommand OpenWinCommand { get; }
        public AdminEmployeeViewModel()
        {
            admin = new AdminServer();
            RefreshCommand = new Command(Refresh);
            DeleteCommand = new Command(Delete, () => SelectedEmployee != null);
            AddCommand = new Command(Add, () => SendCondition());
            ChangeCommand = new Command(Update, () => SendCondition());
            CareerPosts = Handbook.CareerPosts;
        }
        private void Refresh()
        {
            Employees = new ObservableCollection<Employee>(admin.GetEmployees());
        }
        private void Delete()
        {
            ResponseServer response = admin.DeleteEmployee(SelectedEmployee.Id);
            NotificationHelper.Instance.ShowResponse(response);
            SelectedEmployee = null;
            Refresh();
        }
        private void Add()
        {
            Employee employee = new Employee() {Id = Id.Value, FirstName = FirstName, LastName = LastName, Birthday = BirthDay, Phone = Phone, 
                Email = Email, EmpId = EmpId.Value, ClubId = ClubId.Value, CareerPost = SelectedCareerPost, ScheduleId=ScheduleId.Value};
            ResponseServer response = admin.AddEmployee(employee);
            NotificationHelper.Instance.ShowResponse(response);
            Refresh();
        }
        private void Update()
        {
            Employee employee = new Employee() { FirstName = FirstName };
            ResponseServer response = admin.ChangeEmployee(employee);
            NotificationHelper.Instance.ShowResponse(response);
            Refresh();
        }
        private bool SendCondition()
        {
            return SelectedEmployee != null && FirstName != null && LastName != null && BirthDay != null && Phone != null && Email != null;
        }
    }
}
