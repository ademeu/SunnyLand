using UnityEngine;

public class AtesSapawner : MonoBehaviour
{
    [SerializeField] GameObject _atesSpawner, _Parent;
    [Range(0, 5)] [SerializeField] float _atesEtmeSuresi;
    float _currentTime;

    private void Start()
    {
        _currentTime = _atesEtmeSuresi;
    }

    private void FixedUpdate()
    {
        _currentTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(1) && _currentTime > _atesEtmeSuresi)
        {
            FireEtme();
        }
    }
    void FireEtme()
    {
        var ates = Instantiate(_atesSpawner, transform.position, transform.rotation,_Parent.transform);

        ates.GetComponent<AtesController>().Go(!GetComponentInParent<SpriteRenderer>().flipX);
        _currentTime = 0;
    }
}
