using University.Core.Common.Entities;

namespace University.Core.Common.Services
{
    public interface IStudentDAL
    {
        Task<IEnumerable<Carrers>> GetAllCarrers();

        Task<IEnumerable<CivilStatus>> GetAllCivilStatus();

        Task<IEnumerable<Genders>> GetAllGenders();

        Task<IEnumerable<MaximunLevelStudies>> GetAllMaximunLevelStudies();

        Task<IEnumerable<StudentStatus>> GetAllStudentStatus();

        /**/
        Task<Student> GetStudent(int id);

        Task<IEnumerable<Student>> GetAllStudents();

        Task SaveStudent(Student student);

        Task DeleteStudent(int id);

        Task UpdateStudent(int id, Student student);

    }
}
