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
    public class ColorBO : BussinessObjectBase<Colors>
    {
        private readonly IUnityContainer unityContainer;

        public int Id { get; set; }
        public string Color { get; set; }

        public ColorBO(IMapper mapper, UnitOfWorkFactory<Colors> unitOfWorkFactory, IUnityContainer unityContainer)
            : base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public ColorBO GetAuthorsListById(int? id)
        {
            ColorBO colors;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                colors = unitOfWork.EntityRepository.GetAll().Where(a => a.Id == id).Select(item => AutoMapper<Colors, ColorBO>.Map(item)).FirstOrDefault();
            }
            return colors;
        }

        public List<ColorBO> GetAuthorsList()
        {
            List<ColorBO> colors = new List<ColorBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                colors = unitOfWork.EntityRepository.GetAll().Select(item => AutoMapper<Colors, ColorBO>.Map(item)).ToList();
            }
            return colors;
        }
    }
}
