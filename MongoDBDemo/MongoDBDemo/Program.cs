using MongoDBLibrary;
using MongoDBLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ////添加数据
            //var id = Add();

            ////修改数据
            //Update(id);

            ////获取用户信息
            //var user = Get(id);

            //列表
            //var userList = List();
            //userList.ForEach((item) =>
            //{
            //    Console.WriteLine($"name={item.Name},age={item.Age},sex={item.Sex},id={item._id}");
            //});

            ////分页
            //PageList();

            //删除数据
            // Delete(user);

            Console.ReadKey();
        }

        static string AddAccount()
        {
            var id = Guid.NewGuid().ToString();
            new MongoDBHelper().Add(new AccountInfo
            {
                Name = ".net",
                Age = int.MaxValue,
                Phone = "18110051015"
            });
            return id;
        }


        /// <summary>
        /// 添加数据
        /// </summary>
        /// <returns></returns>
        static string Add()
        {
            var id = Guid.NewGuid().ToString();
            new MongoDBHelper().Add(new User
            {
                _id = id,
                Age = 26,
                Name = "胡汉三",
                Son = new User
                {
                    Age = 1,
                    Name = "张三",
                    BirthDateTime = DateTime.Now
                },
                BirthDateTime = DateTime.Now
            }); ;
            return id;
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="id"></param>
        static void Update(string id)
        {
            new MongoDBHelper().Update<User>(a => a._id == id, a => new User
            {
                Age = a.Age + 2,
                Name = "White",
                Son = new User
                {
                    Age = 15,
                    Name = "small White"
                },
                Sex = Sex.Man,
                AddressList = new List<string>
                {
                    "内蒙古",
                    "赤峰市"
                }
            });
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        static User Get(string id)
        {
            var result = new MongoDBHelper().Get<User>(a => a._id == id);
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        static void Delete(User entity)
        {
            new MongoDBHelper().Delete(entity);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        static PageList<User> PageList()
        {
            return new MongoDBHelper().PageList<User>(a => true);
        }

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        static List<User> List()
        {
            return new MongoDBHelper().List<User>(a => true);
        }

        /// <summary>
        /// 批量插入数据
        /// </summary>
        static void BatchInser()
        {
            var listUser = Enumerable.Range(0, 100).Select(i => new User
            {
                _id = Guid.NewGuid().ToString("N"),
                Age = i,
                Name = "胡汉三" + i,
                Son = new User
                {
                    Age = i,
                    Name = "张三" + i
                },
                BirthDateTime = DateTime.Now
            }).ToList();

            new MongoDBHelper().BatchAdd(listUser);
        }
    }
}
