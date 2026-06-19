using System;
using Assets.TValle.BeachGirl;
using Assets._ReusableScripts.CuchiCuchi.PhysicsAndBonesScripts;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.PhysicsScripts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Holes.Controlladores
{
	// Token: 0x020001C2 RID: 450
	public abstract class HoleController : AplicableBehaviour
	{
		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000A9B RID: 2715 RVA: 0x00030647 File Offset: 0x0002E847
		public ModificableDeFloat modificableDeDamperOnWeigth
		{
			get
			{
				return this.m_modificableDeDamperOnWeigth;
			}
		}

		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000A9C RID: 2716 RVA: 0x0003064F File Offset: 0x0002E84F
		public ModificableDeFloat modificableDePenetracionDamper
		{
			get
			{
				return this.m_modificableDePenetracionDamper;
			}
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000A9D RID: 2717 RVA: 0x00030657 File Offset: 0x0002E857
		public ModificableDeFloat modificableDeHardPointsDesgastePorSegundo
		{
			get
			{
				return this.m_modificableDeHardPointsDesgastePorSegundo;
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000A9E RID: 2718 RVA: 0x0003065F File Offset: 0x0002E85F
		public ModificableDeFloat timeTryingToOpenHoleModificable
		{
			get
			{
				return this.m_timeTryingToOpenHoleModificable;
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000A9F RID: 2719 RVA: 0x00030667 File Offset: 0x0002E867
		[Obsolete("", true)]
		public ModificableDeFloat desgasteToBreakHoleModificable
		{
			get
			{
				return this.m_desgasteToBreakHoleModificable;
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000AA0 RID: 2720
		public abstract HolePointsDataCollector collector { get; }

		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000AA1 RID: 2721
		public abstract BoneStretchedChain hole { get; }

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000AA2 RID: 2722 RVA: 0x00005F51 File Offset: 0x00004151
		protected virtual GlobalUpdater.UpdateType updateEvent
		{
			get
			{
				return GlobalUpdater.UpdateType.update2;
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000AA3 RID: 2723 RVA: 0x0003066F File Offset: 0x0002E86F
		public sealed override int updateEvent1Index
		{
			get
			{
				return (int)this.updateEvent;
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000AA4 RID: 2724 RVA: 0x00030677 File Offset: 0x0002E877
		protected float defaultApertureMod
		{
			get
			{
				return this.config.defaultApertureMod;
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000AA5 RID: 2725 RVA: 0x00030684 File Offset: 0x0002E884
		protected virtual float intervaloDeAplicacionDeApertureMod
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000AA6 RID: 2726 RVA: 0x0003068B File Offset: 0x0002E88B
		protected float maxApertureMod
		{
			get
			{
				return this.config.maxApertureMod;
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000AA7 RID: 2727 RVA: 0x00030698 File Offset: 0x0002E898
		protected float timeTryingToOpenHole
		{
			get
			{
				return this.config.timeTryingToOpenHole;
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000AA8 RID: 2728 RVA: 0x000306A5 File Offset: 0x0002E8A5
		public bool penisIsTryingPenetrate
		{
			get
			{
				return this.m_TimeToOpen.trying;
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000AA9 RID: 2729
		protected abstract MapaDeDesgasteDeHole mapaDeDesgasteSmall { get; }

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000AAA RID: 2730
		protected abstract MapaDeDesgasteDeHole mapaDeDesgasteBig { get; }

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000AAB RID: 2731
		protected abstract float anchuraNormalMinima { get; }

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000AAC RID: 2732
		protected abstract float anchuraNormalMaxima { get; }

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000AAD RID: 2733 RVA: 0x000306B2 File Offset: 0x0002E8B2
		public bool cerradoOBlockeado
		{
			get
			{
				return this.m_cerrado;
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x06000AAE RID: 2734
		public abstract bool blockeado { get; }

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x06000AAF RID: 2735 RVA: 0x000306BA File Offset: 0x0002E8BA
		public Character character
		{
			get
			{
				return this.m_character;
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x06000AB0 RID: 2736 RVA: 0x000306C2 File Offset: 0x0002E8C2
		[Obsolete("", true)]
		public PorcentageModificable desgasteVisual
		{
			get
			{
				return this.m_desgasteVisual;
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06000AB1 RID: 2737 RVA: 0x000306CA File Offset: 0x0002E8CA
		[Obsolete("", true)]
		public PorcentageModificable desgasteAI
		{
			get
			{
				return this.m_desgasteAI;
			}
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x000306D4 File Offset: 0x0002E8D4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_character = base.GetComponentInParent<Character>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.hole.beforeStartPoints += this.Hole_beforeStartPoints;
			this.hole.stared += this.Hole_stared;
		}

		// Token: 0x06000AB3 RID: 2739 RVA: 0x00030740 File Offset: 0x0002E940
		private void Hole_stared(object obj)
		{
			this.m_ownModificadorPorDesgasteDePenetracionDamper = this.m_modificableDePenetracionDamper.ObtenerModificadorNotNull(this);
			this.m_TimeToOpen.Init(this);
			this.m_PenetrationJointCreator = this.hole.GetComponent<PenetrationJointCreator>();
			this.m_LastZDamperPenetrationJointMod = new float?(this.m_PenetrationJointCreator.zDamperMod);
		}

		// Token: 0x06000AB4 RID: 2740 RVA: 0x00030792 File Offset: 0x0002E992
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			HoleController.TimeToOpenCalcule timeToOpen = this.m_TimeToOpen;
			if (timeToOpen != null)
			{
				timeToOpen.Destroy();
			}
			ModificadorDeFloat ownModificadorPorDesgasteDePenetracionDamper = this.m_ownModificadorPorDesgasteDePenetracionDamper;
			if (ownModificadorPorDesgasteDePenetracionDamper == null)
			{
				return;
			}
			ownModificadorPorDesgasteDePenetracionDamper.TryRemoverDeOwner(true);
		}

		// Token: 0x06000AB5 RID: 2741 RVA: 0x000307BE File Offset: 0x0002E9BE
		public void ChangeMotionDesgasteWeigth(float visual, float AI)
		{
			this.motionDesgaste.desgasteVisual = new PorcentageModificable(visual * 100f);
			this.motionDesgaste.desgasteAI = new PorcentageModificable(AI * 100f);
		}

		// Token: 0x06000AB6 RID: 2742 RVA: 0x000307EE File Offset: 0x0002E9EE
		public void ChangeProfundidadDesgasteWeigth(float visual, float AI)
		{
			this.profundidadDesgaste.desgasteVisual = new PorcentageModificable(visual * 100f);
			this.profundidadDesgaste.desgasteAI = new PorcentageModificable(AI * 100f);
		}

		// Token: 0x06000AB7 RID: 2743 RVA: 0x0003081E File Offset: 0x0002EA1E
		public void ChangeAnchuraDesgasteWeigth(float visual, float AI)
		{
			this.anchuraDesgaste.desgasteVisual = new PorcentageModificable(visual * 100f);
			this.anchuraDesgaste.desgasteAI = new PorcentageModificable(AI * 100f);
		}

		// Token: 0x06000AB8 RID: 2744 RVA: 0x00030850 File Offset: 0x0002EA50
		public virtual void ResetDesgaste()
		{
			this.motionDesgaste.lastDesgaste = 0f;
			this.profundidadDesgaste.lastDesgaste = 0f;
			this.anchuraDesgaste.lastDesgaste = 0f;
			this.motionDesgaste.desgasteAI = (this.motionDesgaste.desgasteVisual = default(PorcentageModificable));
			this.profundidadDesgaste.desgasteAI = (this.profundidadDesgaste.desgasteVisual = default(PorcentageModificable));
			this.anchuraDesgaste.desgasteAI = (this.anchuraDesgaste.desgasteVisual = default(PorcentageModificable));
		}

		// Token: 0x06000AB9 RID: 2745 RVA: 0x000308F3 File Offset: 0x0002EAF3
		public virtual void UpdateMotionDesgaste(bool force = false)
		{
			if (force || !ExtendedMonoBehaviour.AlmostEqual(this.motionDesgaste.desgasteVisual.total, this.motionDesgaste.lastDesgaste, 0.01f))
			{
				this.updateMotionDesgaste();
			}
		}

		// Token: 0x06000ABA RID: 2746 RVA: 0x00030925 File Offset: 0x0002EB25
		public virtual void UpdateProfundidadDesgaste(bool force = false)
		{
			if (force || !ExtendedMonoBehaviour.AlmostEqual(this.profundidadDesgaste.desgasteVisual.total, this.profundidadDesgaste.lastDesgaste, 0.01f))
			{
				this.updateProfundidadDesgaste();
			}
		}

		// Token: 0x06000ABB RID: 2747 RVA: 0x00030957 File Offset: 0x0002EB57
		public virtual void UpdateAnchuraDesgaste(bool force = false)
		{
			if (force || !ExtendedMonoBehaviour.AlmostEqual(this.anchuraDesgaste.desgasteVisual.total, this.anchuraDesgaste.lastDesgaste, 0.01f))
			{
				this.updateAnchuraDesgaste();
			}
		}

		// Token: 0x06000ABC RID: 2748 RVA: 0x00030989 File Offset: 0x0002EB89
		protected virtual void updateMotionDesgaste()
		{
			this.motionDesgaste.lastDesgaste = this.motionDesgaste.desgasteVisual.total;
		}

		// Token: 0x06000ABD RID: 2749 RVA: 0x000309A6 File Offset: 0x0002EBA6
		protected virtual void updateProfundidadDesgaste()
		{
			this.profundidadDesgaste.lastDesgaste = this.profundidadDesgaste.desgasteVisual.total;
		}

		// Token: 0x06000ABE RID: 2750 RVA: 0x000309C4 File Offset: 0x0002EBC4
		protected virtual void updateAnchuraDesgaste()
		{
			try
			{
				float num = Mathf.Lerp(this.defaultApertureMod, this.maxApertureMod, this.anchuraDesgaste.desgasteVisual.mod);
				bool flag = num < this.intervaloDeAplicacionDeApertureMod && this.mapaDeDesgasteSmall != null && this.mapaDeDesgasteBig != null;
				float num2 = 0f;
				if (flag)
				{
					num2 = Mathf.InverseLerp(this.anchuraNormalMinima, this.anchuraNormalMaxima, this.collector.anchuraPromedioAumentante);
				}
				foreach (CircularChainPointStretcherJoint circularChainPointStretcherJoint in this.hole.points)
				{
					JointDistancesAdmin jointDistancesAdmin = circularChainPointStretcherJoint.jointDistancesAdmin;
					JointDistancesAdmin.Configuracion configuracion = jointDistancesAdmin.configuracion;
					configuracion.finalTagetPoistionMod = num;
					if (flag)
					{
						MapaDeDesgasteDeHole.PointMod pointMod = HoleController.ObtenerMod(circularChainPointStretcherJoint.puntoID, this.mapaDeDesgasteSmall);
						MapaDeDesgasteDeHole.PointMod pointMod2 = HoleController.ObtenerMod(circularChainPointStretcherJoint.puntoID, this.mapaDeDesgasteBig);
						float num3 = Mathf.Lerp(pointMod.value, pointMod2.value, num2);
						configuracion.finalTagetPoistionMod = Mathf.Lerp(this.intervaloDeAplicacionDeApertureMod, configuracion.finalTagetPoistionMod, num3);
					}
					jointDistancesAdmin.UpdateDistaceAndTargetMods();
				}
				this.hole.estadoDePuntos.iniciales.ActualizarApeturaInicial();
			}
			finally
			{
				this.anchuraDesgaste.lastDesgaste = this.anchuraDesgaste.desgasteVisual.total;
			}
		}

		// Token: 0x06000ABF RID: 2751 RVA: 0x00030B54 File Offset: 0x0002ED54
		private void Hole_beforeStartPoints(BoneStretchedChain obj)
		{
			foreach (CircularChainPointStretcherJoint circularChainPointStretcherJoint in obj.points)
			{
				circularChainPointStretcherJoint.afterGenerateConfig += this.Item_afterGenerateConfig;
			}
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x00030BAC File Offset: 0x0002EDAC
		private void Item_afterGenerateConfig(ChainPointStretcherJoint obj)
		{
			JointDistancesAdmin.Configuracion configuracion = obj.jointDistancesAdmin.configuracion;
			configuracion.finalDistanceLimitMod = (configuracion.finalTagetPoistionMod = this.defaultApertureMod);
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x00030BD8 File Offset: 0x0002EDD8
		public override void OnUpdateEvent1()
		{
			bool isPenetrated = this.hole.isPenetrated;
			this.UpdateMotionDesgaste(false);
			this.UpdateProfundidadDesgaste(false);
			this.UpdateAnchuraDesgaste(false);
			this.m_ownModificadorPorDesgasteDePenetracionDamper.valor.valor = 0f;
			float num;
			float num2;
			float num3;
			this.GetDamperOnOnWeigthValues(out num, out num2, out num3);
			this.UpdateModDeDamperPorMotion(num, num2, num3, isPenetrated ? 0.6666f : 1f);
			this.UpdateModDeDamperPorProfundidad(num, num2, num3, isPenetrated ? 0f : 1f);
			this.UpdateModDeDamperPorAnchura(num, num2, num3, isPenetrated ? 0f : 1f);
			this.UpdateHarPoints();
			this.UpdateCerradoState();
			this.UpdatePenetrationZDamper(false);
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x00030C84 File Offset: 0x0002EE84
		[Obsolete("", true)]
		private void UpdateModDeDamperPorDesgaste()
		{
			if (this.config.changeDamperMod)
			{
				float num = this.m_desgasteToBreakHoleModificable.ModificarValor(this.config.desgasteProcentajeToBreakHole);
				float num2 = MathfExtension.InverseLerpConMedio(0f, num * 0.666f, num, this.m_desgasteAI.total);
				float num3 = MathfExtension.LerpConMedio(this.config.maxDamperModPorDesgaste, this.config.defaultDamperMod, this.config.minDamperModPorDesgaste, num2);
				this.m_ownModificadorPorDesgasteDePenetracionDamper.valor.valor = num3;
				return;
			}
			this.m_ownModificadorPorDesgasteDePenetracionDamper.valor.valor = 1f;
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x00030D24 File Offset: 0x0002EF24
		private void UpdateModDeDamperPorMotion(float minDamperOnWeigth, float medDamperOnWeigth, float maxDamperOnWeigth, float wOverrideToDefault)
		{
			if (this.config.changeDamperMod)
			{
				float motionVirtualUnClampWeigth = this.hole.motionVirtualUnClampWeigth;
				float num = MathfExtension.InverseLerpConMedio(minDamperOnWeigth, medDamperOnWeigth, maxDamperOnWeigth, motionVirtualUnClampWeigth);
				num = num.InInOutOutPowInverted(2f, 2f, 0.5f);
				num = Mathf.Lerp(num, 0.5f, wOverrideToDefault);
				float num2 = MathfExtension.LerpConMedio(this.config.minDamperModPorDesgaste, this.config.defaultDamperMod, this.config.maxDamperModPorDesgaste, num);
				this.m_ownModificadorPorDesgasteDePenetracionDamper.valor.valor = Mathf.Max(this.m_ownModificadorPorDesgasteDePenetracionDamper.valor.valor, num2);
			}
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00030DCC File Offset: 0x0002EFCC
		private void UpdateModDeDamperPorProfundidad(float minDamperOnWeigth, float medDamperOnWeigth, float maxDamperOnWeigth, float wOverrideToDefault)
		{
			if (this.config.changeDamperMod)
			{
				float profundidadPhysicsUnClampWeigth = this.hole.profundidadPhysicsUnClampWeigth;
				float num = MathfExtension.InverseLerpConMedio(minDamperOnWeigth, medDamperOnWeigth, maxDamperOnWeigth, profundidadPhysicsUnClampWeigth);
				num = num.InInOutOutPowInverted(2f, 2f, 0.5f);
				num = Mathf.Lerp(num, 0.5f, wOverrideToDefault);
				float num2 = MathfExtension.LerpConMedio(this.config.minDamperModPorDesgaste, this.config.defaultDamperMod, this.config.maxDamperModPorDesgaste, num);
				this.m_ownModificadorPorDesgasteDePenetracionDamper.valor.valor = Mathf.Max(this.m_ownModificadorPorDesgasteDePenetracionDamper.valor.valor, num2);
			}
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x00030E74 File Offset: 0x0002F074
		private void UpdateModDeDamperPorAnchura(float minDamperOnWeigth, float medDamperOnWeigth, float maxDamperOnWeigth, float wOverrideToDefault)
		{
			if (this.config.changeDamperMod)
			{
				float anchuraVirtualUnClampWeigth = this.hole.anchuraVirtualUnClampWeigth;
				float num = MathfExtension.InverseLerpConMedio(minDamperOnWeigth, medDamperOnWeigth, maxDamperOnWeigth, anchuraVirtualUnClampWeigth);
				num = num.InInOutOutPowInverted(2f, 2f, 0.5f);
				num = Mathf.Lerp(num, 0.5f, wOverrideToDefault);
				float num2 = MathfExtension.LerpConMedio(this.config.minDamperModPorDesgaste, this.config.defaultDamperMod, this.config.maxDamperModPorDesgaste, num);
				this.m_ownModificadorPorDesgasteDePenetracionDamper.valor.valor = Mathf.Max(this.m_ownModificadorPorDesgasteDePenetracionDamper.valor.valor, num2);
			}
		}

		// Token: 0x06000AC6 RID: 2758 RVA: 0x00030F1C File Offset: 0x0002F11C
		public void UpdatePenetrationZDamper(bool force = false)
		{
			if (this.m_LastZDamperPenetrationJointMod == null || this.m_PenetrationJointCreator == null)
			{
				return;
			}
			if (this.overrideZDamperPenetrationJoint)
			{
				float num = this.m_modificableDePenetracionDamper.ModificarValor(this.modZDamperPenetrationJoint);
				if (force || this.m_LastZDamperPenetrationJointMod.Value != num)
				{
					this.m_PenetrationJointCreator.zDamperMod = num;
					this.m_LastZDamperPenetrationJointMod = new float?(num);
					return;
				}
			}
			else
			{
				this.m_PenetrationJointCreator.zDamperMod = this.config.defaultDamperMod;
				this.m_LastZDamperPenetrationJointMod = new float?(this.config.defaultDamperMod);
			}
		}

		// Token: 0x06000AC7 RID: 2759 RVA: 0x00030FB8 File Offset: 0x0002F1B8
		protected virtual void UpdateCerradoState()
		{
			if (this.m_cerrado && this.m_cerradoHastaV2 != null)
			{
				float time = Time.time;
				float? cerradoHastaV = this.m_cerradoHastaV2;
				if ((time >= cerradoHastaV.GetValueOrDefault()) & (cerradoHastaV != null))
				{
					this.m_cerradoHastaV2 = null;
					this.m_cerrado = false;
				}
			}
			this.hole.canBePenetrated = !this.m_cerrado && !this.blockeado;
			if (!this.hole.canBePenetrated && this.hole.isPenetrated)
			{
				this.hole.ExpulsarPenes();
			}
		}

		// Token: 0x06000AC8 RID: 2760 RVA: 0x00031053 File Offset: 0x0002F253
		public void Cerrar()
		{
			this.m_cerrado = true;
		}

		// Token: 0x06000AC9 RID: 2761 RVA: 0x0003105C File Offset: 0x0002F25C
		public void CerrarPor(float duration)
		{
			this.m_cerradoHastaV2 = new float?(Time.time + duration);
			this.m_cerrado = true;
		}

		// Token: 0x06000ACA RID: 2762 RVA: 0x00031077 File Offset: 0x0002F277
		public void Abrir()
		{
			this.m_cerradoHastaV2 = null;
			this.m_cerrado = false;
		}

		// Token: 0x06000ACB RID: 2763 RVA: 0x0003108C File Offset: 0x0002F28C
		public void GetDamperOnOnWeigthValues(out float minDamperOnWeigth, out float medDamperOnWeigth, out float maxDamperOnWeigth)
		{
			float num = this.m_modificableDeDamperOnWeigth.ModificarValor(1f);
			minDamperOnWeigth = this.config.minDamperOnWeigth * num;
			medDamperOnWeigth = this.config.medDamperOnWeigth * num;
			maxDamperOnWeigth = this.config.maxDamperOnWeigth * num;
		}

		// Token: 0x06000ACC RID: 2764 RVA: 0x000310D8 File Offset: 0x0002F2D8
		private static MapaDeDesgasteDeHole.PointMod ObtenerMod(int puntoID, MapaDeDesgasteDeHole mapaDeDesgaste)
		{
			switch (puntoID)
			{
			case 0:
				return mapaDeDesgaste.modificadores._12;
			case 1:
				return mapaDeDesgaste.modificadores._6;
			case 2:
				return mapaDeDesgaste.modificadores._3;
			case 3:
				return mapaDeDesgaste.modificadores._9;
			case 4:
				return mapaDeDesgaste.modificadores._130;
			case 5:
				return mapaDeDesgaste.modificadores._430;
			case 6:
				return mapaDeDesgaste.modificadores._1030;
			case 7:
				return mapaDeDesgaste.modificadores._730;
			default:
				throw new ArgumentOutOfRangeException(puntoID.ToString());
			}
		}

		// Token: 0x06000ACD RID: 2765
		protected abstract void UpdateHarPoints();

		// Token: 0x06000ACE RID: 2766 RVA: 0x0003117C File Offset: 0x0002F37C
		protected static void UpdateHardPoint(string HardPointID, BoneStretchedChain m_hole, HoleFondoHitSkin m_fondo, float passResistanceMod, float desgaste, float desgastePorSegundoMod, float minDamperOnWeigth, float medDamperOnWeigth, float maxDamperOnWeigth)
		{
			HoleVirtualHardPoint holeVirtualHardPoint;
			if (m_hole.hardPoints.TryGetValue(HardPointID, out holeVirtualHardPoint))
			{
				float num = 0f;
				float anchuraVirtualUnClampWeigth = m_hole.anchuraVirtualUnClampWeigth;
				float num2 = MathfExtension.InverseLerpConMedio(minDamperOnWeigth, medDamperOnWeigth, maxDamperOnWeigth, anchuraVirtualUnClampWeigth);
				num += num2 * 0.75f;
				float motionVirtualUnClampWeigth = m_hole.motionVirtualUnClampWeigth;
				float num3 = MathfExtension.InverseLerpConMedio(minDamperOnWeigth, medDamperOnWeigth, maxDamperOnWeigth, motionVirtualUnClampWeigth);
				num += num3 * 0.25f;
				num = num.OutPow(3f);
				holeVirtualHardPoint.resistenciaMod = num;
				HoleFondoHitSkin.Check check;
				if (m_fondo.checksDeCollisionesDicc.TryGetValue(HardPointID, out check))
				{
					holeVirtualHardPoint.desgaste += check.lastPenetrationWeightSpacial * holeVirtualHardPoint.maxDesgastePorSegundo * desgastePorSegundoMod * Time.deltaTime * (1f + desgaste * 0.1f);
					holeVirtualHardPoint.desgaste = Mathf.Clamp01(holeVirtualHardPoint.desgaste);
					holeVirtualHardPoint.resistenciaMod = Mathf.Clamp01(holeVirtualHardPoint.resistenciaMod - holeVirtualHardPoint.desgaste);
				}
				holeVirtualHardPoint.passResistenciaMod = holeVirtualHardPoint.resistenciaMod * passResistanceMod;
			}
		}

		// Token: 0x040008C0 RID: 2240
		public HoleController.Config config = new HoleController.Config();

		// Token: 0x040008C1 RID: 2241
		public HoleController.Desgaste motionDesgaste = new HoleController.Desgaste();

		// Token: 0x040008C2 RID: 2242
		public HoleController.Desgaste profundidadDesgaste = new HoleController.Desgaste();

		// Token: 0x040008C3 RID: 2243
		public HoleController.Desgaste anchuraDesgaste = new HoleController.Desgaste();

		// Token: 0x040008C4 RID: 2244
		private ModificableDeFloat m_modificableDeDamperOnWeigth = new ModificableDeFloat(1f);

		// Token: 0x040008C5 RID: 2245
		private ModificableDeFloat m_modificableDePenetracionDamper = new ModificableDeFloat(1f);

		// Token: 0x040008C6 RID: 2246
		[SerializeField]
		protected ModificableDeFloat m_modificableDeHardPointsDesgastePorSegundo = new ModificableDeFloat(1f);

		// Token: 0x040008C7 RID: 2247
		[SerializeField]
		private ModificadorDeFloat m_ownModificadorPorDesgasteDePenetracionDamper;

		// Token: 0x040008C8 RID: 2248
		public bool overrideZDamperPenetrationJoint = true;

		// Token: 0x040008C9 RID: 2249
		[Range(0f, 100f)]
		public float modZDamperPenetrationJoint = 1f;

		// Token: 0x040008CA RID: 2250
		private float? m_LastZDamperPenetrationJointMod;

		// Token: 0x040008CB RID: 2251
		[SerializeField]
		private ModificableDeFloat m_timeTryingToOpenHoleModificable = new ModificableDeFloat(1f);

		// Token: 0x040008CC RID: 2252
		[Obsolete("", true)]
		private ModificableDeFloat m_desgasteToBreakHoleModificable = new ModificableDeFloat(1f);

		// Token: 0x040008CD RID: 2253
		[Range(0f, 10f)]
		public float timeTryingToOpenHoleMod = 1f;

		// Token: 0x040008CE RID: 2254
		private HoleController.TimeToOpenCalcule m_TimeToOpen = new HoleController.TimeToOpenCalcule();

		// Token: 0x040008CF RID: 2255
		[SerializeField]
		private bool m_cerrado;

		// Token: 0x040008D0 RID: 2256
		private float? m_cerradoHastaV2;

		// Token: 0x040008D1 RID: 2257
		private Character m_character;

		// Token: 0x040008D2 RID: 2258
		private PenetrationJointCreator m_PenetrationJointCreator;

		// Token: 0x040008D3 RID: 2259
		[SerializeField]
		[Obsolete("", true)]
		private PorcentageModificable m_desgasteVisual;

		// Token: 0x040008D4 RID: 2260
		[SerializeField]
		[Obsolete("", true)]
		private PorcentageModificable m_desgasteAI;

		// Token: 0x040008D5 RID: 2261
		[Obsolete("", true)]
		private PorcentageModificable m_lastDesgaste;

		// Token: 0x020001C3 RID: 451
		[Serializable]
		public class Config
		{
			// Token: 0x040008D6 RID: 2262
			public float defaultApertureMod = 1f;

			// Token: 0x040008D7 RID: 2263
			public float maxApertureMod = 0.01f;

			// Token: 0x040008D8 RID: 2264
			public float minDamperOnWeigth = 0.4f;

			// Token: 0x040008D9 RID: 2265
			public float medDamperOnWeigth = 0.7f;

			// Token: 0x040008DA RID: 2266
			public float maxDamperOnWeigth = 1f;

			// Token: 0x040008DB RID: 2267
			[Range(0f, 100f)]
			[Obsolete("", true)]
			public float desgasteProcentajeToBreakHole = 50f;

			// Token: 0x040008DC RID: 2268
			[Range(0f, 100f)]
			[Obsolete("", true)]
			public float desgasteProcentajeToBreakHardPoints = 66.666f;

			// Token: 0x040008DD RID: 2269
			public float timeTryingToOpenHole = 1f;

			// Token: 0x040008DE RID: 2270
			public float timeToResetPenetrationTry = 0.333f;

			// Token: 0x040008DF RID: 2271
			public bool changeDamperMod = true;

			// Token: 0x040008E0 RID: 2272
			public float maxDamperModPorDesgaste = 4f;

			// Token: 0x040008E1 RID: 2273
			public float defaultDamperMod = 1f;

			// Token: 0x040008E2 RID: 2274
			public float minDamperModPorDesgaste = 0.25f;
		}

		// Token: 0x020001C4 RID: 452
		[Serializable]
		public class Desgaste
		{
			// Token: 0x040008E3 RID: 2275
			public PorcentageModificable desgasteVisual;

			// Token: 0x040008E4 RID: 2276
			public PorcentageModificable desgasteAI;

			// Token: 0x040008E5 RID: 2277
			internal float lastDesgaste;
		}

		// Token: 0x020001C5 RID: 453
		[Serializable]
		public class TimeToOpenCalcule
		{
			// Token: 0x06000AD2 RID: 2770 RVA: 0x000313C8 File Offset: 0x0002F5C8
			public void Init(HoleController controller)
			{
				if (controller == null)
				{
					throw new ArgumentNullException("controller", "controller null reference.");
				}
				this.m_controller = controller;
				this.m_controller.hole.penetraciones.peneTryingPenetration += this.Penetraciones_penisTryingPenetration;
				this.m_controller.hole.penetraciones.checkedPenetraciones += this.Penetraciones_checkedPenetraciones;
			}

			// Token: 0x06000AD3 RID: 2771 RVA: 0x00031438 File Offset: 0x0002F638
			public void Destroy()
			{
				HoleController controller = this.m_controller;
				Penetraciones penetraciones;
				if (controller == null)
				{
					penetraciones = null;
				}
				else
				{
					BoneStretchedChain hole = controller.hole;
					penetraciones = ((hole != null) ? hole.penetraciones : null);
				}
				Penetraciones penetraciones2 = penetraciones;
				if (penetraciones2 != null)
				{
					penetraciones2.peneTryingPenetration -= this.Penetraciones_penisTryingPenetration;
					penetraciones2.checkedPenetraciones -= this.Penetraciones_checkedPenetraciones;
				}
			}

			// Token: 0x17000254 RID: 596
			// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x0003148B File Offset: 0x0002F68B
			public bool trying
			{
				get
				{
					return this.m_trying;
				}
			}

			// Token: 0x06000AD5 RID: 2773 RVA: 0x00031494 File Offset: 0x0002F694
			private void Penetraciones_penisTryingPenetration(Penetraciones.TryPenetrationArgs args, IPeneConPartes pene, Penetraciones penetracionesChecker)
			{
				float num = (((float)args.cantidadDePartesIntentando > 0f) ? (1f / (float)args.cantidadDePartesIntentando) : 1f);
				this.m_lastTryTime = Time.time;
				float worldTipPartWidth = pene.worldTipPartWidth;
				float worldScaleReal = this.m_controller.hole.worldScaleReal;
				float num2 = worldTipPartWidth / worldScaleReal;
				float num3 = Mathf.Clamp(MathfExtension.InverseLerpUnclamped(0f, this.m_controller.hole.maxAnchuraVirtualLocal, num2), 0f, float.MaxValue);
				float num4;
				float num5;
				float num6;
				this.m_controller.GetDamperOnOnWeigthValues(out num4, out num5, out num6);
				float num7 = MathfExtension.InverseLerpConMedio(num4, num5, num6, num3);
				num7 = num7.InPow(8f);
				if (this.startTime == null)
				{
					this.startTime = new float?(Time.time);
				}
				float? num8 = Time.time - this.startTime;
				float num9 = this.m_controller.timeTryingToOpenHole * this.m_controller.timeTryingToOpenHoleMod * pene.timeTryingToOpenHoleMod;
				if (pene is Finger)
				{
					num9 *= 0.2f;
				}
				num9 = this.m_controller.m_timeTryingToOpenHoleModificable.ModificarValor(num9);
				float num10 = Mathf.Lerp(0f, num9, num7) * num;
				float? num11 = num8;
				float num12 = num10;
				if ((num11.GetValueOrDefault() < num12) & (num11 != null))
				{
					args.DenyPenetration();
					this.m_trying = true;
					return;
				}
				this.startTime = null;
				this.m_trying = false;
			}

			// Token: 0x06000AD6 RID: 2774 RVA: 0x00031625 File Offset: 0x0002F825
			private void Penetraciones_checkedPenetraciones(Penetraciones penetracionesChecker, bool penesDetectados)
			{
				if (!this.m_trying)
				{
					return;
				}
				if (Time.time - this.m_lastTryTime > this.m_controller.config.timeToResetPenetrationTry)
				{
					this.startTime = null;
					this.m_trying = false;
				}
			}

			// Token: 0x040008E6 RID: 2278
			private float m_lastTryTime;

			// Token: 0x040008E7 RID: 2279
			[SerializeField]
			[ReadOnlyUI]
			private bool m_trying;

			// Token: 0x040008E8 RID: 2280
			private float? startTime;

			// Token: 0x040008E9 RID: 2281
			private HoleController m_controller;
		}
	}
}
