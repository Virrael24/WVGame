using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    public GameObject objectToEnable; // Объект, который будет включаться
    public GameObject objectWithScript; // Объект, у которого будет отключаться скрипт
    public MonoBehaviour targetScript; // Скрипт, который будет отключаться/включаться

    private Rigidbody2D rb; // Ссылка на компонент Rigidbody2D
    private bool isActive = false; // Флаг для отслеживания состояния

    void Start()
    {
        if (objectWithScript != null)
        {
            rb = objectWithScript.GetComponent<Rigidbody2D>(); // Получаем компонент Rigidbody2D
        }
    }

    void Update()
    {
        // Проверяем, что Rigidbody не движется
        if (Input.GetKeyDown(KeyCode.R) && rb != null && rb.velocity == Vector2.zero)
        {
            ToggleActions();
        }
    }

    private void ToggleActions()
    {
        if (objectToEnable != null && objectWithScript != null && rb != null)
        {
            isActive = !isActive; // Переключаем состояние

            // Включаем/выключаем первый объект
            objectToEnable.SetActive(isActive);

            // Включаем/выключаем скрипт у второго объекта
            if (targetScript != null)
            {
                targetScript.enabled = !isActive; // Включаем скрипт, если объект отключен
            }

            // Меняем тип Rigidbody
            if (isActive)
            {
                rb.isKinematic = true; // Устанавливаем Kinematic
            }
            else
            {
                rb.isKinematic = false; // Устанавливаем Dynamic
            }
        }
    }
}