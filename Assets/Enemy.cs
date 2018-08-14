using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int health;
    public float speed;
    public int reward;

    public Waypoint currentWaypoint;
    public Waypoint targetWaypoint;

    // Use this for initialization
    void Start () {

        transform.position = EnemyManager.Instance.waypoints[0].transform.position;
        currentWaypoint = EnemyManager.Instance.waypoints[0];
        targetWaypoint = EnemyManager.Instance.waypoints[1];
	}
	
	// Update is called once per frame
	void Update () {

        if (targetWaypoint == null)
            return;

        Vector3 direction = (targetWaypoint.transform.position - transform.position).normalized;
        Vector3 yDir = new Vector3(direction.x, 0, direction.z);

        transform.position += yDir * speed * Time.deltaTime;
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Waypoint")
        {
            currentWaypoint = other.GetComponent<Waypoint>();
            targetWaypoint = currentWaypoint.next;
        }
        else if (other.tag == "Base")
        {
            EnemyManager.Instance.KillEnemy(this);
            UI.Instance.hud.RemoveLife();
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            EnemyManager.Instance.KillEnemy(this);
            UI.Instance.hud.AddKill(reward);
        }
    }
}
