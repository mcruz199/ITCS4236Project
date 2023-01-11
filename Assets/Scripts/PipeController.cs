using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public Animator animator;
    public GameObject pipe;
    public bool isPickedUp;
    
    public void pickUpPipe()
    {
        if(!isPickedUp)
        {
            isPickedUp = true;
            animator.SetBool("IsPickedUp", true);
            Debug.Log("Picked up Pipe");
            Destroy(pipe);
        }
    }

    public void dropPipe()
    {
        isPickedUp = false;
        animator.SetBool("IsPickedUp", false);
        Debug.Log("Dropped Pipe");
    }
}
