using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text _sanityText;
    [SerializeField] private PlayerState _playerState;
    private float _sanity;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        _sanityText.text = "Sanity:" + _playerState.GetSanity();
        
    }


    
}
