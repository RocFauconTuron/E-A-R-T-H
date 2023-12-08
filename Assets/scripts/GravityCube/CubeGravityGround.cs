using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGravityGround : MonoBehaviour
{
    Vector3 dir;
    [SerializeField] GravityObjectController gravityControllerObj;
    [SerializeField] LayerMask layerGround;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.gravity.y <0)
        {
            dir = -transform.up;
        }
        else if (Physics.gravity.y > 0)
        {
            dir = transform.up;
        }
        else if (Physics.gravity.z > 0)
        {
            dir = transform.forward;
        }
        else if (Physics.gravity.z < 0)
        {
            dir = -transform.forward;
        }
        else if (Physics.gravity.x > 0)
        {
            dir = transform.right;
        }
        else if (Physics.gravity.x < 0)
        {
            dir = -transform.right;
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, 2f, layerGround))
        {
            gravityControllerObj.canChangeGravity = true;
        }
        Debug.Log(gravityControllerObj.canChangeGravity);
    }
}
