namespace Domain.Interfaces.Services
{
    public interface IReportStrategyFactory
    {
        IReportService GetConcreteReportService(string format);
    }
}