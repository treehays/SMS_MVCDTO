using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models;
using SMS_MVCDTO.Models.DTOs.UserDTOs;
using System.Diagnostics;
using System.Security.Claims;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;


namespace SMS_MVCDTO.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _user;
        private readonly IConfiguration _config;
        public HomeController(IUserService user, ILogger<HomeController> logger, IConfiguration config)
        {
            _user = user;
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            //ViewBag.ShowElement1 = true;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public IActionResult Signup()
        {

            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgotPassword(LoginRequestModel loginDetails)
        {
            //loginDetails.PasswordToken = Guid.NewGuid().ToString().Replace('-', 'c');
            //var urlToken = $"/Home/ResetPassword/{loginDetails.PasswordToken}";
            //loginDetails.Password = $"{Request.Scheme}://{Request.Host}{urlToken}";
            ////var url = $"{Request.Scheme}://{Request.Host}{urlToken}";
            //var userExit = _user.GetById(loginDetails.StaffId);
            //if (userExit == null)
            //{
            //    return NotFound();
            //}
            //_user.ForgotPassword(loginDetails);
            //ViewBag.Message = "Reset password link has been sent to your email id.";

            Configuration.Default.ApiKey.Clear();
            Configuration.Default.ApiKey.Add("api-key", "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");

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
                //Debug.WriteLine(result.ToJson());
                //Console.WriteLine(result.ToJson());
                //Console.ReadLine();
            }
            catch (Exception)
            {
                //Debug.WriteLine(e.Message);
                //Console.WriteLine(e.Message);
                //Console.ReadLine();
            }


            /*
             * var con = _config.GetConnectionString("EmailKey");
            Configuration.Default.ApiKey.Clear();
            Configuration.Default.ApiKey.Add("api-key", "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");

            var apiInstance = new TransactionalEmailsApi();
            var SenderName = "Abdulsalam Ahmad";
            var SenderEmail = "treehays90@gmail.com";
            SendSmtpEmailSender Email = new SendSmtpEmailSender(SenderName, SenderEmail);

            var ToEmail = "aymoneyay@gmail.com";
            var ToName = "Abdulsalam Ahmad Ayoola";
            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(ToEmail, ToName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);

            var BccName = "Akinkunmi Alabi";
            var BccEmail = "abdulsalamayoola@gmail.com";
            SendSmtpEmailBcc BccData = new SendSmtpEmailBcc(BccEmail, BccName);
            List<SendSmtpEmailBcc> Bcc = new List<SendSmtpEmailBcc>();
            Bcc.Add(BccData);

            var CcName = "Akeye Walli";
            var CcEmail = "treehays90@yahoo.com";
            SendSmtpEmailCc CcData = new SendSmtpEmailCc(CcEmail, CcName);
            List<SendSmtpEmailCc> Cc = new List<SendSmtpEmailCc>();
            Cc.Add(CcData);

            var HtmlContent = "<html><body> <h4>HELP SPREAD THE EMAIL</h4> <h1> All from AHmad This is my first transactional email </h1></body></html>";
            var TextContent = "All from and this is text content";
            var Subject = "My Testing Mail";
            var ReplyToName = "Reply Ahmad Doe";
            var ReplyToEmail = "treehays90@gmail.com";
            SendSmtpEmailReplyTo ReplyTo = new SendSmtpEmailReplyTo(ReplyToEmail, ReplyToName);

            //string AttachmentUrl = null;
            //var stringInBase64 = "aGVsbG8gdGhpcyBpcyB0ZXN0";
            //byte[] Content = System.Convert.FromBase64String(stringInBase64);
            //var AttachmentName = "test.txt";
            //SendSmtpEmailAttachment AttachmentContent = new SendSmtpEmailAttachment(AttachmentUrl, Content, AttachmentName);
            //List<SendSmtpEmailAttachment> Attachment = new List<SendSmtpEmailAttachment>();
            //Attachment.Add(AttachmentContent);

            JObject Headers = new JObject();
            Headers.Add("Some-Custom-Name", "unique-id-1234");
            long? TemplateId = null;
            JObject Params = new JObject();
            Params.Add("parameter", "My param value");
            Params.Add("subject", "New Subject");
            List<string> Tags = new List<string>();
            Tags.Add("mytag");
            SendSmtpEmailTo1 smtpEmailTo1 = new SendSmtpEmailTo1("aymoneyay@gmail.com", "Testing from my side");
            List<SendSmtpEmailTo1> To1 = new List<SendSmtpEmailTo1>();
            To1.Add(smtpEmailTo1);

            Dictionary<string, object> _parmas = new Dictionary<string, object>();
            _parmas.Add("params", Params);
            SendSmtpEmailReplyTo1 ReplyTo1 = new SendSmtpEmailReplyTo1(ReplyToEmail, ReplyToName);
            //SendSmtpEmailMessageVersions messageVersion = new SendSmtpEmailMessageVersions(To1, _parmas, Bcc, Cc, ReplyTo1, Subject);
            SendSmtpEmailMessageVersions messageVersion = new SendSmtpEmailMessageVersions
            {
                //(To1, _parmas, Bcc, Cc, ReplyTo1, Subject);
                To = To1,
                Params = _parmas,
                Bcc = Bcc,
                Cc = Cc,
                ReplyTo = ReplyTo1,
                Subject = Subject,
            };
            List<SendSmtpEmailMessageVersions> messageVersiopns = new List<SendSmtpEmailMessageVersions>();
            messageVersiopns.Add(messageVersion);
            try
            {
                var sendSmtpEmail = new SendSmtpEmail
                {
                    Sender = Email,
                    To = To,
                    Bcc = Bcc,
                    Cc = Cc,
                    HtmlContent = HtmlContent,
                    TextContent = TextContent,
                    Subject = Subject,
                    ReplyTo = ReplyTo,
                    //Attachment = Attachment,
                    Headers = Headers,
                    TemplateId = TemplateId,
                    Params = Params,
                    MessageVersions = messageVersiopns,
                    Tags = Tags,
                    //ScheduledAt = scheduledAt,
                    //BatchId = batchId,

                };///(Email, To, Bcc, Cc, HtmlContent, TextContent, Subject, ReplyTo, Attachment, Headers, TemplateId, Params, messageVersiopns, Tags);
                CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);
                //Configuration.Default.ApiKey.Clear();
                //Debug.WriteLine(result.ToJson());
                //Console.WriteLine(result.ToJson());
                //Console.ReadLine();
            }
            catch (Exception)
            {
                return View();
                //Debug.WriteLine(e.Message);
                //Console.WriteLine(e.Message);
                //Console.ReadLine();
            }
            */

            return View();
        }


        //var url = $"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}";

        //var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, urlToken);


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginRequestModel loginDetails)
        {
            /**********************************************/
            //checking if the l=TagHelperServicesExtensions details is null
            if (loginDetails == null)
            {
                TempData["failed"] = "Login Failed...";
                return View();
            }


            var user = _user.Login(loginDetails);

            if (user == null)
            {
                TempData["failed"] = "Login Failed...";
                return View();
            }
            byte[] imageData = user.Data.ProfilePicture;

            /*
                        ViewBag.Image = "data:image/jpeg;base64," + Convert.ToBase64String(imageData);
                        ViewData["ImageData"] = imageData;
            */



            var roles = new List<string>();
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, user.Data.RoleId.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Data.StaffId),
                    new Claim(ClaimTypes.Name, user.Data.Name),
                    new Claim(ClaimTypes.Email, user.Data.Email),
                    new Claim(ClaimTypes.PrimarySid, user.Data.Id.ToString()),
                };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authenticationProperties = new AuthenticationProperties();
            var principal = new ClaimsPrincipal(claimIdentity);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);

            if (user.Data.RoleId == 3)
            {
                // ViewBag.ShowElement1 = true;
                TempData["success"] = "Login successful";
                return RedirectToAction(nameof(Index), "Attendant");

            }
            else if (user.Data.RoleId == 1)
            {
                // ViewBag.ShowElement1 = true;
                TempData["success"] = "Login successful";
                return RedirectToAction(nameof(Index), "SuperAdmin");

            }
            else if (user.Data.RoleId == 4)
            {
                // ViewBag.ShowElement1 = true;
                TempData["success"] = "Login successful";
                return RedirectToAction(nameof(Index), "Customer");

            }
            else if (user.Data.RoleId == 2)
            {
                // ViewBag.ShowElement1 = true;
                TempData["success"] = "Login successful";
                return RedirectToAction(nameof(Index), "SalesManager");

            }
            else
            {
                // ViewBag.ShowElement1 = true;
                TempData["success"] = "Your Account has not been activated.";
                return RedirectToAction(nameof(Index), "Home");

            }


        }
        public IActionResult Logout()
        {
            //HttpContext.Session.Clear();
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

    }
}