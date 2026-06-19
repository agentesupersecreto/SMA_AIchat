using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Runtime.Characteres;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.BeachGirl.Runtime.Males
{
	// Token: 0x020000A0 RID: 160
	public class MaleHandFingerSizeModPorShapes : ModificadorDeVolumenPorShapes, IHandFingerSizeModPorShapes
	{
		// Token: 0x170001EB RID: 491
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x0000FDEE File Offset: 0x0000DFEE
		public override GlobalUpdater.UpdateType? updateEvent1
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x060004EC RID: 1260 RVA: 0x0000FDF6 File Offset: 0x0000DFF6
		public override IReadOnlyList<ModificadorDeVolumenPorShapes.ModificacionInfo> infos
		{
			get
			{
				return this.m_modsInfos;
			}
		}

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x060004ED RID: 1261 RVA: 0x0000FDFE File Offset: 0x0000DFFE
		public float currentOverallMod
		{
			get
			{
				return this.m_currentOverallMod;
			}
		}

		// Token: 0x060004EE RID: 1262 RVA: 0x0000FE08 File Offset: 0x0000E008
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			ICharacter componentEnRoot = this.GetComponentEnRoot(false);
			for (int i = 0; i < this.m_modsInfos.Count; i++)
			{
				MaleHandFingerSizeModPorShapes.HandFingerSizeModificacion handFingerSizeModificacion = this.m_modsInfos[i];
				handFingerSizeModificacion.Init(componentEnRoot.bodyAnimator, i, this);
				if (!handFingerSizeModificacion.isValid)
				{
					Debug.LogError("HandFingerSizeModificacion no es valida.");
				}
			}
		}

		// Token: 0x060004EF RID: 1263 RVA: 0x0000FE64 File Offset: 0x0000E064
		public override void OnUpdateEvent1()
		{
			base.Actualizar();
			this.m_currentOverallMod = this.m_overallModificable.ModificarValor(1f);
		}

		// Token: 0x040002E3 RID: 739
		[SerializeField]
		private List<MaleHandFingerSizeModPorShapes.HandFingerSizeModificacion> m_modsInfos = new List<MaleHandFingerSizeModPorShapes.HandFingerSizeModificacion>();

		// Token: 0x040002E4 RID: 740
		[SerializeField]
		private ModificableDeFloat m_overallModificable = new ModificableDeFloat(1f);

		// Token: 0x040002E5 RID: 741
		[ReadOnlyUI]
		[SerializeField]
		private float m_currentOverallMod;

		// Token: 0x02000192 RID: 402
		[Serializable]
		public class HandFingerSizeModificacion : ModificadorDeVolumenPorShapes.ModificacionInfo
		{
			// Token: 0x17000511 RID: 1297
			// (get) Token: 0x06000ED8 RID: 3800 RVA: 0x00032866 File Offset: 0x00030A66
			public override string normbreDeShape
			{
				get
				{
					return MapaSingleton<MapaDeMaleBlendShapes>.instance.ObtenerValorDeField(this.m_shape);
				}
			}

			// Token: 0x06000ED9 RID: 3801 RVA: 0x00032878 File Offset: 0x00030A78
			public void Init(Animator anim, int index, MaleHandFingerSizeModPorShapes holder)
			{
				this.m_modificador = holder.m_overallModificable.ObtenerModificadorNotNull(index);
				base.Init(anim, holder);
			}

			// Token: 0x06000EDA RID: 3802 RVA: 0x00032894 File Offset: 0x00030A94
			protected override void Destroyed()
			{
				ModificadorDeFloat modificador = this.m_modificador;
				if (modificador == null)
				{
					return;
				}
				modificador.TryRemoverDeOwner(true);
			}

			// Token: 0x06000EDB RID: 3803 RVA: 0x000328A8 File Offset: 0x00030AA8
			protected override void Updated(float mod)
			{
				this.m_modificador.valor.valor = mod;
			}

			// Token: 0x040008E2 RID: 2274
			[SerializeField]
			[StringSelector(typeof(MapaDeMaleBlendShapes), "fieldsEditor")]
			private string m_shape;

			// Token: 0x040008E3 RID: 2275
			[SerializeField]
			private ModificadorDeFloat m_modificador;
		}
	}
}
