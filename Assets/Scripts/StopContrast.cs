using UnityEngine;

public class StopContrast : MonoBehaviour
{
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    //Freez Obj 
    public void OnCollisionEnter(Collision collision)
    {
        // If have detected a collisions
        if (_rb.detectCollisions)
        {
            // Do only have detected same Tag
            if (collision.gameObject.tag == _rb.tag)
            {   
                //Ignore collision with PlatForm
                if (!collision.gameObject.CompareTag("PlatForm"))
                {
                    _rb.constraints = RigidbodyConstraints.FreezeAll;
                    Debug.Log("Do");
                }
            }
        }
    }
}
