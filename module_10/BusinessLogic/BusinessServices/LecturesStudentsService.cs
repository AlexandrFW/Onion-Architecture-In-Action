using Domain.Interfaces.BusinessLogicServices;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.BusinessServices
{
    internal class LecturesStudentsService : ILecturesStudentsService
    {
        private readonly ILecturesStudentsRepository _lectureStudentsRepository;
        private readonly ILectorsRepository _lectorRepository;
        private readonly ILecturesRepository _lectureRepository;
        private readonly IStudentsRepository _studentsRepository;
        private readonly IEmailService _emailService;
        private readonly ISMSService _smsService;
        private readonly ILogger<LecturesStudentsService> _logger;

        public LecturesStudentsService(ILecturesStudentsRepository lectureStudentsRepository,
                                       ILecturesRepository lectureRepository,
                                       ILectorsRepository lectorRepository,
                                       IStudentsRepository studentsRepository,
                                       IEmailService emailService,
                                       ISMSService smsService,
                                       ILogger<LecturesStudentsService> logger)
        {
            _lectureStudentsRepository = lectureStudentsRepository;
            _lectureRepository = lectureRepository;
            _lectorRepository = lectorRepository;
            _studentsRepository = studentsRepository;
            _emailService = emailService;
            _smsService = smsService;
            _logger = logger;
        }

        public void Delete(string id)
        {
            _lectureStudentsRepository.Delete(id);
        }

        public string Edit(string id, LecturesStudents lecturseStudents)
        {
            _lectureStudentsRepository.Edit(id, lecturseStudents);

            CheckIfSendNotificationsNeeded(lecturseStudents);

            return $"{lecturseStudents.LectureId}_{lecturseStudents.StudentId}";
        }

        public LecturesStudents? Get(string id)
        {
            return _lectureStudentsRepository.Get(id);
        }

        public IReadOnlyCollection<LecturesStudents> GetAll()
        {
            return _lectureStudentsRepository.GetAll().ToArray();
        }

        public string New(LecturesStudents lecturseStudents)
        {
            string newId = _lectureStudentsRepository.New(lecturseStudents);

            CheckIfSendNotificationsNeeded(lecturseStudents);

            return newId;
        }

        private void CheckIfSendNotificationsNeeded(LecturesStudents lecturseStudents)
        {
            var student = _studentsRepository.Get(lecturseStudents.StudentId);
            var lecture = _lectureRepository.Get(lecturseStudents.LectureId);

            // Check if student is attendend and send email if not
            var missedLecturesCount = _lectureStudentsRepository.GetAll()
                                                                .Where(x => x.IsStudentAttended == false)
                                                                .Where(y => y.StudentId == lecturseStudents.StudentId)
                                                                .Where(z => z.LectureId == lecturseStudents.LectureId)
                                                                .Count();

            if (missedLecturesCount > 3)
            {
                Lector? lector = null;

                string sSubjectNotification = "";

                // Sending notification email to student 
                if (student is not null && lecture is not null)
                {
                    string lectureName = (lecture is not null ? lecture.LectureName : "");
                    sSubjectNotification = $"[Notification] Student { student.Name } missed more than 3 letures";


                    _logger.LogInformation($"Send missed lectures email to student Id = { student.Id }");
                    _emailService.SendEmailAsync(student.Email,
                                                 sSubjectNotification,
                                                 $"You missed more than 3 { lectureName } lecture");
                }

                // Sending notification email to student 
                if (lecture is not null)
                {
                    lector = _lectorRepository.Get(lecture.LectorId);
                    if (lector is not null)
                    {
                        sSubjectNotification = $"[Notification] Student { (student is not null ? student.Name : "") } missed more than 3 letures";

                        _logger.LogInformation($"Send missed lectures email to lector Id = { lector.Id }");
                        _emailService.SendEmailAsync(lector.Email,
                                                     sSubjectNotification,
                                                     $"The student { (student is not null ? student.Name : "") } missed more than 3 { lecture.LectureName } lecture");
                    }

                }
            }

            // Send the SMS to the student
            var averageGradeOfLecturesLessThan_4 = _lectureStudentsRepository.GetAll()
                                                                    .Where(y => y.StudentId == lecturseStudents.StudentId)
                                                                    .Where(z => z.LectureId == lecturseStudents.LectureId)
                                                                    .Average(x => x.Grade);
            if (averageGradeOfLecturesLessThan_4 < 4)
            {
                if (student is not null && lecture is not null)
                {
                    _logger.LogInformation($"Try to send SMS for student {student.Id}");
                    _smsService.SendSMS($"Your average grade of lecture {lecture.LectureName} less then 4", student.Phone);
                }
                else
                    _logger.LogWarning($"Student of Lecture not found");
            }

        }
    }
}