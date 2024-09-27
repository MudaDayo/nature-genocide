using UnityEngine;

public class GrownPlant : MonoBehaviour
{
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
    }

    public void FeedPlant(float healAmount)
    {
        _health += healAmount;
    }
}
