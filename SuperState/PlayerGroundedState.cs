using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int xInput;
    private bool JumpInput;
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string StateName) : base(player, stateMachine, playerData, StateName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
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
        // cập nhật input cho biến MovementInput ở PlayerInputHandler
        // cập nhật ở trạng thái grounded để các trạng thái sub kế thừa
        xInput = Player.InputHandler.NormInputX ;
        Player.Flip(xInput);
        JumpInput = Player.InputHandler.JumpInput;

        if (JumpInput && Player.JumpState.CanJump() > 0)
        {
            Player.InputHandler.UseJumpInput();
            StateMachine.ChangeState(Player.JumpState);
        }
        else if (JumpInput && Player.JumpState.CanJump() < 1)
        {
            Player.InputHandler.UseJumpInput();
            StateMachine.ChangeState(Player.DoubleJump);
        }
        //}else if (Player.CheckIfGround())
        //{
        //    StateMachine.ChangeState(Player.FallState);
        //}
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
