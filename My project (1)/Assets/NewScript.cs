
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
        Txt_Text.text = "제 닉네임은 " + player + "입니다.";
        Txt_Text.text = $"제 레벨은 {playerLevel}레벨 입니다.";
    }

    public void PlayerLevel()
    {
        Txt_Text.text = $"제 레벨은 {playerLevel}레벨 입니다.";
    }

    public void PlayerGold()
    {
        Txt_Text.text = $"제 전재산은 {gold}G 입니다.";
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
//            "제 닉네임은" + player + "입니다.",
//            $"제 레벨은 {playerlevel}레벨 입니다.",
//            $"제 전재산은 {gold}g 입니다."
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