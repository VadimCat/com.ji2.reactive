using System;

namespace Ji2Core.Reactive
{
    public interface IReactiveProperty<T>
    {
        event Action<T, T> ValueChangedWithPrevious;
        event Action<T> ValueChanged;
        T Value { get; }
        T PrevValue { get; }
    }
}