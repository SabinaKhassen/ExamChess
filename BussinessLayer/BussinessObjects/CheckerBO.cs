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
    public class CheckerBO : BussinessObjectBase<Checkers>
    {
        private readonly IUnityContainer unityContainer;

        public int Id { get; set; }
        public int GameId { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int ColorId { get; set; }
        public int CheckerTypeId { get; set; }

        public CheckerBO(IMapper mapper, UnitOfWorkFactory<Checkers> unitOfWorkFactory, IUnityContainer unityContainer)
            : base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public CheckerBO GetAuthorsListById(int? id)
        {
            CheckerBO checkers;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                checkers = unitOfWork.EntityRepository.GetAll().Where(a => a.Id == id).Select(item => AutoMapper<Checkers, CheckerBO>.Map(item)).FirstOrDefault();
            }
            return checkers;
        }

        public List<CheckerBO> GetAuthorsList()
        {
            List<CheckerBO> checkers = new List<CheckerBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                checkers = unitOfWork.EntityRepository.GetAll().Select(item => AutoMapper<Checkers, CheckerBO>.Map(item)).ToList();
            }
            return checkers;
        }
    }
}
