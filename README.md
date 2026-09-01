# Unity_Pratice

유니티 공부용 저장소.

## 프로젝트 목록

| 프로젝트 | 설명 | 유니티 버전 | 빌드 다운로드 |
|---|---|---|---|
| [Dodge](Dodge/) | 사방에서 날아오는 탄알을 피해 오래 버티는 3D 게임 | 6000.5.7f1 | [다운로드 · 38MB](https://github.com/iamcode04/Unity_Pratice/releases/download/dodge-v1.0/Dodge_Windows_x64.zip) |
| [Uni-Run](Uni-Run/) | 발판을 밟고 장애물을 피하는 2D 무한 러너 | 6000.5.7f1 | [다운로드 · 73MB](https://github.com/iamcode04/Unity_Pratice/releases/download/unirun-v1.0/UniRun_Windows_x64.zip) |
| [Zombie](Zombie/) | 몰려오는 좀비를 총으로 막아내는 3D 웨이브 서바이벌 | 6000.5.7f1 | [다운로드 · 75MB](https://github.com/iamcode04/Unity_Pratice/releases/download/zombie-v1.0/Zombie_Windows_x64.zip) |

빌드 파일은 [Releases](https://github.com/iamcode04/Unity_Pratice/releases) 에 있습니다. zip을 받아 압축을 풀고 안에 있는 `.exe` 를 실행하면 됩니다. (Windows x64)

에디터에서 열 때는 Unity Hub → **Add** → 프로젝트 폴더 선택 → **6000.5.7f1** 로 열면 됩니다.
`Library/` 폴더는 커밋하지 않으므로 처음 열 때 에셋 재임포트에 시간이 조금 걸립니다.

---

## Dodge

### 게임 방법

- **이동**: 방향키 / WASD
- **목표**: 스포너가 쏘는 탄알을 피해 최대한 오래 생존
- **재시작**: 게임오버 후 `R` 키
- 최고 기록은 `PlayerPrefs`로 저장되어 다음 실행에도 유지됩니다.

씬: `Assets/Scenes/SampleScene.unity`

### 스크립트 구조

| 파일 | 역할 |
|---|---|
| [`PlayerController.cs`](Dodge/Assets/Scripts/PlayerController.cs) | 입력을 받아 Rigidbody 속도로 플레이어를 이동. 피격 시 `Die()` 로 게임 종료 처리 |
| [`Bullet.cs`](Dodge/Assets/Scripts/Bullet.cs) | 앞으로 등속 이동, 3초 뒤 자동 파괴. Player 태그와 충돌하면 `Die()` 호출 |
| [`BulletSpawner.cs`](Dodge/Assets/Scripts/BulletSpawner.cs) | 0.5~3초 간격으로 탄알을 생성하고 플레이어 방향(`LookAt`)으로 조준 |
| [`GameManager.cs`](Dodge/Assets/Scripts/GameManager.cs) | 생존 시간 측정, 게임오버 UI, 최고 기록 저장(`PlayerPrefs`), `R` 키 재시작 |

---

## Uni-Run


### 게임 방법

- **점프**: 마우스 왼쪽 클릭 (공중에서 한 번 더 눌러 **2단 점프**)
- 버튼을 일찍 떼면 상승이 절반으로 줄어 **점프 높이를 조절**할 수 있습니다.
- **목표**: 발판을 밟을 때마다 1점. 장애물(`Dead` 태그)에 닿으면 게임 오버
- **재시작**: 게임오버 후 마우스 왼쪽 클릭

씬: `Assets/Main.unity`

### 스크립트 구조

| 파일 | 역할 |
|---|---|
| [`PlayerController.cs`](Uni-Run/Assets/Scripts/PlayerController.cs) | 클릭으로 2단 점프, 접지 판정(법선 y > 0.7), 사망 시 애니메이션·사운드 재생 |
| [`GameManager.cs`](Uni-Run/Assets/Scripts/GameManager.cs) | 싱글톤. 점수 집계와 게임오버 UI, 클릭 재시작 |
| [`PlatformSpawner.cs`](Uni-Run/Assets/Scripts/PlatformSpawner.cs) | 발판을 미리 3개 만들어 두고 오브젝트 풀링으로 돌려 쓰며 1.25~2.25초 간격 재배치 |
| [`Platform.cs`](Uni-Run/Assets/Scripts/Platform.cs) | 활성화될 때마다 장애물을 1/3 확률로 켜고, 플레이어가 처음 밟으면 1점 추가 |
| [`ScrollingObject.cs`](Uni-Run/Assets/Scripts/ScrollingObject.cs) | 배경·발판을 왼쪽으로 등속 이동시켜 달리는 느낌을 냄 |
| [`BackgroundLoop.cs`](Uni-Run/Assets/Scripts/BackgroundLoop.cs) | 왼쪽으로 벗어난 배경을 오른쪽 끝으로 재배치해 무한 스크롤 |

---

## Zombie


### 게임 방법

- **이동**: `W` / `S` (앞뒤), `A` / `D` (좌우 회전)
- **발사**: 마우스 왼쪽 버튼 (누르고 있으면 연사)
- **재장전**: `R`
- **회복 / 탄약 / 점수**: 맵에 주기적으로 떨어지는 아이템을 밟아서 획득
- 웨이브가 올라갈수록 좀비의 수와 능력치가 함께 강해집니다.
- **재시작**: 게임오버 UI의 Restart 버튼

씬: `Assets/Scenes/Main.unity`

### 스크립트 구조

| 파일 | 역할 |
|---|---|
| [`LivingEntity.cs`](Zombie/Assets/Scripts/LivingEntity.cs) | 체력·피격·사망을 담은 생명체 공통 부모. `IDamageable` 구현 |
| [`PlayerInput.cs`](Zombie/Assets/Scripts/PlayerInput.cs) | 입력만 감지해 `move` / `rotate` / `fire` / `reload` 값으로 노출 |
| [`PlayerMovement.cs`](Zombie/Assets/Scripts/PlayerMovement.cs) | 입력값으로 캐릭터를 전후 이동·좌우 회전시키고 애니메이터에 반영 |
| [`PlayerShooter.cs`](Zombie/Assets/Scripts/PlayerShooter.cs) | 사격·재장전 처리. IK로 양손을 총 위치에 맞춤 |
| [`PlayerHealth.cs`](Zombie/Assets/Scripts/PlayerHealth.cs) | `LivingEntity`를 상속한 플레이어 체력. 사망 시 게임 오버 |
| [`Gun.cs`](Zombie/Assets/Scripts/Gun.cs) | 레이캐스트 사격, 탄피·총구 화염 이펙트, 탄약과 재장전 상태 관리 |
| [`Zombie.cs`](Zombie/Assets/Scripts/Zombie.cs) | 좀비 AI. 추적·공격 상태 전환과 피격 반응 |
| [`ZombieSpawner.cs`](Zombie/Assets/Scripts/ZombieSpawner.cs) | 웨이브마다 좀비를 생성하고 난이도를 올림 |
| [`ItemSpawner.cs`](Zombie/Assets/Scripts/ItemSpawner.cs) | 플레이어 근처에 아이템을 주기적으로 배치 |
| [`IItem.cs`](Zombie/Assets/Scripts/IItem.cs) / [`AmmoPack.cs`](Zombie/Assets/Scripts/AmmoPack.cs) · [`HealthPack.cs`](Zombie/Assets/Scripts/HealthPack.cs) · [`Coin.cs`](Zombie/Assets/Scripts/Coin.cs) | 아이템 인터페이스와 구현 3종 |
| [`GunData.cs`](Zombie/Assets/Scripts/GunData.cs) / [`ZombieData.cs`](Zombie/Assets/Scripts/ZombieData.cs) | 총·좀비 수치를 담는 `ScriptableObject` |
| [`GameManager.cs`](Zombie/Assets/Scripts/GameManager.cs) / [`UIManager.cs`](Zombie/Assets/Scripts/UIManager.cs) | 점수·게임오버 상태 관리와 UI 갱신, 재시작 |

배포용 zip에는 `Zombie_BackUpThisFolder_ButDontShipItWithYourGame`(IL2CPP 디버그 심볼 675MB)과
`Zombie_BurstDebugInformation_DoNotShip`은 포함하지 않았습니다. 실행에는 필요 없는 파일입니다.
