using UnityEngine;
using Cinemachine;

public class Cinetouch : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook cineCam;
    [SerializeField] TouchField touchField;
    [SerializeField] float senstivityX = 2f;
    [SerializeField] float senstivityY = 2f;


    void Update()
    {
        cineCam.m_XAxis.Value += touchField.TouchDist.x * 200 * senstivityX * Time.deltaTime;
        cineCam.m_YAxis.Value += touchField.TouchDist.y * senstivityY * Time.deltaTime;
    }
}