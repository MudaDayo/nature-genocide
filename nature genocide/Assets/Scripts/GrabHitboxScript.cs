using UnityEditorInternal;
using UnityEngine;

public class GrabHitboxScript : MonoBehaviour
{
    private bool _hasGrabbed;

    private GameObject _directionObject;
    private Vector3 _direction;
    [SerializeField] private float _speed;

    [SerializeField] private GameObject _tempVisual;

    [SerializeField] private float lifeTime = 0.2f;
    private float timer = 0;

    private GameObject[] _droppedSeeds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _droppedSeeds = GameObject.FindGameObjectsWithTag("Seed");

        foreach (var seed in _droppedSeeds) 
        {
            if (Vector3.Distance(this.transform.position, seed.transform.position) < 5f)
            {
                Debug.Log("Seed grabbed");
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.TryGetComponent<PlaceSeed>(out PlaceSeed placeSeedScript);

                //placeSeedScript.seedPot
            }
        }


        //_directionObject = GameObject.FindGameObjectWithTag("SeedSpawnPos");

        //if (_directionObject != null)
        //{
        //}
        //    _direction = _directionObject.transform.position - this.transform.position;
        //    _direction.Normalize();

        //this.transform.parent = null;
    }

    // Update is called once per frame
     void Update()
    {
        //this.transform.position += _direction * _speed * Time.deltaTime;

        //Instantiate(_tempVisual, this.transform.position, Quaternion.identity);

        timer += Time.deltaTime;
        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (_hasGrabbed == false)
    //    {
    //        if (other.gameObject.tag == "Seed")
    //        {
    //            _hasGrabbed = true;

    //            Debug.Log("SeedGrabbed");
    //        }
    //    }
    //}
}
