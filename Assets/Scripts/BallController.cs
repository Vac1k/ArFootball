using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;

    public float force = 0;
    public GameObject camera;
    public float step;
    public bool isFire;
    public GameObject startPositionball;
    public GameObject ballPrefab;
    public Image bar;
    LevelManager levelManager;

    void Start()
    {
        levelManager = (LevelManager)FindObjectOfType(typeof(LevelManager));

        Debug.Log(bar.rectTransform.sizeDelta);
        NewBall();
        isFire = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space) && !isFire && !CommonDATA.end_round)
        {
            ball.GetComponent<Rigidbody>().useGravity = true;
            ball.GetComponent<Rigidbody>().AddForce(camera.transform.forward * force, ForceMode.Impulse);
            ball.transform.SetParent(null);
            ball.GetComponent<Ball>().DestroyBall();
            force = 0;
            isFire = true;
            levelManager.Size_Bar(0);
            ball = null;
            StartCoroutine(PauseFire());

        }


        if (Input.GetKey(KeyCode.Space) && !isFire&&!CommonDATA.end_round)
        {
            force += step;

            if (force > CommonDATA.max_force)
            {


                force = CommonDATA.max_force;
            }


            levelManager.Size_Bar(force);



        }

    }

    IEnumerator PauseFire()
    {

        yield return new WaitForSeconds(3);
        isFire = false;
        NewBall();

    }

    void NewBall()
    {
        if (!CommonDATA.end_round)
        {
            ball = Instantiate(ballPrefab);

            ball.transform.position = startPositionball.transform.position;
            ball.transform.SetParent(camera.transform);
        }
    }


    public void CheckCurrentBall() 
    {
        if (ball==null) 
        {
            NewBall();
        }
    }



}
