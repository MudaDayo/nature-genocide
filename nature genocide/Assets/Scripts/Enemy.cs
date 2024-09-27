using System;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float _health = 100f;

    [SerializeField] private GameObject _target;
    [SerializeField] private NavMeshAgent _navMeshAgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

            Debug.Log("Attacked");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Attack(collision);
    }

    public virtual void TakeDamage(float damageAmount)
    {
        _health -= damageAmount;

        if (_health <= 0f)
        {
            // To-Do:
            // Drop blood
            // Particle Effect

            Destroy(this.gameObject);
        }
    }
}
