using UnityEngine;

public class MeteoriteDamageCollider : MonoBehaviour
{
    [SerializeField] private float _lifeTime;
    private float _timer;

    private GameObject UIManager;
    [SerializeField] private GameObject hpManager;

    [SerializeField] private float _knockupForce;

    private bool _hasCheckedTrigger = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hpManager = GameObject.Find("HeartManager");

        UIManager = GameObject.FindGameObjectWithTag("UIManager");
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_hasCheckedTrigger == false)
        {
            _hasCheckedTrigger = true;

            if (other.gameObject.tag == "Player")
            {
                UIManager.GetComponent<redPanel>().Enable();

                hpManager.GetComponent<PlayerHP>().LoseHP();
                other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, _knockupForce, 0f));
            }

            if (other.gameObject.tag == "Enemy")
            {
                other.TryGetComponent<Enemy>(out Enemy enemyScript);
                enemyScript.Die();
            }
        }
    }
}
