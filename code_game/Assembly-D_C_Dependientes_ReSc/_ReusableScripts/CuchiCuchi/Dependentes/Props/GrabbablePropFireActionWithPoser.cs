using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Props
{
	// Token: 0x02000144 RID: 324
	public abstract class GrabbablePropFireActionWithPoser : GrabbablePropFireAction
	{
		// Token: 0x06000660 RID: 1632 RVA: 0x000236F4 File Offset: 0x000218F4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			Dictionary<string, Transform> dictionary = (from t in this.m_interactionPoseRoot.GetComponentsInChildren<Transform>()
				where t != this.m_interactionPoseRoot
				select t).ToDictionary((Transform t) => t.name);
			Dictionary<string, Transform> dictionary2 = (from t in this.m_startPoseRoot.GetComponentsInChildren<Transform>()
				where t != this.m_startPoseRoot
				select t).ToDictionary((Transform t) => t.name);
			Dictionary<string, Transform> dictionary3 = (from t in this.m_endPoseRoot.GetComponentsInChildren<Transform>()
				where t != this.m_endPoseRoot
				select t).ToDictionary((Transform t) => t.name);
			List<GrabbablePropFireActionWithPoser.BonePoseData> list = new List<GrabbablePropFireActionWithPoser.BonePoseData>();
			foreach (KeyValuePair<string, Transform> keyValuePair in dictionary)
			{
				GrabbablePropFireActionWithPoser.BonePoseData bonePoseData = new GrabbablePropFireActionWithPoser.BonePoseData();
				bonePoseData.Init(keyValuePair.Value, dictionary2[keyValuePair.Key], dictionary3[keyValuePair.Key]);
				list.Add(bonePoseData);
			}
			this.m_bonePoseData = list.ToArray();
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x0002384C File Offset: 0x00021A4C
		protected override void OnFireActionWeightUpdated(bool changed, bool increasing)
		{
			for (int i = 0; i < this.m_bonePoseData.Length; i++)
			{
				this.m_bonePoseData[i].Lerp(this.m_currentFireActionValue);
			}
		}

		// Token: 0x04000523 RID: 1315
		[Header("Poser")]
		[SerializeField]
		private Transform m_interactionPoseRoot;

		// Token: 0x04000524 RID: 1316
		[SerializeField]
		private Transform m_startPoseRoot;

		// Token: 0x04000525 RID: 1317
		[SerializeField]
		private Transform m_endPoseRoot;

		// Token: 0x04000526 RID: 1318
		[SerializeField]
		[ReadOnlyUI]
		private GrabbablePropFireActionWithPoser.BonePoseData[] m_bonePoseData;

		// Token: 0x02000145 RID: 325
		[Serializable]
		public class BonePoseData
		{
			// Token: 0x06000666 RID: 1638 RVA: 0x000238B1 File Offset: 0x00021AB1
			public void Init(Transform InteractionBone, Transform StartPoseBone, Transform EndPoseBone)
			{
				this.interactionBone = InteractionBone;
				this.startPoseBone = StartPoseBone;
				this.endPoseBone = EndPoseBone;
			}

			// Token: 0x06000667 RID: 1639 RVA: 0x000238C8 File Offset: 0x00021AC8
			public void Lerp(float w)
			{
				this.interactionBone.localRotation = Quaternion.Slerp(this.startPoseBone.localRotation, this.endPoseBone.localRotation, w);
			}

			// Token: 0x04000527 RID: 1319
			public Transform interactionBone;

			// Token: 0x04000528 RID: 1320
			public Transform startPoseBone;

			// Token: 0x04000529 RID: 1321
			public Transform endPoseBone;
		}
	}
}
