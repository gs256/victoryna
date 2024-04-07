using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class QuizListItem : MonoBehaviour
    {
        public event Action<QuizDto> Clicked;

        [SerializeField]
        private Button _button;

        [SerializeField]
        private TMP_Text _label;

        private QuizDto _quiz;

        public void Initialize(QuizDto quizDto)
        {
            _quiz = quizDto;
            _label.text = quizDto.Name;
        }

        private void Start()
        {
            _button.onClick.AddListener(OnClicked);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            Clicked?.Invoke(_quiz);
        }
    }
}
