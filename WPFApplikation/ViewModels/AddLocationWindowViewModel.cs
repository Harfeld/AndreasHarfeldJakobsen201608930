using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using WPFApplikation.Models;
using WPFApplikation.Views;

namespace WPFApplikation.ViewModels
{
    class AddLocationWindowViewModel : BindableBase
    {
        private AddTreeWindowViewModel AddTreeVm = null;

        public AddLocationWindowViewModel(Location _newLocation)
        {
            newLocation = _newLocation;
        }

        Location newLocation = null;
        public Location NewLocation
        {
            get { return newLocation; }
            set { SetProperty(ref newLocation, value); }
        }

        #region Apply og Cancel Commands

        public event EventHandler Apply;
        ICommand _ApplyCommand;

        public ICommand ApplyCommand
        {
            get
            {
                return _ApplyCommand ?? (_ApplyCommand = new DelegateCommand(() =>
                {
                    if (Apply != null)
                    {
                        Apply(this, EventArgs.Empty);
                    }
                }));
            }
        }

        public event EventHandler Close;
        ICommand _CancelCommand;

        public ICommand CancelCommand
        {
            get
            {
                return _CancelCommand ?? (_CancelCommand = new DelegateCommand(() =>
                {
                    if (Close != null)
                    {
                        Close(this, EventArgs.Empty);
                    }
                }));
            }
        }

        #endregion

        
        ICommand _AddTreeCommand;
        public ICommand AddTreeCommand
        {
            get
            {
                return _AddTreeCommand ?? (_AddTreeCommand = new DelegateCommand(
                           () =>
                           {
                               Tree newTree = new Tree();
                               AddTreeVm = new AddTreeWindowViewModel(newTree);
                               AddTreeWindow AddTreelDlg = new AddTreeWindow
                               {
                                   DataContext = AddTreeVm
                               };
                               AddTreelDlg.Owner = Application.Current.MainWindow.Owner;
                               if (AddTreelDlg.ShowDialog() == true)
                               {
                                   NewLocation.Trees.Add(newTree);
                                   AddTreelDlg.Close();
                               }
                           }));
            }
        }
        
    }
}
