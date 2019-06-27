using UnityEngine;

public class TerrainGenerator : MonoBehaviour {
    public TerrainData terrainData;
    public int depth;
    public int width;
    public int height;
    public int radius;
    public bool isCircular;

    // Start is called before the first frame update
    void Start() {
        if (isCircular) {
            createCircle(terrainData);
        }
        else {
            createSquare(terrainData);
        }
    }

    void createCircle(TerrainData terrainData) {
        // terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, generateCircularHeights());
    }

    float[,] generateCircularHeights() {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                heights[x, y] = getCircularHeight(x, y);
            }
        }
        return heights;
    }

    float getCircularHeight(int x, int y) {
        Vector2 midpoint = new Vector2(width / 2, height / 2);
        Vector2 coordinate = new Vector2(x, y);
        float distance = distanceBetween(coordinate, midpoint);
        // Debug.Log("mag: " + distance);
        if (distance < radius) {
            return 0;
        }
        else {
            return 0.5f;
        }
    }

    float distanceBetween(Vector2 point, Vector2 other) {
        Vector2 distanceVector = point - other;
        return distanceVector.magnitude;
    }


    void createSquare(TerrainData terrainData) {
        terrainData.heightmapResolution = width + 1;
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, generateSquareHeights());
    }

    float[,] generateSquareHeights() {
        float[,] heights = new float[width, height];

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                heights[x, y] = generateWithRadius(x, y, radius);
            }
        }
        return heights;
    }

    float generateWithRadius(int x, int y, int radius) {
        if (withinRadius(x, radius) && withinRadius(y, radius)) {
            return 0;
        }
        else {
            return 1;
        }
    }

    bool withinRadius(int coord, int radius) {
        int midpoint = height / 2;
        return Mathf.Abs(coord - midpoint) < radius;
    }

    float generateWithPerlin(int x, int y) {
        float xCoord = (float)x / width;
        float yCoord = (float)y / height;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
