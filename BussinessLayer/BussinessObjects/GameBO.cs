using AutoMapper;
using DataLayer.Entities;
using DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BussinessLayer.BussinessObjects
{
    public class GameBO : BussinessObjectBase<Games>
    {
        private readonly IUnityContainer unityContainer;

        public int Id { get; set; }
        public int PlayerOne { get; set; }
        public int PlayerTwo { get; set; }
        public int BoardColorId { get; set; }
        public int ChessTypeId { get; set; }
        public DateTime BeginGame { get; set; }
        public DateTime EndGame { get; set; }

        public GameBO(IMapper mapper, UnitOfWorkFactory<Games> unitOfWorkFactory, IUnityContainer unityContainer)
            : base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public GameBO GetGamesListById(int? id)
        {
            GameBO games;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                games = unitOfWork.EntityRepository.GetAll().Where(a => a.Id == id).Select(item => mapper.Map<GameBO>(item)).FirstOrDefault();
            }
            return games;
        }

        public List<GameBO> GetGamesList()
        {
            List<GameBO> games = new List<GameBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                games = unitOfWork.EntityRepository.GetAll().Select(item => mapper.Map<GameBO>(item)).ToList();
            }
            return games;
        }

        public void Save()
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                Add(unitOfWork);
            }
        }

        public void Add(IUnitOfWork<Games> unitOfWork)
        {
            var game = mapper.Map<Games>(this);
            unitOfWork.EntityRepository.Add(game);
            unitOfWork.Save();
        }
    }
}
