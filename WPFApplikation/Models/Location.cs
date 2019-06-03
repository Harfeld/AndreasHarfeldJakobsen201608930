using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApplikation.Models
{
    public class Location
    {
        private int locationId;
        private string name;
        private string road;
        private string roadNumber;
        private int postalCode;
        private string city;
        private ObservableCollection<Tree> trees;

        public Location()
        {}

        public Location(int _locationId, string _name, string _road, string _roadNumber, int _postalCode, string _city)
        {
            locationId = _locationId;
            name = _name;
            road = _road;
            roadNumber = _roadNumber;
            postalCode = _postalCode;
            city = _city;
            trees = new ObservableCollection<Tree>();
        }

        public int LocationId
        {
            get { return locationId; }
            set { locationId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Road
        {
            get { return road; }
            set { road = value; }
        }

        public string RoadNumber
        {
            get { return roadNumber; }
            set { roadNumber = value; }
        }

        public int PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public ObservableCollection<Tree> Trees
        {
            get { return trees; }
            set { trees = value; }
        }
    }
}
