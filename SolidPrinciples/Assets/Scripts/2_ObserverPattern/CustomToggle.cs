using System;
using UnityEngine;

public class CustomToggle : IObserver
{
    public string Name;

    public CustomToggle(string name)
    {
        Name = name;
    }
    
    public void DeselectNotify(ISubject subject)
    {
        Debug.Log($"{((CustomToggleGroup)subject).Name} sent a notification to {Name}");
    }
}
