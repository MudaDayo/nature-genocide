using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField] private GameObject _grownPlant;
    private bool _grownPlantHasGrown;

    [SerializeField] private float _health;
    [SerializeField] private float _healthDecaySpeed;

    [SerializeField] private BoxCollider _collider;
    [SerializeField] private Rigidbody _rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_collider == null)
        {
            _collider = GetComponent<BoxCollider>();
        }

        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        _health -= _healthDecaySpeed * Time.deltaTime;

        if (_health <= 0f)
        {
            Destroy(this);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "BloodDrop" && _grownPlantHasGrown == false)
        {
            _grownPlantHasGrown = true;
            Debug.Log("Plant Fed");
            Destroy(_rb);
            Destroy(_collider);

            FeedPlant();
        }
    }


    public void FeedPlant()
    {
        // Gets called from enemy
        Instantiate(_grownPlant, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
