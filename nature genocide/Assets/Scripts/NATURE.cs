using UnityEngine;

public class NATURE : MonoBehaviour
{
    [SerializeField]
    private AudioSource nature;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            nature.Play();
        }
    }
}
