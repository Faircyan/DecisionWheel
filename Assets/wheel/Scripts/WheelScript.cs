using System;
using UnityEngine;
using UnityEngine.UI;

public class WheelScript : MonoBehaviour {

    private bool isSpin = false;
    private bool isSlow = false; 
    private float slowSpeed = -3f;
    private Text[] texts;
    private int counter = 0;
    public Image wheel;
    public Text resultText;
    public Text T1;
    public Text T2;
    public Text T3;
    public Text T4;
    public Text T5;
    public Text T6;
    public Text T7;
    public Text T8;
    
    void Update () {

        if (isSpin && !isSlow)
        {
            slowSpeed = -3f;
            wheel.transform.Rotate(new Vector3(wheel.transform.rotation.x, wheel.transform.rotation.y, wheel.transform.rotation.z - 3f));
            counter--;
            if (counter <= 0)
            {
                isSlow = true;
                isSpin = false;
            }
        }
        if(!isSpin && isSlow)
        {
            wheel.transform.Rotate(new Vector3(wheel.transform.rotation.x, wheel.transform.rotation.y, wheel.transform.rotation.z + decreaseSlowSpeed()));
        }

    }
    public void Spin()
    {
        isSpin = true;
        System.Random rnd = new System.Random();
        counter = rnd.Next(150, 270);
    }

    private float decreaseSlowSpeed()
    {
        if(slowSpeed <= -0.5f)
        {
            slowSpeed += 0.05f;
        }
        else
        {
            slowSpeed = 0f;
            isSlow = false;
            resultText.text = getResult() + " is Winner";

        }

        return slowSpeed;
    }

    private int CalculateRotation()
    {
        float wheelXRotation = wheel.transform.rotation.eulerAngles.z % 360f;
        return (int) (wheelXRotation + 0.5f);
    }

    public String getResult()
    {
        CreateList();
        return texts[((int)((CalculateRotation() + 22) / 45)) % 8].text;
    }

    private void CreateList()
    {
        texts = new Text[8];
        texts[0] = T1;
        texts[1] = T2;
        texts[2] = T3;
        texts[3] = T4;
        texts[4] = T5;
        texts[5] = T6;
        texts[6] = T7;
        texts[7] = T8;
    }
}
