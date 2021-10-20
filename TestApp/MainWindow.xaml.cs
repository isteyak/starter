using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using AirCloudWPF;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly IModalWindowService modal;

        private readonly Vm vm;

        public MainWindow(IModalWindowService modal)
        {
            this.InitializeComponent();
            this.vm = new Vm();
            this.DataContext = this.vm;
            this.modal = modal;
            this.PreviewKeyDown += (s, e) => System.Console.WriteLine($"HELL ----> {Keyboard.FocusedElement}");
            this.Loaded += (s, e) => FocusManager.SetFocusedElement(this, this.NumericSpinner);
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Console.WriteLine(string.Join(",", this.vm.SelectedItems.ToList()));
            //// MessageBox.Show(string.Join(",", this.vm.SelectedItems.ToList()));
            //// e.Cancel = true;
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var button = sender as Button;
            if(button != null)
            {
                switch (button.Content)
                {
                    case "Error":
                        AirCloudBox.ShowError("Error", "Error Message", MessageBoxButton.OK);
                        break;
                    case "Info":
                        AirCloudBox.Show("Information", "Message");
                        break;
                    case "Success":
                        AirCloudBox.ShowSuccess("Success", "Success Message", MessageBoxButton.OKCancel);
                        break;
                    case "Warning":
                        AirCloudBox.ShowWarning("Warning", "Warning Message", MessageBoxButton.OK);
                        break;
                    case "ProceedLater":
                        AirCloudBox.ShowProceedLater("Agreement", "Updates are available. Want to proceed?", "dlknknven kfek", MessageType.Warning, AirCloudMessageBoxButtons.Proceed);
                        break;
                    case "SaveCancel":
                        AirCloudBox.ShowSaveAndCancel("Agreement", "Updates are available. Want to proceed?", "dlknknven kfek", MessageType.Warning, AirCloudMessageBoxButtons.SaveCancel);
                        break;
                    case "SaveDontSave":
                        AirCloudBox.ShowSaveDialog("Agreement", "Updates are available. Want to proceed?", "dlknknven kfek", MessageType.Warning, AirCloudMessageBoxButtons.Save);
                        break;
                    case "ShowResult":
                        AirCloudBox.ShowResult("Agreement", "Updates are available. Want to proceed?", "Multiline Data", MessageType.Information, MessageBoxButton.OK);
                        break;
                    case "DeleteCancel":
                        AirCloudBox.ShowDeleteCancel("Delete", "Are you sure want to delete?", "Multiline Data", MessageType.Warning, AirCloudMessageBoxButtons.Delete);
                        break;
                    default:
                        var param = new NavigationParameters();
                        param.Add("Show", true);
                        this.modal.Show(nameof(Controls), "CustomControls", param);
                        break;
                }
            }
        }

        private void Clear_Unchecked(object sender, RoutedEventArgs e)
        {
            this.vm.SelectedItems.Clear();
        }

        private void ClearSource_Checked(object sender, RoutedEventArgs e)
        {
            if (this.vm.Items.Any())
            {
                this.vm.Items.Clear();
            }
            else
            {
                this.vm.Items.Add("Chennai");
                this.vm.Items.Add("Trichy");
                this.vm.Items.Add("Bangalore");
                this.vm.Items.Add("Coimbatore");
                this.vm.SelectedItems.Add("Chennai");
                this.vm.SelectedItems.Add("Trichy");
            }
        }
    }
    public class Vm : BindableBase
    {
        private ObservableCollection<string> _items;
        private ObservableCollection<string> _selectedItems;

        public Vm()
        {
            this.ProjectName = "Untitled Project";
            this.HomeChecked = true;
            this.ErrMsg = "";
            this.CloseMenuCommand = new DelegateCommand(() => this.OpenMenu = false);
            this.HomeCommand = new DelegateCommand(() => this.HomeChecked = false);
            this.TestCommand = new DelegateCommand(() => MessageBox.Show("Test"));
            this.CheckBoxCommand = new DelegateCommand(this.Text);
            this.ValueChangeListnerCommand = new DelegateCommand(() => System.Console.WriteLine("Values"));

            this.Idus = new ObservableCollection<TestIdu> {
                new TestIdu("I1", "Id1", "R1", "F1", "40", "40", "40", "40", "30", "30", "30", "30"),
                new TestIdu("I2", "Id2", "R2", "F2", "40", "40", "40", "40", "30", "30", "30", "30"),
                new TestIdu("I3", "Id3", "R3", "F3", "40", "40", "40", "40", "30", "30", "30", "30"),
                new TestIdu("I4", "Id4", "R4", "F4", "40", "40", "40", "40", "30", "30", "30", "30"),
                new TestIdu("I5", "Id5", "R5", "F5", "40", "40", "40", "40", "30", "30", "30", "30"),
                new TestIdu("I6", "Id6", "R6", "F6", "40", "40", "40", "40", "30", "30", "30", "30"),
                new TestIdu("I7", "Id7", "R7", "F7", "40", "40", "40", "40", "30", "30", "30", "30")
            };

            this.Access = new ObservableCollection<string> {
                "T1", "T2", "T3"
            };
            this.TextChangedCommand = new DelegateCommand<string>(s => System.Console.WriteLine($"Test {s}"));
            Items = new ObservableCollection<string>();
            Items.Add("Chennai");
            Items.Add("Trichy");
            Items.Add("Bangalore");
            Items.Add("Coimbatore");

            SelectedItems = new ObservableCollection<string>();
            SelectedItems.Add("Chennai");
            SelectedItems.Add("Trichy");

        }

        public void Text()
        {

        }

        public void Text(object s)
        {
            System.Console.WriteLine(s);
        }

        public ICommand CloseMenuCommand { get; set; }
        public ICommand HomeCommand { get; set; }

        public ICommand TextChangedCommand { get; set; }

        public ICommand TestCommand { get; set; }

        public ICommand CheckBoxCommand { get; set; }

        public ICommand ValueChangeListnerCommand { get; set; }

        public ObservableCollection<TestIdu> Idus {get;set;}

        public ObservableCollection<string> Access { get; set; }


        private string errMsg;
        public string ErrMsg
        {
            get => this.errMsg;
            set
            {
                this.errMsg = value;
                this.RaisePropertyChanged(nameof(this.ErrMsg));
            }
        }

        private bool openMenu;
        public bool OpenMenu
        {
            get
            {
                return this.openMenu;
            }

            set
            {
                this.SetProperty(ref this.openMenu, value);
            }
        }

        private bool openFlyer;
        public bool OpenFlyer
        {
            get
            {
                return this.openFlyer;
            }

            set
            {
                this.SetProperty(ref this.openFlyer, value);
            }
        }

        private bool homeChecked;
        public bool HomeChecked
        {
            get
            {
                return this.homeChecked;
            }

            set
            {
                this.SetProperty(ref this.homeChecked, value);
            }
        }

        private bool settingsChecked;
        public bool SettingsChecked
        {
            get
            {
                return this.settingsChecked;
            }

            set
            {
                this.SetProperty(ref this.settingsChecked, value);
            }
        }

        private bool openUserMenu;
        public bool OpenUserMenu
        {
            get
            {
                return this.openUserMenu;
            }

            set
            {
                this.SetProperty(ref this.openUserMenu, value);
            }
        }

        public string ProjectName { get; set; }

        public ObservableCollection<string> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                this.RaisePropertyChanged("Items");
            }
        }

        public ObservableCollection<string> SelectedItems
        {
            get
            {
                return _selectedItems;
            }
            set
            {
                _selectedItems = value;
                RaisePropertyChanged("SelectedItems");
            }
        }
    }

    public class TestIdu : BindableBase
    {
        public TestIdu(string name, string indoorName, string roomName, string floorName,
            string cooling, string heating, string sensible, string airFlow, string dbc, string wbc,
            string rhc, string dbh)
        {
            this.DisplayName = name;
            this.IndoorName = indoorName;
            this.RoomName = roomName;
            this.FloorName = floorName;
            this.Cooling = cooling;
            this.Heating = heating;
            this.SensibleHeating = sensible;
            this.Airflow = airFlow;
            this.DbCooling = dbc;
            this.WbCooling = wbc;
            this.RhCooling = rhc;
            this.DbHeating = dbh;
        }

        public string DisplayName { get; set; }
        private string indoorName;
        public string IndoorName {
            get => this.indoorName;
            set
            {
                this.indoorName = value;
                this.RaisePropertyChanged(nameof(IndoorName));
            }
        }
        public string RoomName { get; set; }
        public string FloorName { get; set; }
        public string Cooling { get; set; }
        public string Heating { get; set; }
        public string SensibleHeating { get; set; }
        public string Airflow { get; set; }
        public string DbCooling { get; set; }
        public string WbCooling { get; set; }
        public string RhCooling { get; set; }
        public string DbHeating { get; set; }
    }
}
