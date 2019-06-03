using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace WPFApplikation.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        //Dialogs
        //ModelessDlg = null

        //Properties


        public MainWindowViewModel()
        {

        }

        #region Properties

        Generic currentGeneric = null;
        public Generic CurrentGeneric
        {
            get { return currentGeneric; }
            set { SetProperty(ref currentGeneric, value); }
        }

        #endregion

        #region Commands

        ICommand _GenericCommand;

        public ICommand GenericCommand
        {
            get
            {
                return _GenericCommand ?? (_GenericCommand = new DelegateCommand(
                           () =>
                           {

                           }));
            }
        }

        #endregion

        #region ModelessWindow
        /*
        ICommand _ModelessCommand;
        public ICommand AddModelCommand
        {
            get
            {
                return _ModelessCommand ?? (_ModelessCommand = new DelegateCommand(async () =>
                {
                    if (ModelessDlg != null)
                    {
                        ModelessDlg.Focus();
                    }
                    else
                    {
                        var genericObject = new Object();
                        //måske ting skal sættes

                        Modelessvm = new ModelessViewModel(genericObject);
                        ModelessDlg = new ModelessWindow
                        {
                            DataContext = Modelessvm
                        };
                        ModelessDlg.Owner = Application.Current.MainWindow.Owner;

                        Modelessvm.Apply += new EventHandler(addModeldlgAccept);
                        Modelessvm.Close += new EventHandler(addModeldlgCancel);
                        ModelessDlg.Closed += new EventHandler(addModeldlgCancel);
                        ModelessDlg.Show();
                    }
                }));
            }

        void ModelessCancel(object sender, EventArgs e)
        {
            Modelessvm.Apply -= new EventHandler(ModelessAccept);
            Modelessvm.Close -= new EventHandler(ModelessCancel);
            ModelessDlg.Closed -= new EventHandler(ModelessCancel);
            ModelessDlg = null;
            Application.Current.MainWindow.Focus();
        }

        async void ModelessAccept(object sender, EventArgs e)
        {
            await database.AddModel(addModelvm.NewModel);
            RaisePropertyChanged("ListofModels");
            addModelDlg.Close();
        }
    }
    */
        #endregion

        #region ModalWindow

        /*
        ICommand _ModalCommand;
        public ICommand ModalCommand
        {
            get
            {
                return _ModalCommand ?? (_ModalCommand = new DelegateCommand(
                           () =>
                           {
                               Modalvm = new ModalViewModel();
                               ModalWindow ModalDlg = new ModalWindow
                               {
                                   DataContext = Modalvm
                               };
                               listDlg.Owner = Application.Current.MainWindow.Owner;
                               listDlg.ShowDialog();
                               //Tilføj if statement hvis der skal ventes på retur
                           }));
            }
        }
        */
        #endregion
    }
}
