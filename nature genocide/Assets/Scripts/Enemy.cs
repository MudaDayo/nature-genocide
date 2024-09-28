using System;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;


public class Enemy : MonoBehaviour
{
    [SerializeField] public float _health = 2f;

    [SerializeField] private GameObject _target, normalMesh, hitMesh, runAnimationMesh;

    [SerializeField] private GameObject _bloodDrop, hpManager;
    [SerializeField] private GameObject _bloodDropSpawnPos;

    [SerializeField] private NavMeshAgent _navMeshAgent;

    [SerializeField] private GameObject bloodSplatter, explosion, redPanel;

    [SerializeField]
    private float knockbackForce, knockbackTime, deathTime, knockupForce;

    public bool eaten;
    public bool knockback, dying;
    private float timer;
    private int hp;

    private bool redBool;
    private float redPanelTimer;
    private float redPanelMaxtime;

    private GameObject UIManager;

    private Rigidbody rb;

    [SerializeField] private AudioClip _screamOfAgony, _yeahh, _ballSqueeze, _ohGod, _yell;
    private AudioSource _audioSource;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        redPanelMaxtime = 0.2f;
        eaten = false;
        rb = this.GetComponent<Rigidbody>();

        transform.localScale *= UnityEngine.Random.Range(0.5f, 1f);
        hp = 2;

        _target = GameObject.FindGameObjectWithTag("Player");

        hpManager = GameObject.Find("HeartManager");

        UIManager = GameObject.FindGameObjectWithTag("UIManager");

        if (_navMeshAgent == null)
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        _audioSource = GetComponent<AudioSource>();

        normalMesh.SetActive(false);
        runAnimationMesh.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (redBool)
        {
            redPanelTimer += Time.deltaTime;
        }
        if (redPanelTimer > redPanelMaxtime)
        {
            redBool = false;
            UIManager.GetComponent<redPanel>().Disable();
        }

        if (knockback || dying)
        {
            timer += Time.deltaTime;
        }
        if(timer > deathTime)
        {

            Die();
        }

        /*if (timer > knockbackTime && knockback)
        {
            _navMeshAgent.enabled = true;
        }*/
        else if (!knockback)
        {
            _navMeshAgent.destination = _target.transform.position;
            this.transform.LookAt(new Vector3(_target.transform.position.x,
                  transform.position.y, _target.transform.position.z));
        }
       
    }

    private void Attack(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && dying == false)
        {
            UIManager.GetComponent<redPanel>().Enable();
            redBool = true;

            hpManager.GetComponent<PlayerHP>().LoseHP();
            collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3 (0f, knockupForce, 0f));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.tag == "Player")
        {
            _audioSource.clip = _yeahh;
            _audioSource.Play();
        }   
    }
    private void OnCollisionEnter(Collision collision)
    {
        Attack(collision);

        if (collision.gameObject.tag == "PlayerAttack")
        {
            _navMeshAgent.enabled = false;
            int random = UnityEngine.Random.Range(0, 10);

             if (random ==  1)
             {
                _audioSource.clip = _ballSqueeze;
                _audioSource.volume = 10000;
                _audioSource.Play();
             }
            else if (random >= 2 && random <= 4)
            {
                _audioSource.clip = _screamOfAgony;
                _audioSource.volume = 10000;
                _audioSource.Play();
            } else if (random >= 5 && random <= 7)
            {
                _audioSource.clip = _ohGod;
                _audioSource.volume = 1000;
                _audioSource.Play();
            } else
            {
                _audioSource.clip = _yell;
                _audioSource.volume = 1000;
                _audioSource.Play();
            }
            
            _audioSource.volume = 10000;
            _audioSource.Play();
            knockback = true;
            dying = true;
            rb.linearVelocity = Vector3.zero;

            rb.AddForce((transform.position - collision.transform.position) * knockbackForce);

            TakeDamage();
            SpawnBloodEffect();

            runAnimationMesh.SetActive(false);
            hitMesh.SetActive(true);
        }
    }

    public void SpawnBloodEffect()
    {
        Instantiate(_bloodDrop, _bloodDropSpawnPos.transform.position, Quaternion.identity);
        Instantiate(bloodSplatter, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
    }

    public void Die()
    {
        //UIManager.GetComponent<killCountManager>().AddKill();

        if (!eaten)
        {
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        }

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
