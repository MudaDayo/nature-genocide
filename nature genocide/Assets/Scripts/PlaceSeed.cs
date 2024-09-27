using UnityEngine;

public class PlaceSeed : MonoBehaviour
{
    [SerializeField] Camera _playerCamera;

    public GameObject holdedSeed;
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
        if (Input.GetKeyUp(KeyCode.E) && holdedSeed != null)
        {
            Physics.Raycast(this.transform.position, Vector3.down, out RaycastHit hitInfo);
            Instantiate(holdedSeed, new Vector3(_playerCamera.transform.position.x, 
                hitInfo.collider.transform.position.y + 0.2F, _playerCamera.transform.position.y), Quaternion.identity);

            holdedSeed = null;
        }
    }
}