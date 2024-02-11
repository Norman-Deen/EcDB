using EcDB.Data;
using EcDB.Entities;
using EcDB.IRepository;
using EcDB.Repository;
using EcDB.Services.SubServices;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;

namespace EcDB.Services
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


        public bool GetAll()
        {
            return _courseRepository.GetAll();
        }


        public bool GetBy()
        {

            return _courseRepository.GetBy();

        }


        public bool GetAllmini()
        {
            return _courseRepository.GetAllmini();
        }

        public bool Create()
        {
            return _courseRepository.Create();
        }

        public bool Update()
        {
            return _courseRepository.Update();
        }

        public bool Delete()
        {
            return _courseRepository.Delete();
        }

        public bool InputRead(out string courseName, out string duration, out string description, out string coursePlan, out int schoolId)
        {
            return _courseRepository.InputRead(out courseName, out duration, out description, out coursePlan, out schoolId);
        }




    }
}
