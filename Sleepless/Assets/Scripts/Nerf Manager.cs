using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NerfManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReverseControls()
    {
        Locator.Instance._player.SetReversedControls();
    }
}
