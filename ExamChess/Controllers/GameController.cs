using AutoMapper;
using BussinessLayer;
using BussinessLayer.BussinessObjects;
using ExamChess.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        public static UserViewModel User { get; set; }

        public GameController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        // GET: Game
        public ActionResult Index(int userId)
        {
            ViewBag.Game = null;
            User = mapper.Map<UserViewModel>(DependencyResolver.Current.GetService<UserBO>().GetUsersListById(userId));

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
        public ActionResult Create(GameViewModel model)
        {
            var gamesBO = DependencyResolver.Current.GetService<GameBO>();
            var gamesList = gamesBO.GetGamesList().Select(m => mapper.Map<GameViewModel>(m)).ToList();
            //var match = gamesList.Where(g => g.ChessTypeId == model.ChessTypeId && g.ColorOneId != model.ColorOneId && g.PlayerOne == g.PlayerTwo && g.PlayerOne != model.PlayerOne).ToList();
            //if (match.Count != 0)
            //{
            //    var gameBO = mapper.Map<GameBO>(model);
            //    if (gameBO.GetGamesList().Count == 0)
            //        gameBO.Id = 1;
            //    else
            //        gameBO.Id = gameBO.GetGamesList().Last().Id + 1;
            //    gameBO.PlayerOne = User.Id;
            //    gameBO.PlayerTwo = match[0].PlayerOne;
            //    gameBO.ColorTwoId = match[0].ColorOneId;
            //    gameBO.BeginGame = DateTime.Now;
            //    gameBO.EndGame = DateTime.Now;

            //    gameBO.Save();
            //    gameBO.Delete(match[0].Id);

            //    //gameBO = DependencyResolver.Current.GetService<GameBO>();

            //    var game = mapper.Map<GameViewModel>(gameBO.GetGamesListById(gameBO.Id));

            //    return PartialView("Partial/GameBoardPartialView", game);
            //}
            //else
            //{
                var gameBO = mapper.Map<GameBO>(model);
                //if (gameBO.GetGamesList().Count == 0)
                //    gameBO.Id = 1;
                //else
                //    gameBO.Id = gameBO.GetGamesList().Last().Id + 1;
                gameBO.PlayerOne = User.Id;
                gameBO.PlayerTwo = User.Id;
                gameBO.BeginGame = DateTime.Now;
                gameBO.EndGame = DateTime.Now;
                gameBO.WinnerId = User.Id;

                gameBO.Save();

                var newgame = DependencyResolver.Current.GetService<GameBO>(); 
                var game = mapper.Map<GameViewModel>(newgame.GetGamesList().LastOrDefault());

                return Json(new { id = game.Id, player = game.PlayerOne, chesstype = game.ChessTypeId, color = game.ColorOneId });
            //}
        }

        [HttpGet]
        public JsonResult ColorDropDown()
        {
            //var boardColorBO = DependencyResolver.Current.GetService<BoardColorBO>();
            //var boardColorList = boardColorBO.GetBoardColorsList().Select(item => mapper.Map<BoardColorViewModel>(item)).ToList();

            var colorBO = DependencyResolver.Current.GetService<ColorBO>();
            var colorList = colorBO.GetColorsList().Select(m => mapper.Map<ColorViewModel>(m)).ToList();

            //return Json(boardColorList
            //    .Select(c => new { c.Id, Color = colorBO.GetColorsListById(c.ColorOne).Color + " " + colorBO.GetColorsListById(c.ColorTwo).Color }), 
            //    JsonRequestBehavior.AllowGet);
            return Json(colorList.Select(c => new { c.Id, c.Color }), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult ChessTypeDropDown()
        {
            var chessTypeBO = DependencyResolver.Current.GetService<ChessTypeBO>();
            var chessTypeList = chessTypeBO.GetChessTypesList().Select(item => mapper.Map<ChessTypeViewModel>(item)).ToList();

            return Json(chessTypeList.Select(c => new { c.Id, c.Name }), JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public JsonResult GameBoardJson(int colorId, int gameId)
        //{
        //    //var colorBO = DependencyResolver.Current.GetService<ColorBO>();
        //    //var id = colorBO.GetColorsListById(colorId).Id;
        //    ////var id = 1;
        //    //int position = 0;

        //    //for (var row = 0; row < 3; row++)
        //    //{
        //    //    if (row % 2 == 0)
        //    //    {
        //    //        for (var line = 0; line < 8; line++)
        //    //        {
        //    //            if (line % 2 == 0)
        //    //            {
        //    //                var checker = DependencyResolver.Current.GetService<CheckerBO>();
        //    //                checker.ColorId = id;
        //    //                checker.GameId = gameId;
        //    //                checker.IsEaten = false;
        //    //                checker.IsQueen = false;
        //    //                checker.Movement = DateTime.Now;
        //    //                checker.Position = position;
        //    //                checker.PrevPosition = position;
        //    //                checker.Save();
        //    //            }

        //    //            position++;
        //    //        }
        //    //    }
        //    //    else
        //    //    {
        //    //        for (var line = 0; line < 8; line++)
        //    //        {
        //    //            if (line % 2 != 0)
        //    //            {
        //    //                var checker = DependencyResolver.Current.GetService<CheckerBO>();
        //    //                checker.ColorId = id;
        //    //                checker.GameId = gameId;
        //    //                checker.IsEaten = false;
        //    //                checker.IsQueen = false;
        //    //                checker.Movement = DateTime.Now;
        //    //                checker.Position = position;
        //    //                checker.PrevPosition = position;
        //    //                checker.Save();
        //    //            }

        //    //            position++;
        //    //        }
        //    //    }
        //    //}

        //    //var positionBO = DependencyResolver.Current.GetService<CheckerBO>().GetCheckersList().Where(p => p.GameId == gameId).ToList();
        //    //var checkers = positionBO.Select(m => mapper.Map<CheckerViewModel>(m)).ToList();

        //    //return Json(checkers, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public JsonResult GameReturnBoard(int id)
        {
            var gameBO = DependencyResolver.Current.GetService<GameBO>();
            var game = mapper.Map<GameViewModel>(gameBO.GetGamesListById(id));

            return Json(new { game.Id, game.PlayerOne, game.PlayerTwo, game.ChessTypeId, game.ColorOneId, game.ColorTwoId }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public void AddCheckers(CheckerViewModel json)
        //{
        //    var checkerBO = mapper.Map<CheckerBO>(json);
        //    checkerBO.Save();
        //}

        [HttpGet]
        public JsonResult GameMatches(int gameId, int colorId, int typeId)
        {
            var gamesBO = DependencyResolver.Current.GetService<GameBO>();
            var gamesList = gamesBO.GetGamesList().Select(m => mapper.Map<GameViewModel>(m)).ToList();
            var match = gamesList.Where(g => g.ChessTypeId == typeId && g.ColorOneId != colorId && g.PlayerOne == g.PlayerTwo && g.Id != gameId).ToList();
            if (match.Count != 0)
            {
                return Json(match.Select(m => new { match = true, currentId = m.Id, playerTwo = m.PlayerOne, colorTwo = m.ColorOneId }), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { match = false, currentId = 0, playerTwo = 0, colorTwo = 0 }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult MatchFound(int PrevId, int Id, int PlayerOne, int PlayerTwo, int ColorOneId, int ColorTwoId, int ChessTypeId)
        {
            var gameBO = DependencyResolver.Current.GetService<GameBO>();
            var newgame = gameBO.GetGamesListById(Id);
            newgame.PlayerOne = PlayerOne;
            newgame.PlayerTwo = PlayerTwo;
            newgame.ColorOneId = ColorOneId;
            newgame.ColorTwoId = ColorTwoId;
            newgame.ChessTypeId = ChessTypeId;
            newgame.BeginGame = DateTime.Now;
            newgame.EndGame = DateTime.Now;
            newgame.WinnerId = PlayerOne;

            newgame.Save();
            newgame.Delete(PrevId);

            //gameBO = DependencyResolver.Current.GetService<GameBO>();

            var game = mapper.Map<GameViewModel>(newgame);

            return PartialView("Partial/GameBoardPartialView", game);
        }

        [HttpPost]
        public JsonResult StopWait(int game)
        {
            var gameBO = DependencyResolver.Current.GetService<GameBO>();
            gameBO.Delete(game);

            return Json(new { stopped = true });
        }
    }
}
