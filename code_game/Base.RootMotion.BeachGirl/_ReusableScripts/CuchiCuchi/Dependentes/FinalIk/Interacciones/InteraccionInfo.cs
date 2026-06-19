using System;
using System.Collections.Generic;
using System.Linq;
using RootMotion.FinalIK;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.Interacciones
{
	// Token: 0x0200009E RID: 158
	[Serializable]
	public class InteraccionInfo
	{
		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000629 RID: 1577 RVA: 0x0001DFBA File Offset: 0x0001C1BA
		public IReadOnlyList<InteraccionEffectorParInfo> effectorsInteractions
		{
			get
			{
				return this.interaccionEffectors;
			}
		}

		// Token: 0x17000181 RID: 385
		// (get) Token: 0x0600062A RID: 1578 RVA: 0x0001DFC2 File Offset: 0x0001C1C2
		public IReadOnlyDictionary<int, InteraccionEffectorParInfo> effectorsInteractionsDictionary
		{
			get
			{
				return this.m_interaccionEffectorsSet;
			}
		}

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x0600062B RID: 1579 RVA: 0x0001DFCC File Offset: 0x0001C1CC
		public bool isValid
		{
			get
			{
				if (this.interaccionEffectors.Count == 0)
				{
					return false;
				}
				for (int i = 0; i < this.interaccionEffectors.Count; i++)
				{
					InteraccionEffectorParInfo interaccionEffectorParInfo = this.interaccionEffectors[i];
					if (interaccionEffectorParInfo.activado)
					{
						if (interaccionEffectorParInfo == null)
						{
							return false;
						}
						if (!interaccionEffectorParInfo.isValid)
						{
							return false;
						}
					}
				}
				return true;
			}
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x0001E023 File Offset: 0x0001C223
		public void Init()
		{
			this.m_interaccionEffectorsSet = this.interaccionEffectors.ToDictionary((InteraccionEffectorParInfo i) => (int)i.fullBodyBipedEffector);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0001E058 File Offset: 0x0001C258
		public float ObtenerDuracion()
		{
			float num = 0f;
			for (int i = 0; i < this.interaccionEffectors.Count; i++)
			{
				InteraccionEffectorParInfo interaccionEffectorParInfo = this.interaccionEffectors[i];
				if (interaccionEffectorParInfo.activado && interaccionEffectorParInfo.isValid && interaccionEffectorParInfo.interactionObject.length > num)
				{
					num = interaccionEffectorParInfo.interactionObject.length;
				}
			}
			return num;
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0001E0BC File Offset: 0x0001C2BC
		public InteraccionEffectorParInfo BuscarParaEffector(FullBodyBipedEffector effector)
		{
			for (int i = 0; i < this.interaccionEffectors.Count; i++)
			{
				if (this.interaccionEffectors[i].fullBodyBipedEffector == effector)
				{
					return this.interaccionEffectors[i];
				}
			}
			return null;
		}

		// Token: 0x04000446 RID: 1094
		private Dictionary<int, InteraccionEffectorParInfo> m_interaccionEffectorsSet;

		// Token: 0x04000447 RID: 1095
		[Header("No compatible con modificacion de items en runtime")]
		[SerializeField]
		[CoolArrayItem]
		private List<InteraccionEffectorParInfo> interaccionEffectors = new List<InteraccionEffectorParInfo>();
	}
}
