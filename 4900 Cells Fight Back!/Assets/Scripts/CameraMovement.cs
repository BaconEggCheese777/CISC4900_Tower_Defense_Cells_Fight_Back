using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int boundary;
    public int moveSpeed;
    public float leftLimit;
    public float rightLimit;
    public float zoomInLimit;
    private float speed = 100f;

    public float zoomOutLimit;

    private void Start()
    {
        
    }
    private void LateUpdate()
    {
        /*
        // move right
        if (transform.position.x < rightLimit && Input.mousePosition.x > Screen.width - boundary)
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }

        // move left
        if (transform.position.x > leftLimit && Input.mousePosition.x < boundary)
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        */

        if (Input.GetKey(KeyCode.A) && transform.position.x >= leftLimit)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D) && transform.position.x <= rightLimit)
            transform.Translate(Vector2.right * speed * Time.deltaTime);


    }

}