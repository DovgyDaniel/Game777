using UnityEngine;

public class BringToFront : MonoBehaviour
{
    public GameObject panel; // Ссылка на панель, которую нужно вынести на передний план

    void Start()
    {
        if (panel != null)
        {
            panel.transform.SetAsLastSibling();
        }
    }

    // Вы также можете вызвать эту функцию в любое время, когда вам нужно вынести панель на передний план
    public void BringPanelToFront()
    {
        if (panel != null)
        {
            panel.transform.SetAsLastSibling();
        }
    }
}
