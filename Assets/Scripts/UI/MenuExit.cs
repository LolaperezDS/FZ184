using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuExit : MonoBehaviour
{
    // Start is called before the first frame update
    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SomeFunction);
    }

    public void SomeFunction()
    {
        SceneManager.LoadScene(0);
    }
}
