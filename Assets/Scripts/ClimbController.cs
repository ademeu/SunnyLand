using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbController : MonoBehaviour
{
   
    [SerializeField] GameObject _player;
    [SerializeField] Animator _animator;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] PlayerController _playercontroller;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _playercontroller.Climb();
            _rb.gravityScale = 0;
            PlayerController._isVerticalActive = true;
            PlayerController._isJumpActive = true;
            
            _animator.SetBool("__isClimb", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _rb.gravityScale = 1;
        PlayerController._isFlipActive = true;
        PlayerController._isVerticalActive = false;
        _animator.SetBool("__isClimb", false);
    }
}
