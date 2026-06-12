using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private float timer;
    private bool timerRunning;
    void Start()
    {
        _animator.Play("bubble");
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerRunning) return;

        timer -= Time.deltaTime;
        _animator.Play("bubble gone");

        if (timer <= 0)
        {
            timerRunning = false;
            _animator.SetBool("cooldown", false);
            GetComponent<Collider2D>().enabled = true;
        }
    }

    private void StartTimer(float duration)
    {
        timer = duration;
        timerRunning = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            GetComponent<Collider2D>().enabled = false;
            _animator.SetTrigger("pop");
            _animator.SetBool("cooldown", true);
            _animator.Play("bubble pop");
            StartTimer(2f);
            

        }
    }

}
