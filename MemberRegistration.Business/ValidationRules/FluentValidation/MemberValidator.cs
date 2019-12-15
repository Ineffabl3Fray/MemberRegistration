using FluentValidation;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Business.ValidationRules.FluentValidation
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.DateOfBirth).NotEmpty();
            RuleFor(c => c.DateOfBirth).LessThan(DateTime.Now);
            RuleFor(c => c.TcNo).NotEmpty();
            RuleFor(c => c.TcNo).Length(11);
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Email).EmailAddress();
        }
    }
}
