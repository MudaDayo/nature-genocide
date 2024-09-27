using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Camera playerCam;

    [SerializeField]
    private GameObject attackPrefab;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(attackPrefab, transform.position, Quaternion.identity);
        }
    }
}
