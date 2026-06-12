using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update

    private ArmMarking _armMarking;
    void Start()
    {
        _armMarking = Locator.Instance._armMarking;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("Something touched checkpoint: " + collision.name);
        if (collision.CompareTag("Player"))
        {
            _armMarking.OpenArmUI();
            Debug.Log("touched");
        }
    }
}
