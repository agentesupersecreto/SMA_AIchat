using System;
using Assets._ReusableScripts.CuchiCuchi.Holes;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chains.Controllers
{
	// Token: 0x02000297 RID: 663
	public abstract class Linear7BoneChainController : AplicableBehaviour
	{
		// Token: 0x17000323 RID: 803
		// (get) Token: 0x06000E88 RID: 3720
		public abstract Linear7BoneChainBase chain { get; }

		// Token: 0x17000324 RID: 804
		// (get) Token: 0x06000E89 RID: 3721
		public abstract ChainPointsDataCollector collector { get; }

		// Token: 0x17000325 RID: 805
		// (get) Token: 0x06000E8A RID: 3722 RVA: 0x00005F51 File Offset: 0x00004151
		protected virtual GlobalUpdater.UpdateType updateEvent
		{
			get
			{
				return GlobalUpdater.UpdateType.update2;
			}
		}

		// Token: 0x17000326 RID: 806
		// (get) Token: 0x06000E8B RID: 3723 RVA: 0x00044945 File Offset: 0x00042B45
		public sealed override int updateEvent1Index
		{
			get
			{
				return (int)this.updateEvent;
			}
		}

		// Token: 0x17000327 RID: 807
		// (get) Token: 0x06000E8C RID: 3724
		public abstract HolePointsDataCollector holeCollector { get; }

		// Token: 0x17000328 RID: 808
		// (get) Token: 0x06000E8D RID: 3725
		protected abstract MapaDeDesgasteDeLinear7Chain mapaDeDesgasteSmall { get; }

		// Token: 0x17000329 RID: 809
		// (get) Token: 0x06000E8E RID: 3726
		protected abstract MapaDeDesgasteDeLinear7Chain mapaDeDesgasteBig { get; }

		// Token: 0x1700032A RID: 810
		// (get) Token: 0x06000E8F RID: 3727
		protected abstract float anchuraNormalMinima { get; }

		// Token: 0x1700032B RID: 811
		// (get) Token: 0x06000E90 RID: 3728
		protected abstract float anchuraNormalMaxima { get; }

		// Token: 0x1700032C RID: 812
		// (get) Token: 0x06000E91 RID: 3729 RVA: 0x0004494D File Offset: 0x00042B4D
		// (set) Token: 0x06000E92 RID: 3730 RVA: 0x00044955 File Offset: 0x00042B55
		public PorcentageModificable desgasteVisual
		{
			get
			{
				return this.m_desgasteVisual;
			}
			set
			{
				this.m_desgasteVisual = value;
			}
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06000E93 RID: 3731 RVA: 0x00030684 File Offset: 0x0002E884
		protected virtual float defaultApertureMod
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x1700032E RID: 814
		// (get) Token: 0x06000E94 RID: 3732 RVA: 0x00030684 File Offset: 0x0002E884
		protected virtual float intervaloDeAplicacionDeApertureMod
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x1700032F RID: 815
		// (get) Token: 0x06000E95 RID: 3733 RVA: 0x0004495E File Offset: 0x00042B5E
		protected virtual float maxApertureMod
		{
			get
			{
				return 0.01f;
			}
		}

		// Token: 0x06000E96 RID: 3734 RVA: 0x00013EE0 File Offset: 0x000120E0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x06000E97 RID: 3735 RVA: 0x00044968 File Offset: 0x00042B68
		public override void OnUpdateEvent1()
		{
			if (this.m_firstFix)
			{
				if (this.chain != null)
				{
					foreach (ChainPointStretcherJoint chainPointStretcherJoint in this.chain.puntosBase)
					{
						JointDistancesAdmin.Configuracion configuracion = chainPointStretcherJoint.jointDistancesAdmin.configuracion;
						configuracion.finalDistanceLimitMod = (configuracion.finalTagetPoistionMod = this.defaultApertureMod);
						chainPointStretcherJoint.jointDistancesAdmin.UpdateDistaceAndTargetMods();
					}
				}
				this.chain.estadoDePuntos.posicionesLocalesIniciales.Actializar();
				this.m_firstFix = false;
				return;
			}
			this.UpdateDesgaste(false);
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x00044A18 File Offset: 0x00042C18
		public virtual void ResetDesgaste()
		{
			this.desgasteVisual = (this.m_lastDesgaste = default(PorcentageModificable));
		}

		// Token: 0x06000E99 RID: 3737 RVA: 0x00044A40 File Offset: 0x00042C40
		public virtual void UpdateDesgaste(bool force = false)
		{
			if (force || !ExtendedMonoBehaviour.AlmostEqual(this.desgasteVisual.total, this.m_lastDesgaste.total, 0.01f))
			{
				this.updateDesgaste();
			}
		}

		// Token: 0x06000E9A RID: 3738 RVA: 0x00044A7C File Offset: 0x00042C7C
		protected virtual void updateDesgaste()
		{
			if (this.chain == null)
			{
				return;
			}
			try
			{
				float num = Mathf.Lerp(this.defaultApertureMod, this.maxApertureMod, this.desgasteVisual.mod);
				float num2 = 0f;
				bool flag = num < this.intervaloDeAplicacionDeApertureMod && this.mapaDeDesgasteBig != null && this.mapaDeDesgasteSmall != null && this.holeCollector != null;
				if (flag)
				{
					num2 = Mathf.InverseLerp(this.anchuraNormalMinima, this.anchuraNormalMaxima, this.holeCollector.anchuraPromedioAumentante);
				}
				for (int i = 0; i < this.chain.puntosBase.Count; i++)
				{
					JointDistancesAdmin jointDistancesAdmin = this.chain.puntosBase[i].jointDistancesAdmin;
					JointDistancesAdmin.Configuracion configuracion = jointDistancesAdmin.configuracion;
					configuracion.finalTagetPoistionMod = num;
					if (flag)
					{
						float num3 = this.mapaDeDesgasteBig.modificadores.mods[i];
						float num4 = this.mapaDeDesgasteSmall.modificadores.mods[i];
						configuracion.finalTagetPoistionMod = Mathf.Lerp(this.intervaloDeAplicacionDeApertureMod, configuracion.finalTagetPoistionMod, Mathf.Lerp(num4, num3, num2));
					}
					jointDistancesAdmin.UpdateDistaceAndTargetMods();
				}
				this.chain.estadoDePuntos.posicionesLocalesIniciales.Actializar();
			}
			finally
			{
				this.m_lastDesgaste = this.desgasteVisual;
			}
		}

		// Token: 0x06000E9B RID: 3739 RVA: 0x00044C00 File Offset: 0x00042E00
		protected override void OnAplicar()
		{
			base.OnAplicar();
			this.UpdateDesgaste(false);
		}

		// Token: 0x04000C8F RID: 3215
		[SerializeField]
		private PorcentageModificable m_desgasteVisual;

		// Token: 0x04000C90 RID: 3216
		private PorcentageModificable m_lastDesgaste;

		// Token: 0x04000C91 RID: 3217
		private bool m_firstFix = true;
	}
}
