using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : PlayerGroundedState
{
    public MoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string StateName) : base(player, stateMachine, playerData, StateName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        //StateMachine.ChangeState(Player.MoveState);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Player.SetVelocityX(PlayerData.movementVelocity * xInput);
        if (xInput == 0f)
        {
            StateMachine.ChangeState(Player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
