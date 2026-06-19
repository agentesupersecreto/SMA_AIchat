using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos.Abstract;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos.Clases;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.ExclamacionesDiags;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.MaxEmoValue;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Orgasmo.Dialogos
{
	// Token: 0x02000306 RID: 774
	public class ReactorDeBarkingDeOrgasmo : ReactorDeBarkingBasicoConMultipleBarks
	{
		// Token: 0x06001397 RID: 5015 RVA: 0x0005BE6E File Offset: 0x0005A06E
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_DuracionDeOrgasmo = this.GetComponentEnRoot(false);
			if (this.m_DuracionDeOrgasmo == null)
			{
				throw new ArgumentNullException("m_DuracionDeOrgasmo", "m_DuracionDeOrgasmo null reference.");
			}
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x00006C93 File Offset: 0x00004E93
		protected override bool CalculoEsValido(ICalculoDeEstimulo calculo)
		{
			return calculo.EsOrgasmo();
		}

		// Token: 0x06001399 RID: 5017 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float CoolDownModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f;
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ProbabilidadPorSegundoModificadorParaCalculo(ICalculoDeEstimulo calculo)
		{
			return 1f;
		}

		// Token: 0x0600139B RID: 5019 RVA: 0x0005BE9C File Offset: 0x0005A09C
		protected override int BarksParaCalculo(ICalculoDeEstimulo calculo)
		{
			float num = ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDePersonalidadRasgoDefaultOne(this.m_handler.personalidad.extroversion, 0.5f);
			bool flag = calculo is ICalculoDeInteracionEstimulante;
			bool flag2 = this.m_primerOrgasmo || (flag && (88f * num).ProcPorcentaje(1f));
			bool flag3 = flag2 && 20f.ProcPorcentaje(1f);
			if (!flag2)
			{
				this.m_currentTipo = ReactorDeBarkingDeOrgasmo.Tipo.None;
			}
			else if (flag3)
			{
				this.m_currentTipo = ReactorDeBarkingDeOrgasmo.Tipo.soloBarkPresente;
			}
			else
			{
				this.m_currentTipo = ReactorDeBarkingDeOrgasmo.Tipo.soloBarkPasado;
			}
			this.m_duracionDeCurrentOrgasmo = this.m_DuracionDeOrgasmo.currentDuracionTotalDeOrgasmo * 1.05f;
			this.m_handler.controller.ClearBark();
			this.m_handler.controller.FlagMinPrioridad(2147483637, this.m_duracionDeCurrentOrgasmo);
			switch (this.m_currentTipo)
			{
			case ReactorDeBarkingDeOrgasmo.Tipo.None:
				return 0;
			case ReactorDeBarkingDeOrgasmo.Tipo.soloBarkPresente:
				return 1;
			case ReactorDeBarkingDeOrgasmo.Tipo.soloBarkPasado:
				return 1;
			}
			throw new ArgumentOutOfRangeException(this.m_currentTipo.ToString());
		}

		// Token: 0x0600139C RID: 5020 RVA: 0x00006DC5 File Offset: 0x00004FC5
		protected override float ObtenerPrioridadMod(int barkIndex, ICalculoDeEstimulo calculoConEstado)
		{
			return 1f;
		}

		// Token: 0x0600139D RID: 5021 RVA: 0x0005BFA2 File Offset: 0x0005A1A2
		protected override int PrioridadOverrideParaIndex(int barkIndex, int calculada, ICalculoDeEstimulo calculo)
		{
			return int.MaxValue - barkIndex;
		}

		// Token: 0x0600139E RID: 5022 RVA: 0x00002BE7 File Offset: 0x00000DE7
		protected override int ObtenerIntensidad(int barkIndex, ICalculoDeEstimuloConEstado calculoConEstado)
		{
			return 0;
		}

		// Token: 0x0600139F RID: 5023 RVA: 0x0005BFAC File Offset: 0x0005A1AC
		protected override float DelayParaIndex(int barkIndex, ICalculoDeEstimulo calculoConEstado)
		{
			ReactorDeBarkingDeOrgasmo.TipoDeBark tipoDeBark = ReactorDeBarkingDeOrgasmo.ObtnerTipoDeBark(barkIndex, this.m_currentTipo);
			if (tipoDeBark == ReactorDeBarkingDeOrgasmo.TipoDeBark.barkPresente)
			{
				return 0f;
			}
			if (tipoDeBark != ReactorDeBarkingDeOrgasmo.TipoDeBark.barkPasado)
			{
				throw new ArgumentOutOfRangeException(tipoDeBark.ToString());
			}
			return this.m_duracionDeCurrentOrgasmo;
		}

		// Token: 0x060013A0 RID: 5024 RVA: 0x0005BFF0 File Offset: 0x0005A1F0
		protected override float DuracionModParaIndex(int barkIndex, ICalculoDeEstimulo calculo)
		{
			ReactorDeBarkingDeOrgasmo.TipoDeBark tipoDeBark = ReactorDeBarkingDeOrgasmo.ObtnerTipoDeBark(barkIndex, this.m_currentTipo);
			if (tipoDeBark == ReactorDeBarkingDeOrgasmo.TipoDeBark.barkPresente)
			{
				return 1.25f;
			}
			if (tipoDeBark != ReactorDeBarkingDeOrgasmo.TipoDeBark.barkPasado)
			{
				throw new ArgumentOutOfRangeException(tipoDeBark.ToString());
			}
			return 1f;
		}

		// Token: 0x060013A1 RID: 5025 RVA: 0x0005C034 File Offset: 0x0005A234
		protected override void LoadDialogosHandler(int barkIndex, out object productor, List<DialogoInfo> resultado, ICalculoDeEstimulo calculo, Localizacion cultura, object lastProductor, ReactorDeBarkingHandler handler)
		{
			productor = null;
			float num = ReactorDeBarkingHandler.ModSegunPersonalidad.ValueDePersonalidadRasgoDefaultOne(this.m_handler.personalidad.extroversion, 1f);
			num = MathfExtension.InverseLerpConMedio(0.5f, 1f, 2f, num);
			ReactorDeBarkingDeOrgasmo.TipoDeBark tipoDeBark = ReactorDeBarkingDeOrgasmo.ObtnerTipoDeBark(barkIndex, this.m_currentTipo);
			IDialogosDePersonalidades dialogosDePersonalidades;
			if (tipoDeBark != ReactorDeBarkingDeOrgasmo.TipoDeBark.barkPresente)
			{
				if (tipoDeBark != ReactorDeBarkingDeOrgasmo.TipoDeBark.barkPasado)
				{
					throw new ArgumentOutOfRangeException(tipoDeBark.ToString());
				}
				dialogosDePersonalidades = this.GetSingleBarkPasado(num, calculo);
			}
			else
			{
				dialogosDePersonalidades = this.GetSingleBarkPresente(num, calculo);
			}
			productor = dialogosDePersonalidades;
			if (dialogosDePersonalidades == null)
			{
				Debug.LogException(new ArgumentNullException("Singleton", "IDialogosDePersonalidades es nullo"), this);
				return;
			}
			dialogosDePersonalidades.ObtenerDialogos(resultado, handler.personalidad.currentPersonalidad.personalidad.rasgos, cultura, calculo, handler.last, null);
		}

		// Token: 0x060013A2 RID: 5026 RVA: 0x0005C0FC File Offset: 0x0005A2FC
		protected override bool OnCalculoZeroBarksParaCalculo(ICalculoDeEstimulo calculoReaccionado)
		{
			return this.m_handler.controller.MuteClearing(this.m_duracionDeCurrentOrgasmo);
		}

		// Token: 0x060013A3 RID: 5027 RVA: 0x0005C114 File Offset: 0x0005A314
		protected override void OnCalculoReaccionado(ICalculoDeEstimulo calculoReaccionado, bool reaccionadoResultado)
		{
			if (reaccionadoResultado)
			{
				this.m_primerOrgasmo = false;
				this.baseConfig.coolDownGeneral = this.m_DuracionDeOrgasmo.currentDuracionTotalDeOrgasmo;
			}
		}

		// Token: 0x060013A4 RID: 5028 RVA: 0x0005C138 File Offset: 0x0005A338
		protected static ReactorDeBarkingDeOrgasmo.TipoDeBark ObtnerTipoDeBark(int barkIndex, ReactorDeBarkingDeOrgasmo.Tipo tipo)
		{
			switch (tipo)
			{
			case ReactorDeBarkingDeOrgasmo.Tipo.soloBarkPresente:
				if (barkIndex > 0)
				{
					throw new IndexOutOfRangeException();
				}
				return ReactorDeBarkingDeOrgasmo.TipoDeBark.barkPresente;
			case ReactorDeBarkingDeOrgasmo.Tipo.soloBarkPasado:
				if (barkIndex > 0)
				{
					throw new IndexOutOfRangeException();
				}
				return ReactorDeBarkingDeOrgasmo.TipoDeBark.barkPasado;
			}
			throw new ArgumentOutOfRangeException(tipo.ToString());
		}

		// Token: 0x060013A5 RID: 5029 RVA: 0x0005C188 File Offset: 0x0005A388
		private IDialogosDePersonalidades GetSingleExpresion(float verb, ICalculoDeEstimulo calculo)
		{
			bool flag = true;
			bool flag2 = true;
			IDialogosDePersonalidades dialogosDePersonalidades;
			if (flag && verb < 0.3333f)
			{
				dialogosDePersonalidades = (Singleton<DialogosDePersonalidadesExclamacionCortaLongitud>.IsInScene ? Singleton<DialogosDePersonalidadesExclamacionCortaLongitud>.instance : null);
			}
			else if (flag2 && verb > 0.6666f)
			{
				dialogosDePersonalidades = (Singleton<DialogosDePersonalidadesExclamacionLargaLongitud>.IsInScene ? Singleton<DialogosDePersonalidadesExclamacionLargaLongitud>.instance : null);
			}
			else
			{
				dialogosDePersonalidades = (Singleton<DialogosDePersonalidadesExclamacionMedianaLongitud>.IsInScene ? Singleton<DialogosDePersonalidadesExclamacionMedianaLongitud>.instance : null);
			}
			return dialogosDePersonalidades;
		}

		// Token: 0x060013A6 RID: 5030 RVA: 0x0005C1E4 File Offset: 0x0005A3E4
		private IDialogosDePersonalidades GetSingleBarkPresente(float verb, ICalculoDeEstimulo calculo)
		{
			bool flag = true;
			bool flag2 = true;
			IDialogosDePersonalidades dialogosDePersonalidades;
			if (flag && verb < 0.3333f)
			{
				dialogosDePersonalidades = (Singleton<DiagsPresenteDeMaxEmocionValueCortaLongitud>.IsInScene ? Singleton<DiagsPresenteDeMaxEmocionValueCortaLongitud>.instance : null);
			}
			else if (flag2 && verb > 0.6666f)
			{
				dialogosDePersonalidades = (Singleton<DiagsPresenteDeMaxEmocionValueLargaLongitud>.IsInScene ? Singleton<DiagsPresenteDeMaxEmocionValueLargaLongitud>.instance : null);
			}
			else
			{
				dialogosDePersonalidades = (Singleton<DiagsPresenteDeMaxEmocionValueMedianaLongitud>.IsInScene ? Singleton<DiagsPresenteDeMaxEmocionValueMedianaLongitud>.instance : null);
			}
			return dialogosDePersonalidades;
		}

		// Token: 0x060013A7 RID: 5031 RVA: 0x0005C240 File Offset: 0x0005A440
		private IDialogosDePersonalidades GetSingleBarkPasado(float verb, ICalculoDeEstimulo calculo)
		{
			bool flag = true;
			bool flag2 = true;
			IDialogosDePersonalidades dialogosDePersonalidades;
			if (flag && verb < 0.3333f)
			{
				dialogosDePersonalidades = (Singleton<DiagsPasadoDeMaxEmocionValueCortaLongitud>.IsInScene ? Singleton<DiagsPasadoDeMaxEmocionValueCortaLongitud>.instance : null);
			}
			else if (flag2 && verb > 0.6666f)
			{
				dialogosDePersonalidades = (Singleton<DiagsPasadoDeMaxEmocionValueLargaLongitud>.IsInScene ? Singleton<DiagsPasadoDeMaxEmocionValueLargaLongitud>.instance : null);
			}
			else
			{
				dialogosDePersonalidades = (Singleton<DiagsPasadoDeMaxEmocionValueMedianaLongitud>.IsInScene ? Singleton<DiagsPasadoDeMaxEmocionValueMedianaLongitud>.instance : null);
			}
			return dialogosDePersonalidades;
		}

		// Token: 0x04000E2A RID: 3626
		[ReadOnlyUI]
		[SerializeField]
		private float m_duracionDeCurrentOrgasmo;

		// Token: 0x04000E2B RID: 3627
		[ReadOnlyUI]
		[SerializeField]
		private ReactorDeBarkingDeOrgasmo.Tipo m_currentTipo;

		// Token: 0x04000E2C RID: 3628
		private IDuracionDeOrgasmo m_DuracionDeOrgasmo;

		// Token: 0x04000E2D RID: 3629
		[NonSerialized]
		private bool m_primerOrgasmo = true;

		// Token: 0x02000307 RID: 775
		public enum TipoDeBark
		{
			// Token: 0x04000E2F RID: 3631
			[Obsolete("", true)]
			expresion,
			// Token: 0x04000E30 RID: 3632
			barkPresente,
			// Token: 0x04000E31 RID: 3633
			barkPasado
		}

		// Token: 0x02000308 RID: 776
		public enum Tipo
		{
			// Token: 0x04000E33 RID: 3635
			None,
			// Token: 0x04000E34 RID: 3636
			[Obsolete("", true)]
			soloExpresionPresente,
			// Token: 0x04000E35 RID: 3637
			soloBarkPresente,
			// Token: 0x04000E36 RID: 3638
			soloBarkPasado,
			// Token: 0x04000E37 RID: 3639
			[Obsolete("", true)]
			expresionPresenteAndBarkPasado,
			// Token: 0x04000E38 RID: 3640
			[Obsolete("", true)]
			barkPresenteAndExpresionPasado
		}
	}
}
