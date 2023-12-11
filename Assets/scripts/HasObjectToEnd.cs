using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasObjectToEnd : MonoBehaviour
{
    public bool bobina;
    public bool refrigeracion;
    public bool lore;

    private static HasObjectToEnd hasObjectToEnd;

    private void Awake()
    {
        if (hasObjectToEnd != null)
        {
            Destroy(gameObject);
        }
        else
        {
            hasObjectToEnd = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
