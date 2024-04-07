namespace Game
{
    public class QuizProvider
    {
        public QuizDto[] Quizzes => GenerateTestQuizList();

        private QuizDto[] GenerateTestQuizList()
        {
            return new QuizDto[]
            {
                new QuizDto()
                {
                    Name = "How good are you at math?",
                    Questions = new QuestionDto[]
                    {
                        new QuestionDto()
                        {
                            Id = "93e47238",
                            Text = "What is 2 * 2?",
                            Options = new QuestionOptionDto[]
                            {
                                new() { Id = "a04d68f3", Text = "5" },
                                new() { Id = "e31b2792", Text = "4" },
                                new() { Id = "7518bafd", Text = "8" },
                            },
                            AnswerId = "e31b2792"
                        },
                        new QuestionDto()
                        {
                            Id = "cff05175",
                            Text = "What is the smallest odd whole number?",
                            Options = new QuestionOptionDto[]
                            {
                                new() { Id = "c5b7dfc3", Text = "1" },
                                new() { Id = "885c66f9", Text = "0" },
                                new() { Id = "2974b4af", Text = "3" },
                            },
                            AnswerId = "c5b7dfc3"
                        },
                        new QuestionDto()
                        {
                            Id = "d0dd5113",
                            Text = "How to find the area of a circle?",
                            Options = new QuestionOptionDto[]
                            {
                                new() { Id = "d1b42f18", Text = "2πr" },
                                new() { Id = "41b659b8", Text = "π * (d^2)/2" },
                                new() { Id = "7d78b46d", Text = "π * r^2" },
                            },
                            AnswerId = "7d78b46d"
                        }
                    }
                }
            };
        }
    }
}
