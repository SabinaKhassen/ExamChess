using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public static class AutoMapper<Source, Destination>
    {
        public static Destination Map(Source item)
        {
            if (typeof(Source).GetGenericArguments().Length > 0)
            {
                Type x = typeof(Source).GetGenericArguments()[0];
                Type y = typeof(Destination).GetGenericArguments()[0];
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap(x, y)).CreateMapper();
                return mapper.Map<Source, Destination>(item);
            }
            else
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Source, Destination>()).CreateMapper();
                return mapper.Map<Source, Destination>(item);
            }
        }
    }
}
