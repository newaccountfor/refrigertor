using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform father;
    private Text text;
    int id;
    int amount;
    int year;
    int month;
    int day;
    int type;
    int countButtonDown = 0;
    public DateTime date1;

    public void RightButtonDown()
    {
        countButtonDown++;
    }
    public void LeftButtonDown()
    {
        countButtonDown--;
    }
    public void ChangeNumber(InputField inputfield)
    {
        int newnum;
        newnum = Convert.ToInt32(inputfield.text);
        //GameObject amountText = GameObject.FindGameObjectWithTag("amount");
        //Text textA = amountText.transform.GetComponent<Text>();
        //textA.text = amount.ToString();

        GameObject property = GameObject.FindGameObjectWithTag("Prop");
        property.transform.GetChild(0).gameObject.SetActive(true);
        property.transform.GetChild(1).gameObject.SetActive(false);

        GameObject pointer = GameObject.FindGameObjectWithTag("Pointer");
        pointer.transform.GetChild(0).gameObject.SetActive(true);
        string pointername = pointer.transform.GetChild(0).GetChild(0).transform.GetComponent<Text>().text;
        //Debug.Log(pointername.text);
        GameObject ToBeChange = GameObject.Find(pointername);
        //pointername.text = thisname.name;
        Debug.Log(newnum);
         ToBeChange.gameObject.GetComponent<Property>().amount = newnum;
        Debug.Log(ToBeChange.gameObject.GetComponent<Property>().amount);
        Invoke("changed",(float)0.1);
    }

    private void changed()
    {
        GameObject amountText = GameObject.FindGameObjectWithTag("amount");
        
        GameObject pointer = GameObject.FindGameObjectWithTag("Pointer");
        string pointername = pointer.transform.GetChild(0).GetChild(0).transform.GetComponent<Text>().text;

        GameObject ToBeChange = GameObject.Find(pointername);
        var Father = amountText.gameObject.transform.parent;
        Text textA = amountText.transform.GetComponent<Text>();
        amount = ToBeChange.gameObject.GetComponent<Property>().amount;
        textA.text = "数：" + amount.ToString();
    }

    public void deleteing()
    {
        GameObject amountText = GameObject.FindGameObjectWithTag("amount");

        GameObject pointer = GameObject.FindGameObjectWithTag("Pointer");
        string pointername = pointer.transform.GetChild(0).GetChild(0).transform.GetComponent<Text>().text;

        GameObject ToBeChange = GameObject.Find(pointername);
        ToBeChange.transform.GetChild(0).gameObject.SetActive(false);
        ToBeChange.transform.GetChild(1).gameObject.SetActive(false);
        ToBeChange.transform.GetChild(2).gameObject.SetActive(false);

        GameObject property = GameObject.FindGameObjectWithTag("Prop");
        property.transform.GetChild(0).gameObject.SetActive(false);
        pointer.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void AddByQR()
    {
        this.GetComponent<BarcodeCam>().enabled = true;
        this.GetComponent<BarcodeCam>().OnEnable();
        //this.GetComponent<BarcodeCam>().SendMessage("Start");
    }
    void Show()
    {
        this.gameObject.SetActive(true);
    }

    void Hide()
    {
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        date1 = DateTime.Now;
        // this.gameObject.SetActive(false);
    }
    public void ClickBack()
    {
        GameObject property = GameObject.FindGameObjectWithTag("Prop");
        property.transform.GetChild(0).gameObject.SetActive(false);

        GameObject pointer = GameObject.FindGameObjectWithTag("Pointer");
        pointer.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void AlterFunc()
    {
        GameObject property = GameObject.FindGameObjectWithTag("Prop");
        property.transform.GetChild(1).gameObject.SetActive(true);
        property.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void ButtonFunc()
    {
        GameObject add = GameObject.FindGameObjectWithTag("Add");
        add.transform.GetChild(0).gameObject.SetActive(true);
        add.transform.GetChild(1).gameObject.SetActive(false);
    }
    public void InputFieldFunc(InputField inputfield)
    {
        //在场景中是否激活（实际激活状态）
        //this.gameObject.activeInHierarchy;
        //物体自身激活状态（物体在  面板当中的激活状态）
        //this.gameObject.activeSelf;
        //设置物体禁用，启用；
        //this.gameObject.SetActive(true);
        //在场景中根据名称查找物体（不建议使用）
        //GameObject.Find("游戏对象名称")
        //获取所有使用该标签的物体
        //GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("QWE");
        //获取单个使用该标签的物体
        //text.text = inputfield.text;
            Debug.Log(inputfield.text);
            string s1 = inputfield.text.Substring(0, 1);
            string s2 = inputfield.text.Substring(1, 2);
            string s3 = inputfield.text.Substring(3, 4);
            string s4 = inputfield.text.Substring(7, 2);
            string s5 = inputfield.text.Substring(9, 2);
            string s6 = inputfield.text.Substring(11, 1);
            id = Convert.ToInt32(s1);
            amount = Convert.ToInt32(s2);
            year = Convert.ToInt32(s3);
            month = Convert.ToInt32(s4);
            day = Convert.ToInt32(s5);
            type = Convert.ToInt32(s6);
            Debug.Log(type);
            if ( id == 1)
            {
                GameObject[] allPlaces = GameObject.FindGameObjectsWithTag("Place");
                foreach (GameObject i in allPlaces)
                {
                    Debug.Log(i.name);
                    //var child = father.GetChild(i).gameObject;
                    if (i.transform.GetChild(0).gameObject.activeSelf == false && i.transform.GetChild(1).gameObject.activeSelf == false && i.transform.GetChild(2).gameObject.activeSelf == false)
                    {
                        i.transform.GetChild(0).gameObject.SetActive(true);
                        i.GetComponent<Property>().id = id;
                        i.GetComponent<Property>().amount = amount;
                        i.GetComponent<Property>().year = year;
                        i.GetComponent<Property>().month = month;
                        i.GetComponent<Property>().day = day;
                        i.GetComponent<Property>().type = type;
                        break;
                    }
                }
            }
            else if (id == 2)
            {
                GameObject[] allPlaces = GameObject.FindGameObjectsWithTag("Place");
                foreach (GameObject i in allPlaces)
                {
                    Debug.Log(i.name);
                    //var child = father.GetChild(i).gameObject;
                    if (i.transform.GetChild(0).gameObject.activeSelf == false && i.transform.GetChild(1).gameObject.activeSelf == false && i.transform.GetChild(2).gameObject.activeSelf == false)
                    {
                        i.transform.GetChild(1).gameObject.SetActive(true);
                    i.GetComponent<Property>().id = id;
                    i.GetComponent<Property>().amount = amount;
                    i.GetComponent<Property>().year = year;
                    i.GetComponent<Property>().month = month;
                    i.GetComponent<Property>().day = day;
                    i.GetComponent<Property>().type = type;
                    break;
                    }
                }
            }
            else if (id == 3)
            {
                GameObject[] allPlaces = GameObject.FindGameObjectsWithTag("Place");
                foreach (GameObject i in allPlaces)
                {
                    Debug.Log(i.name);
                    //var child = father.GetChild(i).gameObject;
                    if (i.transform.GetChild(0).gameObject.activeSelf == false && i.transform.GetChild(1).gameObject.activeSelf == false && i.transform.GetChild(2).gameObject.activeSelf == false)
                    {
                        i.transform.GetChild(2).gameObject.SetActive(true);
                    i.GetComponent<Property>().id = id;
                    i.GetComponent<Property>().amount = amount;
                    i.GetComponent<Property>().year = year;
                    i.GetComponent<Property>().month = month;
                    i.GetComponent<Property>().day = day;
                    i.GetComponent<Property>().type = type;
                    break;
                    }
                }
            }
        else if (id == 4)
        {
            GameObject[] allShelfs = GameObject.FindGameObjectsWithTag("Shelf");
            foreach (GameObject i in allShelfs)
            {
                Debug.Log(i.name);
                //var child = father.GetChild(i).gameObject;
                if (i.transform.GetChild(0).gameObject.activeSelf == false && i.transform.GetChild(1).gameObject.activeSelf == false && i.transform.GetChild(2).gameObject.activeSelf == false)
                {
                    i.transform.GetChild(2).gameObject.SetActive(true);
                    i.GetComponent<Property>().id = id;
                    i.GetComponent<Property>().amount = amount;
                    i.GetComponent<Property>().year = year;
                    i.GetComponent<Property>().month = month;
                    i.GetComponent<Property>().day = day;
                    i.GetComponent<Property>().type = type;
                    break;
                }
            }
        }
        else if (id == 5)
        {
            GameObject[] allShelfs = GameObject.FindGameObjectsWithTag("Shelf");
            foreach (GameObject i in allShelfs)
            {
                Debug.Log(i.name);
                //var child = father.GetChild(i).gameObject;
                if (i.transform.GetChild(0).gameObject.activeSelf == false && i.transform.GetChild(1).gameObject.activeSelf == false && i.transform.GetChild(2).gameObject.activeSelf == false)
                {
                    i.transform.GetChild(1).gameObject.SetActive(true);
                    i.GetComponent<Property>().id = id;
                    i.GetComponent<Property>().amount = amount;
                    i.GetComponent<Property>().year = year;
                    i.GetComponent<Property>().month = month;
                    i.GetComponent<Property>().day = day;
                    i.GetComponent<Property>().type = type;
                    break;
                }
            }
        }
        else if (id == 6)
        {
            GameObject[] allShelfs = GameObject.FindGameObjectsWithTag("Shelf");
            foreach (GameObject i in allShelfs)
            {
                Debug.Log(i.name);
                //var child = father.GetChild(i).gameObject;
                if (i.transform.GetChild(0).gameObject.activeSelf == false && i.transform.GetChild(1).gameObject.activeSelf == false && i.transform.GetChild(2).gameObject.activeSelf == false)
                {
                    i.transform.GetChild(0).gameObject.SetActive(true);
                    i.GetComponent<Property>().id = id;
                    i.GetComponent<Property>().amount = amount;
                    i.GetComponent<Property>().year = year;
                    i.GetComponent<Property>().month = month;
                    i.GetComponent<Property>().day = day;
                    i.GetComponent<Property>().type = type;
                    break;
                }
            }
        }

        GameObject add = GameObject.FindGameObjectWithTag("Add");
        add.transform.GetChild(0).gameObject.SetActive(false);
        add.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void StrFunc(String str)
    {
        //在场景中是否激活（实际激活状态）
        //this.gameObject.activeInHierarchy;
        //物体自身激活状态（物体在  面板当中的激活状态）
        //this.gameObject.activeSelf;
        //设置物体禁用，启用；
        //this.gameObject.SetActive(true);
        //在场景中根据名称查找物体（不建议使用）
        //GameObject.Find("游戏对象名称")
        //获取所有使用该标签的物体
        //GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("QWE");
        //获取单个使用该标签的物体
        //text.text = inputfield.text;
        string s1 = str.Substring(0, 1);
        string s2 = str.Substring(1, 2);
        string s3 = str.Substring(3, 4);
        string s4 = str.Substring(7, 2);
        string s5 = str.Substring(9, 2);
        string s6 = str.Substring(11, 1);
        id = Convert.ToInt32(s1);
        amount = Convert.ToInt32(s2);
        year = Convert.ToInt32(s3);
        month = Convert.ToInt32(s4);
        day = Convert.ToInt32(s5);
        type = Convert.ToInt32(s6);
        Debug.Log(id);
        if (id == 1)
        {
            GameObject[] allPlaces = GameObject.FindGameObjectsWithTag("Place");
            foreach (GameObject i in allPlaces)
            {
                Debug.Log(i.name);
                //var child = father.GetChild(i).gameObject;
                if (i.transform.GetChild(0).gameObject.activeSelf == false && i.transform.GetChild(1).gameObject.activeSelf == false && i.transform.GetChild(2).gameObject.activeSelf == false)
                {
                    i.transform.GetChild(0).gameObject.SetActive(true);
                    i.GetComponent<Property>().id = id;
                    i.GetComponent<Property>().amount = amount;
                    i.GetComponent<Property>().year = year;
                    i.GetComponent<Property>().month = month;
                    i.GetComponent<Property>().day = day;
                    i.GetComponent<Property>().type = type;
                    break;
                }
            }
        }
        else if (id == 2)
        {
            GameObject[] allPlaces = GameObject.FindGameObjectsWithTag("Place");
            foreach (GameObject i in allPlaces)
            {
                Debug.Log(i.name);
                //var child = father.GetChild(i).gameObject;
                if (i.transform.GetChild(0).gameObject.activeSelf == false && i.transform.GetChild(1).gameObject.activeSelf == false && i.transform.GetChild(2).gameObject.activeSelf == false)
                {
                    i.transform.GetChild(1).gameObject.SetActive(true);
                    i.GetComponent<Property>().id = id;
                    i.GetComponent<Property>().amount = amount;
                    i.GetComponent<Property>().year = year;
                    i.GetComponent<Property>().month = month;
                    i.GetComponent<Property>().day = day;
                    i.GetComponent<Property>().type = type;
                    break;
                }
            }
        }
        else if (id == 3)
        {
            GameObject[] allPlaces = GameObject.FindGameObjectsWithTag("Place");
            foreach (GameObject i in allPlaces)
            {
                Debug.Log(i.name);
                //var child = father.GetChild(i).gameObject;
                if (i.transform.GetChild(0).gameObject.activeSelf == false && i.transform.GetChild(1).gameObject.activeSelf == false && i.transform.GetChild(2).gameObject.activeSelf == false)
                {
                    i.transform.GetChild(2).gameObject.SetActive(true);
                    i.GetComponent<Property>().id = id;
                    i.GetComponent<Property>().amount = amount;
                    i.GetComponent<Property>().year = year;
                    i.GetComponent<Property>().month = month;
                    i.GetComponent<Property>().day = day;
                    i.GetComponent<Property>().type = type;
                    break;
                }
            }
        }
        else if (id == 4)
        {
            GameObject[] allShelfs = GameObject.FindGameObjectsWithTag("Shelf");
            foreach (GameObject i in allShelfs)
            {
                Debug.Log(i.name);
                //var child = father.GetChild(i).gameObject;
                if (i.transform.GetChild(0).gameObject.activeSelf == false && i.transform.GetChild(1).gameObject.activeSelf == false && i.transform.GetChild(2).gameObject.activeSelf == false)
                {
                    i.transform.GetChild(2).gameObject.SetActive(true);
                    i.GetComponent<Property>().id = id;
                    i.GetComponent<Property>().amount = amount;
                    i.GetComponent<Property>().year = year;
                    i.GetComponent<Property>().month = month;
                    i.GetComponent<Property>().day = day;
                    i.GetComponent<Property>().type = type;
                    break;
                }
            }
        }
        else if (id == 5)
        {
            GameObject[] allShelfs = GameObject.FindGameObjectsWithTag("Shelf");
            foreach (GameObject i in allShelfs)
            {
                Debug.Log(i.name);
                //var child = father.GetChild(i).gameObject;
                if (i.transform.GetChild(0).gameObject.activeSelf == false && i.transform.GetChild(1).gameObject.activeSelf == false && i.transform.GetChild(2).gameObject.activeSelf == false)
                {
                    i.transform.GetChild(1).gameObject.SetActive(true);
                    i.GetComponent<Property>().id = id;
                    i.GetComponent<Property>().amount = amount;
                    i.GetComponent<Property>().year = year;
                    i.GetComponent<Property>().month = month;
                    i.GetComponent<Property>().day = day;
                    i.GetComponent<Property>().type = type;
                    break;
                }
            }
        }
        else if (id == 6)
        {
            GameObject[] allShelfs = GameObject.FindGameObjectsWithTag("Shelf");
            foreach (GameObject i in allShelfs)
            {
                Debug.Log(i.name);
                //var child = father.GetChild(i).gameObject;
                if (i.transform.GetChild(0).gameObject.activeSelf == false && i.transform.GetChild(1).gameObject.activeSelf == false && i.transform.GetChild(2).gameObject.activeSelf == false)
                {
                    i.transform.GetChild(0).gameObject.SetActive(true);
                    i.GetComponent<Property>().id = id;
                    i.GetComponent<Property>().amount = amount;
                    i.GetComponent<Property>().year = year;
                    i.GetComponent<Property>().month = month;
                    i.GetComponent<Property>().day = day;
                    i.GetComponent<Property>().type = type;
                    break;
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        TimeSpan duration = new System.TimeSpan(countButtonDown, 0, 0, 0);
        date1 = DateTime.Now + duration;
        GameObject TimeOfNow = GameObject.FindGameObjectWithTag("Timer");
        Text textT = TimeOfNow.transform.GetComponent<Text>();
        textT.text =  date1.ToString(System.Globalization.CultureInfo.CreateSpecificCulture("ja-JP"));
        //GameObject.Find("UserInforUI").transform.FindChild(o + "/bg/Que/zhuang").GetComponent<Image>().gameObject.SetActive(true);
    }
}
