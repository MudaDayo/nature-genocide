using UnityEngine;

public class NATURE : MonoBehaviour
{
    [SerializeField]
    private AudioSource nature;

    [SerializeField]
    private AudioClip annihilation;
    [SerializeField]
    private AudioClip extinction;
    [SerializeField]
    private AudioClip faceThePain;
    [SerializeField]
    private AudioClip someOtherSound;
    [SerializeField]
    private AudioClip natureClip;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            nature.clip = natureClip;
            nature.Play();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            nature.clip = annihilation;
            nature.Play();
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            nature.clip = extinction;
            nature.Play();
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            nature.clip = faceThePain;
            nature.Play();
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            nature.clip = someOtherSound;
            nature.Play();
        }
    }
}
