using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;


public class ScrollableList : MonoBehaviour
{
    public GameObject listItemPrefab;
    public Transform listContent;

    string filepath = Application.streamingAssetsPath + "/saves/";

    private List<string> stringList = new List<string>() { "Item 1", "Item 2", "Item 3", "Item 4" };

    private void Start()
    {
        FillList();
    }

    private void FillList()
    {
        string loadedData;
        using (var reader = new StreamReader(filepath + "termins.txt"))
        {
            loadedData = reader.ReadToEnd();
        }
        string[] strings = loadedData.Split("\n");
        // заполняем список строк
        for (int i = 0; i < strings.Length; i++)
        {
            stringList.Add(strings[i]);
        }

        for (int i = 0; i < stringList.Count; i++)
        {
            //GameObject listItem = Instantiate(listItemPrefab, listContent.transform.position - new Vector3(0, i * 50, 0), Quaternion.identity);
            GameObject listItem = Instantiate(listItemPrefab, listContent);
            TextMeshProUGUI textMeshPro = listItem.GetComponentInChildren<TextMeshProUGUI>();
            textMeshPro.text = stringList[i];
        }
    }
}

