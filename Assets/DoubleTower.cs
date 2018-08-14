using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTower : Tower {

    protected override void FireWeapon()
    {
        foreach (var firepoint in Firepoints)
        {
            GameObject bullObj = Instantiate(bulletPrefab);
            bullObj.GetComponent<Projectile>().SetTarget(currentTarget);
            bullObj.transform.position = firepoint.position;
            bullObj.transform.LookAt(currentTarget.transform);
        }
    }
}
