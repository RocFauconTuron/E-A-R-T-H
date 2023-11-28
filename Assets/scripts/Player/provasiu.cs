using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class provasiu : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + pos;
    }
}
