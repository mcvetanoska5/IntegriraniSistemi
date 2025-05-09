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
    public class LectureService : ILectureService
    {
        private readonly IRepository<Lecture> _lectureRepository;

        public LectureService(IRepository<Lecture> lectureRepository)
        {
            _lectureRepository = lectureRepository;
        }
        List<Lecture> ILectureService.GetAll()
        {
            return _lectureRepository.GetAll(selector: x => x).ToList();
        }
        Lecture? ILectureService.GetById(Guid id)
        {
            return _lectureRepository.Get(selector: x => x,
                                          predicate: x => x.Id.Equals(id));
        }
        public Lecture Insert(Lecture product)
        {
            product.Id = Guid.NewGuid();
            return _lectureRepository.Insert(product);
        }
        public Lecture Update(Lecture product)
        {
            return _lectureRepository.Update(product);
        }
        public Lecture DeleteById(Guid id)
        {
            var lecture = GetById(id);
            if (lecture == null)
            {
                throw new Exception("Product not found");
            }
            _lectureRepository.Delete(lecture);
            return lecture;
        }
        private Lecture GetById(Guid id)
        {
            return _lectureRepository.Get(selector: x => x,
                                        predicate: x => x.Id.Equals(id));
        }
    }
}
