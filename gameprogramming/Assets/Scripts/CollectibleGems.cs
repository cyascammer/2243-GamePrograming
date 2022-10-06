using UnityEngine;
using DG.Tweening;

public class CollectibleGems : MonoBehaviour
{
    [SerializeField] private Transform tween_End;
    private void Start()
    {
        transform.DOMove(tween_End.position, 6f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }
}