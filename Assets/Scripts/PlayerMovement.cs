using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public CharacterController CharController;

    public float walkSpeed;
    public float runSpeed;
    private Vector3 finalSpeed;

    public Transform cameraPoint;
    public float mouseSensitivity;
    public bool isInverted;

    public float gravityModifier;

    public bool canJump;
    public float JumpPower;

    public Transform groundCheckerPoint;
    public LayerMask groundLayer;

    public Weapon currentWeapon;
    private Transform firePoint;

    public Animator Anim;

    public int playerScore = 0;
    public float Health;


    private int CurrentWeapon;
    public List<Weapon> Guns;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = Guns[CurrentWeapon];
        currentWeapon.gameObject.SetActive(true);
        firePoint = currentWeapon.FirePoint;
        UiManager.instance.ShowBulletCount(currentWeapon.currentAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CameraRotation();
        ShootBullet();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchGuns();
        }

        if(currentWeapon != null)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                currentWeapon.ReloadAmmo();
            }
        }
    }

    // THIS WILL HANDLE PLAYERS WALK,RUN AND JUMP
    void Movement()
    {

        float ystore = finalSpeed.y;

        var horizontalValue = transform.right * Input.GetAxis("Horizontal");
        var verticalValue = transform.forward * Input.GetAxis("Vertical");


        //if (horizontalValue.magnitude == 0.0f && verticalValue.magnitude == 0.0f)
        //    return;

        // PLAYER MOVEMENT
        finalSpeed = (horizontalValue + verticalValue) * walkSpeed;

        //Anim.enabled = finalSpeed == Vector3.zero;

        //if(finalSpeed == Vector3.zero)
        //{
        //    Anim.enabled = false;
        //}
        //else
        //{
        //    Anim.enabled = true;
        //}

        if (Input.GetKey(KeyCode.LeftShift))
        {
            finalSpeed = (horizontalValue + verticalValue) * runSpeed;
        }



        finalSpeed.y = ystore;
        //ALL TIME GRAVITY
        finalSpeed.y += Physics.gravity.y * gravityModifier * Time.deltaTime;



        if (CharController.isGrounded)
        {
            finalSpeed.y = Physics.gravity.y * gravityModifier * Time.deltaTime;
        }

        canJump = Physics.OverlapSphere(groundCheckerPoint.position, 0.25f, groundLayer).Length > 0;


        //canJump = Physics.OverlapSphere(gr)


        if (canJump && Input.GetKey(KeyCode.Space))
        {
            finalSpeed.y = JumpPower;
        }

        CharController.Move(finalSpeed * Time.deltaTime);


    }

    //FOR ROTATION
    void CameraRotation()
    {
        Vector2 mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"),
            Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        if (isInverted)
        {
            mouseDirection.x = -mouseDirection.x;
            mouseDirection.y = -mouseDirection.y;
        }

        this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y + mouseDirection.x,
            transform.rotation.eulerAngles.z);

        cameraPoint.rotation = Quaternion.Euler(cameraPoint.rotation.eulerAngles
            + new Vector3(-mouseDirection.y, 0f, 0f));

    }


    void ShootBullet()
    {

        if (Input.GetMouseButton(0) && currentWeapon.canAutoFire)
        {
            if (currentWeapon.fireCounter <= 0)
            {
                FireBullet();
            }
        }

        if (Input.GetMouseButtonDown(0) && currentWeapon.fireCounter <= 0)
        {
            RaycastHit hit;

            if(Physics.Raycast(cameraPoint.position,cameraPoint.forward,out hit, 50f))
            {
                if (Vector3.Distance(cameraPoint.position, hit.point) > 20)
                {
                    firePoint.LookAt(hit.point);
                }
            }
            else
            {
                firePoint.LookAt(cameraPoint.position + (cameraPoint.forward * 30f));
            }
            FireBullet();
        }
    }

    void FireBullet()
    {
        if (currentWeapon.currentAmmo > 0)
        {
            currentWeapon.currentAmmo--;
            UiManager.instance.ShowBulletCount(currentWeapon.currentAmmo);
            Instantiate(currentWeapon.Bullet, firePoint.position, firePoint.rotation);
            currentWeapon.fireCounter = currentWeapon.fireRate;
        }
    }

    void SwitchGuns()
    {
        currentWeapon.gameObject.SetActive(false);
        CurrentWeapon++;

        if (CurrentWeapon >= Guns.Count)
        {
            CurrentWeapon = 0;
        }
        currentWeapon = Guns[CurrentWeapon];
        currentWeapon.gameObject.SetActive(true);
        firePoint = currentWeapon.FirePoint;
        UiManager.instance.ShowBulletCount(currentWeapon.currentAmmo);


    }
}
