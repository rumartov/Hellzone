using Services.Input;
using UnityEngine;

public static class Utils
{
    public enum FlipAxis
    {
        X,
        Y,
        Z
    }

    public static void FlipTransform(ref Transform transform, float angle, FlipAxis axis,
        float rightSideFlipTransform, float leftSideFlipTransform)
    {
        var rotation = transform.localRotation;
        rotation = axis switch
        {
            FlipAxis.X => Quaternion.Euler(
                IsMouseOnRightSide(angle) ? rightSideFlipTransform : leftSideFlipTransform,
                rotation.y, rotation.z),
            FlipAxis.Y => Quaternion.Euler(rotation.x,
                IsMouseOnRightSide(angle) ? rightSideFlipTransform : leftSideFlipTransform, rotation.z),
            FlipAxis.Z => Quaternion.Euler(rotation.x, rotation.y,
                IsMouseOnRightSide(angle) ? rightSideFlipTransform : leftSideFlipTransform),
            _ => rotation
        };

        transform.localRotation = rotation;
    }

    private static bool IsMouseOnRightSide(float angle)
    {
        return angle is <= 270f and >= 90f;
    }

    public static bool HeroIsMoving(IInputService inputService)
    {
        return inputService.Axis.sqrMagnitude > Constants.Epsilon;
    }
}