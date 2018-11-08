using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreSample.GraphQL.Models;

namespace CoreSample.GraphQL.IRepositories
{
   public interface IClassRepostory
    {
        /// <summary>
        /// 获取所有班级信息
        /// </summary>
        /// <returns>返回班级信息集合</returns>
        IEnumerable<Class> GetAll();

        /// <summary>
        ///通过ID获取班级信息
        /// </summary>
        /// <returns>班级信息</returns>
        Class GetById(int classId);
    }
}
