
using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 30f;
    public float scrollSpeed = 5f;
    public float panBorderThickness = 10f;

    public float minimumY = 10f;
    public float maximumY = 80;

    private bool doMovement = true;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }
        if (!doMovement)
        {
            return;
        }
        
        moveCamera();

        scrollUpAndDown();
    }

    void moveCamera()
    {
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * (panSpeed * Time.deltaTime),Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * (panSpeed * Time.deltaTime),Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * (panSpeed * Time.deltaTime),Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * (panSpeed * Time.deltaTime),Space.World);
        }
    }

    void scrollUpAndDown()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(scroll);

        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Math.Clamp(pos.y, minimumY, maximumY);

        transform.position = pos;
    }
}
