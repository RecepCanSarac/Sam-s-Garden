using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SOPlayer playerData;

    private Rigidbody2D rb;
    private Animator _animator;
    Vector2 movement;
    float _speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _speed = playerData.Speed;
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        _animator.SetFloat("Horizontal", movement.x);
        _animator.SetFloat("Vertical", movement.y);
        _animator.SetFloat("speed", movement.sqrMagnitude);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * _speed * Time.fixedDeltaTime);
    }

}
