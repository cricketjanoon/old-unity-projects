using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {


    public GameObject smoke;
    public AudioClip crack;
    public static int BreakableBricks = 0;
    public int maxHit;
    private int timesHit;
    private LevelManager lm;
    public Sprite[] sprites;

    // Use this for initialization
    void Start () {
        if (this.tag == "Breakable")
            BreakableBricks++;
        timesHit = 0;
        lm = GameObject.FindObjectOfType<LevelManager>();

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.tag == "Breakable")
        {
            timesHit++;
            if (timesHit >= maxHit)
            {
                AudioSource.PlayClipAtPoint(crack, transform.position);
                Destroy(gameObject);
                GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity );
                smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
                BreakableBricks--;
                lm.BrickDestroyed();
                //print(BreakableBricks);
            }
            else
                LoadSprite();
        }
    }

    void LoadSprite()
    {
        int spriteIndex = timesHit - 1;
        this.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];

    }

    void SimulateWin()
    {
        lm.LoadNextLevel();

    }
    
}
