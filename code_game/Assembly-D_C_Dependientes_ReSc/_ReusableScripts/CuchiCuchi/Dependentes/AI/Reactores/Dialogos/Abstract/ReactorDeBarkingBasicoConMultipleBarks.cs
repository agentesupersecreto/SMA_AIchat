using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos.Clases;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos.Abstract
{
	// Token: 0x0200034E RID: 846
	public abstract class ReactorDeBarkingBasicoConMultipleBarks : ReactorACalculoDeEstimulo<ICalculoDeEstimulo>
	{
		// Token: 0x0600152A RID: 5418 RVA: 0x00063DD4 File Offset: 0x00061FD4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			IControlladorDeBark componentEnCharacter = this.GetComponentEnCharacter(false);
			Personalidad componentEnCharacter2 = this.GetComponentEnCharacter(false);
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

		// Token: 0x0600152B RID: 5419 RVA: 0x00063E73 File Offset: 0x00062073
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f / this.m_handler.ModificadorTotal(calculo);
		}

		// Token: 0x0600152C RID: 5420 RVA: 0x00063E87 File Offset: 0x00062087
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return this.m_handler.ModificadorTotal(calculo);
		}

		// Token: 0x0600152D RID: 5421 RVA: 0x00063E95 File Offset: 0x00062095
		protected void LoadDialogosHandler(out object productor, List<DialogoInfo> resultado, ICalculoDeEstimulo calculo, Localizacion cultura, object lastProductor, ReactorDeBarkingHandler handler)
		{
			this.LoadDialogosHandler(this.m_currentBarkIndex, out productor, resultado, calculo, cultura, lastProductor, handler);
		}

		// Token: 0x0600152E RID: 5422 RVA: 0x00063EAC File Offset: 0x000620AC
		protected bool DialogosEsValidoHandler(object productor, DialogoInfo dialogo, ICalculoDeEstimulo calculo, Localizacion cultura, ReactorDeBarkingHandler handler)
		{
			return this.DialogosEsValidoHandler(this.m_currentBarkIndex, productor, dialogo, calculo, cultura, handler);
		}

		// Token: 0x0600152F RID: 5423 RVA: 0x00063EC1 File Offset: 0x000620C1
		protected virtual bool DialogosElegidoHandler(object productor, DialogoInfo dialogo, ICalculoDeEstimulo calculo, Localizacion cultura, ReactorDeBarkingHandler handl)
		{
			return this.DialogosElegidoHandler(this.m_currentBarkIndex, productor, dialogo, calculo, cultura, handl);
		}

		// Token: 0x06001530 RID: 5424
		protected abstract void LoadDialogosHandler(int barkIndex, out object productor, List<DialogoInfo> resultado, ICalculoDeEstimulo calculo, Localizacion cultura, object lastProductor, ReactorDeBarkingHandler handler);

		// Token: 0x06001531 RID: 5425 RVA: 0x00063ED8 File Offset: 0x000620D8
		protected virtual bool DialogosEsValidoHandler(int barkIndex, object productor, DialogoInfo dialogo, ICalculoDeEstimulo calculo, Localizacion cultura, ReactorDeBarkingHandler handler)
		{
			DialogoInfoGenerico dialogoInfoGenerico = dialogo as DialogoInfoGenerico;
			if (dialogoInfoGenerico == null)
			{
				return dialogo != null;
			}
			return this.m_actualizacionUtil.DialogoGenericoSePuedeActualizar(productor, dialogoInfoGenerico, calculo, false, false);
		}

		// Token: 0x06001532 RID: 5426 RVA: 0x00063F08 File Offset: 0x00062108
		protected virtual bool DialogosElegidoHandler(int barkIndex, object productor, DialogoInfo dialogo, ICalculoDeEstimulo calculo, Localizacion cultura, ReactorDeBarkingHandler handl)
		{
			ICalculoDeEstimuloConEstado calculoDeEstimuloConEstado = calculo as ICalculoDeEstimuloConEstado;
			int? num = null;
			if (calculoDeEstimuloConEstado != null)
			{
				num = new int?(this.ObtenerIntensidad(this.m_currentBarkIndex, calculoDeEstimuloConEstado));
			}
			Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuestaDeDialogoDeHeroina = this.m_handler.personalidad.ObtenerTipoDeRespuestaSegunPersonalidadYEmociones();
			ValueTuple<ObtenerDialogosUtil.Resultado, TipoDePalabraGenerica> valueTuple = this.m_actualizacionUtil.ActualizarDialogoGenerico(productor, (DialogoInfoGenerico)dialogo, calculo, this.m_handler.last, num, tipoDeRespuestaDeDialogoDeHeroina);
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

		// Token: 0x06001533 RID: 5427
		protected abstract int ObtenerIntensidad(int barkIndex, ICalculoDeEstimuloConEstado calculo);

		// Token: 0x06001534 RID: 5428
		protected abstract float ObtenerPrioridadMod(int barkIndex, ICalculoDeEstimulo calculo);

		// Token: 0x06001535 RID: 5429
		protected abstract float DelayParaIndex(int barkIndex, ICalculoDeEstimulo calculo);

		// Token: 0x06001536 RID: 5430
		protected abstract float DuracionModParaIndex(int barkIndex, ICalculoDeEstimulo calculo);

		// Token: 0x06001537 RID: 5431
		protected abstract int PrioridadOverrideParaIndex(int barkIndex, int calculada, ICalculoDeEstimulo calculo);

		// Token: 0x06001538 RID: 5432
		protected abstract int BarksParaCalculo(ICalculoDeEstimulo calculo);

		// Token: 0x06001539 RID: 5433 RVA: 0x00063FB0 File Offset: 0x000621B0
		protected override bool ReaccionarCalculo(ICalculoDeEstimulo calculo)
		{
			bool flag2;
			try
			{
				int num = this.BarksParaCalculo(calculo);
				bool flag = false;
				if (num <= 0)
				{
					flag = this.OnCalculoZeroBarksParaCalculo(calculo) || flag;
				}
				for (int i = 0; i < num; i++)
				{
					this.m_currentBarkIndex = i;
					int num2 = (this.esMaxPrioridadParaController ? int.MaxValue : ReactorSegundario.PrioridadParcer(calculo, this.baseConfig.prioridad, (double)(this.m_internalPrioridadMod * this.prioridadModParaController * this.ObtenerPrioridadMod(this.m_currentBarkIndex, calculo))));
					num2 = this.PrioridadOverrideParaIndex(this.m_currentBarkIndex, num2, calculo);
					float num3 = this.DelayParaIndex(this.m_currentBarkIndex, calculo);
					flag = this.m_handler.ReaccionarCalculoDelayed(calculo, num2, num3, true, this.DuracionModParaIndex(this.m_currentBarkIndex, calculo)) || flag;
				}
				this.OnCalculoReaccionado(calculo, flag);
				flag2 = flag;
			}
			finally
			{
				this.m_currentBarkIndex = -1;
			}
			return flag2;
		}

		// Token: 0x0600153A RID: 5434
		protected abstract bool OnCalculoZeroBarksParaCalculo(ICalculoDeEstimulo calculoReaccionado);

		// Token: 0x0600153B RID: 5435
		protected abstract void OnCalculoReaccionado(ICalculoDeEstimulo calculoReaccionado, bool reaccionadoResultado);

		// Token: 0x04000EF1 RID: 3825
		[Header("De Interaccion Estimulante")]
		[SerializeField]
		protected ReactorDeBarkingHandler m_handler = new ReactorDeBarkingHandler();

		// Token: 0x04000EF2 RID: 3826
		public bool esMaxPrioridadParaController;

		// Token: 0x04000EF3 RID: 3827
		public float prioridadModParaController = 1f;

		// Token: 0x04000EF4 RID: 3828
		[SerializeField]
		[ReadOnlyUI]
		protected float m_internalPrioridadMod = 1f;

		// Token: 0x04000EF5 RID: 3829
		[SerializeField]
		[ReadOnlyUI]
		private int m_currentBarkIndex = -1;

		// Token: 0x04000EF6 RID: 3830
		[Header("Dialogos Util")]
		public bool autoIgnoreDialogosNoEncontrados = true;

		// Token: 0x04000EF7 RID: 3831
		[SerializeField]
		private ObtenerDialogosUtil m_actualizacionUtil;
	}
}
