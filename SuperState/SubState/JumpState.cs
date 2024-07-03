using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerAbilityState
{
    private int amountOfJunmpsLeft;
    public JumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string StateName) : base(player, stateMachine, playerData, StateName)
    {
        amountOfJunmpsLeft = PlayerData.amountOfDBJump;
    }
    public override void Enter()
    {
        DecreaseAmountOfJumpLeft();
        Player.SetVelocityY(PlayerData.jumpVelocity);
        isAbilityDone = true;
        
    }
    public int CanJump()
    {
        if (amountOfJunmpsLeft > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public void ResetAmountOfJumpsLeft() => amountOfJunmpsLeft = PlayerData.amountOfDBJump;
    public void DecreaseAmountOfJumpLeft() => amountOfJunmpsLeft--;
}
