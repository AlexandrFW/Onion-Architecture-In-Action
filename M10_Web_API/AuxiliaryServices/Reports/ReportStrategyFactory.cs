using Domain.Interfaces.Services;

namespace AuxiliaryServices.Reports
{
    public class ReportStrategyFactory : IReportStrategyFactory
    {
        public ReportStrategyFactory()
        {
        }

        public IReportService GetConcreteReportService(string format)
        {
            switch (format.ToLower())
            {
                case "xml":
                    return new XMLReport();

                case "json":
                    return new JSONReport();
            }

            return null;
        }
    }
}