using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TestApp
{
    public class TestViewModel : BindableBase
    {

        public TestViewModel()
        {
            this.Idus = new ObservableCollection<Idu>
            {
                new Idu("1", "UnitName 1", "M1"),
                new Idu("2", "UnitName 2", "M2"),
                new Idu("3", "UnitName 3", "M3"),
                new Idu("4", "UnitName 4", "M4"),
                new Idu("5", "UnitName 5", "M5")
            };

            this.Events = new ObservableCollection<Event>() {
            new Event("airCloud Select Version 6.3", DateTime.Now, new System.Collections.Generic.List<string>(){
            "This Added", "That Removed", "This Happened"
            }),
            new Event("airCloud Select Version 6.1", DateTime.Now.AddDays(-30), new System.Collections.Generic.List<string>(){
            "30 new Features added", "That was fixed", "Something happened"
            }),
            new Event("airCloud Select Version 6.2", DateTime.Now.AddDays(-15), new System.Collections.Generic.List<string>(){
            "This added", "That Removed", "This Happened"
            })
            };
        }

        public ObservableCollection<Idu> Idus
        {
            get; set;
        }
        public ObservableCollection<Event> Events { get; }

    }

    public class Event : BindableBase
    {

        public Event(string title, DateTime date, List<string> details)
        {
            this.Header = title;
            this.Date = date;
            this.Details = details;
        }

        public string Header { get; }
        public DateTime Date { get; }
        public List<string> Details { get; }
    }


    public class Idu : BindableBase
    {
        public string id;
        private string unitName;
        private string model;

        public Idu(string id, string name, string model)
        {
            this.Id = id;
            this.UnitName = name;
            this.Model = model;
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
                this.RaisePropertyChanged(nameof(this.Id));
            }
        }

        public string UnitName
        {
            get
            {
                return this.unitName;
            }

            set
            {
                this.unitName = value;
                this.RaisePropertyChanged(nameof(this.UnitName));
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
                this.RaisePropertyChanged(nameof(this.Model));
            }
        }

    }
}
