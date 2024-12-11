using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float moveDistance = 2000f; // Расстояние, на которое будет сдвигаться объект
    public float interactionDistance = 3f; // Максимальная дистанция для взаимодействия

    void Update()
    {
        // Проверяем нажатие клавиши E
        if (Input.GetKeyDown(KeyCode.E))
        {
            MoveTargetObject();
        }
    }

    private void MoveTargetObject()
    {
        // Проверяем объекты, находящиеся перед игроком
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, interactionDistance, LayerMask.GetMask("movable"));

        if (hit.collider == null)
        {
            hit = Physics2D.Raycast(transform.position, -transform.right, interactionDistance, LayerMask.GetMask("movable"));
        }

        if (hit.collider != null)
        {
            GameObject targetObject = hit.collider.gameObject;

            // Получаем Rigidbody2D компонента целевого объекта
            Rigidbody2D targetRigidbody = targetObject.GetComponent<Rigidbody2D>();

            if (targetRigidbody != null)
            {
                if (targetObject.transform.position.x > transform.position.x)
                {
                    targetRigidbody.AddForce(Vector2.right * moveDistance);
                }
                else
                {
                    targetRigidbody.AddForce(Vector2.left * moveDistance);
                } 
                 
            }
        }
    }
}