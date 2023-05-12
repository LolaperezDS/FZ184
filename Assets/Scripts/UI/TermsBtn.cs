using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TermsBtn : MonoBehaviour
{
    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SomeFunction);
    }

    public void SomeFunction()
    {
        SceneManager.LoadScene(2);
    }
}
