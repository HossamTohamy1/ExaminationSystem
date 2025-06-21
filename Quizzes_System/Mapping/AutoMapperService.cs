using AutoMapper.QueryableExtensions;
using AutoMapper;
using Quizzes_System.Mapping;

public class AutoMapperService : IMapperService
{
    private readonly IMapper _mapper;

    public AutoMapperService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public AutoMapper.IConfigurationProvider ConfigurationProvider => _mapper.ConfigurationProvider;

    public IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source)
    {
        return source.ProjectTo<TDestination>(_mapper.ConfigurationProvider);
    }

    public TDestination Map<TDestination>(object source)
    {
        return _mapper.Map<TDestination>(source);
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        return _mapper.Map<TDestination>(source);
    }
}
