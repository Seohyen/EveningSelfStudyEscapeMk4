using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSet : MonoBehaviour
{
    
    [Header("카메라 기본속성")]
    private Transform cameraTransform = null;

    public GameObject objTarget = null;

    private Transform objTargetTransform = null;

    Vector3 originPos;
    public enum CameraTypeState { First,  Third }

    public CameraTypeState cameraTypeState = CameraTypeState.Third;

   

    [Header("1인칭 카메라")]
    public float detailX = 3.0f;
    public float detailY = 3.0f;

    public float rotationX = 0.0f;
    public float rotationY = 0.0f;

    public Transform posfirstCameraTarget = null;

    public float shakeTime = 1;
    public float shakeSpeed = 2;
    public float shakeAmount = 1;
    private Transform cam;

    void Start()
    {
        originPos = transform.localPosition;

        cameraTransform = GetComponent<Transform>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;

        if (objTarget != null)
        {
            objTargetTransform = objTarget.transform;
        }
    }
    public IEnumerator Shake()
    {
        Debug.Log("d");
        Vector3 originPosition = cam.localPosition;
        float elapsedTime = 0;
        while (elapsedTime < shakeTime)
        {
            Vector3 randomPoint = originPosition + Random.insideUnitSphere * shakeAmount;
            cam.localPosition = Vector3.Lerp(cam.localPosition, randomPoint, Time.deltaTime * shakeSpeed);
            
            yield return null;

            elapsedTime += Time.deltaTime;
        }
        cam.localPosition = originPosition;
    }
    void FirstCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        rotationX = cameraTransform.localEulerAngles.y + mouseX * detailX;
        rotationX = (rotationX > 180.0f) ? rotationX - 360.0f : rotationX;

        rotationY = rotationY + mouseY * detailY;
        //y축 제한
       rotationY = Mathf.Clamp(rotationY + mouseY, -45, 80);
        rotationY = (rotationY > 180.0f) ? rotationY - 360.0f : rotationY;

        cameraTransform.localEulerAngles = new Vector3(-rotationY, rotationX, 0f);
    
        cameraTransform.position = posfirstCameraTarget.position;
    }
    private void LateUpdate()
    {
     
        if (objTarget == null)
        {
            return;
        }

        if (objTargetTransform == null)
        {
            objTargetTransform = objTarget.transform;
        }

        switch (cameraTypeState)
        {
            case CameraTypeState.First:
                FirstCamera();
                break;
        }
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            StartCoroutine(Shake());
        }
    }
}