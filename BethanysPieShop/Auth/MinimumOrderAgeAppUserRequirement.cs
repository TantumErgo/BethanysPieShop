using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Auth
{
    public class MinimumOrderAgeAppUserRequirement : IAuthorizationRequirement
    {
        public int MinimumOrderAge;

        public MinimumOrderAgeAppUserRequirement(int minimumOrderAge)
        {
            MinimumOrderAge = minimumOrderAge;
        }
    }
}
