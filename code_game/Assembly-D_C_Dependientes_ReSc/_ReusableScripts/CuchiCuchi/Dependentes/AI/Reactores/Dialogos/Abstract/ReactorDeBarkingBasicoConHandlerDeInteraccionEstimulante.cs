using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos.Clases;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos.Abstract
{
	// Token: 0x0200034D RID: 845
	public abstract class ReactorDeBarkingBasicoConHandlerDeInteraccionEstimulante : ReactorACalculoDeEstimulo<ICalculoDeInteracionEstimulante>
	{
		// Token: 0x0600151D RID: 5405 RVA: 0x00063ABC File Offset: 0x00061CBC
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ownerCharacterIdleable = this.GetComponentEnRoot(false);
			if (this.m_ownerCharacterIdleable == null)
			{
				throw new ArgumentNullException("m_ownerCharacterIdleable", "m_ownerCharacterIdleable null reference.");
			}
			IControlladorDeBark componentEnCharacter = this.GetComponentEnCharacter(false);
			Personalidad componentEnCharacter2 = this.GetComponentEnCharacter(false);
			this.m_ConsentNecesario = this.GetComponentEnCharacter(false);
			if (this.m_ConsentNecesario == null)
			{
				throw new ArgumentNullException("m_ConsentNecesario", "m_ConsentNecesario null reference.");
			}
			if (componentEnCharacter == null)
			{
				throw new ArgumentNullException("m_Controller", "m_Controller null reference.");
			}
			if (componentEnCharacter2 == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
			this.m_actualizacionUtil = new ObtenerDialogosUtil(this.GetComponentEnRoot(false));
			this.m_actualizacionUtil.contexto = this;
			this.m_handler.Init(componentEnCharacter, componentEnCharacter2, new ReactorDeBarkingHandler.LoadDialogosHandler(this.LoadDialogosHandler), new ReactorDeBarkingHandler.DialogosEsValidoHandler(this.DialogosEsValidoHandler), new ReactorDeBarkingHandler.DialogosElegidoHandler(this.DialogosElegidoHandler));
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x00063BB0 File Offset: 0x00061DB0
		protected sealed override bool CalculoEsValido(ICalculoDeInteracionEstimulante calculo)
		{
			if (!this.EsCalculoEsValido(calculo))
			{
				return false;
			}
			int num = (int)this.m_handler.personalidad.ObtenerTipoMayorDeCurrentFrame(false, null, true, false);
			if (!((int)this.paraTipoDePersonalidad).HasFlag(num))
			{
				return false;
			}
			if (this.soloSiEsConsentido)
			{
				ICalculoDeInteracionEstimulanteDeParteEstimulante calculoDeInteracionEstimulanteDeParteEstimulante = calculo as ICalculoDeInteracionEstimulanteDeParteEstimulante;
				if (calculoDeInteracionEstimulanteDeParteEstimulante == null)
				{
					return false;
				}
				if (!this.m_ConsentNecesario.EsConsentidoConJerarquia(calculoDeInteracionEstimulanteDeParteEstimulante, null, null))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0600151F RID: 5407
		protected abstract bool EsCalculoEsValido(ICalculoDeInteracionEstimulante calculo);

		// Token: 0x06001520 RID: 5408
		protected abstract void LoadDialogosHandler(out object productor, List<DialogoInfo> resultado, ICalculoDeEstimulo calculo, Localizacion cultura, object lastProductor, ReactorDeBarkingHandler handler);

		// Token: 0x06001521 RID: 5409 RVA: 0x00063C1C File Offset: 0x00061E1C
		protected virtual bool DialogosEsValidoHandler(object productor, DialogoInfo dialogo, ICalculoDeEstimulo calculo, Localizacion cultura, ReactorDeBarkingHandler handler)
		{
			DialogoInfoGenerico dialogoInfoGenerico = dialogo as DialogoInfoGenerico;
			if (dialogoInfoGenerico == null)
			{
				return dialogo != null;
			}
			return this.m_actualizacionUtil.DialogoGenericoSePuedeActualizar(productor, dialogoInfoGenerico, (ICalculoDeInteracionEstimulante)calculo, false, false);
		}

		// Token: 0x06001522 RID: 5410 RVA: 0x00063C50 File Offset: 0x00061E50
		protected virtual bool DialogosElegidoHandler(object productor, DialogoInfo dialogo, ICalculoDeEstimulo calculo, Localizacion cultura, ReactorDeBarkingHandler handl)
		{
			ICalculoDeEstimuloConEstado calculoDeEstimuloConEstado = calculo as ICalculoDeEstimuloConEstado;
			int? num = null;
			if (calculoDeEstimuloConEstado != null)
			{
				num = new int?(this.ObtenerIntensidad(calculoDeEstimuloConEstado));
			}
			Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuestaDeDialogoDeHeroina = this.m_handler.personalidad.ObtenerTipoDeRespuestaSegunPersonalidadYEmociones();
			ValueTuple<ObtenerDialogosUtil.Resultado, TipoDePalabraGenerica> valueTuple = this.m_actualizacionUtil.ActualizarDialogoGenerico(productor, (DialogoInfoGenerico)dialogo, (ICalculoDeInteracionEstimulante)calculo, this.m_handler.last, num, tipoDeRespuestaDeDialogoDeHeroina);
			if (this.autoIgnoreDialogosNoEncontrados && valueTuple.Item1 == ObtenerDialogosUtil.Resultado.noExisteDialogo && productor != null)
			{
				if (productor == null)
				{
					Debug.LogWarning("No se pudo ignorar palabra generica, productor es nullo", this);
				}
				else
				{
					this.m_actualizacionUtil.AddIgnoracionDeProducor(productor, valueTuple.Item2);
				}
			}
			return valueTuple.Item1 == ObtenerDialogosUtil.Resultado.exito;
		}

		// Token: 0x06001523 RID: 5411
		protected abstract int ObtenerIntensidad(ICalculoDeEstimuloConEstado calculoConEstado);

		// Token: 0x06001524 RID: 5412
		protected abstract int ObtenerDuracionMod(ICalculoDeInteracionEstimulante calculoConEstado);

		// Token: 0x06001525 RID: 5413 RVA: 0x00063CF3 File Offset: 0x00061EF3
		protected override float CoolDownModificadorParaCalculo(ICalculoDeInteracionEstimulante calculo)
		{
			return 1f / this.m_handler.ModificadorTotal(calculo);
		}

		// Token: 0x06001526 RID: 5414 RVA: 0x00063D07 File Offset: 0x00061F07
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeInteracionEstimulante calculo)
		{
			return this.m_handler.ModificadorTotal(calculo);
		}

		// Token: 0x06001527 RID: 5415 RVA: 0x00063D18 File Offset: 0x00061F18
		protected override bool ReaccionarCalculo(ICalculoDeInteracionEstimulante calculo)
		{
			int num = ReactorSegundario.PrioridadParcer(calculo, this.baseConfig.prioridad, (double)(this.m_internalPrioridadMod * this.prioridadModParaController));
			ICalculoDeEstimuloReaccionable calculoDeEstimuloReaccionable = calculo as ICalculoDeEstimuloReaccionable;
			if (calculoDeEstimuloReaccionable != null && calculoDeEstimuloReaccionable.ignorarCoolDown)
			{
				num = int.MaxValue;
			}
			bool flag = this.m_handler.ReaccionarCalculo(calculo, num, (float)this.ObtenerDuracionMod(calculo));
			this.OnCalculoReaccionado(calculo, flag);
			if (this.debugLogConHandler)
			{
				Debug.Log("Reacciono: " + flag.ToString(), this);
			}
			return flag;
		}

		// Token: 0x06001528 RID: 5416
		protected abstract void OnCalculoReaccionado(ICalculoDeInteracionEstimulante calculoReaccionado, bool reaccionadoResultado);

		// Token: 0x04000EE7 RID: 3815
		public bool debugLogConHandler;

		// Token: 0x04000EE8 RID: 3816
		[Header("Condiciones Estimulo")]
		public bool soloSiEsConsentido;

		// Token: 0x04000EE9 RID: 3817
		[Header("Condiciones Para Personalidad")]
		public Personalidad.Tipo paraTipoDePersonalidad = Personalidad.Tipo.All;

		// Token: 0x04000EEA RID: 3818
		[Header("De Interaccion Estimulante")]
		[SerializeField]
		protected ReactorDeBarkingHandler m_handler = new ReactorDeBarkingHandler();

		// Token: 0x04000EEB RID: 3819
		public float prioridadModParaController = 1f;

		// Token: 0x04000EEC RID: 3820
		[SerializeField]
		[ReadOnlyUI]
		protected float m_internalPrioridadMod = 1f;

		// Token: 0x04000EED RID: 3821
		[Header("Dialogos Util")]
		public bool autoIgnoreDialogosNoEncontrados = true;

		// Token: 0x04000EEE RID: 3822
		[SerializeField]
		private ObtenerDialogosUtil m_actualizacionUtil;

		// Token: 0x04000EEF RID: 3823
		private ConsentNecesario m_ConsentNecesario;

		// Token: 0x04000EF0 RID: 3824
		protected IFemaleCharacterIdleable m_ownerCharacterIdleable;
	}
}
