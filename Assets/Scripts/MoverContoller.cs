using UnityEngine;

public class MoverContoller : IPlayerContoller
{
    public float HorizontalAxis => Input.GetAxis("Horizontal") * Time.deltaTime;
    public float VerticalAxis => Input.GetAxis("Vertical") * Time.deltaTime;
    public float JumpAxis => Input.GetAxis("Jump");

    public bool _horizontal, _vertical, _jump, _attack;
   
    public void Horizontal(Transform transform, float _playerSpeed, bool _isHorizondalActive)
    {
        switch (_isHorizondalActive)
        {
            case true:
                transform.position += new Vector3(HorizontalAxis * _playerSpeed, 0);
                break;
            default:
                _isHorizondalActive = false;
                break; 
        }
    }
    public void Vertical(Transform transform, float _climbspeed, bool _isVerticalActive)
    {
        switch (_isVerticalActive)
        {
            case true:
                transform.position += new Vector3(0, VerticalAxis * _climbspeed);
                break;
            default:
                _isVerticalActive = false;
                break;
        }
    }
    public void Jump(Rigidbody2D _rigidbody2D, float _jumpForce, bool _isJumpActive)
    {
        switch (_isJumpActive)
        {
            case true:

                _rigidbody2D.AddForce(Vector2.up * JumpAxis * _jumpForce);
                break;
            default:
                _isJumpActive = false;
                break;
        }
    }

    public void Flip(SpriteRenderer _spriteRenderer, bool _isFlipActive)
    {
        switch (_isFlipActive)
        {
            case true:
                if (HorizontalAxis < 0)
                {
                    _spriteRenderer.flipX = true;

                }
                else if (HorizontalAxis > 0)
                {
                    _spriteRenderer.flipX = false;
                }
                break;
        }
    }
    public void Vertical(Rigidbody2D _rigidbody2D, float _climbspeed, bool _isVerticalActive)
    {
        switch (_isVerticalActive)
        {
            case true:
                _rigidbody2D.velocity = new Vector2(0, VerticalAxis * _climbspeed);
                break;
            default:
                _isVerticalActive = false;
                break;
        }
    }

}
