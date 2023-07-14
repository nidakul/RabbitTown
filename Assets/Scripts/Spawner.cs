using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy1, enemy2, enemy3, enemy4, enemy5, enemy6;
    public GameObject SmallGround, MiddleGround, BigGround, BigSmall, BigSmallCarrot, MiddleGround4Carrot, Platform1, Platform2, Platform3,
    BigGroundEnemy, BigGroundx2Enemy, BigGroundx2, BigSmallMushroom, Platform3Mushroom;
    public GameObject obstacle1, obstacle2, obstacle3, obstacle4, obstacle5, obstacle6, obstacle7, obstacle8;
    public GameObject carrot1, carrot2, carrot3;
    int previousRandom;

    public float spawnInterval = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isGameOver)
        {
            StopCoroutine("Spawn");
        }
    }

    private void SpawnEnemies()
    {
        int random = Random.Range(1, 7);
        float rand = Random.Range(-4.31f, 3.88f);

        if (random == 1)
        {
            Instantiate(enemy1, new Vector3(transform.position.x, rand, 0), Quaternion.identity); //enemyFly
        }

        else if (random == 2)
        {
            Instantiate(enemy2, new Vector3(transform.position.x, -7.210399f, 0), Quaternion.identity); //FallenAngel
        }

        else if (random == 3)
        {
            Instantiate(enemy3, new Vector3(transform.position.x, -7.208865f, 0), Quaternion.identity); //Golem1
        }

        else if (random == 4)
        {
            Instantiate(enemy4, new Vector3(transform.position.x, -7.781992f, 0), Quaternion.identity); //Monster
        }

        else if (random == 5)
        {
            Instantiate(enemy5, new Vector3(transform.position.x, -7.280869f, 0), Quaternion.identity); //ReaperMan1
        }

        else if (random == 6)
        {
            Instantiate(enemy6, new Vector3(transform.position.x, -7.232544f, 0), Quaternion.identity); //ReaperMan2
        }
    }

    public void SpawnPlatform()
    {
        int randomNumber = Random.Range(1, 15); 
        float rand = Random.Range(-7.64f, -5.62f);
        //for Platform1/2...
        float platformRand = Random.Range(-3.3f, -0.6f);
        //form Platform with Enemy
        float platformEnemy = Random.Range(-3.3f, 0.14f);

        if (randomNumber == 1)
        {
            Instantiate(SmallGround, new Vector3(transform.position.x+4, rand, 0), Quaternion.identity);
        }

        if (randomNumber == 2)
        {
           Instantiate(MiddleGround, new Vector3(transform.position.x + 4, rand, 0), Quaternion.identity);
        }

        if (randomNumber == 3)
        {
            Instantiate(BigGround, new Vector3(transform.position.x + 4, rand, 0), Quaternion.identity);
        }

        if (randomNumber == 4)
        {
            Instantiate(BigSmall, new Vector3(transform.position.x + 4, rand, 0), Quaternion.identity);
        }

        if (randomNumber == 5)
        {
            Instantiate(BigSmallCarrot, new Vector3(transform.position.x + 4, rand, 0), Quaternion.identity);
        }

        if (randomNumber == 6)
        {
            Instantiate(MiddleGround4Carrot, new Vector3(transform.position.x + 4, rand, 0), Quaternion.identity);
        }

        if (randomNumber == 7)
        {
            Instantiate(Platform1, new Vector3(transform.position.x + 4, platformRand, 0), Quaternion.identity);
        }

        if (randomNumber == 8)
        {
            Instantiate(Platform2, new Vector3(transform.position.x + 4, platformRand, 0), Quaternion.identity);
        }

        if (randomNumber == 9)
        {
            Instantiate(Platform3, new Vector3(transform.position.x + 4, 2.38f, 0), Quaternion.identity);
        }

        if (randomNumber == 10)
        {
            Instantiate(BigGroundEnemy, new Vector3(transform.position.x + 4, platformEnemy, 0), Quaternion.identity);
        }

        if (randomNumber == 11)
        {
            Instantiate(BigGroundx2Enemy, new Vector3(transform.position.x + 4, platformEnemy, 0), Quaternion.identity);
        }

        if (randomNumber == 12)
        {
            Instantiate(BigGroundx2, new Vector3(transform.position.x + 4, platformEnemy, 0), Quaternion.identity);
        }

        if (randomNumber == 13)
        {
            Instantiate(BigSmallMushroom, new Vector3(transform.position.x + 6, -6.26f, 0), Quaternion.identity);
        }

        if (randomNumber == 14)
        {
            Instantiate(Platform3Mushroom, new Vector3(transform.position.x + 6, 2.1f, 0), Quaternion.identity);
        }


    }

    private void SpawnObstacle()
    {
        int random = Random.Range(1, 9);
        if (random == 1)
        {
            Instantiate(obstacle1, new Vector3(transform.position.x, -7.76f, 0), Quaternion.identity); //Cactus
        }

        else if (random == 2)
        {
            Instantiate(obstacle2, new Vector3(transform.position.x , -8.19f, 0), Quaternion.identity); //Prop_3
        }

        else if (random == 3)
        {
            Instantiate(obstacle3, new Vector3(transform.position.x , -8.048767f, 0), Quaternion.identity); //Prop_7
        }

        else if (random == 4)
        {
            Instantiate(obstacle4, new Vector3(transform.position.x, -8.16f, 0), Quaternion.identity); //Stone
        }

        else if (random == 5)
        {
            Instantiate(obstacle5, new Vector3(transform.position.x, -8.61f, 0), Quaternion.identity); //Pad_01_1
        }

        else if (random == 6)
        {
            Instantiate(obstacle6, new Vector3(transform.position.x, -8.61f, 0), Quaternion.identity); //Pad_01_2
        }

        else if (random == 7)
        {
            Instantiate(obstacle7, new Vector3(transform.position.x, -8.781757f, 0), Quaternion.identity); //Pad_02_1
        }

        else if (random == 8)
        {
            Instantiate(obstacle8, new Vector3(transform.position.x, -8.731874f, 0), Quaternion.identity); //Pad_02_2
        }


    }

    private void SpawnCarrots()
    {
        int random = Random.Range(1, 4);

        if (random == 1)
        {
            Instantiate(carrot1, new Vector3(transform.position.x, -7.38f, 0), Quaternion.identity); //4 
        }

        else if (random == 2)
        {
            Instantiate(carrot2, new Vector3(transform.position.x, -6f, 0), Quaternion.identity); //4-7  
        }

        else if (random == 3)
        {
            Instantiate(carrot3, new Vector3(transform.position.x, -4.4f, 0), Quaternion.identity); //16  
        }
    }

   

    IEnumerator Spawn()
        {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            int random;
            do
            {
                random = Random.Range(1, 5); 
            }
            while (random == previousRandom); 
            previousRandom = random;

            if (random == 1)
            {
                SpawnEnemies();
            }

            else if (random == 2)
            {
                SpawnPlatform();
            }

            else if (random == 3)
            {
                SpawnObstacle();
            }
            else if (random == 4)
            {
                SpawnCarrots();
            }

            /* 
            yield return new WaitForSeconds(spawnInterval);
                SpawnEnemies();
                //yield return new WaitForSeconds(spawnInterval - 4.0f);
                SpawnPlatform();
                //yield return new WaitForSeconds(spawnInterval - 2.0f);
                SpawnObstacle();
                //yield return new WaitForSeconds(spawnInterval - 1.0f);
                SpawnCarrots();*/
        }
    }

}

