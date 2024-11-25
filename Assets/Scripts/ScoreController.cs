using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] GameObject[] endPoints;
    int currentEndPoint = 1;
    int score = 0;
    int maxScore = 0;

    public void ReachEndPoint(GameObject reachedEndPoint) {
        // Debug.Log("reachedEndPoint.name: " + reachedEndPoint.name);
        // Debug.Log("endPoints[currentEndPoint].name: " + endPoints[currentEndPoint].name);
        // Debug.Log("- - -");
        if (reachedEndPoint.name == endPoints[currentEndPoint].name)
        {
            currentEndPoint++;
            if (currentEndPoint > (endPoints.Length-1)) currentEndPoint = 0;

            score++;
            if (score > maxScore) maxScore = score;
            Debug.Log("score: " + score +", maxScore: " + maxScore);
        }

    }
}
