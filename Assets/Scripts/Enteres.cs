using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Enteres : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Material entered, common;

    private void Start()
    {
        this.GetComponentInChildren<Image>().material = common;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponentInChildren<Image>().material = entered;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponentInChildren<Image>().material = common;
    }
}
