using UnityEngine;
using UnityEngine.UI;

public class ExitBtn : MonoBehaviour
{
    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SomeFunction);
    }

    public void SomeFunction()
    {
        Application.Quit();
    }
}
