using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Player Data")]
public class PlayerStats : ScriptableObject
{
    [Header("Player Prefab")]
    public GameObject playerPrefab;

    [Header("Player Data")]
    public string playerName;
    public float maxHealth;

    [Header("Enemy Movement")]
    public float moveSpeed;
    public int movementPatternID;
    public int movementSpeedID;

    [Header("Player Combat")]
    public float attackRate;
    public float nextAttackTime;
    public float attackRange;
    public int attackDamage;
}
