using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private int _money;
    private int _addition;
    public static int QuanityProduct = 6;

    public Button[] Product = new Button[QuanityProduct];
    public Text[] TextProduct = new Text[QuanityProduct];
    public Text AdditionText;
    public int[] PriceProduct = new int[QuanityProduct];
    public int[] AdditionProduct = new int[QuanityProduct];
    private int[] _statusProduct = new int[QuanityProduct];

    private string _purchasedProductText = "\nПриобретено";


    private void Start()
    {
        _money = PlayerPrefs.GetInt("money", 0);
        _addition = PlayerPrefs.GetInt("Addition", 1);
        AdditionText.text = "Доход за клик: " + _addition.ToString();
        StatusProductUpdate();
    }
    public void ClickButtonProduct(int _numberButton)
    {
        if (_money >= PriceProduct[_numberButton])
        {
            ClickButtonStatus(_numberButton);
        }
    }

    private void ClickButtonStatus(int _numberButton)
    {
        _money -= PriceProduct[_numberButton];
        PlayerPrefs.SetInt("money", _money);

        Product[_numberButton].interactable = false;
        TextProduct[_numberButton].text += _purchasedProductText;
        _addition += AdditionProduct[_numberButton];
        _statusProduct[_numberButton] = 1;
        AdditionText.text = "Доход за клик: " + _addition.ToString();

        PlayerPrefs.SetInt("Addition", _addition);
        PlayerPrefs.SetInt($"StatusProduct{_numberButton}", _statusProduct[_numberButton]);
        PlayerPrefs.Save();



    }

    private void StatusProductUpdate()
    {
        for (byte i = 0; i < QuanityProduct; i++)
        {
            _statusProduct[i] = PlayerPrefs.GetInt($"StatusProduct{i}", 0);
            if (_statusProduct[i] == 1)
            {
                Product[i].interactable = false;
                TextProduct[i].text += _purchasedProductText;

            }
            else
            {
                _statusProduct[i] = 0;
                PlayerPrefs.SetInt($"StatusProduct{i}", _statusProduct[i]);
                PlayerPrefs.Save();

            }
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}