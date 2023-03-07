using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    [SerializeField] GameObject player;

    void LateUpdate()
    {
        this.transform.position = player.transform.position + new Vector3(0,0,-15);
    }
}
