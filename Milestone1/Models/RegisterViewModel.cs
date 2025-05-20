using static ServiceStack.LicenseUtils;
using System.ComponentModel.DataAnnotations;

namespace RegisterAndLoginApp.Models
{
    public class GroupViewModel
    {
        public bool IsSelected { get; set; }
        public string GroupName { get; set; }
    }
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Sex { get; set; }

        [Required]
        [Range(1, 120, ErrorMessage = "Please enter a valid age.")]
        public int Age { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 1)]
        public string Username { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 1)]
        public string Password { get; set; }

        public List<GroupViewModel> Groups { get; set; }

        public RegisterViewModel()
        {
            Groups = new List<GroupViewModel>
            {
                new GroupViewModel { GroupName = "Admin", IsSelected = false },
                new GroupViewModel { GroupName = "Users", IsSelected = false },
                new GroupViewModel { GroupName = "Students", IsSelected = false }
            };
        }
    }
}
