using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D projectileRigidBody;
    private Transform playerTransform;

    private SpriteRenderer projectileSprite;

    public float projectileSpeed;

    private Animator projectileFX;

    // private Coroutine returnToPoolCoroutine;
    private float destroyTime;

    private bool returned;

    private int damage;
    private Vector2 projectileTarget;
    private Transform spawnPosition;

    private float angle;

    private void Awake()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        projectileSprite = GetComponentInChildren<SpriteRenderer>();
        projectileRigidBody = GetComponent<Rigidbody2D>();
        projectileFX = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        returned = false;
        destroyTime = 7.0f;
        damage = 1;
        spawnPosition = this.gameObject.transform;
        projectileTarget = new Vector2(playerTransform.position.x, playerTransform.position.y);
        FlipSprite();
        // StartCoroutine(ReturnToPoolAfterTime());
    }

    private void Update()
    {
        // RotateSprite();
    }

    private void FixedUpdate()
    {
        MoveProjectile();
    }

    // Move projectile towards the player
    private void MoveProjectile()
    {
        // Rotate bullet in direction of velocity

        transform.position = Vector2.MoveTowards(
            transform.position,
            projectileTarget,
            projectileSpeed * Time.deltaTime
        );

        if (
            transform.position.x == projectileTarget.x
            && transform.position.y == projectileTarget.y
            && !returned
        )
        {
            ObjectPoolManager.ReturnObjectToPool(gameObject);
            returned = true;
        }
    }

    // Rotate sprite independently of game object
    private void RotateSprite()
    {
        angle = Mathf.Atan2(projectileTarget.y, projectileTarget.x);
        projectileSprite.transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
    }

    // Flip the sprite to face direction of player
    private void FlipSprite()
    {
        if (playerTransform.position.x > transform.position.x)
        {
            projectileSprite.flipX = false;
        }
        else
        {
            projectileSprite.flipX = true;
        }
    }

    // Destroy projectile if touching player and projectile has not already been destroyed


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Damage Enemy
        IDoDamage iDoDamage = collision.gameObject.GetComponent<IDoDamage>();

        if (collision.gameObject.name == "PlayerCharacter")
        {
            projectileFX.SetTrigger("hasCollided");

            iDoDamage?.DoDamage(damage);

            ObjectPoolManager.ReturnObjectToPool(gameObject);
            returned = true;
        }

        if (returned)
        {
            return;
        }
    }

    // Coroutine with designated wait time before destroying object
    public IEnumerator ReturnToPoolAfterTime()
    {
        float elapsedTime = 0f;
        while (elapsedTime < destroyTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (returned)
        {
            yield break;
        }

        ObjectPoolManager.ReturnObjectToPool(gameObject);
        returned = true;
    }

    // Destroy object if object has moved out beyond game boundaries
    // private void OnBecameInvisible()
    // {
    //     if (returned)
    //     {
    //         return;
    //     }
    //     Debug.Log("invisible returned");
    //     ObjectPoolManager.ReturnObjectToPool(gameObject);
    //     returned = true;
    // }
}
