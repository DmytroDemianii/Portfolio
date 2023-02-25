using UnityEngine;

public class CueController : MonoBehaviour
{
    public GameObject Cue;
    public GameObject MainBall;
    public Transform hitPosition;
    public Transform obj;
    public float radius;
    public float hitForce;

    private Transform _pivot;
    private Rigidbody _mainBallRigidbody;
    

    void Start()
    {
        _mainBallRigidbody = MainBall.GetComponent<Rigidbody>();

        _pivot = obj.transform;
        transform.parent = _pivot;

        transform.position += Vector3.up * radius;
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        AdjustPivot(mousePosition);

        Vector3 direction = (MainBall.transform.position - hitPosition.position).normalized;
        ManagePlayerInput(direction);
    }    

    private void AdjustPivot(Vector3 mousePosition)
    {
        Vector3 orbVector = Camera.main.WorldToScreenPoint(obj.position);
        orbVector = mousePosition - orbVector;
        float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;
        _pivot.position = obj.position;
        _pivot.rotation = Quaternion.AngleAxis(angle + 180, Vector3.down);
    }

    private void ManagePlayerInput(Vector3 direction)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {    
            _mainBallRigidbody.AddForce(direction * hitForce, ForceMode.Impulse);
            _mainBallRigidbody.freezeRotation = false;
            Cue.SetActive(false);
        }
    }
}
