using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class DoorCode2 : MonoBehaviour
{
    public TMPro.TMP_InputField password;
    public string Donetext;
    private const string SecretMessage = "bill cipher"; // The secret code
    public bool done = false;

    private bool awaitingCodeInput = false; // Flag to track if we're waiting for input

    void Start()
    {
        password.gameObject.SetActive(false);
    }

    void Update()
    {
        // Check if the player presses the "9" key
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Cursor.lockState = CursorLockMode.None;
            password.gameObject.SetActive(true);
        }
    }

    public void SubmitPassword() {
        Cursor.lockState = CursorLockMode.Locked;
        password.gameObject.SetActive(false);

        if (password.text == SecretMessage) {
            gameObject.SetActive(false);
        }
    }
}