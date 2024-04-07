using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class QuizSelectScreen : MonoBehaviour
    {
        [SerializeField]
        private Transform _listRoot;

        [SerializeField]
        private QuizListItem _listItemPrefab;

        private readonly QuizProvider _quizProvider = new QuizProvider();
        private List<QuizListItem> _items = new();

        private void Start()
        {
            foreach (var quiz in _quizProvider.Quizzes)
            {
                QuizListItem item = Instantiate(_listItemPrefab, _listRoot);
                item.Initialize(quiz);
                item.Clicked += OnQuizSelected;
                _items.Add(item);
            }
        }

        private void OnDestroy()
        {
            foreach (var item in _items)
                item.Clicked -= OnQuizSelected;
            _items.Clear();
        }

        private void OnQuizSelected(QuizDto quiz)
        {
            Debug.Log($"Selected [id: {quiz.Id}, name: {quiz.Name}]");
        }
    }
}
