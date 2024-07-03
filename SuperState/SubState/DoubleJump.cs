using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : PlayerAbilityState
{
    public DoubleJump(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string StateName) : base(player, stateMachine, playerData, StateName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Player.SetVelocityY(PlayerData.jumpVelocity);
        
        isAbilityDone = true;
    } 
}
