using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Interactables.Penetradores
{
	// Token: 0x02000187 RID: 391
	[RequireComponent(typeof(InteraccionRootRecorridoLinear))]
	public class RecorridoLinearDePenetrador : RecorridoLinearDePenetradorBase
	{
		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000932 RID: 2354 RVA: 0x00029409 File Offset: 0x00027609
		public override Penetrador penetrador
		{
			get
			{
				return this.m_Penis;
			}
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x00029411 File Offset: 0x00027611
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetYieldStart();
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x0002941F File Offset: 0x0002761F
		protected override IEnumerator YieldStartUnityEvent()
		{
			this.m_Penis = null;
			while (this.m_Penis == null)
			{
				yield return null;
				this.m_Penis = this.GetComponentEnRoot(false);
			}
			this.m_PuntosGuiasRecorridoLinear.puntos = this.m_Penis.partesEnOrden.Select((PenisPart p) => p.physicBone.transform).ToList<Transform>();
			this.m_PuntosGuiasRecorridoLinear.puntos.Add(this.m_Penis.tipPhysics);
			yield break;
		}

		// Token: 0x04000725 RID: 1829
		[ReadOnlyUI]
		[SerializeField]
		protected Penis m_Penis;
	}
}
