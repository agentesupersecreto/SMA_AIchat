using System;
using System.Collections;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using TValleCustomClases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos
{
	// Token: 0x0200039C RID: 924
	public abstract class ReactorSegundario : AplicableCustomMonobehaviour
	{
		// Token: 0x06001437 RID: 5175 RVA: 0x00057948 File Offset: 0x00055B48
		public static void GetEstadoConMasEstimuloTotal(ICalculoDeEstimulo calculo, out UmbralBasico.Estado estado)
		{
			ICalculoDeEstimuloConEstado calculoDeEstimuloConEstado = calculo as ICalculoDeEstimuloConEstado;
			if (calculoDeEstimuloConEstado == null || calculoDeEstimuloConEstado.cantidadDeEstados == 0)
			{
				estado = default(UmbralBasico.Estado);
				return;
			}
			if (calculoDeEstimuloConEstado.esSingleEstado)
			{
				calculoDeEstimuloConEstado.GetSingleEstado(out estado);
				return;
			}
			int num = -1;
			float num2 = float.MinValue;
			for (int i = 0; i < calculoDeEstimuloConEstado.cantidadDeEstados; i++)
			{
				UmbralBasico.Estado estado2;
				calculoDeEstimuloConEstado.GetEstadoCopia(i, out estado2);
				float estimulacionGeneradaTotal = estado2.estimulacionGeneradaTotal;
				if (estimulacionGeneradaTotal > num2)
				{
					num = i;
					num2 = estimulacionGeneradaTotal;
				}
			}
			calculoDeEstimuloConEstado.GetEstadoCopia(num, out estado);
		}

		// Token: 0x06001438 RID: 5176 RVA: 0x000579BC File Offset: 0x00055BBC
		public static void GetEstadoConMasEstimuloEnFrame(ICalculoDeEstimulo calculo, out UmbralBasico.Estado estado)
		{
			ICalculoDeEstimuloConEstado calculoDeEstimuloConEstado = calculo as ICalculoDeEstimuloConEstado;
			if (calculoDeEstimuloConEstado == null || calculoDeEstimuloConEstado.cantidadDeEstados == 0)
			{
				estado = default(UmbralBasico.Estado);
				return;
			}
			if (calculoDeEstimuloConEstado.esSingleEstado)
			{
				calculoDeEstimuloConEstado.GetSingleEstado(out estado);
				return;
			}
			int num = -1;
			float num2 = float.MinValue;
			for (int i = 0; i < calculoDeEstimuloConEstado.cantidadDeEstados; i++)
			{
				UmbralBasico.Estado estado2;
				calculoDeEstimuloConEstado.GetEstadoCopia(i, out estado2);
				float estimulacionGeneradaEnFrame = estado2.estimulacionGeneradaEnFrame;
				if (estimulacionGeneradaEnFrame > num2)
				{
					num = i;
					num2 = estimulacionGeneradaEnFrame;
				}
			}
			calculoDeEstimuloConEstado.GetEstadoCopia(num, out estado);
		}

		// Token: 0x06001439 RID: 5177 RVA: 0x00057A30 File Offset: 0x00055C30
		public static ParteDelCuerpoHumano PartePrincipalEstimulada(ICalculoDeInteracionEstimulante calculo, bool usarInvertido)
		{
			return calculo.PartePrincipalEstimulada(usarInvertido);
		}

		// Token: 0x0600143A RID: 5178 RVA: 0x00057A39 File Offset: 0x00055C39
		public static ParteDelCuerpoHumano PartePrincipalEstimulada(ICalculoDeEstimulo calculo, InteracionEstimulanteBasica estimulo)
		{
			return calculo.PartePrincipalEstimulada(estimulo);
		}

		// Token: 0x0600143B RID: 5179 RVA: 0x00057A42 File Offset: 0x00055C42
		public static PrioridadDeParteDelCuerpoHumanoContexto PrioridadContexto(ICalculoDeEstimulo calculo)
		{
			return calculo.PrioridadContexto();
		}

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x0600143C RID: 5180 RVA: 0x00057A4A File Offset: 0x00055C4A
		public float tiempoDesdeLaUltimaReaccion
		{
			get
			{
				return Time.time - this.m_ultimaReaccionTiempo;
			}
		}

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x0600143D RID: 5181 RVA: 0x00057A58 File Offset: 0x00055C58
		public int lastReaccionFrame
		{
			get
			{
				return this.m_lastReaccionFrame;
			}
		}

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x0600143E RID: 5182 RVA: 0x00057A60 File Offset: 0x00055C60
		public bool lastReaccionResult
		{
			get
			{
				return this.m_lastReaccionResult;
			}
		}

		// Token: 0x0600143F RID: 5183 RVA: 0x00057A68 File Offset: 0x00055C68
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_CoolDownGeneral = new CoolDown(this.baseConfig.coolDownGeneral, 0.05f);
			this.m_MinCoolDownGeneral = new CoolDown(this.baseConfig.minCoolDownGeneral);
		}

		// Token: 0x06001440 RID: 5184 RVA: 0x00057AA4 File Offset: 0x00055CA4
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			ReactorSegundario.Prioridad prioridad = this.baseConfig.prioridad;
			if (prioridad > ReactorSegundario.Prioridad.extraAlta)
			{
				Debug.LogError("Prioridad mal configurada: " + this.baseConfig.prioridad.ToString() + " no es una prioridad valida.", this);
			}
		}

		// Token: 0x06001441 RID: 5185 RVA: 0x00057AF4 File Offset: 0x00055CF4
		protected bool proc(float mod = 1f)
		{
			if (this.baseConfig.probabilidadEsSoloUnoFrame && this.baseConfig.probabilidadUsarNuevoMetodo)
			{
				Debug.LogException(new NotSupportedException("No se puede usar nuevo metodo y ademas probabilidad por un solo frame"), this);
				this.baseConfig.probabilidadUsarNuevoMetodo = false;
			}
			float num = Mathf.Clamp(this.baseConfig.probabilidadPorSegundo * mod, 0f, 100f);
			this.m_lastTickChance = num;
			if (num >= 100f)
			{
				return true;
			}
			if (!this.baseConfig.probabilidadEsSoloUnoFrame)
			{
				if (this.baseConfig.probabilidadUsarNuevoMetodo)
				{
					float num2 = Time.time - this.m_lastProcTimeChance;
					float num3 = ((this.baseConfig.coolDownGeneral < 1f) ? this.baseConfig.coolDownGeneral : 1f);
					if (Mathf.Clamp(num2, 0f, num3) == num3)
					{
						this.m_lastTickChance = num * num3;
						this.m_lastProcTimeChance = Time.time;
					}
					else
					{
						this.m_lastTickChance *= Time.deltaTime;
					}
				}
				else
				{
					this.m_lastTickChance *= Time.deltaTime;
				}
			}
			if (this.m_lastTickChance >= 100f)
			{
				return true;
			}
			if (this.m_lastTickChance <= 0f)
			{
				return false;
			}
			float num4 = Random.value * 100f;
			return this.m_lastTickChance > num4;
		}

		// Token: 0x06001442 RID: 5186
		public abstract bool ReactorPadrePuedeReaccionar(ReactorPadre padre, object arg, out bool negarTodos);

		// Token: 0x06001443 RID: 5187 RVA: 0x00057C30 File Offset: 0x00055E30
		public static int PrioridadParcer(ICalculoDeEstimulo calculo, ReactorSegundario.Prioridad prioridadDeReacctor, double mod = 1.0)
		{
			double num = 1.0;
			switch (prioridadDeReacctor)
			{
			case ReactorSegundario.Prioridad.normal:
				break;
			case ReactorSegundario.Prioridad.baja:
				num = 0.800000011920929;
				break;
			case ReactorSegundario.Prioridad.alta:
				num = 1.2000000476837158;
				break;
			case ReactorSegundario.Prioridad.muyBaja:
				num = 0.6000000238418579;
				break;
			case ReactorSegundario.Prioridad.muyAlta:
				num = 1.399999976158142;
				break;
			case ReactorSegundario.Prioridad.extraBaja:
				num = 0.4000000059604645;
				break;
			case ReactorSegundario.Prioridad.extraAlta:
				num = 1.600000023841858;
				break;
			default:
				throw new ArgumentOutOfRangeException(prioridadDeReacctor.ToString());
			}
			return ReactorSegundario.PrioridadParcer(calculo, num * mod);
		}

		// Token: 0x06001444 RID: 5188 RVA: 0x00057CD0 File Offset: 0x00055ED0
		public static int PrioridadParcer(ICalculoDeEstimulo calculo, double mod = 1.0)
		{
			if (calculo == null)
			{
				return 0;
			}
			switch (calculo.tipo)
			{
			case TipoDeCalculoDeEstimulo.None:
				mod *= 0.0;
				goto IL_009D;
			case TipoDeCalculoDeEstimulo.frame:
				mod *= 1.0;
				goto IL_009D;
			case TipoDeCalculoDeEstimulo.sesionComienza:
				mod *= 1.2;
				goto IL_009D;
			case TipoDeCalculoDeEstimulo.sesionEnCurso:
				mod *= 1.1;
				goto IL_009D;
			case TipoDeCalculoDeEstimulo.sesionTermina:
				mod *= 1.3;
				goto IL_009D;
			}
			throw new ArgumentOutOfRangeException(calculo.tipo.ToString());
			IL_009D:
			if (calculo.producidoPor == null)
			{
				return ReactorSegundario.PrioridadParcer(calculo.prioridad, mod);
			}
			TipoDeCalculadorDeEstimulo tipo = calculo.producidoPor.tipo;
			switch (tipo)
			{
			case TipoDeCalculadorDeEstimulo.None:
				mod *= 0.0;
				goto IL_017C;
			case TipoDeCalculadorDeEstimulo.frame:
				mod *= 1.0;
				goto IL_017C;
			case TipoDeCalculadorDeEstimulo.sesionEspecifica:
				mod *= 1.25;
				goto IL_017C;
			case TipoDeCalculadorDeEstimulo.frame | TipoDeCalculadorDeEstimulo.sesionEspecifica:
			case TipoDeCalculadorDeEstimulo.frame | TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
			case TipoDeCalculadorDeEstimulo.sesionEspecifica | TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
			case TipoDeCalculadorDeEstimulo.frame | TipoDeCalculadorDeEstimulo.sesionEspecifica | TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
				break;
			case TipoDeCalculadorDeEstimulo.sesionEspecificaDe:
				mod *= 1.5;
				goto IL_017C;
			case TipoDeCalculadorDeEstimulo.sesionGeneral:
				mod *= 1.1;
				goto IL_017C;
			default:
				if (tipo == TipoDeCalculadorDeEstimulo.sesionGeneralDe)
				{
					mod *= 1.2;
					goto IL_017C;
				}
				if (tipo == TipoDeCalculadorDeEstimulo.sesionGeneralDeTipoDeCualquierEmocion)
				{
					mod *= 1.05;
					goto IL_017C;
				}
				break;
			}
			throw new ArgumentOutOfRangeException(calculo.producidoPor.tipo.ToString());
			IL_017C:
			return ReactorSegundario.PrioridadParcer(calculo.prioridad * calculo.producidoPor.prioridad, mod);
		}

		// Token: 0x06001445 RID: 5189 RVA: 0x00057E74 File Offset: 0x00056074
		private static int PrioridadParcer(double prioridad, double mod = 1.0)
		{
			if (mod > 100000.0)
			{
				Debug.LogWarning("Mod de prioridad es demaciado alto");
			}
			if (prioridad > 1000000000.0)
			{
				Debug.LogWarning("Prioridad es demaciado alto");
			}
			double num = MathfExtension.InverseLerp(0.0, 100000000000000.0, prioridad * mod);
			num = MathfExtension.Clamp01(num);
			return (int)MathfExtension.Lerp(0.0, 1234567890.0, num);
		}

		// Token: 0x06001446 RID: 5190 RVA: 0x00057EE8 File Offset: 0x000560E8
		public virtual bool Reaccionar(object arg)
		{
			this.OnArgumentoReaccionando(arg);
			bool flag = false;
			bool flag2;
			try
			{
				IList list = arg as IList;
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						object obj = list[i];
						if (this.PuedeReaccionar(obj))
						{
							flag = this.Reacc(obj);
							return flag;
						}
					}
					flag2 = flag;
				}
				else if (this.PuedeReaccionar(arg))
				{
					flag = this.Reacc(arg);
					flag2 = flag;
				}
				else
				{
					flag2 = flag;
				}
			}
			finally
			{
				this.m_lastReaccionFrame = Time.frameCount;
				this.m_lastReaccionResult = flag;
				this.OnArgumentoReaccionado(arg, flag);
			}
			return flag2;
		}

		// Token: 0x06001447 RID: 5191 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void OnArgumentoReaccionando(object arg)
		{
		}

		// Token: 0x06001448 RID: 5192 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void OnArgumentoReaccionado(object arg, bool resultado)
		{
		}

		// Token: 0x06001449 RID: 5193 RVA: 0x00057F84 File Offset: 0x00056184
		protected bool PuedeReaccionar(object arg)
		{
			if (this.debugLog)
			{
				MonoBehaviour.print(string.Concat(new string[]
				{
					"********Reaccionando: ",
					base.name,
					" de type: ",
					base.GetType().Name,
					" a calculo de tipo: ",
					(arg != null) ? arg.GetType().Name : "NULL"
				}));
				MonoBehaviour.print("DataDeArgumento:\n" + JsonUtility.ToJson(arg, true));
			}
			if (!base.isActiveAndEnabled || !base.gameObject.activeInHierarchy)
			{
				if (this.debugLog)
				{
					MonoBehaviour.print("Sin Reaccion: deshabilidato***");
				}
				return false;
			}
			if (this.baseConfig.unIntentoDeReaccionPorFrame && this.m_lastUpdate.IsCurrent())
			{
				if (this.debugLog)
				{
					MonoBehaviour.print("Sin Reaccion: solo un intento por frame***");
				}
				return false;
			}
			if (this.baseConfig.unIntentoEnFrameTipo == ReactorSegundario.UnIntentoEnFrameTipo.antesDeArgumentoValido)
			{
				this.m_lastUpdate = ForcedUpdateId.current;
			}
			if (!this.ArgumentoEsValido(arg))
			{
				if (this.debugLog)
				{
					MonoBehaviour.print("Sin Reaccion: argumento no fue valido********");
				}
				return false;
			}
			if (this.baseConfig.unIntentoEnFrameTipo == ReactorSegundario.UnIntentoEnFrameTipo.despuesDeArgumentoValido)
			{
				this.m_lastUpdate = ForcedUpdateId.current;
			}
			if (!this.IsProcReactor(arg))
			{
				if (this.debugLog)
				{
					MonoBehaviour.print("Sin Reaccion: no hubo suerte no proc***");
				}
				return false;
			}
			if (this.IsOnCoolDown(arg))
			{
				if (this.debugLog)
				{
					MonoBehaviour.print("Sin Reaccion: en CoolDown***");
				}
				return false;
			}
			return true;
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x000580E8 File Offset: 0x000562E8
		protected bool Reacc(object arg)
		{
			bool flag = this.ReaccionarArgumento(arg);
			if (this.debugLog)
			{
				MonoBehaviour.print("Reaccion termino, resultado fue : " + flag.ToString() + "********");
				MonoBehaviour.print("DataDeArgumento:\n" + JsonUtility.ToJson(arg, true));
				MonoBehaviour.print("********");
			}
			this.PostReaccion(flag, arg);
			return flag;
		}

		// Token: 0x0600144B RID: 5195 RVA: 0x0005814C File Offset: 0x0005634C
		protected void PostReaccion(bool resultado, object arg)
		{
			if (resultado)
			{
				this.m_ultimaReaccionTiempo = Time.time;
				this.m_CoolDownGeneral.ApplyNextModed(this.baseConfig.coolDownGeneral, this.nextCoolDownMod);
				this.m_MinCoolDownGeneral.ApplyNext(this.baseConfig.minCoolDownGeneral);
				this.nextCoolDownMod = 1f;
				if (this.debugLogReaccionado)
				{
					Debug.Log(base.name + ": Reacciono\n" + JsonUtility.ToJson(arg, true), this);
				}
			}
			this.Reaccionado(resultado);
		}

		// Token: 0x0600144C RID: 5196 RVA: 0x00003B39 File Offset: 0x00001D39
		protected virtual void Reaccionado(bool resultado)
		{
		}

		// Token: 0x0600144D RID: 5197
		protected abstract bool ArgumentoEsValido(object arg);

		// Token: 0x0600144E RID: 5198
		protected abstract bool ReaccionarArgumento(object arg);

		// Token: 0x0600144F RID: 5199
		protected abstract float CoolDownModificador(object arg);

		// Token: 0x06001450 RID: 5200
		protected abstract float ProbabilidadPorSegundoModificador(object arg);

		// Token: 0x06001451 RID: 5201 RVA: 0x000581D0 File Offset: 0x000563D0
		protected virtual bool IsOnCoolDown(object arg)
		{
			if (this.m_MinCoolDownGeneral.IsOn(1f))
			{
				return true;
			}
			float num = (this.m_lastCoolDownMod = this.CoolDownModificador(arg));
			return this.m_CoolDownGeneral.IsOn(num);
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x00058210 File Offset: 0x00056410
		protected bool IsProcReactor(object arg)
		{
			float num = (this.m_lastProbabilidadPorSegundoMod = this.ProbabilidadPorSegundoModificador(arg));
			if (this.proc(num))
			{
				this.m_lastProcTimeChance = Time.time;
				return true;
			}
			return false;
		}

		// Token: 0x04001097 RID: 4247
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastCoolDownMod = 1f;

		// Token: 0x04001098 RID: 4248
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastProbabilidadPorSegundoMod = 1f;

		// Token: 0x04001099 RID: 4249
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastProcTimeChance;

		// Token: 0x0400109A RID: 4250
		[ReadOnlyUI]
		[SerializeField]
		private float m_lastTickChance = 1f;

		// Token: 0x0400109B RID: 4251
		[ReadOnlyUI]
		[SerializeField]
		protected bool m_lastReaccionResult;

		// Token: 0x0400109C RID: 4252
		[ReadOnlyUI]
		[SerializeField]
		protected int m_lastReaccionFrame;

		// Token: 0x0400109D RID: 4253
		private float m_ultimaReaccionTiempo = float.MinValue;

		// Token: 0x0400109E RID: 4254
		protected float nextCoolDownMod = 1f;

		// Token: 0x0400109F RID: 4255
		private ForcedUpdateId m_lastUpdate;

		// Token: 0x040010A0 RID: 4256
		public bool debugLog;

		// Token: 0x040010A1 RID: 4257
		public bool debugLogReaccionado;

		// Token: 0x040010A2 RID: 4258
		public ReactorSegundario.BaseConfig baseConfig = new ReactorSegundario.BaseConfig();

		// Token: 0x040010A3 RID: 4259
		protected CoolDown m_CoolDownGeneral;

		// Token: 0x040010A4 RID: 4260
		protected CoolDown m_MinCoolDownGeneral;

		// Token: 0x040010A5 RID: 4261
		public const double maxMod = 100000.0;

		// Token: 0x040010A6 RID: 4262
		public const double maxPrioridad = 1000000000.0;

		// Token: 0x040010A7 RID: 4263
		public const double maxPrioridadTotal = 100000000000000.0;

		// Token: 0x0200039D RID: 925
		[Serializable]
		public class BaseConfig
		{
			// Token: 0x040010A8 RID: 4264
			public float minCoolDownGeneral;

			// Token: 0x040010A9 RID: 4265
			[Tooltip("si ya algun calculo no fue valido, ya no se intentara reaccionar mas en el current frame")]
			public bool unIntentoDeReaccionPorFrame;

			// Token: 0x040010AA RID: 4266
			public ReactorSegundario.UnIntentoEnFrameTipo unIntentoEnFrameTipo;

			// Token: 0x040010AB RID: 4267
			[Tooltip("solo puede reaccionar una vez en un frame? false para varias reacciones en un mismo frame")]
			public bool unaSolaReaccionPorFrame = true;

			// Token: 0x040010AC RID: 4268
			public float coolDownGeneral = 0.1f;

			// Token: 0x040010AD RID: 4269
			[Header("Probabilidad")]
			[Range(0f, 100f)]
			public float probabilidadPorSegundo = 10f;

			// Token: 0x040010AE RID: 4270
			[Tooltip("Util para reactores q solo tienen un chance de reaccionar ej session termina/comienza")]
			public bool probabilidadEsSoloUnoFrame;

			// Token: 0x040010AF RID: 4271
			[Tooltip("si se cumple el segundo de probabilidad y no ha sido proc, se usa probabilidad cruda, hace la porbabilidad por segundo mas acertada")]
			public bool probabilidadUsarNuevoMetodo;

			// Token: 0x040010B0 RID: 4272
			[Header("Prioridad")]
			public ReactorSegundario.Prioridad prioridad;

			// Token: 0x040010B1 RID: 4273
			[Tooltip("entre la Prioridad, se organizan segun este numero, mayor es primero")]
			public int prioridadEspecifica;
		}

		// Token: 0x0200039E RID: 926
		public enum UnIntentoEnFrameTipo
		{
			// Token: 0x040010B3 RID: 4275
			despuesDeArgumentoValido,
			// Token: 0x040010B4 RID: 4276
			antesDeArgumentoValido
		}

		// Token: 0x0200039F RID: 927
		public enum Prioridad
		{
			// Token: 0x040010B6 RID: 4278
			normal,
			// Token: 0x040010B7 RID: 4279
			baja,
			// Token: 0x040010B8 RID: 4280
			alta,
			// Token: 0x040010B9 RID: 4281
			muyBaja,
			// Token: 0x040010BA RID: 4282
			muyAlta,
			// Token: 0x040010BB RID: 4283
			extraBaja,
			// Token: 0x040010BC RID: 4284
			extraAlta
		}
	}
}
