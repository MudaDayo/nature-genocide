using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _minimumDistance;

    // [SerializeField] private GameObject _canSpawnVisual;
    // [SerializeField] private GameObject _cannotSpawnVisual;

    public bool canSpawn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, _player.transform.position) < _minimumDistance)
        {
            canSpawn = false;
            _canSpawnVisual.SetActive(false);
            _cannotSpawnVisual.SetActive(true);
        }

        else
        {
            canSpawn = true;
            _canSpawnVisual.SetActive(true);
            _cannotSpawnVisual.SetActive(false);
        }
    }
}
