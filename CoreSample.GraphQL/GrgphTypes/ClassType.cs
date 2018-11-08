using CoreSample.GraphQL.Models;
using GraphQL.Types;

namespace CoreSample.GraphQL.GrgphTypes
{
    public class ClassType : ObjectGraphType<Class>
    {
        public ClassType()
        {
            Field(x => x.ID);
            Field(x => x.Name);
            Field(x => x.Grade);
            Field(x => x.Location);
            Field<ListGraphType<StudentType>>("Students");
        }
    }
}