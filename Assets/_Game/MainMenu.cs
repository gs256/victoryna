using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private Button _quizzesButton;

        [SerializeField]
        private Button _exitButton;

        [SerializeField]
        private QuizSelectScreen _quizSelectionScreen;

        private void Start()
        {
            _quizzesButton.onClick.AddListener(ToQuizSelectionScreen);
            _exitButton.onClick.AddListener(Exit);
        }

        private void OnDestroy()
        {
            _quizzesButton.onClick.RemoveListener(ToQuizSelectionScreen);
            _exitButton.onClick.RemoveListener(Exit);
        }

        private void ToQuizSelectionScreen()
        {
            _quizSelectionScreen.Show();
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}
