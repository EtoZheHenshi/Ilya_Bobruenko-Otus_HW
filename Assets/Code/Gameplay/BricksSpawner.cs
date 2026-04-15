using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public sealed class BricksSpawner : MonoBehaviour
    {
        [SerializeField] private Brick brickPrefab;
        [SerializeField] private int maxColumnCount = 8;
        [SerializeField] private int maxRowCount = 5;
        [SerializeField] private float offsetBetweenBricks = 0.05f;

        private float _brickWidth;
        private float _brickHeight;
        private float _centerPosX;

        private void Start()
        {
            _brickWidth = brickPrefab.transform.localScale.x + offsetBetweenBricks;
            _brickHeight = brickPrefab.transform.localScale.y + offsetBetweenBricks;
            _centerPosX = transform.position.x;
            CreateBricksWall();
        }

        private void CreateBricksWall()
        {
            int rowCount = Random.Range(1, maxRowCount + 1);
            float startPosY = transform.position.y;

            for (int i = 0; i < rowCount; i++)
            {
                int columnCount = Random.Range(1, maxColumnCount + 1);
                float y = startPosY - _brickHeight * i;
                
                CreateBricksRow(columnCount, y);
            }
        }

        private void CreateBricksRow(int columnCount, float posY)
        {
            if (columnCount == 0f) return;
            
            Color color = Random.ColorHSV();
            
            float distanceBetweenBricks = _brickWidth;
            float distanceFromCenter = _brickWidth / 2;

            if (columnCount % 2 != 0)
            {
                Instantiate(brickPrefab, new Vector3(_centerPosX, posY, 0f), Quaternion.identity, transform).Color = color;
                distanceBetweenBricks += _brickWidth;
                distanceFromCenter += _brickWidth / 2;
            }

            for (int i = 0; i < columnCount / 2; i++)
            {
                float x = _centerPosX - distanceFromCenter - _brickWidth * i;
                CreateTwoMirrorBricks(new Vector3(x, posY, 0f), distanceBetweenBricks, color);
                distanceBetweenBricks += _brickWidth * 2;
            }
        }

        private void CreateTwoMirrorBricks(Vector3 leftBrickPos, float distanceBetweenBricks, Color color)
        {
            Vector3 rightBrickPos = leftBrickPos + new Vector3(distanceBetweenBricks, 0, 0);
            Instantiate(brickPrefab, leftBrickPos, Quaternion.identity, transform).Color = color;
            Instantiate(brickPrefab, rightBrickPos, Quaternion.identity, transform).Color = color;
        }
    }
}