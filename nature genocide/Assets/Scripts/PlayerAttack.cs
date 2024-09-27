using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Camera playerCam;

    [SerializeField]
    private GameObject attackPrefab, shovel;

    private Vector3 initialShovelPos;

    private float timer;

    private bool attacking;

    [SerializeField]
    private float attackTimer;
    private void Start()
    {
        initialShovelPos = transform.position - shovel.transform.position;
        timer = 0f;
    }

    void Update()
    {
        if (attacking)
        {
            timer += Time.deltaTime;
        }
        else
        {
            shovel.transform.position = this.transform.position;
        }

        if (Input.GetMouseButtonDown(0) && !attacking)
        {
            shovel.transform.position += Camera.main.transform.forward.normalized * 2;
            Instantiate(attackPrefab, transform.position, Quaternion.identity);
            attacking = true;
            timer = 0f;
        }

        if(timer >= attackTimer)
        {
            attacking = false;
        }
    }
}
