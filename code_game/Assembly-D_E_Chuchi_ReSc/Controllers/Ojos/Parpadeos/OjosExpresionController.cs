using System;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos
{
	// Token: 0x0200025A RID: 602
	public sealed class OjosExpresionController : ControllerColaDePrioridadBase<OjosExpresionController.Estado, OjosExpresionController.Orden, OjosExpresionController.Cola, OjosExpresionController, OjosExpresionController.Tipo>
	{
		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000D76 RID: 3446 RVA: 0x0003EBD3 File Offset: 0x0003CDD3
		protected override int cantidadDeEstados
		{
			get
			{
				if (this.m_cantidadDeEstados == null)
				{
					this.m_cantidadDeEstados = new int?(typeof(OjosExpresionController.Tipo).GetEnumCount());
				}
				return this.m_cantidadDeEstados.Value;
			}
		}

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000D77 RID: 3447 RVA: 0x0003EC07 File Offset: 0x0003CE07
		protected sealed override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.lateUpdate2);
			}
		}

		// Token: 0x06000D78 RID: 3448 RVA: 0x0003EC10 File Offset: 0x0003CE10
		protected sealed override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_control = this.GetComponentEnCharacter(false);
			this.m_modsDeParpadeo.Init(this.m_control.modificableDeParpadeo, this);
			this.m_modsDeGuiñoR.Init(this.m_control.modificableDeGuiñoR, this);
			this.m_modsDeGuiñoL.Init(this.m_control.modificableDeGuiñoL, this);
			this.m_modsDeAchiquitar.Init(this.m_control.modificableDeAchiquitamiento, this);
			this.m_modsDeAgrandar.Init(this.m_control.modificableDeAgrandamiento, this);
		}

		// Token: 0x06000D79 RID: 3449 RVA: 0x0003ECA3 File Offset: 0x0003CEA3
		public bool Cancelar(OjosExpresionController.Tipo tipoId)
		{
			return base.currentStado.DetenerOrdenEnSlot(tipoId);
		}

		// Token: 0x06000D7A RID: 3450 RVA: 0x0003ECB4 File Offset: 0x0003CEB4
		public bool Cambiar(OjosExpresionController.Tipo tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, float target = 100f, float tiempoModIn = 1f, float tiempoModOut = 1f)
		{
			bool flag = false;
			OjosExpresionController.Orden orden;
			bool flag2;
			bool flag3;
			if (!base.VerificarSiPuedeEjecutarse(out orden, out flag2, tipoId, prioridad, priConfig, out flag3, ref flag, false))
			{
				return false;
			}
			target = Mathf.Clamp(target, 0f, 100f);
			if (base.PuedeAcumularse(orden, priConfig, tipoId))
			{
				orden.target = target;
				orden.tiempoModIn = tiempoModIn;
				orden.tiempoModOut = tiempoModOut;
				base.ResusarOrden(orden, duracion, prioridad, null, null);
				return true;
			}
			if (!flag && flag3)
			{
				return false;
			}
			OjosExpresionController.Orden orden2 = new OjosExpresionController.Orden(tipoId, prioridad, duracion, priConfig, target, tiempoModIn, tiempoModOut);
			base.Procesar(orden == null, flag2, priConfig, orden2, false, false);
			return true;
		}

		// Token: 0x06000D7B RID: 3451 RVA: 0x0000386D File Offset: 0x00001A6D
		public override OjosExpresionController.Tipo ParseIndexToTipoId(int index)
		{
			return (OjosExpresionController.Tipo)index;
		}

		// Token: 0x06000D7C RID: 3452 RVA: 0x0000386D File Offset: 0x00001A6D
		public override int ParseTipoIdToindex(OjosExpresionController.Tipo tipoId)
		{
			return (int)tipoId;
		}

		// Token: 0x06000D7D RID: 3453 RVA: 0x0001A9B9 File Offset: 0x00018BB9
		protected override OjosExpresionController ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x06000D7E RID: 3454 RVA: 0x0003ED4C File Offset: 0x0003CF4C
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			if (this.m_duracionDebug <= 0f)
			{
				return base.Boton2();
			}
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "GestuarDebug"
			};
		}

		// Token: 0x06000D7F RID: 3455 RVA: 0x0003ED79 File Offset: 0x0003CF79
		protected override void OnAplicar2()
		{
			this.Cambiar(this.m_gestuarDebug, int.MaxValue, this.m_duracionDebug, ControllerPrioridadConfig.prioridad, this.m_weightDebug * 100f, this.m_inTiempoModDebug, this.m_outTiempoModDebug);
		}

		// Token: 0x04000B83 RID: 2947
		private int? m_cantidadDeEstados;

		// Token: 0x04000B84 RID: 2948
		private IControlDeParpadeo m_control;

		// Token: 0x04000B85 RID: 2949
		[SerializeField]
		private ControlDeParpadeo.ModsDeModificadoresHolder m_modsDeParpadeo = new ControlDeParpadeo.ModsDeModificadoresHolder();

		// Token: 0x04000B86 RID: 2950
		[SerializeField]
		private ControlDeParpadeo.ModsDeModificadoresHolder m_modsDeGuiñoR = new ControlDeParpadeo.ModsDeModificadoresHolder();

		// Token: 0x04000B87 RID: 2951
		[SerializeField]
		private ControlDeParpadeo.ModsDeModificadoresHolder m_modsDeGuiñoL = new ControlDeParpadeo.ModsDeModificadoresHolder();

		// Token: 0x04000B88 RID: 2952
		[SerializeField]
		private ControlDeParpadeo.ModsDeModificadoresHolder m_modsDeAchiquitar = new ControlDeParpadeo.ModsDeModificadoresHolder();

		// Token: 0x04000B89 RID: 2953
		[SerializeField]
		private ControlDeParpadeo.ModsDeModificadoresHolder m_modsDeAgrandar = new ControlDeParpadeo.ModsDeModificadoresHolder();

		// Token: 0x04000B8A RID: 2954
		[Header("***Debbuging")]
		[SerializeField]
		private OjosExpresionController.Tipo m_gestuarDebug;

		// Token: 0x04000B8B RID: 2955
		[SerializeField]
		private float m_duracionDebug = 3f;

		// Token: 0x04000B8C RID: 2956
		[SerializeField]
		private float m_weightDebug = 1f;

		// Token: 0x04000B8D RID: 2957
		[SerializeField]
		private float m_inTiempoModDebug = 1f;

		// Token: 0x04000B8E RID: 2958
		[SerializeField]
		private float m_outTiempoModDebug = 1f;

		// Token: 0x0200025B RID: 603
		public sealed class Estado : ControllerColaDePrioridadBase<OjosExpresionController.Estado, OjosExpresionController.Orden, OjosExpresionController.Cola, OjosExpresionController, OjosExpresionController.Tipo>.StadoBase
		{
		}

		// Token: 0x0200025C RID: 604
		public sealed class Cola : ControllerColaDePrioridadBase<OjosExpresionController.Estado, OjosExpresionController.Orden, OjosExpresionController.Cola, OjosExpresionController, OjosExpresionController.Tipo>.ColasBase
		{
		}

		// Token: 0x0200025D RID: 605
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<OjosExpresionController.Estado, OjosExpresionController.Orden, OjosExpresionController.Cola, OjosExpresionController, OjosExpresionController.Tipo>.OrdenBaseDeControllador
		{
			// Token: 0x06000D83 RID: 3459 RVA: 0x0003EE32 File Offset: 0x0003D032
			public Orden(OjosExpresionController.Tipo tipoId, int prioridad, float duracion, ControllerPrioridadConfig priConfig, float target, float velocidadModIn, float velocidadModOut)
				: base(tipoId, prioridad, duracion, priConfig, false)
			{
				this.target = target;
				this.tiempoModIn = velocidadModIn;
				this.tiempoModOut = velocidadModOut;
			}

			// Token: 0x06000D84 RID: 3460 RVA: 0x0003EE58 File Offset: 0x0003D058
			private void Primer(OjosExpresionController dataUpdate)
			{
				switch (base.tipoId)
				{
				case OjosExpresionController.Tipo.cerrar:
					this.m_holderDeMods = dataUpdate.m_modsDeParpadeo;
					return;
				case OjosExpresionController.Tipo.guiñarR:
					this.m_holderDeMods = dataUpdate.m_modsDeGuiñoR;
					return;
				case OjosExpresionController.Tipo.guiñarL:
					this.m_holderDeMods = dataUpdate.m_modsDeGuiñoL;
					return;
				case OjosExpresionController.Tipo.achiquitar:
					this.m_holderDeMods = dataUpdate.m_modsDeAchiquitar;
					return;
				case OjosExpresionController.Tipo.agrandar:
					this.m_holderDeMods = dataUpdate.m_modsDeAgrandar;
					return;
				default:
					throw new ArgumentOutOfRangeException(base.tipoId.ToString());
				}
			}

			// Token: 0x06000D85 RID: 3461 RVA: 0x00003B39 File Offset: 0x00001D39
			protected override void OnDetenidaPorUsuario(OjosExpresionController dataUpdate)
			{
			}

			// Token: 0x06000D86 RID: 3462 RVA: 0x0003EEE2 File Offset: 0x0003D0E2
			protected override bool OnTerminando(OjosExpresionController dataUpdate, bool primerUpdate, OjosExpresionController.Orden ordenEsperandoDetencion)
			{
				if (OjosExpresionController.Orden.Get(dataUpdate, base.tipoId) <= 0f)
				{
					if (this.m_holderDeMods != null)
					{
						this.m_holderDeMods.Reset();
					}
					return true;
				}
				OjosExpresionController.Orden.Set(dataUpdate, 0f, base.tipoId);
				return false;
			}

			// Token: 0x06000D87 RID: 3463 RVA: 0x00003B39 File Offset: 0x00001D39
			protected override void OnTerminada(OjosExpresionController dataUpdate, bool abruptamente)
			{
			}

			// Token: 0x06000D88 RID: 3464 RVA: 0x0003EF20 File Offset: 0x0003D120
			protected override bool UpdateOrden(OjosExpresionController dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino())
				{
					OjosExpresionController.Orden.Set(dataUpdate, 0f, base.tipoId);
					return false;
				}
				if (esPrimerUpdate)
				{
					this.Primer(dataUpdate);
				}
				this.m_holderDeMods.tiempoIn.valor.valor = this.tiempoModIn;
				this.m_holderDeMods.tiempoOut.valor.valor = this.tiempoModOut;
				OjosExpresionController.Orden.Set(dataUpdate, this.target, base.tipoId);
				return true;
			}

			// Token: 0x06000D89 RID: 3465 RVA: 0x0003EF9C File Offset: 0x0003D19C
			private static float Get(OjosExpresionController dataUpdate, OjosExpresionController.Tipo tipoId)
			{
				ControlDeParpadeoValores currents = dataUpdate.m_control.currents;
				switch (tipoId)
				{
				case OjosExpresionController.Tipo.cerrar:
					return currents.blink;
				case OjosExpresionController.Tipo.guiñarR:
					return currents.winkR;
				case OjosExpresionController.Tipo.guiñarL:
					return currents.winkL;
				case OjosExpresionController.Tipo.achiquitar:
					return currents.squint;
				case OjosExpresionController.Tipo.agrandar:
					return currents.enlarge;
				default:
					throw new ArgumentOutOfRangeException(tipoId.ToString());
				}
			}

			// Token: 0x06000D8A RID: 3466 RVA: 0x0003F008 File Offset: 0x0003D208
			private static void Set(OjosExpresionController dataUpdate, float target, OjosExpresionController.Tipo tipoId)
			{
				ControlDeParpadeoValores targets = dataUpdate.m_control.targets;
				switch (tipoId)
				{
				case OjosExpresionController.Tipo.cerrar:
					targets.blink = target;
					break;
				case OjosExpresionController.Tipo.guiñarR:
					targets.winkR = target;
					break;
				case OjosExpresionController.Tipo.guiñarL:
					targets.winkL = target;
					break;
				case OjosExpresionController.Tipo.achiquitar:
					targets.squint = target;
					break;
				case OjosExpresionController.Tipo.agrandar:
					targets.enlarge = target;
					break;
				default:
					throw new ArgumentOutOfRangeException(tipoId.ToString());
				}
				dataUpdate.m_control.targets = targets;
			}

			// Token: 0x06000D8B RID: 3467 RVA: 0x00003B39 File Offset: 0x00001D39
			protected override void OnStart(OjosExpresionController dataUpdate)
			{
			}

			// Token: 0x04000B8F RID: 2959
			public float tiempoModIn;

			// Token: 0x04000B90 RID: 2960
			public float tiempoModOut;

			// Token: 0x04000B91 RID: 2961
			public float target;

			// Token: 0x04000B92 RID: 2962
			private ControlDeParpadeo.ModsDeModificadoresHolder m_holderDeMods;
		}

		// Token: 0x0200025E RID: 606
		public enum Tipo
		{
			// Token: 0x04000B94 RID: 2964
			cerrar,
			// Token: 0x04000B95 RID: 2965
			guiñarR,
			// Token: 0x04000B96 RID: 2966
			guiñarL,
			// Token: 0x04000B97 RID: 2967
			achiquitar,
			// Token: 0x04000B98 RID: 2968
			agrandar
		}
	}
}
