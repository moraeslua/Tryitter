using Gwtdo;

namespace TestProject1.UnitTests.Services.Post
{
    public class PostServiceTest : Feature<PostServiceFixture>, IClassFixture<PostServiceFixture>
    {
        public PostServiceTest(PostServiceFixture fixture)
        {
            SetFixture(fixture);
            fixture.Setup();
        }

        [Fact]
        public void Create_student_on_sucess()
        {
            GIVEN
                .My_post_repository_is_initialized().And
                .My_student_service_is_initialized().And
                .My_post_repository_returns_post_created().And
                .I_have_a_post_service();
            WHEN
                .I_ask_to_create_a_new_post();
            THEN
                .I_should_have_created_a_new_post();
        }

        [Fact]
        public void Update_student_on_sucess()
        {
            GIVEN
                .My_post_repository_is_initialized().And
                .My_student_service_is_initialized().And
                .My_post_repository_read_by_id_returns_post_data().And
                .My_post_repository_returns_post_updated().And
                .I_have_a_post_service();
            WHEN
                .I_ask_to_update_a_post();
            THEN
                .I_should_have_updated_a_post();
        }

       [Fact]
        public void Read_student_all_posts_on_sucess()
        {
            GIVEN
                .My_post_repository_is_initialized().And
                .My_student_service_is_initialized().And
                .My_student_service_returns_student_data().And
                .My_post_repository_returns_posts_list().And
                .I_have_a_post_service();
            WHEN
                .I_ask_to_read_a_student_posts_list();
            THEN
                .I_should_have_a_posts_list();
        }


    }
}
