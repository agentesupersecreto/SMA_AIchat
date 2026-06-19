using System;
using System.Collections;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x02000010 RID: 16
	public class TemperaturaCorporal : CustomMonobehaviour
	{
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00003A9D File Offset: 0x00001C9D
		public float currentTemp
		{
			get
			{
				return this.m_currentTemp;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600006A RID: 106 RVA: 0x00003AA5 File Offset: 0x00001CA5
		public ModificableDeFloat fiebreWeightModificable
		{
			get
			{
				return this.m_fiebreWeightModificable;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003AAD File Offset: 0x00001CAD
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.Generate();
			this.m_defaultTemp = this.m_currentTemp;
			this.m_coroutineUpdate = new CoroutineCapsule(this.UpdateRutine(), this, new CoroutineCapsuleConfig
			{
				autoRestart = true,
				autoStart = true
			});
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003AEC File Offset: 0x00001CEC
		private void Generate()
		{
			this.m_currentTemp = Random.Range(36.5f, 37.5f);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x00003B03 File Offset: 0x00001D03
		private IEnumerator UpdateRutine()
		{
			new WaitForSeconds(1f.Random(0.1f));
			for (;;)
			{
				yield return null;
				float num = this.m_fiebreWeightModificable.AdicinarValorIncluyendo(this.m_fiebreW);
				this.m_currentTemp = Mathf.Lerp(this.m_defaultTemp, 39.45f, num);
			}
			yield break;
		}

		// Token: 0x0400005A RID: 90
		public const float min = 36.5f;

		// Token: 0x0400005B RID: 91
		public const float max = 37.5f;

		// Token: 0x0400005C RID: 92
		public const float maxTemp = 39.45f;

		// Token: 0x0400005D RID: 93
		[SerializeField]
		[ReadOnlyUI]
		private float m_currentTemp;

		// Token: 0x0400005E RID: 94
		[SerializeField]
		[ReadOnlyUI]
		private float m_defaultTemp;

		// Token: 0x0400005F RID: 95
		[SerializeField]
		private float m_fiebreW;

		// Token: 0x04000060 RID: 96
		[SerializeField]
		private ModificableDeFloat m_fiebreWeightModificable = new ModificableDeFloat(0f);

		// Token: 0x04000061 RID: 97
		private CoroutineCapsule m_coroutineUpdate;
	}
}
