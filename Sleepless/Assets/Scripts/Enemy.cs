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
    public enum EnemyState
    {
        _roaming, _chasing, _attacking, _retreating
    }


    void Start()
    {
        _playerTransform = Locator.Instance._player.transform;
        _currentState = EnemyState._roaming; //might even do this in the spawner script
        _attackTimer = _attackDuration;
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayerInRange();

    }

    protected virtual void Attack()
    {

    }

    protected void DetectPlayerInRange()
    {
        if(Vector2.Distance(_playerTransform.position, transform.position) <= _attackDistance)
        {
            //chasing and attacking
            _playerInRange = true;
            _canAttack = true;
            _isAttacking = true;
            ChangeState(EnemyState._attacking);
        }

        else if( (_attackDistance <= Vector2.Distance(_playerTransform.position, transform.position)) &&(Vector2.Distance(_playerTransform.position, transform.position)<=_detectionDistance))
            //chasing but not attacking
        {
            _playerInRange = true;
            _canAttack = false;
            _isAttacking = false;
            ChangeState(EnemyState._chasing);
        }

        else if (Vector2.Distance(_playerTransform.position, transform.position) > _detectionDistance && _hasTimeLeft)
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

    protected void EnterNewState(EnemyState state)
    {
        switch (_currentState)
        {
            case EnemyState._roaming:
                //when enemy instantiated
                //play the animation. let autoscroller handle the putting in the same line
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

    protected void ChangeState(EnemyState newState)
    {
        _currentState = newState;
        EnterNewState(_currentState);
    }

    protected void Roaming()
    {
        // have it not move and let the autoscroller move it until it gets close enough to player
    }

    protected void Follow()
    {
        //move towards player use lerp maybe

        Vector2 target = _playerTransform.position;

        transform.position = Vector2.Lerp(transform.position, target, _speed * Time.deltaTime);
    }

    protected void AttackTimer()
    {
        _attackDuration -= Time.deltaTime;
        if(_attackDuration <= 0 )
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
