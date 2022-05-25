using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugging : MonoBehaviour
{
    public bool debugPossible;
    bool debugActive;
    CanvasGroup debugCanvas;

    public GameObject DebugLight;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        debugPossible = Application.isEditor;
        debugCanvas = gameObject.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (debugPossible)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                debugActive = !debugActive;
                if (debugActive)
                {
                    Cursor.lockState = CursorLockMode.None;
                    debugCanvas.alpha = 1;
                    debugCanvas.interactable = true;
                    debugCanvas.blocksRaycasts = true;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    debugCanvas.alpha = 0;
                    debugCanvas.interactable = false;
                    debugCanvas.blocksRaycasts = false;
                }
            }
        }
    }

    public void ToggleLight()
    {
        if (DebugLight.activeSelf)
        {
            DebugLight.SetActive(false);
        }
        else
        {
            DebugLight.SetActive(true);
        }
    }

    public void MovePlayer()
    {
        CharacterController characterController = player.GetComponent<CharacterController>();
        characterController.enabled = false;
        player.position = new Vector3(0.5f,2f,69.5f);
        Debug.Log(player.position);
        player.rotation = Quaternion.Euler(0, 0, 0);
        characterController.enabled = true;
    }
}
