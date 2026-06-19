using System;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas
{
	// Token: 0x02000438 RID: 1080
	[CreateAssetMenu(fileName = "MapaDeEmociones", menuName = "Objetos/Emociones/MapaDeEmociones")]
	public class MapaDeEmociones : ScriptableObject, ICloneable
	{
		// Token: 0x06001825 RID: 6181 RVA: 0x00060A4E File Offset: 0x0005EC4E
		public object Clone()
		{
			return this.Clonar(true, false, false);
		}

		// Token: 0x04001242 RID: 4674
		[Header("Confprmacion de grupos segun partes")]
		public MapaDeEmociones.GruposDePartesHumanas gruposDePartesHumanas = new MapaDeEmociones.GruposDePartesHumanas();

		// Token: 0x04001243 RID: 4675
		public MapaDeEmociones.GruposDePartesEstimulantes gruposDePartesEstimulantes = new MapaDeEmociones.GruposDePartesEstimulantes();

		// Token: 0x04001244 RID: 4676
		[Header("max emocion por grupo de cada tipo de emocion")]
		[Header("OJO recordar que max emos estan en configuracion global")]
		public MapaDeEmociones.MaxEmocionValuePorGrupo maxEmocionValuePorGrupo = new MapaDeEmociones.MaxEmocionValuePorGrupo();

		// Token: 0x04001245 RID: 4677
		[Header("datos de generacion de estimulacion")]
		public MapaDeEmociones.UmbralData umbralData = new MapaDeEmociones.UmbralData();

		// Token: 0x04001246 RID: 4678
		[Header("modificadores De estimulacion Generada")]
		public MapaDeEmociones.ModificadoresDeGeneradoPorGrupo modificadoresDeGeneradoPorGrupo = new MapaDeEmociones.ModificadoresDeGeneradoPorGrupo();

		// Token: 0x04001247 RID: 4679
		[Header("modificadores de intervalos Por Emocion")]
		public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion modificadoresDeIntervalosSegunEmocion = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion();

		// Token: 0x04001248 RID: 4680
		[Header("modificadores de intervalos Por Grupo de parte estimulada")]
		public MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados modificadoresDeIntervalosSegunGrupo = new MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados();

		// Token: 0x04001249 RID: 4681
		[Header("modificadores de intervalos Por Grupo de parte Estimulante")]
		public MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulantes modificadoresDeIntervalosSegunGrupoEstimulante = new MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulantes();

		// Token: 0x02000439 RID: 1081
		[Serializable]
		public class ModificadoresDeIntervalosSegunGrupo_Estimulados
		{
			// Token: 0x0400124A RID: 4682
			public MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados.Interacciones erogeno = new MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados.Interacciones();

			// Token: 0x0400124B RID: 4683
			public MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados.InteraccionesSoloIncrementos privacidad = new MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados.InteraccionesSoloIncrementos();

			// Token: 0x0400124C RID: 4684
			public MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados.Interacciones sensibilidad = new MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados.Interacciones();

			// Token: 0x0200043A RID: 1082
			[Serializable]
			public class InteraccionesSoloIncrementos
			{
				// Token: 0x0400124D RID: 4685
				public FloatPorGrupoDicc incPorCaricias;

				// Token: 0x0400124E RID: 4686
				public FloatPorGrupoDicc incPorPenetracion;
			}

			// Token: 0x0200043B RID: 1083
			[Serializable]
			public class Interacciones
			{
				// Token: 0x0400124F RID: 4687
				public MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados.Par porCaricias = new MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados.Par();

				// Token: 0x04001250 RID: 4688
				[Tooltip("para velocidad, apertura, movimiento")]
				public MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados.Par porPenetracionVelAperMov = new MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados.Par();

				// Token: 0x04001251 RID: 4689
				[HideInInspector]
				[Obsolete("")]
				public MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados.Par porPenetracionProfundidad = new MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados.Par();

				// Token: 0x04001252 RID: 4690
				public MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados.Par porPenetracionAnchura = new MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulados.Par();
			}

			// Token: 0x0200043C RID: 1084
			[Serializable]
			public class Par
			{
				// Token: 0x04001253 RID: 4691
				public FloatPorGrupoDicc incremento;

				// Token: 0x04001254 RID: 4692
				public FloatPorGrupoDicc expancion;
			}
		}

		// Token: 0x0200043D RID: 1085
		[Serializable]
		public class ModificadoresDeIntervalosSegunGrupo_Estimulantes
		{
			// Token: 0x04001255 RID: 4693
			public MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulantes.Interacciones erogeno = new MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulantes.Interacciones();

			// Token: 0x04001256 RID: 4694
			public MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulantes.InteraccionesSoloIncrementos privacidad = new MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulantes.InteraccionesSoloIncrementos();

			// Token: 0x04001257 RID: 4695
			public MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulantes.Interacciones sensibilidad = new MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulantes.Interacciones();

			// Token: 0x0200043E RID: 1086
			[Serializable]
			public class InteraccionesSoloIncrementos
			{
				// Token: 0x04001258 RID: 4696
				public FloatPorGrupoDicc incPorCaricias;

				// Token: 0x04001259 RID: 4697
				public FloatPorGrupoDicc incPorPenetracion;
			}

			// Token: 0x0200043F RID: 1087
			[Serializable]
			public class Interacciones
			{
				// Token: 0x0400125A RID: 4698
				public MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulantes.Par porCaricias = new MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulantes.Par();

				// Token: 0x0400125B RID: 4699
				public MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulantes.Par porPenetracion = new MapaDeEmociones.ModificadoresDeIntervalosSegunGrupo_Estimulantes.Par();
			}

			// Token: 0x02000440 RID: 1088
			[Serializable]
			public class Par
			{
				// Token: 0x0400125C RID: 4700
				public FloatPorGrupoDicc incremento;

				// Token: 0x0400125D RID: 4701
				public FloatPorGrupoDicc expancion;
			}
		}

		// Token: 0x02000441 RID: 1089
		[Serializable]
		public class ModificadoresDeIntervalosSegunEmocion
		{
			// Token: 0x0400125E RID: 4702
			public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.InteraccionesPlacer placer = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.InteraccionesPlacer();

			// Token: 0x0400125F RID: 4703
			public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.InteracionesRage rage = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.InteracionesRage();

			// Token: 0x04001260 RID: 4704
			public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.InteraccionesCaricaiasPlacerArousal rage_Golpes = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.InteraccionesCaricaiasPlacerArousal();

			// Token: 0x04001261 RID: 4705
			public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.InteraccionesPlacerArousal dolor = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.InteraccionesPlacerArousal();

			// Token: 0x02000442 RID: 1090
			[Serializable]
			public class InteracionesRage : MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.InteraccionesConcentArousal
			{
				// Token: 0x04001262 RID: 4706
				public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunConcentArousal porVer = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunConcentArousal();

				// Token: 0x04001263 RID: 4707
				public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunConcentArousalAdvance porSiendoVisto = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunConcentArousalAdvance();

				// Token: 0x04001264 RID: 4708
				public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunConcentArousal porSerDesvestidoPorOtro = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunConcentArousal();

				// Token: 0x04001265 RID: 4709
				public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunConcentArousal porSerDesvestidoPorSiMismo = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunConcentArousal();

				// Token: 0x04001266 RID: 4710
				public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunConcentArousal porEjecucionDePosePorOtro = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunConcentArousal();

				// Token: 0x04001267 RID: 4711
				public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunConcentArousal porEjecucionDePosePorSiMismo = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunConcentArousal();
			}

			// Token: 0x02000443 RID: 1091
			[Serializable]
			public class InteraccionesPlacer
			{
				// Token: 0x04001268 RID: 4712
				public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porPenetracionProfundidad = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal();

				// Token: 0x04001269 RID: 4713
				public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porPenetracionAnchura = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal();

				// Token: 0x0400126A RID: 4714
				public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porPenetracionMovimiento = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal();

				// Token: 0x0400126B RID: 4715
				public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porPenetracionApertura = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal();

				// Token: 0x0400126C RID: 4716
				public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porPenetracion = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal();

				// Token: 0x0400126D RID: 4717
				public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porCaricias = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal();

				// Token: 0x0400126E RID: 4718
				public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porVer = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal();

				// Token: 0x0400126F RID: 4719
				public MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal porSiendoVisto = new MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal();
			}

			// Token: 0x02000444 RID: 1092
			[Serializable]
			public class InteraccionesCaricaiasPlacerArousal : MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.InteraccionesCaricias<MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal>
			{
			}

			// Token: 0x02000445 RID: 1093
			[Serializable]
			public class InteraccionesPlacerArousal : MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.InteraccionesCompletas<MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunPlacerArousal>
			{
			}

			// Token: 0x02000446 RID: 1094
			[Serializable]
			public class InteraccionesConcentArousal : MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.InteraccionesBasicas<MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunConcentArousalAdvance>
			{
			}

			// Token: 0x02000447 RID: 1095
			public abstract class InteraccionesCaricias<Tmapa> where Tmapa : new()
			{
				// Token: 0x04001270 RID: 4720
				public Tmapa porCaricias = new Tmapa();
			}

			// Token: 0x02000448 RID: 1096
			public abstract class InteraccionesBasicas<Tmapa> : MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.InteraccionesCaricias<Tmapa> where Tmapa : new()
			{
				// Token: 0x04001271 RID: 4721
				public Tmapa porPenetracion = new Tmapa();
			}

			// Token: 0x02000449 RID: 1097
			public abstract class InteraccionesCompletas<Tmapa> : MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.InteraccionesBasicas<Tmapa> where Tmapa : new()
			{
				// Token: 0x04001272 RID: 4722
				public Tmapa porPenetracionProfundidad = new Tmapa();

				// Token: 0x04001273 RID: 4723
				public Tmapa porPenetracionAnchura = new Tmapa();

				// Token: 0x04001274 RID: 4724
				public Tmapa porPenetracionMovimiento = new Tmapa();

				// Token: 0x04001275 RID: 4725
				public Tmapa porPenetracionApertura = new Tmapa();
			}

			// Token: 0x0200044A RID: 1098
			[Serializable]
			public class ModificadoresSegunConcentArousal
			{
				// Token: 0x04001276 RID: 4726
				public FloatPorGrupoDicc concentRequeridoPorGrupo;

				// Token: 0x04001277 RID: 4727
				public ModifcadorDeIntervalo concentVsArousal;
			}

			// Token: 0x0200044B RID: 1099
			[Serializable]
			public class ModificadoresSegunConcentArousalAdvance : MapaDeEmociones.ModificadoresDeIntervalosSegunEmocion.ModificadoresSegunConcentArousal
			{
				// Token: 0x04001278 RID: 4728
				[Tooltip("segun la parte interactuando, es decir pene y mano modificar de manera diferente")]
				public FloatPorGrupoDicc modificadorDeConcentRequeridoPorGrupoEstimulante;

				// Token: 0x04001279 RID: 4729
				public ModifcadorDeIntervalo cambioVsArousal;
			}

			// Token: 0x0200044C RID: 1100
			[Serializable]
			public class ModificadoresSegunPlacerArousal
			{
				// Token: 0x0400127A RID: 4730
				public ModifcadorDeIntervalo vsPlacer;

				// Token: 0x0400127B RID: 4731
				public ModifcadorDeIntervalo vsArousal;
			}
		}

		// Token: 0x0200044D RID: 1101
		[Serializable]
		public class UmbralData
		{
			// Token: 0x0400127C RID: 4732
			[Header("Placer")]
			public MapaDeEmociones.UmbralData.UmbralesDeEmocionCaricias placer_Caricias = new MapaDeEmociones.UmbralData.UmbralesDeEmocionCaricias();

			// Token: 0x0400127D RID: 4733
			public MapaDeEmociones.UmbralData.UmbralesDeEmocionPenetracionCompleta_ConBoca placer_Penetracion = new MapaDeEmociones.UmbralData.UmbralesDeEmocionPenetracionCompleta_ConBoca();

			// Token: 0x0400127E RID: 4734
			public MapaDeEmociones.UmbralData.UmbralesDeEmocionVision placer_Vision = new MapaDeEmociones.UmbralData.UmbralesDeEmocionVision();

			// Token: 0x0400127F RID: 4735
			[Header("Rage")]
			public MapaDeEmociones.UmbralData.UmbralesDeEmocionGolpes rage_Caricias = new MapaDeEmociones.UmbralData.UmbralesDeEmocionGolpes();

			// Token: 0x04001280 RID: 4736
			public MapaDeEmociones.UmbralData.UmbralesDeEmocionPenetracionBasica rage_Penetracion = new MapaDeEmociones.UmbralData.UmbralesDeEmocionPenetracionBasica();

			// Token: 0x04001281 RID: 4737
			public MapaDeEmociones.UmbralData.UmbralesDeEmocionVision rage_Vision = new MapaDeEmociones.UmbralData.UmbralesDeEmocionVision();

			// Token: 0x04001282 RID: 4738
			public MapaDeEmociones.UmbralData.UmbralesDeEmocionDeAcciones rage_Desvestidura = new MapaDeEmociones.UmbralData.UmbralesDeEmocionDeAcciones();

			// Token: 0x04001283 RID: 4739
			public MapaDeEmociones.UmbralData.UmbralesDeEmocionDeAcciones rage_EjecucionDePose = new MapaDeEmociones.UmbralData.UmbralesDeEmocionDeAcciones();

			// Token: 0x04001284 RID: 4740
			[Header("Dolor")]
			public MapaDeEmociones.UmbralData.UmbralesDeEmocionGolpes dolor_Caricias = new MapaDeEmociones.UmbralData.UmbralesDeEmocionGolpes();

			// Token: 0x04001285 RID: 4741
			public MapaDeEmociones.UmbralData.UmbralesDeEmocionPenetracionCompleta_ConBoca dolor_Penetracion = new MapaDeEmociones.UmbralData.UmbralesDeEmocionPenetracionCompleta_ConBoca();

			// Token: 0x0200044E RID: 1102
			[Serializable]
			public class UmbralesDeEmocionDeAcciones
			{
				// Token: 0x04001286 RID: 4742
				public DatosDeUmbral PorOtros;

				// Token: 0x04001287 RID: 4743
				public DatosDeUmbral porSiMismo;
			}

			// Token: 0x0200044F RID: 1103
			[Serializable]
			public class UmbralesDeEmocionPenetracionCompleta : MapaDeEmociones.UmbralData.UmbralesDeEmocionPenetracionAdvance
			{
				// Token: 0x04001288 RID: 4744
				[HideInInspector]
				[Obsolete("", true)]
				public DatosDeUmbral porProfundidadVaginal;

				// Token: 0x04001289 RID: 4745
				public DatosDeUmbralSinIntervalo porProfundidadVaginalV2;

				// Token: 0x0400128A RID: 4746
				public DatosDeUmbral porAnchuraVaginal;

				// Token: 0x0400128B RID: 4747
				[HideInInspector]
				[Obsolete("", true)]
				public DatosDeUmbral porProfundidadAnal;

				// Token: 0x0400128C RID: 4748
				public DatosDeUmbralSinIntervalo porProfundidadAnalV2;

				// Token: 0x0400128D RID: 4749
				public DatosDeUmbral porAnchuraAnal;
			}

			// Token: 0x02000450 RID: 1104
			[Serializable]
			public class UmbralesDeEmocionPenetracionCompleta_ConBoca : MapaDeEmociones.UmbralData.UmbralesDeEmocionPenetracionCompleta
			{
				// Token: 0x0400128E RID: 4750
				[HideInInspector]
				[Obsolete("", true)]
				public DatosDeUmbral porPenetracionFacialProfundidad;

				// Token: 0x0400128F RID: 4751
				public DatosDeUmbralSinIntervalo porPenetracionFacialProfundidadV2;

				// Token: 0x04001290 RID: 4752
				public DatosDeUmbral porPenetracionFacialAnchura;
			}

			// Token: 0x02000451 RID: 1105
			[Serializable]
			public class UmbralesDeEmocionPenetracionAdvance : MapaDeEmociones.UmbralData.UmbralesDeEmocionPenetracionBasica
			{
				// Token: 0x04001291 RID: 4753
				public DatosDeUmbral porPenetracionApertura;

				// Token: 0x04001292 RID: 4754
				public DatosDeUmbral porPenetracionMovimiento;
			}

			// Token: 0x02000452 RID: 1106
			[Serializable]
			public class UmbralesDeEmocionPenetracionBasica
			{
				// Token: 0x04001293 RID: 4755
				public DatosDeUmbral porPenetracion;
			}

			// Token: 0x02000453 RID: 1107
			[Serializable]
			public class UmbralesDeEmocionCaricias
			{
				// Token: 0x04001294 RID: 4756
				public DatosDeUmbral porCaricias;
			}

			// Token: 0x02000454 RID: 1108
			[Serializable]
			public class UmbralesDeEmocionGolpes : MapaDeEmociones.UmbralData.UmbralesDeEmocionCaricias
			{
				// Token: 0x04001295 RID: 4757
				public DatosDeUmbral porGolpes;
			}

			// Token: 0x02000455 RID: 1109
			[Serializable]
			public class UmbralesDeEmocionVision
			{
				// Token: 0x04001296 RID: 4758
				public DatosDeUmbral mirando;

				// Token: 0x04001297 RID: 4759
				public DatosDeUmbral siendoMirado;
			}
		}

		// Token: 0x02000456 RID: 1110
		[Serializable]
		public class MaxEmocionValuePorGrupo
		{
			// Token: 0x04001298 RID: 4760
			public MaxPlacerPorGrupo placer;

			// Token: 0x04001299 RID: 4761
			public FloatPorGrupoDicc placerModificacionAlArousalMaximo;
		}

		// Token: 0x02000457 RID: 1111
		[Serializable]
		public class ModificadoresDeGeneradoPorGrupo
		{
			// Token: 0x0400129A RID: 4762
			public FloatPorGrupoDicc erogenoEstimulados;

			// Token: 0x0400129B RID: 4763
			public FloatPorGrupoDicc erogenoEstimulantes;

			// Token: 0x0400129C RID: 4764
			public FloatPorGrupoDicc erogenoVisualEstimulados;

			// Token: 0x0400129D RID: 4765
			public FloatPorGrupoDicc privacidadEstimulados;

			// Token: 0x0400129E RID: 4766
			public FloatPorGrupoDicc privacidadEstimulantes;

			// Token: 0x0400129F RID: 4767
			public FloatPorGrupoDicc privacidadVisualEstimulantes;

			// Token: 0x040012A0 RID: 4768
			public FloatPorGrupoDicc seinsibilidadEstimulados;

			// Token: 0x040012A1 RID: 4769
			public FloatPorGrupoDicc seinsibilidadEstimulantes;
		}

		// Token: 0x02000458 RID: 1112
		[Serializable]
		public class GruposDePartesHumanas
		{
			// Token: 0x040012A2 RID: 4770
			public PartesHumanasPorGrupo seinsibilidad;

			// Token: 0x040012A3 RID: 4771
			public PartesHumanasPorGrupo erogeno;

			// Token: 0x040012A4 RID: 4772
			public PartesHumanasPorGrupo erogenoVisual;

			// Token: 0x040012A5 RID: 4773
			public PartesHumanasPorGrupo privacidad;

			// Token: 0x040012A6 RID: 4774
			public PartesHumanasPorGrupo privacidadVisual;
		}

		// Token: 0x02000459 RID: 1113
		[Serializable]
		public class GruposDePartesEstimulantes
		{
			// Token: 0x040012A7 RID: 4775
			public PartesEstimulantePorGrupo seinsibilidad;

			// Token: 0x040012A8 RID: 4776
			public PartesEstimulantePorGrupo erogeno;

			// Token: 0x040012A9 RID: 4777
			public PartesEstimulantePorGrupo privacidad;
		}
	}
}
