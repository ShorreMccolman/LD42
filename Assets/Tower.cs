using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
    

    protected enum TowerState
    {
        Building,
        Hunting,
        Firing
    }

    public float range;
    public float cooldown;
    public int cost;

    public Transform Turret;
    public Transform[] Firepoints;

    public GameObject bulletPrefab;

    protected TowerState state;
    protected Enemy currentTarget;
    protected float lastFireTime;

	// Use this for initialization
	void Start () {
        lastFireTime = 0;
        state = TowerState.Hunting;
        StartCoroutine(Hunt());
	}

    void Update()
    {
        if(currentTarget != null && Vector3.Distance(transform.position,currentTarget.transform.position) < range)
        {
            Vector3 noY = new Vector3(currentTarget.transform.position.x, Turret.transform.position.y, currentTarget.transform.position.z);
            Quaternion look = Quaternion.LookRotation(noY - Turret.transform.position);
            Turret.transform.rotation = Quaternion.Slerp(Turret.transform.rotation, look, 10f * Time.deltaTime);
        }
    }
	
	// Update is called once per frame
	IEnumerator Hunt()
    {
        while (true)
        {
            Enemy inRange = null;
            float minDist = range;
            foreach (var enemy in EnemyManager.Instance.Enemies)
            {
                float dist = Vector3.Distance(transform.position, enemy.transform.position);
                if (dist < range && dist < minDist)
                {
                    inRange = enemy;
                    minDist = dist;
                }
            }
            currentTarget = inRange;

            if (currentTarget != null && Time.time - lastFireTime > cooldown)
            {
                FireWeapon();
                lastFireTime = Time.time;
            }

            yield return new WaitForSeconds(0.5f);
        }
	}

    IEnumerator Fire()
    {
        bool inRange = true;
        while (inRange)
        {
            FireWeapon();

            yield return new WaitForSeconds(cooldown);

            if (currentTarget == null)
                inRange = false;
            else
                inRange = Vector3.Distance(transform.position, currentTarget.transform.position) < range;
        }
        state = TowerState.Hunting;
        StartCoroutine(Hunt());
    }

    protected virtual void FireWeapon()
    {
        //EnemyManager.Instance.KillEnemy(currentTarget);
        GameObject bullObj = Instantiate(bulletPrefab);
        bullObj.GetComponent<Projectile>().SetTarget(currentTarget);
        bullObj.transform.position = transform.position;
    }
}
