using Microsoft.EntityFrameworkCore;
using Serilog;
using Parsyn.Apps.Company.Data.Contexts;
using Parsyn.Apps.Company.Data.Models.Entity.Reactions;
using Parsyn.Apps.Company.Service.Utiles.Generators.ResponseGenerator.MapperObjects;
using Parsyn.Apps.Company.Services.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Parsyn.Apps.Company.Services.Interfaces
{
    public class SubscribeService(PDBContext ctx, ILogger log) : BaseService<SubscribeModel>(ctx, log), ISubscribeIface
    {
        public async Task<ResponseObject> Subscribe(string email)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email) || !MailAddress.TryCreate(email, out _))
                return _rsp.MapError("Please enter a valid email address. [youraddress@yourdomain.com]");
            if (await _dbObj.AnyAsync(x => x.Email == email))
                return _rsp.MapError("Email address already exists.");

            await _dbObj.AddAsync(new SubscribeModel { Email = email });
            await _ctx.SaveChangesAsync();
            return _rsp.MapOk("Thank you for subscription.");
        }
    }
}
