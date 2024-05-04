using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_Text scoreTxt;

    [Header("Score")]
    [SerializeField] private GameObject startPosition;
    [SerializeField] private GameObject currentPosition;

    private int previousDistanceInteger = 0;

    private void Update()
    {
        var distance = Mathf.Abs(currentPosition.transform.position.x - startPosition.transform.position.x);
        var distanceInteger = Mathf.RoundToInt(distance);

        if (distanceInteger > previousDistanceInteger)
        {
            previousDistanceInteger = distanceInteger;
            PlayerPrefs.SetInt(PlayerPrefsUtils.BEST_SCORE, distanceInteger);
            scoreTxt.text = "Score: " + previousDistanceInteger.ToString();
        }
    }
}
