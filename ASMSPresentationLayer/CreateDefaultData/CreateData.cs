using ASMSEntityLayer.Enums;
using ASMSEntityLayer.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASMSPresentationLayer.CreateDefaultData
{
    public class CreateData
    {
        public static void Create(RoleManager<AppRole>roleManager)
        {
            CheckAndCreateRoles(roleManager);
        }

        private static void CheckAndCreateRoles(RoleManager<AppRole> roleManager)
        {
            var allRoles = Enum.GetNames(typeof(ASMSRoles));
            foreach (var item in allRoles)
            {
                if (!roleManager.RoleExistsAsync(item).Result)
                {
                    AppRole role = new AppRole()
                    {
                        Name = item,
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        Description = $"Sistem tarafınfan {item} rolü eklendi"
                    };
                  var result=roleManager.CreateAsync(role).Result;
                }
            }

        }
    }
}
