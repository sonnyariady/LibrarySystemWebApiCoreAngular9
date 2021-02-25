using PerpustakaanAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerpustakaanAPI.ViewModels
{
    public class LoginResultModel
    {
        public bool IsSuccess { get; set; }

        public string ErrorMessage { get; set; }

        public Petugas UserDetail { get; set; }

        public LoginResultModel()
        {
            this.IsSuccess = true;
            this.ErrorMessage = string.Empty;
        }
    }
}
