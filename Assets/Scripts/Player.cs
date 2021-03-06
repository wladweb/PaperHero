﻿using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioClip))]
public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent CoinCollected;

    private Animator _animator;
    private AudioClip _deathSound;
    private Jumper _jumper;
    private Mover _mover;
    private Shooter _shooter;
    private float _currentDirection = 1;
    private float _animDirection;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _jumper = GetComponent<Jumper>();
        _mover = GetComponent<Mover>();
        _shooter = GetComponent<Shooter>();
        _deathSound = GetComponent<AudioSource>().clip;
    }

    private void Update()
    {
        Move();
        Jump();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _shooter.Shoot(_animDirection);
        }
    }

    private void Move()
    {
        float direction = Input.GetAxisRaw("Horizontal");

        _mover.Move(direction, out float movementMagnitude);

        if (direction == 0)
        {
            direction = _currentDirection;
        }
        else
        {
            _currentDirection = direction;
        }
        
        _animDirection = direction;

        _animator.SetFloat("Direction", direction);
        _animator.SetFloat("Speed", movementMagnitude);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _jumper.Jump(true);
            _animator.ResetTrigger("Land");
            _animator.SetTrigger("Jump");
        }
        else if (Input.GetButtonUp("Jump"))
        {
            _animator.ResetTrigger("Jump");
            _animator.SetTrigger("Land");
        }
    }

    public void TakeDamageHandler()
    {
        _animator.SetTrigger("Damage");
    }

    public void DeathHandler()
    {
        _animator.SetTrigger("Death");
        AudioSource.PlayClipAtPoint(_deathSound, transform.position);
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            coin.gameObject.SetActive(false);
            CoinCollected.Invoke();
        }
    }
}
