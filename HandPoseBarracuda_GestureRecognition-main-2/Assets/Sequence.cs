using System.Collections;
using DG.Tweening; // DoTween 네임스페이스
using UnityEngine;
using UnityEngine.UI;

public class CharacterDialogue : MonoBehaviour
{
    public Text dialogueText; // 대사를 표시할 UI 텍스트
    public Transform character; // 캐릭터 Transform
    public Transform talkPosition; // 캐릭터의 대화 애니메이션 위치
    public Transform idlePosition; // 캐릭터의 기본 위치
    public Button continueButton; // 대화 후 표시될 버튼

    private string[] dialogues = {
        "헉 저기요!!!",
        "제가 주차장에 갇혀서 그런데....",
        "절 좀 여기서 나가게 도와주세요."
    };

    private int currentDialogueIndex = 0; // 현재 대사 인덱스

    void Start()
    {
        // 버튼 비활성화
        continueButton.gameObject.SetActive(false);

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

        // 모든 대화가 끝난 후 버튼 표시
        continueButton.gameObject.SetActive(true);
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

    public void ChangeScene(string scene)
    {
        MySceneManager.Instance.ChangeScene(scene);
    }
}