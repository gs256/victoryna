using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class QuestionOptionView : MonoBehaviour
    {
        public event Action<QuestionOptionDto> Clicked;
        public string OptionId { get; private set; }

        [SerializeField]
        private TMP_Text _label;

        [SerializeField]
        private Button _button;

        private QuestionOptionDto _option;

        public void Initialize(QuestionOptionDto option)
        {
            _option = option;
            OptionId = _option.Id;
            _label.text = $"{option.Text}";
        }

        public void Lock()
        {
            _button.transition = Selectable.Transition.None;
            _button.interactable = false;
        }

        public void HighlightCorrect()
        {
            _button.image.color = GlobalSettings.CorrectAnswerColor;
        }

        public void HighlightWrong()
        {
            _button.image.color = GlobalSettings.WrongAnswerColor;
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
            Clicked?.Invoke(_option);
        }
    }
}
