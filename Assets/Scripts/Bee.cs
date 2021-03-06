﻿using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Bee : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamageHandler()
    {
        _animator.SetTrigger("Damage");
    }

    public void DeathHandler()
    {
        _animator.SetTrigger("Death");
        Destroy(gameObject, 2f);
    }
}
