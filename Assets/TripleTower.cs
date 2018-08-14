using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleTower : Tower {

    int curPoint = 0;

    protected override void FireWeapon()
    {
        GameObject bullObj = Instantiate(bulletPrefab);
        bullObj.GetComponent<Projectile>().SetTarget(currentTarget);
        bullObj.transform.position = Firepoints[curPoint].position;
        bullObj.transform.LookAt(currentTarget.transform);
        curPoint = (curPoint + 1) % Firepoints.Length;
    }
}
