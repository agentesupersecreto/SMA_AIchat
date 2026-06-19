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
	// Token: 0x0200048F RID: 1167
	public sealed class DolorPorPenetracion : CalculoDeEstimuloPorPenetracionRecibidaComplete
	{
		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x06001B1F RID: 6943 RVA: 0x00006318 File Offset: 0x00004518
		protected override PrioridadDeParteDelCuerpoHumanoContexto contextoDePrioridadDeParteHumana
		{
			get
			{
				return PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor;
			}
		}

		// Token: 0x06001B20 RID: 6944 RVA: 0x0002591B File Offset: 0x00023B1B
		protected override float GetNextCoolDown()
		{
			return 0f;
		}

		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x06001B21 RID: 6945 RVA: 0x0006CA76 File Offset: 0x0006AC76
		protected override DatosDeUmbralSinIntervalo datosDeUmbralProfundidad_Vaginal
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.dolor_Penetracion.porProfundidadVaginalV2;
			}
		}

		// Token: 0x170006FB RID: 1787
		// (get) Token: 0x06001B22 RID: 6946 RVA: 0x0006CA92 File Offset: 0x0006AC92
		protected override RangeValueV2 intervaloProfundidad_Vaginal
		{
			get
			{
				return this.m_IPhyscisIntervalosDeProfundidad.vag;
			}
		}

		// Token: 0x170006FC RID: 1788
		// (get) Token: 0x06001B23 RID: 6947 RVA: 0x0006CA9F File Offset: 0x0006AC9F
		protected override DatosDeUmbralSinIntervalo datosDeUmbralProfundidad_Anal
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.dolor_Penetracion.porProfundidadAnalV2;
			}
		}

		// Token: 0x170006FD RID: 1789
		// (get) Token: 0x06001B24 RID: 6948 RVA: 0x0006CABB File Offset: 0x0006ACBB
		protected override RangeValueV2 intervaloProfundidad_Anal
		{
			get
			{
				return this.m_IPhyscisIntervalosDeProfundidad.anus;
			}
		}

		// Token: 0x170006FE RID: 1790
		// (get) Token: 0x06001B25 RID: 6949 RVA: 0x0006CAC8 File Offset: 0x0006ACC8
		protected override DatosDeUmbralSinIntervalo datosDeUmbralProfundidad_Facial
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.dolor_Penetracion.porPenetracionFacialProfundidadV2;
			}
		}

		// Token: 0x170006FF RID: 1791
		// (get) Token: 0x06001B26 RID: 6950 RVA: 0x0006CAE4 File Offset: 0x0006ACE4
		protected override RangeValueV2 intervaloProfundidad_Facial
		{
			get
			{
				return this.m_IPhyscisIntervalosDeProfundidad.facial;
			}
		}

		// Token: 0x17000700 RID: 1792
		// (get) Token: 0x06001B27 RID: 6951 RVA: 0x0006CAF1 File Offset: 0x0006ACF1
		protected override RangeValueV2 intervaloProfundidad_VaginalSinHardPoints
		{
			get
			{
				return this.m_IPhyscisIntervalosDeProfundidad.vagUnLimited;
			}
		}

		// Token: 0x17000701 RID: 1793
		// (get) Token: 0x06001B28 RID: 6952 RVA: 0x0006CAFE File Offset: 0x0006ACFE
		protected override RangeValueV2 intervaloProfundidad_AnalSinHardPoints
		{
			get
			{
				return this.m_IPhyscisIntervalosDeProfundidad.anusUnLimited;
			}
		}

		// Token: 0x17000702 RID: 1794
		// (get) Token: 0x06001B29 RID: 6953 RVA: 0x0006CB0B File Offset: 0x0006AD0B
		protected override RangeValueV2 intervaloProfundidad_FacialSinHardPoints
		{
			get
			{
				return this.m_IPhyscisIntervalosDeProfundidad.facialUnLimited;
			}
		}

		// Token: 0x17000703 RID: 1795
		// (get) Token: 0x06001B2A RID: 6954 RVA: 0x0006CB18 File Offset: 0x0006AD18
		protected override DatosDeUmbral datosDeUmbralAnchura_Vaginal
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.dolor_Penetracion.porAnchuraVaginal;
			}
		}

		// Token: 0x17000704 RID: 1796
		// (get) Token: 0x06001B2B RID: 6955 RVA: 0x0006CB34 File Offset: 0x0006AD34
		protected override DatosDeUmbral datosDeUmbralAnchura_Anal
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.dolor_Penetracion.porAnchuraAnal;
			}
		}

		// Token: 0x17000705 RID: 1797
		// (get) Token: 0x06001B2C RID: 6956 RVA: 0x0006CB50 File Offset: 0x0006AD50
		protected override DatosDeUmbral datosDeUmbralAnchura_Facial
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.dolor_Penetracion.porPenetracionFacialAnchura;
			}
		}

		// Token: 0x17000706 RID: 1798
		// (get) Token: 0x06001B2D RID: 6957 RVA: 0x0006CB6C File Offset: 0x0006AD6C
		protected override DatosDeUmbral datosDeUmbralApertura
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.dolor_Penetracion.porPenetracionApertura;
			}
		}

		// Token: 0x17000707 RID: 1799
		// (get) Token: 0x06001B2E RID: 6958 RVA: 0x0006CB88 File Offset: 0x0006AD88
		protected override DatosDeUmbral datosDeUmbralMovimiento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.dolor_Penetracion.porPenetracionMovimiento;
			}
		}

		// Token: 0x17000708 RID: 1800
		// (get) Token: 0x06001B2F RID: 6959 RVA: 0x0006CBA4 File Offset: 0x0006ADA4
		protected override DatosDeUmbral datosDeUmbralPenetracion
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.umbralData.dolor_Penetracion.porPenetracion;
			}
		}

		// Token: 0x17000709 RID: 1801
		// (get) Token: 0x06001B30 RID: 6960 RVA: 0x0006C612 File Offset: 0x0006A812
		protected override PartesEstimulantePorGrupo mapaDeParteEstimulanteGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesEstimulantes.seinsibilidad;
			}
		}

		// Token: 0x1700070A RID: 1802
		// (get) Token: 0x06001B31 RID: 6961 RVA: 0x0006C629 File Offset: 0x0006A829
		protected override PartesHumanasPorGrupo mapaDeParteHumanaEstimuladaGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.gruposDePartesHumanas.seinsibilidad;
			}
		}

		// Token: 0x1700070B RID: 1803
		// (get) Token: 0x06001B32 RID: 6962 RVA: 0x00006060 File Offset: 0x00004260
		protected override FloatPorGrupoDicc maxEmocionValuePorGrupo
		{
			get
			{
				return null;
			}
		}

		// Token: 0x1700070C RID: 1804
		// (get) Token: 0x06001B33 RID: 6963 RVA: 0x0006CBC0 File Offset: 0x0006ADC0
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento_Velocidad
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.sensibilidad.porPenetracionVelAperMov.incremento;
			}
		}

		// Token: 0x1700070D RID: 1805
		// (get) Token: 0x06001B34 RID: 6964 RVA: 0x0006CBE1 File Offset: 0x0006ADE1
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion_Velocidad
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.sensibilidad.porPenetracionVelAperMov.expancion;
			}
		}

		// Token: 0x1700070E RID: 1806
		// (get) Token: 0x06001B35 RID: 6965 RVA: 0x0006CBC0 File Offset: 0x0006ADC0
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento_Apertura
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.sensibilidad.porPenetracionVelAperMov.incremento;
			}
		}

		// Token: 0x1700070F RID: 1807
		// (get) Token: 0x06001B36 RID: 6966 RVA: 0x0006CBE1 File Offset: 0x0006ADE1
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion_Apertura
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.sensibilidad.porPenetracionVelAperMov.expancion;
			}
		}

		// Token: 0x17000710 RID: 1808
		// (get) Token: 0x06001B37 RID: 6967 RVA: 0x0006CBC0 File Offset: 0x0006ADC0
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento_Movimiento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.sensibilidad.porPenetracionVelAperMov.incremento;
			}
		}

		// Token: 0x17000711 RID: 1809
		// (get) Token: 0x06001B38 RID: 6968 RVA: 0x0006CBE1 File Offset: 0x0006ADE1
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion_Movimiento
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.sensibilidad.porPenetracionVelAperMov.expancion;
			}
		}

		// Token: 0x17000712 RID: 1810
		// (get) Token: 0x06001B39 RID: 6969 RVA: 0x0006CC02 File Offset: 0x0006AE02
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Incremento_Anchura
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.sensibilidad.porPenetracionAnchura.incremento;
			}
		}

		// Token: 0x17000713 RID: 1811
		// (get) Token: 0x06001B3A RID: 6970 RVA: 0x0006CC23 File Offset: 0x0006AE23
		protected sealed override FloatPorGrupoDicc modsDeIntervaloPorGrupoEstimulado_Expancion_Anchura
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunGrupo.sensibilidad.porPenetracionAnchura.expancion;
			}
		}

		// Token: 0x17000714 RID: 1812
		// (get) Token: 0x06001B3B RID: 6971 RVA: 0x0006C640 File Offset: 0x0006A840
		protected override FloatPorGrupoDicc parteEstimulada_EmocionGeneradaModPorGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.seinsibilidadEstimulados;
			}
		}

		// Token: 0x17000715 RID: 1813
		// (get) Token: 0x06001B3C RID: 6972 RVA: 0x0006CC44 File Offset: 0x0006AE44
		protected override FloatPorGrupoDicc parteEstimulante_EmocionGeneradaModPorGrupo
		{
			get
			{
				return this.m_emocionesDeOwner.mapas.modificadoresDeGeneradoPorGrupo.seinsibilidadEstimulantes;
			}
		}

		// Token: 0x17000716 RID: 1814
		// (get) Token: 0x06001B3D RID: 6973 RVA: 0x0006CC5B File Offset: 0x0006AE5B
		protected override float bufferParaGenerarEstimuloPorAnchura
		{
			get
			{
				return this.TiempoDeResistenciaDeHoleAtributos();
			}
		}

		// Token: 0x17000717 RID: 1815
		// (get) Token: 0x06001B3E RID: 6974 RVA: 0x0006CC5B File Offset: 0x0006AE5B
		protected override float bufferParaGenerarEstimuloPorProfundidad
		{
			get
			{
				return this.TiempoDeResistenciaDeHoleAtributos();
			}
		}

		// Token: 0x17000718 RID: 1816
		// (get) Token: 0x06001B3F RID: 6975 RVA: 0x0006CC5B File Offset: 0x0006AE5B
		protected override float bufferParaGenerarEstimuloPorPenetracion
		{
			get
			{
				return this.TiempoDeResistenciaDeHoleAtributos();
			}
		}

		// Token: 0x06001B40 RID: 6976 RVA: 0x0006CC64 File Offset: 0x0006AE64
		private float TiempoDeResistenciaDeHoleAtributos()
		{
			float num = this.m_arousalV2.value.mod + 1f;
			float num2 = MathfExtension.InverseLerpConMedio(0f, 0.3333333f, 1f, this.m_personalidad.optimismo);
			num2 = MathfExtension.LerpConMedio(0f, 1f, 4.8f, num2);
			return num2 * num;
		}

		// Token: 0x17000719 RID: 1817
		// (get) Token: 0x06001B41 RID: 6977 RVA: 0x0006CCC4 File Offset: 0x0006AEC4
		[Obsolete("ahora esta en otra clase", true)]
		public DolorPorPenetracion.ConfigDeMinValores configDeMinValores
		{
			get
			{
				return this.m_ConfigDeMinValores;
			}
		}

		// Token: 0x06001B42 RID: 6978 RVA: 0x0006C6DB File Offset: 0x0006A8DB
		protected override bool EmocionPadreEsValida(Emocion emo)
		{
			return emo is Dolor;
		}

		// Token: 0x06001B43 RID: 6979 RVA: 0x0006CCCC File Offset: 0x0006AECC
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
			this.m_placerV2 = this.m_emocionesDeOwner.GetComponentInChildren<Placer>();
			if (this.m_placerV2 == null)
			{
				throw new ArgumentNullException("Placer", "Placer null reference.");
			}
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
			this.m_modificablesDeInteraccio = base.emo.GetComponentNotNull<ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion>();
		}

		// Token: 0x06001B44 RID: 6980 RVA: 0x0006CDC3 File Offset: 0x0006AFC3
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_emocionesDeOwner.GetComponentsInChildren<IModDeInterDeGenCoitalPenVel>(this.m_modificadoresDeIntervaloPenVel);
			this.m_emocionesDeOwner.GetComponentsInChildren<IModDeInterDeGenCoitalAnchura>(this.m_modificadoresDeIntervaloAnchura);
		}

		// Token: 0x06001B45 RID: 6981 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPostUmbralCalculoAnchura(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001B46 RID: 6982 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPostUmbralCalculoApertura(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001B47 RID: 6983 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPostUmbralCalculoMovimiento(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001B48 RID: 6984 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPostUmbralCalculoPenetracion(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001B49 RID: 6985 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPostUmbralCalculoProfundidad(PenetracionesByMainInFrame.Penetracion penetracion, ref float estimulacionGenerada)
		{
		}

		// Token: 0x06001B4A RID: 6986 RVA: 0x00003B39 File Offset: 0x00001D39
		protected override void OnPreLimitarMaxEmocionValue(GrupoQueCompartenValores grupoEstimulado, GrupoQueCompartenValores estimulante, EstimuloPenetrante estimulo, ref float maxEmotionValue)
		{
		}

		// Token: 0x06001B4B RID: 6987 RVA: 0x0006CDF0 File Offset: 0x0006AFF0
		protected override void OnPreUmbralCalculoApertura(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambioSuavizado, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			if (!this.aplicarModsDeIntervalosVsEmocion)
			{
				return;
			}
			MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porPenetracionApertura = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.dolor.porPenetracionApertura;
			intervalo = porPenetracionApertura.vsArousal.Modificar(intervalo, this.m_arousalV2, 1f);
			intervalo = porPenetracionApertura.vsPlacer.Modificar(intervalo, this.m_placerV2, 1f);
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
				this.m_modificadoresDeIntervaloPenVel[i].StackIfGreater(this.m_Emo.reaccion, penetracion.tipo, ref intervalo);
			}
		}

		// Token: 0x06001B4C RID: 6988 RVA: 0x0006CFFC File Offset: 0x0006B1FC
		protected override void OnPreUmbralCalculoMovimiento(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambioSuavizado, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
		{
			if (!this.aplicarModsDeIntervalosVsEmocion)
			{
				return;
			}
			MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porPenetracionMovimiento = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.dolor.porPenetracionMovimiento;
			intervalo = porPenetracionMovimiento.vsArousal.Modificar(intervalo, this.m_arousalV2, 1f);
			intervalo = porPenetracionMovimiento.vsPlacer.Modificar(intervalo, this.m_placerV2, 1f);
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
				this.m_modificadoresDeIntervaloPenVel[i].StackIfGreater(this.m_Emo.reaccion, penetracion.tipo, ref intervalo);
			}
		}

		// Token: 0x06001B4D RID: 6989 RVA: 0x0006D208 File Offset: 0x0006B408
		protected override void OnPreUmbralCalculoPenetracion(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambioSuavizado, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			if (!this.aplicarModsDeIntervalosVsEmocion)
			{
				return;
			}
			if (!emocionesValoresMods.loaded)
			{
				emocionesValoresMods = this.m_emocionesDeOwner.ObtenerModsFemeninos();
			}
			MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porPenetracion = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.dolor.porPenetracion;
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
				this.m_modificadoresDeIntervaloPenVel[i].StackIfGreater(this.m_Emo.reaccion, penetracion.tipo, ref intervalo);
			}
			float num;
			float num2;
			switch (penetracion.tipo)
			{
			case FemalePenetracionTipo.anus:
				num = Mathf.Clamp(intervalo.max, this.m_IHolesRangosClamp_PorDesgaste.anus.motion.min * 0.1f, this.m_IHolesRangosClamp_PorDesgaste.anus.motion.max * 0.1f);
				num2 = Mathf.Clamp(intervalo.min, this.m_IHolesRangosClamp_PorDesgaste.anus.motion.min, this.m_IHolesRangosClamp_PorDesgaste.anus.motion.max);
				break;
			case FemalePenetracionTipo.vag:
				num = Mathf.Clamp(intervalo.max, this.m_IHolesRangosClamp_PorDesgaste.vag.motion.min * 0.1f, this.m_IHolesRangosClamp_PorDesgaste.vag.motion.max * 0.1f);
				num2 = Mathf.Clamp(intervalo.min, this.m_IHolesRangosClamp_PorDesgaste.vag.motion.min, this.m_IHolesRangosClamp_PorDesgaste.vag.motion.max);
				break;
			case FemalePenetracionTipo.facial:
				num = Mathf.Clamp(intervalo.max, this.m_IHolesRangosClamp_PorDesgaste.garganta.motion.min * 0.1f, this.m_IHolesRangosClamp_PorDesgaste.garganta.motion.max * 0.1f);
				num2 = Mathf.Clamp(intervalo.min, this.m_IHolesRangosClamp_PorDesgaste.garganta.motion.min, this.m_IHolesRangosClamp_PorDesgaste.garganta.motion.max);
				break;
			default:
				throw new ArgumentOutOfRangeException(base.tipo.ToString());
			}
			intervalo = RangeValueV2.TryNew(num2, num, 0.1f, 0.001f);
		}

		// Token: 0x06001B4E RID: 6990 RVA: 0x0006D5FA File Offset: 0x0006B7FA
		protected override void OnPreUmbralCalculoProfundidad_ModificarIntervalo(FemalePenetracionTipo tipo, ref RangeValueV2 intervalo, ref EmocionesFemeninasValues emocionesValoresMods)
		{
			bool flag = this.aplicarModsDeIntervalosVsEmocion;
		}

		// Token: 0x06001B4F RID: 6991 RVA: 0x0006D604 File Offset: 0x0006B804
		protected override void OnPreUmbralCalculoProfundidad(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
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
			switch (penetracion.tipo)
			{
			case FemalePenetracionTipo.anus:
				estimulacionGenerada.moded *= this.m_IPhyscisIntervalosDeProfundidad.anusWeight;
				return;
			case FemalePenetracionTipo.vag:
				estimulacionGenerada.moded *= this.m_IPhyscisIntervalosDeProfundidad.vagWeight;
				return;
			case FemalePenetracionTipo.facial:
				estimulacionGenerada.moded *= this.m_IPhyscisIntervalosDeProfundidad.facialWeight;
				return;
			default:
				throw new ArgumentOutOfRangeException(penetracion.tipo.ToString());
			}
		}

		// Token: 0x06001B50 RID: 6992 RVA: 0x0006D74C File Offset: 0x0006B94C
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
			MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porPenetracionAnchura = this.m_emocionesDeOwner.mapas.modificadoresDeIntervalosSegunEmocion.dolor.porPenetracionAnchura;
			float num = 1f;
			intervalo = porPenetracionAnchura.vsArousal.Modificar(intervalo, emocionesValoresMods.arousal * num);
			intervalo = porPenetracionAnchura.vsPlacer.Modificar(intervalo, emocionesValoresMods.humanasValues.placer * num);
			for (int i = 0; i < this.m_modificadoresDeIntervaloAnchura.Count; i++)
			{
				this.m_modificadoresDeIntervaloAnchura[i].StackIfGreater(this.m_Emo.reaccion, tipo, ref intervalo);
			}
			float num2;
			float num3;
			switch (tipo)
			{
			case FemalePenetracionTipo.anus:
				num2 = Mathf.Clamp(intervalo.max, this.m_IHolesRangosClamp_PorDesgaste.anus.anchura.min * 0.1f, this.m_IHolesRangosClamp_PorDesgaste.anus.anchura.max * 0.1f);
				num3 = Mathf.Clamp(intervalo.min, this.m_IHolesRangosClamp_PorDesgaste.anus.anchura.min, this.m_IHolesRangosClamp_PorDesgaste.anus.anchura.max);
				break;
			case FemalePenetracionTipo.vag:
				num2 = Mathf.Clamp(intervalo.max, this.m_IHolesRangosClamp_PorDesgaste.vag.anchura.min * 0.1f, this.m_IHolesRangosClamp_PorDesgaste.vag.anchura.max * 0.1f);
				num3 = Mathf.Clamp(intervalo.min, this.m_IHolesRangosClamp_PorDesgaste.vag.anchura.min, this.m_IHolesRangosClamp_PorDesgaste.vag.anchura.max);
				break;
			case FemalePenetracionTipo.facial:
				num2 = Mathf.Clamp(intervalo.max, this.m_IHolesRangosClamp_PorDesgaste.garganta.anchura.min * 0.1f, this.m_IHolesRangosClamp_PorDesgaste.garganta.anchura.max * 0.1f);
				num3 = Mathf.Clamp(intervalo.min, this.m_IHolesRangosClamp_PorDesgaste.garganta.anchura.min, this.m_IHolesRangosClamp_PorDesgaste.garganta.anchura.max);
				break;
			default:
				throw new ArgumentOutOfRangeException(tipo.ToString());
			}
			intervalo = RangeValueV2.TryNew(num3, num2, 0.1f, 0.001f);
		}

		// Token: 0x06001B51 RID: 6993 RVA: 0x0006D9D0 File Offset: 0x0006BBD0
		protected override void OnPreUmbralCalculoAnchura(PenetracionesByMainInFrame.Penetracion penetracion, ref float cambio, ref RangeValueV2 intervalo, ref ValorModificable estimulacionGenerada)
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

		// Token: 0x04001389 RID: 5001
		public bool aplicarModsDeIntervalosVsEmocion = true;

		// Token: 0x0400138A RID: 5002
		private Personalidad m_personalidad;

		// Token: 0x0400138B RID: 5003
		private Arousal m_arousalV2;

		// Token: 0x0400138C RID: 5004
		private Placer m_placerV2;

		// Token: 0x0400138D RID: 5005
		[Obsolete("ahora esta en otra clase", true)]
		[SerializeField]
		private DolorPorPenetracion.ConfigDeMinValores m_ConfigDeMinValores = new DolorPorPenetracion.ConfigDeMinValores();

		// Token: 0x0400138E RID: 5006
		private List<IModDeInterDeGenCoitalPenVel> m_modificadoresDeIntervaloPenVel = new List<IModDeInterDeGenCoitalPenVel>();

		// Token: 0x0400138F RID: 5007
		[Obsolete("reemplazado por internals y hard  points", true)]
		private List<IModDeInterDeGenCoitalProfundidad> m_modificadoresDeIntervaloProfundiad = new List<IModDeInterDeGenCoitalProfundidad>();

		// Token: 0x04001390 RID: 5008
		private List<IModDeInterDeGenCoitalAnchura> m_modificadoresDeIntervaloAnchura = new List<IModDeInterDeGenCoitalAnchura>();

		// Token: 0x04001391 RID: 5009
		private IHolesRangosClamp m_IHolesRangosClamp_PorDesgaste;

		// Token: 0x04001392 RID: 5010
		private ModifiicablesDeDamageAndIntervalsEnEmocionDeInteraccion m_modificablesDeInteraccio;

		// Token: 0x04001393 RID: 5011
		private IPhyscisIntervalosDeProfundidadAbove m_IPhyscisIntervalosDeProfundidad;

		// Token: 0x02000490 RID: 1168
		[Obsolete("ahora esta en otra clase", true)]
		[Serializable]
		public class ConfigDeMinValores
		{
			// Token: 0x04001394 RID: 5012
			public float profundiadMinimaDeVag = 0.03f;

			// Token: 0x04001395 RID: 5013
			public float anchuraMinimaDeVag = 0.005f;

			// Token: 0x04001396 RID: 5014
			public float profundiadMinimaDeAnus;

			// Token: 0x04001397 RID: 5015
			public float anchuraMinimaDeAnus;

			// Token: 0x04001398 RID: 5016
			public float profundiadMinimaDeBoca = 0.065f;

			// Token: 0x04001399 RID: 5017
			public float anchuraMinimaDeBoca = 0.035f;
		}
	}
}
