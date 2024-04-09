using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game
{
    public class QuestionView : MonoBehaviour
    {
        public event Action<QuestionOptionDto> Selected;
        public event Action Next;

        [SerializeField]
        private TMP_Text _headerLabel;

        [SerializeField]
        private TMP_Text _questionLabel;

        [SerializeField, HideInInspector]
        private string _headerFormat;

        [SerializeField]
        private QuestionOptionView _optionPrefab;

        [SerializeField]
        private Transform _optionsRoot;

        [SerializeField]
        private QuestionNavigation _navigation;
        
        private QuestionDto _question;
        private int _questionIndex;
        private int _questionCount;
        private readonly List<QuestionOptionView> _options = new();

        private void OnValidate()
        {
            _headerFormat = _headerLabel.text;
        }

        private void Start()
        {
            _navigation.Proceed += OnNextClicked;
        }

        private void OnDestroy()
        {
            _navigation.Proceed -= OnNextClicked;
        }

        public void Display(QuestionDto question, int questionIndex, int questionCount)
        {
            _question = question;
            _questionIndex = questionIndex;
            _questionCount = questionCount;
            _headerLabel.text = string.Format(_headerFormat, _questionIndex + 1);
            _questionLabel.text = _question.Text;
            _navigation.Hide();

            foreach (var option in _question.Options)
            {
                QuestionOptionView optionView = Instantiate(_optionPrefab, _optionsRoot);
                optionView.Initialize(option);
                optionView.Clicked += OnOptionSelected;
                _options.Add(optionView);
            }
        }

        public void Clear()
        {
            foreach (var option in _options)
            {
                option.Clicked -= OnOptionSelected;
                Destroy(option.gameObject);
            }

            _options.Clear();
        }

        private void OnOptionSelected(QuestionOptionDto option)
        {
            foreach (var optionView in _options)
                optionView.Lock();

            if (option.Id == _question.AnswerId)
            {
                _options
                    .Find(o => o.OptionId == option.Id)
                    .HighlightCorrect();
            }
            else
            {
                _options
                    .Find(o => o.OptionId == option.Id)
                    .HighlightWrong();

                _options
                    .Find(o => o.OptionId == _question.AnswerId)
                    .HighlightCorrect();
            }

            Selected?.Invoke(option);
            
            _navigation
                .WithContext(questionIndex: _questionIndex, questionCount: _questionCount)
                .Show();
        }

        private void OnNextClicked()
        {
            Next?.Invoke();
        }
    }
}
