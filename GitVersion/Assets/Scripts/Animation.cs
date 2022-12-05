using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animation : MonoBehaviour
{

    Animator anim;

    public float coolDownTime = 1;
    private float nextFireTime = 0f;
    public static int no0fClicks = 0;
    float lastClickedTime = 0;

    [SerializeField] public bool isGrounded = false;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
    }

        public void LoadFirstScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        //Movment Animation

    if (Input.GetKeyDown (KeyCode.M)){
       LoadFirstScene();
       print("Yob");
    }
        
        anim.SetInteger("Condition", 0);
        if  (Input.GetKey (KeyCode.D))
        {
            if (Input.GetKey (KeyCode.LeftShift))
            {
            transform.localScale = new Vector3(-0.2f, 0.27f, 0.2f);
            anim.SetInteger("Condition", 2);
            }
            else
            {
            transform.localScale = new Vector3(-0.2f, 0.27f, 0.2f);
            anim.SetInteger("Condition", 1);
            }
        }
        else if (Input.GetKey (KeyCode.A))
        {
            if (Input.GetKey (KeyCode.LeftShift))
            {
            transform.localScale = new Vector3(0.2f, 0.27f, 0.2f);
            anim.SetInteger("Condition", 2);
            }
            else
            {
            transform.localScale = new Vector3(0.2f, 0.27f, 0.2f);
            anim.SetInteger("Condition", 1);
            }
        }

        //Jump Animation
        
        if (Input.GetKey (KeyCode.Space))
        {
            anim.SetBool("inAir", true);
        }
        else{
            anim.SetBool("inAir", false);
        }
        


        //Crouch animation
        if  (Input.GetKeyDown (KeyCode.LeftControl))
        {
            anim.SetBool("isCrouching", true);
        }
        if  (Input.GetKeyUp (KeyCode.LeftControl))
        {
            anim.SetBool("isCrouching", false);
        }


        //Attack Animation
        if (Time.time - lastClickedTime > coolDownTime)
        {
            no0fClicks = 0;
            anim.SetInteger("Attack", 0);
        }
        if (Time.time > nextFireTime && Input.GetMouseButtonDown(0))
        {
            OnClick();
        }

    }
    
    //Attack combo
    void OnClick()
    {
        lastClickedTime = Time.time;
        no0fClicks++;
        if(no0fClicks == 1 )
        {
            anim.SetInteger("Attack", 1);
        }
        else if(no0fClicks == 2 )
        {
            anim.SetInteger("Attack", 2);
        }
        else if(no0fClicks == 3 )
        {
            anim.SetInteger("Attack", 3);
        }
    }
}
