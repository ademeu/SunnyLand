using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartalController : MonoBehaviour
{
    [Range(1,9)] [SerializeField] float _kartalSpeed;
    Rigidbody2D _rb;
    [Range(1, 20)] [SerializeField] float _minHeight, _maxHeight;
    [SerializeField] LayerMask lm;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = new Vector2(0f, _kartalSpeed);
    }
    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 8f,lm);

        if (hit.collider != null)
        {
            if (hit.distance <= _minHeight)
            {
                _rb.velocity = new Vector2(0f, _kartalSpeed);
            }
            else if (hit.distance >= _maxHeight)
            {
                _rb.velocity = new Vector2(0f, -_kartalSpeed);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
