using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    public Transform player;

    void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {
        faceMouse();
    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        player.up = direction;
    }
}
