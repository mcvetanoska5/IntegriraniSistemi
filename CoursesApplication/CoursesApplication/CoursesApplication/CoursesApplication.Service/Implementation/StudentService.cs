using CoursesApplication.Domain.Models;
using CoursesApplication.Repository.Interface;
using CoursesApplication.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesApplication.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public Student DeleteById(Guid id)
        {
            var product = GetById(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            _studentRepository.Delete(product);
            return product;
        }
        public List<Student> GetAll()
        {
            return _studentRepository.GetAll(selector: x => x).ToList();
        }
        public Student? GetById(Guid id)
        {
            return _studentRepository.Get(selector: x => x,
                                          predicate: x => x.Id.Equals(id));
        }
        public Student Insert(Student product)
        {
            product.Id = Guid.NewGuid();
            return _studentRepository.Insert(product);
        }
        public Student Update(Student product)
        {
            return _studentRepository.Update(product);
        }
    }
}
