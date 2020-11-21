using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    public Animator animator;
    float speedModifier = 3f;
   [SerializeField] float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }


    void movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        animator.SetFloat("horizontalSpeed", Mathf.Abs(horizontal));
        if (horizontal!=0)
            {
            gameObject.transform.localScale = new Vector3(2 * -Mathf.Sign(horizontal), 2, 2);
            }

        //if (horizontal < 0)
        //{
        //    //animator.SetBool("mirror", false);
        //    gameObject.transform.localScale = new Vector3(2, 2, 2);
        //    Debug.Log("normal");

        //}
        //else if (horizontal > 0 )
        //{
        //   // animator.SetBool("mirror", true);
        //    gameObject.transform.localScale = new Vector3(-2, 2, 2);
        //    Debug.Log("reversed");
        //}



        cc.Move((Vector3)new Vector2(horizontal, vertical) * Time.deltaTime * speedModifier);
    }
}
