using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Ctrl : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //foll playr
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDist;
    [SerializeField] private float CameraSpeed;
    private float lookAhead;

    private void Update()
    {
        // transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX,transform.position.y, transform.position.z), ref velocity, speed*Time.deltaTime);
        // Follow Player
        transform.position = new Vector3(Mathf.Clamp(player.position.x,-0.59f,2.59f), transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead,(aheadDist * player.localScale.x), Time.deltaTime * CameraSpeed);   
    }


}
