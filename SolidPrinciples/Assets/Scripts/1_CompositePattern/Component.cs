using System;
using System.Collections.Generic;

[Serializable]
public abstract class Component
{
    //Readonly permette l'assegnamento del valore a runtime, a differenza di const che permette solo l'assegnamento al momento della dichiarazione.
    //Inoltre a const si possono assegnare solo valori costanti (come stringhe e numeri), mentre a readonly si possono anche fare asegnamenti tramite funzione.
    //
    //In casi come questi, in cui c'è da incapsulare un campo, è meglio utilizzare readonly dato che il suo valore
    //gli può essere assegnato anche nel costruttore di una classe figlia in un secondo momento.
    protected readonly List<Component> _components = new List<Component>();
    
    public abstract string ShowDetails();

    public virtual void Add(Component component)
    {
        _components.Add(component);
    }

    public virtual void Remove(Component component)
    {
        _components.Remove(component);
    }

    public List<Component> GetComponents()
    {
        return _components;
    }

}
