using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_translation : MonoBehaviour
{
    [Header("Character Movement Variables")]
    [SerializeField]private float defaultSpeed = 5.0f;
    [SerializeField]private float walkSpeed = 1.5f; 
    [SerializeField]private float jumpSpeed = 7.0f;
    [SerializeField]private float gravity = 18.0f;

    [Header("Character Body Attributes")]
    [SerializeField]private float characterHeight = 2f;
    [SerializeField]private float characterCrouchingHeight = 1f;

    CharacterController characterController; 
    private Vector3 moveDirection = Vector3.zero;
    private float speed;
    private bool isWalking = false;
    private bool isCrouching = false; 
    private float horizontalMovement;
    private float verticalMovement;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        speed = defaultSpeed;
        characterController.height = characterHeight;
    }

    // Update is called once per frame
    void Update()
    {
        // block all player movement if dialogue is active
        if (dialogue_manager.Instance != null && dialogue_manager.Instance.isDialogueActive)
        {
            moveDirection = Vector3.zero;
            if (characterController != null)
                characterController.Move(Vector3.zero);
            return;
        }

        GetInput();
        CheckCrouch();

        if(characterController.isGrounded)
        {
            GroundMovement();
        }   
        else  
        {
            NotGroundMovement();
        } 

        characterController.Move(moveDirection * Time.deltaTime);
            
    }

    private void GetInput()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
    }

    private void CheckCrouch()
    {
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            characterController.height = characterHeight;
            isCrouching = false; 
        }
    }
    
    private void GroundMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            characterController.height = characterCrouchingHeight;
            isCrouching = true; 
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        if(isCrouching || isWalking)
        {
            speed = walkSpeed;
        }
        else
        {
            speed = defaultSpeed;
        }

        moveDirection = transform.right * horizontalMovement - transform.forward * verticalMovement;    // changed "+ transform.forward" to "- transform.forward"

        if (moveDirection.magnitude > 1)
        {
            moveDirection = moveDirection.normalized;
        }

        moveDirection *= speed;

        if (Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }
    }

    private void NotGroundMovement()
    {
        if(isWalking || isCrouching)
        {
            speed = walkSpeed;
        }
        else 
        {
            speed = defaultSpeed;
        }

        moveDirection = (transform.right *horizontalMovement *speed)+ 
            new Vector3(0f,moveDirection.y -gravity * Time.deltaTime, 0f)  + 
            (-transform.forward *verticalMovement * speed);                     // changed "+ transform.forward" to "- transform.forward"
    }               
}
