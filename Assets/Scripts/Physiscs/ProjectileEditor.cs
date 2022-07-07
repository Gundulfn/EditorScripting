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

    void OnSceneGUI()
    {
        var projectile = target as Projectile;
        var transform = projectile.transform;
        projectile.damageRadius = Handles.RadiusHandle(transform.rotation, transform.position, projectile.damageRadius);
    }
}