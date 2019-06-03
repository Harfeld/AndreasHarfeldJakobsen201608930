using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApplikation.Models
{
    public class Tree
    {
        private int amount;
        private string species;

        public Tree()
        {

        }

        public Tree(int _amount, string _species)
        {
            amount = _amount;
            species = _species;
        }

        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string Species
        {
            get { return species; }
            set { species = value; }
        }
    }
}
