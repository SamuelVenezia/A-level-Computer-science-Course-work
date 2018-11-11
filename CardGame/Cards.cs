using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CardGame
{
    class Cards
    {//Attributes of the Cards
        protected string _Name;
        protected string _House;
        protected int _Number;
        protected int _Score;
        protected int _SizeY;
        protected int _SizeX;
        protected Point _Location;
        protected Image _Image;
        //Get and Sets
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string House
        {
            get { return _House; }
            set { _House = value; }
        }
        public int Number
        {
            get { return _Number; }
            set { _Number = value;}
        }
        public int Score
        {
            get { return _Score; }
            set { _Score = value; }
        }
        public int SizeY
        {
            get { return _SizeY; }
        }
        public int SizeX
        {
            get { return _SizeX; }
        }
        public Point Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; }
        }
        //Constructors
        public Cards()
        {
            _SizeY = 60;
            _SizeX = 85;
            _Name = Name;
            _House = House;
            _Number = Number;
            _Score = Score;
            _Location = new Point(120,130);
        }
    }
    class RuleCards
    {
        //Attributes of the Rules
        protected int _SizeY;
        protected int _SizeX;
        protected Point _Location;
        protected Image _Image;
        //Get and sets
        public int SizeY
        {
            get { return _SizeY; }
        }
        public int SizeX
        {
            get { return _SizeX; }
        }
        public Point Location
        {
            get { return _Location; }
            set { _Location = value; }
        }
        public Image Image
        {
            get { return _Image; }
            set { _Image = value; }
        }
        //Constructors
        public RuleCards()
        {
            _SizeY = 200;
            _SizeX = 200;
        }
    }
}
