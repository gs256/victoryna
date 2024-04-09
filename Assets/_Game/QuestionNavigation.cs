using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class QuestionNavigation : MonoBehaviour
    {
        public event Action Proceed;
            
        private const string NextButtonText = "Next";
        private const string ConcludeButtonText = "Results";
            
        [SerializeField]
        private Button _proceedButton;

        [SerializeField]
        private TMP_Text _proceedButtonLabel;
        
        private int _questionIndex;
        private int _questionCount;

        private void Start()
        {
            _proceedButton.onClick.AddListener(OnProceed);
        }

        private void OnDestroy()
        {
            _proceedButton.onClick.RemoveListener(OnProceed);
        }

        public QuestionNavigation WithContext(int questionIndex, int questionCount)
        {
            _questionIndex = questionIndex;
            _questionCount = questionCount;
            return this;
        }
        
        public void Show()
        {
            _proceedButtonLabel.text = IsLastQuestion() ? ConcludeButtonText : NextButtonText;
            _proceedButton.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _proceedButton.gameObject.SetActive(false);
        }

        private bool IsLastQuestion()
        {
            return _questionIndex >= _questionCount - 1;
        }

        private void OnProceed()
        {
            Proceed?.Invoke();
        }
    }
}