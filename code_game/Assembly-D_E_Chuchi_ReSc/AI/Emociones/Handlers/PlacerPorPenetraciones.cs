using System;
using System.Collections.Generic;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers.FrameCalculos.Modificadores;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers
{
	// Token: 0x02000492 RID: 1170
	public sealed class PlacerPorPenetraciones : CalculoDeEstimuloPorPenetracionRecibidaComplete
	{
		// Token: 0x17000727 RID: 1831
		// (get) Token: 0x06001B6D RID: 7021 RVA: 0x00005F51 File Offset: 0x00004151
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor;
			}
		}

		// Token: 0x06001B6E RID: 7022 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x17000728 RID: 1832
		// (get) Token: 0x06001B6F RID: 7023 RVA: 0x0006DF2F File Offset: 0x0006C12F
		protected sealed override DatosDeUmbral datosDeUmbralApertura
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.placer_Penetracion.porPenetracionApertura;
			}
		}

		// Token: 0x17000729 RID: 1833
		// (get) Token: 0x06001B70 RID: 7024 RVA: 0x0006DF4B File Offset: 0x0006C14B
		protected sealed override DatosDeUmbral datosDeUmbralMovimiento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.placer_Penetracion.porPenetracionMovimiento;
			}
		}

		// Token: 0x1700072A RID: 1834
		// (get) Token: 0x06001B71 RID: 7025 RVA: 0x0006DF67 File Offset: 0x0006C167
		protected sealed override DatosDeUmbral datosDeUmbralPenetracion
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.placer_Penetracion.porPenetracion;
			}
		}

		// Token: 0x1700072B RID: 1835
		// (get) Token: 0x06001B72 RID: 7026 RVA: 0x0006DF83 File Offset: 0x0006C183
		protected override DatosDeUmbralSinIntervalo datosDeUmbralProfundidad_Vaginal
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.placer_Penetracion.porProfundidadVaginalV2;
			}
		}

		// Token: 0x1700072C RID: 1836
		// (get) Token: 0x06001B73 RID: 7027 RVA: 0x0006DF9F File Offset: 0x0006C19F
		protected override RangeValueV2 intervaloProfundidad_Vaginal
		{
			get
			{
				return this.m_IPhyscisIntervalosDeProfundidad.vag;
			}
		}

		// Token: 0x1700072D RID: 1837
		// (get) Token: 0x06001B74 RID: 7028 RVA: 0x0006DFAC File Offset: 0x0006C1AC
		protected override DatosDeUmbralSinIntervalo datosDeUmbralProfundidad_Anal
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.placer_Penetracion.porProfundidadAnalV2;
			}
		}

		// Token: 0x1700072E RID: 1838
		// (get) Token: 0x06001B75 RID: 7029 RVA: 0x0006DFC8 File Offset: 0x0006C1C8
		protected override RangeValueV2 intervaloProfundidad_Anal
		{
			get
			{
				return this.m_IPhyscisIntervalosDeProfundidad.anus;
			}
		}

		// Token: 0x1700072F RID: 1839
		// (get) Token: 0x06001B76 RID: 7030 RVA: 0x0006DFD5 File Offset: 0x0006C1D5
		protected override DatosDeUmbralSinIntervalo datosDeUmbralProfundidad_Facial
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.placer_Penetracion.porPenetracionFacialProfundidadV2;
			}
		}

		// Token: 0x17000730 RID: 1840
		// (get) Token: 0x06001B77 RID: 7031 RVA: 0x0006DFF1 File Offset: 0x0006C1F1
		protected override RangeValueV2 intervaloProfundidad_Facial
		{
			get
			{
				return this.m_IPhyscisIntervalosDeProfundidad.facial;
			}
		}

		// Token: 0x17000731 RID: 1841
		// (get) Token: 0x06001B78 RID: 7032 RVA: 0x0006DFFE File Offset: 0x0006C1FE
		protected override RangeValueV2 intervaloProfundidad_VaginalSinHardPoints
		{
			get
			{
				return this.m_IPhyscisIntervalosDeProfundidad.vagUnLimited;
			}
		}

		// Token: 0x17000732 RID: 1842
		// (get) Token: 0x06001B79 RID: 7033 RVA: 0x0006E00B File Offset: 0x0006C20B
		protected override RangeValueV2 intervaloProfundidad_AnalSinHardPoints
		{
			get
			{
				return this.m_IPhyscisIntervalosDeProfundidad.anusUnLimited;
			}
		}

		// Token: 0x17000733 RID: 1843
		// (get) Token: 0x06001B7A RID: 7034 RVA: 0x0006E018 File Offset: 0x0006C218
		protected override RangeValueV2 intervaloProfundidad_FacialSinHardPoints
		{
			get
			{
				return this.m_IPhyscisIntervalosDeProfundidad.facialUnLimited;
			}
		}

		// Token: 0x17000734 RID: 1844
		// (get) Token: 0x06001B7B RID: 7035 RVA: 0x0006E025 File Offset: 0x0006C225
		protected override DatosDeUmbral datosDeUmbralAnchura_Vaginal
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.placer_Penetracion.porAnchuraVaginal;
			}
		}

		// Token: 0x17000735 RID: 1845
		// (get) Token: 0x06001B7C RID: 7036 RVA: 0x0006E041 File Offset: 0x0006C241
		protected override DatosDeUmbral datosDeUmbralAnchura_Anal
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.placer_Penetracion.porAnchuraAnal;
			}
		}

		// Token: 0x17000736 RID: 1846
		// (get) Token: 0x06001B7D RID: 7037 RVA: 0x0006E05D File Offset: 0x0006C25D
		protected override DatosDeUmbral datosDeUmbralAnchura_Facial
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.placer_Penetracion.porPenetracionFacialAnchura;
			}
		}

		// Token: 0x17000737 RID: 1847
		// (get) Token: 0x06001B7E RID: 7038 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float bufferParaGenerarEstimuloPorAnchura
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x17000738 RID: 1848
		// (get) Token: 0x06001B7F RID: 7039 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float bufferParaGenerarEstimuloPorProfundidad
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x17000739 RID: 1849
		// (get) Token: 0x06001B80 RID: 7040 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float bufferParaGenerarEstimuloPorPenetracion
		{
			get
			{
				return 0f;
			}
		}

		// Token: 0x1700073A RID: 1850
		// (get) Token: 0x06001B81 RID: 7041 RVA: 0x0005FBC6 File Offset: 0x0005DDC6
		protected sealed override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.erogeno;
			}
		}

		// Token: 0x1700073B RID: 1851
		// (get) Token: 0x06001B82 RID: 7042 RVA: 0x0006E079 File Offset: 0x0006C279
		protected sealed override PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesEstimulantes.erogeno;
			}
		}

		// Token: 0x1700073C RID: 1852
		// (get) Token: 0x06001B83 RID: 7043 RVA: 0x0005F8FF File Offset: 0x0005DAFF
		protected sealed override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.maxEmocionValuePorGrupo.placer;
			}
		}

		// Token: 0x1700073D RID: 1853
		// (get) Token: 0x06001B84 RID: 7044 RVA: 0x0006E090 File Offset: 0x0006C290
		protected sealed override FloatPorGrupoDicc parteEstimulante_EmocionGeneradaModPorGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.erogenoEstimulantes;
			}
		}

		// Token: 0x1700073E RID: 1854
		// (get) Token: 0x06001B85 RID: 7045 RVA: 0x0005FBDD File Offset: 0x0005DDDD
		protected sealed override FloatPorGrupoDicc parteEstimulada_EmocionGeneradaModPorGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.erogenoEstimulados;
			}
		}

		// Token: 0x1700073F RID: 1855
		// (get) Token: 0x06001B86 RID: 7046 RVA: 0x0006E0A7 File Offset: 0x0006C2A7
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento_Velocidad
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.erogeno.porPenetracionVelAperMov.incremento;
			}
		}

		// Token: 0x17000740 RID: 1856
		// (get) Token: 0x06001B87 RID: 7047 RVA: 0x0006E0C8 File Offset: 0x0006C2C8
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion_Velocidad
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.erogeno.porPenetracionVelAperMov.expancion;
			}
		}

		// Token: 0x17000741 RID: 1857
		// (get) Token: 0x06001B88 RID: 7048 RVA: 0x0006E0A7 File Offset: 0x0006C2A7
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento_Apertura
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.erogeno.porPenetracionVelAperMov.incremento;
			}
		}

		// Token: 0x17000742 RID: 1858
		// (get) Token: 0x06001B89 RID: 7049 RVA: 0x0006E0C8 File Offset: 0x0006C2C8
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion_Apertura
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.erogeno.porPenetracionVelAperMov.expancion;
			}
		}

		// Token: 0x17000743 RID: 1859
		// (get) Token: 0x06001B8A RID: 7050 RVA: 0x0006E0A7 File Offset: 0x0006C2A7
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento_Movimiento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.erogeno.porPenetracionVelAperMov.incremento;
			}
		}

		// Token: 0x17000744 RID: 1860
		// (get) Token: 0x06001B8B RID: 7051 RVA: 0x0006E0C8 File Offset: 0x0006C2C8
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion_Movimiento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.erogeno.porPenetracionVelAperMov.expancion;
			}
		}

		// Token: 0x17000745 RID: 1861
		// (get) Token: 0x06001B8C RID: 7052 RVA: 0x0006E0E9 File Offset: 0x0006C2E9
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento_Anchura
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.erogeno.porPenetracionAnchura.incremento;
			}
		}

		// Token: 0x17000746 RID: 1862
		// (get) Token: 0x06001B8D RID: 7053 RVA: 0x0006E10A File Offset: 0x0006C30A
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion_Anchura
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.erogeno.porPenetracionAnchura.expancion;
			}
		}

		// Token: 0x06001B8E RID: 7054 RVA: 0x0005F92D File Offset: 0x0005DB2D
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Placer;
		}

		// Token: 0x06001B8F RID: 7055 RVA: 0x0006E12C File Offset: 0x0006C32C
		protected sealed override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_IHolesRangosClamp_PorDesgaste = this.GetComponentEnRoot(false);
			if (this.m_IHolesRangosClamp_PorDesgaste == null)
			{
				throw new ArgumentNullException("m_IHolesRangosClamp", "m_IHolesRangosClamp null reference.");
			}
			this.m_IPhyscisIntervalosDeProfundidad = this.GetComponentEnRoot(false);
			if (this.m_IPhyscisIntervalosDeProfundidad == null)
			{
				throw new ArgumentNullException("m_IPhyscisIntervalosDeProfundidad", "m_IPhyscisIntervalosDeProfundidad null reference.");
			}
			this.m_arousalV2 = this.m_emocionesDeOwner.GetComponentInChildren<Arousal>();
			if (this.m_arousalV2 == null)
			{
				throw new ArgumentNullException("m_arousal", "m_arousal null reference.");
			}
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x06001B90 RID: 7056 RVA: 0x0006E1C9 File Offset: 0x0006C3C9
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_emocionesDeOwner.GetComponentsInChildren<IModDeInterDeGenCoitalPenVel>(this.m_modificadoresDeIntervaloPenVel);
			this.m_emocionesDeOwner.GetComponentsInChildren<IModDeInterDeGenCoitalAnchura>(this.m_modificadoresDeIntervaloAnchura);
		}

		// Token: 0x06001B91 RID: 7057 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPostUmbralCalculoApertura(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001B92 RID: 7058 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPostUmbralCalculoMovimiento(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001B93 RID: 7059 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPostUmbralCalculoPenetracion(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001B94 RID: 7060 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPostUmbralCalculoProfundidad(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001B95 RID: 7061 RVA: 0x00003B39 File Offset: 0x00001D39
		protected sealed override void OnPostUmbralCalculoAnchura(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001B96 RID: 7062 RVA: 0x0006E1F4 File Offset: 0x0006C3F4
		protected sealed override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, GrupoQueCompartenValores estimulante, EstimuloPenetrante estimulo, ref float maxEmotionValue)
		{
			FloatPorGrupoDicc placerModificacionAlArousalMaximo = this.m_emocionesDeOwner.mapas.maxEmocionValuePorGrupo.placerModificacionAlArousalMaximo;
			if (placerModificacionAlArousalMaximo == null)
			{
				return;
			}
			float valor = placerModificacionAlArousalMaximo[grupoEstimulado].valor;
			maxEmotionValue = Mathf.Lerp(maxEmotionValue, maxEmotionValue * valor, this.m_arousalV2.value.mod);
		}

		// Token: 0x06001B97 RID: 7063 RVA: 0x0006E254 File Offset: 0x0006C454
		protected sealed override void OnPreUmbralCalculoApertura(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambioSuavizado, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			if (!this.aplicarModsDeIntervalosVsEmocion)
			{
				return;
			}
			Emocion emo = this.m_Emo;
			MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porPenetracionApertura = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.placer.porPenetracionApertura;
			intervalo = porPenetracionApertura.vsArousal.Modificar(intervalo, this.m_arousalV2, 1f);
			intervalo = porPenetracionApertura.vsPlacer.Modificar(intervalo, emo, 1f);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix modificador = this.m_modificablesDeInteraccio.GetModificador(penetracion.estimulo, penetracion.tipo.ParseAParteDelCuerpoHumano(), penetracion.estimulanteParte, false, null);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced advanced = modificador.advanced;
			if (advanced != null)
			{
				estimulacionGenerada.moded *= advanced.gainModificable.ModificarValor(1f);
				intervalo.Expandir(advanced.interExpandModificable.ModificarValor(1f), 0.0001f);
				intervalo.Increase(advanced.interPositionMinMaxModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMinAndKeepLenght(advanced.interPositionMinModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMaxAndKeepLenght(advanced.interPositionMaxModificable.ModificarValor(1f), 0.0001f);
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional tradicional = modificador.tradicional;
			if (tradicional != null)
			{
				estimulacionGenerada.moded *= tradicional.gainModificable.ModificarValor(1f);
				intervalo.Expandir(tradicional.interExpandModificable.ModificarValor(1f), 0.0001f);
				intervalo.Increase(tradicional.interPositionMinMaxModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMinAndKeepLenght(tradicional.interPositionMinModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMaxAndKeepLenght(tradicional.interPositionMaxModificable.ModificarValor(1f), 0.0001f);
			}
			for (int i = 0; i < this.m_modificadoresDeIntervaloPenVel.Count; i++)
			{
				this.m_modificadoresDeIntervaloPenVel[i].Max(this.m_Emo.reaccion, penetracion.tipo, ref intervalo);
			}
		}

		// Token: 0x06001B98 RID: 7064 RVA: 0x0006E46C File Offset: 0x0006C66C
		protected sealed override void OnPreUmbralCalculoMovimiento(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambioSuavizado, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			if (!this.aplicarModsDeIntervalosVsEmocion)
			{
				return;
			}
			Emocion emo = this.m_Emo;
			MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porPenetracionMovimiento = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.placer.porPenetracionMovimiento;
			intervalo = porPenetracionMovimiento.vsArousal.Modificar(intervalo, this.m_arousalV2, 1f);
			intervalo = porPenetracionMovimiento.vsPlacer.Modificar(intervalo, emo, 1f);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix modificador = this.m_modificablesDeInteraccio.GetModificador(penetracion.estimulo, penetracion.tipo.ParseAParteDelCuerpoHumano(), penetracion.estimulanteParte, false, null);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced advanced = modificador.advanced;
			if (advanced != null)
			{
				estimulacionGenerada.moded *= advanced.gainModificable.ModificarValor(1f);
				intervalo.Expandir(advanced.interExpandModificable.ModificarValor(1f), 0.0001f);
				intervalo.Increase(advanced.interPositionMinMaxModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMinAndKeepLenght(advanced.interPositionMinModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMaxAndKeepLenght(advanced.interPositionMaxModificable.ModificarValor(1f), 0.0001f);
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional tradicional = modificador.tradicional;
			if (tradicional != null)
			{
				estimulacionGenerada.moded *= tradicional.gainModificable.ModificarValor(1f);
				intervalo.Expandir(tradicional.interExpandModificable.ModificarValor(1f), 0.0001f);
				intervalo.Increase(tradicional.interPositionMinMaxModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMinAndKeepLenght(tradicional.interPositionMinModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMaxAndKeepLenght(tradicional.interPositionMaxModificable.ModificarValor(1f), 0.0001f);
			}
			for (int i = 0; i < this.m_modificadoresDeIntervaloPenVel.Count; i++)
			{
				this.m_modificadoresDeIntervaloPenVel[i].Max(this.m_Emo.reaccion, penetracion.tipo, ref intervalo);
			}
		}

		// Token: 0x06001B99 RID: 7065 RVA: 0x0006E684 File Offset: 0x0006C884
		protected sealed override void OnPreUmbralCalculoPenetracion(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambioSuavizado, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			if (!this.aplicarModsDeIntervalosVsEmocion)
			{
				return;
			}
			if (!emocionesValoresMods.loaded)
			{
				emocionesValoresMods = this.m_emocionesDeOwner.ObtenerModsFemeninos();
			}
			MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porPenetracion = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.placer.porPenetracion;
			intervalo = porPenetracion.vsArousal.Modificar(intervalo, emocionesValoresMods.arousal);
			intervalo = porPenetracion.vsPlacer.Modificar(intervalo, emocionesValoresMods.humanasValues.placer);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesMix modificador = this.m_modificablesDeInteraccio.GetModificador(penetracion.estimulo, penetracion.tipo.ParseAParteDelCuerpoHumano(), penetracion.estimulanteParte, false, null);
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced advanced = modificador.advanced;
			if (advanced != null)
			{
				estimulacionGenerada.moded *= advanced.gainModificable.ModificarValor(1f);
				intervalo.Expandir(advanced.interExpandModificable.ModificarValor(1f), 0.0001f);
				intervalo.Increase(advanced.interPositionMinMaxModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMinAndKeepLenght(advanced.interPositionMinModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMaxAndKeepLenght(advanced.interPositionMaxModificable.ModificarValor(1f), 0.0001f);
			}
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesTradicional tradicional = modificador.tradicional;
			if (tradicional != null)
			{
				estimulacionGenerada.moded *= tradicional.gainModificable.ModificarValor(1f);
				intervalo.Expandir(tradicional.interExpandModificable.ModificarValor(1f), 0.0001f);
				intervalo.Increase(tradicional.interPositionMinMaxModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMinAndKeepLenght(tradicional.interPositionMinModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMaxAndKeepLenght(tradicional.interPositionMaxModificable.ModificarValor(1f), 0.0001f);
			}
			for (int i = 0; i < this.m_modificadoresDeIntervaloPenVel.Count; i++)
			{
				this.m_modificadoresDeIntervaloPenVel[i].Max(this.m_Emo.reaccion, penetracion.tipo, ref intervalo);
			}
			float num;
			float num2;
			switch (penetracion.tipo)
			{
			case FemalePenetracionTipo.anus:
				num = Mathf.Clamp(intervalo.max, this.m_IHolesRangosClamp_PorDesgaste.anus.motion.min, this.m_IHolesRangosClamp_PorDesgaste.anus.motion.max);
				num2 = Mathf.Clamp(intervalo.min, 0f, num);
				break;
			case FemalePenetracionTipo.vag:
				num = Mathf.Clamp(intervalo.max, this.m_IHolesRangosClamp_PorDesgaste.vag.motion.min, this.m_IHolesRangosClamp_PorDesgaste.vag.motion.max);
				num2 = Mathf.Clamp(intervalo.min, 0f, num);
				break;
			case FemalePenetracionTipo.facial:
				num = Mathf.Clamp(intervalo.max, this.m_IHolesRangosClamp_PorDesgaste.garganta.motion.min, this.m_IHolesRangosClamp_PorDesgaste.garganta.motion.max);
				num2 = Mathf.Clamp(intervalo.min, 0f, num);
				break;
			default:
				throw new ArgumentOutOfRangeException(base.tipo.ToString());
			}
			intervalo = RangeValueV2.TryNew(num2, num, 0.01f, 0.001f);
		}

		// Token: 0x06001B9A RID: 7066 RVA: 0x0006E9E3 File Offset: 0x0006CBE3
		protected sealed override void OnPreUmbralCalculoProfundidad_ModificarIntervalo(FemalePenetracionTipo tipo, ref RangeValueV2 intervalo, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			bool flag = this.aplicarModsDeIntervalosVsEmocion;
		}

		// Token: 0x06001B9B RID: 7067 RVA: 0x0006E9EC File Offset: 0x0006CBEC
		protected sealed override void OnPreUmbralCalculoProfundidad(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambioSuavizado, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvanced = this.m_modificablesDeInteraccio.GetModificadorAdvanced(penetracion.estimulo, penetracion.tipo.ParseAParteDelCuerpoHumano(), penetracion.estimulanteParte, false, new SensitiveFemaleHoleType?(SensitiveFemaleHoleType.bottom));
			if (modificadorAdvanced != null)
			{
				estimulacionGenerada.moded *= modificadorAdvanced.gainModificable.ModificarValor(1f);
				intervalo.Expandir(modificadorAdvanced.interExpandModificable.ModificarValor(1f), 0.0001f);
				intervalo.Increase(modificadorAdvanced.interPositionMinMaxModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMinAndKeepLenght(modificadorAdvanced.interPositionMinModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMaxAndKeepLenght(modificadorAdvanced.interPositionMaxModificable.ModificarValor(1f), 0.0001f);
			}
		}

		// Token: 0x06001B9C RID: 7068 RVA: 0x0006EAB4 File Offset: 0x0006CCB4
		protected sealed override void OnPreUmbralCalculoAnchura_ModificarIntervalo(FemalePenetracionTipo tipo, ref RangeValueV2 intervalo, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			if (!this.aplicarModsDeIntervalosVsEmocion)
			{
				return;
			}
			if (!emocionesValoresMods.loaded)
			{
				emocionesValoresMods = this.m_emocionesDeOwner.ObtenerModsFemeninos();
			}
			MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porPenetracionAnchura = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.placer.porPenetracionAnchura;
			intervalo = porPenetracionAnchura.vsArousal.Modificar(intervalo, emocionesValoresMods.arousal);
			intervalo = porPenetracionAnchura.vsPlacer.Modificar(intervalo, emocionesValoresMods.humanasValues.placer);
			for (int i = 0; i < this.m_modificadoresDeIntervaloAnchura.Count; i++)
			{
				this.m_modificadoresDeIntervaloAnchura[i].Max(this.m_Emo.reaccion, tipo, ref intervalo);
			}
			float num;
			float num2;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				num = Mathf.Clamp(intervalo.max, this.m_IHolesRangosClamp_PorDesgaste.anus.anchura.min, this.m_IHolesRangosClamp_PorDesgaste.anus.anchura.max);
				num2 = Mathf.Clamp(intervalo.min, 0f, num);
				break;
			case FemalePenetracionTipo.vag:
				num = Mathf.Clamp(intervalo.max, this.m_IHolesRangosClamp_PorDesgaste.vag.anchura.min, this.m_IHolesRangosClamp_PorDesgaste.vag.anchura.max);
				num2 = Mathf.Clamp(intervalo.min, 0f, num);
				break;
			case FemalePenetracionTipo.facial:
				num = Mathf.Clamp(intervalo.max, this.m_IHolesRangosClamp_PorDesgaste.garganta.anchura.min, this.m_IHolesRangosClamp_PorDesgaste.garganta.anchura.max);
				num2 = Mathf.Clamp(intervalo.min, 0f, num);
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			intervalo = RangeValueV2.TryNew(num2, num, 0.01f, 0.001f);
		}

		// Token: 0x06001B9D RID: 7069 RVA: 0x0006EC94 File Offset: 0x0006CE94
		protected sealed override void OnPreUmbralCalculoAnchura(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion.ModificablesAdvanced modificadorAdvanced = this.m_modificablesDeInteraccio.GetModificadorAdvanced(penetracion.estimulo, penetracion.tipo.ParseAParteDelCuerpoHumano(), penetracion.estimulanteParte, false, new SensitiveFemaleHoleType?(SensitiveFemaleHoleType.walls));
			if (modificadorAdvanced != null)
			{
				estimulacionGenerada.moded *= modificadorAdvanced.gainModificable.ModificarValor(1f);
				intervalo.Expandir(modificadorAdvanced.interExpandModificable.ModificarValor(1f), 0.0001f);
				intervalo.Increase(modificadorAdvanced.interPositionMinMaxModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMinAndKeepLenght(modificadorAdvanced.interPositionMinModificable.ModificarValor(1f), 0.0001f);
				intervalo.IncreaseMaxAndKeepLenght(modificadorAdvanced.interPositionMaxModificable.ModificarValor(1f), 0.0001f);
			}
		}

		// Token: 0x0400139F RID: 5023
		public bool aplicarModsDeIntervalosVsEmocion = true;

		// Token: 0x040013A0 RID: 5024
		private List<IModDeInterDeGenCoitalPenVel> m_modificadoresDeIntervaloPenVel = new List<IModDeInterDeGenCoitalPenVel>();

		// Token: 0x040013A1 RID: 5025
		[Obsolete("reemplazado por internals y hard  points", true)]
		private List<IModDeInterDeGenCoitalProfundidad> m_modificadoresDeIntervaloProfundiad = new List<IModDeInterDeGenCoitalProfundidad>();

		// Token: 0x040013A2 RID: 5026
		private List<IModDeInterDeGenCoitalAnchura> m_modificadoresDeIntervaloAnchura = new List<IModDeInterDeGenCoitalAnchura>();

		// Token: 0x040013A3 RID: 5027
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;

		// Token: 0x040013A4 RID: 5028
		private Arousal m_arousalV2;

		// Token: 0x040013A5 RID: 5029
		private IHolesRangosClamp m_IHolesRangosClamp_PorDesgaste;

		// Token: 0x040013A6 RID: 5030
		private IPhyscisIntervalosDeProfundidadMiddle m_IPhyscisIntervalosDeProfundidad;
	}
}
