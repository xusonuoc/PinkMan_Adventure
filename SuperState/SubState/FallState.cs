using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : PlayerGroundedState
{
    public FallState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string StateName) : base(player, stateMachine, playerData, StateName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Player.CheckIfGround())
        {
            StateMachine.ChangeState(Player.IdleState);
        }
    }
}
