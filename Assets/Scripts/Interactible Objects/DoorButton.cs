using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : Interactible
{
    public GameObject door;
    public static bool doorOpen = false;
    protected override void Interact()
    {
        if (!doorOpen)
        {
            doorOpen = true;
            door.GetComponent<Animator>().SetBool("isOpen", doorOpen);
        }
        else
        {
            doorOpen = false;
            door.GetComponent<Animator>().SetBool("isOpen", doorOpen);
        }
    }
    protected override void Hovering()
    {
        if (!doorOpen)
        {
            hoverMessage = "Press F to open the door";
        }
        else
        {
            hoverMessage = "Press F to close the door";
        }
    }

    protected override void ExitHover()
    {
        hoverMessage = string.Empty;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
