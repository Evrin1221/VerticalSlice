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

    [SerializeField] Material _wobblyVision;
    public void ReverseControls()
    {
        Locator.Instance._player.SetReversedControls();
        Locator.Instance._player.PlayHalo();
    }

    public void WobblyVisionWeak()
    {
        _wobblyVision.SetFloat("_Blend", 0.1f);
        Debug.Log("wobbly vision on");

    }

    public void WobblyVisionStrong()
    {
        _wobblyVision.SetFloat("_Blend", 0.25f);

    }
}
