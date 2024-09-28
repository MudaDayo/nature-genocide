using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Billboard1 : MonoBehaviour
{
    private GameObject _target;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        transform.LookAt(_target.transform.position);
    }
}
