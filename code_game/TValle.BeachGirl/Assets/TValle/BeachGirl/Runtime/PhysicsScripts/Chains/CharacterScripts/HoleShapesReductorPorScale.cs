using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Base.BeachGirl.Controladores.Materiales.Runtime.Shapes;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.PhysicsScripts.Chains.CharacterScripts
{
	// Token: 0x0200007B RID: 123
	public abstract class HoleShapesReductorPorScale : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x17000161 RID: 353
		// (get) Token: 0x0600032E RID: 814 RVA: 0x00009BB9 File Offset: 0x00007DB9
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.afterFixedUpdates1);
			}
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00009BC2 File Offset: 0x00007DC2
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_hole = base.GetComponent<Circular8BoneChain>();
			this.m_holeShapesController = this.GetComponentEnRoot(false);
			base.SetYieldStart();
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00009BE9 File Offset: 0x00007DE9
		protected override IEnumerator YieldStartUnityEvent()
		{
			while (!this.m_hole.isStared)
			{
				yield return null;
			}
			while (!this.m_holeShapesController.isStared)
			{
				yield return null;
			}
			IReadOnlyList<string> holeShapeNames = this.GetHoleShapeNames();
			this.m_mods = holeShapeNames.Select((string n) => this.m_holeShapesController.GetModificablesDeShape(n).modificable.ObtenerModificadorNotNull(this)).ToArray<ModificadorDeFloat>();
			yield break;
		}

		// Token: 0x06000331 RID: 817
		protected abstract IReadOnlyList<string> GetHoleShapeNames();

		// Token: 0x06000332 RID: 818 RVA: 0x00009BF8 File Offset: 0x00007DF8
		public override void OnUpdateEvent1()
		{
			float num = Mathf.Clamp(this.m_hole.estadoDePuntos.actualLocal.minLocalHole - 0.01f, 1E-05f, float.MaxValue);
			this.m_lastMod = Mathf.Clamp(0.01f / (num * 4f), 1E-06f, 1f);
			for (int i = 0; i < this.m_mods.Length; i++)
			{
				this.m_mods[i].valor.valor = this.m_lastMod;
			}
		}

		// Token: 0x040001E8 RID: 488
		private Circular8BoneChain m_hole;

		// Token: 0x040001E9 RID: 489
		protected ControlladorDeShapeDeVagAndAnusHoles m_holeShapesController;

		// Token: 0x040001EA RID: 490
		[SerializeField]
		private float m_lastMod;

		// Token: 0x040001EB RID: 491
		[SerializeField]
		private ModificadorDeFloat[] m_mods;
	}
}
