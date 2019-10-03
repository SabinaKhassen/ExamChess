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
    public class CityBO : BussinessObjectBase<Cities>
    {
        private readonly IUnityContainer unityContainer;

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public CityBO(IMapper mapper, UnitOfWorkFactory<Cities> unitOfWorkFactory, IUnityContainer unityContainer)
            : base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public CityBO GetCitiesListById(int? id)
        {
            CityBO cities;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                cities = unitOfWork.EntityRepository.GetAll().Where(a => a.Id == id).Select(item => mapper.Map<CityBO>(item)).FirstOrDefault();
            }
            return cities;
        }

        public List<CityBO> GetCitiesList()
        {
            List<CityBO> cities = new List<CityBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                cities = unitOfWork.EntityRepository.GetAll().Select(item => mapper.Map<CityBO>(item)).ToList();
            }
            return cities;
        }
    }
}
