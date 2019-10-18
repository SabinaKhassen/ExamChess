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
        public int Position { get; set; }
        public int PrevPosition { get; set; }
        public int ColorId { get; set; }
        public bool IsQueen { get; set; }
        public bool IsEaten { get; set; }
        public DateTime? Movement { get; set; }

        public CheckerBO(IMapper mapper, UnitOfWorkFactory<Checkers> unitOfWorkFactory, IUnityContainer unityContainer)
            : base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public CheckerBO GetCheckersListById(int? id)
        {
            CheckerBO checkers;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                checkers = unitOfWork.EntityRepository.GetAll().Where(a => a.Id == id).Select(item => mapper.Map<CheckerBO>(item)).FirstOrDefault();
            }
            return checkers;
        }

        public List<CheckerBO> GetCheckersList()
        {
            List<CheckerBO> checkers = new List<CheckerBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                checkers = unitOfWork.EntityRepository.GetAll().Select(item => mapper.Map<CheckerBO>(item)).ToList();
            }
            return checkers;
        }

        public void Save()
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                Add(unitOfWork);
            }
        }

        public void Add(IUnitOfWork<Checkers> unitOfWork)
        {
            var checker = mapper.Map<Checkers>(this);
            unitOfWork.EntityRepository.Add(checker);
            unitOfWork.Save();
        }
    }
}
