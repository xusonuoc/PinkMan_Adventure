using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData", menuName ="Data/Player")]
public class PlayerData : ScriptableObject
{
    [Header("Move State")]
    public float movementVelocity = 10f;

    [Header("Jump State")]
    public float jumpVelocity = 5f;
    public int amountOfDBJump = 1;

    [Header("Check Variables")]
    public float groundCheckRadius;
    public LayerMask isGround;  
}
