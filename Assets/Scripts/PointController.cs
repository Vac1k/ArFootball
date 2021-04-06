using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public ParticleSystem pint;
    public int score;
    LevelManager levelManager;
    public AudioSource sc_sound;
    void Start()
    {
         levelManager = (LevelManager)FindObjectOfType(typeof(LevelManager));
        sc_sound = gameObject.GetComponent<AudioSource>();
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        levelManager.SetScore(score);
        pint.Play();
        sc_sound.Play();
        
    }

}
