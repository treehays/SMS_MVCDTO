using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using SMS_MVCDTO.Context;
using SMS_MVCDTO.Interfaces.Repositories;
using SMS_MVCDTO.Models.DTOs;
using SMS_MVCDTO.Models.Entities;

namespace SMS_MVCDTO.Implementations.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EmailConfiguration _configuration;
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context, IOptions<EmailConfiguration> configuration)
        {
            _context = context;
            _configuration = configuration.Value;
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        //public void Delete(User user)
        //{
        //    _context.Users.Update(user);
        //    _context.SaveChanges();
        //}

        public User GetById(string staffId)
        {
            var user = _context.Users.Include(a => a.Role).SingleOrDefault(x => x.StaffId == staffId);
            return user;
        }

        public User Login(User user)
        {
            var userr = _context.Users.Include(b => b.SuperAdmin).SingleOrDefault(a => a.StaffId == user.StaffId && a.Password == user.Password);
            return userr;
        }

        public bool SendEmail(string email, string OTPKey)
        {
            var tokeenKey = _configuration.TokenKey;
            Configuration.Default.ApiKey.Clear();
            Configuration.Default.ApiKey.Add("api-key", tokeenKey);

            var apiInstance = new TransactionalEmailsApi();
            string SenderName = "Abdulsalam Ahmad Sende";
            string SenderEmail = "treehays90@gmail.com";
            SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);
            string ToEmail = "aymoneyay@gmail.com";
            string ToName = "Ahmad Doe";
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);
            string BccName = "Salam Ahmad Doe";
            string BccEmail = "treehays90@yahoo.com";
            SendSmtpEmailBcc BccData = new SendSmtpEmailBcc(BccEmail, BccName);
            List<SendSmtpEmailBcc> Bcc = new List<SendSmtpEmailBcc>();
            Bcc.Add(BccData);
            string CcName = "Ahmad Test Email";
            string CcEmail = "abdulsalamayoola@gmail.com";
            SendSmtpEmailCc CcData = new SendSmtpEmailCc(CcEmail, CcName);
            List<SendSmtpEmailCc> Cc = new List<SendSmtpEmailCc>();
            Cc.Add(CcData);
            string HtmlContent = "<html><body><h1>Thhis a  new email composing ferom the ne trying of emal</h1> <p> You can call this a new paragraph</p></body></html>";
            string TextContent = "This a sample of ntext content";
            string Subject = "My Greating from who cares";
            string ReplyToName = "Johny Ahmad Repl";
            string ReplyToEmail = "treehays90@gmail.com";
            SendSmtpEmailReplyTo ReplyTo = new SendSmtpEmailReplyTo(ReplyToEmail, ReplyToName);
            string AttachmentUrl = null;
            string stringInBase64 = "aGVsbG8gdGhpcyBpcyB0ZXN0";
            byte[] Content = System.Convert.FromBase64String(stringInBase64);
            string AttachmentName = "test.txt";
            SendSmtpEmailAttachment AttachmentContent = new SendSmtpEmailAttachment(AttachmentUrl, Content, AttachmentName);
            List<SendSmtpEmailAttachment> Attachment = new List<SendSmtpEmailAttachment>();
            Attachment.Add(AttachmentContent);
            JObject Headers = new JObject();
            Headers.Add("Some-Custom-Name", "unique-id-1234");
            long? TemplateId = null;
            JObject Params = new JObject();
            Params.Add("parameter", "My param value");
            Params.Add("subject", "New Subject");
            List<string> Tags = new List<string>();
            Tags.Add("mytag");
            SendSmtpEmailTo1 smtpEmailTo1 = new SendSmtpEmailTo1(ToEmail, ToName);
            List<SendSmtpEmailTo1> To1 = new List<SendSmtpEmailTo1>();
            To1.Add(smtpEmailTo1);
            Dictionary<string, object> _parmas = new Dictionary<string, object>();
            _parmas.Add("params", Params);
            SendSmtpEmailReplyTo1 ReplyTo1 = new SendSmtpEmailReplyTo1(ReplyToEmail, ReplyToName);
            SendSmtpEmailMessageVersions messageVersion = new SendSmtpEmailMessageVersions(To1, _parmas, Bcc, Cc, ReplyTo1, Subject);
            List<SendSmtpEmailMessageVersions> messageVersiopns = new List<SendSmtpEmailMessageVersions>();
            messageVersiopns.Add(messageVersion);
            try
            {
                var sendSmtpEmail = new SendSmtpEmail(Email, To, Bcc, Cc, HtmlContent, TextContent, Subject, ReplyTo, Attachment, Headers, TemplateId, Params, messageVersiopns, Tags);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User Update(User user)
        {
            //_context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }


        //    public User UpdateRole(User user)
        //    {
        //        _context.Users.Update(user);
        //        _context.SaveChanges();
        //        return user;
        //    }
        //}
    }
}