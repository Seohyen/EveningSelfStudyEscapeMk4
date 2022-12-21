using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSet : MonoBehaviour
{

    [Header("카메라 기본속성")]
    private Transform cameraTransform = null;

    public GameObject objTarget = null;

    private Transform objTargetTransform = null;

    SettingUI settingUI;

    Vector3 originPos;

    [Header("1인칭 카메라")]
    public float detailX = 3.0f;
    public float detailY = 3.0f;

    public float rotationX = 0.0f;
    public float rotationY = 0.0f;

    public Transform posfirstCameraTarget = null;

 
    private Transform cam;

    void Start()
    {
        originPos = transform.localPosition;

        cameraTransform = GetComponent<Transform>();
        settingUI = GetComponent<SettingUI>();
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;

        if (objTarget != null)
        {
            objTargetTransform = objTarget.transform;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void FirstCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        rotationX = cameraTransform.localEulerAngles.y + mouseX * detailX;
        rotationX = (rotationX > 180.0f) ? rotationX - 360.0f : rotationX;

        rotationY = rotationY + mouseY * detailY;
        rotationY = Mathf.Clamp(rotationY + mouseY, -45, 80);
        rotationY = (rotationY > 180.0f) ? rotationY - 360.0f : rotationY;

        cameraTransform.localEulerAngles = new Vector3(-rotationY, rotationX, 0f);

        cameraTransform.position = posfirstCameraTarget.position;
    }

    private void Update()
    {
        if (objTarget == null)
        {
            return;
        }

        if (objTargetTransform == null)
        {
            objTargetTransform = objTarget.transform;
        }
        FirstCamera();
    }
}