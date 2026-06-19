using System;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x020000AB RID: 171
	[RequireComponent(typeof(InteractionSystem))]
	public class InteractionSystemTestGUIV2 : MonoBehaviour
	{
		// Token: 0x0600068A RID: 1674 RVA: 0x0001FEB4 File Offset: 0x0001E0B4
		private void Awake()
		{
			this.interactionSystem = base.GetComponent<InteractionSystem>();
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0001FEC4 File Offset: 0x0001E0C4
		private void OnGUI()
		{
			if (this.interactionSystem == null)
			{
				return;
			}
			foreach (InteractionSystemTestGUIV2.Test test in this.m_Tests)
			{
				if (!(test.interactionObject == null))
				{
					if (!this.interactionSystem.IsPaused(test.effector))
					{
						if (GUILayout.Button("Start Interaction With " + test.interactionObject.name, Array.Empty<GUILayoutOption>()))
						{
							this.interactionSystem.StartInteraction(test.effector, test.interactionObject, false);
						}
					}
					else if (GUILayout.Button("Resume Interaction With " + test.interactionObject.name, Array.Empty<GUILayoutOption>()))
					{
						this.interactionSystem.ResumeInteraction(test.effector);
					}
					GUILayout.Space(10f);
				}
			}
		}

		// Token: 0x04000475 RID: 1141
		private InteractionSystem interactionSystem;

		// Token: 0x04000476 RID: 1142
		[SerializeField]
		private InteractionSystemTestGUIV2.Test[] m_Tests;

		// Token: 0x0200018D RID: 397
		[Serializable]
		public class Test
		{
			// Token: 0x040008D8 RID: 2264
			public InteractionObject interactionObject;

			// Token: 0x040008D9 RID: 2265
			public FullBodyBipedEffector effector;
		}
	}
}
