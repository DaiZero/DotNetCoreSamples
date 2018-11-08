using CoreSample.GraphQL.IRepositories;
using GraphQL.Types;

namespace CoreSample.GraphQL.GrgphTypes
{
    public class ClassQuery : ObjectGraphType
    {
        public ClassQuery(IClassRepostory classRepostory)
        {
            Field<ClassType>(name: "oneclass",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var classid = context.GetArgument<int>("id");
                    return classRepostory.GetById(classid);
                });
            Field<ListGraphType<ClassType>>(name: "classlist",
                 resolve: context =>
                 {
                     return classRepostory.GetAll();
                 }
                );
        }
    }
}