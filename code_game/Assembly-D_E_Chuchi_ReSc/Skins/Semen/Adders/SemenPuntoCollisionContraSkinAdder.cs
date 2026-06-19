using System;
using System.Collections;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Runtime.Semens;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Skins.Semen.Adders
{
	// Token: 0x0200008D RID: 141
	[RequireComponent(typeof(SemenChain))]
	public sealed class SemenPuntoCollisionContraSkinAdder : BehaviourAdder
	{
		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06000374 RID: 884 RVA: 0x0000D6FC File Offset: 0x0000B8FC
		public sealed override object addedResult
		{
			get
			{
				return this.m_added;
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06000375 RID: 885 RVA: 0x0000D704 File Offset: 0x0000B904
		protected override BehaviourAdder.AddType addType
		{
			get
			{
				return BehaviourAdder.AddType.custom;
			}
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000D707 File Offset: 0x0000B907
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_SemenChain = base.GetComponent<SemenChain>();
			this.m_SemenChain.stared += this.M_SemenChain_stared;
		}

		// Token: 0x06000377 RID: 887 RVA: 0x0000D732 File Offset: 0x0000B932
		private void M_SemenChain_stared(object sender)
		{
			base.OnAddBehaviour();
		}

		// Token: 0x06000378 RID: 888 RVA: 0x0000D73C File Offset: 0x0000B93C
		protected override void AddBehaviour()
		{
			this.m_added = new List<SemenPuntoCollisionContraSkin>();
			for (int i = 0; i < this.m_SemenChain.semenPuntos.Count; i++)
			{
				SemenPuntoCollisionContraSkin componentNotNull = this.m_SemenChain.semenPuntos[i].GetComponentNotNull<SemenPuntoCollisionContraSkin>();
				this.m_added.Add(componentNotNull);
				if (this.addImpulse)
				{
					base.StartCoroutine(this.WaitToAddForceRutine(componentNotNull.semenPunto));
				}
			}
		}

		// Token: 0x06000379 RID: 889 RVA: 0x0000D7AD File Offset: 0x0000B9AD
		private IEnumerator WaitToAddForceRutine(SemenPunto punto)
		{
			while (!punto.isInitiated)
			{
				yield return null;
			}
			punto.body.AddRelativeForce(this.impulse, ForceMode.Impulse);
			yield break;
		}

		// Token: 0x04000270 RID: 624
		private List<SemenPuntoCollisionContraSkin> m_added;

		// Token: 0x04000271 RID: 625
		private SemenChain m_SemenChain;

		// Token: 0x04000272 RID: 626
		public bool addImpulse;

		// Token: 0x04000273 RID: 627
		public Vector3 impulse;
	}
}
