using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private EnemyData enemyData;

    [SerializeField]
    private SpriteRenderer enemySprite;

    private Transform playerTransform;

    // private GunAnimation enemyAnimation;
    private MasterAnimator enemyAnimation;
    public bool IsFacingRight { get; set; }

    private float distance;
    bool isDead;

    private string projectileName;

    private void Awake()
    {
        // enemyAnimation = GetComponent<GunAnimation>();
        enemyAnimation = GetComponent<MasterAnimator>();
        isDead = GetComponent<Enemy>().isDead;
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        projectileName = "projectile";
    }

    private void OnEnable()
    {
        TurnCheck();
        // enemyAnimation.SetAnimation(2);
        enemyAnimation.ChangeAnimation("Walk");
    }

    private void FixedUpdate()
    {
        if (!MainNavigation.isPaused)
        {
            // distance between enemy and player
            distance = Vector2.Distance(transform.position, playerTransform.position);

            // Direction player is moving in
            Vector2 direction = playerTransform.position - transform.position;
            direction.Normalize();

            // Rotation angle
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Flip sprite in direction of player movement
            if (enemySprite != null)
            {
                TurnCheck();
            }

            // Walk towards player
            if (distance < enemyData.distanceBetween && !isDead && enemyAnimation.animationFinished)
            {
                if (enemyData.EnemyName == projectileName)
                {
                    enemyAnimation.ChangeAnimation(enemyAnimation.moveProjectileAnimation[2]);
                }
                else
                {
                    enemyAnimation.ChangeAnimation(enemyAnimation.moveAnimation[2]);
                }

                EnemyMovementPatterns(enemyData.movementPatternID, angle, enemyData.moveSpeed);
            }

            // Idle animation
            if (distance > enemyData.distanceBetween && !isDead)
            {
                if (enemyData.EnemyName == projectileName)
                {
                    enemyAnimation.ChangeAnimation(enemyAnimation.moveProjectileAnimation[0]);
                }
                else
                {
                    enemyAnimation.ChangeAnimation(enemyAnimation.moveAnimation[0]);
                }
            }
        }
    }

    private void EnemyMovementPatterns(int movementPatternID, float angle, float speed)
    {
        switch (movementPatternID)
        {
            case 0:
                RotateTowardsPlayer(angle);
                break;
            case 1:
                MoveTowardsPlayer(speed);
                break;
            case 2:
                ForwardAndRetreat(speed);
                break;
        }
    }

    // Move towards player and then retreat if player moves towards enemy
    private void ForwardAndRetreat(float speed)
    {
        // Retreat from player if too close
        if (
            Vector2.Distance(transform.position, playerTransform.position)
                < enemyData.minimumDistance
            && enemyAnimation.animationFinished
        )
        {
            if (enemyData.EnemyName == projectileName)
            {
                enemyAnimation.ChangeAnimation(enemyAnimation.moveProjectileAnimation[1]);
            }
            else
            {
                enemyAnimation.ChangeAnimation(enemyAnimation.moveAnimation[1]);
            }

            MoveTowardsPlayer(-speed);
        }
        // Move towards Player if too far away
        else if (
            Vector2.Distance(transform.position, playerTransform.position)
                > enemyData.minimumDistance
            && enemyAnimation.animationFinished
        )
        {
            if (enemyData.EnemyName == projectileName)
            {
                enemyAnimation.ChangeAnimation(enemyAnimation.moveProjectileAnimation[2]);
            }
            else
            {
                enemyAnimation.ChangeAnimation(enemyAnimation.moveAnimation[2]);
            }

            MoveTowardsPlayer(speed);
        }
    }

    private void RotateTowardsPlayer(float angle)
    {
        // Create a smooth updating turn rotation
        transform.SetPositionAndRotation(
            Vector2.MoveTowards(
                this.transform.position,
                playerTransform.position,
                enemyData.moveSpeed * Time.deltaTime
            ),
            Quaternion.Euler(Vector3.forward * angle)
        );
    }

    // Without rotation
    private void MoveTowardsPlayer(float speed)
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            playerTransform.position,
            speed * Time.deltaTime
        );
    }

    private void TurnCheck()
    {
        if (playerTransform.position.x > transform.position.x && !IsFacingRight)
        {
            Turn();
        }
        else if (playerTransform.position.x < transform.position.x && IsFacingRight)
        {
            Turn();
        }
    }

    private void Turn()
    {
        if (IsFacingRight)
        {
            transform.rotation = Quaternion.Euler(
                new Vector3(transform.rotation.x, 180f, transform.rotation.z)
            );
            IsFacingRight = !IsFacingRight;

            //turn camera follow object
        }
        else
        {
            transform.rotation = Quaternion.Euler(
                new Vector3(transform.rotation.x, 0f, transform.rotation.z)
            );
            IsFacingRight = !IsFacingRight;

            //turn camera follow object
        }
    }
}
