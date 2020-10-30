using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerEntity playerEntity;
    private Vector3 moveAmount;
    private Vector3 smoothMoveVelocity;
    private Rigidbody rb;
    [SerializeField]private float inputX;
    private bool bulletFired = false;

    private float currentFireRate = 0;
    private UIManager uiManager;
    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerEntity = GetComponent<PlayerEntity>();
    }

    private void Start()
    {
        uiManager = GameObject.Find("LevelManager").GetComponent<UIManager>();
    }


    private void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        Vector3 targetMoveAmount = Vector3.forward * playerEntity.movementSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

#if UNITY_ANDROID
        if (bulletFired)
            currentFireRate -= Time.deltaTime;
        else
            bulletFired = false;
#endif

#if UNITY_STANDALONE
        if (inputX < 0)
            animator.SetFloat("Left", 1);
        else if (inputX > 0)
            animator.SetFloat("Right", 1);
        else
        {
            animator.SetFloat("Left", 0);
            animator.SetFloat("Right", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && currentFireRate <= 0)
            Shot();
        else
            currentFireRate -= Time.deltaTime;
#endif
    }

    private void FixedUpdate()
    {
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + localMove);

        transform.Rotate(0, inputX * playerEntity.rotationSpeed, 0);
    }

    public void Shot()
    {
        Instantiate(playerEntity.shotPrefab, playerEntity.spawnPosition.position, playerEntity.spawnPosition.rotation);

        currentFireRate = playerEntity.fireRate;

        uiManager.StartCd(playerEntity.fireRate);
    }

    public void SimulateLeftPressedInput()
    {
        inputX = -1;
    }

    public void SimulateLeftReleasedInput()
    {
        if (inputX == -1f)
            inputX = 0f;
    }

    public void SimulateRightPressedInput()
    {
        inputX = 1f;
    }

    public void SimulateRightReleasedInput()
    {
        if (inputX == 1f)
            inputX = 0f;
    }

    public void SimulateShotPressedInput()
    {
        if (currentFireRate <= 0)
        {
            bulletFired = true;
            Shot();
        }
    }
}
