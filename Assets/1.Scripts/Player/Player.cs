using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    #region
    public static Player Instace = null;

    public static Player GetInstace()
    {
        return Instace;
    }

    private void Awake()
    {
        if (Instace == null)
        {
            Instace = this;
        }
        else
        {
            Destroy(gameObject);
        }


    }
    #endregion
    [SerializeField]
    private float spd = 3;
    public float stamina = 5;
    Rigidbody rigid;


    [SerializeField]
    private Slider sapceEvent = null;

    [SerializeField]
    private float gravity = 20;

    [SerializeField]
    private Text spaceT;


    public Camera mainCamera;

    public float rotateMoveSpd = 200.0f;

    public float rotateBodySpd = 2.0f;

    public float moveChageSpd = 0.1f;

    private Vector3 vecNowVelocity = Vector3.zero;

    private Vector3 vecMoveDirection = Vector3.zero;

    private CharacterController controllerCharacter = null;

    private CollisionFlags collisionFlagsCharacter = CollisionFlags.None;

    public Text rayText;



    RaycastHit hit;
    public bool isItem = false;
    public LayerMask layerMask;
    public ItemObj nowItem;

    private bool isHolding = false;


    void Start()
    {
        sapceEvent.gameObject.SetActive(false);
        sapceEvent.value = 0.05f;
        controllerCharacter = GetComponent<CharacterController>();
        rayText.gameObject.SetActive(false);

        gravity = 9.8f;
        spaceT.gameObject.SetActive(false);


    }



    void Update()
    {
        OnRun();
        Move();
        VecDirectionChangeBody();
        SpaceEvent();
        UseItem();
    }

    void Move()
    {
        Transform CameraTransform = Camera.main.transform;
        Vector3 forward = CameraTransform.TransformDirection(Vector3.forward);
        forward.y = 0.0f;
        Vector3 right = new Vector3(forward.z, 0.0f, -forward.x);

        if (isHolding == false)
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            Vector3 targetDirection = horizontal * right + vertical * forward;
            vecMoveDirection = Vector3.RotateTowards(vecMoveDirection, targetDirection, rotateMoveSpd * Mathf.Deg2Rad * Time.deltaTime, 1000.0f);
            vecMoveDirection = vecMoveDirection.normalized;
            float walkSpd = spd;

            Vector3 moveAmount = (vecMoveDirection * walkSpd * Time.deltaTime);
            collisionFlagsCharacter = controllerCharacter.Move(moveAmount);


            if (controllerCharacter.isGrounded == false)
            {
                vecMoveDirection.y -= gravity * Time.deltaTime;
            }

        }


    }

    float GetNowVelocityVal()
    {
        if (controllerCharacter.velocity == Vector3.zero)
        {
            vecNowVelocity = Vector3.zero;
        }
        else
        {

            Vector3 retVelocity = controllerCharacter.velocity;
            retVelocity.y = 0.0f;

            vecNowVelocity = Vector3.Lerp(vecNowVelocity, retVelocity, moveChageSpd * Time.fixedDeltaTime);

        }
        return vecNowVelocity.magnitude;
    }

    void VecDirectionChangeBody()
    {
        if (GetNowVelocityVal() > 0.0f)
        {
            Vector3 newForward = controllerCharacter.velocity;
            newForward.y = 0.0f;

            transform.forward = Vector3.Lerp(transform.forward, newForward, rotateBodySpd * Time.deltaTime);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 hitPosition = hit.point;
            float hitDistance = hit.distance;

            if (Physics.Raycast(ray, out hit, 3, layerMask, QueryTriggerInteraction.Ignore))
            {
                if (hit.collider.tag == "Item")
                {
                    isItem = true;
                    rayText.gameObject.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        nowItem = hit.collider.gameObject.GetComponent<ItemPickup>().item;
                        ItemAddUse.Instace.AddNewItem();
                        Destroy(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                rayText.gameObject.SetActive(false);
                isItem = false;
            }
        }
    }

    private void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            mainCamera.fieldOfView -= 13;

        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            stamina -= 2 * Time.deltaTime;
            if (stamina > 0)
            {
                spd = 6;
            }
            else if (stamina <= 0)
            {
                stamina = 0;
                spd = 3;
            }
           
            
            

        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            mainCamera.fieldOfView += 13;
            spd = 3;
        }

        if (stamina < 5)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
                stamina += 3 * Time.deltaTime;

        }

    }


    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Enemy"))
        {
            isHolding = true;
            sapceEvent.gameObject.SetActive(true);
            spaceT.gameObject.SetActive(true);
        }

    }

    private void UseItem()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
        ItemAddUse.Instace.Clear1(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ItemAddUse.Instace.Clear1(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            ItemAddUse.Instace.Clear1(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            ItemAddUse.Instace.Clear1(3);
        }
        
    }

    private void SpaceEvent()
    {
        if (isHolding == true)
        {
            sapceEvent.value -= 0.0003f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spd = 0;
                sapceEvent.value += 0.02f;
            }
            if (sapceEvent.value == 0)
            {
                SceneM.instance.ChangeScene("TestFinish");
            }
        }

        if (sapceEvent.value >= 1)
        {
            isHolding = false;
            sapceEvent.gameObject.SetActive(false);
            spaceT.gameObject.SetActive(false);
            if (isHolding == false)
            {
                sapceEvent.value = 0.05f;
                spd = 3;

            }
        }
    }



}

