using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    // Dizi olmasının nedeni, Sprite'ın ayaklarında birden fazla transformu(yoklayıcı) olmasıdır.

    [SerializeField] Transform[] _translates;

    [SerializeField] bool _isOnGround = false;
    [SerializeField] float _maxDistance;
    [SerializeField] LayerMask _layerMask;

    public bool IsOnGround => _isOnGround;

    private void Update()
    {
        foreach (Transform footTransform in _translates)
        {
            CheckFootOnGround(footTransform);

            if (_isOnGround) break;
           
        }
    }
    void CheckFootOnGround(Transform footTransform)
    {
        RaycastHit2D hit = Physics2D.Raycast(footTransform.position, footTransform.forward, _maxDistance, _layerMask);

        Debug.DrawRay(footTransform.position, footTransform.forward * _maxDistance, Color.yellow);

        if (hit.collider != null)
        {
            _isOnGround = true;
        }
        else
        {
            _isOnGround = false;
        }
    }
}
