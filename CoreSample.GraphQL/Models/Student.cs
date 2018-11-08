namespace CoreSample.GraphQL.Models
{
    public class Student
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 学生名
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 学生姓
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
    }
}