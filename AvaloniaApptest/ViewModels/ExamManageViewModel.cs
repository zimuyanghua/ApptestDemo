using AvaloniaApptest.Models;
using System.Collections.ObjectModel;

namespace AvaloniaApptest.ViewModels
{
    public partial class ExamManageViewModel : ViewModelBase
    {
        public ObservableCollection<ExamInfo> ExamInfos { get; set; }

        public ExamManageViewModel()
        {
            ExamInfos = new ObservableCollection<ExamInfo>()
    {
        new ("考试1","A","考试1简介","考试1的详细信息"),
        new ("考试2","B","考试2简介","考试2的详细信息"),
        new ("考试3","C","考试3简介","考试3的详细信息")
    };
        }
    }
}
