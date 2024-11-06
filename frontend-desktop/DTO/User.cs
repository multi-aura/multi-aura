using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User
    {
        public string Token { get; set; }
        public string UserID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Nation { get; set; }
        public string Province { get; set; }
        public string Avatar { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublic { get; set; }

        public Dictionary<string, object> ToDictionary()
        {
            return new Dictionary<string, object>
            {
                { "userID", UserID },
                { "fullname", FullName },
                { "username", Username },
                { "email", Email },
                { "password", Password },
                { "phone", PhoneNumber },
                { "birthday", Birthday.ToString("yyyy-MM-dd") },
                { "gender", Gender },
                { "nation", Nation },
                { "province", Province },
                { "avatar", Avatar },
                { "isAdmin", IsAdmin },
                { "isActive", IsActive },
                { "isPublic", IsPublic }
            };
        }

        public static User FromDictionary(Dictionary<string, object> data)
        {
            return new User
            {
                UserID = data.ContainsKey("userID") ? data["userID"] as string : string.Empty,
                FullName = data.ContainsKey("fullname") ? data["fullname"] as string : string.Empty,
                Username = data.ContainsKey("username") ? data["username"] as string : string.Empty,
                Email = data.ContainsKey("email") ? data["email"] as string : string.Empty,
                Password = data.ContainsKey("password") ? data["password"] as string : string.Empty,
                PhoneNumber = data.ContainsKey("phone") ? data["phone"] as string : string.Empty,
                Birthday = data.ContainsKey("birthday") && DateTime.TryParse(data["birthday"] as string, out DateTime birthday)
                    ? birthday
                    : DateTime.Now,
                Gender = data.ContainsKey("gender") ? data["gender"] as string : string.Empty,
                Nation = data.ContainsKey("nation") ? data["nation"] as string : string.Empty,
                Province = data.ContainsKey("province") ? data["province"] as string : string.Empty,
                Avatar = data.ContainsKey("avatar") ? data["avatar"] as string : string.Empty,
                IsAdmin = data.ContainsKey("isAdmin") && bool.TryParse(data["isAdmin"].ToString(), out bool isAdmin) ? isAdmin : false,
                IsActive = data.ContainsKey("isActive") && bool.TryParse(data["isActive"].ToString(), out bool isActive) ? isActive : false,
                IsPublic = data.ContainsKey("isPublic") && bool.TryParse(data["isPublic"].ToString(), out bool isPublic) ? isPublic : false,
            };
        }
    }

    public class RegisterRequest
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(3)]
        public string Password { get; set; }

        [Required, Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Birthday { get; set; }

        [Required]
        public string Gender { get; set; }

        public string Nation { get; set; }
        public string Province { get; set; }
    }

    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required, MinLength(3)]
        public string Password { get; set; }
    }
}
