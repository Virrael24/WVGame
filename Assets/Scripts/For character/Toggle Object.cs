using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    public GameObject objectToEnable; // ������, ������� ����� ����������
    public GameObject objectWithScript; // ������, � �������� ����� ����������� ������
    public MonoBehaviour targetScript; // ������, ������� ����� �����������/����������

    private Rigidbody2D rb; // ������ �� ��������� Rigidbody2D
    private bool isActive = false; // ���� ��� ������������ ���������

    void Start()
    {
        if (objectWithScript != null)
        {
            rb = objectWithScript.GetComponent<Rigidbody2D>(); // �������� ��������� Rigidbody2D
        }
    }

    void Update()
    {
        // ���������, ��� Rigidbody �� ��������
        if (Input.GetKeyDown(KeyCode.R) && rb != null && rb.velocity == Vector2.zero)
        {
            ToggleActions();
        }
    }

    private void ToggleActions()
    {
        if (objectToEnable != null && objectWithScript != null && rb != null)
        {
            isActive = !isActive; // ����������� ���������

            // ��������/��������� ������ ������
            objectToEnable.SetActive(isActive);

            // ��������/��������� ������ � ������� �������
            if (targetScript != null)
            {
                targetScript.enabled = !isActive; // �������� ������, ���� ������ ��������
            }

            // ������ ��� Rigidbody
            if (isActive)
            {
                rb.isKinematic = true; // ������������� Kinematic
            }
            else
            {
                rb.isKinematic = false; // ������������� Dynamic
            }
        }
    }
}