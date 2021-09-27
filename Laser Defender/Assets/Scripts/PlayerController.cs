using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float health = 250;
    public float speed = 10;
    float xMin, xMax;
    public GameObject projectile;
    public float projectileSpeed = 10;
    public float firingRate = 0.2f;
    public AudioClip fireSound;


    // Use this for initialization
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftmost.x + 0.5f;
        xMax = rightmost.x - 0.5f;
    }



    void Fire()
    {
        GameObject beam = Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
        beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.0000001f, firingRate);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }

        float xNew = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(xNew, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if (missile)
        {
            health -= missile.GetDemage();
            missile.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
            }
          //  Debug.Log("Hit by projectile.");

        }

    }
}
