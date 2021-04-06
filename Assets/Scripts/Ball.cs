using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (CommonDATA.isFound)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CommonDATA.isFound) 
        {
            gameObject.GetComponent<Renderer>().enabled = true;
        }
        else 
        {
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
    public void DestroyBall()
    {
        StartCoroutine(PauseFire());
    }
    public IEnumerator PauseFire()
    {

        yield return new WaitForSeconds(5);
        Destroy(gameObject);


    }   
}
