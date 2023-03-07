using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    private int _money;
    private string _taskAchText = "Заработать монет: ";

    public static int QuanityAchievement = 5;
    public GameObject[] Achievement = new GameObject[QuanityAchievement];
    public Text[] AchText = new Text[QuanityAchievement];
    public int[] QuanityMoney = new int[QuanityAchievement];

    private int[] StatusAchievements = new int[QuanityAchievement];

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        _money = PlayerPrefs.GetInt("totalMoney");
        for (byte i = 0; i < QuanityAchievement; i++)
        {

            StatusAchievements[i] = PlayerPrefs.GetInt($"StatusAchievements{i}", 0);

            AchText[i].text = _taskAchText + QuanityMoney[i].ToString();

            if (_money >= QuanityMoney[i] || StatusAchievements[i] == 1)
            {
                Achievement[i].GetComponent<Image>().color = new Color(140f / 255, 255f / 255, 117f / 255);

                StatusAchievements[i] = 1;
                PlayerPrefs.SetInt($"StatusAchievements{i}", StatusAchievements[i]);
                PlayerPrefs.Save();
            }
        }
    }
}
