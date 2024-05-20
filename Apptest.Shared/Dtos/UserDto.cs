using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apptest.Shared.Dtos
{
    public class UserDto : BaseDto
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; OnPropertyChanged(); }
        }

        private string account;

        public string Account
        {
            get { return account; }
            set { account = value; OnPropertyChanged(); }
        }

        private string passWord;

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; OnPropertyChanged(); }
        }

        //private string deptId;

        //public string DeptId
        //{
        //    get { return deptId; }
        //    set { deptId = value; OnPropertyChanged(); }
        //}

        //private string gender;

        //public string Gender
        //{
        //    get { return gender; }
        //    set { gender = value; OnPropertyChanged(); }
        //}

        //private DateTime birthdate;

        //public DateTime Birthdate
        //{
        //    get { return birthdate; }
        //    set { birthdate = value; OnPropertyChanged(); }
        //}

        //private string address;

        //public string Address
        //{
        //    get { return address; }
        //    set { address = value; OnPropertyChanged(); }
        //}

        //private string role;

        //public string Role
        //{
        //    get { return role; }
        //    set { role = value; OnPropertyChanged(); }
        //}

        //private string state;

        //public string State
        //{
        //    get { return state; }
        //    set { state = value; OnPropertyChanged(); }
        //}
    }
}
