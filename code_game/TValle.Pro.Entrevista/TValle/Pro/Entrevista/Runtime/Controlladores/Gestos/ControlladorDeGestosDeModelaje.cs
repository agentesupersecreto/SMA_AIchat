using System;
using Assets.Base.BeachGirl.Runtime;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using Assets._ReusableScripts.Globales.Updater;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Controlladores.Gestos
{
	// Token: 0x0200010B RID: 267
	public class ControlladorDeGestosDeModelaje : ControllerColaDePrioridadBase<ControlladorDeGestosDeModelaje.Estado, ControlladorDeGestosDeModelaje.Orden, ControlladorDeGestosDeModelaje.Cola, ControlladorDeGestosDeModelaje, int>
	{
		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000905 RID: 2309 RVA: 0x00034C53 File Offset: 0x00032E53
		protected override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.lateUpdate2);
			}
		}

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x00034C5B File Offset: 0x00032E5B
		protected override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x00034C60 File Offset: 0x00032E60
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ControladorDeGestosConCabeza = this.GetComponentEnRoot(false);
			this.m_ControladorDeGestosConHombros = this.GetComponentEnRoot(false);
			this.m_ControlladorDeGestosFacialesEmocionales = this.GetComponentEnRoot(false);
			this.m_OjosExpresionController = this.GetComponentEnRoot(false);
			if (this.m_ControlladorDeGestosFacialesEmocionales == null)
			{
				throw new ArgumentNullException("m_ControlladorDeGestosFacialesEmocionales", "m_ControlladorDeGestosFacialesEmocionales null reference.");
			}
			if (this.m_ControladorDeGestosConHombros == null)
			{
				throw new ArgumentNullException("m_ControladorDeGestosConHombros", "m_ControladorDeGestosConHombros null reference.");
			}
			if (this.m_ControladorDeGestosConCabeza == null)
			{
				throw new ArgumentNullException("m_ControladorDeGestosConCabeza", "m_ControladorDeGestosConCabeza null reference.");
			}
			if (this.m_OjosExpresionController == null)
			{
				throw new ArgumentNullException("m_OjosExpresionController", "m_OjosExpresionController null reference.");
			}
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x00034D20 File Offset: 0x00032F20
		private void GetTiposDeAnimacion(ControlladorDeGestosDeModelaje.TipoDeExpresion tipoDeExpresion, int experience, out TipoDeGestoDeCabeza tipoCabeza, out TipoDeGestoDeHombro tipoHombros, out ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipoExpresionA, out ControlladorDeGestosFacialesEmocionales.TipoDeExpresion? tipoExpresionB, out float tipoCabezaAmplitudMod, out float tipoHombrosAmplitudMod, out float tipoExpresionAW, out float? tipoExpresionBW, out bool expresarUsandoBoca, out float ojosSize)
		{
			tipoExpresionB = null;
			tipoExpresionBW = null;
			switch (tipoDeExpresion)
			{
			case ControlladorDeGestosDeModelaje.TipoDeExpresion.happy:
				switch (experience)
				{
				case 0:
					tipoCabeza = TipoDeGestoDeCabeza.placer;
					tipoCabezaAmplitudMod = 0.1f;
					tipoHombros = TipoDeGestoDeHombro.unoArribaOtroAbajo;
					tipoHombrosAmplitudMod = 0f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria;
					tipoExpresionAW = 0.8f;
					expresarUsandoBoca = true;
					ojosSize = 0f;
					return;
				case 1:
					tipoCabeza = TipoDeGestoDeCabeza.placer;
					tipoCabezaAmplitudMod = 0.45f;
					tipoHombros = TipoDeGestoDeHombro.unoArribaOtroAbajo;
					tipoHombrosAmplitudMod = 0.25f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria;
					tipoExpresionAW = 0.9f;
					expresarUsandoBoca = false;
					ojosSize = 0.2f;
					return;
				case 2:
					tipoCabeza = TipoDeGestoDeCabeza.placer;
					tipoCabezaAmplitudMod = 0.75f;
					tipoHombros = TipoDeGestoDeHombro.unoArribaOtroAbajo;
					tipoHombrosAmplitudMod = 0.4f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria;
					tipoExpresionAW = 1f;
					expresarUsandoBoca = false;
					ojosSize = 0.4f;
					return;
				default:
					throw new ArgumentOutOfRangeException(experience.ToString());
				}
				break;
			case ControlladorDeGestosDeModelaje.TipoDeExpresion.sad:
				switch (experience)
				{
				case 0:
					tipoCabeza = TipoDeGestoDeCabeza.dolor;
					tipoCabezaAmplitudMod = 0.1f;
					tipoHombros = TipoDeGestoDeHombro.achiquitar;
					tipoHombrosAmplitudMod = 0f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor;
					tipoExpresionAW = 0.5f;
					tipoExpresionB = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
					tipoExpresionBW = new float?(0.5f);
					expresarUsandoBoca = false;
					ojosSize = 0f;
					return;
				case 1:
					tipoCabeza = TipoDeGestoDeCabeza.dolor;
					tipoCabezaAmplitudMod = 0.333f;
					tipoHombros = TipoDeGestoDeHombro.achiquitar;
					tipoHombrosAmplitudMod = 0.45f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor;
					tipoExpresionAW = 0.45f;
					tipoExpresionB = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
					tipoExpresionBW = new float?(0.45f);
					expresarUsandoBoca = false;
					ojosSize = -0.1f;
					return;
				case 2:
					tipoCabeza = TipoDeGestoDeCabeza.dolor;
					tipoCabezaAmplitudMod = 0.666f;
					tipoHombros = TipoDeGestoDeHombro.achiquitar;
					tipoHombrosAmplitudMod = 0.75f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor;
					tipoExpresionAW = 0.4f;
					tipoExpresionB = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
					tipoExpresionBW = new float?(0.4f);
					expresarUsandoBoca = false;
					ojosSize = -0.2f;
					return;
				default:
					throw new ArgumentOutOfRangeException(experience.ToString());
				}
				break;
			case ControlladorDeGestosDeModelaje.TipoDeExpresion.angry:
				switch (experience)
				{
				case 0:
					tipoCabeza = TipoDeGestoDeCabeza.dolor;
					tipoCabezaAmplitudMod = 0.1f;
					tipoHombros = TipoDeGestoDeHombro.diagonales;
					tipoHombrosAmplitudMod = 0f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia;
					tipoExpresionAW = 1f;
					expresarUsandoBoca = true;
					ojosSize = 0f;
					return;
				case 1:
					tipoCabeza = TipoDeGestoDeCabeza.dolor;
					tipoCabezaAmplitudMod = 0.33f;
					tipoHombros = TipoDeGestoDeHombro.diagonales;
					tipoHombrosAmplitudMod = 0.1f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia;
					tipoExpresionAW = 0.833f;
					expresarUsandoBoca = false;
					ojosSize = -0.2f;
					return;
				case 2:
					tipoCabeza = TipoDeGestoDeCabeza.dolor;
					tipoCabezaAmplitudMod = 0.5f;
					tipoHombros = TipoDeGestoDeHombro.diagonales;
					tipoHombrosAmplitudMod = 0.25f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia;
					tipoExpresionAW = 0.666f;
					expresarUsandoBoca = false;
					ojosSize = -0.4f;
					return;
				default:
					throw new ArgumentOutOfRangeException(experience.ToString());
				}
				break;
			case ControlladorDeGestosDeModelaje.TipoDeExpresion.naughty:
				switch (experience)
				{
				case 0:
					tipoCabeza = TipoDeGestoDeCabeza.traviesa;
					tipoCabezaAmplitudMod = 0.1f;
					tipoHombros = TipoDeGestoDeHombro.unoAtrasOtroAdelante;
					tipoHombrosAmplitudMod = 0f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer;
					tipoExpresionAW = 0.5f;
					tipoExpresionB = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo);
					tipoExpresionBW = new float?(0.05f);
					expresarUsandoBoca = true;
					ojosSize = 0f;
					return;
				case 1:
					tipoCabeza = TipoDeGestoDeCabeza.traviesa;
					tipoCabezaAmplitudMod = 0.45f;
					tipoHombros = TipoDeGestoDeHombro.unoAtrasOtroAdelante;
					tipoHombrosAmplitudMod = 0.333f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer;
					tipoExpresionAW = 0.75f;
					tipoExpresionB = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo);
					tipoExpresionBW = new float?(0.1f);
					expresarUsandoBoca = false;
					ojosSize = -0.15f;
					return;
				case 2:
					tipoCabeza = TipoDeGestoDeCabeza.traviesa;
					tipoCabezaAmplitudMod = 0.8f;
					tipoHombros = TipoDeGestoDeHombro.unoAtrasOtroAdelante;
					tipoHombrosAmplitudMod = 0.5f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer;
					tipoExpresionAW = 1f;
					tipoExpresionB = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo);
					tipoExpresionBW = new float?(0.2f);
					expresarUsandoBoca = false;
					ojosSize = -0.3f;
					return;
				default:
					throw new ArgumentOutOfRangeException(experience.ToString());
				}
				break;
			case ControlladorDeGestosDeModelaje.TipoDeExpresion.shy:
				switch (experience)
				{
				case 0:
					tipoCabeza = TipoDeGestoDeCabeza.timidez;
					tipoCabezaAmplitudMod = 0.1f;
					tipoHombros = TipoDeGestoDeHombro.achiquitar;
					tipoHombrosAmplitudMod = 0f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor;
					tipoExpresionAW = 0.4f;
					tipoExpresionB = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo);
					tipoExpresionBW = new float?(0.6f);
					expresarUsandoBoca = true;
					ojosSize = 0f;
					return;
				case 1:
					tipoCabeza = TipoDeGestoDeCabeza.timidez;
					tipoCabezaAmplitudMod = 0.45f;
					tipoHombros = TipoDeGestoDeHombro.achiquitar;
					tipoHombrosAmplitudMod = 0.1f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor;
					tipoExpresionAW = 0.5f;
					tipoExpresionB = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo);
					tipoExpresionBW = new float?(0.5f);
					expresarUsandoBoca = false;
					ojosSize = -0.1f;
					return;
				case 2:
					tipoCabeza = TipoDeGestoDeCabeza.timidez;
					tipoCabezaAmplitudMod = 0.75f;
					tipoHombros = TipoDeGestoDeHombro.achiquitar;
					tipoHombrosAmplitudMod = 0.33f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor;
					tipoExpresionAW = 0.6f;
					tipoExpresionB = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo);
					tipoExpresionBW = new float?(0.4f);
					expresarUsandoBoca = false;
					ojosSize = -0.2f;
					return;
				default:
					throw new ArgumentOutOfRangeException(experience.ToString());
				}
				break;
			case ControlladorDeGestosDeModelaje.TipoDeExpresion.attitude:
				switch (experience)
				{
				case 0:
					tipoCabeza = TipoDeGestoDeCabeza.grandeza;
					tipoCabezaAmplitudMod = 0.1f;
					tipoHombros = TipoDeGestoDeHombro.diagonales;
					tipoHombrosAmplitudMod = 0f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia;
					tipoExpresionAW = 0.25f;
					tipoExpresionB = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
					tipoExpresionBW = new float?(0.75f);
					expresarUsandoBoca = false;
					ojosSize = 0f;
					return;
				case 1:
					tipoCabeza = TipoDeGestoDeCabeza.grandeza;
					tipoCabezaAmplitudMod = 0.4f;
					tipoHombros = TipoDeGestoDeHombro.diagonales;
					tipoHombrosAmplitudMod = 0.2f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia;
					tipoExpresionAW = 0.3f;
					tipoExpresionB = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
					tipoExpresionBW = new float?(0.83f);
					expresarUsandoBoca = false;
					ojosSize = -0.25f;
					return;
				case 2:
					tipoCabeza = TipoDeGestoDeCabeza.grandeza;
					tipoCabezaAmplitudMod = 0.75f;
					tipoHombros = TipoDeGestoDeHombro.diagonales;
					tipoHombrosAmplitudMod = 0.4f;
					tipoExpresionA = ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia;
					tipoExpresionAW = 0.35f;
					tipoExpresionB = new ControlladorDeGestosFacialesEmocionales.TipoDeExpresion?(ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer);
					tipoExpresionBW = new float?(1f);
					expresarUsandoBoca = true;
					ojosSize = -0.5f;
					return;
				default:
					throw new ArgumentOutOfRangeException(experience.ToString());
				}
				break;
			default:
				throw new ArgumentOutOfRangeException(tipoDeExpresion.ToString());
			}
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x00035324 File Offset: 0x00033524
		public bool Gestuar(ControlladorDeGestosDeModelaje.TipoDeExpresion tipo, float duracion, int experience)
		{
			bool flag = false;
			ControlladorDeGestosDeModelaje.Orden orden;
			bool flag2;
			bool flag3;
			if (!base.VerificarSiPuedeEjecutarse(out orden, out flag2, 0, 0, ControllerPrioridadConfig.interrumpir, out flag3, ref flag, false))
			{
				return false;
			}
			ControlladorDeGestosDeModelaje.Orden orden2 = new ControlladorDeGestosDeModelaje.Orden(tipo, experience, duracion);
			base.Procesar(orden == null, flag2, ControllerPrioridadConfig.interrumpir, orden2, false, false);
			return true;
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x00035364 File Offset: 0x00033564
		public override int ParseIndexToTipoId(int index)
		{
			return index;
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00035367 File Offset: 0x00033567
		public override int ParseTipoIdToindex(int tipoId)
		{
			return tipoId;
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x0003536A File Offset: 0x0003356A
		protected override ControlladorDeGestosDeModelaje ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x0003536D File Offset: 0x0003356D
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Gestuar DebugearTipo"
			};
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00035386 File Offset: 0x00033586
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.Gestuar(this.m_DebugearTipo, this.m_duracion, this.m_exp);
		}

		// Token: 0x040004CA RID: 1226
		private ControladorDeGestosConCabeza m_ControladorDeGestosConCabeza;

		// Token: 0x040004CB RID: 1227
		private ControladorDeGestosConHombros m_ControladorDeGestosConHombros;

		// Token: 0x040004CC RID: 1228
		private ControlladorDeGestosFacialesEmocionales m_ControlladorDeGestosFacialesEmocionales;

		// Token: 0x040004CD RID: 1229
		private OjosExpresionController m_OjosExpresionController;

		// Token: 0x040004CE RID: 1230
		[Header("***Debbuging")]
		[SerializeField]
		private ControlladorDeGestosDeModelaje.TipoDeExpresion m_DebugearTipo;

		// Token: 0x040004CF RID: 1231
		[SerializeField]
		private int m_exp;

		// Token: 0x040004D0 RID: 1232
		[SerializeField]
		private float m_duracion = 30f;

		// Token: 0x0200027C RID: 636
		public enum TipoDeExpresion
		{
			// Token: 0x04000BB1 RID: 2993
			[LabelLocalizado("Happy", "US")]
			happy,
			// Token: 0x04000BB2 RID: 2994
			[LabelLocalizado("Sad", "US")]
			sad,
			// Token: 0x04000BB3 RID: 2995
			[LabelLocalizado("Angry", "US")]
			angry,
			// Token: 0x04000BB4 RID: 2996
			[LabelLocalizado("Naughty", "US")]
			naughty,
			// Token: 0x04000BB5 RID: 2997
			[LabelLocalizado("Shy", "US")]
			shy,
			// Token: 0x04000BB6 RID: 2998
			[LabelLocalizado("Attitude", "US")]
			attitude
		}

		// Token: 0x0200027D RID: 637
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<ControlladorDeGestosDeModelaje.Estado, ControlladorDeGestosDeModelaje.Orden, ControlladorDeGestosDeModelaje.Cola, ControlladorDeGestosDeModelaje, int>.OrdenBaseDeControllador
		{
			// Token: 0x0600116A RID: 4458 RVA: 0x0005167B File Offset: 0x0004F87B
			public Orden(ControlladorDeGestosDeModelaje.TipoDeExpresion tipo, int experience, float duracion)
				: base(0, duracion)
			{
				this.m_tipo = tipo;
				this.m_experience = experience;
			}

			// Token: 0x0600116B RID: 4459 RVA: 0x00051693 File Offset: 0x0004F893
			protected override void OnStart(ControlladorDeGestosDeModelaje dataUpdate)
			{
			}

			// Token: 0x0600116C RID: 4460 RVA: 0x00051698 File Offset: 0x0004F898
			protected override bool UpdateOrden(ControlladorDeGestosDeModelaje dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino())
				{
					return false;
				}
				if (esPrimerUpdate)
				{
					dataUpdate.GetTiposDeAnimacion(this.m_tipo, this.m_experience, out this.tipoCabeza, out this.tipoHombros, out this.tipoExpresionA, out this.tipoExpresionB, out this.tipoCabezaAmplitudMod, out this.tipoHombrosAmplitudMod, out this.tipoExpresionAW, out this.tipoExpresionBW, out this.expresarUsandoBoca, out this.ojosSize);
				}
				if (this.tipoCabezaAmplitudMod > 0f && this.m_cabezaOrden == null && dataUpdate.m_ControladorDeGestosConCabeza.GestuarConPausa(this.tipoCabeza, this.tipoCabezaAmplitudMod, base.tiempoRestante, ControllerPrioridadConfig.interrumpir, false))
				{
					this.m_cabezaOrden = dataUpdate.m_ControladorDeGestosConCabeza.justProcesedOrder;
				}
				if (this.tipoHombrosAmplitudMod > 0f && this.m_hombrosOrden == null && dataUpdate.m_ControladorDeGestosConHombros.GestuarConPausa(this.tipoHombros, this.tipoHombrosAmplitudMod, base.tiempoRestante, ControllerPrioridadConfig.interrumpir, false))
				{
					this.m_hombrosOrden = dataUpdate.m_ControladorDeGestosConHombros.justProcesedOrder;
				}
				if (this.m_gestosFacialesEmocionalesOrdenA == null && dataUpdate.m_ControlladorDeGestosFacialesEmocionales.Cambiar(this.tipoExpresionA, base.tiempoRestante, this.tipoExpresionAW, true, new bool?(this.expresarUsandoBoca), new float?((float)25)))
				{
					this.m_gestosFacialesEmocionalesOrdenA = dataUpdate.m_ControlladorDeGestosFacialesEmocionales.justProcesedOrder;
				}
				if (this.tipoExpresionB != null && this.m_gestosFacialesEmocionalesOrdenB == null && dataUpdate.m_ControlladorDeGestosFacialesEmocionales.Cambiar(this.tipoExpresionB.Value, base.tiempoRestante, this.tipoExpresionBW.Value, true, new bool?(this.expresarUsandoBoca), null))
				{
					this.m_gestosFacialesEmocionalesOrdenB = dataUpdate.m_ControlladorDeGestosFacialesEmocionales.justProcesedOrder;
				}
				if (this.tipoExpresionB == null)
				{
					dataUpdate.m_ControlladorDeGestosFacialesEmocionales.ExagerarYSuprimirOtros(this.tipoExpresionA, base.tiempoRestante, 1f, 1f, 0f, null);
				}
				else
				{
					dataUpdate.m_ControlladorDeGestosFacialesEmocionales.ExagerarYSuprimirOtros(this.tipoExpresionA, this.tipoExpresionB.Value, base.tiempoRestante, 1f, 1f, 1f, 0f, null);
				}
				if (this.ojosSize != 0f && this.m_ojosOrden == null)
				{
					if (this.ojosSize > 0f)
					{
						if (dataUpdate.m_OjosExpresionController.Cambiar(OjosExpresionController.Tipo.agrandar, 999, base.tiempoRestante, ControllerPrioridadConfig.interrumpir, 100f * this.ojosSize, 0.5f, 0.5f))
						{
							this.m_ojosOrden = dataUpdate.m_OjosExpresionController.justProcesedOrder;
						}
					}
					else if (dataUpdate.m_OjosExpresionController.Cambiar(OjosExpresionController.Tipo.achiquitar, 999, base.tiempoRestante, ControllerPrioridadConfig.interrumpir, 100f * this.ojosSize * -1f, 0.5f, 0.5f))
					{
						this.m_ojosOrden = dataUpdate.m_OjosExpresionController.justProcesedOrder;
					}
				}
				return true;
			}

			// Token: 0x0600116D RID: 4461 RVA: 0x00051970 File Offset: 0x0004FB70
			protected override void OnDetenidaPorUsuario(ControlladorDeGestosDeModelaje dataUpdate)
			{
				dataUpdate.m_ControladorDeGestosConCabeza.TryDetenerOrden(this.m_cabezaOrden);
				dataUpdate.m_ControladorDeGestosConHombros.TryDetenerOrden(this.m_hombrosOrden);
				dataUpdate.m_ControlladorDeGestosFacialesEmocionales.TryDetenerOrden(this.m_gestosFacialesEmocionalesOrdenA);
				dataUpdate.m_ControlladorDeGestosFacialesEmocionales.TryDetenerOrden(this.m_gestosFacialesEmocionalesOrdenB);
				dataUpdate.m_OjosExpresionController.TryDetenerOrden(this.m_ojosOrden);
			}

			// Token: 0x0600116E RID: 4462 RVA: 0x000519D7 File Offset: 0x0004FBD7
			protected override bool OnTerminando(ControlladorDeGestosDeModelaje dataUpdate, bool primerUpdate, ControlladorDeGestosDeModelaje.Orden ordenEsperandoDetencion)
			{
				return true;
			}

			// Token: 0x0600116F RID: 4463 RVA: 0x000519DA File Offset: 0x0004FBDA
			protected override void OnTerminada(ControlladorDeGestosDeModelaje dataUpdate, bool abruptamente)
			{
			}

			// Token: 0x04000BB7 RID: 2999
			private ControlladorDeGestosDeModelaje.TipoDeExpresion m_tipo;

			// Token: 0x04000BB8 RID: 3000
			private int m_experience;

			// Token: 0x04000BB9 RID: 3001
			private IOrdenDeController m_cabezaOrden;

			// Token: 0x04000BBA RID: 3002
			private IOrdenDeController m_hombrosOrden;

			// Token: 0x04000BBB RID: 3003
			private IOrdenDeController m_gestosFacialesEmocionalesOrdenA;

			// Token: 0x04000BBC RID: 3004
			private IOrdenDeController m_gestosFacialesEmocionalesOrdenB;

			// Token: 0x04000BBD RID: 3005
			private IOrdenDeController m_ojosOrden;

			// Token: 0x04000BBE RID: 3006
			private TipoDeGestoDeCabeza tipoCabeza;

			// Token: 0x04000BBF RID: 3007
			private TipoDeGestoDeHombro tipoHombros;

			// Token: 0x04000BC0 RID: 3008
			private ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipoExpresionA;

			// Token: 0x04000BC1 RID: 3009
			private ControlladorDeGestosFacialesEmocionales.TipoDeExpresion? tipoExpresionB;

			// Token: 0x04000BC2 RID: 3010
			private float tipoCabezaAmplitudMod;

			// Token: 0x04000BC3 RID: 3011
			private float tipoHombrosAmplitudMod;

			// Token: 0x04000BC4 RID: 3012
			private float tipoExpresionAW;

			// Token: 0x04000BC5 RID: 3013
			private float? tipoExpresionBW;

			// Token: 0x04000BC6 RID: 3014
			private bool expresarUsandoBoca;

			// Token: 0x04000BC7 RID: 3015
			private float ojosSize;
		}

		// Token: 0x0200027E RID: 638
		public sealed class Estado : ControllerColaDePrioridadBase<ControlladorDeGestosDeModelaje.Estado, ControlladorDeGestosDeModelaje.Orden, ControlladorDeGestosDeModelaje.Cola, ControlladorDeGestosDeModelaje, int>.StadoBase
		{
		}

		// Token: 0x0200027F RID: 639
		public sealed class Cola : ControllerColaDePrioridadBase<ControlladorDeGestosDeModelaje.Estado, ControlladorDeGestosDeModelaje.Orden, ControlladorDeGestosDeModelaje.Cola, ControlladorDeGestosDeModelaje, int>.ColasBase
		{
		}
	}
}
