using UnityEngine;

public class PlaceSeed : MonoBehaviour
{
    [SerializeField] Camera _playerCamera;

    public GameObject seedPot;
    public GameObject previewHoldedSeed;
    private GameObject _previewGameObject;

    private bool _isPreviewing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // holdedSeed = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && seedPot != null)
        {
            Physics.Raycast(_playerCamera.transform.position, Vector3.down, out RaycastHit hitInfo);
            Instantiate(seedPot, new Vector3(_playerCamera.transform.position.x, 
                hitInfo.point.y, _playerCamera.transform.position.y), Quaternion.identity);

            seedPot = null;
        }
    }
}