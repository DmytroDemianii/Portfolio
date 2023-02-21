using UnityEngine;

public class AirCheck : MonoBehaviour
{
    public float distance = 1f;
    public LayerMask groundLayer;
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, distance, groundLayer);
        if (hit.collider == null)
        {
            Rotation.isGrounded = false;
        }
        else
        {
            Rotation.isGrounded = true;
        }
    }
}
