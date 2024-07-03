using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Stable Varibles
    public PlayerStateMachine StateMachine { get; private set; }
    public IdleState IdleState { get; private set; }
    public MoveState MoveState { get; private set; }
    public JumpState JumpState { get; private set; }
    public InAirState InAirState { get; private set; }
    public DoubleJump DoubleJump { get; private set; }
    public FallState FallState { get; private set; }
    [SerializeField] public PlayerData playerData;
    #endregion

    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    #endregion

    #region Varibles
    private Vector2 workspace;
    public Vector2 CurrentVelocity { get; private set; }

    private bool checkflip;

    public Transform groundCheck;
    #endregion

    #region functionUnity
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new IdleState(this, StateMachine, playerData, "idle");
        MoveState = new MoveState(this, StateMachine, playerData, "move");
        JumpState = new JumpState(this, StateMachine, playerData, "jump");
        InAirState = new InAirState(this, StateMachine, playerData, "jump");
        FallState = new FallState(this, StateMachine, playerData, "fall");
        DoubleJump = new DoubleJump(this, StateMachine, playerData, "DBjump");
    }
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        StateMachine.Initialize(IdleState);
    }

    // Update is called once per frame
    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.PhysicsUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.LogicUpdate();
    }
    #endregion
    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }
    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }
    public void Flip(int xInput)
    {
        if (xInput > 0)
        {
            SpriteRenderer.flipX = false;
        }else if (xInput < 0)
        {
            SpriteRenderer.flipX = true;
        }
    }
    public bool CheckIfGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius,playerData.isGround);
    }
}
