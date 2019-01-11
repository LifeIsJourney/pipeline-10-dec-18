using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//resposible for player movement
public class CharachterMovement : MonoBehaviour {
    public float moveSpeed = 10;
    public float jumpSpeed = 10;
    public Rigidbody swordPrefab;
    public float swordMoveSpeed=5;
    Transform firePoint;
    Rigidbody rgbd;
    bool facingRight;
    float moveDirection;
    Transform groundCheck;
    bool grounded;
    bool jump;
    bool doubleJump;
    int noOfJump;
    Animator animator;
    public GameObject deadModel;
   public Transform Sword;
    private void Awake()
    {
        groundCheck = transform.Find("groundCheck");
        firePoint = transform.Find("firePoint");
       
    }
    // Use this for initialization
    void Start () {
        animator = GetComponentInChildren<Animator>();
        facingRight = true;
        rgbd = GetComponent<Rigidbody>();
       
    }
	
	// Update is called once per frame
	void Update () {
      moveDirection = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed",Mathf.Abs(moveDirection));
        animator.SetBool("facingRight", facingRight);
       // canJump = false;
        //  transform.position += movement * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
           
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Attack();
        }
    }
    private void FixedUpdate()
    {
       
        grounded = Physics.Linecast(transform.position, groundCheck.position,LayerMask.GetMask("ground"));
        animator.SetBool("isGrounded", grounded);
        
        animator.SetFloat("vSpeed", rgbd.velocity.y);
       
        if (grounded){doubleJump = false; }
      
        rgbd.velocity = new Vector2(moveSpeed*moveDirection,rgbd.velocity.y);
        if(moveDirection < 0 && facingRight || moveDirection > 0 && !facingRight)
        {
            Flip();
        }
       
        if ((grounded ||!doubleJump) && jump )
        {
            rgbd.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
           //first time when pressed groundede is true so skip if
            if(!doubleJump && !grounded)
            {//next when jummp in air grounded is also false //then this run and stop jump
                doubleJump = true;
               
            }
            jump = false;
        }
        if (grounded)
        {
           // rgbd.velocity = new Vector2(rgbd.velocity.x, 0);
        }

        SwordMoveFromPositionError();


    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up,180, Space.World);
        
    }
    void Attack()
    {
        animator.SetTrigger("Attacking");
    }
    public void Fire()
    {
        Rigidbody obj = Instantiate(swordPrefab, firePoint.position,Quaternion.identity) as Rigidbody;
        obj.GetComponent<Rigidbody>().isKinematic = false;
        obj.AddForce(firePoint.right * swordMoveSpeed, ForceMode.Impulse);

    }
    public void FallApart()
    {
        GameObject obj = transform.Find("GhostKnight_Rig").gameObject;
        obj.SetActive (false);
        Instantiate(deadModel, transform.position, transform.rotation, transform);
    }
    void SwordMoveFromPositionError()
    {
       
        if(Sword.localPosition != Vector3.zero)
        {
            Debug.Log("resetting position of sword");
            Sword.localPosition = Vector3.zero;
        }
    }
    public void PlayerIsInBattel()
    {   
        animator.SetFloat("vSpeed", 0);
        animator.SetFloat("Speed", 0);
        animator.SetBool("isGrounded", true);
        this.enabled = false;
      
    }
}
