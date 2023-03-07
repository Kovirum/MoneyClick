using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private int _money;
    private int _addition;

    public Text MoneyCounter;
    public Text ClickRateText;

    public GameObject EffectClick;
    public GameObject ButtonMoney;

    private int _clickRateCount = 0;
    private float _elapsedTime = 0f;

    public void Start()
    {
        _money = PlayerPrefs.GetInt("money", 0);
        _addition = PlayerPrefs.GetInt("Addition", 1);
        MoneyCounter.text = _money.ToString();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= 1f)
        {
            ClickRateText.text = "Кликов в секунду: " + Mathf.Round(_clickRateCount / _elapsedTime).ToString();
            _elapsedTime = 0f;
            _clickRateCount = 0;
        }
        #if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetData();
        }
        #endif
    }

    public void MoneyClickUp()
    {
        _money += _addition;
        _clickRateCount += _addition;
        MoneyCounter.text = _money.ToString();
        PlayerPrefs.SetInt("money", _money);
        PlayerPrefs.Save();
        Instantiate(EffectClick, ButtonMoney.GetComponent<RectTransform>().position.normalized, Quaternion.identity);

        ButtonMoney.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
    }

    public void MoneyClickDown()
    {
        ButtonMoney.transform.localScale = Vector3.one;
    }



    public void ToAchievements()
    {
        SceneManager.LoadScene(1);
    }

    public void ToShop()
    {
        SceneManager.LoadScene(2);
    }



    private void ResetData()
    {
        PlayerPrefs.DeleteAll();
        _money = 0;
        _addition = 1;
        MoneyCounter.text = _money.ToString();

    }
}

