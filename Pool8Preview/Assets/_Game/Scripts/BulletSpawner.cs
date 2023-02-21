using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{   
    [SerializeField] private LayerMask mask;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private TrailRenderer bulletTrail;
    [SerializeField] private float shootDelay = 0.5f;

    private float _LastShootTime;


    public void ShootBullet(Vector3 HitPoint)
    {        
        if (_LastShootTime + shootDelay < Time.time)
        {       
            Vector3 direction = transform.forward;
            RaycastHit hit;
            Physics.Raycast(bulletSpawnPoint.position, direction, out hit, float.MaxValue, mask);
            TrailRenderer trail = Instantiate(bulletTrail, bulletSpawnPoint.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, HitPoint));
            _LastShootTime = Time.time;
        }
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, Vector3 HitPoint)
    {
        float time = 0;
        Vector3 startPosition = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, HitPoint, time);
            time += Time.deltaTime / Trail.time;

            yield return null;
        }
        Trail.transform.position = HitPoint;
        Destroy(Trail.gameObject, Trail.time);
    }
}
