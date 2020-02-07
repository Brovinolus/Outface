using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    bool currentMode;
    public bool facingRight;
    public GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Fliping(horizontal);
    }


    public void Fliping(float horizontal)
    {
        if ((horizontal > 0 && !facingRight || horizontal < 0 && facingRight) && manager.ready == true)
        {
            facingRight = !facingRight;

            //variable
            Vector3 theScale = transform.localScale;

            //using variable
            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
}
