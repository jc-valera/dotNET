using Dapper;
using System.Data;
using University.Core.Common.Entities;
using University.Core.Common.Services;

namespace University.Core.DAL
{
    public class StudentDAL : IStudentDAL
    {
        public readonly SqlConfiguration Configuration;

        public StudentDAL(SqlConfiguration configuration)
        {
            Configuration = configuration;
        }


        public async Task<IEnumerable<Carrers>> GetAllCarrers()
        {
            var carrers = new List<Carrers>();

            var connection = await Configuration.GetConnection();

            carrers = connection.Query<Carrers>("sp_GetCarrers", commandType: CommandType.StoredProcedure).ToList();

            return carrers;
        }

        public async Task<IEnumerable<CivilStatus>> GetAllCivilStatus()
        {
            var civilStatus = new List<CivilStatus>();

            var connection = await Configuration.GetConnection();

            civilStatus = connection.Query<CivilStatus>("sp_GetCivilStatus", commandType: CommandType.StoredProcedure).ToList();

            return civilStatus;
        }

        public async Task<IEnumerable<Genders>> GetAllGenders()
        {
            var genders = new List<Genders>();

            var connection = await Configuration.GetConnection();

            genders = connection.Query<Genders>("sp_GetGenders", commandType: CommandType.StoredProcedure).ToList();

            return genders;
        }


        public async Task<IEnumerable<MaximunLevelStudies>> GetAllMaximunLevelStudies()
        {
            var levelStudies = new List<MaximunLevelStudies>();

            var connection = await Configuration.GetConnection();

            levelStudies = connection.Query<MaximunLevelStudies>("sp_GetAllMaximunLevelStudies", commandType: CommandType.StoredProcedure).ToList();

            return levelStudies;
        }

        public async Task<IEnumerable<StudentStatus>> GetAllStudentStatus()
        {
            var studentStatus = new List<StudentStatus>();

            var connection = await Configuration.GetConnection();

            studentStatus = connection.Query<StudentStatus>("sp_GetAllStudentStatus", commandType: CommandType.StoredProcedure).ToList();

            return studentStatus;
        }

        /**/
        public async Task<Student> GetStudent(int id)
        {
            var student = new Student();

            var connection = await Configuration.GetConnection();

            var queryString = $"SELECT [Id], [Names], [FirstSurname], [SecondSurname], [BirthDate], [Age], [GenderId], [CarrersId], [MaximunLevelStudiesId], [CivilStatusId], [StudentStatusId] FROM [Students] WHERE Id = {id}";

            student = connection.QueryFirstOrDefault<Student>(queryString, new { Id = id });

            return student;
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var students = new List<Student>();

            var connection = await Configuration.GetConnection();

            students = connection.Query<Student>("sp_GetAllStudent", commandType: CommandType.StoredProcedure).ToList();

            return students;
        }

        public async Task SaveStudent(Student student)
        {
            var connection = await Configuration.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Names", student.Names, DbType.String);
            parameters.Add("@FirstSurname", student.FirstSurname, DbType.String);
            parameters.Add("@SecondSurname", student.SecondSurname, DbType.String);
            parameters.Add("@BirthDate", student.BirthDate, DbType.Date);
            parameters.Add("@Age", student.Age, DbType.Int32);
            parameters.Add("@GenderId", student.GenderId, DbType.Int32);
            parameters.Add("@CarrersId", student.CarrersId, DbType.Int32);
            parameters.Add("@MaximunLevelStudiesId", student.MaximunLevelStudiesId, DbType.Int32);
            parameters.Add("@CivilStatusId", student.CivilStatusId, DbType.Int32);
            parameters.Add("@StudentStatusId", student.StudentStatusId, DbType.Int32);

            await connection.ExecuteAsync("sp_SaveStudent", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteStudent(int id)
        {
            var connection = await Configuration.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32);

            await connection.ExecuteAsync("sp_DeleteStudent", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateStudent(int id, Student student)
        {
            var connection = await Configuration.GetConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id, DbType.Int32);
            parameters.Add("@Names", student.Names, DbType.String);
            parameters.Add("@FirstSurname", student.FirstSurname, DbType.String);
            parameters.Add("@SecondSurname", student.SecondSurname, DbType.String);
            parameters.Add("@BirthDate", student.BirthDate, DbType.Date);
            parameters.Add("@Age", student.Age, DbType.Int32);
            parameters.Add("@GenderId", student.GenderId, DbType.Int32);
            parameters.Add("@CarrersId", student.CarrersId, DbType.Int32);
            parameters.Add("@MaximunLevelStudiesId", student.MaximunLevelStudiesId, DbType.Int32);
            parameters.Add("@CivilStatusId", student.CivilStatusId, DbType.Int32);
            parameters.Add("@StudentStatusId", student.StudentStatusId, DbType.Int32);


            await connection.ExecuteAsync("sp_UpdateStudent", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
