using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    // Start is called before the first frame update

    //Shared variables

    [SerializeField] protected float _speed;
    [SerializeField] protected float _hp;
    [SerializeField] protected float _maxhp;
    [SerializeField] protected float _detectionDistance;
    [SerializeField] protected float _attackDistance;



    protected Transform _playerTransform;
    protected bool _playerInRange;
    protected bool _canAttack;
    [SerializeField] protected float _attackDuration;
    protected float _attackTimer;
    protected bool _isAttacking;
    protected bool _hasTimeLeft;

    protected EnemyState _currentState;


    //dealing damage

    [SerializeField] protected float _damage;


    //animations
    [SerializeField] protected Animator _animator;

    //retreating
    protected EnemySpawner _spawner;
    protected Vector3 _retreatPoint;


    public enum EnemyState
    {
        _roaming, _chasing, _attacking, _retreating
    }

    public static event Action<Enemy> OnEnemyHit;

    public void Hit()
    {
        OnEnemyHit?.Invoke(this);
    }


    void Start()
    {
        _playerTransform = Locator.Instance._player.transform;
        _currentState = EnemyState._roaming;
        _attackTimer = _attackDuration;
        _hasTimeLeft = true;
        _spawner = FindObjectOfType<EnemySpawner>();

    }


   

    // Update is called once per frame
    void Update()
    {
        DetectPlayerInRange();
        RunCurrentState(_currentState);
        CheckRetreated();
       
    }

    protected virtual void Attack()
    {

    }

    protected void DetectPlayerInRange()
    {
        float _distanceToPlayer = Vector2.Distance(_playerTransform.position, transform.position); 

        if (_currentState == EnemyState._retreating) return;

        else if (_distanceToPlayer<= _attackDistance)
        {
            //chasing and attacking
            _playerInRange = true;
            _canAttack = true;
            _isAttacking = true;
            ChangeState(EnemyState._attacking);
        }

        else if( (_attackDistance < _distanceToPlayer) &&(_distanceToPlayer<=_detectionDistance))
            //chasing but not attacking
        {
            _playerInRange = true;
            _canAttack = false;
            _isAttacking = false;
            ChangeState(EnemyState._chasing);
        }

        else if (_distanceToPlayer > _detectionDistance && _hasTimeLeft)
        {
            _playerInRange = false;
            _canAttack = false;
            _isAttacking = false;
            ChangeState(EnemyState._roaming);

        }

    }


    protected void Retreat()
    {
        //this is the part that MOVES the little guy
        _retreatPoint = _spawner.PickRetreatPoint();
        transform.position = _retreatPoint;
    //Imma need tech support for moving shit "off screen"
    }

    protected void RunCurrentState(EnemyState state)
    {
        switch (_currentState)
        {
            case EnemyState._roaming:
                //when enemy instantiated
                
                Roaming();
                break;

            case EnemyState._chasing:
                //starts when player enters range
                
                
                Follow();
                break;

            case EnemyState._attacking:
                //for the duration of the timer * note: if timer doesn't run out you keep the value and it can go back to roaming and chasing depending on whether player in range
                Attack();
                Follow();
                AttackTimer();
                CheckTimerLeft();
                break;

            case EnemyState._retreating:
                //once timer reaches 0. once it reaches this state enemy go off screen and destroy
                
                Retreat();
                break;
        }
    }

    protected void EnterNewState(EnemyState state)
    {
        switch (_currentState)
        {
            case EnemyState._roaming:
                //play animation
                _animator.SetBool("isAttacking", false);
                _animator.Play("moving");
               // Debug.Log("roaming");
                break;

            case EnemyState._chasing:

                _animator.SetBool("isAttacking", false);
               // _animator.Play("spotted"); doesnt exist yet
                _animator.Play("moving");
               // Debug.Log("chasing");
                break;
                

            case EnemyState._attacking:
                //play animation
                _animator.SetBool("isAttacking", true);
                _animator.Play("start attack");
                //_animator.Play("attack");
               // Debug.Log("attacking");
                break;

            case EnemyState._retreating:
                //play animation
                _animator.SetBool("isAttacking", false);
                _animator.Play("moving");
                Debug.Log("retreating");

                break;
        }
    }

    protected void ChangeState(EnemyState newState)
    {

        if (_currentState == newState) return;  

        _currentState = newState;
        EnterNewState(_currentState);
    }

    protected void Roaming()
    {
        transform.position = transform.position + new Vector3(-1, 0, 0) * _speed*Time.deltaTime;
    }

    protected void Follow()
    {
        //move towards player use lerp maybe

        Vector2 target = _playerTransform.position;

        transform.position = Vector2.Lerp(transform.position, target, _speed * Time.deltaTime);
    }

    protected void AttackTimer()
    {
        _attackTimer -= Time.deltaTime;
        if(_attackTimer <= 0 )
        {
            _hasTimeLeft = false;
            print("time up");
        }
    }

    protected void CheckTimerLeft()
    {
        if(!_hasTimeLeft)
        {
            ChangeState(EnemyState._retreating);
        }
    }

    public float GetDamageDealt()
    {
        return _damage;
    }

    protected void CheckRetreated()
    {
        if (transform.position == _retreatPoint)
        {
            Destroy(gameObject);
            Debug.Log("enemy gone");
        }
    }

}
