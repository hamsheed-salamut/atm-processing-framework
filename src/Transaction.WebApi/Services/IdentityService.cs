using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Transaction.WebApi.Models;

namespace Transaction.WebApi.Services
{
    public class IdentityService : IIdentityService
    {
        private IHttpContextAccessor _context;

        public IdentityService(IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IdentityModel GetIdentity()
        {
            string authorizationHeader = _context.HttpContext.Request.Headers["Authorization"];

            if (authorizationHeader != null)
            {
                var tokenHander = new JwtSecurityTokenHandler();
                var token = authorizationHeader.Split(" ")[1];
                var parsedToken = tokenHander.ReadJwtToken(token);

                var account = parsedToken.Claims
                    .Where(c => c.Type == "accountnumber")
                    .FirstOrDefault();

                var name = parsedToken.Claims
                    .Where(c => c.Type == "name")
                    .FirstOrDefault();

                var currency = parsedToken.Claims
                    .Where(c => c.Type == "currency")
                    .FirstOrDefault();

                return new IdentityModel()
                {
                    AccountNumber = Convert.ToInt32(account.Value),
                    FullName = name.Value,
                    Currency = currency.Value
                };
            }

            throw new ArgumentNullException("accountNumber");
        }
    }
}
