using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Projectile))]
public class ProjectileEditor : Editor
{
    // Draw gizmo on these situations
    [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void DrawGizmosSelected(Projectile projectile, GizmoType gizmoType)
    {
        Gizmos.DrawSphere(projectile.transform.position, projectile.damageRadius);
    }

    public override void OnInspectorGUI()
    {
        var projectile = target as Projectile;
        var transform = projectile.transform;

        projectile.damageRadius = EditorGUILayout.Slider("Damage Radius", projectile.damageRadius, 0, 100);
    }
}