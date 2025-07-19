using UnityEngine;
using Zenject;
using System.Collections;
using SorterGame._Scripts.Settings;
using SorterGame._Scripts.Shapes;

public class ShapeSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] lines; // 3 лайна
    [SerializeField] private GameSettings gameSettings;

    private ShapeFactory _factory;

    [Inject]
    public void Construct(ShapeFactory factory)
    {
        _factory = factory;
    }

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        int total = Random.Range(
            gameSettings.ShapeCountRange.x,
            gameSettings.ShapeCountRange.y + 1
        );

        for (int i = 0; i < total; i++)
        {
            var delay = Random.Range(
                gameSettings.SpawnDelayRange.x,
                gameSettings.SpawnDelayRange.y
            );
            yield return new WaitForSeconds(delay);

            var shapeType = (ShapeType)Random.Range(0, 4);
            var line = lines[Random.Range(0, lines.Length)];
            var speed = Random.Range(
                gameSettings.SpeedRange.x,
                gameSettings.SpeedRange.y
            );

            var shape = _factory.Create(shapeType, line);
            shape.Init(shapeType, speed);
        }
    }
}