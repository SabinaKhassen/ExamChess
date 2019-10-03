using AutoMapper;
using BussinessLayer;
using BussinessLayer.BussinessObjects;
using ExamChess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamChess.Controllers
{
    public class GameController : Controller
    {
        IMapper mapper;

        public GameController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        // GET: Game
        public ActionResult Index()
        {
            return View();
        }

        //// GET: Game/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Game/Create
        public ActionResult Create()
        {
            var gameBO = DependencyResolver.Current.GetService<GameBO>();
            var model = mapper.Map<GameViewModel>(gameBO);

            if (Request.IsAjaxRequest())
            {
                return PartialView("Partial/EditPartialView", model);
            }

            return View();
        }

        // POST: Game/Create
        [HttpPost]
        public ActionResult Create(GameViewModel model, int chessType, int color)
        {
            var gameBO = mapper.Map<GameBO>(model);
            if (gameBO.GetGamesList().Count == 0)
                gameBO.Id = 1;
            else
                gameBO.Id = gameBO.GetGamesList().Last().Id + 1;
            gameBO.PlayerOne = 1;
            gameBO.PlayerTwo = 2;
            gameBO.ChessTypeId = chessType;
            gameBO.ColorId = color;
            gameBO.BeginGame = DateTime.Now;
            gameBO.EndGame = DateTime.Now;

            gameBO.Save();

            var game = mapper.Map<GameViewModel>(gameBO.GetGamesListById(gameBO.Id));
            return PartialView("Partial/GameBoardPartialView", game);
        }

        [HttpGet]
        public ActionResult ColorDropDown()
        {
            var colorBO = DependencyResolver.Current.GetService<ColorBO>();
            var colorList = colorBO.GetColorsList().Select(item => mapper.Map<ColorViewModel>(item)).ToList();

            return Json(colorList.Select(c => new { c.Id, c.Color }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ChessTypeDropDown()
        {
            var chessTypeBO = DependencyResolver.Current.GetService<ChessTypeBO>();
            var chessTypeList = chessTypeBO.GetChessTypesList().Select(item => mapper.Map<ChessTypeViewModel>(item)).ToList();

            return Json(chessTypeList.Select(c => new { c.Id, c.Name }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GameBoardJson(int colorId, int gameId)
        {
            for (var row = 0; row < 3; row++)
            {
                if (row % 2 != 0)
                {
                    for (var line = 0; line < 8; line = line + 2)
                    {
                        var checker = DependencyResolver.Current.GetService<CheckerBO>();
                        checker.ColorId = colorId;
                        checker.GameId = gameId;
                        checker.IsEaten = false;
                        checker.IsQueen = false;
                        checker.Movement = DateTime.Now;
                        checker.PositionX = line;
                        checker.PositionY = row;
                        checker.Save();
                    }
                }
                else
                {
                    for (var line = 1; line < 8; line = line + 2)
                    {
                        var checker = DependencyResolver.Current.GetService<CheckerBO>();
                        checker.ColorId = colorId;
                        checker.GameId = gameId;
                        checker.IsEaten = false;
                        checker.IsQueen = false;
                        checker.Movement = DateTime.Now;
                        checker.PositionX = line;
                        checker.PositionY = row;
                        checker.Save();
                    }
                }
            }

            var positionBO = DependencyResolver.Current.GetService<CheckerBO>().GetCheckersList();
            var checkers = positionBO.Select(m => mapper.Map<CheckerViewModel>(m)).ToList();

            return Json(checkers, JsonRequestBehavior.AllowGet);
        }
    }
}
