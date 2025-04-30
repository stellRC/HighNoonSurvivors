using UnityEngine;

public class Enemy : MonoBehaviour, IDoDamage
{
    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private SpriteRenderer enemySprite;

    private GameManager gameManager;

    private EnemyManager enemyManager;

    private ParticleSystem deathParticleSystem;

    // private GunAnimation enemyAnimation;
    private MasterAnimator enemyAnimation;

    public float currentHealth;

    public bool isDead;

    private bool IsPlayingParticles;

    void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        deathParticleSystem = GetComponent<ParticleSystem>();
        // enemyAnimation = GetComponent<GunAnimation>();
        enemyAnimation = GetComponent<MasterAnimator>();
    }

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
        // var hurtAnimation = 14;

        // // Hurt animation
        // enemyAnimation.SetAnimation(hurtAnimation);
        enemyAnimation.ChangeAnimation(enemyAnimation.stateAnimation[4]);
    }

    private void Die()
    {
        DeathAnimation();
        DisableComponents();
        gameManager.killCount += 1;
    }

    private void DeathAnimation()
    {
        // var deadAnimation = 13;
        // enemyAnimation.SetAnimation(deadAnimation);
        // enemyAnimation.ChangeAnimation(enemyAnimation.stateAnimation[0]);
        EnableParticles();
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
