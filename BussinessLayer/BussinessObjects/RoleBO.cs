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

        public RoleBO GetRolesListById(int? id)
        {
            RoleBO roles;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                roles = unitOfWork.EntityRepository.GetAll().Where(a => a.Id == id).Select(item => mapper.Map<RoleBO>(item)).FirstOrDefault();
            }
            return roles;
        }

        public List<RoleBO> GetRolesList()
        {
            List<RoleBO> roles = new List<RoleBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                roles = unitOfWork.EntityRepository.GetAll().Select(item => mapper.Map<RoleBO>(item)).ToList();
            }
            return roles;
        }
    }
}
