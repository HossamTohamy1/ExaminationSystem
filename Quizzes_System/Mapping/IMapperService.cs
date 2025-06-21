namespace Quizzes_System.Mapping
{
    public interface IMapperService
    {
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TDestination>(object source);
        IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source);

        AutoMapper.IConfigurationProvider ConfigurationProvider { get; }
    }
}
