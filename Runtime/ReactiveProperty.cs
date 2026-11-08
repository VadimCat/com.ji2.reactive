using System;

namespace Ji2Core.Reactive
{
    public class ReactiveProperty<T> : IReactiveProperty<T>
    {
        private T _value;
        private T _prevValue;

        public event Action<T, T> ValueChangedWithPrevious;
        public event Action<T> ValueChanged;

        public T PrevValue => _prevValue;

        public T Value
        {
            get => _value;
            set
            {
                _prevValue = _value;
                
                if (!Equals(value, _value))
                {
                    _value = value;
                    ValueChangedWithPrevious?.Invoke(_value, _prevValue);
                    ValueChanged?.Invoke(_value);
                }
            }
        }

        public ReactiveProperty(T initialValue)
        {
            Value = initialValue;
        }

        public ReactiveProperty()
        {
            int a = 0;
            Value = default;
        }
    }
}