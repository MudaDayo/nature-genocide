using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Billboard : MonoBehaviour
{
    private void Start()
    {
        GameObject _target = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(_target.transform.position);
    }
}
