using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    MoverContoller _moverController;
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;
    Animator _animator;
    CursorController _cursorController;

    [SerializeField] float _forceSpeed, _moveSpeed, _climbSpeed;
    float carpan = 2;
    
    [SerializeField]  bool _isSpaceControl;
    public static bool _isFlipActive = true;
    public static bool _isHortizantalActive = true;
    public static bool _isVerticalActive = true;
    public static bool _isJumpActive = true;

    OnGround _onGround;
    [SerializeField] Text _textSayac;

    private void Awake()
    {
        AwakeReferanslar();
    }
    void AwakeReferanslar()
    {
        _moverController = new MoverContoller();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _onGround = GetComponent<OnGround>();
        _cursorController = GetComponent<CursorController>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _isSpaceControl = true;
        }
    }
    private void FixedUpdate()
    {
        Walk();
        Jump();
        Flip(); 
    }
    void Walk()
    {
        _moverController.Horizontal(this.transform, _moveSpeed, _isHortizantalActive);
        _animator.SetFloat("__isWalk", Mathf.Abs(Input.GetAxis("Horizontal")));
    }
    void Jump()
    {
        if (_onGround.IsOnGround && _isSpaceControl)
        {
            #region 12 çilek topladýgýnda playerýn zýplama kuveeti artýyor.
            if (GameManager.ReturnScore?.Invoke() >= 1 && _forceSpeed > carpan)
            {
                _forceSpeed *= carpan;
                carpan = _forceSpeed + 1;
            }
            
            #endregion
            _moverController.Jump(_rigidbody2D, _forceSpeed, _isJumpActive);
        }
        _animator.SetBool("__isJump", !_onGround.IsOnGround);
        _isSpaceControl = false;
    }
    void Flip()
    {
         _moverController.Flip(_spriteRenderer, _isFlipActive); 
    }
    public void Climb()
    {
        _moverController.Vertical(_rigidbody2D, _climbSpeed, _isVerticalActive);
    }

    private void OnCollisionEnter2D(Collision2D collision) // player cýlege dokundugunda cýlegý alýyor ýkýsýde ýs trýgerý yok
    {      
        if (collision.gameObject.CompareTag("cilek"))
        {
            Destroy(collision.gameObject);

            GameManager.AddScore?.Invoke(1);
            _textSayac.text = GameManager.ReturnScore?.Invoke().ToString();
        }  
    }
    private void OnTriggerEnter2D(Collider2D collision) // player kurbaga dokundugunda oluyor playerde ýs trýger yok kurbagda var.
    {
        if (collision.gameObject.CompareTag("Kurbag"))
        {
            Destroy(this.gameObject);
        }
    }

}
