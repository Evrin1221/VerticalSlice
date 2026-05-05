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
    protected float _attackDuration;
    protected float _attackTimer;
    protected bool _isAttacking;
    protected bool _hasTimeLeft;

    protected EnemyState _currentState;


    //dealing damage

    [SerializeField] protected float _damage;


   //animations
    [SerializeField] protected Animator _animator;

    public enum EnemyState
    {
        _roaming, _chasing, _attacking, _retreating
    }


    void Start()
    {
        _playerTransform = Locator.Instance._player.transform;
        _currentState = EnemyState._roaming;
        _attackTimer = _attackDuration;
        _hasTimeLeft = true;
     
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayerInRange();
        RunCurrentState(_currentState);
       
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

        else if( (_attackDistance <= _distanceToPlayer) &&(_distanceToPlayer<=_detectionDistance))
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

    //Imma need tech support for moving shit "off screen"
    }

    protected void RunCurrentState(EnemyState state)
    {
        switch (_currentState)
        {
            case EnemyState._roaming:
                //when enemy instantiated
                _animator.Play("moving");
                Roaming();
                break;

            case EnemyState._chasing:
                //starts when player enters range
                _animator.Play("spotted");
                _animator.Play("moving");
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
                _animator.Play("moving");
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
                break;

            case EnemyState._chasing:
                //play animation
                break;

            case EnemyState._attacking:
                //play animation
                break;

            case EnemyState._retreating:
                //play animation
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
        }
    }

    protected void CheckTimerLeft()
    {
        if(!_hasTimeLeft)
        {
            ChangeState(EnemyState._retreating);
        }
    }


    

}
