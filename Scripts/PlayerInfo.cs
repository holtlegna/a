using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
   [SerializeField]
    private int Lives;
    private int Points = 0;
    private bool respawnEnemies = false;

    public GameObject PlayerRef;
    public float WaitToRespawn = 5f;
    public Text LivesRef;
    public Text PtsRef;
    public Button GameOverRef;

    public void IncreaseLives()
    {
        Lives++;
    }

    private void Update()
    {
        LivesRef.text = Lives.ToString();
        PtsRef.text = "Pts: " + Points.ToString();

        if(respawnEnemies)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("projectile"))
            {
                obj.GetComponent<Interactable>().Remover();
            }
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("bullet"))
            {
                obj.GetComponent<Interactable>().Remover();
            }
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("enemy"))
            {
                GameObject respawn = GameObject.FindGameObjectWithTag("Respawn");
                obj.transform.position = Vector3.Lerp(obj.transform.position, respawn.transform.position + Vector3.up * 2f, 0.03f);
            }
        }

        if(Lives == 0)
        {
            PlayerPrefs.SetInt("points", Points);
            GameOverRef.gameObject.SetActive(true);
        }
    }

    public void DecreaseLives()
    {
        if(Lives > 0)
        {
            Lives--;
            if(Lives > 0)
                StartCoroutine(Respawn());
        }
    }

    public void AddPoints(int amount)
    {
        Points += amount;

    }

    private IEnumerator Respawn()
    {
        respawnEnemies = true;
        yield return new WaitForSeconds(WaitToRespawn);
        Instantiate(PlayerRef, transform.position, transform.rotation);
        respawnEnemies = false;
    }
}
