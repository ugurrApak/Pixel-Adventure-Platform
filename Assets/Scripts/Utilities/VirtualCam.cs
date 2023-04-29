using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCam : MonoBehaviour
{
    [SerializeField] Transform endCheckpoint;
    CinemachineVirtualCamera vcam;
    private void Awake()
    {
       vcam= GetComponent<CinemachineVirtualCamera>();
    }
    private void Update()
    {
        if (Player.IsDead)
        {
            StartCoroutine(WaitDeadAnimation());
        }
    }
    IEnumerator WaitDeadAnimation()
    {
        yield return new WaitForSeconds(.5f);
        vcam.Follow = endCheckpoint;
    }
}
