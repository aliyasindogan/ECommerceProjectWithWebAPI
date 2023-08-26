using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Security.Claims;
namespace Core.Aspects.Autofac.SecuredOperation
{
    public class SecuredOperationAspect : MethodInterception
    {
        private readonly string[] _attributeRoles;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SecuredOperationAspect(string attributeRoles = null)
        {
            if (attributeRoles != null)
                _attributeRoles = attributeRoles.Split(',');
            _httpContextAccessor = (IHttpContextAccessor)Utilities.Helpers.HttpContext.Current.RequestServices.GetService(typeof(IHttpContextAccessor));
        }

        protected override void OnBefore(IInvocation invocation)
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
                if (_attributeRoles != null)
                {
                    if (userId != Constants.SystemAdminID)
                    {
                        if (roleClaims.Count <= 0)
                            throw new System.Exception("Bu kullanıcıya rol eklenmemiş!");

                        foreach (var role in _attributeRoles)
                        {
                            string roleName = role;
                            string[] roleAttribute = roleName.Split('.');
                            string roleClaim = "";
                            for (int i = 0; i < roleClaims.Count; i++)
                            {
                                var data = roleClaims[i].Split('.');
                                if (data[0] == roleAttribute[0])
                                {
                                    roleClaim = roleClaims[i].ToString();
                                    break;
                                }
                            }
                            if (!String.IsNullOrEmpty(roleClaim))
                            {           //CRUD  
                                //AppUser.1011
                                var parseRoleClaim = roleClaim.Split('.');
                                string operation = roleAttribute[1];
                                if (operation == "Add" && parseRoleClaim[1].Substring(0, 1) == "1")
                                    return;
                                if (operation == "List" && parseRoleClaim[1].Substring(1, 1) == "1")
                                    return;
                                if (operation == "Update" && parseRoleClaim[1].Substring(2, 1) == "1")
                                    return;
                                if (operation == "Delete" && parseRoleClaim[1].Substring(3, 1) == "1")
                                    return;
                            }
                            else
                            {
                                throw new System.Exception("");
                            }
                        }
                        throw new System.Exception("Yetkiniz Yok");
                    }
                    else
                    {
                        return; //SystemAdmin tüm sayfalarda yetkilidir.
                    }
                }
                else
                {
                    return;//Boş geçilen SecuredOperationAspect'te tüm kullanıcı tipleri yetkilidir. Örnek:   [SecuredOperationAspect()]
                }
            }
            else
            {
                throw new System.Exception("");
            }
            throw new System.Exception("");
        }
    }
}