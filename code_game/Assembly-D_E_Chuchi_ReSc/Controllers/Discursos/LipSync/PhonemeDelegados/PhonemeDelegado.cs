using System;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.Controllers;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Discursos.LipSync.PhonemeDelegados
{
	// Token: 0x0200027E RID: 638
	public abstract class PhonemeDelegado : CustomUpdatedMonobehaviourBase, IPhonemeDelegado
	{
		// Token: 0x17000310 RID: 784
		// (get) Token: 0x06000E2A RID: 3626 RVA: 0x00006318 File Offset: 0x00004518
		public sealed override int updateEvent1Index
		{
			get
			{
				return 2;
			}
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06000E2B RID: 3627
		public abstract Phoneme phoneme { get; }

		// Token: 0x06000E2C RID: 3628 RVA: 0x00042D6C File Offset: 0x00040F6C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_mapa = MapaSingleton<MapaDeCCAnimationBlendShapes>.instance;
			this.m_controlladorShapes = this.GetComponentEnRoot(false);
			this.m_Gestuable = this.GetComponentEnRoot(false);
			if (this.m_Gestuable == null)
			{
				throw new ArgumentNullException("m_Gestuable", "m_Gestuable null reference.");
			}
			if (this.m_controlladorShapes == null)
			{
				throw new ArgumentNullException("m_controlladorShapes", "m_controlladorShapes null reference.");
			}
			this.m_controlladorJaw = this.GetComponentEnRoot(false);
			if (this.m_controlladorJaw == null)
			{
				throw new ArgumentNullException("m_controlladorJaw", "m_controlladorJaw null reference.");
			}
		}

		// Token: 0x06000E2D RID: 3629 RVA: 0x00042DF9 File Offset: 0x00040FF9
		protected float ModPorBocaApretada()
		{
			if (this.m_Gestuable.estadoDeBocaReal == CharacterEstadoDeBoca.sellada)
			{
				return 0.15f;
			}
			return 1f;
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x00042E14 File Offset: 0x00041014
		protected float ModPorBocaAbierta()
		{
			if (this.m_Gestuable.estadoDeBocaReal == CharacterEstadoDeBoca.abiertaSinEnergia)
			{
				return 0.1f;
			}
			if (this.m_Gestuable.estadoDeBocaReal == CharacterEstadoDeBoca.abierta)
			{
				return 0.2f;
			}
			return 1f;
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x00042E43 File Offset: 0x00041043
		protected override void OnValidateUnityEvent()
		{
			base.OnValidateUnityEvent();
			if (Application.isPlaying && Application.isEditor && base.isStared)
			{
				this.flagForceOnWeightChanded = true;
			}
		}

		// Token: 0x06000E30 RID: 3632 RVA: 0x00042E68 File Offset: 0x00041068
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_LastWeight = null;
			this.RemoverOrdenes();
		}

		// Token: 0x06000E31 RID: 3633 RVA: 0x00042E84 File Offset: 0x00041084
		public sealed override void OnUpdateEvent1()
		{
			if (!this.m_controlladorJaw.isStared || !this.m_controlladorShapes.isStared)
			{
				return;
			}
			this.weight = Mathf.Clamp01(this.weight);
			if (this.m_LastWeight == null || !ExtendedMonoBehaviour.AlmostEqual(this.m_LastWeight.Value, this.weight, 0.001f) || this.flagForceOnWeightChanded)
			{
				this.flagForceOnWeightChanded = false;
				if (!this.m_ordenesCargadas || (this.weight > 0f && (this.m_LastWeight == null || this.m_LastWeight.Value <= 0f)))
				{
					this.LoadOrdenes();
				}
				this.m_LastWeight = new float?(this.weight);
				this.OnWeightChanded();
				if (this.weight == 0f && this.m_ordenesCargadas)
				{
					this.RemoverOrdenes();
				}
			}
		}

		// Token: 0x06000E32 RID: 3634 RVA: 0x00042F64 File Offset: 0x00041164
		private void LoadOrdenes()
		{
			try
			{
				this.m_controlladorJaw.ObtenerOrdenesDeID("x", ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio).modificable.LoadModificador(ref this.jawOpenOrden, this);
				this.LoadOrdenesDeShapeController();
			}
			finally
			{
				this.m_ordenesCargadas = true;
			}
		}

		// Token: 0x06000E33 RID: 3635 RVA: 0x00042FB4 File Offset: 0x000411B4
		private void RemoverOrdenes()
		{
			try
			{
				ModificadorDeFloat modificadorDeFloat = this.jawOpenOrden;
				if (modificadorDeFloat != null)
				{
					modificadorDeFloat.TryRemoverDeOwner(false);
				}
				this.RemoverOrdenesDeShapeController();
			}
			finally
			{
				this.m_ordenesCargadas = false;
			}
		}

		// Token: 0x06000E34 RID: 3636
		protected abstract void OnWeightChanded();

		// Token: 0x06000E35 RID: 3637
		protected abstract void LoadOrdenesDeShapeController();

		// Token: 0x06000E36 RID: 3638
		protected abstract void RemoverOrdenesDeShapeController();

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06000E37 RID: 3639 RVA: 0x00042FF4 File Offset: 0x000411F4
		// (set) Token: 0x06000E38 RID: 3640 RVA: 0x00042FFC File Offset: 0x000411FC
		float IPhonemeDelegado.weight
		{
			get
			{
				return this.weight;
			}
			set
			{
				this.weight = value;
			}
		}

		// Token: 0x04000C18 RID: 3096
		public bool flagForceOnWeightChanded;

		// Token: 0x04000C19 RID: 3097
		[Range(0f, 1f)]
		public float weight;

		// Token: 0x04000C1A RID: 3098
		private float? m_LastWeight;

		// Token: 0x04000C1B RID: 3099
		[ReadOnlyUI]
		[SerializeField]
		private bool m_ordenesCargadas;

		// Token: 0x04000C1C RID: 3100
		protected ModificadorDeFloat jawOpenOrden;

		// Token: 0x04000C1D RID: 3101
		protected IControladorDeAnimationBlendShapes m_controlladorShapes;

		// Token: 0x04000C1E RID: 3102
		protected IControladorDeJaw m_controlladorJaw;

		// Token: 0x04000C1F RID: 3103
		protected ICharacterGestuable m_Gestuable;

		// Token: 0x04000C20 RID: 3104
		protected MapaDeCCAnimationBlendShapes m_mapa;
	}
}
