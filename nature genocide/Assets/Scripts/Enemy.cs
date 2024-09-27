using System;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 2f;

    [SerializeField] private GameObject _target, normalMesh, hitMesh;

    [SerializeField] private NavMeshAgent _navMeshAgent;

    [SerializeField] private GameObject bloodSplatter, explosion;

    private int hp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = 2;

        _target = GameObject.FindGameObjectWithTag("Player");

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
            // To-Do:
            // Player.CharController push away
            // Player.TakeDamage() method

            //Debug.Log("Attacked");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Attack(collision);

        if (collision.gameObject.tag == "PlayerAttack")
        {
            TakeDamage();
            Instantiate(bloodSplatter, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);

            normalMesh.SetActive(false);
            hitMesh.SetActive(true);

            //Debug.Log("Attacked");
        }

    }

    void Die()
    {
        Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void TakeDamage()
    {
        _health -= 1;

        Debug.Log(_health);

        if (_health <= 0f)
        {
            Die();
        }
    }

    public virtual void TakeDamage(float damageAmount)
    {
        _health -= 1;

        if (_health <= 0f)
        {
            Die();
        }
    }
}
