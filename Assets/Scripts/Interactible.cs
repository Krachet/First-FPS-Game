using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : MonoBehaviour
{
    public string hoverMessage;
    public bool useEvents;
    
    public void BaseInteract()
    {
        if (useEvents)
        {
            GetComponent<InteractionEvents>().OnInteract.Invoke();
        }
        Interact();
    }

    public void HoverMessage()
    {
        Hovering();
    }

    protected virtual void Interact() { }

    protected virtual void Hovering() { }

    protected virtual void ExitHover() { }
}
