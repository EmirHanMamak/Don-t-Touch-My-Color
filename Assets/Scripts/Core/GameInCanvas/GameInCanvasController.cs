using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameInCanvasController : MonoBehaviour
{
    public GameObject LevelNumberText, CurrentLevelLabel, NextLevelLabel;
    public LevelDesign[] LevelDesign;
    void Start()
    {
        for (int i = 0; i < LevelDesign.Length; i++)
        {
            if (SceneManager.GetActiveScene().name == "Level-" + i)
            {
                LevelNumberText.GetComponent<TMP_Text>().text = LevelDesign[i - 1].CurrentLevelIndex.ToString();
                CurrentLevelLabel.GetComponent<TMP_Text>().text = LevelDesign[i - 1].CurrentLevelIndex.ToString();
                NextLevelLabel.GetComponent<TMP_Text>().text = (LevelDesign[i - 1].CurrentLevelIndex + 1).ToString();

            }
        }
    }
}
