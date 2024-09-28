using UnityEngine;

public class NATURE : MonoBehaviour
{
    [SerializeField]
    private AudioSource nature;

    private void Update()
    {
        if (Input.GetButtonDown("E"))
        {
            nature.Play();
        }
    }
}
