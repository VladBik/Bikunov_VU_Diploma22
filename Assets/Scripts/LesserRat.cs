using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LesserRat : MonoBehaviour
{
    [SerializeField]
    private GameObject item1;
    [SerializeField]
    private float _dropchanse = 30;
    float rnd;

    protected Animator _anim;
   

    public AudioSource audioSource;
    

    public float speed = 1;
    public float maxDistance = .1f;

    

  

   
    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
     
        audioSource = GetComponent<AudioSource>();

        _dropchanse = 30;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DropItem();
            audioSource.Play();
            _anim.SetTrigger("Death");
            Debug.Log("Герой раздавил 1 крыску");
            Destroy(gameObject, 0.30f);

        }
    }



    public void DropItem()
    {
        

        rnd = UnityEngine.Random.Range(0, 100);
        if (rnd <= _dropchanse)
        {
            GameObject Item = Instantiate(item1, transform.position, Quaternion.identity);
            Debug.Log(" Выпало из врага");

        }
        else
        {
            Debug.Log("Ничего не выпало");
            Destroy(gameObject, 0.40f);
        }
    }


}
