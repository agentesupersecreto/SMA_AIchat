using System;
using Assets.Base.BeachGirl.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Runtime;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Characters.Controladores.ControlladoresDeColoDePrioridad;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Controllers.Ojos.Parpadeos;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores
{
	// Token: 0x0200006B RID: 107
	public class RegistroDeFuncionesDeGestos : CustomMonobehaviour
	{
		// Token: 0x06000323 RID: 803 RVA: 0x0001059B File Offset: 0x0000E79B
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("GestuarReaccion", this, base.GetType().GetMethod("GestuarReaccion"));
		}

		// Token: 0x06000324 RID: 804 RVA: 0x000105BE File Offset: 0x0000E7BE
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("GestuarReaccion");
		}

		// Token: 0x06000325 RID: 805 RVA: 0x000105D4 File Offset: 0x0000E7D4
		private Character ObtenerCharacter(string id)
		{
			Guid guid = Guid.Parse(id);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
		}

		// Token: 0x06000326 RID: 806 RVA: 0x000105F4 File Offset: 0x0000E7F4
		public void GestuarReaccion(string id, object reaccionObj, float weight)
		{
			try
			{
				Character character = this.ObtenerCharacter(id);
				ReaccionHumana reaccionHumana;
				if (!Enum.TryParse<ReaccionHumana>(reaccionObj.ToString(), out reaccionHumana))
				{
					Debug.LogException(new InvalidOperationException(), this);
				}
				else
				{
					RegistroDeFuncionesDeGestos.Gestuar(character, reaccionHumana, weight);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x06000327 RID: 807 RVA: 0x00010648 File Offset: 0x0000E848
		public static void Gestuar(Character femaleChar, ReaccionHumana reaccion, float weight)
		{
			if (reaccion == ReaccionHumana.None)
			{
				return;
			}
			if (weight <= 0f)
			{
				return;
			}
			if (femaleChar == null)
			{
				return;
			}
			float num = Mathf.InverseLerp(0f, 1f, weight).OutPow(3f);
			float num2 = Mathf.Clamp01(num.Random(0.75f));
			float num3 = Mathf.Clamp01(num.Random(0.75f));
			float num4 = Mathf.Lerp(15f, 60f, num);
			if (reaccion <= ReaccionHumana.arousal)
			{
				if (reaccion <= ReaccionHumana.dolor)
				{
					if (reaccion != ReaccionHumana.concentToHero)
					{
						if (reaccion != ReaccionHumana.dolor)
						{
							goto IL_00FB;
						}
						goto IL_00C8;
					}
				}
				else
				{
					if (reaccion == ReaccionHumana.rabia)
					{
						RegistroDeFuncionesDeGestos.Enojar.Gestuar(femaleChar, num, num2, num3, num4 * 2f);
						return;
					}
					if (reaccion != ReaccionHumana.placer && reaccion != ReaccionHumana.arousal)
					{
						goto IL_00FB;
					}
				}
			}
			else if (reaccion <= ReaccionHumana.miedo)
			{
				if (reaccion == ReaccionHumana.tristeza)
				{
					goto IL_00C8;
				}
				if (reaccion != ReaccionHumana.miedo)
				{
					goto IL_00FB;
				}
				RegistroDeFuncionesDeGestos.Asustar.Gestuar(femaleChar, num, num2, num3, num4 * 2f);
				return;
			}
			else if (reaccion != ReaccionHumana.alegria && reaccion != ReaccionHumana.felicidad && reaccion != ReaccionHumana.desHielo)
			{
				goto IL_00FB;
			}
			RegistroDeFuncionesDeGestos.Sonrreir.Gestuar(femaleChar, num, num2, num3, num4);
			return;
			IL_00C8:
			RegistroDeFuncionesDeGestos.Sufrir.Gestuar(femaleChar, num, num2, num3, num4 * 1.5f);
			return;
			IL_00FB:
			throw new ArgumentOutOfRangeException(reaccion.ToString());
		}

		// Token: 0x02000098 RID: 152
		public static class EnojarSufrir
		{
			// Token: 0x0600042D RID: 1069 RVA: 0x00015A0C File Offset: 0x00013C0C
			public static void Gestuar(Character female, float weightFace, float weightHead, float weightHombros, float duracionFace)
			{
				if (female == null)
				{
					return;
				}
				ControlladorDeGestosFacialesEmocionales componentInChildren = female.GetComponentInChildren<ControlladorDeGestosFacialesEmocionales>();
				if (componentInChildren == null)
				{
					return;
				}
				ControladorDeGestosConCabeza componentInChildren2 = female.GetComponentInChildren<ControladorDeGestosConCabeza>();
				if (componentInChildren2 == null)
				{
					return;
				}
				ControladorDeGestosConHombros componentInChildren3 = female.GetComponentInChildren<ControladorDeGestosConHombros>();
				if (componentInChildren3 == null)
				{
					return;
				}
				RegistroDeFuncionesDeGestos.Cara.LamentarSonreir.Gestuar(componentInChildren, weightFace, duracionFace);
				RegistroDeFuncionesDeGestos.Cabeza.Gestuar(componentInChildren2, TipoDeGestoDeCabeza.repulsion, 1f, weightHead, true);
				RegistroDeFuncionesDeGestos.Hombros.Gestuar(componentInChildren3, TipoDeGestoDeHombro.achiquitar, 1f, weightHombros, true);
			}

			// Token: 0x0600042E RID: 1070 RVA: 0x00015A7B File Offset: 0x00013C7B
			public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, ControladorDeGestosConCabeza headController, ControladorDeGestosConHombros hombrosController, float weightFace, float weightHead, float weightHombros, float duracionFace)
			{
				RegistroDeFuncionesDeGestos.Cara.EnojarLamentar.Gestuar(fController, weightFace, duracionFace);
				RegistroDeFuncionesDeGestos.Cabeza.Gestuar(headController, TipoDeGestoDeCabeza.repulsion, 1f, weightHead, true);
				RegistroDeFuncionesDeGestos.Hombros.Gestuar(hombrosController, TipoDeGestoDeHombro.achiquitar, 1f, weightHombros, true);
			}
		}

		// Token: 0x02000099 RID: 153
		public static class SufrirAlegrar
		{
			// Token: 0x0600042F RID: 1071 RVA: 0x00015AA4 File Offset: 0x00013CA4
			public static void Gestuar(Character female, float weightFace, float weightHead, float weightHombros, float duracionFace)
			{
				if (female == null)
				{
					return;
				}
				ControlladorDeGestosFacialesEmocionales componentInChildren = female.GetComponentInChildren<ControlladorDeGestosFacialesEmocionales>();
				if (componentInChildren == null)
				{
					return;
				}
				ControladorDeGestosConCabeza componentInChildren2 = female.GetComponentInChildren<ControladorDeGestosConCabeza>();
				if (componentInChildren2 == null)
				{
					return;
				}
				ControladorDeGestosConHombros componentInChildren3 = female.GetComponentInChildren<ControladorDeGestosConHombros>();
				if (componentInChildren3 == null)
				{
					return;
				}
				RegistroDeFuncionesDeGestos.Cara.LamentarSonreir.Gestuar(componentInChildren, weightFace, duracionFace);
				RegistroDeFuncionesDeGestos.Cabeza.Gestuar(componentInChildren2, TipoDeGestoDeCabeza.curiosidad, 1f, weightHead, true);
				RegistroDeFuncionesDeGestos.Hombros.Gestuar(componentInChildren3, TipoDeGestoDeHombro.diagonales, 1f, weightHombros, true);
			}

			// Token: 0x06000430 RID: 1072 RVA: 0x00015B14 File Offset: 0x00013D14
			public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, ControladorDeGestosConCabeza headController, ControladorDeGestosConHombros hombrosController, float weightFace, float weightHead, float weightHombros, float duracionFace)
			{
				RegistroDeFuncionesDeGestos.Cara.LamentarSonreir.Gestuar(fController, weightFace, duracionFace);
				RegistroDeFuncionesDeGestos.Cabeza.Gestuar(headController, TipoDeGestoDeCabeza.curiosidad, 1f, weightHead, true);
				RegistroDeFuncionesDeGestos.Hombros.Gestuar(hombrosController, TipoDeGestoDeHombro.diagonales, 1f, weightHombros, true);
			}
		}

		// Token: 0x0200009A RID: 154
		public static class Sufrir
		{
			// Token: 0x06000431 RID: 1073 RVA: 0x00015B40 File Offset: 0x00013D40
			public static void Gestuar(Character female, float weightFace, float weightHead, float weightHombros, float duracionFace)
			{
				if (female == null)
				{
					return;
				}
				ControlladorDeGestosFacialesEmocionales componentInChildren = female.GetComponentInChildren<ControlladorDeGestosFacialesEmocionales>();
				if (componentInChildren == null)
				{
					return;
				}
				ControladorDeGestosConCabeza componentInChildren2 = female.GetComponentInChildren<ControladorDeGestosConCabeza>();
				if (componentInChildren2 == null)
				{
					return;
				}
				ControladorDeGestosConHombros componentInChildren3 = female.GetComponentInChildren<ControladorDeGestosConHombros>();
				if (componentInChildren3 == null)
				{
					return;
				}
				RegistroDeFuncionesDeGestos.Cara.Lamentar.Gestuar(componentInChildren, weightFace, duracionFace);
				RegistroDeFuncionesDeGestos.Cabeza.Gestuar(componentInChildren2, TipoDeGestoDeCabeza.dolor, 1f, weightHead, true);
				RegistroDeFuncionesDeGestos.Hombros.Gestuar(componentInChildren3, TipoDeGestoDeHombro.achiquitar, 1f, weightHombros, true);
			}

			// Token: 0x06000432 RID: 1074 RVA: 0x00015BB0 File Offset: 0x00013DB0
			public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, ControladorDeGestosConCabeza headController, ControladorDeGestosConHombros hombrosController, float weightFace, float weightHead, float weightHombros, float duracionFace)
			{
				RegistroDeFuncionesDeGestos.Cara.Lamentar.Gestuar(fController, weightFace, duracionFace);
				RegistroDeFuncionesDeGestos.Cabeza.Gestuar(headController, TipoDeGestoDeCabeza.dolor, 1f, weightHead, true);
				RegistroDeFuncionesDeGestos.Hombros.Gestuar(hombrosController, TipoDeGestoDeHombro.achiquitar, 1f, weightHombros, true);
			}
		}

		// Token: 0x0200009B RID: 155
		public static class Sorprender
		{
			// Token: 0x06000433 RID: 1075 RVA: 0x00015BDC File Offset: 0x00013DDC
			public static void Gestuar(Character female, float weightFace, float weightHead, float weightHombros, float weightBoca, float duracion)
			{
				if (female == null)
				{
					return;
				}
				ControlladorDeGestosFacialesEmocionales componentInChildren = female.GetComponentInChildren<ControlladorDeGestosFacialesEmocionales>();
				if (componentInChildren == null)
				{
					return;
				}
				ControladorDeGestosConCabeza componentInChildren2 = female.GetComponentInChildren<ControladorDeGestosConCabeza>();
				if (componentInChildren2 == null)
				{
					return;
				}
				ControladorDeGestosConHombros componentInChildren3 = female.GetComponentInChildren<ControladorDeGestosConHombros>();
				if (componentInChildren3 == null)
				{
					return;
				}
				ControladorDeGestosDeBoca componentInChildren4 = female.GetComponentInChildren<ControladorDeGestosDeBoca>();
				if (componentInChildren4 == null)
				{
					return;
				}
				OjosExpresionController componentInChildren5 = female.GetComponentInChildren<OjosExpresionController>();
				if (componentInChildren5 == null)
				{
					return;
				}
				float duracionPorCiclo = Singleton<CurvasDeGestosConHombros>.instance.ObtenerDatosDeTipo(TipoDeGestoDeHombro.achiquitar).duracionPorCiclo;
				float duracionPorCiclo2 = Singleton<CurvasDeGestosConCabeza>.instance.ObtenerDatosDeTipo(RegistroDeFuncionesDeGestos.Cabeza.overrrideNext ?? TipoDeGestoDeCabeza.sorpresa).duracionPorCiclo;
				RegistroDeFuncionesDeGestos.Cara.Sorprender.Gestuar(componentInChildren, componentInChildren4, componentInChildren5, weightFace, duracion, 1f, weightBoca);
				RegistroDeFuncionesDeGestos.Cabeza.Gestuar(componentInChildren2, TipoDeGestoDeCabeza.sorpresa, Mathf.Clamp(duracion, duracionPorCiclo2 * 0.75f, duracionPorCiclo2 * 2f), weightHead, false);
				RegistroDeFuncionesDeGestos.Hombros.Gestuar(componentInChildren3, TipoDeGestoDeHombro.achiquitar, Mathf.Clamp(duracion, duracionPorCiclo * 0.75f, duracionPorCiclo * 2f), weightHombros, false);
			}
		}

		// Token: 0x0200009C RID: 156
		public static class Sonrreir
		{
			// Token: 0x06000434 RID: 1076 RVA: 0x00015CDC File Offset: 0x00013EDC
			public static void Gestuar(Character female, float weightFace, float weightHead, float weightHombros, float duracionFace)
			{
				if (female == null)
				{
					return;
				}
				ControlladorDeGestosFacialesEmocionales componentInChildren = female.GetComponentInChildren<ControlladorDeGestosFacialesEmocionales>();
				if (componentInChildren == null)
				{
					return;
				}
				ControladorDeGestosConCabeza componentInChildren2 = female.GetComponentInChildren<ControladorDeGestosConCabeza>();
				if (componentInChildren2 == null)
				{
					return;
				}
				ControladorDeGestosConHombros componentInChildren3 = female.GetComponentInChildren<ControladorDeGestosConHombros>();
				if (componentInChildren3 == null)
				{
					return;
				}
				RegistroDeFuncionesDeGestos.Cara.Sonrreir.Gestuar(componentInChildren, weightFace, duracionFace);
				RegistroDeFuncionesDeGestos.Cabeza.Gestuar(componentInChildren2, TipoDeGestoDeCabeza.confucion, 1f, weightHead * 0.333f, true);
				RegistroDeFuncionesDeGestos.Hombros.Gestuar(componentInChildren3, TipoDeGestoDeHombro.sacarPecho, 1f, weightHombros * 0.333f, true);
			}

			// Token: 0x06000435 RID: 1077 RVA: 0x00015D57 File Offset: 0x00013F57
			public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, ControladorDeGestosConCabeza headController, ControladorDeGestosConHombros hombrosController, float weightFace, float weightHead, float weightHombros, float duracionFace)
			{
				RegistroDeFuncionesDeGestos.Cara.Sonrreir.Gestuar(fController, weightFace, duracionFace);
				RegistroDeFuncionesDeGestos.Cabeza.Gestuar(headController, TipoDeGestoDeCabeza.confucion, 1f, weightHead * 0.333f, true);
				RegistroDeFuncionesDeGestos.Hombros.Gestuar(hombrosController, TipoDeGestoDeHombro.sacarPecho, 1f, weightHombros * 0.333f, true);
			}
		}

		// Token: 0x0200009D RID: 157
		public static class Lamentar
		{
			// Token: 0x06000436 RID: 1078 RVA: 0x00015D8C File Offset: 0x00013F8C
			public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, ControladorDeGestosConCabeza headController, ControladorDeGestosConHombros hombrosController, float weightFace, float weightHead, float weightHombros, float duracionFace)
			{
				RegistroDeFuncionesDeGestos.Cara.Lamentar.Gestuar(fController, weightFace, duracionFace);
				RegistroDeFuncionesDeGestos.Cabeza.Gestuar(headController, TipoDeGestoDeCabeza.acentuarLado, 1f, weightHead, true);
				RegistroDeFuncionesDeGestos.Hombros.Gestuar(hombrosController, TipoDeGestoDeHombro.demalas, 1f, weightHombros, true);
			}
		}

		// Token: 0x0200009E RID: 158
		public static class Enojar
		{
			// Token: 0x06000437 RID: 1079 RVA: 0x00015DB8 File Offset: 0x00013FB8
			public static void Gestuar(Character female, float weightFace, float weightHead, float weightHombros, float duracionFace)
			{
				if (female == null)
				{
					return;
				}
				ControlladorDeGestosFacialesEmocionales componentInChildren = female.GetComponentInChildren<ControlladorDeGestosFacialesEmocionales>();
				if (componentInChildren == null)
				{
					return;
				}
				ControladorDeGestosConCabeza componentInChildren2 = female.GetComponentInChildren<ControladorDeGestosConCabeza>();
				if (componentInChildren2 == null)
				{
					return;
				}
				ControladorDeGestosConHombros componentInChildren3 = female.GetComponentInChildren<ControladorDeGestosConHombros>();
				if (componentInChildren3 == null)
				{
					return;
				}
				RegistroDeFuncionesDeGestos.Cara.Enojar.Gestuar(componentInChildren, weightFace, duracionFace);
				RegistroDeFuncionesDeGestos.Cabeza.Gestuar(componentInChildren2, TipoDeGestoDeCabeza.dolor, 1.55f.Random(0.15f), weightHead * 0.666f, true);
				RegistroDeFuncionesDeGestos.Hombros.Gestuar(componentInChildren3, TipoDeGestoDeHombro.achiquitar, 1.25f.Random(0.1f), weightHombros * 0.666f, true);
			}

			// Token: 0x06000438 RID: 1080 RVA: 0x00015E48 File Offset: 0x00014048
			public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, ControladorDeGestosConCabeza headController, ControladorDeGestosConHombros hombrosController, float weightFace, float weightHead, float weightHombros, float duracionFace)
			{
				RegistroDeFuncionesDeGestos.Cara.Enojar.Gestuar(fController, weightFace, duracionFace);
				RegistroDeFuncionesDeGestos.Cabeza.Gestuar(headController, TipoDeGestoDeCabeza.dolor, 1.55f.Random(0.15f), weightHead * 0.666f, true);
				RegistroDeFuncionesDeGestos.Hombros.Gestuar(hombrosController, TipoDeGestoDeHombro.achiquitar, 1.25f.Random(0.1f), weightHombros * 0.666f, true);
			}
		}

		// Token: 0x0200009F RID: 159
		public static class Asustar
		{
			// Token: 0x06000439 RID: 1081 RVA: 0x00015EA0 File Offset: 0x000140A0
			public static void Gestuar(Character female, float weightFace, float weightHead, float weightHombros, float duracionFace)
			{
				if (female == null)
				{
					return;
				}
				ControlladorDeGestosFacialesEmocionales componentInChildren = female.GetComponentInChildren<ControlladorDeGestosFacialesEmocionales>();
				if (componentInChildren == null)
				{
					return;
				}
				ControladorDeGestosConCabeza componentInChildren2 = female.GetComponentInChildren<ControladorDeGestosConCabeza>();
				if (componentInChildren2 == null)
				{
					return;
				}
				ControladorDeGestosConHombros componentInChildren3 = female.GetComponentInChildren<ControladorDeGestosConHombros>();
				if (componentInChildren3 == null)
				{
					return;
				}
				float duracionPorCiclo = Singleton<CurvasDeGestosConHombros>.instance.ObtenerDatosDeTipo(TipoDeGestoDeHombro.achiquitar).duracionPorCiclo;
				float duracionPorCiclo2 = Singleton<CurvasDeGestosConCabeza>.instance.ObtenerDatosDeTipo(RegistroDeFuncionesDeGestos.Cabeza.overrrideNext ?? TipoDeGestoDeCabeza.sorpresa).duracionPorCiclo;
				RegistroDeFuncionesDeGestos.Cara.Asustar.Gestuar(componentInChildren, weightFace, duracionFace);
				RegistroDeFuncionesDeGestos.Cabeza.Gestuar(componentInChildren2, TipoDeGestoDeCabeza.sorpresa, Mathf.Clamp(duracionFace, duracionPorCiclo2 * 0.75f, duracionPorCiclo2 * 2f), weightHead, false);
				RegistroDeFuncionesDeGestos.Hombros.Gestuar(componentInChildren3, TipoDeGestoDeHombro.achiquitar, Mathf.Clamp(duracionFace, duracionPorCiclo * 0.75f, duracionPorCiclo * 2f), weightHombros, false);
			}

			// Token: 0x0600043A RID: 1082 RVA: 0x00015F70 File Offset: 0x00014170
			public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, ControladorDeGestosConCabeza headController, ControladorDeGestosConHombros hombrosController, float weightFace, float weightHead, float weightHombros, float duracionFace)
			{
				float duracionPorCiclo = Singleton<CurvasDeGestosConHombros>.instance.ObtenerDatosDeTipo(TipoDeGestoDeHombro.achiquitar).duracionPorCiclo;
				float duracionPorCiclo2 = Singleton<CurvasDeGestosConCabeza>.instance.ObtenerDatosDeTipo(RegistroDeFuncionesDeGestos.Cabeza.overrrideNext ?? TipoDeGestoDeCabeza.sorpresa).duracionPorCiclo;
				RegistroDeFuncionesDeGestos.Cara.Asustar.Gestuar(fController, weightFace, duracionFace);
				RegistroDeFuncionesDeGestos.Cabeza.Gestuar(headController, TipoDeGestoDeCabeza.sorpresa, Mathf.Clamp(duracionFace, duracionPorCiclo2 * 0.75f, duracionPorCiclo2 * 2f), weightHead, false);
				RegistroDeFuncionesDeGestos.Hombros.Gestuar(hombrosController, TipoDeGestoDeHombro.achiquitar, Mathf.Clamp(duracionFace, duracionPorCiclo * 0.75f, duracionPorCiclo * 2f), weightHombros, false);
			}
		}

		// Token: 0x020000A0 RID: 160
		public static class Ojos
		{
			// Token: 0x0600043B RID: 1083 RVA: 0x00016000 File Offset: 0x00014200
			public static void Gestuar(OjosExpresionController ojosController, OjosExpresionController.Tipo tipo, float weight, float duracion)
			{
				if (duracion > 0f && weight > 0f)
				{
					ojosController.Cambiar(tipo, 1, duracion, ControllerPrioridadConfig.interrumpir, weight * 100f * weight.OutPow(1.5f), 1f, 1f);
					return;
				}
				ojosController.Cancelar(tipo);
			}
		}

		// Token: 0x020000A1 RID: 161
		public static class Cara
		{
			// Token: 0x0600043C RID: 1084 RVA: 0x0001604E File Offset: 0x0001424E
			public static void UsarBoca(ControlladorDeGestosFacialesEmocionales fController, float minWeight, float duracion)
			{
				if (duracion > 0f && minWeight > 0f)
				{
					fController.expresionsValuesBoca.durationOverride = duracion;
					fController.expresionsValuesBoca.targetValueByOverrride = minWeight;
					return;
				}
				fController.expresionsValuesBoca.DejarDeUsar();
			}

			// Token: 0x0600043D RID: 1085 RVA: 0x00016084 File Offset: 0x00014284
			public static void Exagerar(ControlladorDeGestosFacialesEmocionales fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo, float duracion, float weight, float minExpresionValue)
			{
				if (duracion > 0f && weight > 0f)
				{
					fController.ExagerarTipoDeExpresionPor(tipo, duracion, weight, minExpresionValue);
					return;
				}
				fController.DejarDeExagerarTipoDeExpresion(tipo);
			}

			// Token: 0x0600043E RID: 1086 RVA: 0x000160A9 File Offset: 0x000142A9
			public static void Suprimir(ControlladorDeGestosFacialesEmocionales fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion tipo, float duracion, float weight)
			{
				if (duracion > 0f && weight > 0f)
				{
					fController.SuprimirTipoDeExpresionPor(tipo, duracion, weight);
					return;
				}
				fController.DejarDeSuprimirTipoDeExpresion(tipo);
			}

			// Token: 0x0600043F RID: 1087 RVA: 0x000160CC File Offset: 0x000142CC
			public static void Exagerar(ControlladorDeGestosFacialesEmocionales fController, float duracion)
			{
				if (duracion > 0f)
				{
					fController.ExagerarPor(duracion);
					return;
				}
				fController.DejarDeExagerar();
			}

			// Token: 0x020000AD RID: 173
			public static class Sorprender
			{
				// Token: 0x0600044B RID: 1099 RVA: 0x0001622C File Offset: 0x0001442C
				public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, ControladorDeGestosDeBoca jawController, OjosExpresionController ojosController, float weight, float duracion, float ojosW = 1f, float jawW = 1f)
				{
					if (duracion > 0f && weight > 0f)
					{
						RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, duracion, weight, Mathf.Lerp(0f, 0.66f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, duracion, Mathf.Lerp(0f, 0.9f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, duracion, Mathf.Lerp(0f, 0.9f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, duracion, Mathf.Lerp(0f, 0.666f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo, duracion, Mathf.Lerp(0f, 0.9f, weight));
						if (jawW > 0f)
						{
							jawController.Gestuar(TiposDeGestosDeBoca.sorprender, jawW * weight.OutPow(1.33f) * 0.75f, 1, ControllerPrioridadConfig.interrumpir, duracion, false, null, 1f, 1f);
						}
						if (ojosW > 0f)
						{
							ojosController.Cambiar(OjosExpresionController.Tipo.agrandar, 1, duracion, ControllerPrioridadConfig.interrumpir, ojosW * 100f * weight.OutPow(1.5f), 1f, 1f);
							return;
						}
					}
					else
					{
						RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, 0f, 0f, 0f);
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, 0f, 0f);
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, 0f, 0f);
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, 0f, 0f);
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo, 0f, 0f);
						jawController.DetenerGesto(TiposDeGestosDeBoca.sorprender);
						ojosController.Cancelar(OjosExpresionController.Tipo.agrandar);
					}
				}
			}

			// Token: 0x020000AE RID: 174
			public static class Sonrreir
			{
				// Token: 0x0600044C RID: 1100 RVA: 0x000163A4 File Offset: 0x000145A4
				public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, float weight, float duracion)
				{
					if (duracion > 0f && weight > 0f)
					{
						RegistroDeFuncionesDeGestos.Cara.UsarBoca(fController, weight, duracion);
						RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, duracion, weight, Mathf.Lerp(0.33f, 1f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, duracion, Mathf.Lerp(0.3f, 0.9f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, duracion, Mathf.Lerp(0.2f, 0.75f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, duracion, Mathf.Lerp(0.1f, 0.5f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo, duracion, Mathf.Lerp(0.3f, 0.9f, weight));
						return;
					}
					RegistroDeFuncionesDeGestos.Cara.UsarBoca(fController, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, 0f, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo, 0f, 0f);
				}
			}

			// Token: 0x020000AF RID: 175
			public static class EnojarLamentar
			{
				// Token: 0x0600044D RID: 1101 RVA: 0x000164B4 File Offset: 0x000146B4
				public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, float weight, float duracion)
				{
					if (duracion > 0f && weight > 0f)
					{
						RegistroDeFuncionesDeGestos.Cara.UsarBoca(fController, weight * 0.75f, duracion);
						RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, duracion, weight, Mathf.Lerp(0.33f, 1f, weight));
						RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, duracion, weight, Mathf.Lerp(0.33f, 1f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, duracion, Mathf.Lerp(0.2f, 0.75f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, duracion, Mathf.Lerp(0.1f, 0.5f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo, duracion, Mathf.Lerp(0.2f, 0.75f, weight));
						return;
					}
					RegistroDeFuncionesDeGestos.Cara.UsarBoca(fController, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, 0f, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, 0f, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo, 0f, 0f);
				}
			}

			// Token: 0x020000B0 RID: 176
			public static class LamentarSonreir
			{
				// Token: 0x0600044E RID: 1102 RVA: 0x000165D0 File Offset: 0x000147D0
				public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, float weight, float duracion)
				{
					if (duracion > 0f && weight > 0f)
					{
						RegistroDeFuncionesDeGestos.Cara.UsarBoca(fController, weight * 1f, duracion);
						RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, duracion, weight, Mathf.Lerp(0.333f, 1f, weight));
						RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, duracion, weight, Mathf.Lerp(0.2f, 0.75f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, duracion, Mathf.Lerp(0.2f, 0.75f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, duracion, Mathf.Lerp(0.1f, 0.5f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo, duracion, Mathf.Lerp(0.2f, 0.75f, weight));
						return;
					}
					RegistroDeFuncionesDeGestos.Cara.UsarBoca(fController, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, 0f, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, 0f, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo, 0f, 0f);
				}
			}

			// Token: 0x020000B1 RID: 177
			public static class Lamentar
			{
				// Token: 0x0600044F RID: 1103 RVA: 0x000166EC File Offset: 0x000148EC
				public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, float weight, float duracion)
				{
					if (duracion > 0f && weight > 0f)
					{
						RegistroDeFuncionesDeGestos.Cara.UsarBoca(fController, weight * 0.75f, duracion);
						RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, duracion, weight, Mathf.Lerp(0.33f, 1f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, duracion, Mathf.Lerp(0.2f, 0.75f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, duracion, Mathf.Lerp(0.2f, 0.75f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, duracion, Mathf.Lerp(0.1f, 0.5f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo, duracion, Mathf.Lerp(0.2f, 0.75f, weight));
						return;
					}
					RegistroDeFuncionesDeGestos.Cara.UsarBoca(fController, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, 0f, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo, 0f, 0f);
				}
			}

			// Token: 0x020000B2 RID: 178
			public static class Enojar
			{
				// Token: 0x06000450 RID: 1104 RVA: 0x00016804 File Offset: 0x00014A04
				public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, float weight, float duracion)
				{
					if (duracion > 0f && weight > 0f)
					{
						RegistroDeFuncionesDeGestos.Cara.UsarBoca(fController, weight, duracion);
						RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, duracion, weight, Mathf.Lerp(0.33f, 1f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, duracion, Mathf.Lerp(0.3f, 0.9f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, duracion, Mathf.Lerp(0.3f, 0.9f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, duracion, Mathf.Lerp(0.2f, 0.75f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo, duracion, Mathf.Lerp(0.3f, 0.9f, weight));
						return;
					}
					RegistroDeFuncionesDeGestos.Cara.UsarBoca(fController, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, 0f, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo, 0f, 0f);
				}
			}

			// Token: 0x020000B3 RID: 179
			public static class Asustar
			{
				// Token: 0x06000451 RID: 1105 RVA: 0x00016914 File Offset: 0x00014B14
				public static void Gestuar(ControlladorDeGestosFacialesEmocionales fController, float weight, float duracion)
				{
					if (duracion > 0f && weight > 0f)
					{
						RegistroDeFuncionesDeGestos.Cara.UsarBoca(fController, weight, duracion);
						RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo, duracion, weight, Mathf.Lerp(0.33f, 1f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, duracion, Mathf.Lerp(0.3f, 0.9f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, duracion, Mathf.Lerp(0.3f, 0.9f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, duracion, Mathf.Lerp(0.3f, 0.9f, weight));
						RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, duracion, Mathf.Lerp(0.2f, 0.75f, weight));
						return;
					}
					RegistroDeFuncionesDeGestos.Cara.UsarBoca(fController, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Exagerar(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.miedo, 0f, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.rabia, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.dolor, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.alegria, 0f, 0f);
					RegistroDeFuncionesDeGestos.Cara.Suprimir(fController, ControlladorDeGestosFacialesEmocionales.TipoDeExpresion.placer, 0f, 0f);
				}
			}
		}

		// Token: 0x020000A2 RID: 162
		public static class Hombros
		{
			// Token: 0x06000440 RID: 1088 RVA: 0x000160E4 File Offset: 0x000142E4
			public static void Gestuar(ControladorDeGestosConHombros fController, TipoDeGestoDeHombro tipo, float duracion, float amplitudMod, bool duracionEsMod = true)
			{
				if (duracion <= 0f || amplitudMod <= 0f)
				{
					fController.currentStado.DetenerOrdenEnSlot(0);
					return;
				}
				if (duracionEsMod)
				{
					duracion = Mathf.Clamp(duracion, 0.666f, 1.5f);
					fController.Gestuar(tipo, amplitudMod, duracion, ControllerPrioridadConfig.interrumpir, false);
					return;
				}
				fController.GestuarOverridingDuracion(tipo, amplitudMod, duracion, ControllerPrioridadConfig.interrumpir, false);
			}
		}

		// Token: 0x020000A3 RID: 163
		public static class Cabeza
		{
			// Token: 0x06000441 RID: 1089 RVA: 0x00016140 File Offset: 0x00014340
			public static void Gestuar(ControladorDeGestosConCabeza fController, TipoDeGestoDeCabeza tipo, float duracion, float amplitudMod, bool duracionEsMod = true)
			{
				tipo = RegistroDeFuncionesDeGestos.Cabeza.overrrideNext ?? tipo;
				amplitudMod = ((RegistroDeFuncionesDeGestos.Cabeza.overrrideNext != null) ? Mathf.Lerp(amplitudMod, 1f, 0.8f) : amplitudMod);
				if (duracion > 0f && amplitudMod > 0f)
				{
					if (duracionEsMod)
					{
						duracion = Mathf.Clamp(duracion, 0.666f, 1.5f);
						fController.Gestuar(tipo, amplitudMod, duracion, ControllerPrioridadConfig.interrumpir, false);
					}
					else
					{
						fController.GestuarOverridingDuracion(tipo, amplitudMod, duracion, ControllerPrioridadConfig.interrumpir, false);
					}
				}
				else
				{
					fController.currentStado.DetenerOrdenEnSlot(0);
				}
				RegistroDeFuncionesDeGestos.Cabeza.overrrideNext = null;
			}

			// Token: 0x040001BD RID: 445
			public static TipoDeGestoDeCabeza? overrrideNext;
		}
	}
}
