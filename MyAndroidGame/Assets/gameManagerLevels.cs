using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManagerLevels : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject ShootingScene;
    public ParticleSystem ps;
    public GameObject light;

    private bool start = false;
    private bool ex = false;

    private float countdown = 0f;
    private bool timer = false;

    private void Awake()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (timer) countdown += Time.deltaTime;
        //Debug.Log ( countdown);

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.timeScale != 1f) Time.timeScale = 1f;
            
            timer = true;
           
            startScreen.gameObject.SetActive(false);
            if (!start)
            {
                ShootingScene.gameObject.SetActive(true);
                light.gameObject.SetActive(true);
            }
                start = true;

        }

        if(countdown >= 2f)
        {
            timer = false;
            countdown = 0f;
            if (!ex)ps.Play();
            ex = true;
            ShootingScene.gameObject.SetActive(false);
            PlayerScript.playerRB.gravityScale = 10f;
            PlayerScript.hasStarted = true;
            light.gameObject.SetActive(false);

        }
    }
    
}
