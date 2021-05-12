using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutRoom : MonoBehaviour
{
    // Start is called before the first frame update
    public string roomName;
    public Scene room;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void changeRoom()
    {
        SceneManager.LoadScene(roomName);
    }
}
