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
    public class ChessTypeBO : BussinessObjectBase<ChessTypes>
    {
        private readonly IUnityContainer unityContainer;

        public int Id { get; set; }
        public string Name { get; set; }

        public ChessTypeBO(IMapper mapper, UnitOfWorkFactory<ChessTypes> unitOfWorkFactory, IUnityContainer unityContainer)
            : base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public ChessTypeBO GetChessTypesListById(int? id)
        {
            ChessTypeBO types;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                types = unitOfWork.EntityRepository.GetAll().Where(a => a.Id == id).Select(item => mapper.Map<ChessTypeBO>(item)).FirstOrDefault();
            }
            return types;
        }

        public List<ChessTypeBO> GetChessTypesList()
        {
            List<ChessTypeBO> types = new List<ChessTypeBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                types = unitOfWork.EntityRepository.GetAll().Select(item => mapper.Map<ChessTypeBO>(item)).ToList();
            }
            return types;
        }
    }
}
