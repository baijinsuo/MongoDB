using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBLibrary.MongoDbConfig
{
    #region Mongo实体标签
    /// <summary>
    /// Mongo实体标签
    /// </summary>
    public class MongoAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database">库名称</param>
        /// <param name="collection">表名称</param>
        public MongoAttribute(string database, string collection)
        {
            Database = database;
            Collection = collection;
        }

        /// <summary>
        /// 交换机名称 (相当于关系型数据库的数据库名称)
        /// </summary>
        public string Database { get; private set; }

        /// <summary>
        /// 队列名称 (相当于关系型数据库的表Table名称)
        /// </summary>
        public string Collection { get; private set; }
    }
    #endregion
}
