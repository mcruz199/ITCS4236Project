using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKeyController : MonoBehaviour
{
    public bool isInRange;
    public string keyName;
    public bool isInInventory;
    public KeyCode interactKey;
    public BlueKeyController key;
    public static bool blueKeyPickedUp;
    public static bool greenKeyPickedUp;
    public static bool redKeyPickedUp;
    public AudioClip sound;
    public AudioSource source;

    private void Start()
    {
        CheckKeys();
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                if (!key.isInInventory) {
                    key.isInInventory = true;

                    if(key.keyName == "Blue Key")
                    {
                        Destroy(GameObject.Find("Blue Key"));
                        blueKeyPickedUp = true;
                    }

                    if (key.keyName == "Green Key")
                    {
                        Destroy(GameObject.Find("Green Key"));
                        greenKeyPickedUp = true;
                    }

                    if (key.keyName == "Red Key")
                    {
                        Destroy(GameObject.Find("Red Key"));
                        redKeyPickedUp = true;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
    }

    public bool isBlueKeyPickedUp()
    {
        return blueKeyPickedUp;
    }

    public bool isGreenKeyPickedUp()
    {
        return greenKeyPickedUp;
    }

    public bool isRedKeyPickedUp()
    {
        return redKeyPickedUp;
    }

    public void CheckKeys()
    {
        if (blueKeyPickedUp)
        {
            Destroy(GameObject.Find("Blue Key"));
        }

        if (greenKeyPickedUp)
        {
            Destroy(GameObject.Find("Green Key"));
        }

        if (redKeyPickedUp)
        {
            Destroy(GameObject.Find("Red Key"));
        }
    }

}

