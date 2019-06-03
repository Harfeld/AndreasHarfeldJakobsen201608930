using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml.Serialization;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using WPFApplikation.Models;
using WPFApplikation.Views;
//Commands

namespace WPFApplikation.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        //AddLocation Modeless Dialog
        private AddLocationWindow AddLocationDlg = null;
        private AddLocationWindowViewModel AddLocationVm = null;
        private string FileName = "";

        //Properties
        private ObservableCollection<Location> locations;

        public MainWindowViewModel()
        {
            locations = new ObservableCollection<Location>
            {
                new Location{LocationId = 1, Name = "Ringgaden", Road = "Ringgaden", RoadNumber = "22", PostalCode = 8210, City = "Århus", Trees = new ObservableCollection<Tree>
                {
                    new Tree(5, "Bøg"),
                    new Tree(2, "Birk")
                }},
                new Location{LocationId = 2, Name = "Randersvej", Road = "Randersvej", RoadNumber = "43", PostalCode = 8000, City = "Århus", Trees = new ObservableCollection<Tree>
                {
                    new Tree(15, "Eg"),
                    new Tree(2, "Ask")
                }}
            };
            SearchedLocations = new ObservableCollection<Location>();
            SearchedLocation = "";
        }

        #region Properties
        
        public ObservableCollection<Location> Locations
        {
            get { return locations; }
            set { SetProperty(ref locations, value); }
        }

        Location currentLocation = null;
        public Location CurrentLocation
        {
            get { return currentLocation; }
            set { SetProperty(ref currentLocation, value); }
        }

        #endregion

        #region Search Properties

        private ObservableCollection<Location> searchedLocations;
        public ObservableCollection<Location> SearchedLocations
        {
            get { return searchedLocations; }
            set { SetProperty(ref searchedLocations, value); }
        }

        private string searchedLocation;
        public string SearchedLocation
        {
            get { return searchedLocation; }
            set
            {
                SetProperty(ref searchedLocation, value);
                SearchedLocations = new ObservableCollection<Location>(Locations.Where(l => l.Name.ToLower().StartsWith(SearchedLocation.ToLower())));
            }
        }

        #endregion

        #region ModelessWindow
        
        ICommand _AddLocationCommand;

        public ICommand AddLocationCommand
        {
            get
           {
                return _AddLocationCommand ?? (_AddLocationCommand = new DelegateCommand(() =>
                {
                    if (AddLocationDlg != null)
                    {
                        AddLocationDlg.Focus();
                    }
                    else
                    {
                        var newLocation = new Location
                        {
                            LocationId = GenerateId(),
                            Trees = new ObservableCollection<Tree>()
                        };

                        AddLocationVm = new AddLocationWindowViewModel(newLocation);
                        AddLocationDlg = new AddLocationWindow
                        {
                            DataContext = AddLocationVm
                        };
                        AddLocationDlg.Owner = Application.Current.MainWindow.Owner;

                        AddLocationVm.Apply += new EventHandler(AddLocationApply);
                        AddLocationVm.Close += new EventHandler(AddLocationCancel);
                        AddLocationDlg.Closed += new EventHandler(AddLocationCancel);
                        AddLocationDlg.Show();
                    }
                }));
            }
        }

        void AddLocationCancel(object sender, EventArgs e)
        {
            AddLocationVm.Apply -= new EventHandler(AddLocationApply);
            AddLocationVm.Close -= new EventHandler(AddLocationCancel);
            AddLocationDlg.Closed -= new EventHandler(AddLocationCancel);
            AddLocationDlg = null;
            Application.Current.MainWindow.Focus();
        }

        void AddLocationApply(object sender, EventArgs e)
        {
            if (AddLocationVm.NewLocation.City == null ||
                AddLocationVm.NewLocation.Name == null ||
                AddLocationVm.NewLocation.PostalCode == 0 ||
                AddLocationVm.NewLocation.Road == null ||
                AddLocationVm.NewLocation.RoadNumber == null)
            {
                AddLocationDlg.Close();
                SearchedLocation = "";
            }
            else
            {
                Locations.Add(AddLocationVm.NewLocation);
                AddLocationDlg.Close();
                SearchedLocation = "";
            }
            
        }

        ICommand _CloseAppCommand;
        public ICommand CloseAppCommand
        {
            get
            {
                return _CloseAppCommand ?? (_CloseAppCommand = new DelegateCommand(() =>
                {
                    AddLocationDlg.Close();
                    Application.Current.MainWindow.Close();
                }));
            }
        }

        #endregion

        #region SaveFunktionalitet
        //Persisteringsfunktionaliteten er baseret på Agent Opgaverne, fra undervisningen


        ICommand _SaveAsCommand;
        public ICommand SaveAsCommand
        {
            get
            {
                return _SaveAsCommand ?? (_SaveAsCommand = new DelegateCommand(
                    () =>
                    {
                        SaveFileDialog saveDlg = new SaveFileDialog();
                        if (saveDlg.ShowDialog() == true)
                        {
                            FileName = saveDlg.FileName;
                            SaveFile();
                        }
                    }));
            }
        }

        ICommand _SaveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return _SaveCommand ?? (_SaveCommand = new DelegateCommand(SaveFile, IsSavePossible)
                  .ObservesProperty(() => Locations.Count));
            }
        }

        private bool IsSavePossible()
        {
            return (FileName != "") && (Locations.Count > 0);
        }

        private void SaveFile()
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Location>));
            TextWriter writer = new StreamWriter(FileName);
            // Serialize all the locations.
            serializer.Serialize(writer, Locations);
            writer.Close();
        }

        ICommand _NewFileCommand;
        public ICommand NewFileCommand
        {
            get
            {
                return _NewFileCommand ?? (_NewFileCommand = new DelegateCommand(() =>
                {
                    MessageBoxResult res = MessageBox.Show("Any unsaved data will be lost. Are you sure you want to initiate a new file?", "Warning",
                    MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                    if (res == MessageBoxResult.Yes)
                    {
                        Locations.Clear();
                        SearchedLocation = "";
                        FileName = "";
                    }
                }));
            }
        }

        ICommand _OpenFileCommand;
        public ICommand OpenFileCommand
        {
            get
            {
                return _OpenFileCommand ?? (_OpenFileCommand = new DelegateCommand(
                    () =>
                    {
                        OpenFileDialog openDlg = new OpenFileDialog();
                        if (openDlg.ShowDialog() == true)
                        {
                            FileName = openDlg.FileName;
                            var tempLocations = new ObservableCollection<Location>();

                            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Location>));
                            try
                            {
                                TextReader reader = new StreamReader(FileName);
                                tempLocations = (ObservableCollection<Location>)serializer.Deserialize(reader);
                                reader.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            Locations = tempLocations;
                            SearchedLocation = "";
                        }
                    }));
            }
        }

        #endregion

        #region HelperFunctions

        private int GenerateId()
        {
            int id = Locations.Count + 1;

            return id;
        }



        #endregion
    }
}
