namespace Game
{
    public class QuizDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public QuestionDto[] Questions { get; set; }
    }
}
