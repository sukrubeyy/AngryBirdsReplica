using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    bool isPress;
    public Rigidbody2D rb;
    public Rigidbody2D hookRb;
    public float maxDistance = 2f;
    public float leftTime = .15f;
    public GameObject bird;
    private void Update()
    {
        if(isPress)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, hookRb.position)>maxDistance)
            {
                rb.position = hookRb.position + (mousePos - hookRb.position).normalized*maxDistance;
            }
            else
            {
                rb.position = mousePos;
            }
        }
    }
    void OnMouseDown()
    {
        isPress = true;
        rb.isKinematic = true;
    }

     void OnMouseUp()
    {
        isPress = false;
        rb.isKinematic = false;
        StartCoroutine(leftBird(leftTime));
    }

    IEnumerator leftBird(float duration)
    {
        yield return new WaitForSeconds(duration);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(2f);
        if(bird!=null)
        {
            bird.SetActive(true);
        }
        
        else if(bird==null || enemyScript.enemiesCount<=0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
