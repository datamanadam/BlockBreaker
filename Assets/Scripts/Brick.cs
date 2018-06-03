using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;

    public static int breakableCount = 0;

    private bool isBreakable;
    private int timesHit;
    private LevelManager levelmanager;

	// Use this for initialization
	void Start () {
        isBreakable = (this.tag == "Brekable");
        //Keep Track of Brekable Bricks
        if (isBreakable)
        {
            breakableCount++;
            
        }

        levelmanager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {

        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {

            HandleHits();
        }
           
    }

    void HandleHits()
    {
        int maxHits;
        timesHit++;
        maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelmanager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }

    }



    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }



    // TODO REmove this method once we can actually win
    void SimulateWin()
    {
        levelmanager.LoadNextLevel();
    }


}
