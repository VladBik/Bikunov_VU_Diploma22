using UnityEngine;
using System.Collections;
using System.Collections.Generic;





public class HeroSphereCollect : MonoBehaviour
{
    public int herospheres;
    public ScoreHelper scoreHelper;
    public AudioSource AudioS;
    public GameObject DmgAud;


    void Awake()
    {
        GameObject GameControllerObject = GameObject.FindWithTag("ScoreHelper");
        if (GameControllerObject != null)
        {
            scoreHelper = GameControllerObject.GetComponent<ScoreHelper>();
        }
        if (GameControllerObject == null)
        {
            Debug.Log("ScoreHelper не найден!");
        }
        AudioS = GetComponent<AudioSource>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ScoreHelper получил сферу");
            scoreHelper.AddScoreHeroSpheres(herospheres);
            AudioS.Play();
            DmgAud.SetActive(true);
            Destroy(gameObject, 0.1f);
        }

    }
}