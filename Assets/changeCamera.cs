using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCamera : MonoBehaviour
{

    public GameObject player;

    public GameObject camera;

    public GameObject canvas;

    // Start is called before the first frame update
    public void gameStart(){
        player.SetActive(true);
        camera.SetActive(false);
        canvas.SetActive(false);
    }
}
