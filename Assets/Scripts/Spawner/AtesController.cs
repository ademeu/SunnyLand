using UnityEngine;

public class AtesController : MonoBehaviour
{
    
    private Vector3 goPos = Vector3.right;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + goPos , Time.deltaTime * 10f);
       
    }
    public void Go(bool right)
    {
        if (right == false)
            goPos *= -1;
    }

    private void OnTriggerEnter2D(Collider2D collision) //  ateþ kursbaga dokundugunda ýlk kurbaga yok oluyor sonra ateþ yok oluyor ýkýsýnde de ýs trýger ýsaretlý.
    {
        if (collision.gameObject.CompareTag("Kurbag") || collision.gameObject.CompareTag("Kartal"))
        {
            Destroy(collision.gameObject);

            GameManager.AddKScore?.Invoke(1); // kurbag oldugunde scoru tutuyor.

            Destroy(this.gameObject);
        }
    }
}