using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _musicSource;


    [SerializeField] private AudioClip _backgroundMusic;


    [SerializeField] private AudioClip _slash; //done
    [SerializeField] private AudioClip _bubblePop;//done
    [SerializeField] private AudioClip _bubbleForm;//done
    [SerializeField] private AudioClip _collect;//done
    [SerializeField] private AudioClip _heal;//done
    [SerializeField] private AudioClip _damage;//done
    [SerializeField] private AudioClip _weakNerf;//done
    [SerializeField] private AudioClip _strongNerf;//done
    [SerializeField] private AudioClip _buff;//done
    [SerializeField] private AudioClip _explosion;



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        _musicSource.clip = _backgroundMusic;
        _musicSource.loop = true;
        _musicSource.Play();
    
}

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySlash()
    {
        _sfxSource.PlayOneShot(_slash);
    }

    public void PlayBubblePop()
    {
        _sfxSource.PlayOneShot(_bubblePop);
    }

    public void PlayBubbleForm()
    {
        _sfxSource.PlayOneShot(_bubbleForm);
    }

    public void PlayCollect()
    {
        _sfxSource.PlayOneShot(_collect);
    }

    public void PlayHeal()
    {
        _sfxSource.PlayOneShot(_heal);
    }

    public void PlayDamage()
    {
        _sfxSource.PlayOneShot(_damage);
    }

    public void PlayWeakNerf()
    {
        _sfxSource.PlayOneShot(_weakNerf);
    }

    public void PlayStrongNerf()
    {
        _sfxSource.PlayOneShot(_strongNerf);
    }

    public void PlayBuff()
    {
        _sfxSource.PlayOneShot(_buff);
    }

    public void PlayExplosion()
    {
        _sfxSource.PlayOneShot(_explosion);
    }
}

