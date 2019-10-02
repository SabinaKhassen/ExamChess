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
    public class UserBO : BussinessObjectBase<Users>
    {
        private readonly IUnityContainer unityContainer;

        public int Id { get; set; }
        public string FIO { get; set; }
        public string Email { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public int CityId { get; set; }
        public int RoleId { get; set; }

        public UserBO(IMapper mapper, UnitOfWorkFactory<Users> unitOfWorkFactory, IUnityContainer unityContainer)
            : base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public UserBO GetAuthorsListById(int? id)
        {
            UserBO users;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                users = unitOfWork.EntityRepository.GetAll().Where(a => a.Id == id).Select(item => AutoMapper<Users, UserBO>.Map(item)).FirstOrDefault();
            }
            return users;
        }

        public List<UserBO> GetAuthorsList()
        {
            List<UserBO> users = new List<UserBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                users = unitOfWork.EntityRepository.GetAll().Select(item => AutoMapper<Users, UserBO>.Map(item)).ToList();
            }
            return users;
        }
    }
}
