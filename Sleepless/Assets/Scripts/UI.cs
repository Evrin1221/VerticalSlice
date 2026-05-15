using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    //sanity
    [SerializeField] private TMP_Text _sanityText;
    [SerializeField] private PlayerState _playerState;

    //items
    [SerializeField] private Inventory _inventory;
    [SerializeField] private TMP_Text _grenadeText;
    private float _sanity;
    void Start()
    {
        _inventory = Locator.Instance._inventory;
    }

    // Update is called once per frame
    void Update()
    {
        _sanityText.text = "Sanity:" + _playerState.GetSanity();
        _grenadeText.text = "Grenades:" + _inventory.GetGrenadeCount();
    }







    
}
