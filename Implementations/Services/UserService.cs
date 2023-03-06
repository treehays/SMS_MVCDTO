using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.UserDTOs;
using SMS_MVCDTO.Models.Entities;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace SMS_MVCDTO.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public CreateUserRequestModel Create(CreateUserRequestModel user)
        {
            var userr = new User
            {
                Password = user.Password,
                StaffId = user.StaffId,
                RoleId = user.RoleId,
                Created = DateTime.Now,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            _userRepository.Create(userr);
            return user;
        }

        public void Delete(string staffId)
        {
            var user = _userRepository.GetById(staffId);
            _userRepository.Update(user);
        }

        public UserResponseModel GetById(string staffId)
        {
            var user = _userRepository.GetById(staffId);
            var userr = new UserResponseModel
            {
                Message = "User successfully retrieved.",
                Status = true,
                Data = new UserDTOs
                {
                    Password = user.Password,
                    StaffId = user.StaffId,
                    RoleId = user.RoleId,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                }
            };
            return userr;
        }


        public UserResponseModel Login(LoginRequestModel login)
        {
            // decrypting password
            //var decryptPasswordBase64 = Convert.FromBase64String(login.Password);
            //login.Password = System.Text.Encoding.UTF8.GetString(decryptPasswordBase64);




            //this encrypt the password to base 64 strring (Very week)
            //var encryptPasswordBase64 = System.Text.Encoding.UTF8.GetBytes(login.Password);
            //login.Password = Convert.ToBase64String(encryptPasswordBase64);




            //using RFC Encryption
            //var encryptionKey = "QWhtYWQxMjM=";
            //var clearBytes = Encoding.Unicode.GetBytes(login.Password);
            //using (var encryptor = Aes.Create())
            //{
            //    var pbd = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            //    encryptor.Key = pbd.GetBytes(32);
            //    encryptor.IV = pbd.GetBytes(16);
            //    using (var ms = new MemoryStream())
            //    {
            //        using (var cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
            //        {
            //            cs.Write(clearBytes, 0, clearBytes.Length);
            //            cs.Close();
            //        }
            //        login.Password = Convert.ToBase64String(ms.ToArray());
            //    }
            //}




            //Decryprion
            var encryptionKey = "QWhtYWQxMjM=";
            var cipherBytes = Convert.FromBase64String(login.Password);
            using (var encryptor = Aes.Create())
            {
                var pbd = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pbd.GetBytes(32);
                encryptor.IV = pbd.GetBytes(16);

                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    login.Password = Encoding.Unicode.GetString(ms.ToArray());
                }
            }




            var userr = new User
            {
                StaffId = login.StaffId,
                Password = login.Password,
            };

            var user = _userRepository.Login(userr);
            if (user != null)
            {
                var userResponse = new UserResponseModel
                {
                    Message = "SUccesfull",
                    Status = true,
                    Data = new UserDTOs
                    {
                        Id = user.Id,
                        StaffId = user.StaffId,
                        Password = user.Password,
                        RoleId = user.RoleId,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        ProfilePicture = user.ProfilePicture,
                        Name = user.FirstName,
                    }
                };
                return userResponse;
            }
            return null;
        }

        public UpdateUserPasswordRequestModel UpdatePassword(UpdateUserPasswordRequestModel user)
        {
            var userr = _userRepository.GetById(user.StaffId);
            userr.Password = user.Password ?? userr.Password;
            _userRepository.Update(userr);
            return user;
        }

        private void SendEmail(string emailAddress, string body, string subject)
        {
            using (var mm = new MailMessage("clhprojecttest@gmail.com", emailAddress))
            {
                mm.Subject = subject;
                mm.Body = body;

                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("clhprojecttest@gmail.com", "CLH12345");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);

            }
        }

        public LoginRequestModel ForgotPassword(LoginRequestModel loginDetails)
        {

            var userr = _userRepository.GetById(loginDetails.StaffId);
            var subject = "Password Reset Request";
            var body = "Hi " + loginDetails.StaffId + ", <br/> You recently requested to reset your password for your account. Click the link below to reset it. " +

                 " <br/><br/><a href='" + loginDetails.Password + "'>" + loginDetails.Password + "</a> <br/><br/>" +
                 "If you did not request a password reset, please ignore this email or reply to let us know.<br/><br/> Thank you";

            //SendEmail(loginDetails.StaffId, body, subject);
            SendEmail("treehays90@gmail.com", body, subject);





            userr.PasswordResetToken = loginDetails.Password;
            _userRepository.Update(userr);
            return loginDetails;
        }

        public UpdateUserRoleRequestModel UpdateRole(UpdateUserRoleRequestModel user)
        {
            var userr = _userRepository.GetById(user.StaffId);
            userr.RoleId = user.RoleId;
            _userRepository.Update(userr);
            return user;
        }
    }
}
