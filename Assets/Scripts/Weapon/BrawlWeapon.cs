using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrawlWeapon : WeaponBase
{
    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private Transform attackPoint;

    private Vector2 spawnPosition;
    private MasterAnimator enemyAnimation;

    private Transform playerTransform;

    private float timeBetweenShots = 0;
    private float nextShotTime;

    // private Vector3 offset;

    // private int bulletCount;

    void Awake()
    {
        enemyAnimation = GetComponent<MasterAnimator>();
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
    }

    private void Update()
    {
        if (
            Vector2.Distance(transform.position, playerTransform.position)
            <= enemyData.minimumDistance
        )
        {
            // Check if can shoot
            if (Time.time > nextShotTime)
            {
                var attack = Random.Range(0, 4);
                // Shoot animation
                enemyAnimation.ChangeAnimation(enemyAnimation.brawlAnimation[attack]);

                // Reset timer
                timeBetweenShots = Random.Range(1.5f, 5.0f);
                nextShotTime = Time.time + timeBetweenShots;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Damage Enemy
        IDoDamage iDoDamage = collision.gameObject.GetComponent<IDoDamage>();

        if (collision.gameObject.name == "PlayerCharacter")
        {
            iDoDamage?.DoDamage(damage);
        }
    }
}
