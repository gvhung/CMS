using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Core.Interfaces;
using CRM.DAL.Interfaces;
using CRM.Core.Model;
using FlairBees.Common;
using CRM.DAL.Entities;

namespace CRM.Core
{
    public class UserManager :BaseManager, IManager<UserViewModel>
    {
        public UserManager(IUnitOfWork uow):base(uow)
        {

        }
        public long Count()
        {
            return uow.UserRepository.Count();
        }

        public bool Authenticate(UserCreateModel user)
        {

            CRMUser crmUser= uow.UserRepository.GetUserByLoginId(user.LoginId);
            string passwordHash = Encryptor.GenerateHash(user.Password + crmUser.PasswordSalt);
            return (crmUser.PasswordHash == passwordHash);
            
        }
        public void RegisterUser(UserCreateModel model)
        {
            //Generating hash for password 
            string salt = Encryptor.GetSaltString();
            string password = model.Password + salt;
            string hashPassword = Encryptor.GenerateHash(password);
            CRMUser user=AutoMapper.Mapper.Map<UserCreateModel, CRMUser>(model);
            uow.UserRepository.Add(user);
            uow.SaveChanges();
        }

        public UserListModel GetAll(int pageNo, int pageSize, string userName, string customerName )
        {
          var users=  uow.UserRepository.GetQueryable()
                      .Where(u => u.Name == userName 
                        && u.Customer.CustomerName == customerName)
                      .Skip(pageNo - 1).Take(pageSize)
                      .Select(u=>new UserViewModel()
                      {
                          Name = u.Name,
                          LoginId = u.LoginId
                          ,
                          Usertype = u.UserType.Description,
                          Status = u.StatusMaster.Description
                      });
            UserListModel model = new UserListModel();
            model.PageNo = pageNo;
            model.PageSize = pageSize;
            model.Users = users.ToList();
            return model;
        }

        public void Remove(UserViewModel model)
        {
            CRMUser user = uow.UserRepository.GetUserByUID(model.UID);
            if (user == null)
                throw new Exception("user not found");
            else
            {
                uow.UserRepository.Delete(user);
            }
            uow.SaveChanges();
        }

        public void Update(UserViewModel model)
        {
            
        }

        public void Create(UserViewModel model)
        {
            throw new NotImplementedException();
        }

        public List<UserViewModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
