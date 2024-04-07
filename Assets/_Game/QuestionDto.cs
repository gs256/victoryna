namespace Game
{
    public class QuestionDto
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public QuestionOptionDto[] Options { get; set; }
        public string AnswerId { get; set; }
    }
}
