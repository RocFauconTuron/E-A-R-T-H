using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObjectController: MonoBehaviour
{
    public float gravityForce;
    public bool downGravity = true;
    public bool upGravity = false;
    public bool rightGravity = false;
    public bool leftGravity = false;
    public bool forwardGravity = false;
    public bool backwardsGravity = false;
    public List<CubeGravityGround> gravityCubes;
    public bool canChangeGravity = true;
    public bool hasChangedGravity = false;
    public Transform camTransform;
    public void StartEvent(List<CubeGravityGround> gc)
    {
        Physics.gravity = new Vector3(0, gravityForce, 0);
        gravityCubes = gc;
        for (int i = 0; i < gravityCubes.Count; i++)
        {
            gravityCubes[i].enabled = true;
            gravityCubes[i].GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    public void EndEvent()
    {
        for (int i = 0; i < gravityCubes.Count; i++)
        {
            gravityCubes[i].enabled = false;
            gravityCubes[i].GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    void falseBools()
    {
        downGravity = false;
        upGravity = false;
        rightGravity = false;
        leftGravity = false;
        forwardGravity = false;
        backwardsGravity = false;
    }
    void SetVelocityZero()
    {
        for (int i = 0; i < gravityCubes.Count; i++)
        {
            gravityCubes[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
        // Update is called once per frame
    void Update()
    {
        hasChangedGravity = false;
        if (canChangeGravity)
        {
            Debug.Log("sad");
            if (Input.GetKeyDown(KeyCode.F))
            {
                SetVelocityZero();
                hasChangedGravity = true;
                falseBools();
                canChangeGravity = false;
                downGravity = true;
                
                Physics.gravity = new Vector3(0, gravityForce, 0);                
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                SetVelocityZero();
                hasChangedGravity = true;
                falseBools();
                canChangeGravity = false;
                upGravity = true;
                Physics.gravity = new Vector3(0, -gravityForce, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                SetVelocityZero();
                hasChangedGravity = true;
                falseBools();
                canChangeGravity = false;
                leftGravity = true;
                if (camTransform.eulerAngles.y == 90)
                {
                    Physics.gravity = new Vector3(0, 0, -gravityForce);
                }
                else if (camTransform.eulerAngles.y == 270)
                {
                    Physics.gravity = new Vector3(0, 0, gravityForce);
                }
                else if (camTransform.eulerAngles.y == 0)
                {
                    Physics.gravity = new Vector3(gravityForce, 0, 0);
                }
                else if (camTransform.eulerAngles.y == 180)
                {
                    Physics.gravity = new Vector3(-gravityForce, 0, 0);
                }
                
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                SetVelocityZero();
                hasChangedGravity = true;
                falseBools();
                canChangeGravity = false;
                rightGravity = true;
                if (camTransform.eulerAngles.y == 90)
                {
                    Physics.gravity = new Vector3(0, 0, gravityForce);
                }
                else if (camTransform.eulerAngles.y == 270)
                {
                    Physics.gravity = new Vector3(0, 0, -gravityForce);
                }
                else if (camTransform.eulerAngles.y == 0)
                {
                    Physics.gravity = new Vector3(-gravityForce, 0, 0);
                }
                else if (camTransform.eulerAngles.y == 180)
                {
                    Physics.gravity = new Vector3(gravityForce, 0, 0);
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                SetVelocityZero();
                hasChangedGravity = true;
                falseBools();
                canChangeGravity = false;
                backwardsGravity = true;
                if (camTransform.eulerAngles.y == 90)
                {
                    Physics.gravity = new Vector3(gravityForce, 0, 0);
                }
                else if (camTransform.eulerAngles.y == 270)
                {
                    Physics.gravity = new Vector3(-gravityForce, 0, 0);
                }
                else if (camTransform.eulerAngles.y == 0)
                {
                    Physics.gravity = new Vector3(0, 0, gravityForce);
                }
                else if (camTransform.eulerAngles.y == 180)
                {
                    Physics.gravity = new Vector3(0, 0, -gravityForce);
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                SetVelocityZero();
                hasChangedGravity = true;
                falseBools();
                canChangeGravity = false;
                forwardGravity = true;
                if (camTransform.eulerAngles.y == 90)
                {
                    Physics.gravity = new Vector3(-gravityForce, 0, 0);
                }
                else if (camTransform.eulerAngles.y == 270)
                {
                    Physics.gravity = new Vector3(gravityForce, 0, 0);
                }
                else if (camTransform.eulerAngles.y == 0)
                {
                    Physics.gravity = new Vector3(0, 0, -gravityForce);
                }
                else if (camTransform.eulerAngles.y == 180)
                {
                    Physics.gravity = new Vector3(0, 0, gravityForce);
                }
            }
        }       
    }  
}
