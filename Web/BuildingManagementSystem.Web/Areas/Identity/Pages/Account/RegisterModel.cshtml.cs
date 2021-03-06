namespace BuildingManagementSystem.Web.Areas.Identity.Pages.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using BuildingManagementSystem.Data.Models;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Extensions.Logging;

    using static BuildingManagementSystem.Common.GlobalConstants;

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<RegisterModel> logger;
        private readonly IEmailSender emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашето име")]
            [StringLength(50, ErrorMessage = FirstNameErrorMessage, MinimumLength = 3)]
            [Display(Name = "Име")]
            public string FirstName { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашата фамилия")]
            [StringLength(50, ErrorMessage = LasttNameErrorMessage, MinimumLength = 5)]
            [Display(Name = "Фамилия")]
            public string LastName { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашият email адрес")]
            [EmailAddress(ErrorMessage = EmailErrorMessage)]
            [Display(Name = "Е-мейл")]
            public string Email { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете вашият телефонен номер")]
            [Phone]
            [RegularExpression(@"^[+]{1}[3][5][9][0-9]{9}$", ErrorMessage = PhoneNumberErrorMessage)]
            [Display(Name = "Мобилен телефонен номер")]
            public string PhoneNumber { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Моля въведете парола")]
            [StringLength(100, ErrorMessage = PasswordErrorMessage, MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Парола")]
            public string Password { get; set; }

            [Required(AllowEmptyStrings = false, ErrorMessage = "Моля повторете паролата")]
            [DataType(DataType.Password)]
            [Display(Name = "Повторете паролата")]
            [Compare("Password", ErrorMessage = ConfirmPasswordErrorMessage)]
            public string ConfirmPassword { get; set; }

            public bool IsRegisterConfirmed { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            this.ReturnUrl = returnUrl;
            this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= this.Url.Content("~/Home/Info"); // was, and redirected to the Landing page

            // returnUrl ??= this.Url.Content("~/Registrations/Index");
            this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (this.ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = this.Input.Email,
                    Email = this.Input.Email,
                    PhoneNumber = this.Input.PhoneNumber,
                    FirstName = this.Input.FirstName,
                    LastName = this.Input.LastName,
                    IsRegisterConfirmed = this.Input.IsRegisterConfirmed,
                };
                var result = await this.userManager.CreateAsync(user, this.Input.Password);
                if (result.Succeeded)
                {
                    this.logger.LogInformation("Потребителят създаде нов акаунт с парола.");

                    var code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = this.Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: this.Request.Scheme);

                    await this.emailSender.SendEmailAsync(this.Input.Email, "Потвърдете имейла си", $"Моля, потвърдете акаунта си, като <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>натиснете тук</a>.");

                    if (this.userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return this.RedirectToPage("RegisterConfirmation", new { email = this.Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await this.signInManager.SignInAsync(user, isPersistent: false);
                        return this.LocalRedirect(returnUrl);
                    }
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return this.Page();
        }
    }
}
