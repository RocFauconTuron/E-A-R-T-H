using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravityDynamic : MonoBehaviour
{
    bool isCameraFar = false;
    Vector3 lastGravity;
    [SerializeField] Transform camTransform;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform camPosPlayer;
    Transform camPosOutside;
    [SerializeField] GravityObjectController gravityObj;
    [SerializeField]GravityController gravityPlayer;
    [SerializeField] float timeAnim;
    [SerializeField] AnimationCurve curve;
    bool isAnimating = false;
    Quaternion lastPlayerRotForAnim;

    public void ChangeDynamic(Transform outsideCamPos, List<CubeGravityGround> gc)
    {
        if (!isCameraFar && !isAnimating)
        {
            camPosOutside = outsideCamPos;
            gravityPlayer.enabled = false;
            isAnimating = true;
            lastGravity = Physics.gravity;
            isCameraFar = true;
            camTransform.GetComponent<CameraMove>().enabled = false;
            GetComponent<PlayerMovementTutorial>().enabled = false;
            rb.isKinematic = true;
            camTransform.parent = null;
            StartCoroutine(CameraAnimation1(gc));           
        }
        else if(isCameraFar && !isAnimating)
        {
            isCameraFar = false;
            camTransform.GetComponent<CameraMoveWhenFar>().enabled = false;
            gravityObj.EndEvent();
            gravityObj.enabled = false;
            camTransform.parent = null;
            StartCoroutine(CameraAnimation2());
        }
    }
    IEnumerator CameraAnimation1(List<CubeGravityGround> gc)
    {
        isAnimating = true;
        Quaternion startRot = camTransform.rotation;
        lastPlayerRotForAnim = startRot;
        Vector3 startPos = camTransform.position;
        float time = 0;
        while (time < timeAnim)
        {
            time += Time.deltaTime;
            float percentageDuration = time / timeAnim;
            camTransform.localRotation = Quaternion.Lerp(startRot, camPosOutside.rotation, curve.Evaluate(percentageDuration));
            camTransform.position = Vector3.Lerp(startPos, camPosOutside.position, curve.Evaluate(percentageDuration));

            yield return new WaitForEndOfFrame();
        }
        gravityObj.enabled = true;
        gravityObj.StartEvent(gc);

        camTransform.GetComponent<CameraMoveWhenFar>().enabled = true;
        camTransform.GetComponent<CameraMoveWhenFar>().limitZoneLeft = camPosOutside.GetChild(0);
        camTransform.GetComponent<CameraMoveWhenFar>().limitZoneRight = camPosOutside.GetChild(1);
        camTransform.GetComponent<CameraMoveWhenFar>().outsideCam = camPosOutside.parent;

        camTransform.parent = camPosOutside;
        camTransform.localPosition = Vector3.zero;
        camTransform.localEulerAngles = Vector3.zero;
        isAnimating = false;
    }
    IEnumerator CameraAnimation2()
    {
        Quaternion startRot = camPosOutside.rotation;
        Vector3 startPos = camTransform.position;
        float time = 0;
        while (time < timeAnim)
        {
            time += Time.deltaTime;
            float percentageDuration = time / timeAnim;
            camTransform.localRotation = Quaternion.Lerp(startRot, lastPlayerRotForAnim, curve.Evaluate(percentageDuration));
            camTransform.position = Vector3.Lerp(startPos, camPosPlayer.position, curve.Evaluate(percentageDuration));

            yield return new WaitForEndOfFrame();
        }
        gravityPlayer.enabled = true;
        Physics.gravity = lastGravity;


        camTransform.GetComponent<CameraMove>().enabled = true;
        GetComponent<PlayerMovementTutorial>().enabled = true;
        rb.isKinematic = false;

        camTransform.parent = camPosPlayer;
        camTransform.localPosition = Vector3.zero;
        camTransform.localEulerAngles = Vector3.zero;
        isAnimating = false;
    }
}
