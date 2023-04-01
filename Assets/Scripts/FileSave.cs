using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileSave : MonoBehaviour
{
    public static bool dataControl;
    public static string loadData;
    public static string[] splitData;
    public static string fullData = "";
    public static string ownHeroes;
    public static string ownBullets;
    public static int coin;
    public static int totalPlay;
    public static int highscore;
    public static int totalKill;


    static void GetData()
    {
        ownHeroes = StartMenu.ownHeroes;
        ownBullets = StartMenu.ownBullets;
        coin = StartMenu.coin;
        totalPlay = StartMenu.totalPlay;
        highscore = StartMenu.highscore;
        totalKill = StartMenu.totalKill;
    }

    public static void SaveData()
    {
        PlayerPrefs.SetString("Heroes", ownHeroes);
        PlayerPrefs.SetString("Bullets", ownBullets);
        PlayerPrefs.SetInt("Coin", coin);
        PlayerPrefs.SetInt("TotalPlay", totalPlay);
        PlayerPrefs.SetInt("Highscore", highscore);
        PlayerPrefs.SetInt("TotalKill", totalKill);
        PlayerPrefs.Save();
    }

    public static void TotalData()
    {
        GetData();
        fullData = ownHeroes + ":" + ownBullets + ":" + coin + ":" + totalPlay + ":" + highscore + ":" + totalKill;
    }

    public static void SaveFile()
    {
        TotalData();
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.data";
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, fullData);
        stream.Close();
    }

    public static void LoadFile()
    {
        dataControl = false;
        string path = Application.persistentDataPath + "/save.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            loadData = (string)formatter.Deserialize(stream);
            dataControl = true;
            stream.Close();
        }

        if (dataControl)
        {
            splitData = loadData.Split(":");
            StartMenu.ownHeroes = splitData[0];
            StartMenu.ownBullets = splitData[1];
            StartMenu.coin = Convert.ToInt32(splitData[2]);
            StartMenu.totalPlay = Convert.ToInt32(splitData[3]);
            StartMenu.highscore = Convert.ToInt32(splitData[4]);
            StartMenu.totalKill = Convert.ToInt32(splitData[5]);
            SaveData();
        }
    }
}
