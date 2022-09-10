﻿using Core.Utilities.Responses;
using Entities.Dtos.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIWithCoreMvc.ApiServices.Interfaces
{
    public interface IUserApiService
    {
        Task<ApiDataResponse<List<AppUserDetailDto>>> GetListAsync();
    }
}