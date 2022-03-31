using UnityEngine;

public class CursorController : MonoBehaviour
{
   
    [SerializeField] Texture2D[] _defaultCursor;
    
    public static string  _currentTag;
    
    RaycastHit2D _hit;

    private void Update()
    {
        FindCursor();
    }
    void FindCursor()
    {
        string returntag = MouseHitResualt();
        if (returntag == _currentTag)
            return; //şart sağlanıyorsa alta hıc ınmıyor.. 

        switch (returntag)
        {
            case "Tree":
                SelecetCursor((int)CursorType.Balta, returntag);
                break;
            case "Home":
                SelecetCursor((int)CursorType.Kapi, returntag);
                break;
            default:
                SelecetCursor((int)CursorType.Default, returntag);
                break;
        }
    }
    private void SelecetCursor(int _selectCursorArray, string tag)
    {
        Cursor.SetCursor(_defaultCursor[_selectCursorArray], Vector3.zero, CursorMode.Auto);
        _currentTag = tag;
    }
    private string MouseHitResualt()
    {
         _hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.one);

        string _result = " ";
        if (_hit.collider != null)
        {
            _result = _hit.collider.gameObject.tag;
        }
        return _result;
    }
}

public enum CursorType
{
    Default = 0,
    Balta = 1,
    Kazma = 2,
    Kapi = 3,
}