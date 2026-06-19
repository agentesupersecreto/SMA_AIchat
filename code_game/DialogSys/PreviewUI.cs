using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000013 RID: 19
	[AddComponentMenu("")]
	public class PreviewUI : MonoBehaviour
	{
		// Token: 0x0600002C RID: 44 RVA: 0x00002830 File Offset: 0x00000A30
		public static void ShowMessage(string message, float duration, int lineOffset)
		{
			Canvas component = new GameObject("Editor Preview UI", new Type[]
			{
				typeof(Canvas),
				typeof(PreviewUI)
			}).GetComponent<Canvas>();
			component.gameObject.tag = "EditorOnly";
			component.gameObject.hideFlags = HideFlags.DontSave;
			component.renderMode = RenderMode.ScreenSpaceOverlay;
			component.sortingOrder = 9999;
			Text component2 = new GameObject("Preview Text", new Type[]
			{
				typeof(Text),
				typeof(Outline)
			}).GetComponent<Text>();
			component2.rectTransform.localPosition = new Vector3(component2.rectTransform.localPosition.x, component2.rectTransform.localPosition.y + (float)(20 * lineOffset), component2.rectTransform.localPosition.z);
			component2.alignment = TextAnchor.MiddleCenter;
			component2.transform.SetParent(component.transform, false);
			component2.rectTransform.anchorMin = Vector2.zero;
			component2.rectTransform.anchorMax = Vector2.one;
			component.GetComponent<PreviewUI>().ShowMessageOnInstance(message, duration);
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002958 File Offset: 0x00000B58
		public void ShowMessageOnInstance(string message, float duration)
		{
			base.StartCoroutine(this.ShowMessageOnInstanceCoroutine(message, duration));
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002969 File Offset: 0x00000B69
		public IEnumerator ShowMessageOnInstanceCoroutine(string message, float duration)
		{
			Text componentInChildren = base.GetComponentInChildren<Text>();
			if (componentInChildren == null)
			{
				yield break;
			}
			componentInChildren.text = message;
			float num = (Mathf.Approximately(0f, duration) ? 2f : duration);
			float endTime = Time.realtimeSinceStartup + num;
			while (Time.realtimeSinceStartup < endTime)
			{
				yield return null;
			}
			if (Application.isEditor && !Application.isPlaying)
			{
				Object.DestroyImmediate(base.gameObject);
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
			yield break;
		}
	}
}
