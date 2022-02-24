using AuxiliaryServices.Reports;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.ServiceTools;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.BusinessServicesTools
{
    public class ReportService : IReportApiService
    {
        private readonly ILecturesStudentsRepository _lectureStudentsRepository;
        private IReportStrategyFactory _reportServiceFactory;
        private readonly ILogger<ReportService> _logger;        

        public ReportService(ILecturesStudentsRepository lectureStudentsRepository,
                             IReportStrategyFactory reportServiceFactory,
                             ILogger<ReportService> logger)
        {
            _lectureStudentsRepository = lectureStudentsRepository;
            _reportServiceFactory = reportServiceFactory;
            _logger = logger;
        }

        public string GetReport(ReportFilterCriteria reportCreteria)
        {
            var report = _reportServiceFactory.GetConcreteReportService(reportCreteria.Format);

            IEnumerable<LecturesStudents>? reportedCollection = GetCollection(reportCreteria);

            if (reportedCollection is not null && reportedCollection.Any())
                return report.GetReport(reportedCollection);

            return string.Empty;
        }

        private IEnumerable<LecturesStudents>? GetCollection(ReportFilterCriteria reportCreteria)
        {
            IEnumerable<LecturesStudents>? report = null;

            switch (reportCreteria.Criteria.ToLower())
            {
                case "student":
                    report = _lectureStudentsRepository.GetAll()
                                                       .Where(y => y.StudentId == reportCreteria.Id);
                    break;

                case "lecture":
                    report = _lectureStudentsRepository.GetAll()
                                                       .Where(y => y.LectureId == reportCreteria.Id);
                    break;
            }

            return report;
        }
    }
}