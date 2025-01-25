using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveMouse : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

}
