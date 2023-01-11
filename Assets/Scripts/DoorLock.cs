using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorLock : MonoBehaviour
{
    public bool isInRange;
    public bool isUnlocked;
    public string doorName;
    public KeyCode interactKey;
    public BlueKeyController key;
    public static bool blueDoorOpened;
    public static bool greenDoorOpened;
    public static bool redDoorOpened;

    // Update is called once per frame

    void Start()
    {
        CheckDoors();
    }

    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey)) { 
                if (key.isBlueKeyPickedUp() && doorName == "Blue Door")
                {
                    blueDoorOpened = true;
                    Destroy(GameObject.Find("Blue Door"));
                }

                if (key.isGreenKeyPickedUp() && doorName == "Green Door")
                {
                    greenDoorOpened = true;
                    Destroy(GameObject.Find("Green Door"));
                }

                if (key.isRedKeyPickedUp() && doorName == "Red Door")
                {
                    redDoorOpened = true;
                    Destroy(GameObject.Find("Red Door"));
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

    public void CheckDoors()
    {
        if (blueDoorOpened)
        {
            Destroy(GameObject.Find("Blue Door"));
        }

        if (greenDoorOpened)
        {
            Destroy(GameObject.Find("Green Door"));
        }
    }

}
