using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;
    private Vector3 movement;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }
    private void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");

        //float moveVertical = Input.GetAxis("Vertical");
        movement = Input.acceleration * speed;//new Vector3(moveHorizontal, 0.0f, moveVertical);
        System.Console.WriteLine(movement.x + " " + movement.y + " " + movement.z);
        rb.AddForce(movement.x, movement.y, (movement.z*-1)-1);
        setCountText();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
           // setCountText();
        }
    }

    void setCountText()
    {
        countText.text = movement.x + " " + movement.y + " " + movement.z; //"Count: " + count.ToString();
        if (count >= 4)
        {
            winText.text = "You won";
        }
    }
}
