using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class LoginModel
    {
        private string name;
        private string password;

        [Required(ErrorMessage = "Name or email can't be empty")]
        public string Name
        {
            get { return name; }
            set { name = value?.Trim(); }
        }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Minimum length - 4 characters")]
        public string Password
        {
            get { return password; }
            set { password = value?.Trim(); }
        }
    }
}
