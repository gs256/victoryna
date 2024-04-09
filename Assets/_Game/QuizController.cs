using UnityEngine;

namespace Game
{
    public class QuizController : MonoBehaviour
    {
        [SerializeField]
        private QuestionView _questionView;

        private readonly QuizProvider _quizProvider = GlobalContext.QuizProvider;
        private int _questionIndex;
        private QuizDto _quiz;

        private void Start()
        {
            _quiz = _quizProvider.Quizzes[0];
            _questionIndex = 0;
            DisplayQuestion();
            _questionView.Selected += OnSelected;
            _questionView.Next += OnNextClicked;
        }

        private void OnDestroy()
        {
            _questionView.Selected -= OnSelected;
            _questionView.Next -= OnNextClicked;
        }

        private void DisplayQuestion()
        {
            if (_questionIndex > 0)
                _questionView.Clear();

            if (_quiz.Questions.Length <= _questionIndex)
            {
                _questionView.Clear();
                Debug.Log("Quiz completed");
            }
            else
            {
                _questionView.Display(_quiz.Questions[_questionIndex], _questionIndex, _quiz.Questions.Length);
                _questionIndex += 1;
            }
        }

        private void OnSelected(QuestionOptionDto option)
        {
            Debug.Log($"Option: {option.Text}");
        }

        private void OnNextClicked()
        {
            DisplayQuestion();
        }
    }
}
