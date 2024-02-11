using EcDB.Data;
using EcDB.Entities;
using EcDB.IRepository;
using Microsoft.EntityFrameworkCore;


namespace EcDB.Services
{
    internal class CoursePlanService : ICoursePlanRepository
    {
        private readonly AppSettings _context;
        public CoursePlanService(AppSettings context)
        {
            _context = context;
        }

        public bool Create()
        {
            throw new NotImplementedException();
        }

        public bool Delete()
        {
            throw new NotImplementedException();
        }

        public bool GetAll()
        {
            throw new NotImplementedException();
        }

        public bool GetBy()
        {
            throw new NotImplementedException();
        }

        public bool InputRead(out string Name, out string Email, out string Phone, out string Address, out int Grade, out int SchoolId, out int CourseId)
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}
