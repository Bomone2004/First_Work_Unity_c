using UnityEngine;
using UnityEngine.Audio;

public class CollisionsDetector: MonoBehaviour
{
    int collisions = 0;

    #region PointBlock
    int pointsBlock1 = 5;
    int pointsBlock2 = 10;
    int pointsBlock3 = 7;
    int pointsBlock4 = 3;

    int points;
    #endregion

    #region Audio
    private AudioSource cubeSound;
    private AudioSource sphereSound;
    private AudioSource capsuleSound;
    private AudioSource cylinderSound;

    private AudioClip cubeClip;
    private AudioClip sphereClip;
    private AudioClip capsuleClip;
    private AudioClip cylinderClip;
    #endregion

    private void Start()
    {
        //Load Audio Resource
        #region Audio Resource and Clip
        cubeSound = gameObject.AddComponent<AudioSource>();
        sphereSound = gameObject.AddComponent<AudioSource>();
        capsuleSound = gameObject.AddComponent<AudioSource>();
        cylinderSound = gameObject.AddComponent<AudioSource>();

        cubeClip = Resources.Load<AudioClip>("Cube_sound");
        sphereClip = Resources.Load<AudioClip>("Sphere_sound");
        capsuleClip = Resources.Load<AudioClip>("Capsule_sound");
        cylinderClip = Resources.Load<AudioClip>("Cylinder_sound");
        #endregion
    }
    private void OnCollisionEnter(Collision collision)
    {
        collisions++;

        if (collision.gameObject.CompareTag("Block1"))
        {
            points += pointsBlock1;

        }
        else if (collision.gameObject.CompareTag("Block2"))
        {
            points += pointsBlock2;

        }
        else if (collision.gameObject.CompareTag("Block3"))
        {
            points += pointsBlock3;
            
        }
        else if (collision.gameObject.CompareTag("Block4"))
        {
            points += pointsBlock4;
            
        }

        Debug.Log($"Collisions:{collisions} points:{points}");

    }

    private void OnCollisionExit(Collision collision)
    {
        collisions--;

        if (collision.gameObject.CompareTag("Block1"))
        {
            points -= pointsBlock1;
            cubeSound.PlayOneShot(cubeClip);
        }
        else if (collision.gameObject.CompareTag("Block2"))
        {
            points -= pointsBlock2;
            sphereSound.PlayOneShot(sphereClip);
        }
        else if (collision.gameObject.CompareTag("Block3"))
        {
            points -= pointsBlock3;
            capsuleSound.PlayOneShot(capsuleClip);
        }
        else if (collision.gameObject.CompareTag("Block4"))
        {
            points -= pointsBlock4;
            cylinderSound.PlayOneShot(cylinderClip);
        }

        Debug.Log($"Collisons:{collisions} points:{points}");

    }
}
