using UnityEngine;
using System.Collections;

public class TargetMove : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject movePos1;
    public GameObject movePos2;

    private Vector3 dir;
    private Vector3 dirn;
    
    public float timeToReachTarget;
    bool dirb;
    float nextActionTime;

    public GameControl gm;

    void Start()
    {
        dirb = true;
        nextActionTime = 0;
    }

    void Update()
    {
        if (gm.game) {
            OVRInput.Update();
            if (Time.time > nextActionTime)
            {
                nextActionTime += timeToReachTarget;
                dirb = !dirb;
            }
            if (dirb)
            {
                transform.Translate(Time.deltaTime, 0, 0);
                rb.MovePosition(rb.transform.position);
            }
            else
            {
                transform.Translate(-Time.deltaTime, 0, 0);
                rb.MovePosition(rb.transform.position);
            }
        }
    }

    private void FixedUpdate()
    {
        OVRInput.FixedUpdate();
    }
}