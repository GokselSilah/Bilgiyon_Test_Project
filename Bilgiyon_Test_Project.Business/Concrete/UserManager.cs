using Bilgiyon_Test_Project.Business.Abstract;
using Bilgiyon_Test_Project.Core.Results;
using Bilgiyon_Test_Project.DataAccess.Abstract;
using Bilgiyon_Test_Project.DataAccess.Concrete.EntityFramework;
using Bilgiyon_Test_Project.Entity.Concrete;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Bilgiyon_Test_Project.Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public MobilResult<LogonUser> LoginUser(LogonUser user)
        {
            User logginingUser = _userDal.LoginUser(user);
            LogonUser logonUser = new LogonUser();
            MobilResult<LogonUser> result = new MobilResult<LogonUser>();



            if (user == null)
            {
                result.UserMessage = "Kullanıcı Adı ve Şifre Girilmedi.";
                result.IsSucceeded = false;
                return result;
            }
            else if (user.UserName.IsNullOrEmpty())
            {
                result.UserMessage = "Kullanıcı Adı Alanı Boş Geçilemez.";
                result.IsSucceeded = false;
                return result;
            }
            else if (user.Password.IsNullOrEmpty())
            {
                result.UserMessage = "Parola Alanı Boş Geçilemez.";
                result.IsSucceeded = false;
                return result;
            }
            else if (logginingUser == null)
            {
                result.UserMessage = "Kullanıcı Bulunamadı";
                result.IsSucceeded = false;
                return result;
            }
            else
            {
                var jsonString = JsonConvert.SerializeObject(user);
                string token = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonString));
                user.Token = "Basic " + token;
                result.UserMessage = "Giriş Başarılı.";
                result.IsSucceeded = true;
                return result;                
            }

        }



    }
}
