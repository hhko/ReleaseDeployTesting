# ReleaseDeployTesting

C# Hello World 프로그램을 GitHub Release에 자동 배포하는 프로젝트입니다. **Linux x64 전용**으로 빌드 및 배포됩니다.

## 프로젝트 구조

```
ReleaseDeployTesting/
├── Program.cs                      # Hello World 메인 프로그램
├── HelloWorld.csproj               # C# 프로젝트 파일
├── .release-notes/                 # 릴리스 노트 폴더
│   ├── RELEASE_NOTES_v1.0.0.md     # 버전별 릴리스 노트 (태그 버전과 일치)
│   └── RELEASE_NOTES.md            # 기본 릴리스 노트 (fallback)
├── .gitignore                     # Git 무시 파일 목록
└── .github/
    └── workflows/
        └── release.yml             # GitHub Actions 워크플로우
```

## 로컬 빌드 및 실행

### 요구사항
- .NET 8.0 SDK 이상

### 빌드
```bash
dotnet build
```

### 실행
```bash
dotnet run
```

### Linux x64 단일 파일로 배포
```bash
dotnet publish -c Release -r linux-x64 --self-contained true -p:PublishSingleFile=true
```

배포된 파일은 `bin/Release/net8.0/linux-x64/publish/` 디렉토리에 생성됩니다.

## GitHub Release 배포 방법

### 1. Release 노트 작성 (필수)

`.release-notes` 폴더에 태그 버전과 일치하는 릴리스 노트 파일을 **반드시** 작성해야 합니다. 파일이 없으면 릴리스가 실패합니다.

**파일 위치 및 이름 규칙:**
- `.release-notes/RELEASE_NOTES_v{태그명}.md` (예: `.release-notes/RELEASE_NOTES_v1.0.0.md`)
- 또는 `.release-notes/RELEASE_NOTES_{버전}.md` (예: `.release-notes/RELEASE_NOTES_1.0.0.md`)
- **모든 파일이 없으면 릴리스가 실패합니다**

**예시:**
```markdown
# Release Notes

## Version 1.0.0

### Features
- 새로운 기능 설명

### Bug Fixes
- 버그 수정 내용

### Installation
...
```

**파일 생성 예시:**
```bash
# .release-notes 폴더에 v1.0.0 릴리스 노트 생성
cp .release-notes/RELEASE_NOTES.md .release-notes/RELEASE_NOTES_v1.0.0.md
# 또는
cp .release-notes/RELEASE_NOTES.md .release-notes/RELEASE_NOTES_1.0.0.md

# 파일 내용 수정
# 그 다음 태그 생성 및 푸시
```

### 2. 코드 커밋 및 푸시
```bash
git add .
git commit -m "Update release notes"
git push origin main
```

### 3. 태그 생성 및 푸시
GitHub Actions는 `v*` 형식의 태그가 푸시될 때 자동으로 빌드하고 Release를 생성합니다.

```bash
# 태그 생성
git tag v1.0.0

# 태그 푸시
git push origin v1.0.0
```

### 4. 수동 실행 (선택사항)
GitHub 저장소의 Actions 탭에서 "Build and Release" 워크플로우를 수동으로 실행할 수도 있습니다.

## GitHub Actions 워크플로우 설명

워크플로우는 다음 작업을 수행합니다:

1. **빌드**: Linux (Ubuntu)에서 빌드
2. **배포**: Linux x64용 단일 실행 파일 생성 (Self-contained)
3. **아카이브**: `linux-x64.tar.gz` 아카이브 생성
4. **Release 생성**: 
   - `RELEASE_NOTES.md` 파일을 읽어서 Release 노트로 사용
   - 파일이 없으면 기본 릴리스 노트 생성
   - GitHub Release 자동 생성 및 아티팩트 업로드

## 릴리스 다운로드 및 실행

GitHub Releases 페이지에서 Linux x64 바이너리를 다운로드할 수 있습니다:

```bash
# 다운로드
wget https://github.com/YOUR_USERNAME/YOUR_REPO/releases/download/v1.0.0/linux-x64.tar.gz

# 압축 해제
tar -xzf linux-x64.tar.gz

# 실행
./HelloWorld
```

## Release 노트 관리

`.release-notes` 폴더에 각 릴리스 버전별로 별도의 릴리스 노트 파일을 **반드시** 관리해야 합니다:

- **폴더 위치**: `.release-notes/`
- **버전별 파일**: `RELEASE_NOTES_v{태그명}.md` 또는 `RELEASE_NOTES_{버전}.md`
  - 예: `.release-notes/RELEASE_NOTES_v1.0.0.md`, `.release-notes/RELEASE_NOTES_1.0.0.md`
- **기본 파일**: `.release-notes/RELEASE_NOTES.md` (fallback)
- **⚠️ 중요**: 위 파일이 모두 없으면 릴리스가 실패합니다

### 크기 제한

릴리스 노트 파일은 다음 제한사항을 준수해야 합니다:

- **최대 문자 수**: 125,000자 (GitHub Release body 제한)
- **권장 파일 크기**: 10MB 미만 (성능 고려)
- 파일이 제한을 초과하면 릴리스가 실패합니다

태그를 푸시하면 `.release-notes` 폴더에서 해당 버전과 일치하는 릴리스 노트 파일을 자동으로 찾아서 GitHub Release의 본문(body)으로 사용합니다. 파일이 없거나 크기 제한을 초과하면 워크플로우가 실패하므로 릴리스를 생성하기 전에 반드시 릴리스 노트 파일을 작성하고 크기를 확인해야 합니다.

## 라이선스

이 프로젝트는 MIT 라이선스를 따릅니다.