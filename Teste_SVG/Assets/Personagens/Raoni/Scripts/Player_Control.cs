using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : MonoBehaviour
{

    public CharacterController2D ctrl;

    public float run_Speed = 40f;

    public Animator anim;

    private float h_Move = 0f;

    private bool jump = false;
    private bool crouch = false;

    [SerializeField] SceneChanger changer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

        if (!changer.GetPanelState())
        {
            h_Move = Input.GetAxisRaw("Horizontal") * run_Speed;
            anim.SetFloat("Speed", Mathf.Abs(h_Move));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                anim.SetBool("IsJumping", jump);
            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }
    }

    private void FixedUpdate()
    {
        ctrl.Move(h_Move * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void IsLanding ()
    {
        anim.SetBool("IsJumping", jump);
    }

    public void IsCrouching(bool isCrouching)
    {
        anim.SetBool("IsCrouching", isCrouching);
    }
}
