using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float _lifeTime = 1f;
    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Explosion touching: " + collision.name);
    }
    */
}
