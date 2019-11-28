using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isFacingRight;
    private CharacterPlatformer2D _controller;
    private float _normalizedHorizontalSpeed;
    private float h_Move;
    private ControllerPhsyicsVolume2D dash;
    private bool Dead = false;
    private bool isDashing = false;

    public float maxSpeed = 8f;
    public float DashFactor = 2f;
    public float DashTime = 2f;
    public float NeblinaTime = 2f;
    public float speedAccelerationOnGround = 10f;
    public float speedAccelerationInAir = 5f;
    private GameObject changer;
    private SceneChanger _changer;
    public float RateTiro = .5f;
    public float RateMachado = .5f;
    public float RateDash = 2f;
    public float RateNeblina = 2f;

    [SerializeField] private Animator anim;
    [SerializeField] private float velocidadeDash;
    [SerializeField] private ParticleSystem[] _particulasNeblina;
    private float _canFireIn, _canMachado, _canDash, _canNeblina, _dashTime, _neblinaTime;


    public void Start()
    {
        _dashTime = DashTime;
        _neblinaTime = NeblinaTime;
        _canMachado = RateMachado;
        _canFireIn = RateTiro;
        dash = GetComponent < ControllerPhsyicsVolume2D > ();
        _controller = GetComponent<CharacterPlatformer2D>();
        _isFacingRight = transform.localScale.x > 0;
        changer = GameObject.FindWithTag("SceneChanger");
        if (changer != null)
            _changer = changer.GetComponent<SceneChanger>();
            
    }

    public void Update()
    {
        _canFireIn -= Time.deltaTime;
        _canMachado -= Time.deltaTime;
        _canDash -= Time.deltaTime;
        _canNeblina -= Time.deltaTime;

      /*  Debug.Log(NeblinaTime);*/
        //Debug.Log(_controller.State.IsNeblina);

        if (!_changer.GetPanelState() && _canMachado < 0 && !Dead )
        {
            HandleInput();
        }

        if (isDashing)
        {
            _neblinaTime -= Time.deltaTime;
            if (_neblinaTime <= 0)
            {
                _neblinaTime = NeblinaTime;
                _controller.EntraNeblina();
                isDashing = false;
                ToggleNeblina();
            }
        }


        if (!anim.GetBool("Dash"))
        {
            var movementFactor = _controller.State.IsGrounded ? speedAccelerationOnGround : speedAccelerationInAir;
            _controller.SetHorizontalForce(Mathf.Lerp(_controller.Velocity.x, _normalizedHorizontalSpeed * maxSpeed, Time.deltaTime * movementFactor));
        }
        else
        {
            _dashTime -= Time.deltaTime;
            _controller.SetHorizontalForce(Mathf.Lerp(_controller.Velocity.x, _normalizedHorizontalSpeed * maxSpeed * DashFactor, Time.deltaTime /** movementFactor*/));
            if(_dashTime <= 0)
            {
                anim.SetBool("Dash", false);
                _controller.EndDash(dash);
                _dashTime = DashTime;
            }
        }

        /*if(_canMachado < 0 && !isDashing)
        {
            _controller.EndDash(dash);
        }*/

        anim.SetBool("IsGrounded", _controller.State.IsGrounded);            
        anim.SetFloat("Speed", Mathf.Abs(_controller.Velocity.x) / maxSpeed);
    }

    private void HandleInput()
    {
        if(!anim.GetBool("Dash"))
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

        if (Input.GetButtonDown("Crouch"))
        {
            _controller.Crouch(true);
            anim.SetBool("IsCrouching", true);
        }else if (Input.GetButtonUp("Crouch"))
        {
            _controller.Crouch(false);
            anim.SetBool("IsCrouching", false);
        }

        if(Input.GetButton("Tiro") && DataSystem.firePower)
        {
            if (_canFireIn > 0)
                return;
            anim.SetTrigger("IsShooting");
  
            _canFireIn = RateTiro;
        }

        if (Input.GetButton("Machadada"))
        {
            if (_canMachado > 0)
                return;
            //_controller.Dashing(dash, 0f);
            anim.SetTrigger("Machadada");
            _canMachado = RateMachado;
        }

        if (Input.GetButtonDown("Dash") && DataSystem.dashPower)
        {
            if (_canDash > 0)
                return;
            
            if(_isFacingRight)
            {
                anim.SetBool("Dash", true);
                _controller.Dashing (dash, velocidadeDash);
            }
            else
            {
                anim.SetBool("Dash", true);
                _controller.Dashing (dash, -velocidadeDash);
            }
            _canDash = RateDash;            
        }

        if (Input.GetButtonDown("Neblina") && DataSystem.fogPower)
        {
            if (_canNeblina > 0)
                return;
            _controller.EntraNeblina();
            isDashing = true;
            _canNeblina = RateNeblina;
            _neblinaTime = NeblinaTime;
            ToggleNeblina();
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
    }

    private void ToggleNeblina()
    {
        if(isDashing)
        {
            for(int i = 0; i < _particulasNeblina.Length; i++)
            {
                _particulasNeblina[i].Play();
            }
        }
        else
        {
            for (int i = 0; i < _particulasNeblina.Length; i++)
            {
                _particulasNeblina[i].Stop();
            }
        }
    }
}
