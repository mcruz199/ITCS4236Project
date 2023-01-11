using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTrigger : MonoBehaviour
{

    public Vector3 playerChange;
    public string sceneName;
    public GameObject player;

    void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            transitionRoom(player.transform);
        }
    }

    private void transitionRoom(Transform trans)
    {
        trans.position = playerChange;
    }
}
