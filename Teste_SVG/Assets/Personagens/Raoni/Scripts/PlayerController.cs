using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2D;
    private Animator anim;
    private float dir;
    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private Transform _ceilingCheck;
    [SerializeField]
    private float speed;
    [SerializeField]
    private bool jump;
    [SerializeField]
    private bool crouch;
    [SerializeField]
    private bool shoot;
    [SerializeField]
    private LayerMask m_WhatIsGround;
    [SerializeField] private float m_JumpForce;
    [Range(0, 1)] [SerializeField] 
    private float m_CrouchSpeed = .36f;
    [SerializeField]
    private SceneChanger changer;


    const float k_GroundedRadius = .1f;
    const float k_CeilingRadius = .1f;

    // Start is called before the first frame update
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Time.frameCount % 2 == 0)
        {
            dir = Input.GetAxisRaw("Horizontal") * speed;
            anim.SetFloat("Speed", Mathf.Abs(dir));
            Vector3 targetVelocity = new Vector2(dir * 10f, rb2D.velocity.y);
        }
        
        // And then smoothing it out and applying it to the character

    }
}
