using CoreSample.GraphQL.IRepositories;
using CoreSample.GraphQL.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoreSample.GraphQL.Repositories
{
    public class ClassRepostory : IClassRepostory
    {
        public IEnumerable<Class> GetAll()
        {
            var classlist = new List<Class>
            {
                new Class { ID = 101, Name = "1-1班", Grade = 1, Location = "101室",
                    Students =new List<Student>{
                    new Student { ID=10101, Age=6, FirstName="Zero",LastName="Dai", Gender=1 },
                    new Student { ID = 10102, Age = 6, FirstName = "Wei", LastName = "Li", Gender = 1 },
                    new Student { ID = 10103, Age = 6, FirstName = "Yu", LastName = "Qian", Gender = 1 } }  },
                new Class { ID = 102, Name = "1-2班", Grade = 1, Location = "102室" },
                new Class { ID = 103, Name = "1-3班", Grade = 1, Location = "103室" },
                new Class { ID = 201, Name = "2-1班", Grade = 2, Location = "104室" },
                new Class { ID = 202, Name = "2-2班", Grade = 2, Location = "105室" }
            };
            return classlist;
        }

        public Class GetById(int classId)
        {
            return GetAll().FirstOrDefault(x => x.ID == classId);
        }
    }
}