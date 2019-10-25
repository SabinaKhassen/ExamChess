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
    public class AdminController : Controller
    {
        public static UserViewModel UserAdmin { get; set; }

        IMapper mapper;

        public AdminController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        // GET: Admin
        public ActionResult Index(int userId)
        {
            UserAdmin = mapper.Map<UserViewModel>(DependencyResolver.Current.GetService<UserBO>().GetUsersListById(userId));

            var userList = ListsFunction();

            ViewBag.Users = userList;
            ViewBag.AdminName = UserAdmin.FIO;

            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("Partial/UserPartialView", ViewBag.Users);
            //}

            return View("Index");
        }

        // GET: Admin/Create
        [HttpGet]
        public ActionResult CreateOrEdit(int id)
        {
            if (Request.IsAjaxRequest())
            {
                if (id == 0)
                {
                    return PartialView("Partial/CreateOrEditPartialView", new UserViewModel());
                }
                else
                {
                    var userBO = DependencyResolver.Current.GetService<UserBO>();
                    var user = mapper.Map<UserViewModel>(userBO.GetUsersListById(id));

                    return PartialView("Partial/CreateOrEditPartialView", user);
                }
            }

            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult CreateOrEdit(UserViewModel model)
        {
            var userBO = mapper.Map<UserBO>(model);
            userBO.Save();

            var userList = ListsFunction();

            return PartialView("Partial/UserPartialView", userList);
        }
       
        // GET: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var userBO = DependencyResolver.Current.GetService<UserBO>();
            userBO.Delete(id);

            var userList = ListsFunction();

            if (Request.IsAjaxRequest())
            {
                return PartialView("Partial/UserPartialView", userList);
            }

            return RedirectToActionPermanent("Index", "Admin", new { userId = UserAdmin.Id });
        }

        [HttpPost]
        public ActionResult Block(int id, bool block)
        {
            if (block)
            {
                var userBO = DependencyResolver.Current.GetService<UserBO>();
                var user = userBO.GetUsersListById(id);
                user.Blocked = true;
                user.Save();
            }
            else
            {
                var userBO = DependencyResolver.Current.GetService<UserBO>();
                var user = userBO.GetUsersListById(id);
                user.Blocked = false;
                user.Save();
            }

            var userList = ListsFunction();

            if (Request.IsAjaxRequest())
            {
                return PartialView("Partial/UserPartialView", userList);
            }

            return RedirectToActionPermanent("Index", "Admin", new { userId = UserAdmin.Id });
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

        public List<UserViewModel> ListsFunction()
        {
            var userList = DependencyResolver.Current.GetService<UserBO>().GetUsersList().Where(u => u.Id != UserAdmin.Id && u.Deleted == false).Select(m => mapper.Map<UserViewModel>(m)).ToList();

            var cityBO = DependencyResolver.Current.GetService<CityBO>();
            var cityList = cityBO.GetCitiesList().Select(m => mapper.Map<CityViewModel>(m)).ToList();

            var countryBO = DependencyResolver.Current.GetService<CountryBO>();
            var countryList = countryBO.GetCountriesList().Select(m => mapper.Map<CountryViewModel>(m)).ToList();

            var roleBO = DependencyResolver.Current.GetService<RoleBO>();
            var roleList = roleBO.GetRolesList().Select(m => mapper.Map<RoleViewModel>(m)).ToList();

            ViewBag.Cities = cityList;
            ViewBag.Countries = countryList;
            ViewBag.Roles = roleList;

            return userList;
        }
    }
}
