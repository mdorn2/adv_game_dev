using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceneCheck : MonoBehaviour
{

    public Camera CutsceneCamera;
    public Camera MainCamera;
    bool cutscene;
    public Transform groundCheck;
    public Transform ceilingCheck;
    public LayerMask cutsceneMask;


    // Start is called before the first frame update
    void Start()
    {
        CutsceneCamera.enabled = false;
        MainCamera.enabled = true;
    }

    public void runCutScene() {
        Debug.Log("Cutscening");
        MainCamera.enabled = false;
        CutsceneCamera.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        cutscene = Physics.CheckCapsule(groundCheck.position, ceilingCheck.position, 1f, cutsceneMask);

        if (cutscene) {
            runCutScene();
        } else {
            CutsceneCamera.enabled = false;
            MainCamera.enabled = true;
        }
    }
}
