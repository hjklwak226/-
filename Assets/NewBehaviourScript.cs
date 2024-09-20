using UnityEngine;
using UnityEngine.UI;

public class EnhancementSystem : MonoBehaviour
{
    // �ʱ� ��ȭ ���� Ȯ��
    public float enhancementSuccessProbability = 50f;  // ù ��ȭ Ȯ�� 100%

    // Ȯ�� ������
    public float probabilityDecreaseRate = 5f;         // �Ź� ��ȭ �õ� �� 10% ����

    // �ּ� Ȯ�� (�ּ� 5%������ ���� �����ϵ��� ����)
    public float minimumProbability = 5f;

    // ��ȭ ���� Ƚ�� ī��Ʈ
    private int successCount = 0;

    // ��ȭ ���� 5ȸ �� �ٲ�� �̹���
    public Image 

    // �⺻ �̹����� ���� �� �̹���
    public Sprite defaultImage;
    public Sprite successImage;

    // ��ȭ ����� ������ UI �ؽ�Ʈ
    public Text resultText;

    // ��ȭ ��ư
    public Button enhanceButton;

    void Start()
    {
        // �⺻ �̹����� ����
        enhancementImage.sprite = defaultImage;

        // ��ư�� ��ȭ �Լ� ����
        enhanceButton.onClick.AddListener(OnEnhanceButtonClicked);
    }

    // ��ȭ ��ư Ŭ�� �� ����Ǵ� �Լ�
    void OnEnhanceButtonClicked()
    {
        bool result = TryEnhance();
        resultText.text = "��ȭ ���: " + (result ? "����" : "����");

        // ��ȭ�� ������ ������ ���� Ƚ�� ����
        if (result)
        {
            successCount++;

            // ���� Ƚ���� 5���� �����ϸ� �̹��� ����
            if (successCount == 5)
            {
                ChangeImage();
            }
        }
    }

    // ��ȭ �õ� �Լ�
    bool TryEnhance()
    {
        // 0���� 100 ������ ���� �� ����
        float randomValue = Random.Range(0f, 100f);

        // ��ȭ ���� ���� �Ǵ�
        if (randomValue < enhancementSuccessProbability)
        {
            DecreaseEnhancementProbability();  // ��ȭ ���� �� Ȯ�� ����
            return true;  // ����
        }
        else
        {
            return false;  // ����
        }
    }

    // ��ȭ ���� Ȯ�� ���� �Լ�
    void DecreaseEnhancementProbability()
    {
        // ��ȭ ���� Ȯ���� ���ҽ�Ű��, �ּ� Ȯ�� ���Ϸδ� �������� �ʵ��� ����
        enhancementSuccessProbability = Mathf.Max(enhancementSuccessProbability - probabilityDecreaseRate, minimumProbability);
    }

    // 5ȸ ���� �� �̹����� �����ϴ� �Լ�
    void ChangeImage()
    {
        enhancementImage.sprite = successImage;
        Debug.Log("�̹����� ����Ǿ����ϴ�!");
    }
}
