using UnityEngine;

public class BringToFront : MonoBehaviour
{
    public GameObject panel; // ������ �� ������, ������� ����� ������� �� �������� ����

    void Start()
    {
        if (panel != null)
        {
            panel.transform.SetAsLastSibling();
        }
    }

    // �� ����� ������ ������� ��� ������� � ����� �����, ����� ��� ����� ������� ������ �� �������� ����
    public void BringPanelToFront()
    {
        if (panel != null)
        {
            panel.transform.SetAsLastSibling();
        }
    }
}
