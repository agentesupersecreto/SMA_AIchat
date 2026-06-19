using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI;
using Assets._ReusableScripts.CuchiCuchi.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Globales.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Dialogos.Genericos.Testing
{
	// Token: 0x02000181 RID: 385
	public class PrintTESTDialogosGenericos : AplicableBehaviour
	{
		// Token: 0x0600084E RID: 2126 RVA: 0x0002B9D4 File Offset: 0x00029BD4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (!Application.isEditor)
			{
				global::UnityEngine.Debug.LogError("Clase " + base.GetType().Name + " es SOLO para editor");
				Object.Destroy(this);
				return;
			}
			if (!Application.isEditor && !global::UnityEngine.Debug.isDebugBuild)
			{
				Object.Destroy(this);
			}
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x0002BA28 File Offset: 0x00029C28
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (!Application.isEditor)
			{
				return;
			}
			if (this.target == null)
			{
				this.target = Object.FindObjectOfType<TargetChar>().character as FemaleChar;
			}
			if (this.target == null)
			{
				throw new ArgumentNullException("tipTarget", "tipTarget null reference.");
			}
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x0002BA84 File Offset: 0x00029C84
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Buscar TODOS los Mapas",
				playTimeVisible = false
			};
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0002BA9D File Offset: 0x00029C9D
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			this.mapas = PrintTESTDialogosGenericos.CargarTodosLosMapas();
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x0002BAB0 File Offset: 0x00029CB0
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Buscar Mapas es Carpeta",
				playTimeVisible = false
			};
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0002BAC9 File Offset: 0x00029CC9
		protected override void OnAplicar3()
		{
			base.OnAplicar3();
			this.mapas = PrintTESTDialogosGenericos.CargarTodosLosMapasEnCarpeta();
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x0002BADC File Offset: 0x00029CDC
		protected override CustomMonobehaviourBotonConfig Boton4()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Print recibidas",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x0002BAF8 File Offset: 0x00029CF8
		protected override void OnAplicar4()
		{
			base.OnAplicar4();
			if (this.target == null || !Application.isEditor)
			{
				return;
			}
			if (this.incluirMapasEnDialogosSingletones.Count > 0)
			{
				List<DialogosLocalizadosGenericos> list = new List<DialogosLocalizadosGenericos>(this.mapas);
				list.AddRange(PrintTESTDialogosGenericos.CargarTodosLosMapasDeDialogosSingletones(this.incluirMapasEnDialogosSingletones));
				this.mapas = new HashSet<DialogosLocalizadosGenericos>(list).ToList<DialogosLocalizadosGenericos>();
			}
			this.m_siempreInvalidos.Clear();
			PrintTESTDialogosGenericos.DebugClases debugClases = new PrintTESTDialogosGenericos.DebugClases();
			debugClases.Init(this.target);
			ObtenerDialogosUtil obtenerDialogosUtil = new ObtenerDialogosUtil(null, this);
			obtenerDialogosUtil.forcedEnAutoInteraccion = this.emularEnAutoInteraccionCoital;
			StringBuilder stringBuilder3 = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			HashSet<string> hashSet = new HashSet<string>();
			stringBuilder3.Append("RECIBIDAS. \n");
			foreach (DialogosLocalizadosGenericos dialogosLocalizadosGenericos in this.mapas)
			{
				int? num;
				if (this.sobreEscirbirIntensidadCoital)
				{
					num = new int?(this.intensidadCoitalSobreescrita);
				}
				else
				{
					num = null;
				}
				if (dialogosLocalizadosGenericos.ParaCultura(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id))
				{
					PrintTESTDialogosGenericos.AppendListaDeDialogo(num, dialogosLocalizadosGenericos, obtenerDialogosUtil, stringBuilder3, stringBuilder2, hashSet, this.m_siempreInvalidos, this.usarTactiles ? debugClases.tactilesRecibidas : null, this.usarCoitales ? debugClases.coitalRecibidas : null, this.usarVisuales ? debugClases.visualRecibidas : null, this.usarPeticionExponer ? debugClases.peticionExponerRecibidas : null, this.usarPeticionMover ? debugClases.peticionMoverRecibidas : null, this.usarExponer ? debugClases.exponerRecibidas : null, this.usarManipular ? debugClases.manipularRecibidas : null);
				}
			}
			HandleTextFile.WriteTextFile(this.pathDebug, stringBuilder3.ToString());
			HandleTextFile.WriteTextFile(this.pathLimpio, stringBuilder2.ToString());
			if (this.testSimpreContextoErradoOrRedundante && this.m_siempreInvalidos.Count > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				this.m_siempreInvalidos.ForEach(delegate([TupleElementNames(new string[] { "mapa", "dialogo" })] ValueTuple<DialogosLocalizadosGenericos, DialogoInfoGenerico> par)
				{
					stringBuilder.Append(par.Item1.name);
					stringBuilder.Append('=');
					stringBuilder.Append('>');
					stringBuilder.AppendLine(((IDialogoInfoTextMods)par.Item2).text);
				});
				HandleTextFile.WriteTextFile(this.pathAlwaysBad, stringBuilder.ToString());
			}
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x0002BD38 File Offset: 0x00029F38
		protected override CustomMonobehaviourBotonConfig Boton5()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Print dadas",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x0002BD54 File Offset: 0x00029F54
		protected override void OnAplicar5()
		{
			base.OnAplicar5();
			if (this.target == null || !Application.isEditor)
			{
				return;
			}
			PrintTESTDialogosGenericos.DebugClases debugClases = new PrintTESTDialogosGenericos.DebugClases();
			debugClases.Init(this.target);
			ObtenerDialogosUtil obtenerDialogosUtil = new ObtenerDialogosUtil(null, this);
			obtenerDialogosUtil.forcedEnAutoInteraccion = this.emularEnAutoInteraccionCoital;
			StringBuilder stringBuilder = new StringBuilder();
			StringBuilder stringBuilder2 = new StringBuilder();
			HashSet<string> hashSet = new HashSet<string>();
			stringBuilder.Append("DADAS. \n");
			foreach (DialogosLocalizadosGenericos dialogosLocalizadosGenericos in this.mapas)
			{
				int? num;
				if (this.sobreEscirbirIntensidadCoital)
				{
					num = new int?(this.intensidadCoitalSobreescrita);
				}
				else
				{
					num = null;
				}
				if (dialogosLocalizadosGenericos.ParaCultura(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id))
				{
					PrintTESTDialogosGenericos.AppendListaDeDialogo(num, dialogosLocalizadosGenericos, obtenerDialogosUtil, stringBuilder, stringBuilder2, hashSet, null, this.usarTactiles ? debugClases.tactilesDadas : null, this.usarCoitales ? debugClases.coitalDadas : null, this.usarVisuales ? debugClases.visualDadas : null, this.usarPeticionExponer ? debugClases.peticionExponerDadas : null, this.usarPeticionMover ? debugClases.peticionMoverDadas : null, this.usarExponer ? debugClases.exponerDadas : null, this.usarManipular ? debugClases.manipularDadas : null);
				}
			}
			HandleTextFile.WriteTextFile(this.pathDebug, stringBuilder.ToString());
			HandleTextFile.WriteTextFile(this.pathLimpio, stringBuilder2.ToString());
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x0002BEEC File Offset: 0x0002A0EC
		protected override CustomMonobehaviourBotonConfig Boton6()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Reemplazar En Mapas",
				playTimeVisible = false,
				confirmar = true
			};
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x0002BF0C File Offset: 0x0002A10C
		protected override void OnAplicar6()
		{
			base.OnAplicar6();
			if (string.IsNullOrEmpty(this.buscar))
			{
				return;
			}
			foreach (DialogosLocalizadosGenericos dialogosLocalizadosGenericos in this.mapas)
			{
				TValleEditorTools.SaveUndo(dialogosLocalizadosGenericos);
				foreach (DialogoInfo dialogoInfo in dialogosLocalizadosGenericos.dialogosInfoBase)
				{
					((IDialogoInfoTextMods)dialogoInfo).text = ((IDialogoInfoTextMods)dialogoInfo).text.Replace(this.buscar, this.reemplazar);
				}
				TValleEditorTools.PrefabSetDirtyV2(dialogosLocalizadosGenericos);
			}
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x0002BFC8 File Offset: 0x0002A1C8
		private static void AppendListaDeDialogo(int? intensidadCoitalEmulada, DialogosLocalizadosGenericos mapaGenerico, ObtenerDialogosUtil util, StringBuilder debugString, StringBuilder dialogosLimpios, HashSet<string> dialogosLimpiosSet, [TupleElementNames(new string[] { "mapa", "dialogo" })] List<ValueTuple<DialogosLocalizadosGenericos, DialogoInfoGenerico>> siempreInvalidos, List<ICalculoDeEstimuloTactil> tactiles, List<ICalculoDeEstimuloCoitalHole> coitales, List<ICalculoDeEstimuloVisual> visales, List<ICalculoDeEstimuloPorCambioDePose> peticionExponer, List<ICalculoDeEstimuloPorMovimientoDeBones> peticionMover, List<ICalculoDeEstimuloPorCambioDePose> exponer, List<ICalculoDeEstimuloPorMovimientoDeBones> manipular)
		{
			if (!mapaGenerico.IsValid() || mapaGenerico.dialogosInfo.Count == 0)
			{
				return;
			}
			debugString.Append("**MAP:");
			debugString.Append(mapaGenerico.name);
			debugString.Append("\n");
			if (mapaGenerico.dialogosInfo.Count > 0)
			{
				bool flag = false;
				DialogoInfoGenerico dialogoInfoGenerico = mapaGenerico.dialogosInfo[0];
				debugString.Append("\t****Generic text:");
				debugString.Append(dialogoInfoGenerico.seccionado);
				debugString.Append("\n");
				for (int i = 0; i < 2; i++)
				{
					Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuestaDeDialogoDeHeroina = (Personalidad.TipoDeRespuestaDeDialogoDeHeroina)typeof(Personalidad.TipoDeRespuestaDeDialogoDeHeroina).GetEnumRandom();
					if (tipoDeRespuestaDeDialogoDeHeroina == Personalidad.TipoDeRespuestaDeDialogoDeHeroina.None)
					{
						tipoDeRespuestaDeDialogoDeHeroina = Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable;
					}
					debugString.Append("\t");
					debugString.Append("****personalidad:");
					debugString.Append(tipoDeRespuestaDeDialogoDeHeroina.ToString());
					debugString.Append("\n");
					if (tactiles != null)
					{
						flag |= PrintTESTDialogosGenericos.AppendCalculoTactil(dialogoInfoGenerico, util, tactiles, tipoDeRespuestaDeDialogoDeHeroina, debugString, dialogosLimpios, dialogosLimpiosSet);
					}
					tipoDeRespuestaDeDialogoDeHeroina = (Personalidad.TipoDeRespuestaDeDialogoDeHeroina)typeof(Personalidad.TipoDeRespuestaDeDialogoDeHeroina).GetEnumRandom();
					if (tipoDeRespuestaDeDialogoDeHeroina == Personalidad.TipoDeRespuestaDeDialogoDeHeroina.None)
					{
						tipoDeRespuestaDeDialogoDeHeroina = Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable;
					}
					if (visales != null)
					{
						flag |= PrintTESTDialogosGenericos.AppendCalculoVisual(dialogoInfoGenerico, util, visales, tipoDeRespuestaDeDialogoDeHeroina, debugString, dialogosLimpios, dialogosLimpiosSet);
					}
					tipoDeRespuestaDeDialogoDeHeroina = (Personalidad.TipoDeRespuestaDeDialogoDeHeroina)typeof(Personalidad.TipoDeRespuestaDeDialogoDeHeroina).GetEnumRandom();
					if (tipoDeRespuestaDeDialogoDeHeroina == Personalidad.TipoDeRespuestaDeDialogoDeHeroina.None)
					{
						tipoDeRespuestaDeDialogoDeHeroina = Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable;
					}
					if (coitales != null)
					{
						flag |= PrintTESTDialogosGenericos.AppendCalculoCoital(intensidadCoitalEmulada, dialogoInfoGenerico, util, coitales, tipoDeRespuestaDeDialogoDeHeroina, debugString, dialogosLimpios, dialogosLimpiosSet);
					}
					tipoDeRespuestaDeDialogoDeHeroina = (Personalidad.TipoDeRespuestaDeDialogoDeHeroina)typeof(Personalidad.TipoDeRespuestaDeDialogoDeHeroina).GetEnumRandom();
					if (tipoDeRespuestaDeDialogoDeHeroina == Personalidad.TipoDeRespuestaDeDialogoDeHeroina.None)
					{
						tipoDeRespuestaDeDialogoDeHeroina = Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable;
					}
					if (peticionExponer != null)
					{
						flag |= PrintTESTDialogosGenericos.AppendCalculoPeticionExponer(dialogoInfoGenerico, util, peticionExponer, tipoDeRespuestaDeDialogoDeHeroina, debugString, dialogosLimpios, dialogosLimpiosSet);
					}
					tipoDeRespuestaDeDialogoDeHeroina = (Personalidad.TipoDeRespuestaDeDialogoDeHeroina)typeof(Personalidad.TipoDeRespuestaDeDialogoDeHeroina).GetEnumRandom();
					if (tipoDeRespuestaDeDialogoDeHeroina == Personalidad.TipoDeRespuestaDeDialogoDeHeroina.None)
					{
						tipoDeRespuestaDeDialogoDeHeroina = Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable;
					}
					if (exponer != null)
					{
						flag |= PrintTESTDialogosGenericos.AppendCalculoExponer(dialogoInfoGenerico, util, exponer, tipoDeRespuestaDeDialogoDeHeroina, debugString, dialogosLimpios, dialogosLimpiosSet);
					}
					tipoDeRespuestaDeDialogoDeHeroina = (Personalidad.TipoDeRespuestaDeDialogoDeHeroina)typeof(Personalidad.TipoDeRespuestaDeDialogoDeHeroina).GetEnumRandom();
					if (tipoDeRespuestaDeDialogoDeHeroina == Personalidad.TipoDeRespuestaDeDialogoDeHeroina.None)
					{
						tipoDeRespuestaDeDialogoDeHeroina = Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable;
					}
					if (peticionMover != null)
					{
						flag |= PrintTESTDialogosGenericos.AppendCalculoPeticionMover(dialogoInfoGenerico, util, peticionMover, tipoDeRespuestaDeDialogoDeHeroina, debugString, dialogosLimpios, dialogosLimpiosSet);
					}
					tipoDeRespuestaDeDialogoDeHeroina = (Personalidad.TipoDeRespuestaDeDialogoDeHeroina)typeof(Personalidad.TipoDeRespuestaDeDialogoDeHeroina).GetEnumRandom();
					if (tipoDeRespuestaDeDialogoDeHeroina == Personalidad.TipoDeRespuestaDeDialogoDeHeroina.None)
					{
						tipoDeRespuestaDeDialogoDeHeroina = Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable;
					}
					if (peticionMover != null)
					{
						flag |= PrintTESTDialogosGenericos.AppendCalculoManipular(dialogoInfoGenerico, util, manipular, tipoDeRespuestaDeDialogoDeHeroina, debugString, dialogosLimpios, dialogosLimpiosSet);
					}
				}
				if (!flag && siempreInvalidos != null)
				{
					siempreInvalidos.Add(new ValueTuple<DialogosLocalizadosGenericos, DialogoInfoGenerico>(mapaGenerico, dialogoInfoGenerico));
				}
			}
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x0002C208 File Offset: 0x0002A408
		private static bool AppendCalculoPeticionMover(DialogoInfoGenerico dialogo, ObtenerDialogosUtil util, List<ICalculoDeEstimuloPorMovimientoDeBones> calculos, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, StringBuilder debugString, StringBuilder dialogosLimpios, HashSet<string> dialogosLimpiosSet)
		{
			bool flag = false;
			foreach (ICalculoDeEstimuloPorMovimientoDeBones calculoDeEstimuloPorMovimientoDeBones in calculos)
			{
				debugString.Append("\t\t********Peticion Mover:");
				debugString.Append(calculoDeEstimuloPorMovimientoDeBones.emocion.reaccion.ToString());
				debugString.Append(" |estimulante:");
				debugString.Append(calculoDeEstimuloPorMovimientoDeBones.estimulanteParte.ToString());
				debugString.Append(" |estimulada:");
				debugString.Append(calculoDeEstimuloPorMovimientoDeBones.estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).ToString());
				debugString.Append(" |tipo:");
				debugString.Append(0);
				debugString.Append("\n");
				ObtenerDialogosUtil.Resultado resultado;
				TipoDePalabraGenerica tipoDePalabraGenerica;
				if (!util.TryActualizarDialogoGenerico(out resultado, out tipoDePalabraGenerica, null, dialogo, calculoDeEstimuloPorMovimientoDeBones, null, new int?(Random.Range(-1, 2)), tipoDeRespuesta, false, false))
				{
					debugString.Append("\t\t\t");
					debugString.Append(resultado.ToString().ToUpperInvariant());
					if (dialogo != null)
					{
						debugString.Append(":");
						string text = dialogo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, (calculoDeEstimuloPorMovimientoDeBones.estimuloBasico.tipo == DireccionDeEstimulo.recibida) ? 1 : 2);
						debugString.Append(text);
					}
					debugString.Append("\n\n");
				}
				else
				{
					flag = true;
					string text2 = dialogo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, (calculoDeEstimuloPorMovimientoDeBones.estimuloBasico.tipo == DireccionDeEstimulo.recibida) ? 1 : 2);
					debugString.Append("\t\t\t");
					debugString.Append("- ");
					debugString.Append(text2);
					debugString.Append("\n\n");
					if (dialogosLimpiosSet.Add(text2))
					{
						dialogosLimpios.Append("- ");
						dialogosLimpios.Append(text2);
						dialogosLimpios.Append("\n\n");
					}
				}
			}
			return flag;
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x0002C434 File Offset: 0x0002A634
		private static bool AppendCalculoManipular(DialogoInfoGenerico dialogo, ObtenerDialogosUtil util, List<ICalculoDeEstimuloPorMovimientoDeBones> calculos, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, StringBuilder debugString, StringBuilder dialogosLimpios, HashSet<string> dialogosLimpiosSet)
		{
			bool flag = false;
			foreach (ICalculoDeEstimuloPorMovimientoDeBones calculoDeEstimuloPorMovimientoDeBones in calculos)
			{
				debugString.Append("\t\t********Manipular:");
				debugString.Append(calculoDeEstimuloPorMovimientoDeBones.emocion.reaccion.ToString());
				debugString.Append(" |estimulante:");
				debugString.Append(calculoDeEstimuloPorMovimientoDeBones.estimulanteParte.ToString());
				debugString.Append(" |estimulada:");
				debugString.Append(calculoDeEstimuloPorMovimientoDeBones.estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).ToString());
				debugString.Append(" |tipo:");
				debugString.Append(0);
				debugString.Append("\n");
				ObtenerDialogosUtil.Resultado resultado;
				TipoDePalabraGenerica tipoDePalabraGenerica;
				if (!util.TryActualizarDialogoGenerico(out resultado, out tipoDePalabraGenerica, null, dialogo, calculoDeEstimuloPorMovimientoDeBones, null, new int?(Random.Range(-1, 2)), tipoDeRespuesta, false, false))
				{
					debugString.Append("\t\t\t");
					debugString.Append(resultado.ToString().ToUpperInvariant());
					if (dialogo != null)
					{
						debugString.Append(":");
						string text = dialogo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, (calculoDeEstimuloPorMovimientoDeBones.estimuloBasico.tipo == DireccionDeEstimulo.recibida) ? 1 : 2);
						debugString.Append(text);
					}
					debugString.Append("\n\n");
				}
				else
				{
					flag = true;
					string text2 = dialogo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, (calculoDeEstimuloPorMovimientoDeBones.estimuloBasico.tipo == DireccionDeEstimulo.recibida) ? 1 : 2);
					debugString.Append("\t\t\t");
					debugString.Append("- ");
					debugString.Append(text2);
					debugString.Append("\n\n");
					if (dialogosLimpiosSet.Add(text2))
					{
						dialogosLimpios.Append("- ");
						dialogosLimpios.Append(text2);
						dialogosLimpios.Append("\n\n");
					}
				}
			}
			return flag;
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x0002C660 File Offset: 0x0002A860
		private static bool AppendCalculoPeticionExponer(DialogoInfoGenerico dialogo, ObtenerDialogosUtil util, List<ICalculoDeEstimuloPorCambioDePose> calculos, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, StringBuilder debugString, StringBuilder dialogosLimpios, HashSet<string> dialogosLimpiosSet)
		{
			bool flag = false;
			foreach (ICalculoDeEstimuloPorCambioDePose calculoDeEstimuloPorCambioDePose in calculos)
			{
				debugString.Append("\t\t********Peticion Exponer:");
				debugString.Append(calculoDeEstimuloPorCambioDePose.emocion.reaccion.ToString());
				debugString.Append(" |estimulante:");
				debugString.Append(calculoDeEstimuloPorCambioDePose.estimulanteParte.ToString());
				debugString.Append(" |estimulada:");
				debugString.Append(calculoDeEstimuloPorCambioDePose.estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).ToString());
				debugString.Append(" |tipo:");
				debugString.Append(calculoDeEstimuloPorCambioDePose.estimulo.tipoDeEstimuloCambiarPose.ToString());
				debugString.Append("\n");
				ObtenerDialogosUtil.Resultado resultado;
				TipoDePalabraGenerica tipoDePalabraGenerica;
				if (!util.TryActualizarDialogoGenerico(out resultado, out tipoDePalabraGenerica, null, dialogo, calculoDeEstimuloPorCambioDePose, null, new int?(Random.Range(-1, 2)), tipoDeRespuesta, false, false))
				{
					debugString.Append("\t\t\t");
					debugString.Append(resultado.ToString().ToUpperInvariant());
					if (dialogo != null)
					{
						debugString.Append(":");
						string text = dialogo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, (calculoDeEstimuloPorCambioDePose.estimuloBasico.tipo == DireccionDeEstimulo.recibida) ? 1 : 2);
						debugString.Append(text);
					}
					debugString.Append("\n\n");
				}
				else
				{
					flag = true;
					string text2 = dialogo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, (calculoDeEstimuloPorCambioDePose.estimuloBasico.tipo == DireccionDeEstimulo.recibida) ? 1 : 2);
					debugString.Append("\t\t\t");
					debugString.Append("- ");
					debugString.Append(text2);
					debugString.Append("\n\n");
					if (dialogosLimpiosSet.Add(text2))
					{
						dialogosLimpios.Append("- ");
						dialogosLimpios.Append(text2);
						dialogosLimpios.Append("\n\n");
					}
				}
			}
			return flag;
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x0002C8A8 File Offset: 0x0002AAA8
		private static bool AppendCalculoExponer(DialogoInfoGenerico dialogo, ObtenerDialogosUtil util, List<ICalculoDeEstimuloPorCambioDePose> calculos, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, StringBuilder debugString, StringBuilder dialogosLimpios, HashSet<string> dialogosLimpiosSet)
		{
			bool flag = false;
			foreach (ICalculoDeEstimuloPorCambioDePose calculoDeEstimuloPorCambioDePose in calculos)
			{
				debugString.Append("\t\t********Exponer:");
				debugString.Append(calculoDeEstimuloPorCambioDePose.emocion.reaccion.ToString());
				debugString.Append(" |estimulante:");
				debugString.Append(calculoDeEstimuloPorCambioDePose.estimulanteParte.ToString());
				debugString.Append(" |estimulada:");
				debugString.Append(calculoDeEstimuloPorCambioDePose.estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).ToString());
				debugString.Append(" |tipo:");
				debugString.Append(calculoDeEstimuloPorCambioDePose.estimulo.tipoDeEstimuloCambiarPose.ToString());
				debugString.Append("\n");
				ObtenerDialogosUtil.Resultado resultado;
				TipoDePalabraGenerica tipoDePalabraGenerica;
				if (!util.TryActualizarDialogoGenerico(out resultado, out tipoDePalabraGenerica, null, dialogo, calculoDeEstimuloPorCambioDePose, null, new int?(Random.Range(-1, 2)), tipoDeRespuesta, false, false))
				{
					debugString.Append("\t\t\t");
					debugString.Append(resultado.ToString().ToUpperInvariant());
					if (dialogo != null)
					{
						debugString.Append(":");
						string text = dialogo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, (calculoDeEstimuloPorCambioDePose.estimuloBasico.tipo == DireccionDeEstimulo.recibida) ? 1 : 2);
						debugString.Append(text);
					}
					debugString.Append("\n\n");
				}
				else
				{
					flag = true;
					string text2 = dialogo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, (calculoDeEstimuloPorCambioDePose.estimuloBasico.tipo == DireccionDeEstimulo.recibida) ? 1 : 2);
					debugString.Append("\t\t\t");
					debugString.Append("- ");
					debugString.Append(text2);
					debugString.Append("\n\n");
					if (dialogosLimpiosSet.Add(text2))
					{
						dialogosLimpios.Append("- ");
						dialogosLimpios.Append(text2);
						dialogosLimpios.Append("\n\n");
					}
				}
			}
			return flag;
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x0002CAF0 File Offset: 0x0002ACF0
		private static bool AppendCalculoTactil(DialogoInfoGenerico dialogo, ObtenerDialogosUtil util, List<ICalculoDeEstimuloTactil> calculos, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, StringBuilder debugString, StringBuilder dialogosLimpios, HashSet<string> dialogosLimpiosSet)
		{
			bool flag = false;
			foreach (ICalculoDeEstimuloTactil calculoDeEstimuloTactil in calculos)
			{
				debugString.Append("\t\t********Tactiles:");
				debugString.Append(calculoDeEstimuloTactil.emocion.reaccion.ToString());
				debugString.Append(" |estimulante:");
				debugString.Append(calculoDeEstimuloTactil.estimulanteParte.ToString());
				debugString.Append(" |estimulada:");
				debugString.Append(calculoDeEstimuloTactil.estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).ToString());
				debugString.Append(" |tipo:");
				debugString.Append(calculoDeEstimuloTactil.estimulo.tipoDeEstimuloTactil.ToString());
				debugString.Append("\n");
				ObtenerDialogosUtil.Resultado resultado;
				TipoDePalabraGenerica tipoDePalabraGenerica;
				if (!util.TryActualizarDialogoGenerico(out resultado, out tipoDePalabraGenerica, null, dialogo, calculoDeEstimuloTactil, null, new int?(Random.Range(-1, 2)), tipoDeRespuesta, false, false))
				{
					debugString.Append("\t\t\t");
					debugString.Append(resultado.ToString().ToUpperInvariant());
					if (dialogo != null)
					{
						float value = Random.value;
						debugString.Append(":");
						string text = dialogo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, (calculoDeEstimuloTactil.estimuloBasico.tipo == DireccionDeEstimulo.recibida) ? 1 : 2);
						debugString.Append(text);
					}
					debugString.Append("\n\n");
				}
				else
				{
					flag = true;
					float value2 = Random.value;
					string text2 = dialogo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, (calculoDeEstimuloTactil.estimuloBasico.tipo == DireccionDeEstimulo.recibida) ? 1 : 2);
					debugString.Append("\t\t\t");
					debugString.Append("- ");
					debugString.Append(text2);
					debugString.Append("\n\n");
					if (dialogosLimpiosSet.Add(text2))
					{
						dialogosLimpios.Append("- ");
						dialogosLimpios.Append(text2);
						dialogosLimpios.Append("\n\n");
					}
				}
			}
			return flag;
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x0002CD44 File Offset: 0x0002AF44
		private static bool AppendCalculoCoital(int? intensidadEmulada, DialogoInfoGenerico dialogo, ObtenerDialogosUtil util, List<ICalculoDeEstimuloCoitalHole> calculos, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, StringBuilder debugString, StringBuilder dialogosLimpios, HashSet<string> dialogosLimpiosSet)
		{
			bool flag = false;
			foreach (ICalculoDeEstimuloCoitalHole calculoDeEstimuloCoitalHole in calculos)
			{
				debugString.Append("\t\t********Coitales:");
				debugString.Append(calculoDeEstimuloCoitalHole.emocion.reaccion.ToString());
				debugString.Append(" |estimulante:");
				debugString.Append(calculoDeEstimuloCoitalHole.estimulanteParte.ToString());
				debugString.Append(" |estimulada:");
				debugString.Append(calculoDeEstimuloCoitalHole.estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).ToString());
				debugString.Append(" |tipo:");
				debugString.Append(calculoDeEstimuloCoitalHole.estimulo.tipoDeEstimuloCoital.ToString());
				debugString.Append("\n");
				ObtenerDialogosUtil.Resultado resultado;
				TipoDePalabraGenerica tipoDePalabraGenerica;
				if (!util.TryActualizarDialogoGenerico(out resultado, out tipoDePalabraGenerica, null, dialogo, calculoDeEstimuloCoitalHole, null, new int?((intensidadEmulada == null) ? Random.Range(-1, 2) : (intensidadEmulada.Value * (((double)Random.value > 0.5) ? 1 : (-1)))), tipoDeRespuesta, false, false))
				{
					debugString.Append("\t\t\t");
					debugString.Append(resultado.ToString().ToUpperInvariant());
					if (dialogo != null)
					{
						float value = Random.value;
						debugString.Append(":");
						string text = dialogo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, (calculoDeEstimuloCoitalHole.estimuloBasico.tipo == DireccionDeEstimulo.recibida) ? 1 : 2);
						debugString.Append(text);
					}
					debugString.Append("\n\n");
				}
				else
				{
					flag = true;
					float value2 = Random.value;
					string text2 = dialogo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, (calculoDeEstimuloCoitalHole.estimuloBasico.tipo == DireccionDeEstimulo.recibida) ? 1 : 2);
					debugString.Append("\t\t\t");
					debugString.Append("- ");
					debugString.Append(text2);
					debugString.Append("\n\n");
					if (dialogosLimpiosSet.Add(text2))
					{
						dialogosLimpios.Append("- ");
						dialogosLimpios.Append(text2);
						dialogosLimpios.Append("\n\n");
					}
				}
			}
			return flag;
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x0002CFC4 File Offset: 0x0002B1C4
		private static bool AppendCalculoVisual(DialogoInfoGenerico dialogo, ObtenerDialogosUtil util, List<ICalculoDeEstimuloVisual> calculos, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, StringBuilder debugString, StringBuilder dialogosLimpios, HashSet<string> dialogosLimpiosSet)
		{
			bool flag = false;
			foreach (ICalculoDeEstimuloVisual calculoDeEstimuloVisual in calculos)
			{
				debugString.Append("\t\t********Visuales:");
				debugString.Append(calculoDeEstimuloVisual.emocion.reaccion.ToString());
				debugString.Append(" |estimulante:");
				debugString.Append(calculoDeEstimuloVisual.estimulanteParte.ToString());
				debugString.Append(" |estimulada:");
				debugString.Append(calculoDeEstimuloVisual.estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).ToString());
				debugString.Append("\n");
				ObtenerDialogosUtil.Resultado resultado;
				TipoDePalabraGenerica tipoDePalabraGenerica;
				if (!util.TryActualizarDialogoGenerico(out resultado, out tipoDePalabraGenerica, null, dialogo, calculoDeEstimuloVisual, null, new int?(Random.Range(-1, 2)), tipoDeRespuesta, false, false))
				{
					debugString.Append("\t\t\t");
					debugString.Append(resultado.ToString().ToUpperInvariant());
					if (dialogo != null)
					{
						float value = Random.value;
						debugString.Append(":");
						string text = dialogo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, (calculoDeEstimuloVisual.estimuloBasico.tipo == DireccionDeEstimulo.recibida) ? 1 : 2);
						debugString.Append(text);
					}
					debugString.Append("\n\n");
				}
				else
				{
					flag = true;
					float value2 = Random.value;
					string text2 = dialogo.NoMutado(Singleton<ConfiguracionGeneralDeIdioma>.instance.idioma.id, (calculoDeEstimuloVisual.estimuloBasico.tipo == DireccionDeEstimulo.recibida) ? 1 : 2);
					debugString.Append("\t\t\t");
					debugString.Append("- ");
					debugString.Append(text2);
					debugString.Append("\n\n");
					if (dialogosLimpiosSet.Add(text2))
					{
						dialogosLimpios.Append("- ");
						dialogosLimpios.Append(text2);
						dialogosLimpios.Append("\n\n");
					}
				}
			}
			return flag;
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x0002D1EC File Offset: 0x0002B3EC
		public static List<DialogosLocalizadosGenericos> CargarTodosLosMapasDeDialogosSingletones(IReadOnlyList<Singleton> dialogosSingletones)
		{
			List<DialogosLocalizadosGenericos> list = new List<DialogosLocalizadosGenericos>();
			Type listDeEnvolturasType = typeof(IEnumerable<IEnvolturaCondicionalDeHolders>);
			Func<FieldInfo, bool> <>9__2;
			Func<PropertyInfo, bool> <>9__3;
			foreach (IDialogosDePersonalidades dialogosDePersonalidades in (from s in dialogosSingletones
				select s as IDialogosDePersonalidades into d
				where d != null
				select d).ToArray<IDialogosDePersonalidades>())
			{
				IEnumerable<IEnvolturaCondicionalDeHolders> enumerable = null;
				IEnumerable<FieldInfo> fieldsFlattenHierarchy = dialogosDePersonalidades.GetType().GetFieldsFlattenHierarchy(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
				Func<FieldInfo, bool> func;
				if ((func = <>9__2) == null)
				{
					func = (<>9__2 = (FieldInfo f) => listDeEnvolturasType.IsAssignableFrom(f.FieldType));
				}
				FieldInfo fieldInfo = fieldsFlattenHierarchy.FirstOrDefault(func);
				if (fieldInfo != null)
				{
					enumerable = fieldInfo.GetValue(dialogosDePersonalidades) as IEnumerable<IEnvolturaCondicionalDeHolders>;
				}
				else
				{
					IEnumerable<PropertyInfo> propertiesFlattenHierarchy = dialogosDePersonalidades.GetType().GetPropertiesFlattenHierarchy(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
					Func<PropertyInfo, bool> func2;
					if ((func2 = <>9__3) == null)
					{
						func2 = (<>9__3 = (PropertyInfo f) => listDeEnvolturasType.IsAssignableFrom(f.PropertyType));
					}
					PropertyInfo propertyInfo = propertiesFlattenHierarchy.FirstOrDefault(func2);
					if (propertyInfo != null)
					{
						enumerable = propertyInfo.GetValue(dialogosDePersonalidades) as IEnumerable<IEnvolturaCondicionalDeHolders>;
					}
				}
				if (enumerable == null)
				{
					global::UnityEngine.Debug.LogError("singleton de dialogos " + ((Object)dialogosDePersonalidades).name + " no tiene field de " + listDeEnvolturasType.Name, (Object)dialogosDePersonalidades);
				}
				else
				{
					list.AddRange(PrintTESTDialogosGenericos.FindGrupos(enumerable));
				}
			}
			return new HashSet<DialogosLocalizadosGenericos>(list).ToList<DialogosLocalizadosGenericos>();
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x0002D374 File Offset: 0x0002B574
		private static List<DialogosLocalizadosGenericos> FindGrupos(IEnumerable<IEnvolturaCondicionalDeHolders> inputValueCollection)
		{
			List<DialogosLocalizadosGenericos> list = new List<DialogosLocalizadosGenericos>();
			Type gruposType = typeof(IEnumerable<IHolderDeCollecionDeDialogoInfo>);
			Func<FieldInfo, bool> <>9__0;
			Func<PropertyInfo, bool> <>9__1;
			foreach (IEnvolturaCondicionalDeHolders envolturaCondicionalDeHolders in inputValueCollection)
			{
				IEnumerable<IHolderDeCollecionDeDialogoInfo> enumerable = null;
				IEnumerable<FieldInfo> fieldsFlattenHierarchy = envolturaCondicionalDeHolders.GetType().GetFieldsFlattenHierarchy(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
				Func<FieldInfo, bool> func;
				if ((func = <>9__0) == null)
				{
					func = (<>9__0 = (FieldInfo f) => gruposType.IsAssignableFrom(f.FieldType));
				}
				FieldInfo fieldInfo = fieldsFlattenHierarchy.FirstOrDefault(func);
				if (fieldInfo != null)
				{
					enumerable = fieldInfo.GetValue(envolturaCondicionalDeHolders) as IEnumerable<IHolderDeCollecionDeDialogoInfo>;
				}
				else
				{
					IEnumerable<PropertyInfo> propertiesFlattenHierarchy = envolturaCondicionalDeHolders.GetType().GetPropertiesFlattenHierarchy(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
					Func<PropertyInfo, bool> func2;
					if ((func2 = <>9__1) == null)
					{
						func2 = (<>9__1 = (PropertyInfo f) => gruposType.IsAssignableFrom(f.PropertyType));
					}
					PropertyInfo propertyInfo = propertiesFlattenHierarchy.FirstOrDefault(func2);
					if (propertyInfo != null)
					{
						enumerable = propertyInfo.GetValue(envolturaCondicionalDeHolders) as IEnumerable<IHolderDeCollecionDeDialogoInfo>;
					}
				}
				if (enumerable == null)
				{
					global::UnityEngine.Debug.LogError("singleton de dialogos " + ((Object)envolturaCondicionalDeHolders).name + " no tiene field de" + gruposType.Name, (Object)envolturaCondicionalDeHolders);
				}
				else
				{
					list.AddRange(PrintTESTDialogosGenericos.FindCollecciones(enumerable));
				}
			}
			return list;
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x0002D4BC File Offset: 0x0002B6BC
		private static List<DialogosLocalizadosGenericos> FindCollecciones(IEnumerable<IHolderDeCollecionDeDialogoInfo> inputValueCollection)
		{
			List<DialogosLocalizadosGenericos> list = new List<DialogosLocalizadosGenericos>();
			Type colleccionType = typeof(IEnumerable<ListaDeDialogosBase>);
			Func<FieldInfo, bool> <>9__0;
			Func<PropertyInfo, bool> <>9__3;
			foreach (IHolderDeCollecionDeDialogoInfo holderDeCollecionDeDialogoInfo in inputValueCollection)
			{
				IEnumerable<ListaDeDialogosBase> enumerable = null;
				IEnumerable<FieldInfo> fieldsFlattenHierarchy = holderDeCollecionDeDialogoInfo.GetType().GetFieldsFlattenHierarchy(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
				Func<FieldInfo, bool> func;
				if ((func = <>9__0) == null)
				{
					func = (<>9__0 = (FieldInfo f) => colleccionType.IsAssignableFrom(f.FieldType));
				}
				FieldInfo fieldInfo = fieldsFlattenHierarchy.FirstOrDefault(func);
				if (fieldInfo != null)
				{
					enumerable = fieldInfo.GetValue(holderDeCollecionDeDialogoInfo) as IEnumerable<ListaDeDialogosBase>;
				}
				else
				{
					IEnumerable<PropertyInfo> propertiesFlattenHierarchy = holderDeCollecionDeDialogoInfo.GetType().GetPropertiesFlattenHierarchy(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
					Func<PropertyInfo, bool> func2;
					if ((func2 = <>9__3) == null)
					{
						func2 = (<>9__3 = (PropertyInfo f) => colleccionType.IsAssignableFrom(f.PropertyType));
					}
					PropertyInfo propertyInfo = propertiesFlattenHierarchy.FirstOrDefault(func2);
					if (propertyInfo != null)
					{
						enumerable = propertyInfo.GetValue(holderDeCollecionDeDialogoInfo) as IEnumerable<ListaDeDialogosBase>;
					}
				}
				if (enumerable == null)
				{
					global::UnityEngine.Debug.LogError("singleton de dialogos " + ((Object)holderDeCollecionDeDialogoInfo).name + " no tiene field de" + colleccionType.Name, (Object)holderDeCollecionDeDialogoInfo);
				}
				else
				{
					list.AddRange(from c in enumerable
						select c as DialogosLocalizadosGenericos into d
						where d != null
						select d);
				}
			}
			return list;
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x0002D654 File Offset: 0x0002B854
		public static List<DialogosLocalizadosGenericos> CargarTodosLosMapas()
		{
			if (Application.isPlaying)
			{
				throw new InvalidOperationException();
			}
			if (!Application.isEditor)
			{
				throw new InvalidOperationException();
			}
			return new List<DialogosLocalizadosGenericos>();
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x0002D654 File Offset: 0x0002B854
		public static List<DialogosLocalizadosGenericos> CargarTodosLosMapasEnCarpeta()
		{
			if (Application.isPlaying)
			{
				throw new InvalidOperationException();
			}
			if (!Application.isEditor)
			{
				throw new InvalidOperationException();
			}
			return new List<DialogosLocalizadosGenericos>();
		}

		// Token: 0x040006A3 RID: 1699
		public string pathDebug = "DEBUG_PRINT/DialogosPrintedDEBUG.txt";

		// Token: 0x040006A4 RID: 1700
		public string pathLimpio = "DEBUG_PRINT/DialogosPrinted.txt";

		// Token: 0x040006A5 RID: 1701
		public string pathAlwaysBad = "DEBUG_PRINT/DialogosSiempreErrados.txt";

		// Token: 0x040006A6 RID: 1702
		public FemaleChar target;

		// Token: 0x040006A7 RID: 1703
		public string buscar;

		// Token: 0x040006A8 RID: 1704
		public string reemplazar;

		// Token: 0x040006A9 RID: 1705
		[Header("Printing")]
		public bool usarVisuales = true;

		// Token: 0x040006AA RID: 1706
		public bool usarTactiles = true;

		// Token: 0x040006AB RID: 1707
		public bool usarCoitales = true;

		// Token: 0x040006AC RID: 1708
		public bool usarPeticionExponer = true;

		// Token: 0x040006AD RID: 1709
		public bool usarPeticionMover = true;

		// Token: 0x040006AE RID: 1710
		public bool usarExponer = true;

		// Token: 0x040006AF RID: 1711
		public bool usarManipular = true;

		// Token: 0x040006B0 RID: 1712
		[Header("Emulacion")]
		public bool emularEnAutoInteraccionCoital;

		// Token: 0x040006B1 RID: 1713
		public bool sobreEscirbirIntensidadCoital;

		// Token: 0x040006B2 RID: 1714
		public int intensidadCoitalSobreescrita;

		// Token: 0x040006B3 RID: 1715
		[Header("Otros")]
		public bool testSimpreContextoErradoOrRedundante;

		// Token: 0x040006B4 RID: 1716
		[Space]
		public List<Singleton> incluirMapasEnDialogosSingletones = new List<Singleton>();

		// Token: 0x040006B5 RID: 1717
		public List<DialogosLocalizadosGenericos> mapas = new List<DialogosLocalizadosGenericos>();

		// Token: 0x040006B6 RID: 1718
		[TupleElementNames(new string[] { "mapa", "dialogo" })]
		private List<ValueTuple<DialogosLocalizadosGenericos, DialogoInfoGenerico>> m_siempreInvalidos = new List<ValueTuple<DialogosLocalizadosGenericos, DialogoInfoGenerico>>();

		// Token: 0x02000182 RID: 386
		public class DebugClases
		{
			// Token: 0x06000868 RID: 2152 RVA: 0x0002D700 File Offset: 0x0002B900
			public void Init(FemaleChar heroina)
			{
				Placer componentInChildren = heroina.GetComponentInChildren<Placer>();
				Rage componentInChildren2 = heroina.GetComponentInChildren<Rage>();
				Dolor componentInChildren3 = heroina.GetComponentInChildren<Dolor>();
				Decepcion componentInChildren4 = heroina.GetComponentInChildren<Decepcion>();
				ConsentToHero componentInChildren5 = heroina.GetComponentInChildren<ConsentToHero>();
				Arousal componentInChildren6 = heroina.GetComponentInChildren<Arousal>();
				Fear componentInChildren7 = heroina.GetComponentInChildren<Fear>();
				List<Emocion> list = new List<Emocion> { componentInChildren, componentInChildren2, componentInChildren3, componentInChildren4, componentInChildren5, componentInChildren6, componentInChildren7 };
				List<ParteQuePuedeEstimular> list2 = new List<ParteQuePuedeEstimular>();
				list2.Add(ParteQuePuedeEstimular.manos);
				list2.Add(ParteQuePuedeEstimular.boca);
				list2.Add(ParteQuePuedeEstimular.lengua);
				list2.Add(ParteQuePuedeEstimular.pene);
				list2.Add(ParteQuePuedeEstimular.semen);
				list2.Add(ParteQuePuedeEstimular.torzo);
				list2.Add(ParteQuePuedeEstimular.piernas);
				list2.Add(ParteQuePuedeEstimular.propSexToy);
				List<ParteQuePuedeEstimular> list3 = new List<ParteQuePuedeEstimular>
				{
					ParteQuePuedeEstimular.ojos,
					ParteQuePuedeEstimular.propSexToy
				};
				List<ParteDelCuerpoHumano> list4 = new List<ParteDelCuerpoHumano>
				{
					ParteDelCuerpoHumano.ano,
					ParteDelCuerpoHumano.vag,
					ParteDelCuerpoHumano.bocaInterno
				};
				List<ParteQuePuedeEstimular> list5 = new List<ParteQuePuedeEstimular>
				{
					ParteQuePuedeEstimular.pene,
					ParteQuePuedeEstimular.dedo,
					ParteQuePuedeEstimular.propSexToy
				};
				foreach (ParteQuePuedeEstimular parteQuePuedeEstimular in list2)
				{
					if (parteQuePuedeEstimular != ParteQuePuedeEstimular.None && parteQuePuedeEstimular != ParteQuePuedeEstimular.noEspecificada)
					{
						foreach (Emocion emocion in list)
						{
							for (int i = 0; i < 3; i++)
							{
								bool flag = i == 2;
								ParteDelCuerpoHumano parteDelCuerpoHumano = (i.IsLastIndex(3) ? ParteDelCuerpoHumanoHelper.holes.RandomItemReadOnly<ParteDelCuerpoHumano>() : ((ParteDelCuerpoHumano)typeof(ParteDelCuerpoHumano).GetEnumRandom()));
								EstimuloTactil estimuloTactil2;
								EstimuloTactil estimuloTactil = (estimuloTactil2 = new EstimuloTactil());
								((IInteracionEstimulanteReutilizable)estimuloTactil2).GenerateNewID();
								estimuloTactil2.AddParteEstimulada(parteDelCuerpoHumano);
								estimuloTactil2.tipo = DireccionDeEstimulo.recibida;
								estimuloTactil2.tipoDeEstimulo = TipoDeEstimulo.tactil;
								estimuloTactil2.EstimuloSoloUsaPrioridadesFixed();
								estimuloTactil2.SetTipoDeEstimuloTactil(estimuloTactil2.ObtenerTipoDeEstimuloTactil(PrioridadDeParteDelCuerpoHumanoContexto.@fixed, parteQuePuedeEstimular, flag));
								PrintTESTDialogosGenericos.TatilDebug tatilDebug = new PrintTESTDialogosGenericos.TatilDebug(emocion, parteQuePuedeEstimular, estimuloTactil2, ParteQuePuedeEstimular.None, null);
								this.tactilesRecibidas.Add(tatilDebug);
								ParteDelCuerpoHumano parteDelCuerpoHumano2 = ((Random.value > 0.75f) ? ParteDelCuerpoHumano.pene : parteQuePuedeEstimular.Switch());
								ParteQuePuedeEstimular parteQuePuedeEstimular2 = ((Random.value > 0.5f) ? ParteQuePuedeEstimular.manos : estimuloTactil.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).Switch());
								EstimuloTactil estimuloTactil3 = new EstimuloTactil();
								((IInteracionEstimulanteReutilizable)estimuloTactil3).GenerateNewID();
								estimuloTactil.CopiarA(estimuloTactil3, false);
								EstimuloTactil estimuloTactil4 = new EstimuloTactil();
								estimuloTactil4.AddParteEstimulada(parteDelCuerpoHumano2);
								estimuloTactil4.tipo = DireccionDeEstimulo.dada;
								estimuloTactil4.tipoDeEstimulo = TipoDeEstimulo.tactil;
								estimuloTactil4.EstimuloSoloUsaPrioridadesFixed();
								estimuloTactil4.SetTipoDeEstimuloTactil(estimuloTactil4.ObtenerTipoDeEstimuloTactil(PrioridadDeParteDelCuerpoHumanoContexto.@fixed, parteQuePuedeEstimular, flag));
								estimuloTactil4.SetTipoDeEstimuloTactil(parteQuePuedeEstimular2.ObtenerTipoDeEstimuloTactil(parteDelCuerpoHumano2));
								((IInteracionEstimulanteReutilizable)estimuloTactil4).GenerateNewID();
								((IInteracionEstimulanteInversible)estimuloTactil4).SetAsInvertedCopy(estimuloTactil3);
								PrintTESTDialogosGenericos.TatilDebug tatilDebug2 = new PrintTESTDialogosGenericos.TatilDebug(emocion, parteQuePuedeEstimular, estimuloTactil3, parteQuePuedeEstimular2, estimuloTactil4);
								this.tactilesDadas.Add(tatilDebug2);
							}
						}
					}
				}
				foreach (ParteQuePuedeEstimular parteQuePuedeEstimular3 in list3)
				{
					foreach (Emocion emocion2 in list)
					{
						for (int j = 0; j < 3; j++)
						{
							ParteDelCuerpoHumano parteDelCuerpoHumano3 = (j.IsLastIndex(3) ? ParteDelCuerpoHumanoHelper.holes.RandomItemReadOnly<ParteDelCuerpoHumano>() : ((ParteDelCuerpoHumano)typeof(ParteDelCuerpoHumano).GetEnumRandom()));
							EstimuloVisual estimuloVisual2;
							EstimuloVisual estimuloVisual = (estimuloVisual2 = new EstimuloVisual());
							((IInteracionEstimulanteReutilizable)estimuloVisual2).GenerateNewID();
							estimuloVisual2.AddParteEstimulada(parteDelCuerpoHumano3);
							estimuloVisual2.tipo = DireccionDeEstimulo.recibida;
							estimuloVisual2.tipoDeEstimulo = TipoDeEstimulo.visual;
							estimuloVisual2.EstimuloSoloUsaPrioridadesFixed();
							estimuloVisual2.SetTipoDeEstimuloVisual(parteQuePuedeEstimular3.ObtenerTipoDeEstimuloVisual());
							PrintTESTDialogosGenericos.VisualDebug visualDebug = new PrintTESTDialogosGenericos.VisualDebug(emocion2, parteQuePuedeEstimular3, estimuloVisual2, ParteQuePuedeEstimular.None, null);
							this.visualRecibidas.Add(visualDebug);
							ParteDelCuerpoHumano parteDelCuerpoHumano4 = parteQuePuedeEstimular3.Switch();
							EstimuloVisual estimuloVisual3 = new EstimuloVisual();
							((IInteracionEstimulanteReutilizable)estimuloVisual3).GenerateNewID();
							estimuloVisual.CopiarA(estimuloVisual3, false);
							EstimuloVisual estimuloVisual4 = new EstimuloVisual();
							estimuloVisual4.AddParteEstimulada(parteDelCuerpoHumano4);
							estimuloVisual4.tipo = DireccionDeEstimulo.dada;
							estimuloVisual4.tipoDeEstimulo = TipoDeEstimulo.visual;
							estimuloVisual4.EstimuloSoloUsaPrioridadesFixed();
							estimuloVisual4.SetTipoDeEstimuloVisual(parteQuePuedeEstimular3.ObtenerTipoDeEstimuloVisual());
							((IInteracionEstimulanteReutilizable)estimuloVisual4).GenerateNewID();
							((IInteracionEstimulanteInversible)estimuloVisual4).SetAsInvertedCopy(estimuloVisual3);
							PrintTESTDialogosGenericos.VisualDebug visualDebug2 = new PrintTESTDialogosGenericos.VisualDebug(emocion2, parteQuePuedeEstimular3, estimuloVisual3, estimuloVisual.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).Switch(), estimuloVisual4);
							this.visualDadas.Add(visualDebug2);
						}
					}
				}
				foreach (ParteQuePuedeEstimular parteQuePuedeEstimular4 in list5)
				{
					foreach (Emocion emocion3 in list)
					{
						for (int k = 0; k < list4.Count; k++)
						{
							ParteDelCuerpoHumano parteDelCuerpoHumano5 = (ParteDelCuerpoHumano)typeof(ParteDelCuerpoHumano).GetEnumRandom();
							EstimuloPenetrante estimuloPenetrante2;
							EstimuloPenetrante estimuloPenetrante = (estimuloPenetrante2 = new EstimuloPenetrante());
							((IInteracionEstimulanteReutilizable)estimuloPenetrante2).GenerateNewID();
							estimuloPenetrante2.AddParteEstimulada(parteDelCuerpoHumano5);
							estimuloPenetrante2.tipo = DireccionDeEstimulo.recibida;
							estimuloPenetrante2.tipoDeEstimulo = TipoDeEstimulo.coital;
							estimuloPenetrante2.EstimuloSoloUsaPrioridadesFixed();
							estimuloPenetrante2.tipoDeEstimuloCoital = parteQuePuedeEstimular4.ObtenerTipoDeEstimuloCoital();
							PrintTESTDialogosGenericos.CoitalDebug coitalDebug = new PrintTESTDialogosGenericos.CoitalDebug(emocion3, parteQuePuedeEstimular4, estimuloPenetrante2, ParteQuePuedeEstimular.None, null);
							this.coitalRecibidas.Add(coitalDebug);
							ParteDelCuerpoHumano parteDelCuerpoHumano6 = parteQuePuedeEstimular4.Switch();
							EstimuloPenetrante estimuloPenetrante3 = new EstimuloPenetrante();
							((IInteracionEstimulanteReutilizable)estimuloPenetrante3).GenerateNewID();
							estimuloPenetrante.CopiarA(estimuloPenetrante3, false);
							EstimuloPenetrante estimuloPenetrante4 = new EstimuloPenetrante();
							estimuloPenetrante4.AddParteEstimulada(parteDelCuerpoHumano6);
							estimuloPenetrante4.tipo = DireccionDeEstimulo.dada;
							estimuloPenetrante4.tipoDeEstimulo = TipoDeEstimulo.coital;
							estimuloPenetrante4.EstimuloSoloUsaPrioridadesFixed();
							estimuloPenetrante4.tipoDeEstimuloCoital = parteQuePuedeEstimular4.ObtenerTipoDeEstimuloCoital();
							((IInteracionEstimulanteReutilizable)estimuloPenetrante4).GenerateNewID();
							((IInteracionEstimulanteInversible)estimuloPenetrante4).SetAsInvertedCopy(estimuloPenetrante3);
							PrintTESTDialogosGenericos.CoitalDebug coitalDebug2 = new PrintTESTDialogosGenericos.CoitalDebug(emocion3, parteQuePuedeEstimular4, estimuloPenetrante3, estimuloPenetrante.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).Switch(), estimuloPenetrante4);
							this.coitalDadas.Add(coitalDebug2);
						}
					}
				}
				foreach (Emocion emocion4 in list)
				{
					for (int l = 0; l < 3; l++)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano7 = (l.IsLastIndex(3) ? ParteDelCuerpoHumanoHelper.holes.RandomItemReadOnly<ParteDelCuerpoHumano>() : ((ParteDelCuerpoHumano)typeof(ParteDelCuerpoHumano).GetEnumRandom()));
						EstimuloPorCambiarPose estimuloPorCambiarPose;
						InteracionEstimulanteBasica interacionEstimulanteBasica = (estimuloPorCambiarPose = new EstimuloPorCambiarPose());
						((IInteracionEstimulanteReutilizable)estimuloPorCambiarPose).GenerateNewID();
						estimuloPorCambiarPose.AddParteEstimulada(parteDelCuerpoHumano7);
						estimuloPorCambiarPose.tipo = DireccionDeEstimulo.recibida;
						estimuloPorCambiarPose.tipoDeEstimulo = TipoDeEstimulo.peticionEjecucionDePose;
						estimuloPorCambiarPose.EstimuloSoloUsaPrioridadesFixed();
						PrintTESTDialogosGenericos.PeticionExponerDebug peticionExponerDebug = new PrintTESTDialogosGenericos.PeticionExponerDebug(emocion4, estimuloPorCambiarPose, null);
						this.peticionExponerRecibidas.Add(peticionExponerDebug);
						ParteDelCuerpoHumano parteDelCuerpoHumano8 = ParteQuePuedeEstimular.boca.Switch();
						EstimuloPorCambiarPose estimuloPorCambiarPose2 = new EstimuloPorCambiarPose();
						((IInteracionEstimulanteReutilizable)estimuloPorCambiarPose2).GenerateNewID();
						interacionEstimulanteBasica.CopiarA(estimuloPorCambiarPose2, false);
						EstimuloPorCambiarPose estimuloPorCambiarPose3 = new EstimuloPorCambiarPose();
						estimuloPorCambiarPose3.AddParteEstimulada(parteDelCuerpoHumano8);
						estimuloPorCambiarPose3.tipo = DireccionDeEstimulo.dada;
						estimuloPorCambiarPose3.tipoDeEstimulo = TipoDeEstimulo.peticionEjecucionDePose;
						estimuloPorCambiarPose3.EstimuloSoloUsaPrioridadesFixed();
						((IInteracionEstimulanteReutilizable)estimuloPorCambiarPose3).GenerateNewID();
						((IInteracionEstimulanteInversible)estimuloPorCambiarPose3).SetAsInvertedCopy(estimuloPorCambiarPose2);
						PrintTESTDialogosGenericos.PeticionExponerDebug peticionExponerDebug2 = new PrintTESTDialogosGenericos.PeticionExponerDebug(emocion4, estimuloPorCambiarPose2, estimuloPorCambiarPose3);
						this.peticionExponerDadas.Add(peticionExponerDebug2);
					}
				}
				foreach (Emocion emocion5 in list)
				{
					for (int m = 0; m < 3; m++)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano9 = (m.IsLastIndex(3) ? ParteDelCuerpoHumanoHelper.holes.RandomItemReadOnly<ParteDelCuerpoHumano>() : ((ParteDelCuerpoHumano)typeof(ParteDelCuerpoHumano).GetEnumRandom()));
						EstimuloPorCambiarPose estimuloPorCambiarPose4;
						InteracionEstimulanteBasica interacionEstimulanteBasica2 = (estimuloPorCambiarPose4 = new EstimuloPorCambiarPose());
						((IInteracionEstimulanteReutilizable)estimuloPorCambiarPose4).GenerateNewID();
						estimuloPorCambiarPose4.AddParteEstimulada(parteDelCuerpoHumano9);
						estimuloPorCambiarPose4.tipo = DireccionDeEstimulo.recibida;
						estimuloPorCambiarPose4.tipoDeEstimulo = TipoDeEstimulo.ejecucionDePose;
						estimuloPorCambiarPose4.EstimuloSoloUsaPrioridadesFixed();
						PrintTESTDialogosGenericos.ExponerDebug exponerDebug = new PrintTESTDialogosGenericos.ExponerDebug(emocion5, estimuloPorCambiarPose4, null);
						this.exponerRecibidas.Add(exponerDebug);
						ParteDelCuerpoHumano parteDelCuerpoHumano10 = ParteQuePuedeEstimular.manos.Switch();
						EstimuloPorCambiarPose estimuloPorCambiarPose5 = new EstimuloPorCambiarPose();
						((IInteracionEstimulanteReutilizable)estimuloPorCambiarPose5).GenerateNewID();
						interacionEstimulanteBasica2.CopiarA(estimuloPorCambiarPose5, false);
						EstimuloPorCambiarPose estimuloPorCambiarPose6 = new EstimuloPorCambiarPose();
						estimuloPorCambiarPose6.AddParteEstimulada(parteDelCuerpoHumano10);
						estimuloPorCambiarPose6.tipo = DireccionDeEstimulo.dada;
						estimuloPorCambiarPose6.tipoDeEstimulo = TipoDeEstimulo.ejecucionDePose;
						estimuloPorCambiarPose6.EstimuloSoloUsaPrioridadesFixed();
						((IInteracionEstimulanteReutilizable)estimuloPorCambiarPose6).GenerateNewID();
						((IInteracionEstimulanteInversible)estimuloPorCambiarPose6).SetAsInvertedCopy(estimuloPorCambiarPose5);
						PrintTESTDialogosGenericos.ExponerDebug exponerDebug2 = new PrintTESTDialogosGenericos.ExponerDebug(emocion5, estimuloPorCambiarPose5, estimuloPorCambiarPose6);
						this.exponerDadas.Add(exponerDebug2);
					}
				}
				foreach (Emocion emocion6 in list)
				{
					for (int n = 0; n < 3; n++)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano11 = (n.IsLastIndex(3) ? ParteDelCuerpoHumanoHelper.holes.RandomItemReadOnly<ParteDelCuerpoHumano>() : ((ParteDelCuerpoHumano)typeof(ParteDelCuerpoHumano).GetEnumRandom()));
						EstimuloPorManipulacionDeBone estimuloPorManipulacionDeBone;
						InteracionEstimulanteBasica interacionEstimulanteBasica3 = (estimuloPorManipulacionDeBone = new EstimuloPorManipulacionDeBone());
						((IInteracionEstimulanteReutilizable)estimuloPorManipulacionDeBone).GenerateNewID();
						estimuloPorManipulacionDeBone.AddParteEstimulada(parteDelCuerpoHumano11);
						estimuloPorManipulacionDeBone.tipo = DireccionDeEstimulo.recibida;
						estimuloPorManipulacionDeBone.tipoDeEstimulo = TipoDeEstimulo.guiandoBone;
						estimuloPorManipulacionDeBone.EstimuloSoloUsaPrioridadesFixed();
						PrintTESTDialogosGenericos.PeticionMoverDebug peticionMoverDebug = new PrintTESTDialogosGenericos.PeticionMoverDebug(emocion6, estimuloPorManipulacionDeBone, null);
						this.peticionMoverRecibidas.Add(peticionMoverDebug);
						ParteDelCuerpoHumano parteDelCuerpoHumano12 = ParteQuePuedeEstimular.boca.Switch();
						EstimuloPorManipulacionDeBone estimuloPorManipulacionDeBone2 = new EstimuloPorManipulacionDeBone();
						((IInteracionEstimulanteReutilizable)estimuloPorManipulacionDeBone2).GenerateNewID();
						interacionEstimulanteBasica3.CopiarA(estimuloPorManipulacionDeBone2, false);
						EstimuloPorManipulacionDeBone estimuloPorManipulacionDeBone3 = new EstimuloPorManipulacionDeBone();
						estimuloPorManipulacionDeBone3.AddParteEstimulada(parteDelCuerpoHumano12);
						estimuloPorManipulacionDeBone3.tipo = DireccionDeEstimulo.dada;
						estimuloPorManipulacionDeBone3.tipoDeEstimulo = TipoDeEstimulo.guiandoBone;
						estimuloPorManipulacionDeBone3.EstimuloSoloUsaPrioridadesFixed();
						((IInteracionEstimulanteReutilizable)estimuloPorManipulacionDeBone3).GenerateNewID();
						((IInteracionEstimulanteInversible)estimuloPorManipulacionDeBone3).SetAsInvertedCopy(estimuloPorManipulacionDeBone2);
						PrintTESTDialogosGenericos.PeticionMoverDebug peticionMoverDebug2 = new PrintTESTDialogosGenericos.PeticionMoverDebug(emocion6, estimuloPorManipulacionDeBone2, estimuloPorManipulacionDeBone3);
						this.peticionMoverDadas.Add(peticionMoverDebug2);
					}
				}
				foreach (Emocion emocion7 in list)
				{
					for (int num = 0; num < 3; num++)
					{
						ParteDelCuerpoHumano parteDelCuerpoHumano13 = (num.IsLastIndex(3) ? ParteDelCuerpoHumanoHelper.holes.RandomItemReadOnly<ParteDelCuerpoHumano>() : ((ParteDelCuerpoHumano)typeof(ParteDelCuerpoHumano).GetEnumRandom()));
						EstimuloPorManipulacionDeBone estimuloPorManipulacionDeBone4;
						InteracionEstimulanteBasica interacionEstimulanteBasica4 = (estimuloPorManipulacionDeBone4 = new EstimuloPorManipulacionDeBone());
						((IInteracionEstimulanteReutilizable)estimuloPorManipulacionDeBone4).GenerateNewID();
						estimuloPorManipulacionDeBone4.AddParteEstimulada(parteDelCuerpoHumano13);
						estimuloPorManipulacionDeBone4.tipo = DireccionDeEstimulo.recibida;
						estimuloPorManipulacionDeBone4.tipoDeEstimulo = TipoDeEstimulo.manipulandoBone;
						estimuloPorManipulacionDeBone4.EstimuloSoloUsaPrioridadesFixed();
						PrintTESTDialogosGenericos.ManipularDebug manipularDebug = new PrintTESTDialogosGenericos.ManipularDebug(emocion7, estimuloPorManipulacionDeBone4, null);
						this.manipularRecibidas.Add(manipularDebug);
						ParteDelCuerpoHumano parteDelCuerpoHumano14 = ParteQuePuedeEstimular.manos.Switch();
						EstimuloPorManipulacionDeBone estimuloPorManipulacionDeBone5 = new EstimuloPorManipulacionDeBone();
						interacionEstimulanteBasica4.CopiarA(estimuloPorManipulacionDeBone5, false);
						EstimuloPorManipulacionDeBone estimuloPorManipulacionDeBone6 = new EstimuloPorManipulacionDeBone();
						((IInteracionEstimulanteReutilizable)estimuloPorManipulacionDeBone5).GenerateNewID();
						estimuloPorManipulacionDeBone6.AddParteEstimulada(parteDelCuerpoHumano14);
						estimuloPorManipulacionDeBone6.tipo = DireccionDeEstimulo.dada;
						estimuloPorManipulacionDeBone6.tipoDeEstimulo = TipoDeEstimulo.manipulandoBone;
						estimuloPorManipulacionDeBone6.EstimuloSoloUsaPrioridadesFixed();
						((IInteracionEstimulanteReutilizable)estimuloPorManipulacionDeBone6).GenerateNewID();
						((IInteracionEstimulanteInversible)estimuloPorManipulacionDeBone6).SetAsInvertedCopy(estimuloPorManipulacionDeBone5);
						PrintTESTDialogosGenericos.ManipularDebug manipularDebug2 = new PrintTESTDialogosGenericos.ManipularDebug(emocion7, estimuloPorManipulacionDeBone5, estimuloPorManipulacionDeBone6);
						this.manipularDadas.Add(manipularDebug2);
					}
				}
			}

			// Token: 0x040006B7 RID: 1719
			public List<ICalculoDeEstimuloTactil> tactilesRecibidas = new List<ICalculoDeEstimuloTactil>();

			// Token: 0x040006B8 RID: 1720
			public List<ICalculoDeEstimuloTactil> tactilesDadas = new List<ICalculoDeEstimuloTactil>();

			// Token: 0x040006B9 RID: 1721
			public List<ICalculoDeEstimuloVisual> visualRecibidas = new List<ICalculoDeEstimuloVisual>();

			// Token: 0x040006BA RID: 1722
			public List<ICalculoDeEstimuloVisual> visualDadas = new List<ICalculoDeEstimuloVisual>();

			// Token: 0x040006BB RID: 1723
			public List<ICalculoDeEstimuloCoitalHole> coitalRecibidas = new List<ICalculoDeEstimuloCoitalHole>();

			// Token: 0x040006BC RID: 1724
			public List<ICalculoDeEstimuloCoitalHole> coitalDadas = new List<ICalculoDeEstimuloCoitalHole>();

			// Token: 0x040006BD RID: 1725
			public List<ICalculoDeEstimuloPorCambioDePose> peticionExponerRecibidas = new List<ICalculoDeEstimuloPorCambioDePose>();

			// Token: 0x040006BE RID: 1726
			public List<ICalculoDeEstimuloPorCambioDePose> peticionExponerDadas = new List<ICalculoDeEstimuloPorCambioDePose>();

			// Token: 0x040006BF RID: 1727
			public List<ICalculoDeEstimuloPorMovimientoDeBones> peticionMoverRecibidas = new List<ICalculoDeEstimuloPorMovimientoDeBones>();

			// Token: 0x040006C0 RID: 1728
			public List<ICalculoDeEstimuloPorMovimientoDeBones> peticionMoverDadas = new List<ICalculoDeEstimuloPorMovimientoDeBones>();

			// Token: 0x040006C1 RID: 1729
			public List<ICalculoDeEstimuloPorCambioDePose> exponerRecibidas = new List<ICalculoDeEstimuloPorCambioDePose>();

			// Token: 0x040006C2 RID: 1730
			public List<ICalculoDeEstimuloPorCambioDePose> exponerDadas = new List<ICalculoDeEstimuloPorCambioDePose>();

			// Token: 0x040006C3 RID: 1731
			public List<ICalculoDeEstimuloPorMovimientoDeBones> manipularRecibidas = new List<ICalculoDeEstimuloPorMovimientoDeBones>();

			// Token: 0x040006C4 RID: 1732
			public List<ICalculoDeEstimuloPorMovimientoDeBones> manipularDadas = new List<ICalculoDeEstimuloPorMovimientoDeBones>();
		}

		// Token: 0x02000183 RID: 387
		public abstract class Debug : IClearable
		{
			// Token: 0x0600086A RID: 2154 RVA: 0x0002E385 File Offset: 0x0002C585
			public Debug(Emocion emo)
			{
				this.emocion = emo;
			}

			// Token: 0x170001B0 RID: 432
			// (get) Token: 0x0600086B RID: 2155 RVA: 0x0002E394 File Offset: 0x0002C594
			// (set) Token: 0x0600086C RID: 2156 RVA: 0x0002E39C File Offset: 0x0002C59C
			public Emocion emocion { get; set; }

			// Token: 0x0600086D RID: 2157 RVA: 0x00023F85 File Offset: 0x00022185
			public void Clear()
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x02000184 RID: 388
		public class TatilDebug : PrintTESTDialogosGenericos.Debug, ICalculoDeEstimuloTactil, ICalculoDeEstimulo<EstimuloTactil>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante
		{
			// Token: 0x170001B1 RID: 433
			// (get) Token: 0x0600086E RID: 2158 RVA: 0x0002E3A8 File Offset: 0x0002C5A8
			public float estimuloGeneradoEnFrame
			{
				get
				{
					return this.estado.estimulacionGeneradaEnFrame;
				}
			}

			// Token: 0x170001B2 RID: 434
			// (get) Token: 0x0600086F RID: 2159 RVA: 0x000066D6 File Offset: 0x000048D6
			public int cantidadDeEstados
			{
				get
				{
					return 1;
				}
			}

			// Token: 0x170001B3 RID: 435
			// (get) Token: 0x06000870 RID: 2160 RVA: 0x000066D6 File Offset: 0x000048D6
			public bool esSingleEstado
			{
				get
				{
					return true;
				}
			}

			// Token: 0x06000871 RID: 2161 RVA: 0x0002E3C3 File Offset: 0x0002C5C3
			public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
			{
				estado = default(UmbralBasico.Estado);
				if (index == 0)
				{
					estado = this.estado;
				}
			}

			// Token: 0x06000872 RID: 2162 RVA: 0x00002BEA File Offset: 0x00000DEA
			public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
			{
			}

			// Token: 0x06000873 RID: 2163 RVA: 0x0002E3DB File Offset: 0x0002C5DB
			public void GetSingleEstado(out UmbralBasico.Estado estado)
			{
				estado = this.estado;
			}

			// Token: 0x06000874 RID: 2164 RVA: 0x0002E3DB File Offset: 0x0002C5DB
			public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
			{
				estado = this.estado;
			}

			// Token: 0x170001B4 RID: 436
			// (get) Token: 0x06000875 RID: 2165 RVA: 0x0002E3E9 File Offset: 0x0002C5E9
			// (set) Token: 0x06000876 RID: 2166 RVA: 0x0002E3F1 File Offset: 0x0002C5F1
			public bool causoMaxValue { get; set; }

			// Token: 0x06000877 RID: 2167 RVA: 0x00023F85 File Offset: 0x00022185
			public void SetEstimuloInstance(EstimuloTactil instance, EstimuloTactil inv)
			{
				throw new NotImplementedException();
			}

			// Token: 0x06000878 RID: 2168 RVA: 0x0002E3FA File Offset: 0x0002C5FA
			public TatilDebug(Emocion emo, ParteQuePuedeEstimular estimulante, EstimuloTactil estimulo, ParteQuePuedeEstimular estimulanteInv, EstimuloTactil estimuloInv)
				: base(emo)
			{
				this.estimulanteParteInvertido = estimulanteInv;
				this.estimulanteParte = estimulante;
				this.estimulo = estimulo;
				this.estimuloInvertido = estimuloInv;
			}

			// Token: 0x170001B5 RID: 437
			// (get) Token: 0x06000879 RID: 2169 RVA: 0x0002E424 File Offset: 0x0002C624
			public UmbralBasico.Estado estado
			{
				get
				{
					UmbralBasico.Estado estado = new UmbralBasico.Estado
					{
						offsetMod = 1f,
						rango = UmbralBasico.RangoEstado.enRango,
						spotScore = SpotScore.fuera,
						spotRango = UmbralBasico.RangoEstado.porDebajo
					};
					estado.SetEstimulacionGeneradaEnFrame(1f);
					estado.SetEstimulacionGeneradaTotal(1f);
					return estado;
				}
			}

			// Token: 0x170001B6 RID: 438
			// (get) Token: 0x0600087A RID: 2170 RVA: 0x0002E478 File Offset: 0x0002C678
			// (set) Token: 0x0600087B RID: 2171 RVA: 0x0002E480 File Offset: 0x0002C680
			public ParteQuePuedeEstimular estimulanteParte { get; set; }

			// Token: 0x170001B7 RID: 439
			// (get) Token: 0x0600087C RID: 2172 RVA: 0x0002E489 File Offset: 0x0002C689
			// (set) Token: 0x0600087D RID: 2173 RVA: 0x0002E491 File Offset: 0x0002C691
			public ParteQuePuedeEstimular estimulanteParteInvertido { get; set; }

			// Token: 0x170001B8 RID: 440
			// (get) Token: 0x0600087E RID: 2174 RVA: 0x0002E49A File Offset: 0x0002C69A
			// (set) Token: 0x0600087F RID: 2175 RVA: 0x0002E4A2 File Offset: 0x0002C6A2
			public EstimuloTactil estimulo { get; set; }

			// Token: 0x170001B9 RID: 441
			// (get) Token: 0x06000880 RID: 2176 RVA: 0x0002E4AB File Offset: 0x0002C6AB
			public InteracionEstimulanteBasica estimuloBasico
			{
				get
				{
					return this.estimulo;
				}
			}

			// Token: 0x170001BA RID: 442
			// (get) Token: 0x06000881 RID: 2177 RVA: 0x0002E4B3 File Offset: 0x0002C6B3
			// (set) Token: 0x06000882 RID: 2178 RVA: 0x0002E4BB File Offset: 0x0002C6BB
			public EstimuloTactil estimuloInvertido { get; set; }

			// Token: 0x170001BB RID: 443
			// (get) Token: 0x06000883 RID: 2179 RVA: 0x0002E4C4 File Offset: 0x0002C6C4
			public InteracionEstimulanteBasica estimuloInvertidoBasico
			{
				get
				{
					return this.estimuloInvertido;
				}
			}

			// Token: 0x170001BC RID: 444
			// (get) Token: 0x06000884 RID: 2180 RVA: 0x0002E4CC File Offset: 0x0002C6CC
			public double prioridad
			{
				get
				{
					return 1.0;
				}
			}

			// Token: 0x170001BD RID: 445
			// (get) Token: 0x06000885 RID: 2181 RVA: 0x00023ABA File Offset: 0x00021CBA
			// (set) Token: 0x06000886 RID: 2182 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPor
			{
				get
				{
					return null;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x170001BE RID: 446
			// (get) Token: 0x06000887 RID: 2183 RVA: 0x0002E4D7 File Offset: 0x0002C6D7
			// (set) Token: 0x06000888 RID: 2184 RVA: 0x0002E4DF File Offset: 0x0002C6DF
			public string tag { get; set; }

			// Token: 0x170001BF RID: 447
			// (get) Token: 0x06000889 RID: 2185 RVA: 0x000066D6 File Offset: 0x000048D6
			// (set) Token: 0x0600088A RID: 2186 RVA: 0x00023F85 File Offset: 0x00022185
			public TipoDeCalculoDeEstimulo tipo
			{
				get
				{
					return TipoDeCalculoDeEstimulo.frame;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x170001C0 RID: 448
			// (get) Token: 0x0600088B RID: 2187 RVA: 0x00023F85 File Offset: 0x00022185
			// (set) Token: 0x0600088C RID: 2188 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPorSegundario
			{
				get
				{
					throw new NotImplementedException();
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x0600088D RID: 2189 RVA: 0x00023F85 File Offset: 0x00022185
			public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
			{
				throw new NotImplementedException();
			}

			// Token: 0x0600088E RID: 2190 RVA: 0x0002E4E8 File Offset: 0x0002C6E8
			public UmbralBasico.Estado EstadoMasFuerte()
			{
				return this.estado;
			}

			// Token: 0x0600088F RID: 2191 RVA: 0x00023F85 File Offset: 0x00022185
			public void FixEstimuloInstanceTypes(EstimuloTactil instance, EstimuloTactil instanceInverted)
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x02000185 RID: 389
		public class VisualDebug : PrintTESTDialogosGenericos.Debug, ICalculoDeEstimuloVisual, ICalculoDeEstimulo<EstimuloVisual>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante
		{
			// Token: 0x170001C1 RID: 449
			// (get) Token: 0x06000890 RID: 2192 RVA: 0x0002E4F0 File Offset: 0x0002C6F0
			public float estimuloGeneradoEnFrame
			{
				get
				{
					return this.estado.estimulacionGeneradaEnFrame;
				}
			}

			// Token: 0x170001C2 RID: 450
			// (get) Token: 0x06000891 RID: 2193 RVA: 0x000066D6 File Offset: 0x000048D6
			public int cantidadDeEstados
			{
				get
				{
					return 1;
				}
			}

			// Token: 0x170001C3 RID: 451
			// (get) Token: 0x06000892 RID: 2194 RVA: 0x000066D6 File Offset: 0x000048D6
			public bool esSingleEstado
			{
				get
				{
					return true;
				}
			}

			// Token: 0x06000893 RID: 2195 RVA: 0x0002E50B File Offset: 0x0002C70B
			public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
			{
				estado = default(UmbralBasico.Estado);
				if (index == 0)
				{
					estado = this.estado;
				}
			}

			// Token: 0x06000894 RID: 2196 RVA: 0x00002BEA File Offset: 0x00000DEA
			public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
			{
			}

			// Token: 0x06000895 RID: 2197 RVA: 0x0002E523 File Offset: 0x0002C723
			public void GetSingleEstado(out UmbralBasico.Estado estado)
			{
				estado = this.estado;
			}

			// Token: 0x06000896 RID: 2198 RVA: 0x00023F85 File Offset: 0x00022185
			public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
			{
				throw new NotImplementedException();
			}

			// Token: 0x170001C4 RID: 452
			// (get) Token: 0x06000897 RID: 2199 RVA: 0x0002E531 File Offset: 0x0002C731
			// (set) Token: 0x06000898 RID: 2200 RVA: 0x0002E539 File Offset: 0x0002C739
			public bool causoMaxValue { get; set; }

			// Token: 0x06000899 RID: 2201 RVA: 0x00023F85 File Offset: 0x00022185
			public void SetEstimuloInstance(EstimuloVisual instance, EstimuloVisual inv)
			{
				throw new NotImplementedException();
			}

			// Token: 0x0600089A RID: 2202 RVA: 0x0002E542 File Offset: 0x0002C742
			public VisualDebug(Emocion emo, ParteQuePuedeEstimular estimulante, EstimuloVisual estimulo, ParteQuePuedeEstimular estimulanteInv, EstimuloVisual estimuloInv)
				: base(emo)
			{
				this.estimulanteParteInvertido = estimulanteInv;
				this.estimulanteParte = estimulante;
				this.estimulo = estimulo;
				this.estimuloInvertido = estimuloInv;
			}

			// Token: 0x170001C5 RID: 453
			// (get) Token: 0x0600089B RID: 2203 RVA: 0x0002E56C File Offset: 0x0002C76C
			public UmbralBasico.Estado estado
			{
				get
				{
					UmbralBasico.Estado estado = new UmbralBasico.Estado
					{
						offsetMod = 1f,
						rango = UmbralBasico.RangoEstado.enRango,
						spotScore = SpotScore.fuera,
						spotRango = UmbralBasico.RangoEstado.porDebajo
					};
					estado.SetEstimulacionGeneradaEnFrame(1f);
					estado.SetEstimulacionGeneradaTotal(1f);
					return estado;
				}
			}

			// Token: 0x170001C6 RID: 454
			// (get) Token: 0x0600089C RID: 2204 RVA: 0x0002E5C0 File Offset: 0x0002C7C0
			// (set) Token: 0x0600089D RID: 2205 RVA: 0x0002E5C8 File Offset: 0x0002C7C8
			public ParteQuePuedeEstimular estimulanteParte { get; set; }

			// Token: 0x170001C7 RID: 455
			// (get) Token: 0x0600089E RID: 2206 RVA: 0x0002E5D1 File Offset: 0x0002C7D1
			// (set) Token: 0x0600089F RID: 2207 RVA: 0x0002E5D9 File Offset: 0x0002C7D9
			public ParteQuePuedeEstimular estimulanteParteInvertido { get; set; }

			// Token: 0x170001C8 RID: 456
			// (get) Token: 0x060008A0 RID: 2208 RVA: 0x0002E5E2 File Offset: 0x0002C7E2
			// (set) Token: 0x060008A1 RID: 2209 RVA: 0x0002E5EA File Offset: 0x0002C7EA
			public EstimuloVisual estimulo { get; set; }

			// Token: 0x170001C9 RID: 457
			// (get) Token: 0x060008A2 RID: 2210 RVA: 0x0002E5F3 File Offset: 0x0002C7F3
			public InteracionEstimulanteBasica estimuloBasico
			{
				get
				{
					return this.estimulo;
				}
			}

			// Token: 0x170001CA RID: 458
			// (get) Token: 0x060008A3 RID: 2211 RVA: 0x0002E5FB File Offset: 0x0002C7FB
			// (set) Token: 0x060008A4 RID: 2212 RVA: 0x0002E603 File Offset: 0x0002C803
			public EstimuloVisual estimuloInvertido { get; set; }

			// Token: 0x170001CB RID: 459
			// (get) Token: 0x060008A5 RID: 2213 RVA: 0x0002E60C File Offset: 0x0002C80C
			public InteracionEstimulanteBasica estimuloInvertidoBasico
			{
				get
				{
					return this.estimuloInvertido;
				}
			}

			// Token: 0x170001CC RID: 460
			// (get) Token: 0x060008A6 RID: 2214 RVA: 0x0002E4CC File Offset: 0x0002C6CC
			public double prioridad
			{
				get
				{
					return 1.0;
				}
			}

			// Token: 0x170001CD RID: 461
			// (get) Token: 0x060008A7 RID: 2215 RVA: 0x00023ABA File Offset: 0x00021CBA
			// (set) Token: 0x060008A8 RID: 2216 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPor
			{
				get
				{
					return null;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x170001CE RID: 462
			// (get) Token: 0x060008A9 RID: 2217 RVA: 0x0002E614 File Offset: 0x0002C814
			// (set) Token: 0x060008AA RID: 2218 RVA: 0x0002E61C File Offset: 0x0002C81C
			public string tag { get; set; }

			// Token: 0x170001CF RID: 463
			// (get) Token: 0x060008AB RID: 2219 RVA: 0x000066D6 File Offset: 0x000048D6
			// (set) Token: 0x060008AC RID: 2220 RVA: 0x00023F85 File Offset: 0x00022185
			public TipoDeCalculoDeEstimulo tipo
			{
				get
				{
					return TipoDeCalculoDeEstimulo.frame;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x170001D0 RID: 464
			// (get) Token: 0x060008AD RID: 2221 RVA: 0x00023F85 File Offset: 0x00022185
			// (set) Token: 0x060008AE RID: 2222 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPorSegundario
			{
				get
				{
					throw new NotImplementedException();
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x060008AF RID: 2223 RVA: 0x00023F85 File Offset: 0x00022185
			public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
			{
				throw new NotImplementedException();
			}

			// Token: 0x060008B0 RID: 2224 RVA: 0x0002E625 File Offset: 0x0002C825
			public UmbralBasico.Estado EstadoMasFuerte()
			{
				return this.estado;
			}
		}

		// Token: 0x02000186 RID: 390
		public class CoitalDebug : PrintTESTDialogosGenericos.Debug, ICalculoDeEstimuloCoitalHole, ICalculoDeEstimuloCoitalHoleSimple, ICalculoDeEstimulo<EstimuloPenetrante>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante, ICalculoDeEstimuloCoitalHoleConSubTipoSegundario
		{
			// Token: 0x060008B1 RID: 2225 RVA: 0x0002E62D File Offset: 0x0002C82D
			public TipoDeEstimuloCoitalSegundaria GetTipoDeEstimuloCoitalSegundariaDeIndex(int estadoIndex)
			{
				switch (estadoIndex)
				{
				case 0:
					return TipoDeEstimuloCoitalSegundaria.velocidad;
				case 1:
					return TipoDeEstimuloCoitalSegundaria.apertura;
				case 2:
					return TipoDeEstimuloCoitalSegundaria.movimientoDeCentro;
				case 3:
					return TipoDeEstimuloCoitalSegundaria.profundidad;
				case 4:
					return TipoDeEstimuloCoitalSegundaria.anchura;
				default:
					throw new ArgumentOutOfRangeException(estadoIndex.ToString());
				}
			}

			// Token: 0x170001D1 RID: 465
			// (get) Token: 0x060008B2 RID: 2226 RVA: 0x0002E664 File Offset: 0x0002C864
			public float estimuloGeneradoEnFrame
			{
				get
				{
					return this.movimiento.estimulacionGeneradaEnFrame + this.apertura.estimulacionGeneradaEnFrame + this.penetracion.estimulacionGeneradaEnFrame + this.profundidad.estimulacionGeneradaEnFrame + this.anchura.estimulacionGeneradaEnFrame;
				}
			}

			// Token: 0x170001D2 RID: 466
			// (get) Token: 0x060008B3 RID: 2227 RVA: 0x0002E6BB File Offset: 0x0002C8BB
			public int cantidadDeEstados
			{
				get
				{
					return 5;
				}
			}

			// Token: 0x170001D3 RID: 467
			// (get) Token: 0x060008B4 RID: 2228 RVA: 0x000066D6 File Offset: 0x000048D6
			public bool esSingleEstado
			{
				get
				{
					return true;
				}
			}

			// Token: 0x060008B5 RID: 2229 RVA: 0x0002E6C0 File Offset: 0x0002C8C0
			public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
			{
				switch (index)
				{
				case 0:
					estado = this.penetracion;
					return;
				case 1:
					estado = this.apertura;
					return;
				case 2:
					estado = this.movimiento;
					return;
				case 3:
					estado = this.profundidad;
					return;
				case 4:
					estado = this.anchura;
					return;
				default:
					throw new ArgumentOutOfRangeException(index.ToString());
				}
			}

			// Token: 0x060008B6 RID: 2230 RVA: 0x00002BEA File Offset: 0x00000DEA
			public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
			{
			}

			// Token: 0x170001D4 RID: 468
			// (get) Token: 0x060008B7 RID: 2231 RVA: 0x0002E736 File Offset: 0x0002C936
			// (set) Token: 0x060008B8 RID: 2232 RVA: 0x0002E73E File Offset: 0x0002C93E
			public bool causoMaxValue { get; set; }

			// Token: 0x060008B9 RID: 2233 RVA: 0x0002E747 File Offset: 0x0002C947
			public CoitalDebug(Emocion emo, ParteQuePuedeEstimular estimulante, EstimuloPenetrante estimulo, ParteQuePuedeEstimular estimulanteInv, EstimuloPenetrante estimuloInv)
				: base(emo)
			{
				this.estimulanteParteInvertido = estimulanteInv;
				this.estimulanteParte = estimulante;
				this.estimulo = estimulo;
				this.estimuloInvertido = estimuloInv;
			}

			// Token: 0x170001D5 RID: 469
			// (get) Token: 0x060008BA RID: 2234 RVA: 0x0002E76E File Offset: 0x0002C96E
			public UmbralBasico.Estado anchura
			{
				get
				{
					return this.estado;
				}
			}

			// Token: 0x170001D6 RID: 470
			// (get) Token: 0x060008BB RID: 2235 RVA: 0x0002E76E File Offset: 0x0002C96E
			public UmbralBasico.Estado apertura
			{
				get
				{
					return this.estado;
				}
			}

			// Token: 0x170001D7 RID: 471
			// (get) Token: 0x060008BC RID: 2236 RVA: 0x0002E76E File Offset: 0x0002C96E
			public UmbralBasico.Estado profundidad
			{
				get
				{
					return this.estado;
				}
			}

			// Token: 0x170001D8 RID: 472
			// (get) Token: 0x060008BD RID: 2237 RVA: 0x0002E778 File Offset: 0x0002C978
			public UmbralBasico.Estado estado
			{
				get
				{
					UmbralBasico.Estado estado = new UmbralBasico.Estado
					{
						offsetMod = 1f,
						rango = UmbralBasico.RangoEstado.enRango,
						spotScore = SpotScore.fuera,
						spotRango = UmbralBasico.RangoEstado.porDebajo
					};
					estado.SetEstimulacionGeneradaEnFrame(1f);
					estado.SetEstimulacionGeneradaTotal(1f);
					return estado;
				}
			}

			// Token: 0x170001D9 RID: 473
			// (get) Token: 0x060008BE RID: 2238 RVA: 0x0002E76E File Offset: 0x0002C96E
			public UmbralBasico.Estado movimiento
			{
				get
				{
					return this.estado;
				}
			}

			// Token: 0x170001DA RID: 474
			// (get) Token: 0x060008BF RID: 2239 RVA: 0x0002E76E File Offset: 0x0002C96E
			public UmbralBasico.Estado penetracion
			{
				get
				{
					return this.estado;
				}
			}

			// Token: 0x170001DB RID: 475
			// (get) Token: 0x060008C0 RID: 2240 RVA: 0x0002E7CC File Offset: 0x0002C9CC
			// (set) Token: 0x060008C1 RID: 2241 RVA: 0x0002E7D4 File Offset: 0x0002C9D4
			public ParteQuePuedeEstimular estimulanteParte { get; set; }

			// Token: 0x170001DC RID: 476
			// (get) Token: 0x060008C2 RID: 2242 RVA: 0x0002E7DD File Offset: 0x0002C9DD
			// (set) Token: 0x060008C3 RID: 2243 RVA: 0x0002E7E5 File Offset: 0x0002C9E5
			public ParteQuePuedeEstimular estimulanteParteInvertido { get; set; }

			// Token: 0x170001DD RID: 477
			// (get) Token: 0x060008C4 RID: 2244 RVA: 0x0002E7EE File Offset: 0x0002C9EE
			// (set) Token: 0x060008C5 RID: 2245 RVA: 0x0002E7F6 File Offset: 0x0002C9F6
			public EstimuloPenetrante estimulo { get; set; }

			// Token: 0x170001DE RID: 478
			// (get) Token: 0x060008C6 RID: 2246 RVA: 0x0002E7FF File Offset: 0x0002C9FF
			public InteracionEstimulanteBasica estimuloBasico
			{
				get
				{
					return this.estimulo;
				}
			}

			// Token: 0x170001DF RID: 479
			// (get) Token: 0x060008C7 RID: 2247 RVA: 0x0002E807 File Offset: 0x0002CA07
			// (set) Token: 0x060008C8 RID: 2248 RVA: 0x0002E80F File Offset: 0x0002CA0F
			public EstimuloPenetrante estimuloInvertido { get; set; }

			// Token: 0x170001E0 RID: 480
			// (get) Token: 0x060008C9 RID: 2249 RVA: 0x0002E818 File Offset: 0x0002CA18
			public InteracionEstimulanteBasica estimuloInvertidoBasico
			{
				get
				{
					return this.estimuloInvertido;
				}
			}

			// Token: 0x170001E1 RID: 481
			// (get) Token: 0x060008CA RID: 2250 RVA: 0x0002E4CC File Offset: 0x0002C6CC
			public double prioridad
			{
				get
				{
					return 1.0;
				}
			}

			// Token: 0x170001E2 RID: 482
			// (get) Token: 0x060008CB RID: 2251 RVA: 0x00023ABA File Offset: 0x00021CBA
			// (set) Token: 0x060008CC RID: 2252 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPor
			{
				get
				{
					return null;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x170001E3 RID: 483
			// (get) Token: 0x060008CD RID: 2253 RVA: 0x0002E820 File Offset: 0x0002CA20
			// (set) Token: 0x060008CE RID: 2254 RVA: 0x0002E828 File Offset: 0x0002CA28
			public string tag { get; set; }

			// Token: 0x170001E4 RID: 484
			// (get) Token: 0x060008CF RID: 2255 RVA: 0x000066D6 File Offset: 0x000048D6
			// (set) Token: 0x060008D0 RID: 2256 RVA: 0x00023F85 File Offset: 0x00022185
			public TipoDeCalculoDeEstimulo tipo
			{
				get
				{
					return TipoDeCalculoDeEstimulo.frame;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x170001E5 RID: 485
			// (get) Token: 0x060008D1 RID: 2257 RVA: 0x00023F85 File Offset: 0x00022185
			// (set) Token: 0x060008D2 RID: 2258 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPorSegundario
			{
				get
				{
					throw new NotImplementedException();
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x060008D3 RID: 2259 RVA: 0x00023F85 File Offset: 0x00022185
			public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
			{
				throw new NotImplementedException();
			}

			// Token: 0x060008D4 RID: 2260 RVA: 0x0002E76E File Offset: 0x0002C96E
			public UmbralBasico.Estado EstadoMasFuerte()
			{
				return this.estado;
			}

			// Token: 0x060008D5 RID: 2261 RVA: 0x00023F85 File Offset: 0x00022185
			public void SetEstimuloInstance(EstimuloPenetrante instance, EstimuloPenetrante inv)
			{
				throw new NotImplementedException();
			}

			// Token: 0x060008D6 RID: 2262 RVA: 0x0002E831 File Offset: 0x0002CA31
			public void GetEstados(out UmbralBasico.Estado penetracion, out UmbralBasico.Estado apertura, out UmbralBasico.Estado movimiento, out UmbralBasico.Estado profundidad, out UmbralBasico.Estado anchura)
			{
				penetracion = this.penetracion;
				apertura = this.apertura;
				movimiento = this.movimiento;
				profundidad = this.profundidad;
				anchura = this.anchura;
			}

			// Token: 0x060008D7 RID: 2263 RVA: 0x00023F85 File Offset: 0x00022185
			public void SetEstado(TipoDeEstimuloCoitalSegundaria tipo, ref UmbralBasico.Estado estado)
			{
				throw new NotImplementedException();
			}

			// Token: 0x060008D8 RID: 2264 RVA: 0x00023F85 File Offset: 0x00022185
			public void SetEstadoAny(ref UmbralBasico.Estado estado)
			{
				throw new NotImplementedException();
			}

			// Token: 0x060008D9 RID: 2265 RVA: 0x00023F85 File Offset: 0x00022185
			public void GetSingleEstado(out UmbralBasico.Estado estado)
			{
				throw new NotImplementedException();
			}

			// Token: 0x060008DA RID: 2266 RVA: 0x00023F85 File Offset: 0x00022185
			public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x02000187 RID: 391
		public class PeticionExponerDebug : PrintTESTDialogosGenericos.Debug, ICalculoDeEstimuloPorCambioDePose, ICalculoDeEstimulo<EstimuloPorCambiarPose>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante
		{
			// Token: 0x170001E6 RID: 486
			// (get) Token: 0x060008DB RID: 2267 RVA: 0x0002E874 File Offset: 0x0002CA74
			public float estimuloGeneradoEnFrame
			{
				get
				{
					return this.estado.estimulacionGeneradaEnFrame;
				}
			}

			// Token: 0x170001E7 RID: 487
			// (get) Token: 0x060008DC RID: 2268 RVA: 0x000066D6 File Offset: 0x000048D6
			public int cantidadDeEstados
			{
				get
				{
					return 1;
				}
			}

			// Token: 0x170001E8 RID: 488
			// (get) Token: 0x060008DD RID: 2269 RVA: 0x000066D6 File Offset: 0x000048D6
			public bool esSingleEstado
			{
				get
				{
					return true;
				}
			}

			// Token: 0x060008DE RID: 2270 RVA: 0x0002E88F File Offset: 0x0002CA8F
			public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
			{
				estado = default(UmbralBasico.Estado);
				if (index == 0)
				{
					estado = this.estado;
				}
			}

			// Token: 0x060008DF RID: 2271 RVA: 0x0002E8A7 File Offset: 0x0002CAA7
			public void GetSingleEstado(out UmbralBasico.Estado estado)
			{
				estado = this.estado;
			}

			// Token: 0x060008E0 RID: 2272 RVA: 0x00002BEA File Offset: 0x00000DEA
			public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
			{
			}

			// Token: 0x060008E1 RID: 2273 RVA: 0x00023F85 File Offset: 0x00022185
			public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
			{
				throw new NotImplementedException();
			}

			// Token: 0x170001E9 RID: 489
			// (get) Token: 0x060008E2 RID: 2274 RVA: 0x0002E8B5 File Offset: 0x0002CAB5
			// (set) Token: 0x060008E3 RID: 2275 RVA: 0x0002E8BD File Offset: 0x0002CABD
			public bool causoMaxValue { get; set; }

			// Token: 0x060008E4 RID: 2276 RVA: 0x00023F85 File Offset: 0x00022185
			public void SetEstimuloInstance(EstimuloPorCambiarPose instance, EstimuloPorCambiarPose inv)
			{
				throw new NotImplementedException();
			}

			// Token: 0x060008E5 RID: 2277 RVA: 0x0002E8C6 File Offset: 0x0002CAC6
			public PeticionExponerDebug(Emocion emo, EstimuloPorCambiarPose estimulo, EstimuloPorCambiarPose estimuloInv)
				: base(emo)
			{
				this.estimulanteParte = ParteQuePuedeEstimular.boca;
				this.estimulo = estimulo;
				this.estimuloInvertido = estimuloInv;
				this.estimulanteParteInvertido = estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).Switch();
			}

			// Token: 0x170001EA RID: 490
			// (get) Token: 0x060008E6 RID: 2278 RVA: 0x0002E8FC File Offset: 0x0002CAFC
			public UmbralBasico.Estado estado
			{
				get
				{
					UmbralBasico.Estado estado = new UmbralBasico.Estado
					{
						offsetMod = 1f,
						rango = UmbralBasico.RangoEstado.enRango,
						spotScore = SpotScore.fuera,
						spotRango = UmbralBasico.RangoEstado.porDebajo
					};
					estado.SetEstimulacionGeneradaEnFrame(1f);
					estado.SetEstimulacionGeneradaTotal(1f);
					return estado;
				}
			}

			// Token: 0x170001EB RID: 491
			// (get) Token: 0x060008E7 RID: 2279 RVA: 0x0002E950 File Offset: 0x0002CB50
			// (set) Token: 0x060008E8 RID: 2280 RVA: 0x0002E958 File Offset: 0x0002CB58
			public ParteQuePuedeEstimular estimulanteParte { get; set; }

			// Token: 0x170001EC RID: 492
			// (get) Token: 0x060008E9 RID: 2281 RVA: 0x0002E961 File Offset: 0x0002CB61
			// (set) Token: 0x060008EA RID: 2282 RVA: 0x0002E969 File Offset: 0x0002CB69
			public ParteQuePuedeEstimular estimulanteParteInvertido { get; set; }

			// Token: 0x170001ED RID: 493
			// (get) Token: 0x060008EB RID: 2283 RVA: 0x0002E972 File Offset: 0x0002CB72
			// (set) Token: 0x060008EC RID: 2284 RVA: 0x0002E97A File Offset: 0x0002CB7A
			public EstimuloPorCambiarPose estimulo { get; set; }

			// Token: 0x170001EE RID: 494
			// (get) Token: 0x060008ED RID: 2285 RVA: 0x0002E983 File Offset: 0x0002CB83
			public InteracionEstimulanteBasica estimuloBasico
			{
				get
				{
					return this.estimulo;
				}
			}

			// Token: 0x170001EF RID: 495
			// (get) Token: 0x060008EE RID: 2286 RVA: 0x0002E98B File Offset: 0x0002CB8B
			// (set) Token: 0x060008EF RID: 2287 RVA: 0x0002E993 File Offset: 0x0002CB93
			public EstimuloPorCambiarPose estimuloInvertido { get; set; }

			// Token: 0x170001F0 RID: 496
			// (get) Token: 0x060008F0 RID: 2288 RVA: 0x0002E99C File Offset: 0x0002CB9C
			public InteracionEstimulanteBasica estimuloInvertidoBasico
			{
				get
				{
					return this.estimuloInvertido;
				}
			}

			// Token: 0x170001F1 RID: 497
			// (get) Token: 0x060008F1 RID: 2289 RVA: 0x0002E4CC File Offset: 0x0002C6CC
			public double prioridad
			{
				get
				{
					return 1.0;
				}
			}

			// Token: 0x170001F2 RID: 498
			// (get) Token: 0x060008F2 RID: 2290 RVA: 0x00023ABA File Offset: 0x00021CBA
			// (set) Token: 0x060008F3 RID: 2291 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPor
			{
				get
				{
					return null;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x170001F3 RID: 499
			// (get) Token: 0x060008F4 RID: 2292 RVA: 0x0002E9A4 File Offset: 0x0002CBA4
			// (set) Token: 0x060008F5 RID: 2293 RVA: 0x0002E9AC File Offset: 0x0002CBAC
			public string tag { get; set; }

			// Token: 0x170001F4 RID: 500
			// (get) Token: 0x060008F6 RID: 2294 RVA: 0x000066D6 File Offset: 0x000048D6
			// (set) Token: 0x060008F7 RID: 2295 RVA: 0x00023F85 File Offset: 0x00022185
			public TipoDeCalculoDeEstimulo tipo
			{
				get
				{
					return TipoDeCalculoDeEstimulo.frame;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x170001F5 RID: 501
			// (get) Token: 0x060008F8 RID: 2296 RVA: 0x00023F85 File Offset: 0x00022185
			// (set) Token: 0x060008F9 RID: 2297 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPorSegundario
			{
				get
				{
					throw new NotImplementedException();
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x060008FA RID: 2298 RVA: 0x00023F85 File Offset: 0x00022185
			public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
			{
				throw new NotImplementedException();
			}

			// Token: 0x060008FB RID: 2299 RVA: 0x0002E9B5 File Offset: 0x0002CBB5
			public UmbralBasico.Estado EstadoMasFuerte()
			{
				return this.estado;
			}
		}

		// Token: 0x02000188 RID: 392
		public class PeticionMoverDebug : PrintTESTDialogosGenericos.Debug, ICalculoDeEstimuloPorMovimientoDeBones, ICalculoDeEstimulo<EstimuloPorManipulacionDeBone>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante
		{
			// Token: 0x170001F6 RID: 502
			// (get) Token: 0x060008FC RID: 2300 RVA: 0x0002E9C0 File Offset: 0x0002CBC0
			public float estimuloGeneradoEnFrame
			{
				get
				{
					return this.estado.estimulacionGeneradaEnFrame;
				}
			}

			// Token: 0x170001F7 RID: 503
			// (get) Token: 0x060008FD RID: 2301 RVA: 0x000066D6 File Offset: 0x000048D6
			public int cantidadDeEstados
			{
				get
				{
					return 1;
				}
			}

			// Token: 0x170001F8 RID: 504
			// (get) Token: 0x060008FE RID: 2302 RVA: 0x000066D6 File Offset: 0x000048D6
			public bool esSingleEstado
			{
				get
				{
					return true;
				}
			}

			// Token: 0x060008FF RID: 2303 RVA: 0x0002E9DB File Offset: 0x0002CBDB
			public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
			{
				estado = default(UmbralBasico.Estado);
				if (index == 0)
				{
					estado = this.estado;
				}
			}

			// Token: 0x06000900 RID: 2304 RVA: 0x00002BEA File Offset: 0x00000DEA
			public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
			{
			}

			// Token: 0x06000901 RID: 2305 RVA: 0x0002E9F3 File Offset: 0x0002CBF3
			public void GetSingleEstado(out UmbralBasico.Estado estado)
			{
				estado = this.estado;
			}

			// Token: 0x06000902 RID: 2306 RVA: 0x00023F85 File Offset: 0x00022185
			public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
			{
				throw new NotImplementedException();
			}

			// Token: 0x170001F9 RID: 505
			// (get) Token: 0x06000903 RID: 2307 RVA: 0x0002EA01 File Offset: 0x0002CC01
			// (set) Token: 0x06000904 RID: 2308 RVA: 0x0002EA09 File Offset: 0x0002CC09
			public bool causoMaxValue { get; set; }

			// Token: 0x06000905 RID: 2309 RVA: 0x00023F85 File Offset: 0x00022185
			public void SetEstimuloInstance(EstimuloPorManipulacionDeBone instance, EstimuloPorManipulacionDeBone inv)
			{
				throw new NotImplementedException();
			}

			// Token: 0x06000906 RID: 2310 RVA: 0x0002EA12 File Offset: 0x0002CC12
			public PeticionMoverDebug(Emocion emo, EstimuloPorManipulacionDeBone estimulo, EstimuloPorManipulacionDeBone estimuloInv)
				: base(emo)
			{
				this.estimulanteParte = ParteQuePuedeEstimular.boca;
				this.estimulo = estimulo;
				this.estimuloInvertido = estimuloInv;
				this.estimulanteParteInvertido = estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).Switch();
			}

			// Token: 0x170001FA RID: 506
			// (get) Token: 0x06000907 RID: 2311 RVA: 0x0002EA48 File Offset: 0x0002CC48
			public UmbralBasico.Estado estado
			{
				get
				{
					UmbralBasico.Estado estado = new UmbralBasico.Estado
					{
						offsetMod = 1f,
						rango = UmbralBasico.RangoEstado.enRango,
						spotScore = SpotScore.fuera,
						spotRango = UmbralBasico.RangoEstado.porDebajo
					};
					estado.SetEstimulacionGeneradaEnFrame(1f);
					estado.SetEstimulacionGeneradaTotal(1f);
					return estado;
				}
			}

			// Token: 0x170001FB RID: 507
			// (get) Token: 0x06000908 RID: 2312 RVA: 0x0002EA9C File Offset: 0x0002CC9C
			// (set) Token: 0x06000909 RID: 2313 RVA: 0x0002EAA4 File Offset: 0x0002CCA4
			public ParteQuePuedeEstimular estimulanteParte { get; set; }

			// Token: 0x170001FC RID: 508
			// (get) Token: 0x0600090A RID: 2314 RVA: 0x0002EAAD File Offset: 0x0002CCAD
			// (set) Token: 0x0600090B RID: 2315 RVA: 0x0002EAB5 File Offset: 0x0002CCB5
			public ParteQuePuedeEstimular estimulanteParteInvertido { get; set; }

			// Token: 0x170001FD RID: 509
			// (get) Token: 0x0600090C RID: 2316 RVA: 0x0002EABE File Offset: 0x0002CCBE
			// (set) Token: 0x0600090D RID: 2317 RVA: 0x0002EAC6 File Offset: 0x0002CCC6
			public EstimuloPorManipulacionDeBone estimulo { get; set; }

			// Token: 0x170001FE RID: 510
			// (get) Token: 0x0600090E RID: 2318 RVA: 0x0002EACF File Offset: 0x0002CCCF
			public InteracionEstimulanteBasica estimuloBasico
			{
				get
				{
					return this.estimulo;
				}
			}

			// Token: 0x170001FF RID: 511
			// (get) Token: 0x0600090F RID: 2319 RVA: 0x0002EAD7 File Offset: 0x0002CCD7
			// (set) Token: 0x06000910 RID: 2320 RVA: 0x0002EADF File Offset: 0x0002CCDF
			public EstimuloPorManipulacionDeBone estimuloInvertido { get; set; }

			// Token: 0x17000200 RID: 512
			// (get) Token: 0x06000911 RID: 2321 RVA: 0x0002EAE8 File Offset: 0x0002CCE8
			public InteracionEstimulanteBasica estimuloInvertidoBasico
			{
				get
				{
					return this.estimuloInvertido;
				}
			}

			// Token: 0x17000201 RID: 513
			// (get) Token: 0x06000912 RID: 2322 RVA: 0x0002E4CC File Offset: 0x0002C6CC
			public double prioridad
			{
				get
				{
					return 1.0;
				}
			}

			// Token: 0x17000202 RID: 514
			// (get) Token: 0x06000913 RID: 2323 RVA: 0x00023ABA File Offset: 0x00021CBA
			// (set) Token: 0x06000914 RID: 2324 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPor
			{
				get
				{
					return null;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x17000203 RID: 515
			// (get) Token: 0x06000915 RID: 2325 RVA: 0x0002EAF0 File Offset: 0x0002CCF0
			// (set) Token: 0x06000916 RID: 2326 RVA: 0x0002EAF8 File Offset: 0x0002CCF8
			public string tag { get; set; }

			// Token: 0x17000204 RID: 516
			// (get) Token: 0x06000917 RID: 2327 RVA: 0x000066D6 File Offset: 0x000048D6
			// (set) Token: 0x06000918 RID: 2328 RVA: 0x00023F85 File Offset: 0x00022185
			public TipoDeCalculoDeEstimulo tipo
			{
				get
				{
					return TipoDeCalculoDeEstimulo.frame;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x17000205 RID: 517
			// (get) Token: 0x06000919 RID: 2329 RVA: 0x00023F85 File Offset: 0x00022185
			// (set) Token: 0x0600091A RID: 2330 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPorSegundario
			{
				get
				{
					throw new NotImplementedException();
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x0600091B RID: 2331 RVA: 0x00023F85 File Offset: 0x00022185
			public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
			{
				throw new NotImplementedException();
			}

			// Token: 0x0600091C RID: 2332 RVA: 0x0002EB01 File Offset: 0x0002CD01
			public UmbralBasico.Estado EstadoMasFuerte()
			{
				return this.estado;
			}
		}

		// Token: 0x02000189 RID: 393
		public class ExponerDebug : PrintTESTDialogosGenericos.Debug, ICalculoDeEstimuloPorCambioDePose, ICalculoDeEstimulo<EstimuloPorCambiarPose>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante
		{
			// Token: 0x17000206 RID: 518
			// (get) Token: 0x0600091D RID: 2333 RVA: 0x0002EB0C File Offset: 0x0002CD0C
			public float estimuloGeneradoEnFrame
			{
				get
				{
					return this.estado.estimulacionGeneradaEnFrame;
				}
			}

			// Token: 0x17000207 RID: 519
			// (get) Token: 0x0600091E RID: 2334 RVA: 0x000066D6 File Offset: 0x000048D6
			public int cantidadDeEstados
			{
				get
				{
					return 1;
				}
			}

			// Token: 0x17000208 RID: 520
			// (get) Token: 0x0600091F RID: 2335 RVA: 0x000066D6 File Offset: 0x000048D6
			public bool esSingleEstado
			{
				get
				{
					return true;
				}
			}

			// Token: 0x06000920 RID: 2336 RVA: 0x0002EB27 File Offset: 0x0002CD27
			public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
			{
				estado = default(UmbralBasico.Estado);
				if (index == 0)
				{
					estado = this.estado;
				}
			}

			// Token: 0x06000921 RID: 2337 RVA: 0x00002BEA File Offset: 0x00000DEA
			public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
			{
			}

			// Token: 0x06000922 RID: 2338 RVA: 0x0002EB3F File Offset: 0x0002CD3F
			public void GetSingleEstado(out UmbralBasico.Estado estado)
			{
				estado = this.estado;
			}

			// Token: 0x06000923 RID: 2339 RVA: 0x00023F85 File Offset: 0x00022185
			public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
			{
				throw new NotImplementedException();
			}

			// Token: 0x17000209 RID: 521
			// (get) Token: 0x06000924 RID: 2340 RVA: 0x0002EB4D File Offset: 0x0002CD4D
			// (set) Token: 0x06000925 RID: 2341 RVA: 0x0002EB55 File Offset: 0x0002CD55
			public bool causoMaxValue { get; set; }

			// Token: 0x06000926 RID: 2342 RVA: 0x00023F85 File Offset: 0x00022185
			public void SetEstimuloInstance(EstimuloPorCambiarPose instance, EstimuloPorCambiarPose inv)
			{
				throw new NotImplementedException();
			}

			// Token: 0x06000927 RID: 2343 RVA: 0x0002EB5E File Offset: 0x0002CD5E
			public ExponerDebug(Emocion emo, EstimuloPorCambiarPose estimulo, EstimuloPorCambiarPose estimuloInv)
				: base(emo)
			{
				this.estimulanteParte = ParteQuePuedeEstimular.manos;
				this.estimulo = estimulo;
				this.estimuloInvertido = estimuloInv;
				this.estimulanteParteInvertido = estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).Switch();
			}

			// Token: 0x1700020A RID: 522
			// (get) Token: 0x06000928 RID: 2344 RVA: 0x0002EB90 File Offset: 0x0002CD90
			public UmbralBasico.Estado estado
			{
				get
				{
					UmbralBasico.Estado estado = new UmbralBasico.Estado
					{
						offsetMod = 1f,
						rango = UmbralBasico.RangoEstado.enRango,
						spotScore = SpotScore.fuera,
						spotRango = UmbralBasico.RangoEstado.porDebajo
					};
					estado.SetEstimulacionGeneradaEnFrame(1f);
					estado.SetEstimulacionGeneradaTotal(1f);
					return estado;
				}
			}

			// Token: 0x1700020B RID: 523
			// (get) Token: 0x06000929 RID: 2345 RVA: 0x0002EBE4 File Offset: 0x0002CDE4
			// (set) Token: 0x0600092A RID: 2346 RVA: 0x0002EBEC File Offset: 0x0002CDEC
			public ParteQuePuedeEstimular estimulanteParte { get; set; }

			// Token: 0x1700020C RID: 524
			// (get) Token: 0x0600092B RID: 2347 RVA: 0x0002EBF5 File Offset: 0x0002CDF5
			// (set) Token: 0x0600092C RID: 2348 RVA: 0x0002EBFD File Offset: 0x0002CDFD
			public ParteQuePuedeEstimular estimulanteParteInvertido { get; set; }

			// Token: 0x1700020D RID: 525
			// (get) Token: 0x0600092D RID: 2349 RVA: 0x0002EC06 File Offset: 0x0002CE06
			// (set) Token: 0x0600092E RID: 2350 RVA: 0x0002EC0E File Offset: 0x0002CE0E
			public EstimuloPorCambiarPose estimulo { get; set; }

			// Token: 0x1700020E RID: 526
			// (get) Token: 0x0600092F RID: 2351 RVA: 0x0002EC17 File Offset: 0x0002CE17
			public InteracionEstimulanteBasica estimuloBasico
			{
				get
				{
					return this.estimulo;
				}
			}

			// Token: 0x1700020F RID: 527
			// (get) Token: 0x06000930 RID: 2352 RVA: 0x0002EC1F File Offset: 0x0002CE1F
			// (set) Token: 0x06000931 RID: 2353 RVA: 0x0002EC27 File Offset: 0x0002CE27
			public EstimuloPorCambiarPose estimuloInvertido { get; set; }

			// Token: 0x17000210 RID: 528
			// (get) Token: 0x06000932 RID: 2354 RVA: 0x0002EC30 File Offset: 0x0002CE30
			public InteracionEstimulanteBasica estimuloInvertidoBasico
			{
				get
				{
					return this.estimuloInvertido;
				}
			}

			// Token: 0x17000211 RID: 529
			// (get) Token: 0x06000933 RID: 2355 RVA: 0x0002E4CC File Offset: 0x0002C6CC
			public double prioridad
			{
				get
				{
					return 1.0;
				}
			}

			// Token: 0x17000212 RID: 530
			// (get) Token: 0x06000934 RID: 2356 RVA: 0x00023ABA File Offset: 0x00021CBA
			// (set) Token: 0x06000935 RID: 2357 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPor
			{
				get
				{
					return null;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x17000213 RID: 531
			// (get) Token: 0x06000936 RID: 2358 RVA: 0x0002EC38 File Offset: 0x0002CE38
			// (set) Token: 0x06000937 RID: 2359 RVA: 0x0002EC40 File Offset: 0x0002CE40
			public string tag { get; set; }

			// Token: 0x17000214 RID: 532
			// (get) Token: 0x06000938 RID: 2360 RVA: 0x000066D6 File Offset: 0x000048D6
			// (set) Token: 0x06000939 RID: 2361 RVA: 0x00023F85 File Offset: 0x00022185
			public TipoDeCalculoDeEstimulo tipo
			{
				get
				{
					return TipoDeCalculoDeEstimulo.frame;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x17000215 RID: 533
			// (get) Token: 0x0600093A RID: 2362 RVA: 0x00023F85 File Offset: 0x00022185
			// (set) Token: 0x0600093B RID: 2363 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPorSegundario
			{
				get
				{
					throw new NotImplementedException();
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x0600093C RID: 2364 RVA: 0x00023F85 File Offset: 0x00022185
			public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
			{
				throw new NotImplementedException();
			}

			// Token: 0x0600093D RID: 2365 RVA: 0x0002EC49 File Offset: 0x0002CE49
			public UmbralBasico.Estado EstadoMasFuerte()
			{
				return this.estado;
			}
		}

		// Token: 0x0200018A RID: 394
		public class ManipularDebug : PrintTESTDialogosGenericos.Debug, ICalculoDeEstimuloPorMovimientoDeBones, ICalculoDeEstimulo<EstimuloPorManipulacionDeBone>, ICalculoDeEstimulo, ICalculoDeInteracionEstimulante, IClearable, ICalculoDeEstimuloCompleto, ICalculoDeInteracionEstimulanteConEstado, ICalculoDeEstimuloConEstado, ICalculoDeEstimuloGenerando, ICalculoDeInteracionEstimulanteDeParteEstimulante, ICalculoDeEstimuloDeParteEstimulante
		{
			// Token: 0x17000216 RID: 534
			// (get) Token: 0x0600093E RID: 2366 RVA: 0x0002EC54 File Offset: 0x0002CE54
			public float estimuloGeneradoEnFrame
			{
				get
				{
					return this.estado.estimulacionGeneradaEnFrame;
				}
			}

			// Token: 0x17000217 RID: 535
			// (get) Token: 0x0600093F RID: 2367 RVA: 0x000066D6 File Offset: 0x000048D6
			public int cantidadDeEstados
			{
				get
				{
					return 1;
				}
			}

			// Token: 0x17000218 RID: 536
			// (get) Token: 0x06000940 RID: 2368 RVA: 0x000066D6 File Offset: 0x000048D6
			public bool esSingleEstado
			{
				get
				{
					return true;
				}
			}

			// Token: 0x06000941 RID: 2369 RVA: 0x0002EC6F File Offset: 0x0002CE6F
			public void GetEstadoCopia(int index, out UmbralBasico.Estado estado)
			{
				estado = default(UmbralBasico.Estado);
				if (index == 0)
				{
					estado = this.estado;
				}
			}

			// Token: 0x06000942 RID: 2370 RVA: 0x00002BEA File Offset: 0x00000DEA
			public void SobreEscribirEstado(int index, ref UmbralBasico.Estado estado)
			{
			}

			// Token: 0x06000943 RID: 2371 RVA: 0x0002EC87 File Offset: 0x0002CE87
			public void GetSingleEstado(out UmbralBasico.Estado estado)
			{
				estado = this.estado;
			}

			// Token: 0x06000944 RID: 2372 RVA: 0x00023F85 File Offset: 0x00022185
			public void SobreEscribirSingleEstado(ref UmbralBasico.Estado estado)
			{
				throw new NotImplementedException();
			}

			// Token: 0x17000219 RID: 537
			// (get) Token: 0x06000945 RID: 2373 RVA: 0x0002EC95 File Offset: 0x0002CE95
			// (set) Token: 0x06000946 RID: 2374 RVA: 0x0002EC9D File Offset: 0x0002CE9D
			public bool causoMaxValue { get; set; }

			// Token: 0x06000947 RID: 2375 RVA: 0x00023F85 File Offset: 0x00022185
			public void SetEstimuloInstance(EstimuloPorManipulacionDeBone instance, EstimuloPorManipulacionDeBone inv)
			{
				throw new NotImplementedException();
			}

			// Token: 0x06000948 RID: 2376 RVA: 0x0002ECA6 File Offset: 0x0002CEA6
			public ManipularDebug(Emocion emo, EstimuloPorManipulacionDeBone estimulo, EstimuloPorManipulacionDeBone estimuloInv)
				: base(emo)
			{
				this.estimulanteParte = ParteQuePuedeEstimular.manos;
				this.estimulo = estimulo;
				this.estimuloInvertido = estimuloInv;
				this.estimulanteParteInvertido = estimulo.PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto.@fixed).Switch();
			}

			// Token: 0x1700021A RID: 538
			// (get) Token: 0x06000949 RID: 2377 RVA: 0x0002ECD8 File Offset: 0x0002CED8
			public UmbralBasico.Estado estado
			{
				get
				{
					UmbralBasico.Estado estado = new UmbralBasico.Estado
					{
						offsetMod = 1f,
						rango = UmbralBasico.RangoEstado.enRango,
						spotScore = SpotScore.fuera,
						spotRango = UmbralBasico.RangoEstado.porDebajo
					};
					estado.SetEstimulacionGeneradaEnFrame(1f);
					estado.SetEstimulacionGeneradaTotal(1f);
					return estado;
				}
			}

			// Token: 0x1700021B RID: 539
			// (get) Token: 0x0600094A RID: 2378 RVA: 0x0002ED2C File Offset: 0x0002CF2C
			// (set) Token: 0x0600094B RID: 2379 RVA: 0x0002ED34 File Offset: 0x0002CF34
			public ParteQuePuedeEstimular estimulanteParte { get; set; }

			// Token: 0x1700021C RID: 540
			// (get) Token: 0x0600094C RID: 2380 RVA: 0x0002ED3D File Offset: 0x0002CF3D
			// (set) Token: 0x0600094D RID: 2381 RVA: 0x0002ED45 File Offset: 0x0002CF45
			public ParteQuePuedeEstimular estimulanteParteInvertido { get; set; }

			// Token: 0x1700021D RID: 541
			// (get) Token: 0x0600094E RID: 2382 RVA: 0x0002ED4E File Offset: 0x0002CF4E
			// (set) Token: 0x0600094F RID: 2383 RVA: 0x0002ED56 File Offset: 0x0002CF56
			public EstimuloPorManipulacionDeBone estimulo { get; set; }

			// Token: 0x1700021E RID: 542
			// (get) Token: 0x06000950 RID: 2384 RVA: 0x0002ED5F File Offset: 0x0002CF5F
			public InteracionEstimulanteBasica estimuloBasico
			{
				get
				{
					return this.estimulo;
				}
			}

			// Token: 0x1700021F RID: 543
			// (get) Token: 0x06000951 RID: 2385 RVA: 0x0002ED67 File Offset: 0x0002CF67
			// (set) Token: 0x06000952 RID: 2386 RVA: 0x0002ED6F File Offset: 0x0002CF6F
			public EstimuloPorManipulacionDeBone estimuloInvertido { get; set; }

			// Token: 0x17000220 RID: 544
			// (get) Token: 0x06000953 RID: 2387 RVA: 0x0002ED78 File Offset: 0x0002CF78
			public InteracionEstimulanteBasica estimuloInvertidoBasico
			{
				get
				{
					return this.estimuloInvertido;
				}
			}

			// Token: 0x17000221 RID: 545
			// (get) Token: 0x06000954 RID: 2388 RVA: 0x0002E4CC File Offset: 0x0002C6CC
			public double prioridad
			{
				get
				{
					return 1.0;
				}
			}

			// Token: 0x17000222 RID: 546
			// (get) Token: 0x06000955 RID: 2389 RVA: 0x00023ABA File Offset: 0x00021CBA
			// (set) Token: 0x06000956 RID: 2390 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPor
			{
				get
				{
					return null;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x17000223 RID: 547
			// (get) Token: 0x06000957 RID: 2391 RVA: 0x0002ED80 File Offset: 0x0002CF80
			// (set) Token: 0x06000958 RID: 2392 RVA: 0x0002ED88 File Offset: 0x0002CF88
			public string tag { get; set; }

			// Token: 0x17000224 RID: 548
			// (get) Token: 0x06000959 RID: 2393 RVA: 0x000066D6 File Offset: 0x000048D6
			// (set) Token: 0x0600095A RID: 2394 RVA: 0x00023F85 File Offset: 0x00022185
			public TipoDeCalculoDeEstimulo tipo
			{
				get
				{
					return TipoDeCalculoDeEstimulo.frame;
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x17000225 RID: 549
			// (get) Token: 0x0600095B RID: 2395 RVA: 0x00023F85 File Offset: 0x00022185
			// (set) Token: 0x0600095C RID: 2396 RVA: 0x00023F85 File Offset: 0x00022185
			public ICalculadorDeEstimulo producidoPorSegundario
			{
				get
				{
					throw new NotImplementedException();
				}
				set
				{
					throw new NotImplementedException();
				}
			}

			// Token: 0x0600095D RID: 2397 RVA: 0x00023F85 File Offset: 0x00022185
			public void SobreEscribirEstadoMasFuerte(UmbralBasico.Estado masFuerte)
			{
				throw new NotImplementedException();
			}

			// Token: 0x0600095E RID: 2398 RVA: 0x0002ED91 File Offset: 0x0002CF91
			public UmbralBasico.Estado EstadoMasFuerte()
			{
				return this.estado;
			}
		}
	}
}
