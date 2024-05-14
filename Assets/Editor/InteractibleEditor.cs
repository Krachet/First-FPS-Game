using UnityEditor;

[CustomEditor(typeof(Interactible), true)]
public class InteractibleEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactible interactible = (Interactible)target;
        if (target.GetType() == typeof(EventOnlyInteractible))
        {
            interactible.hoverMessage = EditorGUILayout.TextField("Hover Message", interactible.hoverMessage);
            EditorGUILayout.HelpBox("EventOnlyInteract can ONLY use UnityEvents", MessageType.Info);
            if (interactible.GetComponent<InteractionEvents>() == null)
            {
                interactible.useEvents = true;
                interactible.gameObject.AddComponent<InteractionEvents>();
            }
        }
        base.OnInspectorGUI();
        if (interactible.useEvents)
        {
            if (interactible.GetComponent<InteractionEvents>() == null)
            {
                interactible.gameObject.AddComponent<InteractionEvents>();
            }
        }
        else
        {
            if (interactible.GetComponent<InteractionEvents>() != null)
            {
                DestroyImmediate(interactible.GetComponent<InteractionEvents>());
            }
        }
    }
}
