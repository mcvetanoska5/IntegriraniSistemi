using CoursesApplication.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Service.Interface
{
    public interface IEnrollmentService
    {
        IEnumerable Students { get; }

        Enrollment EnrollStudentOnCourse(Guid studentId, Guid courseId);
    }
}
