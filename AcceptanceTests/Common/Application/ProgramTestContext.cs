using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcceptanceTests.Common.Application
{
    public class ProgramTestContext
    {
        //**********************
        //* Class Data Section *
        //**********************
        //Login Data
        private string _role = string.Empty;
        private string _program = string.Empty;

        //Application Data
        private string _applicationStatus = string.Empty;
        private int _searchRecord = 0;

        //*******************************
        //* Class Data Accessor Section *
        //*******************************

        //Login Data
        public string role
        {
            get { return this._role; }
            set { this._role = value; }
        }

        public string program
        {
            get { return this._program; }
            set { this._program = value; }
        }

        //Application Data
        public string applicationStatus
        {
            get { return this._applicationStatus; }
            set { this._applicationStatus = value; }
        }

        public int searchRecord
        {
            get { return this._searchRecord; }
            set { this._searchRecord = value; }
        }





    } //end public static class TestContext

} //end namespace AcceptanceTests.Common.Application
