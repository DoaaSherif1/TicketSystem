using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BL.DTOs.Login
{
    public class RegisterResult
    {
        public RegisterResult(bool isSuccess, IEnumerable<IdentityError>? errors = null)
        {
            IsSuccess = isSuccess;
            Errors = errors;
        }

        public bool IsSuccess { get; set; }
        public IEnumerable<IdentityError>? Errors { get; set; }
    }
}
