using Grupo14_ONG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grupo14_ONG.Models.mailService
{
    public class sendMailModel
    {
        public string email { get; set; }
        public string content { get; set; }
        public string subject { get; set; }


        public sendMailModel(ContactViewModel contactForm)
        {
            this.email = contactForm.Email;
            this.content = contactForm.Text;
            this.subject = contactForm.Subject;
        }

    }
}