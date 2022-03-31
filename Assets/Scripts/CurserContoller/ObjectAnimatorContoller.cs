using UnityEngine;

public class ObjectAnimatorContoller : MonoBehaviour
{
    [SerializeField] Animator _Treeanim;
    [SerializeField] Animator _Houseanim;
    bool _onClick;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _onClick = true;
        }
    }
    private void FixedUpdate()
    {
        if (CursorController._currentTag == "Tree" && _onClick)
        {
            _Treeanim.Play("Tree");
            _onClick = false;
        }
        else if (CursorController._currentTag == "Home" && _onClick)
        {
            _Houseanim.Play("Home");
            _onClick = false;
        }
    }
}
