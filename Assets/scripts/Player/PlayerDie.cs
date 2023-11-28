using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public Vector3 diePos;

    public void Die()
    {
        Physics.gravity = new Vector3(0, -14, 0);
        transform.position = diePos;
        transform.rotation = Quaternion.identity;
    }
}
