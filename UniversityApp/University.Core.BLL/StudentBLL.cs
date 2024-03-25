using University.Core.Common.Entities;
using University.Core.Common.Services;
using University.Core.DAL;

namespace University.Core.BLL
{
    public class StudentBLL : IStudentBLL
    {
        private readonly SqlConfiguration Configuration;

        public IStudentDAL StudentDAL;

        public StudentBLL(SqlConfiguration configuration)
        {
            Configuration = configuration;
            StudentDAL = new StudentDAL(Configuration);
        }

        public async Task<IEnumerable<Carrers>> GetAllCarrers()
        {
            var carrers = await StudentDAL.GetAllCarrers();

            return carrers;
        }

        public async Task<IEnumerable<CivilStatus>> GetAllCivilStatus()
        {
            var civilStatus = await StudentDAL.GetAllCivilStatus();

            return civilStatus;
        }

        public async Task<IEnumerable<Genders>> GetAllGenders()
        {
            var genders = await StudentDAL.GetAllGenders();
            
            return genders;
        }

        public async Task<IEnumerable<MaximunLevelStudies>> GetAllMaximunLevelStudies()
        {
            var levelStudies = await StudentDAL.GetAllMaximunLevelStudies();

            return levelStudies;
        }

        public async Task<IEnumerable<StudentStatus>> GetAllStudentStatus()
        {
            var studentStatus = await StudentDAL.GetAllStudentStatus();

            return studentStatus;
        }

        /**/
        public async Task<Student> GetStudent(int id)
        {
            var student = await StudentDAL.GetStudent(id);

            return student;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var students = await StudentDAL.GetAllStudents();

            return students;
        }

        public async Task SaveStudent(Student student)
        {
            await StudentDAL.SaveStudent(student);
        }

        public async Task DeleteStudent(int id)
        {
            await StudentDAL.DeleteStudent(id);
        }

        public async Task UpdateStudent(int id, Student student)
        {
            await StudentDAL.UpdateStudent(id, student);
        }
    }

}
