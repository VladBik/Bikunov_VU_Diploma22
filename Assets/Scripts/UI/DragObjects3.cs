using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObjects3 : MonoBehaviour
{
    private Vector2 mousePosition;
    public GameObject Aud11;
    private float offsetX, offsetY;
    public int scoreRareAdd = 1;

    public static bool mouseButtonReleased;
    public CommonHeroGainCauldron3 colorCouldron;
    
    private void Start()
    {
        GameObject GameControllerObject = GameObject.FindWithTag("GameController");
        if (GameControllerObject != null)
        {
            colorCouldron = GameControllerObject.GetComponent<CommonHeroGainCauldron3>();
         }
        if (GameControllerObject == null)
         {
        Debug.Log("Котел не найден!");
          }
        
    }
    private void OnMouseDown()
    {
        mouseButtonReleased = false;
        offsetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        offsetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - offsetX, mousePosition.y - offsetY);

    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        string thisGameobjectName;
        string collisionGameobjectName;

        thisGameobjectName = gameObject.name.Substring(0, name.IndexOf("_"));
        collisionGameobjectName = collision.gameObject.name.Substring(0, name.IndexOf("_"));

        if (mouseButtonReleased && thisGameobjectName == "Idol1" && thisGameobjectName == collisionGameobjectName)
        {
            Instantiate(Resources.Load("Derevo_Object"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
           
            Aud11.SetActive(true);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (mouseButtonReleased && thisGameobjectName == "Derevo" && thisGameobjectName == collisionGameobjectName)
        {
            Instantiate(Resources.Load("Perun_Object"), transform.position, Quaternion.identity);
            mouseButtonReleased = false;
            
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
