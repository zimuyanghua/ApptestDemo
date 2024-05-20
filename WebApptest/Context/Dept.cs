namespace WebApptest.Context
{
    public class Dept : BaseEntity
    {
        public string DeptId { get; set; }

        public string DeptName { get; set;}

        public string DeptParentId { get; set; }
    }
}
