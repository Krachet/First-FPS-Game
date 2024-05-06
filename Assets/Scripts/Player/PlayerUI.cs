using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI hoverMessage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateMessage(string message)
    {
        hoverMessage.text = message;
    }
}
