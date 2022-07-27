using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTowerController : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private float reloadingTime;
    [SerializeField] private Camera camera;
    [SerializeField] private ParticleSystem flesh;

    private bool isReloading;
    private Vector3 _destination;
    void Update()
    {
        var ray = new Ray(ShootPoint.position, ShootPoint.forward);
        _destination = ray.origin + ray.direction * 1000f;
        Debug.DrawLine(ShootPoint.position, _destination, Color.red, 10f);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (isReloading)
        {
            return;
        }  
        SpawnBullet();
    }

    public void SpawnBullet()
    {
        isReloading = true;
        Invoke("Reloading", reloadingTime);
        var _bullet = Instantiate(bullet, ShootPoint.position, transform.rotation);
        _bullet.GetComponent<bullet> ().SetVariables(_destination, 100, 40);
        flesh.Play();
    }
    private void Reloading()
    {
        isReloading = false;

    }
}
