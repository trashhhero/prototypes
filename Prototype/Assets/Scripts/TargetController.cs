using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour
{
    [SerializeField] public GameObject scoreUI;
    [SerializeField] public GameObject endText;
    private int score;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6) UpdateScore(1);
    }

    public void UpdateScore(int scoreUpdate)
    {
        score += scoreUpdate;
        scoreUI.GetComponent<Text>().text = "Score: " + score + "/2";
        endText.SetActive(score == 2);
    }
}
