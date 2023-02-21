using UnityEngine;
using System.Collections;

public class LaserSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ShotEffect;
    [SerializeField] private BulletSpawner Gun;
    [SerializeField] private GameObject ShotFlash;
    [SerializeField] private Transform firePoint;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private GameObject redDotPrefab;
    [SerializeField] private AudioSource audioSource;

    private float interval;
    private Vector3 HitPoint;
    static public bool Pressed = false;


    private void Update() 
    {
        if(SettingMenu.isPaused == false)
        {
            Laser();

            if (Pressed == true)
            {   
                if ((interval += Time.deltaTime) > .13f)
                {
                    interval = 0.0f;
                    ShotEffect.SetActive(true);
                    ShotFlash.SetActive(true);
                    audioSource.Play();
                    Gun.ShootBullet(HitPoint);
                    StartCoroutine(TurnOffVFX());
                }
            }
        }
    }

    private IEnumerator TurnOffVFX()
    {
        yield return new WaitForSeconds(0.1f);
        ShotEffect.SetActive(false);
        ShotFlash.SetActive(false);
    }

    private void Laser()
        {
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, float.MaxValue))
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hit.point);
            lineRenderer.enabled = true;

            if (redDotPrefab != null)
            {
                redDotPrefab.transform.position = hit.point;
            }

            Vector3 scatteringBullets = new Vector3
            (
            Random.Range(redDotPrefab.transform.position.x - .4f, redDotPrefab.transform.position.x + .4f), 
            Random.Range(redDotPrefab.transform.position.y + - .2f, redDotPrefab.transform.position.y + .4f), 
            redDotPrefab.transform.position.z
            );
            
            HitPoint = new Vector3(redDotPrefab.transform.position.x, redDotPrefab.transform.position.y,
            redDotPrefab.transform.position.z);
            HitPoint = scatteringBullets;
        }
    }
}
