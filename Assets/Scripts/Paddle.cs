using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;

    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();

    }

    void Update () {
        if(autoPlay == false)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
       
	}

    void AutoPlay()
    {
        
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0.0f);
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.7f, 15.3f);
        this.transform.position = paddlePos;
    }



    void MoveWithMouse()
    {
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0.0f);

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.7f, 15.3f);


        this.transform.position = paddlePos;
    }



}
