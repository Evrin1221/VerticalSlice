using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    // Start is called before the first frame update

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpeedUp()
    {
        Locator.Instance._player.SpeedUp();
    }

    public void BiggerSlash()
    {
        Locator.Instance._player.BiggerSlash();
    }


    public void ActivateBubble()
    {
        Locator.Instance._player.ActivateBubble();
    }
}
