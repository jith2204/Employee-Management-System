using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.ICustomAuthorization
{
    public interface IAuthorizationFilter
    {
        void OnAuthorization(AuthorizationFilterContext context);
    }
}
