using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestEntity
{
    public class DbQuerys
    {
        public DataUsers GetUser(string Login, string Password)
        {
            var context = new LessonContext();


            var query = from c in context.DataUsers
                        where c.Login == Login && c.Password == Password
                        select c;

            List<DataUsers> dataUsers = query.ToList();
            DataUsers ThisUser = new DataUsers();
            foreach(var user in dataUsers)
            {
                ThisUser.Id = user.Id;
                ThisUser.Login = user.Login;
                ThisUser.Password = user.Password;
                ThisUser.IdRole = user.IdRole;
            }
            return ThisUser;
        }


        public void RegistrationUser(string Login, string Password)
        {
            var context = new LessonContext();

            DataUsers NewUsers = new DataUsers
            {
                Login = Login,
                Password = Password,
                IdRole = 2
            };

            context.DataUsers.Add(NewUsers);
            context.SaveChanges();
        }


        public string GetRole(DataUsers dataUsers)
        {
            var context = new LessonContext();

            var query = from c in context.DataUsers
                        where c.Id == dataUsers.Id && c.IdRole == c.DataRoles.Id
                        select c.DataRoles.Name;

            List<string> RoleList = query.ToList();
            string Role = RoleList[0];
            return Role;
        }


        public List<DataUsers> GetDataUsers()
        {
            var context = new LessonContext();

            var query = from c in context.DataUsers
                        select c;

            List<DataUsers> dataUsers = query.ToList();
            return dataUsers;
        }
        

        public BansUsers CheckBan(DataUsers ThisUser)
        {
            var context = new LessonContext();

            var queryForCheckBan = from c in context.BansUsers
                                   where c.UserId == ThisUser.Id
                                   select c;
            List<BansUsers> Bans = queryForCheckBan.ToList();
            BansUsers ThisBan = new BansUsers();

            foreach(var ban in Bans)
            {
                ThisBan.Id = ban.Id;
                ThisBan.Comment = ban.Comment;
                ThisBan.UserId = ban.UserId;
            }
            return ThisBan;
        }
    }
}
