using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;
    public float thrust = 5;
    bool isGrounded;

    //para disparar
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float fuerzaDeDisparo;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }

        Vector3 movement = new Vector3(moveHorizontal * speed, rb.velocity.y, moveVertical * speed);
        rb.velocity = movement;
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(bulletSpawnPoint.forward * fuerzaDeDisparo, ForceMode.Impulse);
        }
    }

    public void Jump()
    {
        isGrounded = false;
        rb.AddForce(0, thrust, 0, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
