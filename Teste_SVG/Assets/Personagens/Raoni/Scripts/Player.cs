using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isFacingRight;
    private float _normalizedHorizontalSpeed;
    private float h_Move;
    private bool Dead = false;
    private bool isNeblina, isMachado = false;
    private float _canFireIn, _canMachado, _canDash, _canNeblina, _dashTime, _neblinaTime;

    private CharacterPlatformer2D _controller;
    private DayNightSystem dns;
    private SceneChanger _changer;
    private ControllerPhsyicsVolume2D dash;
    public GameObject panel;

    public float maxSpeed = 8f;
    public float DashFactor = 2f;
    public float DashTime = 2f;
    public float NeblinaTime = 2f;
    public float speedAccelerationOnGround = 10f;
    public float speedAccelerationInAir = 5f;    
    public float RateTiro = .5f;
    public float RateMachado = .5f;
    public float RateDash = 2f;
    public float RateNeblina = 2f;

    [SerializeField] 
    private Animator anim;

    [SerializeField] 
    private float velocidadeDash;

    [SerializeField] 
    private ParticleSystem[] _particulasNeblina;

    [SerializeField]
    private GameObject Pool;
    public static bool gameOver = false;

    [Range(1, 5)]
    [SerializeField]
    private float playbackspeed;

    public void Start()
    {
        _dashTime = DashTime;
        _neblinaTime = NeblinaTime;
        _canMachado = RateMachado;
        _canFireIn = RateTiro;

        _isFacingRight = transform.localScale.x > 0;

        GameObject _dns;
        _dns = GameObject.FindWithTag("DNS");
        dns = _dns.GetComponent<DayNightSystem>();
        _dns = GameObject.FindWithTag("SceneChanger");
        if (dns != null)
            _changer = _dns.GetComponent<SceneChanger>();

        //panel = GameObject.FindWithTag("MsgBase");
        dash = GetComponent<ControllerPhsyicsVolume2D>();
        _controller = GetComponent<CharacterPlatformer2D>();
    }

    public void Update()
    {
        _canFireIn -= Time.deltaTime;
        _canMachado -= Time.deltaTime;
        _canDash -= Time.deltaTime;
        _canNeblina -= Time.deltaTime;

      /*  Debug.Log(NeblinaTime);*/
        //Debug.Log(_controller.State.IsNeblina);

        // Se o Jogador não estiver atacando com o machado, não estiver morto, e não estiver em algum menu ou interface então os controles ficam habilitados
        if (!_changer.GetPanelState() && !panel.activeInHierarchy  && !Dead && _canMachado < 0 )
        {
            HandleInput();
        }

        // Se a vida do jogador chegar a zero, ele morre
        if(DataSystem.health <= 0)
        {
            Dead = true; // Booleana que verifica a morte
            anim.SetBool("IsDead", true); // Animação de morte ativada
            gameOver = true;
        }

        // 
        if (isNeblina)
        {
            _neblinaTime -= Time.deltaTime;
            if (_neblinaTime <= 0)
            {
                _neblinaTime = NeblinaTime;
                _controller.EntraNeblina();
                isNeblina = false;
                StartCoroutine(ToggleNeblina());
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

    public void LateUpdate()
    {
        if (isMachado)
        {
            _controller.SetForce(Vector2.zero);
            anim.SetTrigger("Machadada");
            _canMachado = RateMachado;
            isMachado = false;
        }
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

        if(Input.GetButton("Tiro") && DataSystem.firePower && !anim.GetBool("IsCrouching"))
        {
            if (_canFireIn > 0)
                return;
            anim.SetTrigger("IsShooting");
  
            _canFireIn = RateTiro;
        }

        if (Input.GetButton("Machadada") && !anim.GetBool("IsCrouching"))
        {
            if (_canMachado > 0)
                return;
            //_controller.Dashing(dash, 0f);
            /*            _controller.SetForce(Vector2.zero);
                        anim.SetTrigger("Machadada");
                        _canMachado = RateMachado;*/
            isMachado = true;
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
            isNeblina = true;
            _canNeblina = RateNeblina;
            _neblinaTime = NeblinaTime;
            StartCoroutine(ToggleNeblina());
        }

        if(Input.GetButtonDown("Cheat"))
        {
            Debug.Log("Trocou Bedindo");
            DataSystem.fogPower = !DataSystem.fogPower;
            DataSystem.firePower = !DataSystem.firePower;
            DataSystem.dashPower = !DataSystem.dashPower;

        }

        if (Input.GetButtonDown("Cachimbos"))
        {
            Debug.Log("Porra Moises");
            DataSystem.cachimbos += 2;
        }

        if (Input.GetButtonDown("DayNightCheat"))
        {
            Debug.Log("Mudou o dia BENINO");
            dns.dayTime -= 10;
        }
    }

    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
    }

    /*private void ToggleNeblina()
    {
        if(isNeblina)
        {
            for(int i = 0; i < _particulasNeblina.Length; i++)
            {

                var main = _particulasNeblina[i].main;
                main.simulationSpeed = playbackspeed;

                _particulasNeblina[i].Play();

                


            }

            StartCoroutine(SimulatePart());
        }
        else
        {
            for (int i = 0; i < _particulasNeblina.Length; i++)
            {
                //_particulasNeblina[i].transform.position = Pool.transform.position;
                _particulasNeblina[i].Stop();
                
            }
        }
    }*/

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Espinhos"))
        {
            DataSystem.health = 0;
        }

        if(col.gameObject.CompareTag("HitInimigo"))
        {
            DataSystem.health -= 1;
            Mathf.Clamp(DataSystem.health, 0, 5);
            anim.SetTrigger("GotHit");
        }
    }

    IEnumerator SimulatePart()
    {
        yield return new WaitForSeconds(.5f);
        for (int i = 0; i < _particulasNeblina.Length; i++)
        {
            var main = _particulasNeblina[i].main;
            main.simulationSpeed = 1;
            //_particulasNeblina[i].transform.position = Pool.transform.position;
            //_particulasNeblina[i].Simulate(1f);
            //_particulasNeblina[i].Clear();
        }
        yield return null;
    }

    IEnumerator ToggleNeblina()
    {
        if (isNeblina)
        {
            for (int i = 0; i < _particulasNeblina.Length; i++)
            {

                var main = _particulasNeblina[i].main;
                main.simulationSpeed = playbackspeed;

                _particulasNeblina[i].Play();




            }

            StartCoroutine(SimulatePart());
        }
        else
        {
            for (int i = 0; i < _particulasNeblina.Length; i++)
            {
                //_particulasNeblina[i].transform.position = Pool.transform.position;
                _particulasNeblina[i].Stop();

            }
        }
        yield return null;

    }
}
