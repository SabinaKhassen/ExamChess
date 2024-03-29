﻿using AutoMapper;
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
    public class CountryBO : BussinessObjectBase<Countries>
    {
        private readonly IUnityContainer unityContainer;

        public int Id { get; set; }
        public string Name { get; set; }

        public CountryBO(IMapper mapper, UnitOfWorkFactory<Countries> unitOfWorkFactory, IUnityContainer unityContainer)
            : base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public CountryBO GetCountriesListById(int? id)
        {
            CountryBO countries;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                countries = unitOfWork.EntityRepository.GetAll().Where(a => a.Id == id).Select(item => mapper.Map<CountryBO>(item)).FirstOrDefault();
            }
            return countries;
        }

        public List<CountryBO> GetCountriesList()
        {
            List<CountryBO> countries = new List<CountryBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                countries = unitOfWork.EntityRepository.GetAll().Select(item => mapper.Map<CountryBO>(item)).ToList();
            }
            return countries;
        }
    }
}
