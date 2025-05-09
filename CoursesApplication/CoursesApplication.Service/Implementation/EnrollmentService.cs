using CoursesApplication.Domain.Models;
using CoursesApplication.Repository.Interface;
using CoursesApplication.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace CoursesApplication.Service.Implementation
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IRepository<Enrollment> _enrollmentRepository;

        public EnrollmentService(IRepository<Enrollment> enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public IEnumerable Students => (IEnumerable)_enrollmentRepository.Get(selector: x => x,
                                                       predicate: x => x.CourseId.Equals(Students.ToString()));

        public Enrollment EnrollStudentOnCourse(Guid studentId, Guid courseId)
        {
            throw new NotImplementedException();
        }
    }
}
