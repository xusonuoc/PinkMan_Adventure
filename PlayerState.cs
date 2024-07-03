using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected float startTime; 
    public Player Player { get; private set; }
    public PlayerStateMachine StateMachine {get ;private set;}
    public PlayerData PlayerData { get ; private set;}
    public String StateName { get; private set;} 

    public PlayerState(Player player, PlayerStateMachine stateMachine,PlayerData playerData, String StateName) 
    {
        this.Player = player;
        this.StateMachine = stateMachine;
        this.PlayerData = playerData;
        this.StateName = StateName;
    }

    public virtual void Enter()
    {
        DoCheck();
        Player.Anim.SetBool(StateName, true);
        startTime = Time.time;
        Debug.Log(StateName);

    }

    public virtual void Exit()
    {
        Player.Anim.SetBool(StateName, false);
    }

    public virtual void PhysicsUpdate()
    {

    }
    public virtual void LogicUpdate()
    {

    }

    public virtual void DoCheck() { }
}
