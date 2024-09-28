using UnityEngine;

public class Seed : MonoBehaviour
{
    [SerializeField] private GameObject _grownPlant;
    [SerializeField] private float _health;
    [SerializeField] private float _healthDecaySpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

    public void FeedPlant()
    {
        // Gets called from enemy
        Instantiate(_grownPlant);
        Destroy(this.gameObject);
    }
}
