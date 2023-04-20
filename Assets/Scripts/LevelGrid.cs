using UnityEngine;

public class LevelGrid
{

    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;
    private int width;
    private int height;
    private Snake snake;

    public void Setup(Snake snake)
    {
        this.snake = snake;
        SpawnFood();
    }

    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    private void SpawnFood()
    {
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        } while (snake.GetFullSnakeGridPositionList().IndexOf(foodGridPosition) != -1);
        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.i.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if (foodGridPosition == snakeGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            GameHandler.addScore();
            return true;
        }
        else return false;
    }

    public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        if(gridPosition.x < 0)
        {
            gridPosition.x = width;
        }
        if (gridPosition.x > width)
        {
            gridPosition.x = 0;
        }
        if (gridPosition.y < 0)
        {
            gridPosition.y = height - 1;
        }
        if (gridPosition.y > height)
        {
            gridPosition.y = 0;
        }
        return gridPosition;
    }
}
