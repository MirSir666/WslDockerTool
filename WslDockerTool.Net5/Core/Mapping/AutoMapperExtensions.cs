using AutoMapper;
using AutoMapper.Configuration;
using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WslDockerTool.Net5.Core.Mapping
{
	public static class AutoMapperExtensions
	{
		public static IContainer RegisterAutoMapper(this IContainer container)
		{
            var mce = new MapperConfigurationExpression();
            mce.ConstructServicesUsing(container.GetService);

            mce.AddMaps(typeof(MappingProfile).Assembly);

            var mc = new MapperConfiguration(mce);
            //mc.AssertConfigurationIsValid();
            container.RegisterInstance(typeof(IMapper), new Mapper(mc, t => container.GetService(t)));
            return container;
		}

    

    }
}
