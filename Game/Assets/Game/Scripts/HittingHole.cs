using UnityEngine;

public class HittingHole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "otherBalls")
        {
            Destroy(other);
        }
    }
}
