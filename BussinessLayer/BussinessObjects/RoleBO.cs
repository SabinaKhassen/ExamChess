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
    public class RoleBO : BussinessObjectBase<Roles>
    {
        private readonly IUnityContainer unityContainer;

        public int Id { get; set; }
        public string Status { get; set; }

        public RoleBO(IMapper mapper, UnitOfWorkFactory<Roles> unitOfWorkFactory, IUnityContainer unityContainer)
            : base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public RoleBO GetAuthorsListById(int? id)
        {
            RoleBO roles;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                roles = unitOfWork.EntityRepository.GetAll().Where(a => a.Id == id).Select(item => AutoMapper<Roles, RoleBO>.Map(item)).FirstOrDefault();
            }
            return roles;
        }

        public List<RoleBO> GetAuthorsList()
        {
            List<RoleBO> roles = new List<RoleBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                roles = unitOfWork.EntityRepository.GetAll().Select(item => AutoMapper<Roles, RoleBO>.Map(item)).ToList();
            }
            return roles;
        }
    }
}
