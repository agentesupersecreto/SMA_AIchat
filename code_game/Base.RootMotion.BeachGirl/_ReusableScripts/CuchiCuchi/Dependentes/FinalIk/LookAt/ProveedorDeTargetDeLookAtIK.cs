using System;
using Assets.FinalIk;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.FinalIk.LookAt
{
	// Token: 0x02000093 RID: 147
	[RequireComponent(typeof(LookAtIKTargets))]
	public sealed class ProveedorDeTargetDeLookAtIK : CustomMonobehaviour, LookAtIK_TargetTransformer.IProveedorDeTarget, ILookAtHeadTargets
	{
		// Token: 0x17000163 RID: 355
		// (get) Token: 0x060005EF RID: 1519 RVA: 0x0001D759 File Offset: 0x0001B959
		public LookAtTargetWieghtParCollection primariosCollection
		{
			get
			{
				return this.m_targets.primariosCollection;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x0001D766 File Offset: 0x0001B966
		public LookAtTargetWieghtParCollection segundariosCollection
		{
			get
			{
				return this.m_targets.segundariosCollection;
			}
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060005F1 RID: 1521 RVA: 0x0001D773 File Offset: 0x0001B973
		public LookAtIKTargets.Targets primarios
		{
			get
			{
				return this.m_targets.primarios;
			}
		}

		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x0001D780 File Offset: 0x0001B980
		public LookAtIKTargets.Targets segundarios
		{
			get
			{
				return this.m_targets.segundarios;
			}
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x0001D78D File Offset: 0x0001B98D
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_targets = base.GetComponent<LookAtIKTargets>();
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x0001D7A4 File Offset: 0x0001B9A4
		public bool TryObtener(LookAtTargetWieghtParCollection.EvaluadorDeRango evaluadorEnRango, Vector3 bodyForward, Vector3 posicionGlobalOrigen, float minDistance, out Vector3 targetPosition, out float velocityMod, out float w)
		{
			return LookAtTargetWieghtParCollection.CalcularCurrentTargetConPrioridad(this.primariosCollection, this.segundariosCollection, evaluadorEnRango, bodyForward, posicionGlobalOrigen, out targetPosition, out w, out velocityMod, minDistance);
		}

		// Token: 0x04000416 RID: 1046
		private LookAtIKTargets m_targets;
	}
}
