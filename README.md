# Unity_Pratice

유니티 공부용 저장소.

## 프로젝트 목록

| 프로젝트 | 설명 | 유니티 버전 |
|---|---|---|
| [Dodge](Dodge/) | 사방에서 날아오는 탄알을 피해 오래 버티는 3D 게임 | 6000.5.7f1 |

---

## Dodge

### 게임 방법

- **이동**: 방향키 / WASD
- **목표**: 스포너가 쏘는 탄알을 피해 최대한 오래 생존
- **재시작**: 게임오버 후 `R` 키
- 최고 기록은 `PlayerPrefs`로 저장되어 다음 실행에도 유지됩니다.

### 바로 플레이 (Windows)

빌드된 실행 파일을 받아서 바로 플레이할 수 있습니다.

1. [`Dodge/Build/Dodge_Windows_x64.zip`](Dodge/Build/Dodge_Windows_x64.zip) 다운로드 (약 38MB)
2. 압축 해제 후 `Dodge.exe` 실행

### 에디터에서 열기

1. Unity Hub → **Add** → `Dodge` 폴더 선택
2. 유니티 **6000.5.7f1** 로 열기
3. `Assets/Scenes/SampleScene.unity` 열고 재생

`Library/` 폴더는 커밋하지 않으므로, 처음 열 때 유니티가 에셋을 다시 임포트하며 시간이 조금 걸립니다.

### 스크립트 구조

| 파일 | 역할 |
|---|---|
| [`PlayerController.cs`](Dodge/Assets/Scripts/PlayerController.cs) | 입력을 받아 Rigidbody 속도로 플레이어를 이동. 피격 시 `Die()` 로 게임 종료 처리 |
| [`Bullet.cs`](Dodge/Assets/Scripts/Bullet.cs) | 앞으로 등속 이동, 3초 뒤 자동 파괴. Player 태그와 충돌하면 `Die()` 호출 |
| [`BulletSpawner.cs`](Dodge/Assets/Scripts/BulletSpawner.cs) | 0.5~3초 간격으로 탄알을 생성하고 플레이어 방향(`LookAt`)으로 조준 |
| [`GameManager.cs`](Dodge/Assets/Scripts/GameManager.cs) | 생존 시간 측정, 게임오버 UI, 최고 기록 저장(`PlayerPrefs`), `R` 키 재시작 |
