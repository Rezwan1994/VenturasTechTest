using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelDataAccess;
using ModelEntity;
namespace VenturasTechTest.Controllers
{
    public class HomeController : Controller
    {
        UserRepository userRepo = null;
        public HomeController()
        {
            UserDBContext Context = UserDBContext.getInstance();

            userRepo = new UserRepository(Context);
        }

        public ActionResult Index()
        {
            User user = new User();
            List<SelectListItem> TypeList = new List<SelectListItem>();
            TypeList.Add(new SelectListItem()
            {
                Text = "Select One",
                Value = "-1"
            });
            TypeList.Add(new SelectListItem()
            {
                Text = "Employee",
                Value = "Employee"
            });
            TypeList.Add(new SelectListItem()
            {
                Text = "Student",
                Value = "Student"
            });
            TypeList.Add(new SelectListItem()
            {
                Text = "Parents",
                Value = "Parents"
            });
            ViewBag.TypeList = TypeList;
            return View(user);
        }
        public ActionResult UserList(string searchKey)
        {
            UserListModel userListSession = (UserListModel)Session["UserList"];
            List<User> userList = new List<User>();
            if (userListSession!= null && userListSession.userList != null && userListSession.userList.Count > 0)
            {
                if(!string.IsNullOrEmpty(searchKey) && searchKey != "null")
                {
                    userList = userListSession.userList.Where(User => User.Address.ToLower().Contains(searchKey.ToLower()) || User.Title.ToLower().Contains(searchKey.ToLower())).ToList();
                }
                else
                {
                    userList = userListSession.userList;
                }
            }
            else
            {
                userListSession = new UserListModel();
                userListSession.userList = new List<User>();
                userListSession.userList.Add(new ModelEntity.User
                {
                    SerialId = 1,
                    Title = "Test1",
                    Date = DateTime.Now.Date,
                    Address = "Nikunja",
                    Remarks = 22,
                    Time = "3.30 PM",
                    Type = "Student"
                });
                userListSession.userList.Add(new ModelEntity.User
                {
                    SerialId = 2,
                    Title = "Test2",
                    Date = DateTime.Now.Date,
                    Address = "KhilKhet",
                    Remarks = 24,
                    Time = "2.30 PM",
                    Type = "Employee"
                });
                userListSession.userList.Add(new ModelEntity.User
                {
                    SerialId = 3,
                    Title = "Test3",
                    Date = DateTime.Now.Date,
                    Address = "Mirpur",
                    Remarks = 25,
                    Time = "1.30 PM",
                    Type = "Parents"
                });
                userList = userListSession.userList;
                Session["UserList"] = userListSession;
            }

            return View(userList);
        }

        [HttpPost]
        public JsonResult SaveUserInfo(User user)
        {
            bool result = false;
            int id = 1;
            try
            {
                UserListModel userListSession = (UserListModel)Session["UserList"];
                if (userListSession != null && userListSession.userList != null && userListSession.userList.Count > 0)
                {
                    id = userListSession.userList.Max(x => x.Id) + 1;
                }
                else
                {
                    userListSession = new UserListModel();
                    userListSession.userList = new List<User>();
                }

                userListSession.userList.Add(new ModelEntity.User
                {
                    SerialId = id,
                    Title = user.Title,
                    Date = user.Date,
                    Address = user.Address,
                    Remarks = user.Remarks,
                    Time = user.Time,
                    Type = user.Type
                });
                Session["UserList"] = userListSession;
                result = true;
            }
            catch(Exception ex)
            {

            }
            
            return Json(result);
        }      
        public JsonResult SaveUserList()
        {
            bool result = false;
            try
            {
                UserListModel userListSession = (UserListModel)Session["UserList"];
                if (userListSession != null && userListSession.userList != null && userListSession.userList.Count > 0)
                {
                    foreach(var item in userListSession.userList)
                    {
                        userRepo.Insert(item);
                    }
                }
                result = true;
                Session["UserList"] = null;
            }
            catch (Exception ex)
            {

            }
            return Json(result);
        }
        public JsonResult DeleteUser(int Id)
        {
            bool result = false;
            int id = 1;
            try
            {
                UserListModel userListSession = (UserListModel)Session["UserList"];
                if (userListSession != null && userListSession.userList != null && userListSession.userList.Count > 0)
                {
                    User user = new User();
                    user = userListSession.userList.Where(x => x.SerialId == Id).FirstOrDefault(); 
                    if(user != null)
                    {
                        userListSession.userList.Remove(user);
                    }
                }
                
                Session["UserList"] = userListSession;
                result = true;
            }
            catch (Exception ex)
            {

            }

            return Json(result);
        }
     
    }
}