using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeLevel : MonoBehaviour
{

    public LayerMask playerMask;

    public Transform door;

    public string roomName;

    public Scene room;

    bool playerCol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerCol = Physics.CheckCapsule(door.position, door.position, 1f, playerMask);

        if(playerCol){
            SceneManager.LoadScene(roomName);
        }
    }
}
