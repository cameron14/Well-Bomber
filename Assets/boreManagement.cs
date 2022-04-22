using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boreManagement : MonoBehaviour
{

    public bool moveToWell = true;
    public float speed = 4f; // default speed of tunnel bore - change speed in inspector
    //public float endPoint = 1.0f;


    //Vector2 startPosition = new Vector2 (transform.position.x, 0); 
    //Vector2 endPosition = new Vector2 (-79, 0); // where the well is


    Vector2 endPosition = new Vector2(-79f, 1.63f);
    //Vector2 position = gameObject.transform.position;







    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("boreEndtPosition: " + endPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, endPosition, step);


        //if(transform.position.x != endPoint) 
        //{

        //    transform.Translate(Vector2.left * speed * Time.deltaTime);
        //}







    }
}
