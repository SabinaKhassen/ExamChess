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
    //public class BoardColorBO : BussinessObjectBase<BoardColors>
    //{
    //    private readonly IUnityContainer unityContainer;

    //    public int Id { get; set; }
    //    public int ColorOne { get; set; }
    //    public int ColorTwo { get; set; }

    //    public BoardColorBO(IMapper mapper, UnitOfWorkFactory<BoardColors> unitOfWorkFactory, IUnityContainer unityContainer)
    //        : base(mapper, unitOfWorkFactory)
    //    {
    //        this.unityContainer = unityContainer;
    //    }

    //    public BoardColorBO GetBoardColorsListById(int? id)
    //    {
    //        BoardColorBO colors;

    //        using (var unitOfWork = unitOfWorkFactory.Create())
    //        {
    //            colors = unitOfWork.EntityRepository.GetAll().Where(a => a.Id == id).Select(item => mapper.Map<BoardColorBO>(item)).FirstOrDefault();
    //        }
    //        return colors;
    //    }

    //    public List<BoardColorBO> GetBoardColorsList()
    //    {
    //        List<BoardColorBO> colors = new List<BoardColorBO>();

    //        using (var unitOfWork = unitOfWorkFactory.Create())
    //        {
    //            colors = unitOfWork.EntityRepository.GetAll().Select(item => mapper.Map<BoardColorBO>(item)).ToList();
    //        }
    //        return colors;
    //    }
    //}
}
