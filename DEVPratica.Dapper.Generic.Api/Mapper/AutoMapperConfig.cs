using AutoMapper;

namespace DEVPratica.Dapper.Generic.Api.Mapper
{
    public class AutoMapperConfig
    {
        protected AutoMapperConfig()
        {
        }

        public static MapperConfiguration RegisterMapper()
        {
            return new MapperConfiguration(cfg => { });
        }
    }
}