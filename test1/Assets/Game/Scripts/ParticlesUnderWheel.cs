using UnityEngine;

public class ParticlesUnderWheel : MonoBehaviour
{
    public GameObject dirtyEffect1;
    public GameObject dirtyEffect2;
    public Transform wheelPos1;
    public Transform wheelPos2;

    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.name == "Ground" && InputSystem.IsRotationLeft == true)
        {
            Instantiate(dirtyEffect1, wheelPos1.transform.position, wheelPos1.transform.rotation);
            Instantiate(dirtyEffect2, wheelPos1.transform.position, wheelPos1.transform.rotation);
        }
        if(other.gameObject.name == "Ground" && InputSystem.IsRotationRight == true)
        {
            Instantiate(dirtyEffect1, wheelPos2.transform.position, wheelPos2.transform.rotation);
            Instantiate(dirtyEffect2, wheelPos2.transform.position, wheelPos2.transform.rotation);
        }
    }
}
