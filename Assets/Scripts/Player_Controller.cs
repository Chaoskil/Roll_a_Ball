using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {

    [SerializeField]
    private float Speed;

    [SerializeField]
    private Text countText;

    private Rigidbody rb;
    private int Count;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Count = 0;
        SetCountText();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVerticle = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVerticle);

        rb.AddForce(movement * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            Count = Count + 1;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        countText.text = "Count: " + Count.ToString();
    }
}
