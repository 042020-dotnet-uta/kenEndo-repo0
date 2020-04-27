using System;
using System.Collections.Generic;
using System.Text;

namespace Project0
{
    class UserInfo //class to store user information
    {
		private string _name; 

		internal string name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _userName;

		internal string userName
		{
			get { return _userName; }
			set { _userName = value; }
		}


		private string _password;

		internal string password
		{
			get { return _password; }
			set { _password = value; }
		}

		private string _phone;

		internal string phone
		{
			get { return _phone; }
			set { _phone = value; }
		}

		internal UserInfo(string name,string userName, string password, string phone) // constructor to store user information when instantiated
		{
			this.name = name;
			this.userName = userName;
			this.password = password;
			this.phone = phone;
		}

	}

}
