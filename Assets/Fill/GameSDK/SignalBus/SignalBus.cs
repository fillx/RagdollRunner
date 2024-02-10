using System;
using System.Collections.Generic;
using System.Collections.Specialized;

 public class SignalBus
    {
        private readonly Dictionary<Type, OrderedDictionary> _subscriptionsMap =
            new Dictionary<Type, OrderedDictionary>();

        private readonly Dictionary<Type, FiredSignalState> _currentFiredSignals =
            new Dictionary<Type, FiredSignalState>();

        public void Subscribe<TSignal>(Action<TSignal> callback, object identifier)
        {
            RunOrSchedule(typeof(TSignal),
                () =>
                {
                    if (!_subscriptionsMap.TryGetValue(typeof(TSignal), out var subscriptions))
                    {
                        subscriptions = new OrderedDictionary();
                        _subscriptionsMap.Add(typeof(TSignal), subscriptions);
                    }

                    subscriptions.Add(identifier, callback);
                });
        }

        public void Unsubscribe<TSignal>(object identifier)
        {
            RunOrSchedule(typeof(TSignal),
                () =>
                {
                    if (!_subscriptionsMap.TryGetValue(typeof(TSignal), out var subscriptions))
                        return;
                    subscriptions.Remove(identifier);
                });
        }

        public void UnsubscribeFromAll(object identifier)
        {
            foreach (var subscriptions in _subscriptionsMap)
            {
                RunOrSchedule(subscriptions.Key, () => { subscriptions.Value.Remove(identifier); });
            }
        }

        /// avoid circular fire (firing signal from it's listener)
        public void FireSignal<TSignal>(TSignal signal)
        {
            if (!_currentFiredSignals.TryGetValue(typeof(TSignal), out var lastState))
            {
                _currentFiredSignals.Add(typeof(TSignal), new FiredSignalState(null, 1));
            }
            else
            {
                _currentFiredSignals[typeof(TSignal)] =
                    new FiredSignalState(lastState.OnComplete, lastState.CurrentFireCount + 1);
            }

            var subscriptions = GetSignalSubscriptions<TSignal>();
            if (subscriptions != null)
            {
                var subscriptionsCount = subscriptions.Count;
                for (var i = 0; i < subscriptionsCount; i++)
                {
                    ((Action<TSignal>)subscriptions[i]).Invoke(signal);
                }
            }

            lastState = _currentFiredSignals[typeof(TSignal)];
            lastState.OnComplete?.Invoke();
            if (lastState.CurrentFireCount - 1 > 0)
            {
                _currentFiredSignals[typeof(TSignal)] = new FiredSignalState(null, lastState.CurrentFireCount - 1);
            }
            else
            {
                _currentFiredSignals.Remove(typeof(TSignal));
            }
        }

        private OrderedDictionary GetSignalSubscriptions<TSignal>()
        {
            if (!_subscriptionsMap.TryGetValue(typeof(TSignal), out var subscriptions))
                return null;
            return subscriptions;
        }

        private void RunOrSchedule(Type signalType, Action operation)
        {
            if (_currentFiredSignals.TryGetValue(signalType, out var firedSignalState))
            {
                _currentFiredSignals[signalType] = new FiredSignalState(firedSignalState.OnComplete + operation,
                    firedSignalState.CurrentFireCount);
            }
            else
            {
                operation.Invoke();
            }
        }
    }
