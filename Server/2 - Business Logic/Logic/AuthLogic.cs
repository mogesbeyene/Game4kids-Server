
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Games4Kids
{
    public class AuthLogic : BaseLogic
    {

        public AuthLogic(Games4KidsContext db) : base(db)
        {
        } 

        
        public bool IsUsernameExists(string username)
        {
            return DB.Users.Any(u => u.Nickname == username);
        }


        public UserViewModel Register(UserViewModel user)
        {
            User userDB = user.ConvertToUser(user);
            
            DB.Users.Add(userDB);
            DB.SaveChanges();

            return new UserViewModel(userDB);    
        }

        public UserViewModel GetUserByCredentials(CredentialViewModel credentials)
        {
            UserViewModel user = DB.Users.Where(u => u.Nickname == credentials.Username && u.Password == credentials.Password)
                .Select(u => new UserViewModel(u)).SingleOrDefault();
            return user;
        }

    }
}
