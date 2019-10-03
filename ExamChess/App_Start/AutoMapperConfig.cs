using AutoMapper;
using BussinessLayer.BussinessObjects;
using DataLayer.Entities;
using ExamChess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace ExamChess.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterWithUnity(IUnityContainer container)
        {
            IMapper mapper = CreateConfiguration().CreateMapper();

            container.RegisterInstance(mapper);
        }

        static MapperConfiguration CreateConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                #region BoardColors
                cfg.CreateMap<BoardColorBO, BoardColors>().
                ConstructUsing(item => DependencyResolver.Current.GetService<BoardColors>());

                cfg.CreateMap<BoardColorBO, BoardColorViewModel>().
                ConstructUsing(item => DependencyResolver.Current.GetService<BoardColorViewModel>());

                cfg.CreateMap<BoardColorViewModel, BoardColorBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<BoardColorBO>());

                cfg.CreateMap<BoardColors, BoardColorBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<BoardColorBO>());
                #endregion

                #region Checkers
                cfg.CreateMap<CheckerBO, Checkers>().
                ConstructUsing(item => DependencyResolver.Current.GetService<Checkers>());

                cfg.CreateMap<CheckerBO, CheckerViewModel>().
                ConstructUsing(item => DependencyResolver.Current.GetService<CheckerViewModel>());

                cfg.CreateMap<CheckerViewModel, CheckerBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<CheckerBO>());

                cfg.CreateMap<Checkers, CheckerBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<CheckerBO>());
                #endregion

                #region ChessTypes
                cfg.CreateMap<ChessTypeBO, ChessTypes>().
                ConstructUsing(item => DependencyResolver.Current.GetService<ChessTypes>());

                cfg.CreateMap<ChessTypeBO, ChessTypeViewModel>().
                ConstructUsing(item => DependencyResolver.Current.GetService<ChessTypeViewModel>());

                cfg.CreateMap<ChessTypeViewModel, ChessTypeBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<ChessTypeBO>());

                cfg.CreateMap<ChessTypes, ChessTypeBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<ChessTypeBO>());
                #endregion

                #region Cities
                cfg.CreateMap<CityBO, Cities>().
                ConstructUsing(item => DependencyResolver.Current.GetService<Cities>());

                cfg.CreateMap<CityBO, CityViewModel>().
                ConstructUsing(item => DependencyResolver.Current.GetService<CityViewModel>());

                cfg.CreateMap<CityViewModel, CityBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<CityBO>());

                cfg.CreateMap<Cities, CityBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<CityBO>());
                #endregion

                #region Colors
                cfg.CreateMap<ColorBO, Colors>().
                ConstructUsing(item => DependencyResolver.Current.GetService<Colors>());

                cfg.CreateMap<ColorBO, ColorViewModel>().
                ConstructUsing(item => DependencyResolver.Current.GetService<ColorViewModel>());

                cfg.CreateMap<ColorViewModel, ColorBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<ColorBO>());

                cfg.CreateMap<Colors, ColorBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<ColorBO>());
                #endregion

                #region Countries
                cfg.CreateMap<CountryBO, Countries>().
                ConstructUsing(item => DependencyResolver.Current.GetService<Countries>());

                cfg.CreateMap<CountryBO, CountryViewModel>().
                ConstructUsing(item => DependencyResolver.Current.GetService<CountryViewModel>());

                cfg.CreateMap<CountryViewModel, CountryBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<CountryBO>());

                cfg.CreateMap<Countries, CountryBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<CountryBO>());
                #endregion

                #region Games
                cfg.CreateMap<GameBO, Games>().
                ConstructUsing(item => DependencyResolver.Current.GetService<Games>());

                cfg.CreateMap<GameBO, GameViewModel>().
                ConstructUsing(item => DependencyResolver.Current.GetService<GameViewModel>());

                cfg.CreateMap<GameViewModel, GameBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<GameBO>());

                cfg.CreateMap<Games, GameBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<GameBO>());
                #endregion

                #region Roles
                cfg.CreateMap<RoleBO, Roles>().
                ConstructUsing(item => DependencyResolver.Current.GetService<Roles>());

                cfg.CreateMap<RoleBO, RoleViewModel>().
                ConstructUsing(item => DependencyResolver.Current.GetService<RoleViewModel>());

                cfg.CreateMap<RoleViewModel, RoleBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<RoleBO>());

                cfg.CreateMap<Roles, RoleBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<RoleBO>());
                #endregion

                #region Users
                cfg.CreateMap<UserBO, Users>().
                ConstructUsing(item => DependencyResolver.Current.GetService<Users>());

                cfg.CreateMap<UserBO, UserViewModel>().
                ConstructUsing(item => DependencyResolver.Current.GetService<UserViewModel>());

                cfg.CreateMap<UserViewModel, UserBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<UserBO>());

                cfg.CreateMap<Users, UserBO>().
                ConstructUsing(item => DependencyResolver.Current.GetService<UserBO>());
                #endregion
            });
        }
    }
}