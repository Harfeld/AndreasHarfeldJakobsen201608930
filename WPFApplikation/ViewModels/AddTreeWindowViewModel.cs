using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using WPFApplikation.Models;

namespace WPFApplikation.ViewModels
{
    class AddTreeWindowViewModel : BindableBase
    {
        public AddTreeWindowViewModel(Tree _newTree)
        {
            newTree = _newTree;
        }

        Tree newTree = null;
        public Tree NewTree
        {
            get { return newTree; }
            set { SetProperty(ref newTree, value); }
        }
    }
}
