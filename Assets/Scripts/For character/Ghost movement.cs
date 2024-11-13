
using UnityEngine;

public class Ghostmovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �������� �������� ���������
    private Rigidbody2D rb; // ������ �� ��������� Rigidbody2D
    private Vector2 movement; // ������ ��������
    public Transform Player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �������� ��������� Rigidbody2D
    }

    void Update()
    {
        // ��������� ������� ������ �� ������
        movement.x = Input.GetAxis("Horizontal"); // �������� �� ��� X
        movement.y = Input.GetAxis("Vertical"); // �������� �� ��� Y

        // ���� �������� �������� �� ��� X, ������������ ��� � ������� ��������
        if (movement.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movement.x*Player.localScale.x), 1, 1); // ������������ ���������
        }
    }

    void FixedUpdate()
    {
        // ��������� �������� � Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}