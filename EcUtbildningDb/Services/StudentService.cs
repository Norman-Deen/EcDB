using EcDB.Data;
using EcDB.Entities;
using EcDB.IRepository;
using EcDB.Repository;
using EcDB.Services;
using EcDB.Services.SubServices;
using Microsoft.EntityFrameworkCore;


internal class StudentService 
{

    private readonly IStudentRepository _studentRepository;
    private readonly ValidationService _validationService;
    private readonly AppSettings _context;

    // Constructor with two arguments
    public StudentService(IStudentRepository studentRepository, AppSettings context)
    {
        _studentRepository = studentRepository;
        _context = context;
        _validationService = new ValidationService(context);
    }


    public bool GetAll()
    {
        return _studentRepository.GetAll();
    }

    public bool GetAllmini()
    {
        return _studentRepository.GetAllmini();
    }

    public bool GetBy()
    {
        return _studentRepository.GetBy();
    }

    public bool Create()
    {
        return _studentRepository.Create();
    }

    public bool Update()
    {
        return _studentRepository.Update();
    }

    public bool Delete()
    {
        return _studentRepository.Delete();
    }

    public bool InputRead(out string Name, out string Email, out string Phone, out string Address, out int Grade, out int SchoolId, out int CourseId)
    {
        return _studentRepository.InputRead(out Name, out Email, out Phone, out Address, out Grade, out SchoolId, out CourseId);
    }




}
