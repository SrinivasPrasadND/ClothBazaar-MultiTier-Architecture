using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
    public class ConfigurationsService
    {
        public Config GetConfig(string key)
        {
            using(var context = new CBContext())
            {
                return context.Configurations.Find(key);
            }
        }
    }
}
