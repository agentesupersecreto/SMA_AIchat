using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.Ropa.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones
{
	// Token: 0x02000409 RID: 1033
	public sealed class DesHielo : Emocion
	{
		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x06001699 RID: 5785 RVA: 0x00004252 File Offset: 0x00002452
		protected override bool limiteMinimoPuedeAlcanzar100
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x0600169A RID: 5786 RVA: 0x00030684 File Offset: 0x0002E884
		public override float prioridad
		{
			get
			{
				return 1f;
			}
		}

		// Token: 0x170005B2 RID: 1458
		// (get) Token: 0x0600169B RID: 5787 RVA: 0x0005D1E3 File Offset: 0x0005B3E3
		public override ReaccionHumana reaccion
		{
			get
			{
				return ReaccionHumana.desHielo;
			}
		}

		// Token: 0x170005B3 RID: 1459
		// (get) Token: 0x0600169C RID: 5788 RVA: 0x0005D1EA File Offset: 0x0005B3EA
		protected override float modificadorDeAumentoDeEmocionPorPersonalidad
		{
			get
			{
				return this.m_Personalidad.desHieloGananciaPorPersonalidad * (1f / this.m_Personalidad.miedoGananciaPorPersonalidad);
			}
		}

		// Token: 0x170005B4 RID: 1460
		// (get) Token: 0x0600169D RID: 5789 RVA: 0x0005D209 File Offset: 0x0005B409
		protected override float modificadorDeDisminucionEmocionPorPersonalidad
		{
			get
			{
				return 1f / this.modificadorDeAumentoDeEmocionPorPersonalidad * this.m_Personalidad.miedoGananciaPorPersonalidad;
			}
		}

		// Token: 0x0600169E RID: 5790 RVA: 0x0005CDD1 File Offset: 0x0005AFD1
		protected override void UpdateValue(ref float aumento, ref float aumentoCrudo, ref float valorACambiar)
		{
			aumentoCrudo = aumento;
		}

		// Token: 0x0600169F RID: 5791 RVA: 0x0005D224 File Offset: 0x0005B424
		public float ObtenerValor(ICalculoDeInteracionEstimulante calculo)
		{
			ValueTuple<int, int, int, int> valueTuple;
			return this.ObtenerValor(calculo, out valueTuple);
		}

		// Token: 0x060016A0 RID: 5792 RVA: 0x0005D23C File Offset: 0x0005B43C
		public float ObtenerValor(ICalculoDeInteracionEstimulante calculo, [TupleElementNames(new string[] { "estimulado", "tipoDeEstimulo", "direccion", "subTipoDeEstimulo" })] out ValueTuple<int, int, int, int> key)
		{
			key = default(ValueTuple<int, int, int, int>);
			if (((calculo != null) ? calculo.estimuloBasico : null) == null)
			{
				return 0f;
			}
			switch (calculo.estimuloBasico.tipoDeEstimulo)
			{
			case TipoDeEstimulo.tactil:
				return Mathf.Clamp(this.ObtenerValor(calculo.estimuloBasico as EstimuloTactil, out key), 0f, 100f);
			case TipoDeEstimulo.visual:
				return Mathf.Clamp(this.ObtenerValor(calculo.estimuloBasico as EstimuloVisual, out key), 0f, 100f);
			case TipoDeEstimulo.coital:
				return Mathf.Clamp(this.ObtenerValor(calculo.estimuloBasico as EstimuloPenetrante, out key), 0f, 100f);
			case TipoDeEstimulo.desvestidura:
			case TipoDeEstimulo.peticionDesvestidura:
				return Mathf.Clamp(this.ObtenerValor(calculo.estimuloBasico as EstimuloPorDesvestir, out key), 0f, 100f);
			case TipoDeEstimulo.ejecucionDePose:
			case TipoDeEstimulo.peticionEjecucionDePose:
				return Mathf.Clamp(this.ObtenerValor(calculo.estimuloBasico as IEstimuloPorCambiarPose, out key), 0f, 100f);
			case TipoDeEstimulo.guiandoBone:
			case TipoDeEstimulo.manipulandoBone:
				return Mathf.Clamp(this.ObtenerValor(calculo.estimuloBasico as IEstimuloPorMovimientoDeBone, out key), 0f, 100f);
			}
			Debug.LogWarning("No hay valores de deshielo para " + calculo.estimuloBasico.tipoDeEstimulo.ToString(), this);
			return 100f;
		}

		// Token: 0x060016A1 RID: 5793 RVA: 0x0005D3B4 File Offset: 0x0005B5B4
		public float ObtenerValor(ICalculoDeInteracionEstimulanteDeParteEstimulante calculo, ParteQuePuedeEstimular? estimulante, ParteDelCuerpoHumano? estimulado, TipoDeEstimulo? tipoDeEstimulo, DireccionDeEstimulo? direccion, int? subTipoDeEstimulo)
		{
			ValueTuple<int, int, int, int> valueTuple;
			return this.ObtenerValor(calculo, out valueTuple, estimulante, estimulado, tipoDeEstimulo, direccion, subTipoDeEstimulo);
		}

		// Token: 0x060016A2 RID: 5794 RVA: 0x0005D3D4 File Offset: 0x0005B5D4
		public float ObtenerValor(ICalculoDeInteracionEstimulanteDeParteEstimulante calculo, [TupleElementNames(new string[] { "estimulado", "tipoDeEstimulo", "direccion", "subTipoDeEstimulo" })] out ValueTuple<int, int, int, int> key, ParteQuePuedeEstimular? estimulante, ParteDelCuerpoHumano? estimulado, TipoDeEstimulo? tipoDeEstimulo, DireccionDeEstimulo? direccion, int? subTipoDeEstimulo)
		{
			key = default(ValueTuple<int, int, int, int>);
			if (((calculo != null) ? calculo.estimuloBasico : null) == null)
			{
				return 0f;
			}
			ParteDelCuerpoHumano parteDelCuerpoHumano = estimulado ?? calculo.estimuloBasico.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed);
			TipoDeEstimulo tipoDeEstimulo2 = tipoDeEstimulo ?? calculo.estimuloBasico.tipoDeEstimulo;
			DireccionDeEstimulo direccionDeEstimulo = direccion ?? calculo.estimuloBasico.tipo;
			int num = subTipoDeEstimulo ?? (estimulante ?? calculo.estimulanteParte).ObtenerTipoDeEstimulo(tipoDeEstimulo2, parteDelCuerpoHumano, calculo.tag == "golpe", calculo.estimuloBasico);
			return Mathf.Clamp(this.ObtenerValor(parteDelCuerpoHumano, tipoDeEstimulo2, direccionDeEstimulo, num, out key), 0f, 100f);
		}

		// Token: 0x060016A3 RID: 5795 RVA: 0x0005D4CC File Offset: 0x0005B6CC
		public float ObtenerValor(ParteDelCuerpoHumano estimulado, TipoDeEstimulo tipoDeEstimulo, DireccionDeEstimulo direccion, int subTipoDeEstimulo, [TupleElementNames(new string[] { "estimulado", "tipoDeEstimulo", "direccion", "subTipoDeEstimulo" })] out ValueTuple<int, int, int, int> key)
		{
			key = new ValueTuple<int, int, int, int>((int)estimulado, (int)tipoDeEstimulo, (int)direccion, subTipoDeEstimulo);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(key, out desHieloBase))
			{
				return 0f;
			}
			return desHieloBase.value.total;
		}

		// Token: 0x060016A4 RID: 5796 RVA: 0x0005D514 File Offset: 0x0005B714
		private float ObtenerValor(EstimuloTactil estimulo, out ValueTuple<int, int, int, int> key)
		{
			key = default(ValueTuple<int, int, int, int>);
			if (estimulo == null)
			{
				return 0f;
			}
			key = new ValueTuple<int, int, int, int>((int)estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), (int)estimulo.tipoDeEstimulo, (int)estimulo.tipo, (int)estimulo.tipoDeEstimuloTactil);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(key, out desHieloBase))
			{
				return 0f;
			}
			return desHieloBase.value.total;
		}

		// Token: 0x060016A5 RID: 5797 RVA: 0x0005D57C File Offset: 0x0005B77C
		private float ObtenerValor(EstimuloVisual estimulo, out ValueTuple<int, int, int, int> key)
		{
			key = default(ValueTuple<int, int, int, int>);
			if (estimulo == null)
			{
				return 0f;
			}
			key = new ValueTuple<int, int, int, int>((int)estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), (int)estimulo.tipoDeEstimulo, (int)estimulo.tipo, (int)estimulo.tipoDeEstimuloVisual);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(key, out desHieloBase))
			{
				return 0f;
			}
			return desHieloBase.value.total;
		}

		// Token: 0x060016A6 RID: 5798 RVA: 0x0005D5E4 File Offset: 0x0005B7E4
		private float ObtenerValor(EstimuloPenetrante estimulo, out ValueTuple<int, int, int, int> key)
		{
			key = default(ValueTuple<int, int, int, int>);
			if (estimulo == null)
			{
				return 0f;
			}
			key = new ValueTuple<int, int, int, int>((int)estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), (int)estimulo.tipoDeEstimulo, (int)estimulo.tipo, (int)estimulo.tipoDeEstimuloCoital);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(key, out desHieloBase))
			{
				return 0f;
			}
			return desHieloBase.value.total;
		}

		// Token: 0x060016A7 RID: 5799 RVA: 0x0005D64C File Offset: 0x0005B84C
		private float ObtenerValor(EstimuloPorDesvestir estimulo, out ValueTuple<int, int, int, int> key)
		{
			key = default(ValueTuple<int, int, int, int>);
			if (estimulo == null)
			{
				return 0f;
			}
			key = new ValueTuple<int, int, int, int>((int)estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), (int)estimulo.tipoDeEstimulo, (int)estimulo.tipo, 0);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(key, out desHieloBase))
			{
				return 0f;
			}
			return desHieloBase.value.total;
		}

		// Token: 0x060016A8 RID: 5800 RVA: 0x0005D6B0 File Offset: 0x0005B8B0
		private float ObtenerValor(IEstimuloPorCambiarPose estimulo, out ValueTuple<int, int, int, int> key)
		{
			key = default(ValueTuple<int, int, int, int>);
			if (estimulo == null)
			{
				return 0f;
			}
			key = new ValueTuple<int, int, int, int>((int)estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), (int)estimulo.tipoDeEstimulo, (int)estimulo.tipo, (int)estimulo.tipoDeEstimuloCambiarPose);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(key, out desHieloBase))
			{
				return 0f;
			}
			return desHieloBase.value.total;
		}

		// Token: 0x060016A9 RID: 5801 RVA: 0x0005D718 File Offset: 0x0005B918
		private float ObtenerValor(IEstimuloPorMovimientoDeBone estimulo, out ValueTuple<int, int, int, int> key)
		{
			key = default(ValueTuple<int, int, int, int>);
			if (estimulo == null)
			{
				return 0f;
			}
			key = new ValueTuple<int, int, int, int>((int)estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), (int)estimulo.tipoDeEstimulo, (int)estimulo.tipo, 0);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(key, out desHieloBase))
			{
				return 0f;
			}
			return desHieloBase.value.total;
		}

		// Token: 0x060016AA RID: 5802 RVA: 0x0005D77C File Offset: 0x0005B97C
		public void RegistrarEstimuloGenerico(IInteracionEstimulanteBasica estimulo, float value, float desHieloGlobalMod, ref float generadoNoLimitado, ref float generadoLimitado)
		{
			EstimuloVisual estimuloVisual = estimulo as EstimuloVisual;
			if (estimuloVisual != null)
			{
				this.RegistrarEstimulo(estimuloVisual, value, desHieloGlobalMod, ref generadoNoLimitado, ref generadoLimitado);
				return;
			}
			EstimuloTactil estimuloTactil = estimulo as EstimuloTactil;
			if (estimuloTactil != null)
			{
				this.RegistrarEstimulo(estimuloTactil, value, desHieloGlobalMod, ref generadoNoLimitado, ref generadoLimitado);
				return;
			}
			EstimuloPenetrante estimuloPenetrante = estimulo as EstimuloPenetrante;
			if (estimuloPenetrante != null)
			{
				this.RegistrarEstimulo(estimuloPenetrante, value, desHieloGlobalMod, ref generadoNoLimitado, ref generadoLimitado);
				return;
			}
			IEstimuloPorMovimientoDeBone estimuloPorMovimientoDeBone = estimulo as IEstimuloPorMovimientoDeBone;
			if (estimuloPorMovimientoDeBone != null)
			{
				this.RegistrarEstimulo(estimuloPorMovimientoDeBone, value, desHieloGlobalMod, ref generadoNoLimitado, ref generadoLimitado);
				return;
			}
			IEstimuloPorCambiarPose estimuloPorCambiarPose = estimulo as IEstimuloPorCambiarPose;
			if (estimuloPorCambiarPose != null)
			{
				this.RegistrarEstimulo(estimuloPorCambiarPose, value, desHieloGlobalMod, ref generadoNoLimitado, ref generadoLimitado);
				return;
			}
			EstimuloPorDesvestir estimuloPorDesvestir = estimulo as EstimuloPorDesvestir;
			if (estimuloPorDesvestir == null)
			{
				throw new ArgumentOutOfRangeException(estimulo.ToString());
			}
			this.RegistrarEstimulo(estimuloPorDesvestir, value, desHieloGlobalMod, ref generadoNoLimitado, ref generadoLimitado);
		}

		// Token: 0x060016AB RID: 5803 RVA: 0x0005D82C File Offset: 0x0005BA2C
		public void RegistrarEstimulo(IEstimuloPorCambiarPose estimulo, float value, float desHieloGlobalMod, ref float generadoNoLimitado, ref float generadoLimitado)
		{
			TipoDeEstimulo tipoDeEstimulo = estimulo.tipoDeEstimulo;
			DesHielo.DesHieloCambioDePose desHieloCambioDePose;
			if (tipoDeEstimulo != TipoDeEstimulo.ejecucionDePose)
			{
				if (tipoDeEstimulo != TipoDeEstimulo.peticionEjecucionDePose)
				{
					throw new ArgumentOutOfRangeException(estimulo.tipoDeEstimulo.ToString());
				}
				desHieloCambioDePose = this.GetNotNullPeticionCambioDePose(estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), estimulo.tipo, estimulo.tipoDeEstimuloCambiarPose);
			}
			else
			{
				desHieloCambioDePose = this.GetNotNullCambioDePose(estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), estimulo.tipo, estimulo.tipoDeEstimuloCambiarPose);
			}
			if (desHieloCambioDePose.value.total < 100f)
			{
				DesHielo.DesHieloCambioDePose desHieloCambioDePose2 = desHieloCambioDePose;
				desHieloCambioDePose2.value.moded = desHieloCambioDePose2.value.moded + value;
				if (desHieloCambioDePose.debugPrintVelocity)
				{
					Debug.LogWarning((value / Time.deltaTime).ToString() + " por segundo deshielo aumentando: " + estimulo.tipoDeEstimulo.ToString());
				}
			}
			else
			{
				desHieloGlobalMod *= 0.1f;
			}
			generadoLimitado += value * desHieloGlobalMod;
			generadoNoLimitado += value * desHieloGlobalMod;
		}

		// Token: 0x060016AC RID: 5804 RVA: 0x0005D91C File Offset: 0x0005BB1C
		public void RegistrarEstimulo(IEstimuloPorMovimientoDeBone estimulo, float value, float desHieloGlobalMod, ref float generadoNoLimitado, ref float generadoLimitado)
		{
			TipoDeEstimulo tipoDeEstimulo = estimulo.tipoDeEstimulo;
			DesHielo.DesHieloMovimientoDeBone desHieloMovimientoDeBone;
			if (tipoDeEstimulo != TipoDeEstimulo.guiandoBone)
			{
				if (tipoDeEstimulo != TipoDeEstimulo.manipulandoBone)
				{
					throw new ArgumentOutOfRangeException(estimulo.tipoDeEstimulo.ToString());
				}
				desHieloMovimientoDeBone = this.GetNotNullMovimientoDeBone(estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), estimulo.tipo);
			}
			else
			{
				desHieloMovimientoDeBone = this.GetNotNullPeticionMovimientoDeBone(estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), estimulo.tipo);
			}
			if (desHieloMovimientoDeBone.value.total < 100f)
			{
				DesHielo.DesHieloMovimientoDeBone desHieloMovimientoDeBone2 = desHieloMovimientoDeBone;
				desHieloMovimientoDeBone2.value.moded = desHieloMovimientoDeBone2.value.moded + value;
				if (desHieloMovimientoDeBone.debugPrintVelocity)
				{
					Debug.LogWarning((value / Time.deltaTime).ToString() + " por segundo deshielo aumentando: " + estimulo.tipoDeEstimulo.ToString());
				}
			}
			else
			{
				desHieloGlobalMod *= 0.1f;
			}
			generadoLimitado += value * desHieloGlobalMod;
			generadoNoLimitado += value * desHieloGlobalMod;
		}

		// Token: 0x060016AD RID: 5805 RVA: 0x0005DA00 File Offset: 0x0005BC00
		public void RegistrarEstimulo(EstimuloPorDesvestir estimulo, float value, float desHieloGlobalMod, ref float generadoNoLimitado, ref float generadoLimitado)
		{
			TipoDeEstimulo tipoDeEstimulo = estimulo.tipoDeEstimulo;
			DesHielo.DesHieloDesvestidura desHieloDesvestidura;
			if (tipoDeEstimulo != TipoDeEstimulo.desvestidura)
			{
				if (tipoDeEstimulo != TipoDeEstimulo.peticionDesvestidura)
				{
					throw new ArgumentOutOfRangeException(estimulo.tipoDeEstimulo.ToString());
				}
				desHieloDesvestidura = this.GetNotNullPeticionDesvestir(estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), estimulo.tipo, 0);
			}
			else
			{
				desHieloDesvestidura = this.GetNotNullDesvestir(estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), estimulo.tipo, 0);
			}
			if (desHieloDesvestidura.value.total < 100f)
			{
				DesHielo.DesHieloDesvestidura desHieloDesvestidura2 = desHieloDesvestidura;
				desHieloDesvestidura2.value.moded = desHieloDesvestidura2.value.moded + value;
				if (desHieloDesvestidura.debugPrintVelocity)
				{
					Debug.LogWarning((value / Time.deltaTime).ToString() + " por segundo deshielo aumentando: " + estimulo.tipoDeEstimulo.ToString());
				}
			}
			else
			{
				desHieloGlobalMod *= 0.1f;
			}
			generadoLimitado += value * desHieloGlobalMod;
			generadoNoLimitado += value * desHieloGlobalMod;
		}

		// Token: 0x060016AE RID: 5806 RVA: 0x0005DAE4 File Offset: 0x0005BCE4
		public void RegistrarEstimulo(EstimuloTactil estimulo, float value, float desHieloGlobalMod, ref float generadoNoLimitado, ref float generadoLimitado)
		{
			DesHielo.DesHieloTactil notNullTactil = this.GetNotNullTactil(estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), estimulo.tipo, estimulo.tipoDeEstimuloTactil);
			if (notNullTactil.value.total < 100f)
			{
				DesHielo.DesHieloTactil desHieloTactil = notNullTactil;
				desHieloTactil.value.moded = desHieloTactil.value.moded + value;
				if (notNullTactil.debugPrintVelocity)
				{
					Debug.LogWarning((value / Time.deltaTime).ToString() + " por segundo deshielo aumentando: " + estimulo.tipoDeEstimulo.ToString());
				}
			}
			else
			{
				desHieloGlobalMod *= 0.1f;
			}
			generadoLimitado += value * desHieloGlobalMod;
			generadoNoLimitado += value * desHieloGlobalMod;
		}

		// Token: 0x060016AF RID: 5807 RVA: 0x0005DB88 File Offset: 0x0005BD88
		public void RegistrarEstimulo(EstimuloPenetrante estimulo, float value, float desHieloGlobalMod, ref float generadoNoLimitado, ref float generadoLimitado)
		{
			DesHielo.DesHieloCoital notNullCoital = this.GetNotNullCoital(estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), estimulo.tipo, estimulo.tipoDeEstimuloCoital);
			if (notNullCoital.value.total < 100f)
			{
				DesHielo.DesHieloCoital desHieloCoital = notNullCoital;
				desHieloCoital.value.moded = desHieloCoital.value.moded + value;
				if (notNullCoital.debugPrintVelocity)
				{
					Debug.LogWarning((value / Time.deltaTime).ToString() + " por segundo deshielo aumentando: " + estimulo.tipoDeEstimulo.ToString());
				}
			}
			else
			{
				desHieloGlobalMod *= 0.1f;
			}
			generadoLimitado += value * desHieloGlobalMod;
			generadoNoLimitado += value * desHieloGlobalMod;
		}

		// Token: 0x060016B0 RID: 5808 RVA: 0x0005DC2C File Offset: 0x0005BE2C
		public void RegistrarEstimulo(EstimuloVisual estimulo, float value, float desHieloGlobalMod, ref float generadoNoLimitado, ref float generadoLimitado)
		{
			DesHielo.DesHieloVisual notNullVisual = this.GetNotNullVisual(estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed), estimulo.tipo, estimulo.tipoDeEstimuloVisual);
			if (notNullVisual.value.total < 100f)
			{
				DesHielo.DesHieloVisual desHieloVisual = notNullVisual;
				desHieloVisual.value.moded = desHieloVisual.value.moded + value;
				if (notNullVisual.debugPrintVelocity)
				{
					Debug.LogWarning((value / Time.deltaTime).ToString() + " por segundo deshielo aumentando: " + estimulo.tipoDeEstimulo.ToString());
				}
			}
			else
			{
				desHieloGlobalMod *= 0.1f;
			}
			generadoLimitado += value * desHieloGlobalMod;
			generadoNoLimitado += value * desHieloGlobalMod;
		}

		// Token: 0x060016B1 RID: 5809 RVA: 0x0005DCD0 File Offset: 0x0005BED0
		public void SetTo(float value, TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulante)
		{
			switch (tipoDeEstimulo)
			{
			case TipoDeEstimulo.tactil:
				this.SetTactilTo(value, estimulada, direccion, estimulante.ObtenerTipoDeEstimuloTactil(false, estimulada));
				return;
			case TipoDeEstimulo.visual:
				this.SetVisualTo(value, estimulada, direccion, estimulante.ObtenerTipoDeEstimuloVisual());
				return;
			case TipoDeEstimulo.coital:
				this.SetCoitalTo(value, estimulada, direccion, estimulante.ObtenerTipoDeEstimuloCoital());
				return;
			case TipoDeEstimulo.desvestidura:
				this.SetDesvestiduraTo(value, estimulada, direccion, 0);
				return;
			case TipoDeEstimulo.peticionDesvestidura:
				this.SetPeticionDesvestiduraTo(value, estimulada, direccion, 0);
				return;
			case TipoDeEstimulo.ejecucionDePose:
				this.SetCambioDePoseTo(value, estimulada, direccion, TipoDeEstimuloCambiarPose.None);
				return;
			case TipoDeEstimulo.peticionEjecucionDePose:
				this.SetPeticionCambioDePoseTo(value, estimulada, direccion, TipoDeEstimuloCambiarPose.None);
				return;
			case TipoDeEstimulo.guiandoBone:
				this.SetGuiandoDeBoneTo(value, estimulada, direccion);
				return;
			case TipoDeEstimulo.manipulandoBone:
				this.SetManipulacionDeBoneTo(value, estimulada, direccion);
				return;
			}
			throw new ArgumentOutOfRangeException(tipoDeEstimulo.ToString());
		}

		// Token: 0x060016B2 RID: 5810 RVA: 0x0005DDB5 File Offset: 0x0005BFB5
		public void SetCoitalTo(float value, ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, TipoDeEstimuloCoital subtipo)
		{
			DesHielo.DesHieloCoital notNullCoital = this.GetNotNullCoital(estimulada, direccion, subtipo);
			notNullCoital.value.moded = notNullCoital.value.moded + value;
		}

		// Token: 0x060016B3 RID: 5811 RVA: 0x0005DDD0 File Offset: 0x0005BFD0
		public void SetTactilTo(float value, ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, TipoDeEstimuloTactil subtipo)
		{
			DesHielo.DesHieloTactil notNullTactil = this.GetNotNullTactil(estimulada, direccion, subtipo);
			notNullTactil.value.moded = notNullTactil.value.moded + value;
		}

		// Token: 0x060016B4 RID: 5812 RVA: 0x0005DDEB File Offset: 0x0005BFEB
		public void SetVisualTo(float value, ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, TipoDeEstimuloVisual subtipo)
		{
			DesHielo.DesHieloVisual notNullVisual = this.GetNotNullVisual(estimulada, direccion, subtipo);
			notNullVisual.value.moded = notNullVisual.value.moded + value;
		}

		// Token: 0x060016B5 RID: 5813 RVA: 0x0005DE06 File Offset: 0x0005C006
		public void SetPeticionCambioDePoseTo(float value, ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, TipoDeEstimuloCambiarPose subtipo)
		{
			DesHielo.DesHieloCambioDePose notNullPeticionCambioDePose = this.GetNotNullPeticionCambioDePose(estimulada, direccion, subtipo);
			notNullPeticionCambioDePose.value.moded = notNullPeticionCambioDePose.value.moded + value;
		}

		// Token: 0x060016B6 RID: 5814 RVA: 0x0005DE21 File Offset: 0x0005C021
		public void SetCambioDePoseTo(float value, ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, TipoDeEstimuloCambiarPose subtipo)
		{
			DesHielo.DesHieloCambioDePose notNullCambioDePose = this.GetNotNullCambioDePose(estimulada, direccion, subtipo);
			notNullCambioDePose.value.moded = notNullCambioDePose.value.moded + value;
		}

		// Token: 0x060016B7 RID: 5815 RVA: 0x0005DE3C File Offset: 0x0005C03C
		public void SetPeticionDesvestiduraTo(float value, ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, int subtipo)
		{
			DesHielo.DesHieloDesvestidura notNullPeticionDesvestir = this.GetNotNullPeticionDesvestir(estimulada, direccion, subtipo);
			notNullPeticionDesvestir.value.moded = notNullPeticionDesvestir.value.moded + value;
		}

		// Token: 0x060016B8 RID: 5816 RVA: 0x0005DE57 File Offset: 0x0005C057
		public void SetDesvestiduraTo(float value, ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, int subtipo)
		{
			DesHielo.DesHieloDesvestidura notNullDesvestir = this.GetNotNullDesvestir(estimulada, direccion, subtipo);
			notNullDesvestir.value.moded = notNullDesvestir.value.moded + value;
		}

		// Token: 0x060016B9 RID: 5817 RVA: 0x0005DE72 File Offset: 0x0005C072
		public void SetGuiandoDeBoneTo(float value, ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion)
		{
			DesHielo.DesHieloMovimientoDeBone notNullPeticionMovimientoDeBone = this.GetNotNullPeticionMovimientoDeBone(estimulada, direccion);
			notNullPeticionMovimientoDeBone.value.moded = notNullPeticionMovimientoDeBone.value.moded + value;
		}

		// Token: 0x060016BA RID: 5818 RVA: 0x0005DE8B File Offset: 0x0005C08B
		public void SetManipulacionDeBoneTo(float value, ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion)
		{
			DesHielo.DesHieloMovimientoDeBone notNullMovimientoDeBone = this.GetNotNullMovimientoDeBone(estimulada, direccion);
			notNullMovimientoDeBone.value.moded = notNullMovimientoDeBone.value.moded + value;
		}

		// Token: 0x060016BB RID: 5819 RVA: 0x0005DEA4 File Offset: 0x0005C0A4
		private DesHielo.DesHieloVisual GetNotNullVisual(ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, TipoDeEstimuloVisual subtipo)
		{
			ValueTuple<int, int, int, int> valueTuple = DesHielo.DesHieloVisual.Key(estimulada, TipoDeEstimulo.visual, direccion, subtipo);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(valueTuple, out desHieloBase))
			{
				desHieloBase = new DesHielo.DesHieloVisual(estimulada, TipoDeEstimulo.visual, direccion, subtipo);
				this.m_DesHieloDeTiposDeEstimulo.Add(valueTuple, desHieloBase);
				this.m_Visuales.Add((DesHielo.DesHieloVisual)desHieloBase);
			}
			return (DesHielo.DesHieloVisual)desHieloBase;
		}

		// Token: 0x060016BC RID: 5820 RVA: 0x0005DEFC File Offset: 0x0005C0FC
		private DesHielo.DesHieloCoital GetNotNullCoital(ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, TipoDeEstimuloCoital subtipo)
		{
			ValueTuple<int, int, int, int> valueTuple = DesHielo.DesHieloCoital.Key(estimulada, TipoDeEstimulo.coital, direccion, subtipo);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(valueTuple, out desHieloBase))
			{
				desHieloBase = new DesHielo.DesHieloCoital(estimulada, TipoDeEstimulo.coital, direccion, subtipo);
				this.m_DesHieloDeTiposDeEstimulo.Add(valueTuple, desHieloBase);
				this.m_Coitales.Add((DesHielo.DesHieloCoital)desHieloBase);
			}
			return (DesHielo.DesHieloCoital)desHieloBase;
		}

		// Token: 0x060016BD RID: 5821 RVA: 0x0005DF54 File Offset: 0x0005C154
		private DesHielo.DesHieloTactil GetNotNullTactil(ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, TipoDeEstimuloTactil subtipo)
		{
			ValueTuple<int, int, int, int> valueTuple = DesHielo.DesHieloTactil.Key(estimulada, TipoDeEstimulo.tactil, direccion, subtipo);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(valueTuple, out desHieloBase))
			{
				desHieloBase = new DesHielo.DesHieloTactil(estimulada, TipoDeEstimulo.tactil, direccion, subtipo);
				this.m_DesHieloDeTiposDeEstimulo.Add(valueTuple, desHieloBase);
				this.m_Tactiles.Add((DesHielo.DesHieloTactil)desHieloBase);
			}
			return (DesHielo.DesHieloTactil)desHieloBase;
		}

		// Token: 0x060016BE RID: 5822 RVA: 0x0005DFAC File Offset: 0x0005C1AC
		private DesHielo.DesHieloCambioDePose GetNotNullCambioDePose(ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, TipoDeEstimuloCambiarPose subtipo)
		{
			ValueTuple<int, int, int, int> valueTuple = DesHielo.DesHieloCambioDePose.Key(estimulada, TipoDeEstimulo.ejecucionDePose, direccion, subtipo);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(valueTuple, out desHieloBase))
			{
				desHieloBase = new DesHielo.DesHieloCambioDePose(estimulada, TipoDeEstimulo.ejecucionDePose, direccion, subtipo);
				this.m_DesHieloDeTiposDeEstimulo.Add(valueTuple, desHieloBase);
				this.m_CambioDePose.Add((DesHielo.DesHieloCambioDePose)desHieloBase);
			}
			return (DesHielo.DesHieloCambioDePose)desHieloBase;
		}

		// Token: 0x060016BF RID: 5823 RVA: 0x0005E004 File Offset: 0x0005C204
		private DesHielo.DesHieloCambioDePose GetNotNullPeticionCambioDePose(ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, TipoDeEstimuloCambiarPose subtipo)
		{
			ValueTuple<int, int, int, int> valueTuple = DesHielo.DesHieloCambioDePose.Key(estimulada, TipoDeEstimulo.peticionEjecucionDePose, direccion, subtipo);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(valueTuple, out desHieloBase))
			{
				desHieloBase = new DesHielo.DesHieloCambioDePose(estimulada, TipoDeEstimulo.peticionEjecucionDePose, direccion, subtipo);
				this.m_DesHieloDeTiposDeEstimulo.Add(valueTuple, desHieloBase);
				this.m_PeticionCambioDePose.Add((DesHielo.DesHieloCambioDePose)desHieloBase);
			}
			return (DesHielo.DesHieloCambioDePose)desHieloBase;
		}

		// Token: 0x060016C0 RID: 5824 RVA: 0x0005E05C File Offset: 0x0005C25C
		private DesHielo.DesHieloDesvestidura GetNotNullPeticionDesvestir(ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, int subtipo)
		{
			ValueTuple<int, int, int, int> valueTuple = DesHielo.DesHieloDesvestidura.Key(estimulada, TipoDeEstimulo.peticionDesvestidura, direccion, subtipo);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(valueTuple, out desHieloBase))
			{
				desHieloBase = new DesHielo.DesHieloDesvestidura(estimulada, TipoDeEstimulo.peticionDesvestidura, direccion, subtipo);
				this.m_DesHieloDeTiposDeEstimulo.Add(valueTuple, desHieloBase);
				this.m_PeticionDesvestidura.Add((DesHielo.DesHieloDesvestidura)desHieloBase);
			}
			return (DesHielo.DesHieloDesvestidura)desHieloBase;
		}

		// Token: 0x060016C1 RID: 5825 RVA: 0x0005E0B4 File Offset: 0x0005C2B4
		private DesHielo.DesHieloDesvestidura GetNotNullDesvestir(ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, int subtipo)
		{
			ValueTuple<int, int, int, int> valueTuple = DesHielo.DesHieloDesvestidura.Key(estimulada, TipoDeEstimulo.desvestidura, direccion, subtipo);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(valueTuple, out desHieloBase))
			{
				desHieloBase = new DesHielo.DesHieloDesvestidura(estimulada, TipoDeEstimulo.desvestidura, direccion, subtipo);
				this.m_DesHieloDeTiposDeEstimulo.Add(valueTuple, desHieloBase);
				this.m_Desvestidura.Add((DesHielo.DesHieloDesvestidura)desHieloBase);
			}
			return (DesHielo.DesHieloDesvestidura)desHieloBase;
		}

		// Token: 0x060016C2 RID: 5826 RVA: 0x0005E10C File Offset: 0x0005C30C
		private DesHielo.DesHieloMovimientoDeBone GetNotNullMovimientoDeBone(ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion)
		{
			ValueTuple<int, int, int, int> valueTuple = DesHielo.DesHieloMovimientoDeBone.Key(estimulada, TipoDeEstimulo.manipulandoBone, direccion);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(valueTuple, out desHieloBase))
			{
				desHieloBase = new DesHielo.DesHieloMovimientoDeBone(estimulada, TipoDeEstimulo.manipulandoBone, direccion);
				this.m_DesHieloDeTiposDeEstimulo.Add(valueTuple, desHieloBase);
				this.m_MovimientoDeBone.Add((DesHielo.DesHieloMovimientoDeBone)desHieloBase);
			}
			return (DesHielo.DesHieloMovimientoDeBone)desHieloBase;
		}

		// Token: 0x060016C3 RID: 5827 RVA: 0x0005E164 File Offset: 0x0005C364
		private DesHielo.DesHieloMovimientoDeBone GetNotNullPeticionMovimientoDeBone(ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion)
		{
			ValueTuple<int, int, int, int> valueTuple = DesHielo.DesHieloMovimientoDeBone.Key(estimulada, TipoDeEstimulo.guiandoBone, direccion);
			DesHielo.DesHieloBase desHieloBase;
			if (!this.m_DesHieloDeTiposDeEstimulo.TryGetValue(valueTuple, out desHieloBase))
			{
				desHieloBase = new DesHielo.DesHieloMovimientoDeBone(estimulada, TipoDeEstimulo.guiandoBone, direccion);
				this.m_DesHieloDeTiposDeEstimulo.Add(valueTuple, desHieloBase);
				this.m_PeticionMovimientoDeBone.Add((DesHielo.DesHieloMovimientoDeBone)desHieloBase);
			}
			return (DesHielo.DesHieloMovimientoDeBone)desHieloBase;
		}

		// Token: 0x060016C4 RID: 5828 RVA: 0x0005E1BC File Offset: 0x0005C3BC
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			foreach (KeyValuePair<ValueTuple<int, int, int, int>, DesHielo.DesHieloBase> keyValuePair in this.m_DesHieloDeTiposDeEstimulo)
			{
				keyValuePair.Value.value = default(PorcentageModificable);
				base.SetValueNextUpdate(-10000f);
			}
		}

		// Token: 0x060016C5 RID: 5829 RVA: 0x0005E22C File Offset: 0x0005C42C
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Reset deshielos"
			};
		}

		// Token: 0x040011BB RID: 4539
		private Dictionary<ValueTuple<int, int, int, int>, DesHielo.DesHieloBase> m_DesHieloDeTiposDeEstimulo = new Dictionary<ValueTuple<int, int, int, int>, DesHielo.DesHieloBase>();

		// Token: 0x040011BC RID: 4540
		[SerializeField]
		private List<DesHielo.DesHieloCoital> m_Coitales = new List<DesHielo.DesHieloCoital>();

		// Token: 0x040011BD RID: 4541
		[SerializeField]
		private List<DesHielo.DesHieloTactil> m_Tactiles = new List<DesHielo.DesHieloTactil>();

		// Token: 0x040011BE RID: 4542
		[SerializeField]
		private List<DesHielo.DesHieloVisual> m_Visuales = new List<DesHielo.DesHieloVisual>();

		// Token: 0x040011BF RID: 4543
		[SerializeField]
		private List<DesHielo.DesHieloCambioDePose> m_PeticionCambioDePose = new List<DesHielo.DesHieloCambioDePose>();

		// Token: 0x040011C0 RID: 4544
		[SerializeField]
		private List<DesHielo.DesHieloCambioDePose> m_CambioDePose = new List<DesHielo.DesHieloCambioDePose>();

		// Token: 0x040011C1 RID: 4545
		[SerializeField]
		private List<DesHielo.DesHieloMovimientoDeBone> m_PeticionMovimientoDeBone = new List<DesHielo.DesHieloMovimientoDeBone>();

		// Token: 0x040011C2 RID: 4546
		[SerializeField]
		private List<DesHielo.DesHieloMovimientoDeBone> m_MovimientoDeBone = new List<DesHielo.DesHieloMovimientoDeBone>();

		// Token: 0x040011C3 RID: 4547
		[SerializeField]
		private List<DesHielo.DesHieloDesvestidura> m_PeticionDesvestidura = new List<DesHielo.DesHieloDesvestidura>();

		// Token: 0x040011C4 RID: 4548
		[SerializeField]
		private List<DesHielo.DesHieloDesvestidura> m_Desvestidura = new List<DesHielo.DesHieloDesvestidura>();

		// Token: 0x0200040A RID: 1034
		[Serializable]
		public class DesHieloMovimientoDeBone : DesHielo.DesHieloBase
		{
			// Token: 0x060016C7 RID: 5831 RVA: 0x0005E2C9 File Offset: 0x0005C4C9
			public DesHieloMovimientoDeBone(ParteDelCuerpoHumano estimuladaParte, TipoDeEstimulo tipo, DireccionDeEstimulo direccion)
				: base(estimuladaParte, tipo, direccion)
			{
			}

			// Token: 0x060016C8 RID: 5832 RVA: 0x0005E2D4 File Offset: 0x0005C4D4
			public static ValueTuple<int, int, int, int> Key(ParteDelCuerpoHumano estimuladaParte, TipoDeEstimulo tipo, DireccionDeEstimulo direccion)
			{
				return new ValueTuple<int, int, int, int>((int)estimuladaParte, (int)tipo, (int)direccion, 0);
			}

			// Token: 0x060016C9 RID: 5833 RVA: 0x0005E2DF File Offset: 0x0005C4DF
			public override ValueTuple<int, int, int, int> GetKey()
			{
				return new ValueTuple<int, int, int, int>((int)base.estimulada, (int)base.tipoDeEstimulo, (int)base.direccionDeEstimulo, 0);
			}
		}

		// Token: 0x0200040B RID: 1035
		[Serializable]
		public class DesHieloCambioDePose : DesHielo.DesHieloBase
		{
			// Token: 0x060016CA RID: 5834 RVA: 0x0005E2F9 File Offset: 0x0005C4F9
			public DesHieloCambioDePose(ParteDelCuerpoHumano estimuladaParte, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, TipoDeEstimuloCambiarPose SubTipo)
				: base(estimuladaParte, tipo, direccion)
			{
				this.m_subTipo = SubTipo;
			}

			// Token: 0x170005B5 RID: 1461
			// (get) Token: 0x060016CB RID: 5835 RVA: 0x0005E30C File Offset: 0x0005C50C
			public TipoDeEstimuloCambiarPose subTipo
			{
				get
				{
					return this.m_subTipo;
				}
			}

			// Token: 0x060016CC RID: 5836 RVA: 0x0005E314 File Offset: 0x0005C514
			public static ValueTuple<int, int, int, int> Key(ParteDelCuerpoHumano estimuladaParte, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, TipoDeEstimuloCambiarPose tipoCoital)
			{
				return new ValueTuple<int, int, int, int>((int)estimuladaParte, (int)tipo, (int)direccion, (int)tipoCoital);
			}

			// Token: 0x060016CD RID: 5837 RVA: 0x0005E31F File Offset: 0x0005C51F
			public override ValueTuple<int, int, int, int> GetKey()
			{
				return new ValueTuple<int, int, int, int>((int)base.estimulada, (int)base.tipoDeEstimulo, (int)base.direccionDeEstimulo, (int)this.m_subTipo);
			}

			// Token: 0x040011C5 RID: 4549
			[SerializeField]
			[ReadOnlyUI]
			private TipoDeEstimuloCambiarPose m_subTipo;
		}

		// Token: 0x0200040C RID: 1036
		[Serializable]
		public class DesHieloDesvestidura : DesHielo.DesHieloBase
		{
			// Token: 0x060016CE RID: 5838 RVA: 0x0005E33E File Offset: 0x0005C53E
			public DesHieloDesvestidura(ParteDelCuerpoHumano estimuladaParte, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, int SubTipo)
				: base(estimuladaParte, tipo, direccion)
			{
				this.m_subTipo = SubTipo;
			}

			// Token: 0x170005B6 RID: 1462
			// (get) Token: 0x060016CF RID: 5839 RVA: 0x0005E351 File Offset: 0x0005C551
			public int subTipo
			{
				get
				{
					return this.m_subTipo;
				}
			}

			// Token: 0x060016D0 RID: 5840 RVA: 0x0005E314 File Offset: 0x0005C514
			public static ValueTuple<int, int, int, int> Key(ParteDelCuerpoHumano estimuladaParte, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, int subTipo)
			{
				return new ValueTuple<int, int, int, int>((int)estimuladaParte, (int)tipo, (int)direccion, subTipo);
			}

			// Token: 0x060016D1 RID: 5841 RVA: 0x0005E359 File Offset: 0x0005C559
			public override ValueTuple<int, int, int, int> GetKey()
			{
				return new ValueTuple<int, int, int, int>((int)base.estimulada, (int)base.tipoDeEstimulo, (int)base.direccionDeEstimulo, this.m_subTipo);
			}

			// Token: 0x040011C6 RID: 4550
			[SerializeField]
			[ReadOnlyUI]
			private int m_subTipo;
		}

		// Token: 0x0200040D RID: 1037
		[Serializable]
		public class DesHieloCoital : DesHielo.DesHieloBase
		{
			// Token: 0x060016D2 RID: 5842 RVA: 0x0005E378 File Offset: 0x0005C578
			public DesHieloCoital(ParteDelCuerpoHumano estimuladaParte, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, TipoDeEstimuloCoital tipoCoital)
				: base(estimuladaParte, tipo, direccion)
			{
				this.m_tipoCoital = tipoCoital;
			}

			// Token: 0x170005B7 RID: 1463
			// (get) Token: 0x060016D3 RID: 5843 RVA: 0x0005E38B File Offset: 0x0005C58B
			public TipoDeEstimuloCoital tipoDeEstimuloCoital
			{
				get
				{
					return this.m_tipoCoital;
				}
			}

			// Token: 0x060016D4 RID: 5844 RVA: 0x0005E314 File Offset: 0x0005C514
			public static ValueTuple<int, int, int, int> Key(ParteDelCuerpoHumano estimuladaParte, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, TipoDeEstimuloCoital tipoCoital)
			{
				return new ValueTuple<int, int, int, int>((int)estimuladaParte, (int)tipo, (int)direccion, (int)tipoCoital);
			}

			// Token: 0x060016D5 RID: 5845 RVA: 0x0005E393 File Offset: 0x0005C593
			public override ValueTuple<int, int, int, int> GetKey()
			{
				return new ValueTuple<int, int, int, int>((int)base.estimulada, (int)base.tipoDeEstimulo, (int)base.direccionDeEstimulo, (int)this.m_tipoCoital);
			}

			// Token: 0x040011C7 RID: 4551
			[SerializeField]
			[ReadOnlyUI]
			private TipoDeEstimuloCoital m_tipoCoital;
		}

		// Token: 0x0200040E RID: 1038
		[Serializable]
		public class DesHieloTactil : DesHielo.DesHieloBase
		{
			// Token: 0x060016D6 RID: 5846 RVA: 0x0005E3B2 File Offset: 0x0005C5B2
			public DesHieloTactil(ParteDelCuerpoHumano estimuladaParte, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, TipoDeEstimuloTactil tipoTactil)
				: base(estimuladaParte, tipo, direccion)
			{
				this.m_tipoTactil = tipoTactil;
			}

			// Token: 0x170005B8 RID: 1464
			// (get) Token: 0x060016D7 RID: 5847 RVA: 0x0005E3C5 File Offset: 0x0005C5C5
			public TipoDeEstimuloTactil tipoDeEstimuloTactil
			{
				get
				{
					return this.m_tipoTactil;
				}
			}

			// Token: 0x060016D8 RID: 5848 RVA: 0x0005E314 File Offset: 0x0005C514
			public static ValueTuple<int, int, int, int> Key(ParteDelCuerpoHumano estimuladaParte, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, TipoDeEstimuloTactil tipoTactil)
			{
				return new ValueTuple<int, int, int, int>((int)estimuladaParte, (int)tipo, (int)direccion, (int)tipoTactil);
			}

			// Token: 0x060016D9 RID: 5849 RVA: 0x0005E3CD File Offset: 0x0005C5CD
			public override ValueTuple<int, int, int, int> GetKey()
			{
				return new ValueTuple<int, int, int, int>((int)base.estimulada, (int)base.tipoDeEstimulo, (int)base.direccionDeEstimulo, (int)this.m_tipoTactil);
			}

			// Token: 0x040011C8 RID: 4552
			[SerializeField]
			[ReadOnlyUI]
			private TipoDeEstimuloTactil m_tipoTactil;
		}

		// Token: 0x0200040F RID: 1039
		[Serializable]
		public class DesHieloVisual : DesHielo.DesHieloBase
		{
			// Token: 0x060016DA RID: 5850 RVA: 0x0005E3EC File Offset: 0x0005C5EC
			public DesHieloVisual(ParteDelCuerpoHumano estimuladaParte, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, TipoDeEstimuloVisual tipoVisual)
				: base(estimuladaParte, tipo, direccion)
			{
				this.m_tipoVisual = tipoVisual;
			}

			// Token: 0x170005B9 RID: 1465
			// (get) Token: 0x060016DB RID: 5851 RVA: 0x0005E3FF File Offset: 0x0005C5FF
			public TipoDeEstimuloVisual tipoDeEstimuloVisual
			{
				get
				{
					return this.m_tipoVisual;
				}
			}

			// Token: 0x060016DC RID: 5852 RVA: 0x0005E314 File Offset: 0x0005C514
			public static ValueTuple<int, int, int, int> Key(ParteDelCuerpoHumano estimuladaParte, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, TipoDeEstimuloVisual tipoVisual)
			{
				return new ValueTuple<int, int, int, int>((int)estimuladaParte, (int)tipo, (int)direccion, (int)tipoVisual);
			}

			// Token: 0x060016DD RID: 5853 RVA: 0x0005E407 File Offset: 0x0005C607
			public override ValueTuple<int, int, int, int> GetKey()
			{
				return new ValueTuple<int, int, int, int>((int)base.estimulada, (int)base.tipoDeEstimulo, (int)base.direccionDeEstimulo, (int)this.m_tipoVisual);
			}

			// Token: 0x040011C9 RID: 4553
			[SerializeField]
			[ReadOnlyUI]
			private TipoDeEstimuloVisual m_tipoVisual;
		}

		// Token: 0x02000410 RID: 1040
		public abstract class DesHieloBase
		{
			// Token: 0x060016DE RID: 5854 RVA: 0x0005E426 File Offset: 0x0005C626
			protected DesHieloBase(ParteDelCuerpoHumano estimuladaParte, TipoDeEstimulo tipo, DireccionDeEstimulo direccion)
			{
				if (tipo == TipoDeEstimulo.None)
				{
					throw new NotSupportedException();
				}
				this.m_tipoDeEstimulo = tipo;
				this.m_direccionDeEstimulo = direccion;
				this.m_estimulada = estimuladaParte;
			}

			// Token: 0x170005BA RID: 1466
			// (get) Token: 0x060016DF RID: 5855 RVA: 0x0005E44C File Offset: 0x0005C64C
			public ParteDelCuerpoHumano estimulada
			{
				get
				{
					return this.m_estimulada;
				}
			}

			// Token: 0x170005BB RID: 1467
			// (get) Token: 0x060016E0 RID: 5856 RVA: 0x0005E454 File Offset: 0x0005C654
			public TipoDeEstimulo tipoDeEstimulo
			{
				get
				{
					return this.m_tipoDeEstimulo;
				}
			}

			// Token: 0x170005BC RID: 1468
			// (get) Token: 0x060016E1 RID: 5857 RVA: 0x0005E45C File Offset: 0x0005C65C
			public DireccionDeEstimulo direccionDeEstimulo
			{
				get
				{
					return this.m_direccionDeEstimulo;
				}
			}

			// Token: 0x060016E2 RID: 5858
			public abstract ValueTuple<int, int, int, int> GetKey();

			// Token: 0x040011CA RID: 4554
			public bool debugPrintVelocity;

			// Token: 0x040011CB RID: 4555
			public PorcentageModificable value;

			// Token: 0x040011CC RID: 4556
			[SerializeField]
			[ReadOnlyUI]
			private ParteDelCuerpoHumano m_estimulada;

			// Token: 0x040011CD RID: 4557
			[SerializeField]
			[ReadOnlyUI]
			private TipoDeEstimulo m_tipoDeEstimulo;

			// Token: 0x040011CE RID: 4558
			[SerializeField]
			[ReadOnlyUI]
			private DireccionDeEstimulo m_direccionDeEstimulo;
		}

		// Token: 0x02000411 RID: 1041
		public enum Forzar
		{
			// Token: 0x040011D0 RID: 4560
			None,
			// Token: 0x040011D1 RID: 4561
			conHielo,
			// Token: 0x040011D2 RID: 4562
			sinHielo
		}
	}
}
