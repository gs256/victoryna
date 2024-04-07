using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class QuizSelectScreen : MonoBehaviour
    {
        [SerializeField]
        private Transform _listRoot;

        [SerializeField]
        private QuizListItem _listItemPrefab;

        [SerializeField]
        private Button _backButton;

        private readonly QuizProvider _quizProvider = new QuizProvider();
        private readonly List<QuizListItem> _items = new();

        private void Start()
        {
            foreach (var quiz in _quizProvider.Quizzes)
            {
                QuizListItem item = Instantiate(_listItemPrefab, _listRoot);
                item.Initialize(quiz);
                item.Clicked += OnQuizSelected;
                _items.Add(item);
            }

            _backButton.onClick.AddListener(Hide);
        }

        private void OnDestroy()
        {
            foreach (var item in _items)
                item.Clicked -= OnQuizSelected;

            _items.Clear();
            _backButton.onClick.RemoveListener(Hide);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnQuizSelected(QuizDto quiz)
        {
            Debug.Log($"Selected [id: {quiz.Id}, name: {quiz.Name}]");
        }
    }
}
