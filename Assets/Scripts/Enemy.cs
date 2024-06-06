using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed ;

    private float countdown = 5f;
    int waveSpawnPoint ;

    private WaveSpawner waveSpawner;


    private Rigidbody rb;
    private void Start()
    {
        speed = Random.Range(0.2f,2f);
        waveSpawner = GetComponentInParent<WaveSpawner>();
        waveSpawnPoint = waveSpawner.waveSpawnPointIndex;
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
        // Handle collision detection here
        other.gameObject.SetActive(false);
        GameBehaviour.Instance.ShowLoseScreen();
    }
    }

    private void SetLaserSpeed() {
        int currentIndex = waveSpawner.currentWaveIndex;
        if(currentIndex == 0){
            speed = 0.8f;
        }
        if(currentIndex == 1){
            speed = 1.2f;
        }
        if(currentIndex == 2){
            speed = 1.5f;
        }
        if(currentIndex == 3){
            speed = 1.8f;
        }
        if(currentIndex == 4){
            speed = 2f;
        }
    }
    private void Update()
    {
        SetLaserSpeed();
        if(waveSpawnPoint == 1)
            transform.Translate(transform.right * speed * Time.deltaTime);
            //rb.velocity = transform.right * speed;

        if(waveSpawnPoint == 2)
            transform.Translate(-transform.right * speed * Time.deltaTime);

        if(waveSpawnPoint == 3)
            transform.Translate(transform.up * speed * Time.deltaTime);

        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            Destroy(gameObject);

            waveSpawner.waves[waveSpawner.currentWaveIndex].enemiesLeft--;
        }
    }
}