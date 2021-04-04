using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISDb.Application.Util
{
    public static class MappingConfig
    {
        private static IMapper _mapper { get; set; }

        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    MapperConfiguration config = new MapperConfiguration(mc =>
                    {
                        mc.AddProfile(new UserModelProfile());
                    });

                    _mapper = config.CreateMapper();
                }

                return _mapper;
            }
        }
    }
}
