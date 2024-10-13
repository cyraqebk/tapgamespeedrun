using UnityEngine;
using Core.ReactiveFields;
using Core.Json;
using System.Collections;
using Core.Setting;

namespace Core.Tappings
{
    public class LevelUpgrade : MonoBehaviour
    {
        [SerializeField] private GameInitializer _gameInitializer;
        [SerializeField] private Settings settings;
        [SerializeField] private SoftCurrency _softCurrency;
        [SerializeField] private AnimationCurve _priceCurve;
        [SerializeField] private AnimationCurve _buffCurve;
        [SerializeField] private int _maxLevel = 50;
        [SerializeField] private int _speed = 1;
        [SerializeField] private ReactiveField<int> _currenLevel = new ReactiveField<int>(1);
        public ReactiveField<int> CurrenLevel => _currenLevel;
        [SerializeField] private int _price = 10;
        private void Start()
        {
            _currenLevel.Value = SaveManager.Load("_currenLevel", 1);
            _gameInitializer.SubscribeToStopGame(OnStopGame);
        }

        private void OnDestroy()
        {
            if (_gameInitializer != null)
            {
                _gameInitializer.UnsubscribeFromStopGame(OnStopGame);
            }
        }

        private void OnStopGame()
        {
            SaveManager.Save("_currenLevel", _currenLevel.Value);
        }
        public int GetThePrice()
        {
            float normalizedLevel = (float)_currenLevel.Value;
            float price = _priceCurve.Evaluate(normalizedLevel);
            return Mathf.CeilToInt(price);
        }
        public int GetTheSpeed(int meanin)
        {
            float normalizedLevel = (float)meanin;
            float speed = _buffCurve.Evaluate(normalizedLevel);
            return Mathf.CeilToInt(speed);
        }
        public void Improvement()
        {
            if (_softCurrency.CurrencyField.Value >= GetThePrice())
            {
                settings.VibrationPulse();
                _softCurrency.SubtractingValue(GetThePrice());
                _currenLevel.Value += 1;
                _price = GetThePrice();
                _speed = GetTheSpeed(_currenLevel.Value);
            }
        }
        
    }
}
