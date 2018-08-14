using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    public static EnemyManager Instance;
    void Awake()
    { Instance = this; }

    public Waypoint[] waypoints;

    public List<Enemy> Enemies = new List<Enemy>();
    public GameObject enemyPrefab;

    // Use this for initialization
    void Start() {

        for (int i = 0; i < waypoints.Length; i++)
        {
            int prev = i - 1;
            int next = i + 1;

            if (i > 0)
                waypoints[i].previous = waypoints[prev];
            if (i < waypoints.Length - 1)
                waypoints[i].next = waypoints[next];
        }

        StartCoroutine(EnemyWaves());
	}
	
	IEnumerator EnemyWaves()
    {
        yield return new WaitForSeconds(5.0f);

        int wave = 0;
        int style = 1;

        while (true)
        {
            for (int i = 0; i < 25; i++)
            {
                Enemy newEnemy = CreateEnemy(wave, style);
                Enemies.Add(newEnemy);
                yield return new WaitForSeconds(1.5f);
            }
            wave++;
            style = Random.Range(0, 3);
            yield return new WaitForSeconds(10.0f);
        }
    }

    Enemy CreateEnemy(int wave, int style)
    {
        GameObject enemyObj = Instantiate(enemyPrefab);
        Enemy enemy = enemyObj.GetComponent<Enemy>();

        if(style == 0)
        {
            enemy.health = 3 + 3 * wave;
            enemy.speed *= 0.75f;
        }
        else if (style == 1)
        {
            enemy.health = 3 + 2 * wave;
            enemy.speed *= 1;
        }
        else if (style == 2)
        {
            enemy.health = 3 + wave;
            enemy.speed *= 2.0f;
        }

        return enemy;
    }

    public void KillEnemy(Enemy enemy)
    {
        Enemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}
