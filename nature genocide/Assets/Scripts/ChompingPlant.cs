using UnityEngine;
using UnityEngine.Animations;

public class ChompingPlant : GrownPlant
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _chomperModel, HeartSplatter;

    [SerializeField] private AudioSource purr, CHOMP;



    public bool _canAttack = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            _chomperModel.transform.LookAt(new Vector3(other.transform.position.x,
                transform.position.y, other.transform.position.z));

            if (_canAttack)
            {
                _canAttack = false;

                other.TryGetComponent<Enemy>(out Enemy enemyScript);
                enemyScript.SpawnBloodEffect();

                ChompEnemy(other.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GrabHandHitbox")
        {
            Instantiate(HeartSplatter, transform.position, Quaternion.identity);
            purr.Play();
        }
    }

    private void ChompEnemy(GameObject enemy)
    {
        _animator.SetTrigger("ChompAttack");
        CHOMP.Play();
        Destroy(enemy);
        //To-Do Spawn particles
    }

    public void SetCanAttackTrue()
    {
        Debug.Log("Can Attack");
        _canAttack = true;
    }
}
