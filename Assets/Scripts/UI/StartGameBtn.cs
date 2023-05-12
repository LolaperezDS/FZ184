using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class StartGameBtn : MonoBehaviour
{
    private Button btn;
    [SerializeField] private InputField ifield;
    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SomeFunction);
    }

    public void SomeFunction()
    {
        Pool.ticketsAmount = Convert.ToInt32(ifield.text);
        SceneManager.LoadScene(1);
    }
}
