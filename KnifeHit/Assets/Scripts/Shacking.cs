using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shacking : MonoBehaviour
{
    bool isShacking = false;
    Vector2 pos;
    float shake = 0.03f;
    int health = 7;
    [SerializeField]
    Object destructable;
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShacking)
        {
            transform.position = pos + UnityEngine.Random.insideUnitCircle * shake;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Knife")
        {
            isShacking = true;
            health--;
            if (health <= 0)
            {
                ExplodeObj();
            }
            Invoke("StopShaking", 0.5f);
        }
    }
    void StopShaking()
    {
        isShacking = false;
        transform.position = pos;
    }
    void ExplodeObj()
    {
        GameObject destruct = (GameObject)Instantiate(destructable);
        destruct.transform.position = transform.position;
        Destroy(gameObject);
    }
}
