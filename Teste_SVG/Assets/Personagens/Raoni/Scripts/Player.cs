using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isFacingRight;
    private CharacterPlatformer2D _controller;
    private float _normalizedHorizontalSpeed;
    private float h_Move;

    public float maxSpeed = 8f;
    public float speedAccelerationOnGround = 10f;
    public float speedAccelerationInAir = 5f;

    [SerializeField] private Animator anim;
    public void Start()
    {
        _controller = GetComponent<CharacterPlatformer2D>();
        _isFacingRight = transform.localScale.x > 0;
    }

    public void Update()
    {
        HandleInput();

        var movementFactor = _controller.State.IsGrounded ? speedAccelerationOnGround : speedAccelerationInAir;
        _controller.SetHorizontalForce(Mathf.Lerp(_controller.Velocity.x, _normalizedHorizontalSpeed * maxSpeed, Time.deltaTime * movementFactor));

        anim.SetBool("IsGrounded", _controller.State.IsGrounded);
        anim.SetFloat("Speed", Mathf.Abs(_controller.Velocity.x) / maxSpeed);
    }

    private void HandleInput()
    {
        h_Move = Input.GetAxisRaw("Horizontal");
        
        if (h_Move > 0f)
        {
            _normalizedHorizontalSpeed = 1;
            if (!_isFacingRight)
                Flip();
        }
        else if (h_Move < 0f)
        {
            _normalizedHorizontalSpeed = -1;
            if (_isFacingRight)
                Flip();
        }
        else
        {
            _normalizedHorizontalSpeed = 0;
        }

        if(_controller.CanJump && Input.GetButtonDown("Jump"))
        {
            
            _controller.Jump();
           
        }

    }

    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
    }
}
