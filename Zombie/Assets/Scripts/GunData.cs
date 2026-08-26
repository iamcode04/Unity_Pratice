using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName ="Scriptable/GunData", fileName = "Gun Data")] // 스크립트 오브젝트로 만드는법
public class GunData : ScriptableObject
{
    public AudioClip shotClip; // 발사 소리
    public AudioClip reloadClip; // 재장전 소리

    public float damage = 25; // 공격력(총 한발당)

    public int startAmmoRemain = 100; // 처음에 주어질 전체 탄약
    public int magCapacity = 25; // 탄창 용량

    public float timeBetFire = 0.12f; // 총알 발사 간격(연사력관련)
    public float reloadTime = 1.8f; // 재장전 소요 시간
}