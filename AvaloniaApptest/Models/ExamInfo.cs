using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApptest.Models
{
    public partial class ExamInfo : ObservableObject
    {
        public ExamInfo() { 
        }

        public ExamInfo(string examName, string examGrade, string examDescription, string examDetails)
        {
            ExamName = examName;
            ExamGrade = examGrade;
            ExamDescription = examDescription;
            ExamDetails = examDetails;
        }

        [ObservableProperty]
        private string examName;

        [ObservableProperty]
        private string examGrade;

        [ObservableProperty]
        private string examDescription;

        [ObservableProperty]
        private string examDetails;
    }
}
