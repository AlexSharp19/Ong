using Grupo14_ONG_DA.ModelsEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }
        public UserViewModel(User u)
        {
            this.Id = u.Id;
            this.Name = u.Name;
            this.LastName = u.LastName;
            this.Email = u.Email;
            this.IsActive = u.IsActive;
        }


        public UserViewModel()
        {

        }

        public User ToEntity()
        {
            var user = new User();
            user.Id = Id;
            user.Name = Name;
            user.Email = Email;
            user.IsActive = IsActive;
            user.LastName = LastName;

            return user;
        }

    }
}