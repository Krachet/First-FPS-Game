using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerShoot : MonoBehaviour
{
    //prefabs
    public GameObject bullet;

    //bullet force
    public float shootForce, upwardForce;

    //gun stats
    public float timeBetweenShots, spread, reloadTime, timeBetweenShooting;
    public int magazine, bulletPerTap;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //gun stats display
    public GameObject muzzleFlash;
    public TextMeshProUGUI ammunationDisplay;

    //bool
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    public bool allowInvoke = true;


    private void Awake()
    {
        //make sure magazine is full
        bulletsLeft = magazine;
        readyToShoot = true;
    }

    private void Update()
    {
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        PlayerAction();

        if (ammunationDisplay)
        {
            ammunationDisplay.SetText(bulletsLeft / bulletPerTap + " / " + magazine / bulletPerTap);
        }
    }

    private void PlayerAction()
    {
        //Check if allowed to shoot
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);
        
        //Reloading
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazine && !reloading)
        {
            Reload();
            return;
        }

        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            Reload();
            return;
        }

        //Shooting
        if (shooting && readyToShoot && bulletsLeft > 0 && !reloading)
        {
            bulletsShot = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        //calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        //rotate bullet
        currentBullet.transform.forward = directionWithSpread.normalized;

        if (muzzleFlash)
        {
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        }

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        //if you want to use bounce grenade
        //currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);
        
        bulletsLeft--;
        bulletsShot++;

        if (allowInvoke)
        {
            Invoke(nameof(ResetShot), timeBetweenShooting);
            allowInvoke = false;
        }

        //for shotgun or multi fire gun
        if (bulletsShot < bulletPerTap && bulletsLeft > 0)
        {
            Invoke(nameof(Shoot), timeBetweenShots);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke(nameof(ReloadFinished), reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazine;
        reloading = false;
    }
}
