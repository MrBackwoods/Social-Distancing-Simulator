using UnityEngine;


// Spawning people at start of scene and infecting patient 0
public class PersonSpawner : MonoBehaviour
{
    public GameObject personPrefab;
    public int numberOfPersons = 200;

    void Start()
    {
        SpawnPeople();
    }

    void SpawnPeople()
    {
        if (GetComponent<RectTransform>() != null && personPrefab != null)
        {
            Vector3[] corners = new Vector3[4];
            GetComponent<RectTransform>().GetWorldCorners(corners);

            float minX = corners[0].x;
            float maxX = corners[2].x;
            float minY = corners[0].y;
            float maxY = corners[1].y;

            for (int i = 0; i < numberOfPersons; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), transform.position.z);
                GameObject person = Instantiate(personPrefab, spawnPosition, Quaternion.identity, transform);

                if (i == 0)
                {
                    person.GetComponent<PersonHandler>().Infect();
                }
            }
        }
    }
}