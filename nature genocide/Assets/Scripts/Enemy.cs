using System;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 2f;

    [SerializeField] private GameObject _target, normalMesh, hitMesh;

    [SerializeField] private GameObject _bloodDrop, hpManager;
    [SerializeField] private GameObject _bloodDropSpawnPos;

    [SerializeField] private NavMeshAgent _navMeshAgent;

    [SerializeField] private GameObject bloodSplatter, explosion;

    [SerializeField]
    private float knockbackForce;

    private int hp;

    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        transform.localScale *= UnityEngine.Random.Range(0.5f, 1f);
        hp = 2;

        _target = GameObject.FindGameObjectWithTag("Player");

        hpManager = GameObject.Find("HeartManager");

        if (_navMeshAgent == null)
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent.destination = _target.transform.position;
        this.transform.LookAt(new Vector3(_target.transform.position.x,
               transform.position.y, _target.transform.position.z));
    }

    private void Attack(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hpManager.GetComponent<PlayerHP>().LoseHP();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Attack(collision);

        if (collision.gameObject.tag == "PlayerAttack")
        {
            rb.linearVelocity = Vector3.zero;

            rb.AddForce((transform.position - collision.transform.position) * knockbackForce);

            TakeDamage();
            SpawnBloodEffect();

            normalMesh.SetActive(false);
            hitMesh.SetActive(true);
        }
    }

    public void SpawnBloodEffect()
    {
        Instantiate(_bloodDrop, _bloodDropSpawnPos.transform.position, Quaternion.identity);
        Instantiate(bloodSplatter, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
    }

    void Die()
    {
        Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        Destroy(this.gameObject);
    }

    public virtual void TakeDamage()
    {
        _health -= 1;

        Debug.Log(_health);


        if (_health <= 0f)
        {
            Die();
        }
    }
}
