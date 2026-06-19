using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos.Abstract;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos.Clases;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos
{
	// Token: 0x0200032E RID: 814
	public class ReactorDeBarkingBasicoV2DeEmocionRecibida : ReactorDeBarkingBasicoConHandlerDeInteraccionEstimulante
	{
		// Token: 0x06001494 RID: 5268 RVA: 0x0006221C File Offset: 0x0006041C
		protected override void OnValidateUnityEvent()
		{
			base.OnValidateUnityEvent();
			float num = 1f;
			num *= this.m_CambioDeEstimulada.onChangedModV3;
			num *= this.m_CambioDeEstimulante.onChangedModV3;
			num *= this.m_CambioDeReaccion.onChangedModV3;
			num *= this.m_CambioDeTipoDeEstimulo.onChangedModV3;
			float num2 = this.baseConfig.coolDownGeneral * this.nextCoolDownMod;
			this.m_editorMinCoolDownPorCambiosDeCalculoAprox = num2 / num;
			this.m_editorMaxProbabilidadPorCambiosDeCalculoAprox = this.baseConfig.probabilidadPorSegundo * num;
		}

		// Token: 0x06001495 RID: 5269 RVA: 0x0006229C File Offset: 0x0006049C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ConsentForzado = this.GetComponentEnRoot(false);
			if (this.m_ConsentForzado == null)
			{
				throw new ArgumentNullException("m_ConsentForzado", "m_ConsentForzado null reference.");
			}
			this.m_DesHielo = this.GetComponentEnRoot(false);
			if (this.m_DesHielo == null)
			{
				throw new ArgumentNullException("m_DesHielo", "m_DesHielo null reference.");
			}
			this.m_CambioDeEstimulada.Init(this);
			this.m_CambioDeEstimulante.Init(this);
			this.m_CambioDeReaccion.Init(this);
			this.m_CambioDeTipoDeEstimulo.Init(this);
		}

		// Token: 0x06001496 RID: 5270 RVA: 0x00062335 File Offset: 0x00060535
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_ignorandoDiaglodosCortosEnTipoDeEstimulo = new HashSet<int>(this.m_ignorarDiaglodosCortosEnTipoDeEstimulo.Cast<int>());
		}

		// Token: 0x06001497 RID: 5271 RVA: 0x00062354 File Offset: 0x00060554
		protected override bool EsCalculoEsValido(ICalculoDeInteracionEstimulante calculo)
		{
			if (calculo.estimuloBasico.tipo != DireccionDeEstimulo.recibida)
			{
				return false;
			}
			if (!((int)this.paraReaccion).HasFlag((int)calculo.emocion.reaccion))
			{
				return false;
			}
			if (!((int)this.paraTipoDeCalculo).HasFlag((int)calculo.tipo))
			{
				return false;
			}
			if (calculo is ICalculoDeEstimuloConEstado)
			{
				UmbralBasico.Estado estado;
				ReactorSegundario.GetEstadoConMasEstimuloTotal(calculo, out estado);
				if (this.calculoSoloEsValidoSiEstimuloEsMayorAZero && estado.estimulacionGeneradaTotal <= 0f)
				{
					return false;
				}
			}
			if (this.m_CambioDeEstimulada.activado)
			{
				this.m_CambioDeEstimulada.OnCheckingCalculo(ReactorSegundario.PartePrincipalEstimulada(calculo, false));
			}
			if (this.m_CambioDeEstimulante.activado)
			{
				ICalculoDeEstimuloDeParteEstimulante calculoDeEstimuloDeParteEstimulante = calculo as ICalculoDeEstimuloDeParteEstimulante;
				if (calculoDeEstimuloDeParteEstimulante != null)
				{
					this.m_CambioDeEstimulante.OnCheckingCalculo(calculoDeEstimuloDeParteEstimulante.estimulanteParte);
				}
			}
			if (this.m_CambioDeReaccion.activado)
			{
				this.m_CambioDeReaccion.OnCheckingCalculo(calculo.emocion.reaccion);
			}
			if (this.m_CambioDeTipoDeEstimulo.activado)
			{
				this.m_CambioDeTipoDeEstimulo.OnCheckingCalculo(calculo.estimuloBasico.tipoDeEstimulo);
			}
			return true;
		}

		// Token: 0x06001498 RID: 5272 RVA: 0x00062458 File Offset: 0x00060658
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeInteracionEstimulante calculo)
		{
			this.m_desHieloDeCurrentCalculo = Mathf.Max(this.m_DesHielo.value.total, this.m_DesHielo.ObtenerValor(calculo));
			float num = 1f;
			num *= this.m_CambioDeEstimulada.currentMod;
			num *= this.m_CambioDeEstimulante.currentMod;
			num *= this.m_CambioDeReaccion.currentMod;
			num *= this.m_CambioDeTipoDeEstimulo.currentMod;
			this.m_internalPrioridadMod = Mathf.Clamp(1f + (num - 1f) / 10f, 1f, 100f);
			if (calculo.emocion.reaccion == ReaccionHumana.rabia && this.m_ConsentForzado.EsCorrupted(calculo))
			{
				num *= 0.1f;
			}
			return base.ProbabilidadPorSegundoModificadorParaCalculo(calculo) * num;
		}

		// Token: 0x06001499 RID: 5273 RVA: 0x00062524 File Offset: 0x00060724
		protected override float CoolDownModificadorParaCalculo(ICalculoDeInteracionEstimulante calculo)
		{
			float num = 1f;
			num *= this.m_CambioDeEstimulada.currentMod;
			num *= this.m_CambioDeEstimulante.currentMod;
			num *= this.m_CambioDeReaccion.currentMod;
			num *= this.m_CambioDeTipoDeEstimulo.currentMod;
			num = 1f / num;
			if (calculo.emocion.reaccion == ReaccionHumana.rabia && this.m_ConsentForzado.EsCorrupted(calculo))
			{
				num *= 10f;
			}
			return base.CoolDownModificadorParaCalculo(calculo) * num;
		}

		// Token: 0x0600149A RID: 5274 RVA: 0x000625A4 File Offset: 0x000607A4
		protected override void LoadDialogosHandler(out object pordutor, List<DialogoInfo> resultado, ICalculoDeEstimulo calculo, Localizacion cultura, object lastProductor, ReactorDeBarkingHandler handler)
		{
			pordutor = null;
			float num = ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDePersonalidadRasgoDefaultOne(handler.personalidad.extroversion, 1f);
			num = MathfExtension.InverseLerpConMedio(0.5f, 1f, 2f, num);
			float num2 = num.Random01Lerp(0.45f);
			IDialogosDePersonalidades single = this.GetSingle(num2, (ICalculoDeInteracionEstimulante)calculo, lastProductor);
			pordutor = single;
			if (single == null)
			{
				Debug.LogException(new ArgumentNullException("Singleton", "IDialogosDePersonalidades es nullo"), this);
				return;
			}
			single.ObtenerDialogos(resultado, handler.personalidad.currentPersonalidad.personalidad.rasgos, cultura, calculo, handler.last, null);
		}

		// Token: 0x0600149B RID: 5275 RVA: 0x00062644 File Offset: 0x00060844
		protected override int ObtenerIntensidad(ICalculoDeEstimuloConEstado calculoConEstado)
		{
			UmbralBasico.Estado estado;
			ReactorSegundario.GetEstadoConMasEstimuloTotal(calculoConEstado, out estado);
			return this.m_handler.personalidad.IntensidadSpot(ref estado);
		}

		// Token: 0x0600149C RID: 5276 RVA: 0x000066D6 File Offset: 0x000048D6
		protected override int ObtenerDuracionMod(ICalculoDeInteracionEstimulante calculoConEstado)
		{
			return 1;
		}

		// Token: 0x0600149D RID: 5277 RVA: 0x0006266C File Offset: 0x0006086C
		private IDialogosDePersonalidades GetSingle(float verb, ICalculoDeInteracionEstimulante calculo, object lastProductor)
		{
			if (this.overrideVervosidad >= 0f)
			{
				verb = this.overrideVervosidad;
			}
			IDialogosDePersonalidades dialogosDePersonalidades = null;
			bool flag = false;
			if (this.usarDialogosDeDeshielo)
			{
				flag = calculo.emocion.reaccion == ReaccionHumana.miedo || this.m_desHieloDeCurrentCalculo < 10f || (this.m_desHieloDeCurrentCalculo < 100f && Random.value > Mathf.InverseLerp(10f, 100f, this.m_desHieloDeCurrentCalculo).OutPow(2f));
			}
			for (int i = 0; i < 5; i++)
			{
				if (i > 0)
				{
					verb = verb.Random01Lerp(0.2f);
				}
				if (!flag)
				{
					bool flag2 = this.puedeUsarDialogosCortos && !this.m_ignorandoDiaglodosCortosEnTipoDeEstimulo.Contains((int)calculo.estimuloBasico.tipoDeEstimulo);
					bool flag3 = this.puedeUsarDialogosLargos;
					if (flag2 && verb < 0.3333f)
					{
						dialogosDePersonalidades = (Singleton<DialogosDePersonalidadesCortaLongitud>.IsInScene ? Singleton<DialogosDePersonalidadesCortaLongitud>.instance : null);
					}
					else if (flag3 && verb > 0.6666f)
					{
						dialogosDePersonalidades = (Singleton<DialogosDePersonalidadesLargaLongitud>.IsInScene ? Singleton<DialogosDePersonalidadesLargaLongitud>.instance : null);
					}
					else
					{
						dialogosDePersonalidades = (Singleton<DialogosDePersonalidadesMedianaLongitud>.IsInScene ? Singleton<DialogosDePersonalidadesMedianaLongitud>.instance : null);
					}
				}
				else
				{
					bool flag4 = this.puedeUsarDialogosCortosParaDesHielo && !this.m_ignorandoDiaglodosCortosEnTipoDeEstimulo.Contains((int)calculo.estimuloBasico.tipoDeEstimulo);
					bool flag5 = this.puedeUsarDialogosLargosParaDesHielo;
					if (flag4 && (this.m_desHieloDeCurrentCalculo < 25f || calculo.emocion.reaccion == ReaccionHumana.miedo) && verb < 0.3333f)
					{
						dialogosDePersonalidades = (Singleton<DialogosDePersonalidadesCortaLongitudConHielo>.IsInScene ? Singleton<DialogosDePersonalidadesCortaLongitudConHielo>.instance : null);
					}
					else if (flag5 && verb > 0.6666f)
					{
						dialogosDePersonalidades = (Singleton<DialogosDePersonalidadesLargaLongitudConHielo>.IsInScene ? Singleton<DialogosDePersonalidadesLargaLongitudConHielo>.instance : null);
					}
					else
					{
						dialogosDePersonalidades = (Singleton<DialogosDePersonalidadesMedianaLongitudConHielo>.IsInScene ? Singleton<DialogosDePersonalidadesMedianaLongitudConHielo>.instance : null);
					}
				}
				if (dialogosDePersonalidades != lastProductor)
				{
					break;
				}
			}
			return dialogosDePersonalidades;
		}

		// Token: 0x0600149E RID: 5278 RVA: 0x00062840 File Offset: 0x00060A40
		protected override void OnCalculoReaccionado(ICalculoDeInteracionEstimulante calculoReaccionado, bool reaccionadoResultado)
		{
			if (reaccionadoResultado)
			{
				this.m_CambioDeEstimulada.OnBarked();
				this.m_CambioDeEstimulante.OnBarked();
				this.m_CambioDeReaccion.OnBarked();
				this.m_CambioDeTipoDeEstimulo.OnBarked();
				this.m_internalPrioridadMod = 1f;
			}
		}

		// Token: 0x04000EAB RID: 3755
		[Header("De Emocion Recibida")]
		public bool calculoSoloEsValidoSiEstimuloEsMayorAZero;

		// Token: 0x04000EAC RID: 3756
		public TipoDeCalculoDeEstimulo paraTipoDeCalculo = (TipoDeCalculoDeEstimulo)(-1);

		// Token: 0x04000EAD RID: 3757
		public ReaccionHumana paraReaccion;

		// Token: 0x04000EAE RID: 3758
		public bool usarDialogosDeDeshielo = true;

		// Token: 0x04000EAF RID: 3759
		[ReadOnlyUI]
		[SerializeField]
		private float m_desHieloDeCurrentCalculo;

		// Token: 0x04000EB0 RID: 3760
		private DesHielo m_DesHielo;

		// Token: 0x04000EB1 RID: 3761
		[Header("Modificadores")]
		[SerializeField]
		private ModificadorPorCambioDeEstimulada m_CambioDeEstimulada = new ModificadorPorCambioDeEstimulada();

		// Token: 0x04000EB2 RID: 3762
		[SerializeField]
		private ModificadorPorCambioDeEstimulante m_CambioDeEstimulante = new ModificadorPorCambioDeEstimulante();

		// Token: 0x04000EB3 RID: 3763
		[SerializeField]
		private ModificadorPorCambioDeReaccion m_CambioDeReaccion = new ModificadorPorCambioDeReaccion();

		// Token: 0x04000EB4 RID: 3764
		[SerializeField]
		private ModificadorPorCambioDeTipoDeEstimulo m_CambioDeTipoDeEstimulo = new ModificadorPorCambioDeTipoDeEstimulo();

		// Token: 0x04000EB5 RID: 3765
		[Header("Largo de Dialogos")]
		[Tooltip("-1 para deshabilitar")]
		public float overrideVervosidad = -1f;

		// Token: 0x04000EB6 RID: 3766
		public bool puedeUsarDialogosCortos = true;

		// Token: 0x04000EB7 RID: 3767
		public bool puedeUsarDialogosLargos = true;

		// Token: 0x04000EB8 RID: 3768
		public bool puedeUsarDialogosCortosParaDesHielo;

		// Token: 0x04000EB9 RID: 3769
		public bool puedeUsarDialogosLargosParaDesHielo = true;

		// Token: 0x04000EBA RID: 3770
		[SerializeField]
		private List<TipoDeEstimulo> m_ignorarDiaglodosCortosEnTipoDeEstimulo = new List<TipoDeEstimulo>();

		// Token: 0x04000EBB RID: 3771
		private HashSet<int> m_ignorandoDiaglodosCortosEnTipoDeEstimulo;

		// Token: 0x04000EBC RID: 3772
		[ReadOnlyUI]
		[SerializeField]
		private float m_editorMinCoolDownPorCambiosDeCalculoAprox;

		// Token: 0x04000EBD RID: 3773
		[ReadOnlyUI]
		[SerializeField]
		private float m_editorMaxProbabilidadPorCambiosDeCalculoAprox;

		// Token: 0x04000EBE RID: 3774
		private ConsentCorrupted m_ConsentForzado;
	}
}
