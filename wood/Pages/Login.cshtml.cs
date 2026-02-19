using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wood.Pages;

public class LoginModel : PageModel
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;  // Добавляем UserManager
    private readonly ILogger<LoginModel> _logger;

    public LoginModel(
        SignInManager<IdentityUser> signInManager, 
        UserManager<IdentityUser> userManager,  // Добавляем в конструктор
        ILogger<LoginModel> logger)
    {
        _signInManager = signInManager;
        _userManager = userManager;  // Инициализируем
        _logger = logger;
    }

    [BindProperty]
    public InputModel Input { get; set; } = new();

    public class InputModel
    {
        [Required(ErrorMessage = "Email обязателен")]
        [EmailAddress(ErrorMessage = "Некорректный email адрес")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Пароль обязателен")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            // Используем email как имя пользователя для входа
            var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation("Пользователь {Email} вошел в систему.", Input.Email);
                
                // Получаем пользователя
                var user = await _userManager.FindByEmailAsync(Input.Email);
                
                if (user != null)
                {
                    // Проверяем, является ли пользователь администратором
                    var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
                    
                    if (isAdmin)
                    {
                        _logger.LogInformation("Администратор {Email} перенаправлен в админ-панель.", Input.Email);
                        return RedirectToPage("/Admin/Index");  // Редирект в админку
                    }
                }
                
                // Обычный пользователь - на главную
                return RedirectToPage("/Index");
            }
            
            if (result.IsLockedOut)
            {
                _logger.LogWarning("Аккаунт {Email} заблокирован.", Input.Email);
                return RedirectToPage("./Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Неверный email или пароль.");
                return Page();
            }
        }

        return Page();
    }
}