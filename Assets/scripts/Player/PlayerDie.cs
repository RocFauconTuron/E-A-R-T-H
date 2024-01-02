using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public Vector3 diePos;

    private void Awake()
    {
        diePos = transform.position;
    }

    public void Die()
    {
        Physics.gravity = new Vector3(0, -14, 0);
        transform.position = diePos;
        transform.rotation = Quaternion.identity;

        GetComponent<Rigidbody>().velocity = Vector3.zero;

        if(GetComponent<GravityController>() != null)
        {
            GetComponent<GravityController>().Down();
        }
    }
}
