using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class Enemy : MonoBehaviour, IDoDamage
{
    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private SpriteRenderer enemySprite;

    private EnemyManager enemyManager;

    private ParticleSystem deathParticleSystem;
    private GunAnimation enemyAnimation;
    public float currentHealth;

    public bool isDead;

    private bool IsPlayingParticles;

    void Awake()
    {
        deathParticleSystem = GetComponent<ParticleSystem>();
        enemyAnimation = GetComponent<GunAnimation>();
    }

    void Start() { }

    void OnEnable()
    {
        isDead = false;
        currentHealth = enemyData.maxHealth;

        Physics2D.IgnoreCollision(
            GetComponent<BoxCollider2D>(),
            GetComponentInChildren<BoxCollider2D>()
        );
    }

    public void Update()
    {
        if (IsPlayingParticles && deathParticleSystem.isStopped)
        {
            deathParticleSystem.Stop();
            IsPlayingParticles = false;
            ReturnToPool();
        }
    }

    public void DoDamage(int damage)
    {
        HurtAnimation();
        // Decrease health based on damage
        currentHealth -= damage;

        // play hurt animation
        if (currentHealth <= 0)
        {
            isDead = true;
            Die();
        }
    }

    private void HurtAnimation()
    {
        var hurtAnimation = 14;

        // Hurt animation
        enemyAnimation.SetAnimation(hurtAnimation);
    }

    private void Die()
    {
        DeathAnimation();
        DisableComponents();
    }

    private void DeathAnimation()
    {
        var deadAnimation = 13;
        enemyAnimation.SetAnimation(deadAnimation);
        Debug.Log("dead enemy");
    }

    private void DisableComponents()
    {
        // Prevent collision with dead enemy
        // Disable movement and animation updates
        if (GetComponent<Collider2D>() != null)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        else if (GetComponent<ProjectileWeapon>() != null)
        {
            GetComponent<ProjectileWeapon>().enabled = false;
        }
        GetComponent<Collider2D>().enabled = false;
    }

    // Enabled when Death animation finishes via Particle Death Animation script
    public void EnableParticles()
    {
        var emission = deathParticleSystem.emission;

        emission.enabled = true;
        if (!IsPlayingParticles)
        {
            deathParticleSystem.Play();
            Destroy(enemySprite);
            IsPlayingParticles = true;
        }

        // enemySprite.SetActive(False);
    }

    // // Return to object pool for possible respawn in Enemy Manager
    // public void DestroyEnemyObject()
    // {
    //     enemyManager.ReturnToPool(this.gameObject);
    // }

    public void ReturnToPool()
    {
        if (deathParticleSystem.isStopped)
        {
            ObjectPoolManager.ReturnObjectToPool(gameObject);
        }
    }
}
