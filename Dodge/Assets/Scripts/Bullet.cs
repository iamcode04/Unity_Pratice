using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();

        bulletRigidbody.linearVelocity = transform.forward * speed;

        Destroy(gameObject, 3f);
        // 3초 뒤에 자기자신 없애기
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) // other 은 상대 콜라이더를 의미
    {
        if (other.CompareTag("Player")) // 상대 콜라이더의 other의 이름이 Player라면
        {
            /*
            CompareTag : 유니티 내부에서 바로 id 비교, 없는 태그면 유니티가 없다고 경고 날림
            other.tag == "Player" : cs 내부에서 글자 하나씩 비교, 안맞으면 가비지 나옴, 없는 태그면 유니티가 경고를 날리지 않고, 조용히 false 반환

            other : 부딪힌 상대방
            GetComponent : 컴포넌트들을 가지고옴
            <> : 어떤 컴포넌트를 가지고 올꺼냐 ex) rigidbody, 스크립트.. 등등
            */
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null) // Player의 이름을 가진 오브젝트 중 PlayerController 스크립트를 가진 오브젝트를 고르기 위함
            // 만약 playerController 스크립트가 없는 Player라면 GetComponent가 null 반환
            {
                playerController.Die();
            }
        }
    }
}
