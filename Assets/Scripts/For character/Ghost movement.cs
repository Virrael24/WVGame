
using UnityEngine;

public class Ghostmovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения персонажа
    private Rigidbody2D rb; // Ссылка на компонент Rigidbody2D
    private Vector2 movement; // Вектор движения
    public Transform Player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
    }

    void Update()
    {
        // Считываем входные данные от игрока
        movement.x = Input.GetAxis("Horizontal"); // Движение по оси X
        movement.y = Input.GetAxis("Vertical"); // Движение по оси Y

        // Если персонаж движется по оси X, поворачиваем его в сторону движения
        if (movement.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(movement.x*Player.localScale.x), 1, 1); // Поворачиваем персонажа
        }
    }

    void FixedUpdate()
    {
        // Применяем движение к Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}