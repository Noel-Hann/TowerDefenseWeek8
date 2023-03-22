using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;

    private int wavePointIndex = 0;

    private Enemy enemy;
    

    // Start is called before the first frame update
    void Start()
    {
        target = WayPoints.points[0];
        enemy = GetComponent<Enemy>();
    }
    
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * (enemy.speed* Time.deltaTime),Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.5f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;//this resets speed after we use it, so that we arent slow after
        //turret stops hitting us

    }

    
    private void GetNextWaypoint()
    {
        
        if (wavePointIndex >= WayPoints.points.Length-1)
        {
            endPath();
            return;
        }
        wavePointIndex++;
        target = WayPoints.points[wavePointIndex];
    }

    void endPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
        
    }
}
