using UnityEditor.SceneManagement;
using UnityEngine;

public class DestroyOnFall : MonoBehaviour
{
    float timeDestroyObj = 15f;

    void Update()
    {
        //Timer to destry obj
        timeDestroyObj -= Time.deltaTime;

        if (timeDestroyObj <= 0)
        {
            Destroy(gameObject);
        }
        //Destroy ovver PlatForm
        else if (transform.position.y < GameObject.FindWithTag("PlatForm").transform.position.y)
        {
            Destroy(gameObject);
        }

    }
}
