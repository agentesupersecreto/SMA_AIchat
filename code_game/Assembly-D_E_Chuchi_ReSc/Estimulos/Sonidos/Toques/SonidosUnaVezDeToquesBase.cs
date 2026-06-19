using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.Historiales;
using Assets._ReusableScripts.Sonidos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos.Sonidos.Toques
{
	// Token: 0x020002AE RID: 686
	public abstract class SonidosUnaVezDeToquesBase<TISonidoUnaVez> : ReproductorDeSonidosUnaVez<TISonidoUnaVez>, IReproductorDeSonidoDeToques, IReproductorDeSonidos where TISonidoUnaVez : class, ISonidoUnaVez
	{
		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06000F63 RID: 3939 RVA: 0x00046264 File Offset: 0x00044464
		public sealed override int updateEvent1Index
		{
			get
			{
				return 71;
			}
		}

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06000F64 RID: 3940 RVA: 0x00046268 File Offset: 0x00044468
		public sealed override int updateEvent2Index
		{
			get
			{
				return 72;
			}
		}

		// Token: 0x14000041 RID: 65
		// (add) Token: 0x06000F65 RID: 3941 RVA: 0x000468B0 File Offset: 0x00044AB0
		// (remove) Token: 0x06000F66 RID: 3942 RVA: 0x000468E8 File Offset: 0x00044AE8
		public event RegistrandoDeToqueDeSonidoHandler registrandoToque;

		// Token: 0x06000F67 RID: 3943 RVA: 0x000462D9 File Offset: 0x000444D9
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetManualStart();
			base.SetInicializable();
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x0004691D File Offset: 0x00044B1D
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

		// Token: 0x06000F69 RID: 3945 RVA: 0x00046948 File Offset: 0x00044B48
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

		// Token: 0x06000F6A RID: 3946 RVA: 0x00046996 File Offset: 0x00044B96
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

		// Token: 0x06000F6B RID: 3947 RVA: 0x00003B39 File Offset: 0x00001D39
		private void Subs(object sender)
		{
		}

		// Token: 0x06000F6C RID: 3948 RVA: 0x00026EF4 File Offset: 0x000250F4
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
		}

		// Token: 0x06000F6D RID: 3949 RVA: 0x000469D4 File Offset: 0x00044BD4
		private void TouchedBy_updated(EstimuledBy obj)
		{
			IReadOnlyList<ICharacterUnico> characteres = Singleton<CharacteresActivos>.instance.characteres;
			for (int i = 0; i < characteres.Count; i++)
			{
				ICharacterUnico characterUnico = characteres[i];
				this.RegistrarToques(characterUnico, obj);
			}
		}

		// Token: 0x06000F6E RID: 3950 RVA: 0x00046A10 File Offset: 0x00044C10
		private void RegistrarToques(ICharacterUnico by, EstimuledBy obj)
		{
			try
			{
				if (by != null)
				{
					ITouchedByCharacter touchedByCharacter = obj as ITouchedByCharacter;
					if ((touchedByCharacter != null && touchedByCharacter.ContieneEstimulosDeCharacter<EstimuloTactil>(by, SonidosUnaVezDeToquesBase<TISonidoUnaVez>.m_TEMP)) || obj.ContieneEstimulosV3<EstimuloTactil>(by, SonidosUnaVezDeToquesBase<TISonidoUnaVez>.m_TEMP))
					{
						for (int i = 0; i < SonidosUnaVezDeToquesBase<TISonidoUnaVez>.m_TEMP.Count; i++)
						{
							this.RegistrarToque(by, SonidosUnaVezDeToquesBase<TISonidoUnaVez>.m_TEMP[i]);
						}
					}
				}
			}
			finally
			{
				SonidosUnaVezDeToquesBase<TISonidoUnaVez>.m_TEMP.Clear();
			}
		}

		// Token: 0x06000F6F RID: 3951 RVA: 0x00046A90 File Offset: 0x00044C90
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
			HistorialResultado historialResultado = this.m_historialDeSonidoProductor.AddAndObtainHistorialDeItem(sonidoProductor);
			SonidoMods @default = SonidoMods.@default;
			if (base.EstaFueraDeRangosDeVelocidad(estimulo.velocidadRelativaEmuladaMaxima))
			{
				return;
			}
			if (base.EstaCoolDown() || base.EstaObjetoCoolDown(sonidoProductor) || base.EstaFueraDeCompatibilidad(sonidoProductor))
			{
				return;
			}
			if (historialResultado != HistorialResultado.enter)
			{
				if (historialResultado == HistorialResultado.exit)
				{
					return;
				}
				if (this.toquesConfig.reproducirSoloEnterToques)
				{
					return;
				}
				if (estimulo.velocidadRelativaEmuladaMaxima < this.toquesConfig.minVelocidadParaReproducirNoEnterToques)
				{
					return;
				}
				Vector3 vector = estimulo.posicionGlobalDelEstimulo - estimulo.transformEstimulante.position;
				float num = Vector3.Angle(estimulo.velocidadRelativaEmulada, vector);
				if (num > this.toquesConfig.maxAngleParaReproducirNoEnterToques)
				{
					return;
				}
				float num2 = Mathf.InverseLerp(this.toquesConfig.maxAngleParaReproducirNoEnterToques, 0f, num).OutPow(2f);
				bool debugDrawMaxAngle = this.toquesConfig.debugDrawMaxAngle;
				@default.pitch *= this.toquesConfig.pitchModOnNoEnterToques;
				@default.volumen *= this.toquesConfig.volModOnNoEnterToques * num2;
			}
			ReproductorDeSonidos.AbortarArg abortarArg = default(ReproductorDeSonidos.AbortarArg);
			RegistrandoDeToqueDeSonidoHandler registrandoDeToqueDeSonidoHandler = this.registrandoToque;
			if (registrandoDeToqueDeSonidoHandler != null)
			{
				registrandoDeToqueDeSonidoHandler(estimulo, sonidoProductor, ref @default, ref abortarArg, this);
			}
			object obj = this.ObtenerExtraData(by, estimulo, sonidoProductor);
			if (!abortarArg.abortado)
			{
				if (this.debugDrawToques)
				{
					Debug.Log(estimulo.estimulado.name + " " + estimulo.estimulante.name, this);
				}
				base.RegistrarPedido(sonidoProductor, estimulo.posicionGlobalDelEstimulo, estimulo.velocidadRelativaEmuladaMaxima, @default, obj, false);
			}
		}

		// Token: 0x06000F70 RID: 3952 RVA: 0x00046552 File Offset: 0x00044752
		protected override object ResolverConflictoDeExtraData(object old, object @new)
		{
			if (old != null || @new != null)
			{
				throw new NotImplementedException();
			}
			return null;
		}

		// Token: 0x06000F71 RID: 3953 RVA: 0x00006060 File Offset: 0x00004260
		protected virtual object ObtenerExtraData(ICharacterUnico by, EstimuloTactil estimulo, SonidoProductor productor)
		{
			return null;
		}

		// Token: 0x06000F72 RID: 3954 RVA: 0x00046C68 File Offset: 0x00044E68
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

		// Token: 0x06000F73 RID: 3955 RVA: 0x00046CAE File Offset: 0x00044EAE
		public override void OnUpdateEvent2()
		{
			base.AfterRegistro();
			this.m_historialDeSonidoProductor.FinalizarEstado();
			this.ActualizarSlots(false);
		}

		// Token: 0x04000CC6 RID: 3270
		public bool debugDrawToques;

		// Token: 0x04000CC7 RID: 3271
		public SonidosUnaVezDeToquesBaseConfig toquesConfig = new SonidosUnaVezDeToquesBaseConfig();

		// Token: 0x04000CC8 RID: 3272
		[ReadOnlyUI]
		[SerializeField]
		private List<Object> m_EstimulablesDebug;

		// Token: 0x04000CC9 RID: 3273
		private List<IEstimulablePorToques> m_Estimulables = new List<IEstimulablePorToques>();

		// Token: 0x04000CCB RID: 3275
		private HistorialGenerico<SonidoProductor> m_historialDeSonidoProductor = new HistorialGenerico<SonidoProductor>();

		// Token: 0x04000CCC RID: 3276
		private static List<EstimuloTactil> m_TEMP = new List<EstimuloTactil>();
	}
}
