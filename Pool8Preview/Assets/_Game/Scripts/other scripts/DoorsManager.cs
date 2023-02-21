using UnityEngine;

public class DoorsManager : MonoBehaviour
{
    [SerializeField] private Animation animationComponent;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AnimationClip enterAnimation;
    [SerializeField] private AnimationClip exitAnimation;
    [SerializeField] private AudioClip enterSound;
    [SerializeField] private AudioClip exitSound;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animationComponent.clip = enterAnimation;
            animationComponent.Play();
            audioSource.clip = enterSound;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animationComponent.clip = exitAnimation;
            animationComponent.Play();
            audioSource.clip = exitSound;
            audioSource.Play();
        }
    }
}
