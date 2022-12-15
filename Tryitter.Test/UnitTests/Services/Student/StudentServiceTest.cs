using Gwtdo;

namespace TestProject1.UnitTests.Services.Student
{
    public class StudentServiceTest : Feature<StudentServiceFixture>, IClassFixture<StudentServiceFixture>
    {
        public StudentServiceTest(StudentServiceFixture fixture)
        {
            SetFixture(fixture);
            fixture.Setup();
        }

        [Fact]
        public void Create_student_on_sucess()
        {
            GIVEN
                .My_student_repository_is_initialized().And
                .My_student_repository_returns_null().And
                .My_student_repository_returns_student_created().And
                .My_token_service_is_initialized().And
                .My_token_service_returns_new_token().And
                .I_have_a_student_service();
            WHEN
                .I_ask_to_create_a_new_student();
            THEN
                .I_should_have_created_a_new_student();
        }

        [Fact]
        public void Update_student_on_sucess()
        {
            GIVEN
                .My_student_repository_is_initialized().And
                .My_student_repository_read_by_id_returns_student().And
                .My_student_repository_returns_null().And
                .My_student_repository_returns_student_updated().And
                .My_token_service_is_initialized().And
                .I_have_a_student_service();
            WHEN
                .I_ask_to_update_a_student();
            THEN
                .I_should_have_updated_a_student ();
        }        
        
        [Fact]
        public void Authenticate_student_on_sucess()
        {
            GIVEN
                .My_student_repository_is_initialized().And
                .My_student_repository_read_by_email_returns_student().And
                .My_token_service_is_initialized().And
                .My_token_service_returns_new_token().And
                .I_have_a_student_service();
            WHEN
                .I_ask_to_authenticate_a_student();
            THEN
                .I_should_have_authenticated_a_student();
        }

        [Fact]
        public void Read_student_by_email_on_sucess()
        {
            GIVEN
                .My_student_repository_is_initialized().And
                .My_student_repository_read_by_email_returns_student().And
                .My_token_service_is_initialized().And
                .I_have_a_student_service();
            WHEN
                .I_ask_to_read_a_student_by_email();
            THEN
                .I_should_have_student_data();
        }
    }
}
