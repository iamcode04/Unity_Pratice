using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;
    // 인스펙터에 빈칸을 만들어준다.
    // 여기에 아무것도 안넣어주면 당연히 null이다. 
    // 그러나 유니티에서 이 빈칸에 project의 Bullet 프리팹을 넣어줄 것이다. (드래그앤드롭)
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3f;

    private Transform target;
    // 빈 이름표로 인스펙터에 보이지 않음
    // start에서 PlayerController의 위치정보가 저장됌
    private float spawnRate; // 탄알 발사 후 다음 탄알이 발사 될 때까지의 시간 ( 탄알 발사 간격 )
    private float timeAfterSpawn; // 마지막 탄알 생성 후 흐른 시간
    // 한번 발사하고 몇초를 기다릴꺼냐
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindFirstObjectByType<PlayerController>().transform;
        // FindFirstObjectByType은 씬 전체에서 검색하는것이다.
        // 그리고 그 전체에서 PlayerController를 찾았다. 
        // 그 PlayerController 의 transform을 찾았다.
        // 왜 이렇게 하냐면 스포너는 플레이어를 모른다. 부딪히지도 않기 때문
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;
        // Time.deltaTime 은 1/60 초 이다.(60프레임이면)
        // timeAfterSpawn 은 Update 실행시마다 1/60초가 더해진다.(60프레임이면)
        
        if(timeAfterSpawn >= spawnRate) 
        // spawnRate 만큼 기다렸다면! 실행
        {
            timeAfterSpawn = 0f; // 다시 초기화 
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            // GameObject :  유니티의 Hierarchy 창을 가리킴 + project의 프리팹도 포함
            // Instantiate : 복제본 만들기 
            // 현재 bulletPrefab에는 Bullet 프리팹이 저장되어있다. 
            // transform.position, rotation은 스포너의 위치 정보이다.
            // 따라서 bullet에는 Bullet 프리펩의 정보와 스포너의 위치 및 발사 위치 정보가 들어가 있다. 


            bullet.transform.LookAt(target);
            // target이 플레이어의 정보가 저장되어있음
            // LookAt은 플레이어의 위치를 쳐다봐라 누구가 : bullet(Bullet 프리펩)
            spawnRate = Random.Range(spawnRateMin,spawnRateMax);
            // 다시 교체
        }
    }
}
