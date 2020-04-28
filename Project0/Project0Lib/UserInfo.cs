using System;
using System.Collections.Generic;
using System.Text;

namespace Project0Lib
{
    public class UserInfo
    {
		public int UserId { get; set; }
		private string _fName;

		public string fName
		{
			get { return _fName; }
			set { _fName = value; }
		}

		private string _lName;

		public string lName
		{
			get { return _lName; }
			set { _lName = value; }
		}


		private string _userName;

		public string userName
		{
			get { return _userName; }
			set { _userName = value; }
		}


		private string _password;

		public string password
		{
			get { return _password; }
			set { _password = value; }
		}


		public UserInfo(string fname, string lname, string userName, string password) // constructor to store user information when instantiated
		{
			this.fName = fname;
			this.lName = lname;
			this.userName = userName;
			this.password = password;
		}

	}
}
