using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YuksekAtesBlog.Business.Types;
using YuksekAtesBlog.Data.Dto;
using YuksekAtesBlog.Data.Entities;

namespace YuksekAtesBlog.Business.Services
{
    public interface IAdminService
    {
        AdminDto Login(string email, string password);
        AdminDto GetAdminById(int id);
        void UpdateAdmin(AdminDto admin);
    }
}
