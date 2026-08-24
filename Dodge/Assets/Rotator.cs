using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 60f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,rotationSpeed*Time.deltaTime,0f);
        //Time.deltaTime : 프레임의 역수 
        // 즉 TimedeltaTime과 speed를 곱해주면 60도 X 1/60 이므로 1프레임에 1도가 돌아간다 (60FPS 경우)
    }
}
