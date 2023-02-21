using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float BrakeForce = 10;
    public float rotationSpeed = 4300f;
    public float rotationSpeedLeft = 4300f;
    public static bool isGrounded = false;
    public GameObject player;

    private Rigidbody2D playerRB;


    private void Awake() 
    {
        playerRB = player.GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        if(isGrounded == true && InputSystem.IsRotationRight == true)
        {
            Brake();
        }
        if(isGrounded == false && InputSystem.IsRotationLeft == true)
        {
            RotationLeft();
        }
        if(isGrounded == false && InputSystem.IsRotationRight == true)
        {
            RotationRight();
        }   
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.name == "Ground")
        {
            isGrounded = true;
        }
    }

    public void Brake()
    {
        playerRB.AddForce(Vector2.left * BrakeForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }
    public void RotationLeft()
    {
        playerRB.AddTorque(rotationSpeed * Time.deltaTime);
    }
    public void RotationRight()
    {
        playerRB.AddTorque(-rotationSpeedLeft * Time.deltaTime);
    }
}
