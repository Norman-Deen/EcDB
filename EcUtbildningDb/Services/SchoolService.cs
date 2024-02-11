using EcDB.IRepository;
using EcDB.Services;

internal class SchoolService
{
    private readonly ISchoolRepository _schoolRepository;
    private readonly ValidationService _validationService;

    public SchoolService(ISchoolRepository schoolRepository)
    {
        _schoolRepository = schoolRepository;
     
    }

 

    public bool GetAll()
    {
        return _schoolRepository.GetAll();
    }

    public bool GetAllmini()
    {
        return _schoolRepository.GetAllmini();
    }

    public bool GetBy()
    {
        return _schoolRepository.GetBy();
    }

    public bool Create()
    {
        return _schoolRepository.Create();
    }

    public bool Update()
    {
        return _schoolRepository.Update();
    }

    public bool Delete()
    {
        return _schoolRepository.Delete();
    }

    public bool InputRead(out string SchoolName, out string Address, out string PhoneNumber, out string Website)
    {
        return _schoolRepository.InputRead(out SchoolName, out Address, out PhoneNumber, out Website);
    }


}
