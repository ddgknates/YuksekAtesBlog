
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuksekAtesBlog.Business.Services;
using YuksekAtesBlog.Business.Types;
using YuksekAtesBlog.Data.Dto;
using YuksekAtesBlog.Data.Entities;
using YuksekAtesBlog.Data.Repositories;

namespace YuksekAtesBlog.Business.Managers
{
    public class AdminManager : IAdminService
    {
        private readonly IRepository<AdminEntity> _adminRepository;
        private readonly IDataProtector _dataProtector;
        public AdminManager(IRepository<AdminEntity> adminRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _adminRepository = adminRepository;
            _dataProtector = dataProtectionProvider.CreateProtector("security");
        }

        public AdminDto GetAdminById(int id)
        {
            var admin = _adminRepository.GetById(id);
            var adminDto = new AdminDto
            {
                Id = admin.Id,
                Password = admin.Password,
            };

            return adminDto;
        }

        public AdminDto Login(string email, string password)
        {

            var admin = _adminRepository.Get(x => x.Email == email);
            if (admin is null)
            {
                return null;
            }
            var rawPassword = "123456";
            if (admin.Password.Length > 20)
            {
                rawPassword = _dataProtector.Unprotect(admin.Password);
            }

            if (password != rawPassword)
            {
                return null;
            }
            var adminDto = new AdminDto
            {
                Id = admin.Id,
                Email = admin.Email,
                Password = admin.Password,
                UserType = admin.UserType
            };
            return adminDto;
        }

        public void UpdateAdmin(AdminDto admin)
        {
            var adminEntity = _adminRepository.GetById(admin.Id);

            adminEntity.Password = _dataProtector.Protect(admin.Password);

            _adminRepository.Update(adminEntity);
        }
    }
}
