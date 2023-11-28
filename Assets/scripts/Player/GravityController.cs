using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float rotTime;
    public bool downGravity = true;
    public bool upGravity = false;
    public bool rightGravity = false;
    public bool leftGravity = false;
    public bool forwardGravity = false;
    public bool backwardsGravity = false;
    [SerializeField] Transform camTransform;
    public float gravityForce;

    Vector3 vectorRot;
    Vector3 gravityForceVector;

    [SerializeField] AnimationCurve curve;

    public LayerMask layerLook;
    public bool canChangeGravity = true;
    public bool canCheckIfGround = true;
    PlayerMovementTutorial playerMove;
    public bool hasChangedGravity = false;
    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMovementTutorial>();
    }

    // Update is called once per frame
    void Update()
    {
        hasChangedGravity = false;
        if (Input.GetMouseButtonDown(0) && canChangeGravity)
        {
            prova();
        }            
    }
    void prova()
    {
        RaycastHit hit;
        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, Mathf.Infinity, layerLook))
        {
            if (hit.transform.CompareTag("up") && !upGravity)
            {
                hasChangedGravity = true;
                falseBools();
                gravityForceVector = new Vector3(0, gravityForce, 0);
                upGravity = true;
                Physics.gravity = Vector3.zero;
                vectorRot = FindRot();
                StartCoroutine(rotPlayer(vectorRot));
            }
            else if (hit.transform.CompareTag("down") && !downGravity)
            {
                hasChangedGravity = true;
                falseBools();
                gravityForceVector = new Vector3(0, -gravityForce, 0);
                downGravity = true;
                Physics.gravity = Vector3.zero;
                vectorRot = new Vector3(0, 0, 0);
                StartCoroutine(rotPlayer(vectorRot));
            }
            else if (hit.transform.CompareTag("right") && !rightGravity)
            {
                hasChangedGravity = true;
                falseBools();
                rightGravity = true;
                gravityForceVector = new Vector3(gravityForce, 0, 0);
                Physics.gravity = Vector3.zero;
                vectorRot = new Vector3(0, 0, 90);
                StartCoroutine(rotPlayer(vectorRot));
            }
            else if (hit.transform.CompareTag("left") && !leftGravity)
            {
                hasChangedGravity = true;
                falseBools();
                leftGravity = true;
                gravityForceVector = new Vector3(-gravityForce, 0, 0);
                Physics.gravity = Vector3.zero;
                vectorRot = new Vector3(0, 0, -90);
                StartCoroutine(rotPlayer(vectorRot));
            }
            else if (hit.transform.CompareTag("forward") && !forwardGravity)
            {
                hasChangedGravity = true;
                falseBools();
                forwardGravity = true;
                gravityForceVector = new Vector3(0, 0, gravityForce);
                Physics.gravity = Vector3.zero;
                vectorRot = new Vector3(-90, 0, 0);
                StartCoroutine(rotPlayer(vectorRot));
            }
            else if (hit.transform.CompareTag("backward") && !backwardsGravity)
            {
                hasChangedGravity = true;
                falseBools();
                backwardsGravity = true;
                gravityForceVector = new Vector3(0, 0, -gravityForce);
                Physics.gravity = Vector3.zero;
                vectorRot = new Vector3(90, 0, 0);
                StartCoroutine(rotPlayer(vectorRot));
            }
        }
    }
    Vector3 FindRot()
    {
        if(((camTransform.localEulerAngles.y <= 45 && camTransform.localEulerAngles.y >= 0)|| (camTransform.localEulerAngles.y <= 360 && camTransform.localEulerAngles.y >= 315)) || (camTransform.localEulerAngles.y <= 225 && camTransform.localEulerAngles.y >= 135))
        {
            return new Vector3(0, 0, 180);
        }
        else
        {
            return new Vector3(180, 0, 0);
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
        canChangeGravity = false;
        canCheckIfGround = false;
    }
    IEnumerator rotPlayer(Vector3 angle)
    {
        playerMove.enabled = false;
        Vector3 finalRot = angle;
        //if (Mathf.Abs(transform.localEulerAngles.x - angle.x) != 180)
        //{
        //    finalRot.x = angle.x + transform.localEulerAngles.x;
        //}
        //if (Mathf.Abs(transform.localEulerAngles.y - angle.y) != 180)
        //{
        //    finalRot.y = angle.y + transform.localEulerAngles.y;
        //}
        //if (Mathf.Abs(transform.localEulerAngles.z - angle.z) != 180)
        //{
        //    finalRot.z = angle.z + transform.localEulerAngles.z;
        //}
        float time = 0;
        rb.velocity = new Vector3(0, 0, 0);
        Quaternion startRot = transform.rotation;
        while (time < rotTime)
        {
            time += Time.deltaTime;
            float percentageDuration = time / rotTime;
            transform.localRotation = Quaternion.Lerp(startRot, Quaternion.Euler(finalRot), curve.Evaluate(percentageDuration));

            yield return new WaitForEndOfFrame();
        }
        transform.localEulerAngles = finalRot;
        Physics.gravity = gravityForceVector;
        canCheckIfGround = true;
        playerMove.enabled = true;
    }
}
