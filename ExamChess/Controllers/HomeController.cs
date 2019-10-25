using AutoMapper;
using BussinessLayer.BussinessObjects;
using ExamChess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace ExamChess.Controllers
{
    public class HomeController : Controller
    {
        IMapper mapper;

        public HomeController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            var userBO = DependencyResolver.Current.GetService<UserBO>();
            var user = mapper.Map<UserViewModel>(userBO);

            if (Request.IsAjaxRequest())
            {
                return PartialView("Partial/RegisterPartialView", user);
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult Register(UserViewModel model/*, string password*/)
        {
            var userBO = DependencyResolver.Current.GetService<UserBO>();
            var userList = userBO.GetUsersList().Select(m => mapper.Map<UserViewModel>(m)).ToList();

            var findMatch = userList.Where(u => u.Nick == model.Nick).ToList();

            model.RoleId = DependencyResolver.Current.GetService<RoleBO>().GetRolesList().Where(r => r.Status == "User").Select(r => r.Id).FirstOrDefault();

            if (findMatch.Count == 0)
            {
                var userModel = mapper.Map<UserBO>(model);

                userModel.Save();
                userBO = DependencyResolver.Current.GetService<UserBO>();
                var user = userBO.GetUsersList().Select(m => mapper.Map<UserViewModel>(m)).Last();

                return RedirectToAction("Index", "Game", new { userId = user.Id });
            }
            else
            {
                var user = mapper.Map<UserViewModel>(userBO);

                MessageBox.Show("This nickname already exists");
                return PartialView("Partial/RegisterPartialView", user);
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            var login = new LogIn();

            if (Request.IsAjaxRequest())
            {
                return PartialView("Partial/LogInPartialView", login);
            }

            return View("Index");
        } 

        [HttpPost]
        public ActionResult Login(LogIn model)
        {
            var userBO = DependencyResolver.Current.GetService<UserBO>();
            var match = userBO.GetUsersList().Where(u => u.Nick == model.Nick && u.Password == model.PasswordLogin).ToList();
            if (match.Count != 0)
            {
                var userLog = mapper.Map<UserViewModel>(match[0]);

                var adminRole = DependencyResolver.Current.GetService<RoleBO>().GetRolesList().Where(r => r.Status == "Admin").Select(r => r.Id).FirstOrDefault();

                if (userLog.RoleId == adminRole)
                {
                    return RedirectToAction("Index", "Admin", new { userId = userLog.Id });
                    //return Json(new { userId = userLog.Id, admin = true });
                }
                else
                {
                    return RedirectToActionPermanent("Index", "Game", new { userId = userLog.Id });
                }
            }
            else
            {
                return new HttpStatusCodeResult(401, "Nick or password don't match!");
            }
        }


        [HttpGet]
        public JsonResult CityDropDown()
        {
            var cityBO = DependencyResolver.Current.GetService<CityBO>();
            var cityList = cityBO.GetCitiesList().Select(m => mapper.Map<CityViewModel>(m)).ToList();

            var countryBO = DependencyResolver.Current.GetService<CountryBO>();
            var countryList = countryBO.GetCountriesList().Select(m => mapper.Map<CountryViewModel>(m)).ToList();

            return Json(cityList.Select(c => new { c.Id, c.Name, Country = mapper.Map<CountryViewModel>(countryBO.GetCountriesListById(c.CountryId)).Name }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult RoleDropDown()
        {
            var roleBO = DependencyResolver.Current.GetService<RoleBO>();
            var roleList = roleBO.GetRolesList().Select(m => mapper.Map<RoleViewModel>(m)).ToList();

            return Json(roleList.Select(r => new { r.Id, r.Status }).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult UserInfo()
        {
            var userBO = DependencyResolver.Current.GetService<UserBO>();
            var userList = userBO.GetUsersList().Select(m => mapper.Map<UserViewModel>(m)).ToList();

            return Json(userList.Select(u => new { u.Nick }).ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}