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

        public ColorBO GetColorsListById(int? id)
        {
            ColorBO colors;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                colors = unitOfWork.EntityRepository.GetAll().Where(a => a.Id == id).Select(item => mapper.Map<ColorBO>(item)).FirstOrDefault();
            }
            return colors;
        }

        public List<ColorBO> GetColorsList()
        {
            List<ColorBO> colors = new List<ColorBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                colors = unitOfWork.EntityRepository.GetAll().Select(item => mapper.Map<ColorBO>(item)).ToList();
            }
            return colors;
        }
    }
}
