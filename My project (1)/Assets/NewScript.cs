
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewScript : MonoBehaviour
{
    public TextMeshProUGUI Txt_Text;

    public string player = "Sikku";
    public int playerLevel = 29;
    public int gold = 200;

    public void PlayerName()
    {
        Txt_Text.text = "�� �г����� " + player + "�Դϴ�.";
        Txt_Text.text = $"�� ������ {playerLevel}���� �Դϴ�.";
    }

    public void PlayerLevel()
    {
        Txt_Text.text = $"�� ������ {playerLevel}���� �Դϴ�.";
    }

    public void PlayerGold()
    {
        Txt_Text.text = $"�� ������� {gold}G �Դϴ�.";
    }
}
//using system.collections;
//using system.collections.generic;
//using unityengine;
//using tmpro;

//public class newscript : monobehaviour
//{
//    public textmeshprougui txt_text;


//    private string player = "sikku";
//    private int  playerlevel = 29;
//    private int gold = 200;


//    private list<string> sentences;
//    private int currentindex = 0;

//    void start()
//    {

//        sentences = new list<string>()
//        {
//            "�� �г�����" + player + "�Դϴ�.",
//            $"�� ������ {playerlevel}���� �Դϴ�.",
//            $"�� ������� {gold}g �Դϴ�."
//        };

//        txt_text.text = "";
//    }

//    public void onclickbutton()
//    {
//        if (currentindex < sentences.count)
//        {
//            txt_text.text = sentences[currentindex];
//            currentindex++;
//        }
//    }
//}