using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAirState : PlayerState
{
    protected bool isGrounded;
    private int xInput;
    protected bool jumpInput;

    protected bool canJump;
    public InAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string StateName) : base(player, stateMachine, playerData, StateName)
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
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        jumpInput = Player.InputHandler.JumpInput;
        xInput = Player.InputHandler.NormInputX;
        
        if (Player.CurrentVelocity.y < 0.01f)
        {
            StateMachine.ChangeState(Player.FallState);
        }
        else
        {
            Player.Flip(xInput);
            Player.SetVelocityX(PlayerData.movementVelocity * xInput);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
   
}
