using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject towerPrefab;
    public TowerType type;
    public UpgradeUI upgradeUI;



    private Transform target;
    public string enemyTag = "Enemy";
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;




    [System.Serializable]
    public class UpgradeUI
    {
        public GameObject canvas;
        public GameObject upgradeBtn;
        public GameObject sellBtn;
    }

    public enum TowerType
    {
        NONE,
        TURRET1,
        TURRET2,
        TURRET3,
        TURRET4
    }
    void Start()
    {
        //type = TowerType.NONE;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        fireCountdown -= Time.deltaTime;
        if (target == null)
            return;

        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {

            Shoot();
            fireCountdown = 1f / fireRate;
        }
    }

    public void UpgradeTurret()
    {
        Debug.Log("Upgrade Turret!");
    }


    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }


    void Shoot()
    {

        Vector3 dir = target.transform.position - transform.position;
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(dir));
        Bullet bullet = bulletGo.GetComponent<Bullet>();


        if (bullet != null)
        {
            bullet.Seek(target);
        }

    }


    public void SellTurret()
    {
        GameManager.Instance.turretsList.Remove(this);
        Destroy(gameObject);
    }


    public void ToggleUpgradeUI(bool isActive)
    {
        upgradeUI.canvas.SetActive(isActive);
    }
}
