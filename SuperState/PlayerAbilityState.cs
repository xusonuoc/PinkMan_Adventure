using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool isAbilityDone;

    private bool isGrounded;

   
    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string StateName) : base(player, stateMachine, playerData, StateName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
        
        isGrounded = Player.CheckIfGround();
    }

    public override void Enter()
    {
        base.Enter();

        isAbilityDone = false;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAbilityDone)
        {
            
            if (isGrounded && Player.CurrentVelocity.y < 0.01f) 
            {
                StateMachine.ChangeState(Player.IdleState);

            }
            else
            {
                StateMachine.ChangeState(Player.InAirState);
            }

        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
