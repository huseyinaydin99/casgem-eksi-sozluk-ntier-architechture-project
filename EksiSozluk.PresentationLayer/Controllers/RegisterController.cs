using AutoMapper;
using EksiSozluk.EntityLayer.Concrete;
using EksiSozluk.PresentationLayer.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EksiSozluk.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            Random rnd = new Random();
            int x = rnd.Next(100000, 1000000);
            var appUser = _mapper.Map<AppUser>(model);
            appUser.ConfirmCode = x;
            if (model.Password == model.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    SendEmail(model, x);

                    TempData["Username"] = appUser.UserName;
                    TempData["code"] = appUser.ConfirmCode;
                    //TempData["User"] = appUser;

                    return Redirect("/MailConfirm/Index");
                }
                else
                    foreach (var item in result.Errors)
                        ModelState.AddModelError("", item.Description);
            }
            else
            {
                ModelState.AddModelError("", "Şifreler eşleşmiyor.");
            }
            return View();
        }
        private void SendEmail(RegisterViewModel registerViewModel, int x)
        {
            #region
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddress = new MailboxAddress("Admin", "huseyinaydin99@gmail.com");
            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", registerViewModel.Email);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Giriş için onay kodunuz: " + x.ToString();
            mimeMessage.Body = bodyBuilder.ToMessageBody();
            mimeMessage.Subject = "Doğrulama kodu";

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("huseyinaydin99@gmail.com", "tcizvcpzzcpfxxoy");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            #endregion
        }
    }
}
