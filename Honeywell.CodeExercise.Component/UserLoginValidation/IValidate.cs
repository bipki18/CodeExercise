using System;
using System.Collections.Generic;
using System.Text;

namespace Honeywell.CodeExercise.Component.UserLoginValidation
{
    public interface IValidate
    {
        string GenerateJWTToken(string userid, string password);
        string ReadJWTToken(string tokenString);
    }
}
