using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// camera will follow the player and transition to battle camera position
//3 camera used  for foreground, midground and background
public class FollowCamera : MonoBehaviour
{
    public Vector2 minXY, maxXY,marginXY;
    public Vector2 smoothXY;
    Transform target;
    public float offsetY = 0;
    public float slowSpeed = 30;
    public bool battleStarted= false;
    Transform bossCameraTransform;
    // Use this for initialization
    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("CameraTarget").transform;
        bossCameraTransform = GameObject.FindGameObjectWithTag("bossCameraTarget").transform;
        
    }
    bool MinXRange()
    {
        return (Mathf.Abs(transform.position.x - target.position.x) > marginXY.x);
    }
    bool MinYRange()
    {
        return (Mathf.Abs(transform.position.y - target.position.y) > marginXY.y);
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
       FollowPlayer();
    }
    void FollowPlayer()
    {  if (target == null)
            return;

        Vector2 targetPos = target.position;
        if (MinXRange())
        {
            targetPos.x = Mathf.Lerp(transform.position.x, target.position.x, smoothXY.x);
        }
        if (MinYRange())
        {
            targetPos.y = Mathf.Lerp(transform.position.y, target.position.y, smoothXY.y);
        }
        targetPos.x = Mathf.Clamp(targetPos.x, minXY.x, maxXY.x);
        targetPos.y = Mathf.Clamp(targetPos.y, minXY.y, maxXY.y);
        if (battleStarted)
        {
            transform.position = Vector3.Lerp(transform.position, bossCameraTransform.position, 1 / slowSpeed);
        }
        else
        {
            transform.position = new Vector3(targetPos.x, targetPos.y + offsetY, transform.position.z);

        }

    }
}
