using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{
    public Transform FirePosition;
    public GameObject bulletPrefab;
    public GameObject shotParticle;
    ParticleSystem[] particles;

    [SerializeField] float bulletsLeft;
    [SerializeField] float maxBulletsInGun;
    public int BulletDamage;

    [SerializeField] float shotDelay;
    float timer;
    bool isShooting;

    [SerializeField] int bulletSpreadAmount;
    [SerializeField] float bulletSpreadSize;
    [SerializeField] float shotForce;

    private void Start()
    {
        bulletsLeft = maxBulletsInGun;
        isShooting = false;


        particles = shotParticle.GetComponentsInChildren<ParticleSystem>();
    }

    private void Update()
    {
        Timer();
        if (Input.GetButtonDown("Fire1") && !isShooting && bulletsLeft > 0)
        {
            bulletsLeft -= 1;

            isShooting = true;
            timer = shotDelay;

            Shoot();
        }
    }

    private void Shoot()
    {
        
        for (int i = 0; i < bulletSpreadAmount; i++)
        {
            var randomNumberX = Random.Range(-bulletSpreadSize, bulletSpreadSize);
            var randomNumberY = Random.Range(-bulletSpreadSize, bulletSpreadSize);
            var randomNumberZ = Random.Range(-bulletSpreadSize, bulletSpreadSize);

            var bullet = Instantiate(bulletPrefab, FirePosition.transform.position, FirePosition.transform.rotation);
            bullet.GetComponent<Bullet>().Damage = BulletDamage;
            bullet.transform.Rotate(randomNumberX, randomNumberY, randomNumberZ);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * shotForce);
        }

        foreach (ParticleSystem child in particles)
        {
            child.Clear();
            child.Play();
        }
    }
    
    private void Timer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
            isShooting = false;
        }
    }
}
