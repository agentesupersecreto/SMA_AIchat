using System;
using System.Collections.Generic;
using System.Linq;
using Assets._ReusableScripts.Sonidos;
using Assets._ReusableScripts.Sonidos.Adders;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Puppet.Adders.Sonidos
{
	// Token: 0x02000137 RID: 311
	public abstract class SonidoProductorToConvexColliderAdderBase<TProductor> : SonidoBehaviourAdder<TProductor> where TProductor : SonidoProductor
	{
		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000631 RID: 1585 RVA: 0x00023031 File Offset: 0x00021231
		public sealed override object addedResult
		{
			get
			{
				return this.m_added;
			}
		}

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000632 RID: 1586 RVA: 0x00014CB2 File Offset: 0x00012EB2
		protected override BehaviourAdder.AddType addType
		{
			get
			{
				return BehaviourAdder.AddType.custom;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000633 RID: 1587 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int updateEvent1Index
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x0002303C File Offset: 0x0002123C
		public override void OnUpdateEvent1()
		{
			if (this.m_currentTryingTime == null)
			{
				this.m_currentTryingTime = new float?(0f);
			}
			this.TryAdd();
			this.m_currentTryingTime += Time.deltaTime;
			float? currentTryingTime = this.m_currentTryingTime;
			float num = this.tryingTime;
			if ((currentTryingTime.GetValueOrDefault() >= num) & (currentTryingTime != null))
			{
				Debug.LogWarning("no se pudo añadir " + typeof(TProductor).Name + ", a to convex colliders");
				base.enabled = false;
			}
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x000230F0 File Offset: 0x000212F0
		private void TryAdd()
		{
			this.GetComponentsEnRoot(false, this.m_toConvex);
			if (this.m_toConvex == null || this.m_toConvex.Count == 0)
			{
				return;
			}
			this.m_added = new List<TProductor>();
			for (int i = 0; i < this.m_toConvex.Count; i++)
			{
				PuppetColliderToConvexV2 m = this.m_toConvex[i];
				TProductor componentNotNull = m.dynamic.GetComponentNotNull<TProductor>();
				base.SetConfig(componentNotNull);
				MuscleTexturaPar muscleTexturaPar = this.texturaOverrides.FirstOrDefault((MuscleTexturaPar par) => par.muscle == m.muscle.props.group);
				MuscleFormaPar muscleFormaPar = this.formaOverrides.FirstOrDefault((MuscleFormaPar par) => par.muscle == m.muscle.props.group);
				if (muscleTexturaPar != null)
				{
					componentNotNull.textura = muscleTexturaPar.textura;
				}
				if (muscleFormaPar != null)
				{
					componentNotNull.forma = muscleFormaPar.forma;
				}
				this.m_added.Add(componentNotNull);
				this.OnSonidoProductorAdded(componentNotNull);
			}
			base.OnAddBehaviour();
		}

		// Token: 0x06000636 RID: 1590
		protected abstract void OnSonidoProductorAdded(TProductor added);

		// Token: 0x06000637 RID: 1591 RVA: 0x00002BEA File Offset: 0x00000DEA
		protected override void AddBehaviour()
		{
		}

		// Token: 0x0400050B RID: 1291
		private List<TProductor> m_added;

		// Token: 0x0400050C RID: 1292
		public float tryingTime = 5f;

		// Token: 0x0400050D RID: 1293
		private float? m_currentTryingTime;

		// Token: 0x0400050E RID: 1294
		public List<MuscleTexturaPar> texturaOverrides = new List<MuscleTexturaPar>();

		// Token: 0x0400050F RID: 1295
		public List<MuscleFormaPar> formaOverrides = new List<MuscleFormaPar>();

		// Token: 0x04000510 RID: 1296
		private List<PuppetColliderToConvexV2> m_toConvex = new List<PuppetColliderToConvexV2>();
	}
}
