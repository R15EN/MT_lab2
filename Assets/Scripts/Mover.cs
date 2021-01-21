using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    Vector2 direction; //направление вектора движения
    float rand_X, rand_Y; //переменные по которым выбирается случайное направление
    Vector2 min, max; //границы камеры
    public int speed; //скорость движения


    void Start()
    {
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        rand_X = Random.Range(-1.0f, 1.0f);
        rand_Y = Random.Range(-1.0f, 1.0f);

        direction = new Vector2(rand_X, rand_Y);

    }

    void Update()
    {


        transform.Translate(direction * speed * Time.deltaTime);

        //если координаты сферы по x больше, чем координаты левой или правой границ камеры
        if ((transform.position.x >= max.x) || (transform.position.x <= min.x)) 
        {
            rand_X = -rand_X; //значение по x меняем на противоположное
            direction = new Vector2(rand_X, rand_Y); //создаем новое направление с новым x
            Debug.Log("Изменение по x "); 
            Debug.Log(direction);
        }
        
        //для y аналогично
        if ((transform.position.y >= max.y) || (transform.position.y <= min.y))
        {
            rand_Y = -rand_Y;
            direction = new Vector2(rand_X, rand_Y);
            Debug.Log("Изменение по y ");
            Debug.Log(direction);
        }
       
       
    }
}
