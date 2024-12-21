using System.Collections;
using DG.Tweening; // DoTween 네임스페이스
using UnityEngine;
using UnityEngine.UI;

public class CharacterDialogue3 : MonoBehaviour
{
    public Text dialogueText; // 대사를 표시할 UI 텍스트
    public Transform character; // 캐릭터 Transform
    public Transform talkPosition; // 캐릭터의 대화 애니메이션 위치
    public Transform idlePosition; // 캐릭터의 기본 위치
    public Transform mysteriousMan; // 남자 오브젝트 위치
    public Camera mainCamera; // 메인 카메라
    public CanvasGroup backgroundCanvas; // 배경 페이드 아웃 효과를 위한 CanvasGroup
    public Text toBeContinuedText; // "To be continued" 텍스트
    public Button continueButton; // 대화 후 표시될 버튼

    private string[] dialogues = {
        "이 지옥같은 주차장에서 꺼내주시다니..",
        "정말 감사해요 ㅎㅎ",
        "헉 저 남자는???"
    };

    private int currentDialogueIndex = 0; // 현재 대사 인덱스

    void Start()
    {
        // 버튼과 "To be continued" 텍스트 비활성화
        continueButton.gameObject.SetActive(false);
        toBeContinuedText.gameObject.SetActive(false);

        // 대화 시작
        StartCoroutine(AutoDialogue());
    }

    private IEnumerator AutoDialogue()
    {
        while (currentDialogueIndex < dialogues.Length)
        {
            ShowDialogue();

            // 대사 진행 시간(텍스트 표시 및 이동 포함) 대기
            yield return new WaitForSeconds(2.3f); // 총 0.5s 이동 + 1s 유지 + 0.3s 페이드 아웃
            currentDialogueIndex++;
        }

        // 마지막 대사 이후 추가 연출 실행
        yield return StartCoroutine(FinalScene());
    }

    private void ShowDialogue()
    {
        // 시퀀스 초기화
        Sequence sequence = DOTween.Sequence();

        // 캐릭터가 대화 위치로 이동
        sequence.Append(character.DOMove(talkPosition.position, 0.5f).SetEase(Ease.InOutSine));

        // 텍스트 표시
        sequence.AppendCallback(() =>
        {
            dialogueText.text = dialogues[currentDialogueIndex];
            dialogueText.DOFade(1f, 0.3f); // 텍스트 페이드 인
        });

        // 텍스트 유지 시간
        sequence.AppendInterval(1f);

        // 텍스트 페이드 아웃
        sequence.Append(dialogueText.DOFade(0f, 0.3f));

        // 캐릭터가 원래 위치로 돌아감
        sequence.Append(character.DOMove(idlePosition.position, 0.5f).SetEase(Ease.InOutSine));
    }

    private IEnumerator FinalScene()
    {
        // 디버깅용 로그
        Debug.Log("FinalScene 시작!");

        // 카메라 이동 및 확대 효과를 위한 시퀀스 생성
        Sequence cameraSequence = DOTween.Sequence();

        // 카메라 이동
        Vector3 targetPosition = mysteriousMan.position + new Vector3(0, 2, -5); // 남자를 기준으로 약간 위에서 뒤로 이동
        cameraSequence.Append(mainCamera.transform.DOMove(targetPosition, 2f).SetEase(Ease.InOutSine));

        // 카메라 확대 (Perspective 모드)
        cameraSequence.Join(DOTween.To(() => mainCamera.fieldOfView, x => mainCamera.fieldOfView = x, 30f, 2f)); // FOV 30으로 축소

        // 카메라 연출 실행 후 대기
        yield return cameraSequence.WaitForCompletion();

        // 디버깅용 로그
        Debug.Log("카메라 이동 및 확대 완료");

        // 배경 페이드 아웃
        backgroundCanvas.DOFade(0f, 1.5f);

        // "To be continued" 텍스트 표시
        yield return new WaitForSeconds(1.5f); // 페이드 아웃 대기
        toBeContinuedText.gameObject.SetActive(true);
        toBeContinuedText.DOFade(1f, 1f);

        // 버튼 활성화 (선택적으로 다음 장면 전환)
        continueButton.gameObject.SetActive(true);
    }



    public void ChangeScene(string scene)
    {
        MySceneManager.Instance.ChangeScene(scene);
    }
}
