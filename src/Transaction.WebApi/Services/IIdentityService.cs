﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transaction.WebApi.Models;

namespace Transaction.WebApi.Services
{
    public interface IIdentityService
    {
        IdentityModel GetIdentity();
    }
}
