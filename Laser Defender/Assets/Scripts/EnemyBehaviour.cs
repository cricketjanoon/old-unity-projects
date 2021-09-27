using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject projectile;
    public float health = 150f;
    public float projectileSpeed=10;
    public float shotsPerSecond = 0.5f;
    public int scoreValue = 150;
    private ScoreKeeper scoreKeepr;
    public AudioClip fireSound;
    public AudioClip deathSound;

    private void Start()
    {
     scoreKeepr=    GameObject.Find("Score").GetComponent<ScoreKeeper>();
    }

    private void Update()
    {
         float probability = shotsPerSecond * Time.deltaTime;
        if(Random.value < probability)
              Fire();
    }

    void Fire()
    {
        Vector3 startPosition = transform.position + new Vector3(0, -1f, 0);
        GameObject missile = Instantiate(projectile, startPosition, Quaternion.identity);
        missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
        AudioSource.PlayClipAtPoint(fireSound, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        Projectile missile = collision.gameObject.GetComponent<Projectile>();
        if(missile)
        {
            health -= missile.GetDemage();
            missile.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
                scoreKeepr.Score(scoreValue);
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
            }
            //Debug.Log("Hit by projectile.");

        }
    }
}
