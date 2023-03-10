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
    private int spd = 3;
    public float stamina = 5;


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
        Sound();

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
            int walkSpd = spd;

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



    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("Teacher"))
        {
            isHolding = true;
            sapceEvent.gameObject.SetActive(true);
            spaceT.gameObject.SetActive(true);
            StartCoroutine(BloodScreen());
        }

    }

    private void UseItem()
    {
        Debug.LogWarning(spd);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ItemAddUse.Instace.Clear(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ItemAddUse.Instace.Clear(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ItemAddUse.Instace.Clear(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ItemAddUse.Instace.Clear(3);
        }

        if (ItemAddUse.Instace.isItem1 == true)
        {
            stamina = 5;
            ItemAddUse.Instace.isItem1 = false;
        }
        if (ItemAddUse.Instace.isItem2 == true)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                Invoke("Itemfalse2", 5f);
                spd = 9;
                
            }
        }

        if (ItemAddUse.Instace.isItem3 == true)
        {
            Invoke("Itemfalse3", 5f);
            spd = 6;

        }

        if (ItemAddUse.Instace.isItem4 == true)
        {
            Invoke("Itemfalse4", 5f);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                spd = 9;

            }
            spd = 6;

        }
    }

    private void Itemfalse2()
    {
        ItemAddUse.Instace.isItem2 = false;
    }
    private void Itemfalse3()
    {
        ItemAddUse.Instace.isItem3 = false;
    }
    private void Itemfalse4()
    {
        ItemAddUse.Instace.isItem4 = false;
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
                StopCoroutine(BloodScreen());
                bloodImage.color = new Color(1, 0, 0, 0);
            }
        }
    }
    private void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            mainCamera.fieldOfView -= 13;
            SoundManager.instance.RunSoundPlay();

        }
        if (Input.GetKey(KeyCode.LeftShift))
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
            SoundManager.instance.RunSoundStop();
            spd = 3;
        }
        if (stamina < 5)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
                stamina += 3 * Time.deltaTime;
        }

    }

    private void Sound()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            SoundManager.instance.WalkSoundPlay();
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            SoundManager.instance.WalkSoundStop();
        }
    }

    public Image bloodImage;
    IEnumerator BloodScreen()
    {
        bloodImage.color = new Color(1, 0, 0, Random.Range(0.2f, 0.3f));
        yield return new WaitForSeconds(4);
    }

}



