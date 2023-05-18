using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
// By:明明鸭！

public class AnimationController : UdonSharpBehaviour
{
    [Header("鸭鸭讨厌Bug!!!")]
    
    [Header("要移动的层级")]
    public Transform targetTransform;  // 要控制的对象的 Transform 组件
    public AnimationCurve curve;  // 动画曲线
    [Header("持续时间")]
    public float duration = 1f;  // 动画持续时间
    [Header("初始位置")]
    public Vector3 startPosition;  // 初始位置
    [Header("结束位置")]
    public Vector3 endPosition;  // 结束位置

    private float timer = 0f;  // 记录动画已经播放的时间

    public void Update()
    {
        // 更新计时器
        timer += Time.deltaTime;

        // 计算动画进度（0-1之间的值）
        float progress = Mathf.Clamp01(timer / duration);

        // 使用动画曲线计算位置插值
        Vector3 position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(progress));

        // 将位置应用到目标对象的 Transform 组件
        targetTransform.position = position;
    }
}
