using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJSONXML.Models
{
    public partial class Person
    {

        private int _Id;

        private string _Name;

        private bool _Gender;

        /// <remarks/>
        public int Id
        {
            get
            {
                return this._Id;
            }
            set
            {
                this._Id = value;
            }
        }

        /// <remarks/>
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        /// <remarks/>
        public bool Gender
        {
            get
            {
                return this._Gender;
            }
            set
            {
                this._Gender = value;
            }
        }
    }
}
