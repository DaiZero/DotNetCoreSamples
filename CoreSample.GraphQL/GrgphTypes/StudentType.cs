using CoreSample.GraphQL.Models;
using GraphQL.Types;

namespace CoreSample.GraphQL.GrgphTypes
{
    public class StudentType : ObjectGraphType<Student>
    {
        public StudentType()
        {
            Field(x => x.ID);
            Field(x => x.FirstName);
            Field(x => x.LastName);
            Field(x => x.Gender);
            Field(x => x.Age);
        }
    }
}