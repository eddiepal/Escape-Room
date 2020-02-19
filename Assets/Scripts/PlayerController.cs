using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviourPun
{
    [Header("Stats")] 
    public float moveSpeed;
    public float jumpForce;
    public int curHp;
    public int maxHp;
    public int kills;
    public bool dead;

    private bool flashingDamage;

    [Header("Components")] 
    public Rigidbody rig;
    public Player photonPlayer;
    public MeshRenderer mr;
    
    [Header("Info")]
    public int id;
    private int curAttackerId;

    [Header("Raycasting")] 
    public float rayLength;

    public LayerMask layerMask;
    private PlayerInputActions inputAction;

    private Vector2 movementInput;

    [SerializeField]
    TextMeshPro overheadPlayerName;

    #region ASU

    private void Awake()
    {
        inputAction = new PlayerInputActions();
        PlayerInput.playerInput.controls.PlayerControls.Move.performed += ctx => movementInput = ctx.ReadValue<Vector2>();
        PlayerInput.playerInput.controls.PlayerControls.Jump.performed += ctx => TryJump();
        
    }

    private void Start()
    {
        photonView.RPC("SetOverheadPlayerName", RpcTarget.Others, PhotonNetwork.LocalPlayer.NickName);
    }

    void Update()
    {
        if (!photonView.IsMine || dead)
            return;

        Move();
        if (PauseMenu.gamePaused == false)
        {
           
        }
    }
    
    private void LateUpdate()
    {
        if (Camera.main != null)
        {
            overheadPlayerName.transform.LookAt(Camera.main.transform);
            overheadPlayerName.transform.Rotate(0,180,0);
        }
    }

    #endregion
    
    [PunRPC]
    public void SetOverheadPlayerName(String playerName)
    {
        overheadPlayerName.text = playerName;
    }

    void Move ()
    {
        if(PauseMenu.gamePaused)
            return;
        
        float x = movementInput.x;
        float z = movementInput.y;
 
        // calculate a direction relative to where we're facing
        Vector3 dir = (transform.forward * z + transform.right * x) * moveSpeed;
        dir.y = rig.velocity.y;
 
        // set that as our velocity
        rig.velocity = dir;
    }
    
    void TryJump ()
    {
        // create a ray facing down
        Ray ray = new Ray(transform.position, Vector3.down);
 
        // shoot the raycast
        if(Physics.Raycast(ray, 1.5f))
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    [PunRPC]
    public void TakeDamage(int attackerId, int damage)
    {
        if (dead)
            return;

        curHp -= damage;
        curAttackerId = attackerId;
        
        // flash the player red
        photonView.RPC("DamageFlash", RpcTarget.Others);
        
        // update the health bar UI
        
        // die if no health left
        if(curHp <= 0)
            photonView.RPC("Die", RpcTarget.All);
    }

    [PunRPC]
    void DamageFlash()
    {
        if(flashingDamage)
            return;

        StartCoroutine(DamageFlashCoRoutine());

        IEnumerator DamageFlashCoRoutine()
        {
            flashingDamage = true;

            Color defaultColor = mr.material.color;
            mr.material.color = Color.red;

            yield return new WaitForSeconds(0.05f);

            mr.material.color = defaultColor;
            flashingDamage = false;
        }
    }

    [PunRPC]
    public void Initialize (Player player)
    {
        id = player.ActorNumber;
        photonPlayer = player;

        GameManager.instance.players[id - 1] = this;
    
        // is this not our local player?
        if(!photonView.IsMine)
        {
            GetComponentInChildren<Camera>().gameObject.SetActive(false);
            rig.isKinematic = true;
        }
    }
}