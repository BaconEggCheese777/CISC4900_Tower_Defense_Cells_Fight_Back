using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveSpawn : MonoBehaviour {

	public GameObject bacteria1;
	public GameObject bacteria2;
	public GameObject bacteria3;
	public GameObject bacteria4;

    private bool SlideShown1 = false;
    private bool SlideShown2 = false;
    private bool SlideShown3 = false;
    private bool SlideShown4 = false;

    public static int EnemiesAlive;

	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;

	private int waveIndex;

private void Start()
{
	EnemiesAlive = 0;
	waveIndex = 0;
}

	void Update ()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waves.Length)
		{
			SceneManager.LoadScene("Win");
		}
		
    if (waveIndex == 0 && SlideShown1 == false)
    {
	    Time.timeScale = 0;
	    bacteria1.SetActive (true);
        SlideShown1 = true;
    }
    if (waveIndex == 2 && SlideShown2 == false)
    {
	    Time.timeScale = 0;
	    bacteria2.SetActive (true);
        SlideShown2 = true;
    }
    if (waveIndex == 4 && SlideShown3 == false)
    {
	    Time.timeScale = 0;
	    bacteria3.SetActive (true);
        SlideShown3 = true;
    }
    if (waveIndex == 6 && SlideShown4 == false)
    {
	    Time.timeScale = 0;
	    bacteria4.SetActive (true);
        SlideShown4 = true;
    }




		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

	}

    IEnumerator SpawnWave ()
	{

		Wave wave = waves[waveIndex];


		for (int i = 0; i < wave.count; i++)
		{
			EnemiesAlive += 2;
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f);
			SpawnEnemy2(wave.enemy2);
			yield return new WaitForSeconds(1f);
		}
		waveIndex++;
	}

	void SpawnEnemy (GameObject enemy)
	{
		Instantiate(enemy, spawnPoint.position + new Vector3(0, Random.Range(0, 9), 0), spawnPoint.rotation);
	}
void SpawnEnemy2 (GameObject enemy2)
	{
		Instantiate(enemy2, spawnPoint.position + new Vector3(0, Random.Range(0, 9), 0), spawnPoint.rotation);
	}

}