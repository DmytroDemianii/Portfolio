using UnityEngine;

public class MainBallFreeze : MonoBehaviour
{
    public GameObject cue;
    public GameObject mainBall;


    void Update()
    {   
       if(mainBall.GetComponent<Rigidbody>().IsSleeping())
       {
            cue.SetActive(true);
       }
    } 

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "walls" || other.gameObject.tag == "otherBalls")
        {
            if (mainBall.GetComponent<Rigidbody>().velocity.z <= 5f)
            {
                mainBall.GetComponent<Rigidbody>().freezeRotation = true;
                if (mainBall.GetComponent<Rigidbody>().velocity.z > 0.0f)
                {
                    cue.SetActive(false);
                }
            }
        }
    }
}
