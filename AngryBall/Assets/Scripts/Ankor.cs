using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ankor : MonoBehaviour
{
    public float releaseTime = .15f;
    public float maxDragDistance = 2f;
    public GameObject nextBall;
    public Rigidbody2D rb;
    public Rigidbody2D hook;
    [SerializeField] private PlayerManager playerManager;

    private bool isPressed;

    void Update()
    {
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            else
                rb.position = mousePos;
        }
    }
    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }
    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        SoundManager.PlaySound("playerThrow");

        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        enabled = false;

        yield return new WaitForSeconds(2f);

        if(nextBall != null)
        {
            nextBall.SetActive(true);
            playerManager.TakeDamage();
        }
        else
        {
            Enemy.enemiesAlive = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
