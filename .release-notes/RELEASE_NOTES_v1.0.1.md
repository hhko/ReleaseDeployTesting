# Release Notes

## Version 1.0.1

### Features
- 릴리스 노트 파일 크기 검증 PowerShell 스크립트 추가
  - `validate-release-notes.ps1`: 릴리스를 생성하기 전에 파일 크기를 사전에 확인 가능
  - GitHub Release body 제한(125,000자) 대비 비율 표시
  - 제한 초과 시 에러 메시지 및 경고 제공

### Improvements
- README에 릴리스 노트 크기 검증 도구 사용 방법 추가
- 릴리스 전 파일 크기 확인 프로세스 개선

### Installation

1. 다운로드
   ```bash
   wget https://github.com/hhko/ReleaseDeployTesting/releases/download/v1.0.1/linux-x64.tar.gz
   ```

2. 압축 해제
   ```bash
   tar -xzf linux-x64.tar.gz
   ```

3. 실행
   ```bash
   ./HelloWorld
   ```

### System Requirements
- Linux x64
- .NET 8.0 Runtime (Self-contained 배포로 별도 설치 불필요)

### Usage

릴리스 노트 파일 크기 검증:
```powershell
.\validate-release-notes.ps1 -FilePath ".release-notes\RELEASE_NOTES_v1.0.1.md"
```
