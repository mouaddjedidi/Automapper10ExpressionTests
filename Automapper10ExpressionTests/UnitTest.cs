using AutoMapper;
using AutoMapper.EquivalencyExpression;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq.Expressions;
using Xunit;

namespace Automapper10ExpressionTests
{
    public class UserEntityDto : EntityDtoBase<UserEntityDto> { }
    public class UserPersistenceDto : PersistenceDtoBase<UserPersistenceDto> { }

    public class UserProfile : Profile
    {
        public UserProfile() { CreateMap<UserEntityDto, UserPersistenceDto>().ReverseMap(); }
    }

    public class UnitTest
    {
        private readonly IMapper _mapper;

        public UnitTest()
        {
            var sp = CreateServices();
            _mapper = sp.GetRequiredService<IMapper>();
        }

        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddAutoMapper(cfg =>
                {
                    cfg.AddExpressionMapping();
                    cfg.AddCollectionMappers();
                    cfg.ForAllMaps((map, exp) => exp.MaxDepth(1));
                    cfg.AllowNullCollections = true;
                    cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                }, typeof(UnitTest).Assembly)
                .BuildServiceProvider(false);
        }

        [Fact]
        public void Should_Map_Expression()
        {
            Expression<Func<UserEntityDto, bool>> searchExpression = u => u.Id == 1;
            var searchExpressionMapped = _mapper.Map<Expression<Func<UserPersistenceDto, bool>>>(searchExpression);

            Assert.NotNull(searchExpressionMapped);
        }
    }
}
