using AutoMapper;
using AutoMapper.Internal;
using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class AutoMapperConfig
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            if (cfg is null)
            {
                throw new ArgumentNullException(nameof(cfg));
            }

            cfg.Internal().ForAllMaps(AutoIgnorePropertiesInternal);

        }

        private static void AutoIgnorePropertiesInternal(TypeMap map, IMappingExpression expression)
        {
            if (typeof(IHaveDateCreated).IsAssignableFrom(map.DestinationType))
            {
                expression.ForMember(nameof(IHaveDateCreated.DateCreated), e => e.Ignore());
            }

            if (typeof(IHaveDateUpdated).IsAssignableFrom(map.DestinationType))
            {
                expression.ForMember(nameof(IHaveDateUpdated.DateUpdated), e => e.Ignore());
            }
        }
    }
}
