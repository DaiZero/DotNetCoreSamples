using System.Collections.Generic;

namespace CoreSample.GraphQL.Models
{
    public class Class
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 班级名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 班级位置
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 年级
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// 班级学生
        /// </summary>
        public List<Student> Students { get; set; }
    }
}