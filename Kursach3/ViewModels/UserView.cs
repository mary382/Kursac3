using Kursach3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kursach3.ViewModels
{
    public class UserView
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public Creative[] Creatives { get; set; }
    }
}