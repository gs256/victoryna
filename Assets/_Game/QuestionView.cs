using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game
{
    public class QuestionView : MonoBehaviour
    {
        public event Action<QuestionOptionDto> Selected;

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

        private QuestionDto _question;
        private int _questionNumber;
        private readonly List<QuestionOptionView> _options = new();

        private void OnValidate()
        {
            _headerFormat = _headerLabel.text;
        }

        public void Display(QuestionDto question, int questionNumber)
        {
            _question = question;
            _questionNumber = questionNumber;
            _headerLabel.text = string.Format(_headerFormat, _questionNumber + 1);
            _questionLabel.text = _question.Text;

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
            Selected?.Invoke(option);
        }
    }
}
