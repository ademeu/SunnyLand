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

    private void OnTriggerEnter2D(Collider2D collision) //  ate� kursbaga dokundugunda �lk kurbaga yok oluyor sonra ate� yok oluyor �k�s�nde de �s tr�ger �saretl�.
    {
        if (collision.gameObject.CompareTag("Kurbag") || collision.gameObject.CompareTag("Kartal"))
        {
            Destroy(collision.gameObject);

            GameManager.AddKScore?.Invoke(1); // kurbag oldugunde scoru tutuyor.

            Destroy(this.gameObject);
        }
    }
}