# Unity_Pratice

유니티 공부용 저장소.

## 프로젝트 목록

| 프로젝트 | 설명 | 유니티 버전 | 빌드 다운로드 |
|---|---|---|---|
| [Dodge](Dodge/) | 사방에서 날아오는 탄알을 피해 오래 버티는 3D 게임 | 6000.5.7f1 | [zip · 38MB](Dodge/Build/Dodge_Windows_x64.zip) |
| [Uni-Run](Uni-Run/) | 발판을 밟고 장애물을 피하는 2D 무한 러너 | 6000.5.7f1 | [zip · 73MB](Uni-Run/Build/UniRun_Windows_x64.zip) |

빌드 zip은 파일 페이지에서 **Download** 버튼으로 받은 뒤, 압축을 풀고 안에 있는 `.exe` 를 실행하면 됩니다. (Windows x64)

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
