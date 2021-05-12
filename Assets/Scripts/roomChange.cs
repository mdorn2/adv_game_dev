using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class roomChange : MonoBehaviour
{

    public string roomName;
    public Scene room;

    public void changeRoom()
    {
        SceneManager.LoadScene(roomName);

    }


}
