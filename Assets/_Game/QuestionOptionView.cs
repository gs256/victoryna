using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class QuestionOptionView : MonoBehaviour
    {
        public event Action<QuestionOptionDto> Clicked;

        [SerializeField]
        private TMP_Text _label;

        [SerializeField]
        private Button _button;

        private QuestionOptionDto _option;

        public void Initialize(QuestionOptionDto option)
        {
            _option = option;
            _label.text = $"{option.Text}";
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
