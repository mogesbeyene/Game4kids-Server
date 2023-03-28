using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Games4Kids
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public int UserRole { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
        public string Password { get; set; }
        public string ParentPin { get; set; }
        public string? JwtToken { get; set; }


        public UserViewModel()
        {
        }


        public UserViewModel(User user)
        {
            UserID = user.UserId;
            UserRole = user.UserRole;
            Username = user.Nickname;
            Email = user.Email;
            CreationDate = user.CreationDate;
            Password = user.Password;
            ParentPin = user.ParentPin;
        }


        public User ConvertToUser(UserViewModel userViewModel)
        {
            return new User
            {
                UserId = userViewModel.UserID,
                UserRole = userViewModel.UserRole,
                Nickname = userViewModel.Username,
                Email = userViewModel.Email,
                CreationDate = userViewModel.CreationDate,
                Password = userViewModel.Password,
                ParentPin = userViewModel.ParentPin
            };
        }



    }
}
