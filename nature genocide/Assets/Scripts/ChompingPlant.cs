using UnityEngine;
using UnityEngine.Animations;

public class ChompingPlant : GrownPlant
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _chomperModel;

    public bool _canAttack = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            _chomperModel.transform.LookAt(new Vector3(other.transform.position.x, 
                transform.position.y, other.transform.position.z));
            ChompEnemy(other.gameObject);
        }
    }

    private void ChompEnemy(GameObject enemy)
    {
        _animator.SetTrigger("ChompAttack");
        Destroy(enemy);
        //To-Do Spawn particles
    }

    public void SetCanAttackTrue()
    {
        _canAttack = true;
    }
}
