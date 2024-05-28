(STILL WORK IN PROGRESS)

![image](https://github.com/Krachet/First-FPS-Game/assets/130090198/180ed363-bd64-4f77-ba40-82d5bcc32e9f)

Interaction Editor:

![image](https://github.com/Krachet/First-FPS-Game/assets/130090198/27acb3a2-2ecf-416b-b101-349d02f68bd9)

So if the Object is interactible, these codes will run which will trigger the interaction:
The Object is determined interactible if useEvents is ticked in editor:

![image](https://github.com/Krachet/First-FPS-Game/assets/130090198/92d62d43-99e0-474c-b3d7-7246a25b6585)

public void BaseInteract()
{
    if (useEvents)
    {
        GetComponent<InteractionEvents>().OnInteract.Invoke();
    }
    Interact();
}
