using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

    bool isInControl = false;
    Vector2 mousePosition;
    [SerializeField]
    float moveSpeed = 0.0f;

    [SerializeField]
    SceneChanger sceneChanger = null;

    [SerializeField]
    float delayUntilLevelChange = 3.0f;

    UnityEngine.UI.Text gameOverText = null;

	// Use this for initialization
	void Start () {
        sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!isInControl && Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            isInControl = (hit.collider != null && hit.collider.transform == this.transform);
        }
        else if(isInControl && Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
        else
        {
            isInControl = false;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Wall":
            case "DeathObject":
                WeAreKilled();
                break;
            case "Finish":
                LevelComplete();
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*You should get a */switch(collision.gameObject.tag)
        {
            case "Finish":
                LevelComplete();
                break;
            default:
                break;
        }
    }

    private void WeAreKilled()
    {
        Destroy(gameObject);
        sceneChanger.StartDelayToLoadLevel(delayUntilLevelChange, SceneManager.GetActiveScene().name);
    }

    private void LevelComplete()
    {
        if(SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCount)
            sceneChanger.StartDelayToLoadLevel(delayUntilLevelChange, SceneManager.GetActiveScene().buildIndex+1);
        else
        {
            Debug.Log("Congrats you win, no more levels");
            gameOverText = GameObject.Find("GameOverText").GetComponent<UnityEngine.UI.Text>();
            if(gameOverText != null)
                gameOverText.text = "CONGRATS YOU WIN. NO MORE LEVELS TO COMPLETE";
        }
    }
}
