using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Transaction.Core.Domain;
using Transaction.WebApi.Models;

namespace Transaction.WebApi.Mappers
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<TransactionModel, AccountTransaction>()
                .AfterMap<SetIdentityAction>()
                .ForAllMembers(opts => opts.Ignore());
        }
    }
}
