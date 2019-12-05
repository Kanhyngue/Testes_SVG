using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool _isFacingRight;
    private float _normalizedHorizontalSpeed;
    private float h_Move;
    private bool Dead = false;
    private bool isNeblina;
    private float _canFireIn, _canMachado, _canDash, _canNeblina, _dashTime, _neblinaTime;

    private CharacterPlatformer2D _controller;
    private DayNightSystem dns;
    private SceneChanger _changer;
    private ControllerPhsyicsVolume2D dash;
    public GameObject [] panels;
    public bool canMove = true;

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
    private GameObject menuPause;

    [SerializeField] 
    private Animator anim;

    [SerializeField] 
    private float velocidadeDash;

    [SerializeField] 
    private ParticleSystem[] _particulasNeblina;

    [SerializeField]
    private Animator boxAnimator;
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

        
        if (!menuPause.activeInHierarchy)
            HandleInput();

        // Se a vida do jogador chegar a zero, ele morre
        if (DataSystem.health <= 0)
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

        anim.SetBool("IsGrounded", _controller.State.IsGrounded);            
        anim.SetFloat("Speed", Mathf.Abs(_controller.Velocity.x) / maxSpeed);
    }


    private void HandleInput()
    {

        if (!_changer.GetPanelState() && !panels[0].activeInHierarchy && 
            !panels[1].activeInHierarchy && !Dead && _canMachado < 0 &&
             _canFireIn < 0 &&!boxAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Open") && 
            !anim.GetBool("Dash") && canMove)
        {

            h_Move = Input.GetAxisRaw("Horizontal");

            if (_controller.CanJump && Input.GetButtonDown("Jump"))
            {
                _controller.Jump();
            }




            if (Input.GetButton("Tiro") && DataSystem.firePower && !anim.GetBool("IsCrouching"))
            {
                if (_canFireIn > 0)
                    return;
                anim.SetTrigger("IsShooting");

                _canFireIn = RateTiro;
            }

            if (Input.GetButton("Machadada") && DataSystem.machadinha && !anim.GetBool("IsCrouching"))
            {
                if (_canMachado > 0)
                    return;
                anim.SetTrigger("Machadada");
                _canMachado = RateMachado;
            }

            if (Input.GetButtonDown("Dash") && DataSystem.dashPower)
            {
                if (_canDash > 0)
                    return;

                if (_isFacingRight)
                {
                    anim.SetBool("Dash", true);
                    _controller.Dashing(dash, velocidadeDash);
                }
                else
                {
                    anim.SetBool("Dash", true);
                    _controller.Dashing(dash, -velocidadeDash);
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

            if (Input.GetButtonDown("Cheat"))
            {
                Debug.Log("Trocou Bedindo");
                DataSystem.fogPower = true;
                DataSystem.firePower = true;
                DataSystem.dashPower = true;
                DataSystem.machadinha = true;
                DataSystem.chave = true;
                DataSystem.health = 1000;
            }

            if (Input.GetButtonDown("Cachimbos"))
            {
                //Debug.Log("Porra Moises");
                switch (DataSystem.cachimbosColetados)
                {
                    case 0:
                        DataSystem.cachimbos[0] = true;
                        DataSystem.cachimbos[1] = true;
                        break;
                    case 2:
                        DataSystem.cachimbos[2] = true;
                        DataSystem.cachimbos[3] = true;
                        break;
                    case 4:
                        DataSystem.cachimbos[4] = true;
                        DataSystem.cachimbos[5] = true;
                        break;
                    case 6:
                        DataSystem.cachimbos[6] = true;
                        DataSystem.cachimbos[7] = true;
                        break;
                    case 8:
                        DataSystem.cachimbos[8] = true;
                        DataSystem.cachimbos[9] = true;
                        break;
                    case 10:
                        DataSystem.cachimbos[10] = true;
                        DataSystem.cachimbos[11] = true;
                        break;
                    case 12:
                        DataSystem.cachimbos[12] = true;
                        DataSystem.cachimbos[13] = true;
                        break;
                    case 14:
                        DataSystem.cachimbos[14] = true;
                        DataSystem.cachimbos[15] = true;
                        break;
                    default:
                        break;
                }

                Debug.Log(DataSystem.cachimbosColetados);
            }

            if (Input.GetButtonDown("Crouch"))
            {
                _controller.Crouch(true);
                anim.SetBool("IsCrouching", true);
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                _controller.Crouch(false);
                anim.SetBool("IsCrouching", false);
            }

            if (Input.GetButtonDown("DayNightCheat"))
            {
                Debug.Log("Mudou o dia BENINO");
                dns.dayTime -= 10;
            }
        }
        else
        {
            h_Move = 0f;
        }
               
        
        
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


        
    }

    private void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Espinhos") && DataSystem.health < 1000)
        {
            DataSystem.health = 0;
        }

        if(col.gameObject.CompareTag("HitInimigo") && DataSystem.health < 1000)
        {
            DataSystem.health -= 1;
            Mathf.Clamp(DataSystem.health, 0, 5);
            anim.SetTrigger("GotHit");
        }

        if (col.gameObject.CompareTag("TiroBand") && DataSystem.health < 1000)
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
                _particulasNeblina[i].Stop();

            }
        }
        yield return null;

    }

    public IEnumerator MoveLeft()
    {
        _controller.SetHorizontalForce(Mathf.Lerp(_controller.Velocity.x, -1 * maxSpeed * DashFactor, Time.deltaTime /** movementFactor*/));
        yield return new WaitForSeconds(1.5f);
        _controller.SetHorizontalForce(Mathf.Lerp(_controller.Velocity.x, 0 * maxSpeed * DashFactor, Time.deltaTime /** movementFactor*/));
    }
}
