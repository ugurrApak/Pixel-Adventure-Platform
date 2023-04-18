using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    PlayerMovement player;
    Animator anim;
    private void Awake()
    {
        player= GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        anim.SetBool("IsRun", player.IsRun);
        anim.SetBool("IsJump", player.IsJump);
    }
}
