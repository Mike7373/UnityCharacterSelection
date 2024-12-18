using System;
using System.Collections.Generic;

public class CustomToggleGroup : ISubject
{
    public string Name { get; }
    public List<IObserver> _observers = new();

    public CustomToggleGroup(string name)
    {
        Name = name;
    }
    
    public void Register(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Unregister(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (IObserver observer in _observers)
        {
            observer.DeselectNotify(this);
        }
    }
}
