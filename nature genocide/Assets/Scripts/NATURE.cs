using UnityEngine;

public class NATURE : MonoBehaviour
{
    [SerializeField]
    private AudioSource nature;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            nature.Play();
        }
    }
}
