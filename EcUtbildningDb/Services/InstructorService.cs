using EcDB.Data;
using EcDB.Entities;
using EcDB.IRepository;
using EcDB.Repository;
using EcDB.Services;
using EcDB.Services.SubServices;
using Microsoft.EntityFrameworkCore;

internal class InstructorService : IInstructorRepository
{
    private readonly IInstructorRepository _instructorRepository;
    private readonly ValidationService _validationService;
    private readonly AppSettings _context;

    public InstructorService(IInstructorRepository instructorRepository, AppSettings context)
    {
        _instructorRepository = instructorRepository;
        _context = context;
        _validationService = new ValidationService(_context); // Pass _context to the ValidationService constructor
    }

    public bool GetAll()
    {
        return _instructorRepository.GetAll();
    }

    public bool GetBy()
    {
        return _instructorRepository.GetBy();
    }

    public bool GetAllmini()
    {
        return _instructorRepository.GetAllmini();
    }

    public bool Create()
    {
        return _instructorRepository.Create();
    }

    public bool Update()
    {
        return _instructorRepository.Update();
    }

    public bool Delete()
    {
        return _instructorRepository.Delete();
    }

    public bool InputRead(out string Name, out string Email, out string Phone, out string Address, out int SchoolId, out int CourseId)
    {
        return _instructorRepository.InputRead(out  Name, out  Email, out  Phone, out  Address, out  SchoolId, out  CourseId);
    }
}
