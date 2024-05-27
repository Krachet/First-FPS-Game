using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;

    public float distance = 5f;

    private PlayerUI playerUI;
    private InputManager inputManager;
    [SerializeField] private LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateMessage(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance, layerMask))
        {
            if (hit.collider.GetComponent<Interactible>())
            {
                Interactible interactible = hit.collider.GetComponent<Interactible>();
                interactible.HoverMessage();
                playerUI.UpdateMessage(interactible.hoverMessage);
                if (inputManager.onFoot.Interact.triggered)
                {
                    interactible.BaseInteract();
                }
            }
        }
    }
}
