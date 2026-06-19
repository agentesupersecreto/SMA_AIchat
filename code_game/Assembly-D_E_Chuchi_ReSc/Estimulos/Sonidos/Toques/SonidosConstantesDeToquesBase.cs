using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Historiales;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques
{
	// Token: 0x020002AC RID: 684
	public abstract class SonidosConstantesDeToquesBase<TSonidoConstanteConFlag> : ReproductorDeSonidosConstantes<TSonidoConstanteConFlag>, IReproductorDeSonidoDeToques, IReproductorDeSonidos where TSonidoConstanteConFlag : class, ISonidoConstanteConFlag
	{
		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06000F48 RID: 3912 RVA: 0x00046264 File Offset: 0x00044464
		public sealed override int updateEvent1Index
		{
			get
			{
				return 71;
			}
		}

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06000F49 RID: 3913 RVA: 0x00046268 File Offset: 0x00044468
		public sealed override int updateEvent2Index
		{
			get
			{
				return 72;
			}
		}

		// Token: 0x1400003F RID: 63
		// (add) Token: 0x06000F4A RID: 3914 RVA: 0x0004626C File Offset: 0x0004446C
		// (remove) Token: 0x06000F4B RID: 3915 RVA: 0x000462A4 File Offset: 0x000444A4
		public event RegistrandoDeToqueDeSonidoHandler registrandoToque;

		// Token: 0x06000F4C RID: 3916 RVA: 0x000462D9 File Offset: 0x000444D9
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetManualStart();
			base.SetInicializable();
		}

		// Token: 0x06000F4D RID: 3917 RVA: 0x000462ED File Offset: 0x000444ED
		public void Init(IEstimulablePorToques target)
		{
			this.AddToToques(target);
			if (base.initPendiente)
			{
				base.Initialize();
			}
			if (this.customUpdatedConfig.manualStart)
			{
				base.ManualStart();
			}
		}

		// Token: 0x06000F4E RID: 3918 RVA: 0x00046318 File Offset: 0x00044518
		public void Init(IReadOnlyList<IEstimulablePorToques> targets)
		{
			for (int i = 0; i < targets.Count; i++)
			{
				IEstimulablePorToques estimulablePorToques = targets[i];
				this.AddToToques(estimulablePorToques);
			}
			if (base.initPendiente)
			{
				base.Initialize();
			}
			if (this.customUpdatedConfig.manualStart)
			{
				base.ManualStart();
			}
		}

		// Token: 0x06000F4F RID: 3919 RVA: 0x00046366 File Offset: 0x00044566
		private void AddToToques(IEstimulablePorToques estimulable)
		{
			if (estimulable == null)
			{
				return;
			}
			this.m_Estimulables.Add(estimulable);
			if (Application.isEditor)
			{
				if (this.m_EstimulablesDebug == null)
				{
					this.m_EstimulablesDebug = new List<Object>();
				}
				this.m_EstimulablesDebug.Add(estimulable as Object);
			}
		}

		// Token: 0x06000F50 RID: 3920 RVA: 0x00003B39 File Offset: 0x00001D39
		private void Subs(object sender)
		{
		}

		// Token: 0x06000F51 RID: 3921 RVA: 0x00026EF4 File Offset: 0x000250F4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x06000F52 RID: 3922 RVA: 0x000463A3 File Offset: 0x000445A3
		private void TouchedBy_finallyUpdated(EstimuledBy obj)
		{
			this.m_historialDeSonidoProductor.FinalizarEstado();
		}

		// Token: 0x06000F53 RID: 3923 RVA: 0x000463B0 File Offset: 0x000445B0
		private void TouchedBy_updated(EstimuledBy obj)
		{
			IReadOnlyList<ICharacterUnico> characteres = Singleton<CharacteresActivos>.instance.characteres;
			for (int i = 0; i < characteres.Count; i++)
			{
				ICharacterUnico characterUnico = characteres[i];
				this.RegistrarToques(characterUnico, obj);
			}
		}

		// Token: 0x06000F54 RID: 3924 RVA: 0x000463EC File Offset: 0x000445EC
		private void RegistrarToques(ICharacterUnico by, EstimuledBy obj)
		{
			try
			{
				if (by != null)
				{
					ITouchedByCharacter touchedByCharacter = obj as ITouchedByCharacter;
					if ((touchedByCharacter != null && touchedByCharacter.ContieneEstimulosDeCharacter<EstimuloTactil>(by, SonidosConstantesDeToquesBase<TSonidoConstanteConFlag>.m_TEMP)) || obj.ContieneEstimulosV3<EstimuloTactil>(by, SonidosConstantesDeToquesBase<TSonidoConstanteConFlag>.m_TEMP))
					{
						for (int i = 0; i < SonidosConstantesDeToquesBase<TSonidoConstanteConFlag>.m_TEMP.Count; i++)
						{
							this.RegistrarToque(by, SonidosConstantesDeToquesBase<TSonidoConstanteConFlag>.m_TEMP[i]);
						}
					}
				}
			}
			finally
			{
				SonidosConstantesDeToquesBase<TSonidoConstanteConFlag>.m_TEMP.Clear();
			}
		}

		// Token: 0x06000F55 RID: 3925 RVA: 0x0004646C File Offset: 0x0004466C
		private void RegistrarToque(ICharacterUnico by, EstimuloTactil estimulo)
		{
			if (estimulo == null)
			{
				return;
			}
			Transform transformEstimulante = estimulo.transformEstimulante;
			Rigidbody componentInParent = transformEstimulante.GetComponentInParent<Rigidbody>();
			Component component;
			if (componentInParent != null)
			{
				component = componentInParent;
			}
			else
			{
				Collider componentInParent2 = transformEstimulante.GetComponentInParent<Collider>();
				if (componentInParent2 == null)
				{
					return;
				}
				component = componentInParent2;
			}
			SonidoProductor sonidoProductor = ((component != null) ? component.GetComponent<SonidoProductor>() : null);
			if (sonidoProductor == null)
			{
				return;
			}
			if (this.m_historialDeSonidoProductor.AddAndObtainHistorialDeItem(sonidoProductor) != HistorialResultado.stay)
			{
				return;
			}
			if (base.EstaFueraDeRangosDeVelocidad(estimulo.velocidadRelativaEmuladaMaxima))
			{
				return;
			}
			if (base.EstaCoolDown() || base.EstaObjetoCoolDown(sonidoProductor) || base.EstaFueraDeCompatibilidad(sonidoProductor))
			{
				return;
			}
			SonidoMods @default = SonidoMods.@default;
			ReproductorDeSonidos.AbortarArg abortarArg = default(ReproductorDeSonidos.AbortarArg);
			RegistrandoDeToqueDeSonidoHandler registrandoDeToqueDeSonidoHandler = this.registrandoToque;
			if (registrandoDeToqueDeSonidoHandler != null)
			{
				registrandoDeToqueDeSonidoHandler(estimulo, sonidoProductor, ref @default, ref abortarArg, this);
			}
			object obj = this.ObtenerExtraData(by, estimulo, sonidoProductor);
			if (!abortarArg.abortado)
			{
				base.RegistrarPedido(sonidoProductor, estimulo.posicionGlobalDelEstimulo, estimulo.velocidadRelativaEmuladaMaxima, @default, obj, false);
			}
		}

		// Token: 0x06000F56 RID: 3926 RVA: 0x00046552 File Offset: 0x00044752
		protected override object ResolverConflictoDeExtraData(object old, object @new)
		{
			if (old != null || @new != null)
			{
				throw new NotImplementedException();
			}
			return null;
		}

		// Token: 0x06000F57 RID: 3927 RVA: 0x00006060 File Offset: 0x00004260
		protected virtual object ObtenerExtraData(ICharacterUnico by, EstimuloTactil estimulo, SonidoProductor productor)
		{
			return null;
		}

		// Token: 0x06000F58 RID: 3928 RVA: 0x00046564 File Offset: 0x00044764
		public override void OnUpdateEvent1()
		{
			for (int i = 0; i < this.m_Estimulables.Count; i++)
			{
				IEstimulablePorToques estimulablePorToques = this.m_Estimulables[i];
				EstimuledBy estimuledBy = ((estimulablePorToques != null) ? estimulablePorToques.touchedBy : null);
				if (estimuledBy != null)
				{
					this.TouchedBy_updated(estimuledBy);
				}
			}
		}

		// Token: 0x06000F59 RID: 3929 RVA: 0x000465AA File Offset: 0x000447AA
		public override void OnUpdateEvent2()
		{
			base.AfterRegistro();
			this.m_historialDeSonidoProductor.FinalizarEstado();
			this.ActualizarSlots(false);
		}

		// Token: 0x04000CBF RID: 3263
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_EstimulablesDebug;

		// Token: 0x04000CC0 RID: 3264
		private List<IEstimulablePorToques> m_Estimulables = new List<IEstimulablePorToques>();

		// Token: 0x04000CC2 RID: 3266
		private HistorialGenerico<SonidoProductor> m_historialDeSonidoProductor = new HistorialGenerico<SonidoProductor>();

		// Token: 0x04000CC3 RID: 3267
		private static List<EstimuloTactil> m_TEMP = new List<EstimuloTactil>();
	}
}
