using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClickEvent : MonoBehaviour
{
    public Material box;
    public Material stem;
    DateTime DateNow;
    DateTime DateExpiration;
    int year = 2021;
    int month = 8;
    int day = 10;
    int amount;
    int id;
    private void Start()
    {
        //box = Resources.Load("Box") as Material;
        //stem = Resources.Load("Stem") as Material;
    }
    public void OnClick()
    {
        GameObject property = GameObject.FindGameObjectWithTag("Prop");
        property.transform.GetChild(0).gameObject.SetActive(true);
        GameObject date = GameObject.FindGameObjectWithTag("date");
        Text text = date.transform.GetComponent<Text>();
        var Father = gameObject.transform.parent;
        year = Father.gameObject.GetComponent<Property>().year;
        month = Father.gameObject.GetComponent<Property>().month;
        day = Father.gameObject.GetComponent<Property>().day;
        text.text =  year.ToString() + "/" + month.ToString() + "/" + day.ToString();

        GameObject pointer = GameObject.FindGameObjectWithTag("Pointer");
        pointer.transform.GetChild(0).gameObject.SetActive(true);
        Transform thisname = this.transform.parent;
        Text pointername = pointer.transform.GetChild(0).GetChild(0).transform.GetComponent<Text>();
        //Debug.Log(pointername.text);
        pointername.text = thisname.name;

        GameObject amountText = GameObject.FindGameObjectWithTag("amount");
        Text textA = amountText.transform.GetComponent<Text>();
        amount = Father.gameObject.GetComponent<Property>().amount;
        textA.text = "数：" +  amount.ToString();

            

        GameObject idText = GameObject.FindGameObjectWithTag("id");
        Text textI = idText.transform.GetComponent<Text>();
        id = Father.gameObject.GetComponent<Property>().id;
        int type = Father.gameObject.GetComponent<Property>().type;
        if (id == 1)
        {
            if (type == 0) textI.text = "名前：刺身";
            if (type == 1) textI.text = "名前：豚肉";
            if (type == 2) textI.text = "名前：鶏肉";
            if (type == 3) textI.text = "名前：牛肉";
            if (type == 4) textI.text = "名前：手羽先";
            if (type == 5) textI.text = "名前：和牛";
            if (type == 6) textI.text = "名前：アヒル";
            if (type == 7) textI.text = "名前：魚";
            if (type == 8) textI.text = "名前：エビ";
            if (type == 9) textI.text = "名前：その他";
        }
        else if (id == 2)
        {
            if (type == 0) textI.text = "名前：ニンニク";
            if (type == 1) textI.text = "名前：ジャガイモ";
            if (type == 2) textI.text = "名前：玉ねぎ";
            if (type == 3) textI.text = "名前：ネギ";
            if (type == 4) textI.text = "名前：生姜";
            if (type == 5) textI.text = "名前：ニンジン";
            if (type == 6) textI.text = "名前：ピーマン";
            if (type == 7) textI.text = "名前：里芋";
            if (type == 8) textI.text = "名前：キャベツ";
            if (type == 9) textI.text = "名前：その他";
        }
        else if (id == 3)
        {
            if (type == 0) textI.text = "名前：蜜柑";
            if (type == 1) textI.text = "名前：リンゴ";
            if (type == 2) textI.text = "名前：バナナ";
            if (type == 3) textI.text = "名前： モモ";
            if (type == 4) textI.text = "名前：イチゴ";
            if (type == 5) textI.text = "名前：葡萄";
            if (type == 6) textI.text = "名前：スイカ";
            if (type == 7) textI.text = "名前：メロン";
            if (type == 8) textI.text = "名前：キウイフルーツ";
            if (type == 9) textI.text = "名前：その他";
        }
        else if (id == 4)
        {
            if (type == 0) textI.text = "名前：ミルク";
            if (type == 1) textI.text = "名前：ヨーグルト";
            if (type == 2) textI.text = "名前：天然水";
            if (type == 3) textI.text = "名前： カルビス";
            if (type == 4) textI.text = "名前：コーラ";
            if (type == 5) textI.text = "名前：ぶどうジュース";
            if (type == 6) textI.text = "名前：リンゴジュース";
            if (type == 7) textI.text = "名前：オレンジジュ—ス";
            if (type == 8) textI.text = "名前：ジンジャーエール";
            if (type == 9) textI.text = "名前：その他";
        }
        else if (id == 5)
        {
            if(type == 0) textI.text = "名前：豆腐";
            else if (type == 1) textI.text = "名前：油揚げ";
            else if (type == 2) textI.text = "名前：豆乳";
            else textI.text = 　　              "名前：その他";
        }
        else
        {
            textI.text = "名前：その他";
        }

        /*GameObject usual = GameObject.Find("Property/Usual");
        var Father = gameObject.transform.parent;
        amount = Father.gameObject.GetComponent<Property>().amount ;

        Button btn = (Button)usual.GetComponent<Button>();

        Text text = btn.transform.Find("Text").GetComponent<Text>();
        text.text = "改变文字2";*/
        //Debug.Log( "23245 ");
    }
    void Update()
    {
        DateNow = GameObject.Find("Main Camera").GetComponent<NewBehaviourScript>().date1;

        var Father = gameObject.transform.parent;
        year = Father.gameObject.GetComponent<Property>().year;
        month = Father.gameObject.GetComponent<Property>().month;
        day = Father.gameObject.GetComponent<Property>().day;

        DateExpiration = new DateTime(year, month, day, 12, 0, 0);
        TimeSpan difference = DateExpiration - DateNow;
        if(difference.TotalDays< 0)
        {
            this.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.black;
            //GetComponent<Renderer>().material = reflective;
        }
        else if (difference.TotalDays <= 1)
        {
            this.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.red;
            //GetComponent<Renderer>().material = reflective;
        }
        else if (difference.TotalDays <= 3)
        {
            this.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.yellow;
            //GetComponent<Renderer>().material = reflective;
        }
        else
        {
            if(this.name == "GreenOnion")
            {
                this.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].CopyPropertiesFromMaterial(stem);
            }
             
            else
            this.transform.GetChild(0).GetComponent<MeshRenderer>().materials[0].CopyPropertiesFromMaterial(box);
            //this.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.white;
        }    
    }
}
