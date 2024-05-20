using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apptest.Shared.Dtos
{
    public class DeptDto : BaseDto
    {
        private string deptId;

        public string DeptId
        {
            get { return deptId; }
            set { deptId = value; OnPropertyChanged(); }
        }

        private string deptName;

        public string DeptName
        {
            get { return deptName; }
            set { deptName = value; OnPropertyChanged(); }
        }

        private string deptParentId;

        public string DeptParentId
        {
            get { return deptParentId; }
            set { deptParentId = value; OnPropertyChanged(); }
        }
    }
}
