﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace zajecia_14
{
    public class RegistrationModelValidator : AbstractValidator<RegistrationModel>
    {
        public RegistrationModelValidator()
        {
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
                //.SetValidator();
            //.WithMessage();

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6)
                .Must(y => !(y == y.ToLower() || y == y.ToUpper()))
                .Matches(@"^(.*[!@#$%^&*].*)+");

            RuleFor(x => x.Accept)
                .Must(x => x) //bo to bool -,-
                .WithMessage("musisz wyrazic zgoden na cokolwiek uslugi");
                
        }
        
    }
}
