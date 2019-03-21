using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SocialBusinessApp.ViewModels
{
    public class PickerVM : INotifyPropertyChanged 
    {
        public List<Department> DepartmentsList { get; set; }
        public List<City> CitiesList { get; set; }
        public PickerVM()
        {
            DepartmentsList = GetDepartments().OrderBy(t => t.Value).ToList();
            //CitiesList = GetCities("Nada").OrderBy(t => t.Value).ToList();


        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private Department _selectedDepartment { get; set; }
        public Department SelectedDepartment
        {
            get { return _selectedDepartment; }
            set
            {
                if (_selectedDepartment != value)
                {
                    _selectedDepartment = value;
                    //Funcionalidad
                    MyDepartment = "Selected Department : " + _selectedDepartment.Value;
                    CitiesList = GetCities("Antioquia").OrderBy(t => t.Value).ToList();
                }
            }
        }

        private string _myDepartment;
        public string MyDepartment
        {
            get { return _myDepartment; }
            set
            {
                if (_myDepartment != value)
                {
                    _myDepartment = value;
                    OnPropertyChanged();
                }
            }
        }
        /*private string _myCity;
        public string MyCity
        {
            get { return _myCity; }
            set
            {
                if (_myCity != value)
                {
                    _myCity = value;
                    OnPropertyChanged();
                }
            }
        }*/

        public List<Department> GetDepartments()
        {
            var departments = new List<Department>()
            {
                new Department(){Key = 1, Value = "Antioquia"},
                new Department(){Key = 2, Value = "Cundinamarca"},
                new Department(){Key = 3, Value = "Boyacá"}
            };

            return departments;
        }
        public List<City> GetCities(string param)
        {
            var cities= new List<City>()
            {
                new City(){Key = 1, Value = "Vacio" },
                new City(){Key = 2, Value = "otro Vacio" }
            };
            if (param=="Antioquia")
            {
                cities = new List<City>()
                {
                    new City(){Key = 1, Value = "Medellin"},
                    new City(){Key = 2, Value = "Pereira"},
                    new City(){Key = 3, Value = "Antioquia"}
                };
            }else
            {
                cities = new List<City>()
                {
                    new City(){Key = 1, Value = "Tunja"},
                    new City(){Key = 2, Value = "Tota"},
                    new City(){Key = 3, Value = "Boyacá"}
                };
            }
            
            
            
            return cities;
        }


    }    

    public class Department
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class City
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
