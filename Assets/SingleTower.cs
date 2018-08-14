using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTower : Tower {

    protected override void FireWeapon()
    {
        GameObject bullObj = Instantiate(bulletPrefab);
        bullObj.GetComponent<Projectile>().SetTarget(currentTarget);
        bullObj.transform.position = Firepoints[0].position;
        bullObj.transform.LookAt(currentTarget.transform);
    }
}
