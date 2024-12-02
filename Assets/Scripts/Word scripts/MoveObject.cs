using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float moveDistance = 2000f; // ����������, �� ������� ����� ���������� ������
    public float interactionDistance = 3f; // ������������ ��������� ��� ��������������

    void Update()
    {
        // ��������� ������� ������� E
        if (Input.GetKeyDown(KeyCode.E))
        {
            MoveTargetObject();
        }
    }

    private void MoveTargetObject()
    {
        // ��������� �������, ����������� ����� �������
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, interactionDistance, LayerMask.GetMask("movable"));

        if (hit.collider == null)
        {
            hit = Physics2D.Raycast(transform.position, -transform.right, interactionDistance, LayerMask.GetMask("movable"));
        }

        if (hit.collider != null)
        {
            GameObject targetObject = hit.collider.gameObject;

            // �������� Rigidbody2D ���������� �������� �������
            Rigidbody2D targetRigidbody = targetObject.GetComponent<Rigidbody2D>();

            if (targetRigidbody != null)
            {
                // ���������� ������ � ����������� �� ������
                targetRigidbody.AddForce(-transform.right*moveDistance*transform.localScale.x);
                Debug.Log(targetRigidbody);
            }
        }
    }
}