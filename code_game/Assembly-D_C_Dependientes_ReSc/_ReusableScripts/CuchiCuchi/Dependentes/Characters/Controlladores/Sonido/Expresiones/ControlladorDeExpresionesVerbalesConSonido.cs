using System;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime;
using Assets.TValle.BeachGirl.Runtime.Sonidos.Characters;
using Assets.TValle.BeachGirl.Runtime.Sonidos.Characters.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Respiracion;
using Assets._ReusableScripts.Respiracion.Sonidos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores.Sonido.Expresiones
{
	// Token: 0x02000246 RID: 582
	public sealed class ControlladorDeExpresionesVerbalesConSonido : ControllerColaDePrioridadBase<ControlladorDeExpresionesVerbalesConSonido.Stado, ControlladorDeExpresionesVerbalesConSonido.Orden, ControlladorDeExpresionesVerbalesConSonido.Colas, ControlladorDeExpresionesVerbalesConSonido, int>, ICharacterPuedeHablar
	{
		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06000F65 RID: 3941 RVA: 0x0000B284 File Offset: 0x00009484
		protected override GlobalUpdater.UpdateType? updateTypeAutomatico
		{
			get
			{
				return new GlobalUpdater.UpdateType?(GlobalUpdater.UpdateType.update1);
			}
		}

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x06000F66 RID: 3942 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override int cantidadDeEstados
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x06000F67 RID: 3943 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int cantidadMaximaEnCola
		{
			get
			{
				return 0;
			}
		}

		// Token: 0x06000F68 RID: 3944 RVA: 0x0004448B File Offset: 0x0004268B
		public bool PuedeIntentarHablar(out bool duracionEsIndefinida)
		{
			duracionEsIndefinida = false;
			return !base.currentStado.AlgunaEjecutandose();
		}

		// Token: 0x06000F69 RID: 3945 RVA: 0x0004448B File Offset: 0x0004268B
		public bool PuedeHablarConClaridad(out bool duracionEsIndefinida)
		{
			duracionEsIndefinida = false;
			return !base.currentStado.AlgunaEjecutandose();
		}

		// Token: 0x06000F6A RID: 3946 RVA: 0x000444A0 File Offset: 0x000426A0
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_barkUI = this.GetComponentEnCharacter(false);
			if (this.m_barkUI == null)
			{
				throw new ArgumentNullException("m_barkUI", "m_barkUI null reference.");
			}
			this.m_RespiracionEngine = this.GetComponentEnRoot(false);
			if (this.m_RespiracionEngine == null)
			{
				throw new ArgumentNullException("m_RespiracionEngine", "m_RespiracionEngine null reference.");
			}
			this.m_ControladorDeGestosDeBoca = this.GetComponentEnRoot(false);
			if (this.m_ControladorDeGestosDeBoca == null)
			{
				throw new ArgumentNullException("m_ControladorDeGestosDeBoca", "m_ControladorDeGestosDeBoca null reference.");
			}
			this.m_Conversador = this.GetComponentEnRoot(false);
			if (this.m_Conversador == null)
			{
				throw new ArgumentNullException("m_Conversador", "m_Conversador null reference.");
			}
			this.m_SonidoDeRespiracion = this.GetComponentEnRoot(false);
			if (this.m_SonidoDeRespiracion == null)
			{
				throw new ArgumentNullException("m_SonidoDeRespiracion", "m_SonidoDeRespiracion null reference.");
			}
			this.m_CharacterPitchDeExpulsiones = this.GetComponentEnRoot(false);
			if (this.m_CharacterPitchDeExpulsiones == null)
			{
				throw new ArgumentNullException("m_CharacterPitchDeExpulsiones", "m_CharacterPitchDeExpulsiones null reference.");
			}
			if (this.m_narizSource == null)
			{
				throw new ArgumentNullException("m_narizSource", "m_narizSource null reference.");
			}
			if (this.m_bocaSource == null)
			{
				throw new ArgumentNullException("m_bocaSource", "m_bocaSource null reference.");
			}
			this.m_narizSource.playOnAwake = (this.m_bocaSource.playOnAwake = false);
			this.m_narizSource.loop = (this.m_bocaSource.loop = false);
			this.m_otrosPuedeHalbarIgnorandoEste = (from item in this.GetComponentsEnRoot(false)
				where item != this
				select item).ToArray<ICharacterPuedeHablar>();
		}

		// Token: 0x06000F6B RID: 3947 RVA: 0x00044638 File Offset: 0x00042838
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_modDeVolumenRespiracionNasal = this.m_SonidoDeRespiracion.volumenModificableNasal.ObtenerModificadorNotNull(this);
			this.m_modDeVolumenRespiracionBucal = this.m_SonidoDeRespiracion.volumenModificableVocal.ObtenerModificadorNotNull(this);
			this.m_modificadorDeVelocidadDeDetencionDeGestosDeBoca = this.m_ControladorDeGestosDeBoca.modificableDeVelocidadDeDetencion.ObtenerModificadorNotNull(this);
			this.m_modificadorDeIgnorarOrdenesDeGestosDeBoca = this.m_ControladorDeGestosDeBoca.modificableIgnorarOrdenes.ObtenerModificadorNotNull(this);
		}

		// Token: 0x06000F6C RID: 3948 RVA: 0x000446A8 File Offset: 0x000428A8
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeFloat modDeVolumenRespiracionNasal = this.m_modDeVolumenRespiracionNasal;
			if (modDeVolumenRespiracionNasal != null)
			{
				modDeVolumenRespiracionNasal.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat modDeVolumenRespiracionBucal = this.m_modDeVolumenRespiracionBucal;
			if (modDeVolumenRespiracionBucal != null)
			{
				modDeVolumenRespiracionBucal.TryRemoverDeOwner(true);
			}
			ModificadorDeFloat modificadorDeVelocidadDeDetencionDeGestosDeBoca = this.m_modificadorDeVelocidadDeDetencionDeGestosDeBoca;
			if (modificadorDeVelocidadDeDetencionDeGestosDeBoca != null)
			{
				modificadorDeVelocidadDeDetencionDeGestosDeBoca.TryRemoverDeOwner(true);
			}
			ModificadorDeBool modificadorDeIgnorarOrdenesDeGestosDeBoca = this.m_modificadorDeIgnorarOrdenesDeGestosDeBoca;
			if (modificadorDeIgnorarOrdenesDeGestosDeBoca == null)
			{
				return;
			}
			modificadorDeIgnorarOrdenesDeGestosDeBoca.TryRemoverDeOwner(true);
		}

		// Token: 0x06000F6D RID: 3949 RVA: 0x00044708 File Offset: 0x00042908
		protected override void ControllerUpdated()
		{
			if (base.currentStado.AlgunaEjecutandose())
			{
				this.m_modDeVolumenRespiracionNasal.valor.valor = 0f;
				this.m_modDeVolumenRespiracionBucal.valor.valor = 0f;
				return;
			}
			this.m_modDeVolumenRespiracionNasal.valor.valor = 1f;
			this.m_modDeVolumenRespiracionBucal.valor.valor = 1f;
		}

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x06000F6E RID: 3950 RVA: 0x00044777 File Offset: 0x00042977
		public bool estaExpresando
		{
			get
			{
				return base.currentStado.AlgunaEjecutandose();
			}
		}

		// Token: 0x06000F6F RID: 3951 RVA: 0x00044784 File Offset: 0x00042984
		public bool PuedeExpresar()
		{
			bool flag;
			return this.m_otrosPuedeHalbarIgnorandoEste.PuedeHablarConClaridad(out flag) && !this.m_ControladorDeGestosDeBoca.Gestuandose().EsDeseoOral();
		}

		// Token: 0x06000F70 RID: 3952 RVA: 0x000447B8 File Offset: 0x000429B8
		public bool Expresar(ExpresionVerbalData mapa, int prioridad, ControllerPrioridadConfig priConfig, bool usarGestosSegundarios = false)
		{
			if (mapa == null)
			{
				throw new ArgumentNullException("mapa", "mapa null reference.");
			}
			if (!this.PuedeExpresar())
			{
				return false;
			}
			bool flag = false;
			ControlladorDeExpresionesVerbalesConSonido.Orden orden;
			bool flag2;
			bool flag3;
			if (!base.VerificarSiPuedeEjecutarse(out orden, out flag2, 0, prioridad, priConfig, out flag3, ref flag, false))
			{
				return false;
			}
			if (flag3 && !flag)
			{
				return false;
			}
			float num = mapa.Length(this.m_CharacterPitchDeExpulsiones.pitchDeVocal);
			ControlladorDeExpresionesVerbalesConSonido.Orden orden2 = new ControlladorDeExpresionesVerbalesConSonido.Orden(mapa, prioridad, num, priConfig, usarGestosSegundarios);
			base.Procesar(orden == null, flag2, priConfig, orden2, false, false);
			return true;
		}

		// Token: 0x06000F71 RID: 3953 RVA: 0x0004483A File Offset: 0x00042A3A
		protected override void OnAplicar2()
		{
			this.Expresar(this.m_mapaTesting, 1, ControllerPrioridadConfig.prioridad, this.m_usarGestosSegundariosTesting);
		}

		// Token: 0x06000F72 RID: 3954 RVA: 0x00044851 File Offset: 0x00042A51
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Test",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000F73 RID: 3955 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int ParseIndexToTipoId(int index)
		{
			return 0;
		}

		// Token: 0x06000F74 RID: 3956 RVA: 0x00002BE7 File Offset: 0x00000DE7
		public override int ParseTipoIdToindex(int tipoId)
		{
			return 0;
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x0003011F File Offset: 0x0002E31F
		protected override ControlladorDeExpresionesVerbalesConSonido ObtenerUpdateData()
		{
			return this;
		}

		// Token: 0x04000A9E RID: 2718
		[SerializeField]
		private AudioSource m_narizSource;

		// Token: 0x04000A9F RID: 2719
		[SerializeField]
		private AudioSource m_bocaSource;

		// Token: 0x04000AA0 RID: 2720
		[SerializeField]
		private Color m_colorDeLetras = new Color(0.355555f, 0.355555f, 0.355555f, 1f);

		// Token: 0x04000AA1 RID: 2721
		private ICharacterBarkUI m_barkUI;

		// Token: 0x04000AA2 RID: 2722
		private ICharacterConversador m_Conversador;

		// Token: 0x04000AA3 RID: 2723
		private RespiracionEngine m_RespiracionEngine;

		// Token: 0x04000AA4 RID: 2724
		private IControladorDeGestosDeBoca m_ControladorDeGestosDeBoca;

		// Token: 0x04000AA5 RID: 2725
		private CharacterPitchDeExpulsiones m_CharacterPitchDeExpulsiones;

		// Token: 0x04000AA6 RID: 2726
		private SonidoDeRespiracion m_SonidoDeRespiracion;

		// Token: 0x04000AA7 RID: 2727
		private ModificadorDeFloat m_modDeVolumenRespiracionNasal;

		// Token: 0x04000AA8 RID: 2728
		private ModificadorDeFloat m_modDeVolumenRespiracionBucal;

		// Token: 0x04000AA9 RID: 2729
		private ICharacterPuedeHablar[] m_otrosPuedeHalbarIgnorandoEste;

		// Token: 0x04000AAA RID: 2730
		public float gestosBucalesInVel = 0.85f;

		// Token: 0x04000AAB RID: 2731
		public float gestosBucalesOutVel = 0.333f;

		// Token: 0x04000AAC RID: 2732
		private ModificadorDeBool m_modificadorDeIgnorarOrdenesDeGestosDeBoca;

		// Token: 0x04000AAD RID: 2733
		private ModificadorDeFloat m_modificadorDeVelocidadDeDetencionDeGestosDeBoca;

		// Token: 0x04000AAE RID: 2734
		[Header("Testing")]
		[SerializeField]
		private ExpresionVerbalData m_mapaTesting;

		// Token: 0x04000AAF RID: 2735
		[SerializeField]
		private bool m_usarGestosSegundariosTesting;

		// Token: 0x02000247 RID: 583
		[Serializable]
		public sealed class Orden : ControllerColaDePrioridadBase<ControlladorDeExpresionesVerbalesConSonido.Stado, ControlladorDeExpresionesVerbalesConSonido.Orden, ControlladorDeExpresionesVerbalesConSonido.Colas, ControlladorDeExpresionesVerbalesConSonido, int>.OrdenBaseDeControllador
		{
			// Token: 0x06000F78 RID: 3960 RVA: 0x000448A7 File Offset: 0x00042AA7
			public Orden(ExpresionVerbalData mapa, int prioridad, float duracion, ControllerPrioridadConfig priConfig, bool usarGestosSegundarios)
				: base(0, prioridad, duracion, priConfig, true)
			{
				if (mapa == null)
				{
					throw new ArgumentNullException("mapa", "mapa null reference.");
				}
				this.m_mapa = mapa;
				this.m_usarGestosBucalesSegundarios = usarGestosSegundarios;
				this.usarUnscaledTime = true;
			}

			// Token: 0x06000F79 RID: 3961 RVA: 0x00002BEA File Offset: 0x00000DEA
			protected override void OnDetenidaPorUsuario(ControlladorDeExpresionesVerbalesConSonido dataUpdate)
			{
			}

			// Token: 0x06000F7A RID: 3962 RVA: 0x000066D6 File Offset: 0x000048D6
			protected override bool OnTerminando(ControlladorDeExpresionesVerbalesConSonido dataUpdate, bool primerUpdate, ControlladorDeExpresionesVerbalesConSonido.Orden ordenEsperandoDetencion)
			{
				return true;
			}

			// Token: 0x06000F7B RID: 3963 RVA: 0x000448E4 File Offset: 0x00042AE4
			protected override void OnTerminada(ControlladorDeExpresionesVerbalesConSonido dataUpdate, bool abruptamente)
			{
				this.m_lastExpresion = null;
				dataUpdate.m_narizSource.Stop();
				dataUpdate.m_bocaSource.Stop();
				dataUpdate.m_narizSource.enabled = (dataUpdate.m_bocaSource.enabled = false);
				dataUpdate.m_narizSource.playOnAwake = (dataUpdate.m_bocaSource.playOnAwake = false);
				dataUpdate.m_narizSource.loop = (dataUpdate.m_bocaSource.loop = false);
				dataUpdate.m_narizSource.clip = (dataUpdate.m_bocaSource.clip = null);
				if (this.m_usoBark)
				{
					dataUpdate.m_barkUI.Hide();
				}
				dataUpdate.m_RespiracionEngine.modoManualActivado = false;
			}

			// Token: 0x06000F7C RID: 3964 RVA: 0x00044998 File Offset: 0x00042B98
			protected override bool EsperandoFrameParaComenzar(ControlladorDeExpresionesVerbalesConSonido dataUpdate)
			{
				bool flag = base.EsperandoFrameParaComenzar(dataUpdate);
				dataUpdate.m_ControladorDeGestosDeBoca.DetenerGestos();
				dataUpdate.m_modificadorDeIgnorarOrdenesDeGestosDeBoca.valor.valor = true;
				dataUpdate.m_modificadorDeVelocidadDeDetencionDeGestosDeBoca.valor.valor = 3f;
				return dataUpdate.m_ControladorDeGestosDeBoca.AlgunaOrndeDeteniendose() || flag;
			}

			// Token: 0x06000F7D RID: 3965 RVA: 0x000449EC File Offset: 0x00042BEC
			protected override void OnStart(ControlladorDeExpresionesVerbalesConSonido dataUpdate)
			{
				dataUpdate.m_modificadorDeIgnorarOrdenesDeGestosDeBoca.valor.valor = false;
				dataUpdate.m_modificadorDeVelocidadDeDetencionDeGestosDeBoca.valor.valor = 1f;
				this.m_lastExpresion = null;
				dataUpdate.m_narizSource.Stop();
				dataUpdate.m_bocaSource.Stop();
				dataUpdate.m_narizSource.playOnAwake = (dataUpdate.m_bocaSource.playOnAwake = false);
				dataUpdate.m_narizSource.loop = (dataUpdate.m_bocaSource.loop = false);
				dataUpdate.m_bocaSource.clip = this.m_mapa.clip;
				dataUpdate.m_bocaSource.pitch = dataUpdate.m_CharacterPitchDeExpulsiones.pitchDeVocal * this.m_mapa.pitchMod;
				dataUpdate.m_bocaSource.volume = Singleton<ConfiguracionGeneralDeAudio>.instance.voice * this.m_mapa.volMod;
				dataUpdate.m_narizSource.enabled = (dataUpdate.m_bocaSource.enabled = true);
				dataUpdate.m_bocaSource.Play();
				this.m_usoBark = dataUpdate.m_barkUI.BarkPermanente(this.m_mapa.expresionEnTexto, "NONE");
				if (this.m_usoBark)
				{
					dataUpdate.m_barkUI.barkText.color = dataUpdate.m_colorDeLetras;
				}
			}

			// Token: 0x06000F7E RID: 3966 RVA: 0x00044B30 File Offset: 0x00042D30
			protected override bool UpdateOrden(ControlladorDeExpresionesVerbalesConSonido dataUpdate, bool esPrimerUpdate)
			{
				if (this.Termino())
				{
					return false;
				}
				if (dataUpdate.m_Conversador.estaConversando)
				{
					return false;
				}
				bool flag;
				if (!dataUpdate.m_otrosPuedeHalbarIgnorandoEste.PuedeHablarConClaridad(out flag))
				{
					return false;
				}
				ExpresionVerbalData.ExprecionDeBocaEnTiempo exprecionDeBocaEnTiempo = this.m_mapa.ObtenerExpresionEnTiempo(base.currentUnscaledTime * dataUpdate.m_CharacterPitchDeExpulsiones.pitchDeVocal * this.m_mapa.pitchMod);
				if (exprecionDeBocaEnTiempo == null)
				{
					throw new ArgumentNullException("currentExpresion", "currentExpresion null reference.");
				}
				if (this.m_lastExpresion != exprecionDeBocaEnTiempo)
				{
					ExpresionVerbalData.ExprecionDeBocaEnTiempo lastExpresion = this.m_lastExpresion;
					float num = exprecionDeBocaEnTiempo.duration / (dataUpdate.m_CharacterPitchDeExpulsiones.pitchDeVocal * this.m_mapa.pitchMod);
					TiposDeGestosDeBoca tiposDeGestosDeBoca = ((this.m_usarGestosBucalesSegundarios && exprecionDeBocaEnTiempo.gestoSegundario != TiposDeGestosDeBoca.None) ? exprecionDeBocaEnTiempo.gestoSegundario : exprecionDeBocaEnTiempo.gestoPrimario);
					if (tiposDeGestosDeBoca != TiposDeGestosDeBoca.None)
					{
						dataUpdate.m_ControladorDeGestosDeBoca.Gestuar(tiposDeGestosDeBoca, Random.Range(0.7f, 1f).OutPow(2f), int.MaxValue, ControllerPrioridadConfig.interrumpir, num, false, () => !this.Termino(), dataUpdate.gestosBucalesInVel, dataUpdate.gestosBucalesOutVel);
					}
					else if (this.m_lastExpresion != null)
					{
						TiposDeGestosDeBoca tiposDeGestosDeBoca2 = ((this.m_usarGestosBucalesSegundarios && this.m_lastExpresion.gestoSegundario != TiposDeGestosDeBoca.None) ? this.m_lastExpresion.gestoSegundario : this.m_lastExpresion.gestoPrimario);
						if (tiposDeGestosDeBoca2 != TiposDeGestosDeBoca.None)
						{
							dataUpdate.m_ControladorDeGestosDeBoca.DetenerGesto(tiposDeGestosDeBoca2);
						}
					}
					this.m_lastExpresion = exprecionDeBocaEnTiempo;
					dataUpdate.m_RespiracionEngine.modoManualActivado = true;
					dataUpdate.m_RespiracionEngine.modoManualConfig = new RespiracionEngine.ModoManualConfig
					{
						duracionDeTipoDeRespiracion = num,
						modo = ((exprecionDeBocaEnTiempo.modoDeRespiracion == ExpresionVerbalData.ModoDeRespiracion.bucal) ? ModoDeRespiracion.boca : ModoDeRespiracion.nasal),
						tipo = ((exprecionDeBocaEnTiempo.tipoDeRespiracion == ExpresionVerbalData.TipoDeRespiracion.exhalacion) ? TipoDeRespiracion.exhalacion : TipoDeRespiracion.inhalacion),
						frequenciaDeRespiracion = 1f
					};
				}
				return true;
			}

			// Token: 0x04000AB0 RID: 2736
			[ReadOnlyUI]
			[SerializeField]
			private bool m_usarGestosBucalesSegundarios;

			// Token: 0x04000AB1 RID: 2737
			[ReadOnlyUI]
			[SerializeField]
			private ExpresionVerbalData m_mapa;

			// Token: 0x04000AB2 RID: 2738
			[ReadOnlyUI]
			[SerializeField]
			private ExpresionVerbalData.ExprecionDeBocaEnTiempo m_lastExpresion;

			// Token: 0x04000AB3 RID: 2739
			[NonSerialized]
			private bool m_usoBark;
		}

		// Token: 0x02000248 RID: 584
		public sealed class Colas : ControllerColaDePrioridadBase<ControlladorDeExpresionesVerbalesConSonido.Stado, ControlladorDeExpresionesVerbalesConSonido.Orden, ControlladorDeExpresionesVerbalesConSonido.Colas, ControlladorDeExpresionesVerbalesConSonido, int>.ColasBase
		{
		}

		// Token: 0x02000249 RID: 585
		public sealed class Stado : ControllerColaDePrioridadBase<ControlladorDeExpresionesVerbalesConSonido.Stado, ControlladorDeExpresionesVerbalesConSonido.Orden, ControlladorDeExpresionesVerbalesConSonido.Colas, ControlladorDeExpresionesVerbalesConSonido, int>.StadoBase
		{
		}
	}
}
