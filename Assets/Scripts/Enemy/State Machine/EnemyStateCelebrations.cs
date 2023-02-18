using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyStateCelebrations : EnemyState
{
    private Animator _animator;
    // Start is called before the first frame update
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        _animator.Play("MinotaurCelebrations");
    }

    private void OnDisable()
    {
        _animator.StartPlayback();
    }
}
