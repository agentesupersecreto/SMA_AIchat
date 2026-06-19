using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Scenas
{
	// Token: 0x020000C4 RID: 196
	public class InteraccionesEnScenaTester : AplicableBehaviour
	{
		// Token: 0x0600049E RID: 1182 RVA: 0x000133CA File Offset: 0x000115CA
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (!Application.isEditor)
			{
				Debug.LogError("tester se fue a build");
			}
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x000133E3 File Offset: 0x000115E3
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Singleton<InteraccionesEnScena>.instance.onInteraction += this.Instance_onInteraction;
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00013404 File Offset: 0x00011604
		private void Instance_onInteraction(ref Interaction newInteraction, ICharactersSceneInteractions Interactions, SceneCharacter from, SceneCharacter to, ISceneInteractions sender)
		{
			Debug.LogWarning(string.Concat(new string[]
			{
				newInteraction.interationReceivedType.ToString(),
				" ",
				newInteraction.emotion.ToString(),
				" ",
				newInteraction.fromPart.ToString(),
				" ",
				newInteraction.toPart.ToString(),
				" ",
				newInteraction.damagePercentageDone.ToString()
			}));
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x000134A0 File Offset: 0x000116A0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Singleton<InteraccionesEnScena>.instance.onInteraction -= this.Instance_onInteraction;
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x000134BF File Offset: 0x000116BF
		private IEnumerator TestingRutine()
		{
			this.m_testing = true;
			Character mainChar = CurrentMainCharacter<CurrentMainChar, MainChar>.current.character;
			Character femChar = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current.character;
			SceneCharacter mainCharScene = mainChar.GetComponent<SceneCharacter>();
			SceneCharacter femCharScene = femChar.GetComponent<SceneCharacter>();
			ICalculadorSimulable[] simulables = femChar.GetComponentsInChildren<ICalculadorSimulable>();
			EmocionesFemeninasValues emos = EmocionesFemeninasValues.emptyValid;
			Dictionary<Emotion, float> generadosDeEmocion = new Dictionary<Emotion, float>();
			float time = Time.time;
			float time2 = Time.time;
			int largoDeTest = 150;
			foreach (InteraccionesEnScenaTester.TestItem testItem in this.testes)
			{
				testItem.generado = 0f;
				testItem.generadoResultadoArchivado = 0f;
				testItem.generadoResultadoPasando = 0f;
			}
			int num;
			for (int testIndex = 0; testIndex < largoDeTest; testIndex = num + 1)
			{
				this.Test(mainChar, mainCharScene, femChar, femCharScene, this.testes, simulables, new EmocionesFemeninasValues?(emos), generadosDeEmocion);
				yield return null;
				num = testIndex;
			}
			yield return null;
			this.UpdatePasandoGenerado(mainChar, femChar, this.testes);
			this.CheckPasandoGenerado();
			yield return new WaitForSeconds(0.29997f);
			int largoDeTest2 = 90;
			InteraccionesEnScenaTester.TestItem[] some = this.testes.RandomTake(Mathf.CeilToInt((float)(this.testes.Count / 2))).ToArray<InteraccionesEnScenaTester.TestItem>();
			for (int testIndex = 0; testIndex < largoDeTest2; testIndex = num + 1)
			{
				this.Test(mainChar, mainCharScene, femChar, femCharScene, some, simulables, new EmocionesFemeninasValues?(emos), generadosDeEmocion);
				yield return null;
				num = testIndex;
			}
			yield return null;
			this.UpdatePasandoGenerado(mainChar, femChar, some);
			this.CheckPasandoGenerado();
			yield return new WaitForSeconds(0.29997f);
			int largoDeTest3 = 210;
			InteraccionesEnScenaTester.TestItem[] some2 = some.RandomTake(Mathf.CeilToInt((float)(some.Length / 2))).ToArray<InteraccionesEnScenaTester.TestItem>();
			for (int testIndex = 0; testIndex < largoDeTest3; testIndex = num + 1)
			{
				this.Test(mainChar, mainCharScene, femChar, femCharScene, some2, simulables, new EmocionesFemeninasValues?(emos), generadosDeEmocion);
				yield return null;
				num = testIndex;
			}
			yield return null;
			this.UpdatePasandoGenerado(mainChar, femChar, some2);
			this.CheckPasandoGenerado();
			yield return new WaitForSeconds(0.29997f);
			yield return new WaitForSeconds(1.6665f);
			ICharactersSceneInteractionsArchived mainArchivedInteractions = Singleton<InteraccionesEnScena>.instance.GetMainArchivedInteractions(mainChar, femChar);
			foreach (InteraccionesEnScenaTester.TestItem testItem2 in this.testes)
			{
				TriggeringBodyPart partSimple = testItem2.estimulante.GetPartSimple();
				SensitiveBodyPart part = testItem2.estimulada.GetPart();
				int num2 = testItem2.estimulante.ObtenerTipoDeEstimulo(testItem2.type, testItem2.estimulada, false, null);
				InterationReceivedType interationReceivedType = testItem2.type.GetInterationReceivedType(num2, testItem2.direccion, testItem2.estimulada, testItem2.estimulante);
				Emotion emotion = testItem2.emo.Parse();
				Interaction interaction;
				mainArchivedInteractions.Peek(partSimple, part, interationReceivedType, emotion, false, out interaction);
				Interaction interaction2;
				mainArchivedInteractions.Peek(partSimple, part, interationReceivedType, emotion, true, out interaction2);
				testItem2.generadoResultadoArchivado = interaction.damagePercentageDone + interaction2.damagePercentageDone;
			}
			foreach (InteraccionesEnScenaTester.TestItem testItem3 in this.testes)
			{
				if (!ExtendedMonoBehaviour.AlmostEqual(testItem3.generado, testItem3.generadoResultadoArchivado, 0.001f))
				{
					Debug.LogError("archivado fallo, se esperaba " + testItem3.generado.ToString() + " se obtuvo " + testItem3.generadoResultadoArchivado.ToString());
				}
			}
			foreach (KeyValuePair<Emotion, float> keyValuePair in generadosDeEmocion)
			{
				Interaction interaction3;
				mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.All, keyValuePair.Key, false, out interaction3);
				Interaction interaction4;
				mainArchivedInteractions.Peek(TriggeringBodyPart.All, SensitiveBodyPart.All, InterationReceivedType.All, keyValuePair.Key, true, out interaction4);
				float num3 = interaction3.damagePercentageDone + interaction4.damagePercentageDone;
				if (!ExtendedMonoBehaviour.AlmostEqual(keyValuePair.Value, num3, 0.001f))
				{
					Debug.LogError("archivado fallo, se esperaba " + keyValuePair.Value.ToString() + " se obtuvo " + num3.ToString());
				}
			}
			this.m_testing = false;
			yield break;
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x000134D0 File Offset: 0x000116D0
		private void UpdatePasandoGenerado(ICharacterUnico mainChar, ICharacterUnico femChar, IEnumerable<InteraccionesEnScenaTester.TestItem> items)
		{
			ICharactersSceneInteractions takingPlaceInteractions = Singleton<InteraccionesEnScena>.instance.GetTakingPlaceInteractions(mainChar, femChar);
			foreach (InteraccionesEnScenaTester.TestItem testItem in items)
			{
				TriggeringBodyPart partSimple = testItem.estimulante.GetPartSimple();
				SensitiveBodyPart part = testItem.estimulada.GetPart();
				int num = testItem.estimulante.ObtenerTipoDeEstimulo(testItem.type, testItem.estimulada, false, null);
				InterationReceivedType interationReceivedType = testItem.type.GetInterationReceivedType(num, testItem.direccion, testItem.estimulada, testItem.estimulante);
				Emotion emotion = testItem.emo.Parse();
				Interaction interaction;
				takingPlaceInteractions.Peek(partSimple, part, interationReceivedType, emotion, false, out interaction);
				Interaction interaction2;
				takingPlaceInteractions.Peek(partSimple, part, interationReceivedType, emotion, true, out interaction2);
				testItem.generadoResultadoPasando = interaction.damagePercentageDone + interaction2.damagePercentageDone;
			}
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x000135BC File Offset: 0x000117BC
		private void CheckPasandoGenerado()
		{
			foreach (InteraccionesEnScenaTester.TestItem testItem in this.testes)
			{
				if (!ExtendedMonoBehaviour.AlmostEqual(testItem.generado, testItem.generadoResultadoPasando, 0.001f))
				{
					Debug.LogError("pasando fallo, se esperaba " + testItem.generado.ToString() + " se obtuvo " + testItem.generadoResultadoPasando.ToString());
				}
			}
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x0001364C File Offset: 0x0001184C
		private void Test(ICharacterUnico mainChar, SceneCharacter mainCharScene, ICharacterUnico femChar, SceneCharacter femCharScene, IEnumerable<InteraccionesEnScenaTester.TestItem> items, ICalculadorSimulable[] simulables, EmocionesFemeninasValues? emos, Dictionary<Emotion, float> generadoDeEmocion)
		{
			using (IEnumerator<InteraccionesEnScenaTester.TestItem> enumerator = items.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					InteraccionesEnScenaTester.TestItem item = enumerator.Current;
					ICalculadorSimulable[] array = simulables.Where((ICalculadorSimulable s) => s.direccionDeEstimulo == item.direccion && s.reaccion == item.emo && s.tipoDeEstimulo == item.type && !s.esGolpe).ToArray<ICalculadorSimulable>();
					if (array.Length == 0)
					{
						Debug.LogError("no existio simulador para item");
					}
					else
					{
						if (array.Length > 1)
						{
							Debug.LogError("Multiple tipos de calculador iguales");
						}
						ICalculadorSimulable calculadorSimulable = array.FirstOrDefault<ICalculadorSimulable>();
						float num = 0f;
						if (calculadorSimulable != null)
						{
							RangeValueV2 rangeValueV;
							UmbralBasico.Estado estado;
							UmbralBasico.Estado estado2;
							ICalculoDeEstimuloCompleto calculoDeEstimuloCompleto;
							calculadorSimulable.SimularGlobal(item.estimulante, item.estimulada, Time.deltaTime, out rangeValueV, out estado, out estado2, emos, out calculoDeEstimuloCompleto);
							for (int i = 0; i < calculoDeEstimuloCompleto.cantidadDeEstados; i++)
							{
								UmbralBasico.Estado estado3;
								calculoDeEstimuloCompleto.GetEstadoCopia(i, out estado3);
								float num2 = Random.Range(0.001f, 0.1f);
								estado3.SobreEscribirEstimulacionGeneradaEnFrame(num2, num2, 1f);
								calculoDeEstimuloCompleto.SobreEscribirEstado(i, ref estado3);
								num += num2;
							}
							Singleton<InteraccionesEnScena>.instance.Registrar(mainChar, mainCharScene, femChar, femCharScene, calculoDeEstimuloCompleto);
						}
						generadoDeEmocion.AddOrSum(item.emo.Parse(), num);
						item.generado += num;
					}
				}
			}
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x000137B8 File Offset: 0x000119B8
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			if (this.m_testing)
			{
				return;
			}
			base.StartCoroutine(this.TestingRutine());
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x000137D6 File Offset: 0x000119D6
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Start TEst"
			};
		}

		// Token: 0x04000330 RID: 816
		[SerializeField]
		[ReadOnlyUI]
		private bool m_testing;

		// Token: 0x04000331 RID: 817
		public List<InteraccionesEnScenaTester.TestItem> testes = new List<InteraccionesEnScenaTester.TestItem>();

		// Token: 0x020000C5 RID: 197
		[Serializable]
		public class TestItem
		{
			// Token: 0x04000332 RID: 818
			public ParteQuePuedeEstimular estimulante;

			// Token: 0x04000333 RID: 819
			public ParteDelCuerpoHumano estimulada;

			// Token: 0x04000334 RID: 820
			public TipoDeEstimulo type;

			// Token: 0x04000335 RID: 821
			public ReaccionHumana emo;

			// Token: 0x04000336 RID: 822
			public DireccionDeEstimulo direccion;

			// Token: 0x04000337 RID: 823
			[ReadOnlyUI]
			public float generado;

			// Token: 0x04000338 RID: 824
			[ReadOnlyUI]
			public float generadoResultadoPasando;

			// Token: 0x04000339 RID: 825
			[ReadOnlyUI]
			public float generadoResultadoArchivado;
		}
	}
}
