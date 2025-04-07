using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidAction.Domain.DomainModels
{
    public class ChangePasswordModel
    {
        public int UserId { get; set; }
        public string UserType { get; set; }
        public string? currentPassword { get; set; }
        public string? newPassword { get; set; }
        public string? confirmPassword { get; set; }
    }
}
