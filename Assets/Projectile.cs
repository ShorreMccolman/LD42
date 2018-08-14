using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int damage;
    public float speed;
    Enemy target;
    public Vector3 lastTargetPosition;

    bool hasTarget;

	// Use this for initialization
	void Start () {
		
	}

    public void SetTarget(Enemy newTarget)
    {
        target = newTarget;
        lastTargetPosition = newTarget.transform.position;
        hasTarget = true;
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 targetPos = target == null ? lastTargetPosition : target.transform.position;

        transform.position += (targetPos - transform.position).normalized * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPos) < 0.5)
        {
            if(target != null)
                target.Damage(damage);
            Destroy(this.gameObject);
        }
        else
        {
            lastTargetPosition = targetPos;
        }
	}
}
