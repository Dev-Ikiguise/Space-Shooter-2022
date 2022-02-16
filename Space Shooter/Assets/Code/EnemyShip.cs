using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship
{
    Transform target;
    public bool canFireAtPlayer;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerShip>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        FlyTowardPlayer();
        Thrust();

        if (canFireAtPlayer && canShoot)
        {
            FireProjectile();
        }
    }

    void FlyTowardPlayer()
    {
        Vector2 directionToFace = new Vector2(
            target.position.x - transform.position.x, target.position.y - transform.position.y);
        transform.up = directionToFace;
    }
}
