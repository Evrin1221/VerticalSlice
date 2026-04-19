using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour
{
    public static Locator Instance { get; private set; }
    public PlayerMovement _player { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;

        }
        Instance = this;
        GameObject player = GameObject.FindWithTag("Player");
        _player = player.GetComponent<PlayerMovement>();
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
