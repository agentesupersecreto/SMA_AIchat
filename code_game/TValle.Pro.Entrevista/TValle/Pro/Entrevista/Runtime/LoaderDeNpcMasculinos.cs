using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Base.Plugins.Runtime;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets.TValle.Pro.Entrevista.Runtime.General.Clases;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Tools.Runtime.SMA.Jobs;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Clases;
using Assets._ReusableScripts.CuchiCuchi.Ropa.Globales;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics.Mapas;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.NPCs;
using RandomNameGeneratorLibrary;
using RootMotion;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime
{
	// Token: 0x02000028 RID: 40
	public static class LoaderDeNpcMasculinos
	{
		// Token: 0x06000180 RID: 384 RVA: 0x00008B92 File Offset: 0x00006D92
		public static void DestroyCharacter(string npcID)
		{
			Object.Destroy(Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales.Singleton<NPC_to_Character>.instance.TryGet(npcID).GetComponentInParent<ICharacterRoot>().transform.gameObject);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00008BB4 File Offset: 0x00006DB4
		public static void EraseNPCFromMemory(string npcID)
		{
			MaleCharAparienciaMemory.Borrar(npcID);
			MaleCharAparienciaMemory.BorrarPleasure(npcID);
			MaleCharAparienciaMemory.BorrarEyaculation(npcID);
			MaleCharRopaMemory.Borrar(npcID);
			CharacterWallet.Borrar(npcID);
			string text = "root/NPC/" + npcID;
			GlobalSingletonV2<MemoriaJson>.instance.RemoverDeep(text);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x00008BF8 File Offset: 0x00006DF8
		public static bool MemoriaContiene(IMemoria memoria, string npcID)
		{
			if (string.IsNullOrEmpty(npcID))
			{
				return false;
			}
			string text = "root/NPC/" + npcID;
			return memoria.LeerDeep(text, false) != null;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x00008C28 File Offset: 0x00006E28
		public static ICharacterIdentificable ReadFromMemoryCharacter(string npcID, Vector3 position, Quaternion rotation, bool disabledAndNotBinded, out string nuevoNombreCompleto, out string nuevoNombre, out string nuevoApellido, out Guid ID)
		{
			if (!LoaderDeNpcMasculinos.MemoriaContiene(GlobalSingletonV2<MemoriaJson>.instance, npcID))
			{
				throw new InvalidOperationException(npcID + " NPC is not in memory");
			}
			ICharacterIdentificable @default = LoaderDeNpcMasculinos.GetDefault(position, rotation, disabledAndNotBinded);
			string text = "root/NPC/" + npcID;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text, false);
			nuevoNombre = jsonMemoryNode.FindData("Nombre");
			nuevoApellido = jsonMemoryNode.FindData("Apellido");
			nuevoNombreCompleto = nuevoNombre + " " + nuevoApellido;
			ID = Guid.Parse(npcID);
			if (!disabledAndNotBinded)
			{
				@default.Bind(nuevoNombreCompleto, nuevoNombre, nuevoApellido, ID);
			}
			return @default;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x00008CCB File Offset: 0x00006ECB
		public static void GetNombres(string npcID, out string nombre, out string apellido, out string nombreCompleto)
		{
			MemoriaDeSMAGamePlay.GetNombres(GlobalSingletonV2<MemoriaJson>.instance, npcID, out nombre, out apellido, out nombreCompleto);
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00008CDC File Offset: 0x00006EDC
		public static ICharacterIdentificable GetDefault(Vector3 position, Quaternion rotation, bool disabled)
		{
			bool activeSelf = MapaSingleton<CharactersPrefabsGetter>.instance.maleCharacterDefault.activeSelf;
			ICharacterIdentificable characterIdentificable;
			try
			{
				MapaSingleton<CharactersPrefabsGetter>.instance.maleCharacterDefault.SetActive(!disabled);
				Quaternion rotation2 = MapaSingleton<CharactersPrefabsGetter>.instance.maleCharacterDefault.transform.rotation;
				GameObject gameObject = Object.Instantiate<GameObject>(MapaSingleton<CharactersPrefabsGetter>.instance.maleCharacterDefault, position, rotation2);
				ICharacterIdentificable componentInChildren = gameObject.GetComponentInChildren<ICharacterIdentificable>(true);
				if (componentInChildren == null)
				{
					Object.Destroy(gameObject);
					throw new ArgumentNullException("asCharacter", "asCharacter null reference.");
				}
				GlobalUpdater.instancia.StartCoroutine(LoaderDeNpcMasculinos.SetRotationToNewInstance(componentInChildren, position, rotation));
				characterIdentificable = componentInChildren;
			}
			finally
			{
				if (activeSelf != MapaSingleton<CharactersPrefabsGetter>.instance.maleCharacterDefault.activeSelf)
				{
					MapaSingleton<CharactersPrefabsGetter>.instance.maleCharacterDefault.SetActive(activeSelf);
				}
			}
			return characterIdentificable;
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00008DA4 File Offset: 0x00006FA4
		private static IEnumerator SetRotationToNewInstance(ICharacterIdentificable newInstance, Vector3 position, Quaternion rotation)
		{
			while (((newInstance != null) ? newInstance.transform : null) != null && !newInstance.isStared)
			{
				yield return null;
			}
			if (((newInstance != null) ? newInstance.transform : null) == null)
			{
				yield break;
			}
			Penetrador[] penetrators = newInstance.GetComponentsInChildren<Penetrador>(true);
			bool allStared = false;
			while (((newInstance != null) ? newInstance.transform : null) != null && !allStared)
			{
				foreach (Penetrador penetrador in penetrators)
				{
					allStared = ((penetrador != null) ? new bool?(penetrador.isStared) : null).GetValueOrDefault(true);
					if (!allStared)
					{
						break;
					}
				}
				yield return null;
			}
			SolverManager[] solvers = newInstance.GetComponentsInChildren<SolverManager>(false);
			allStared = false;
			while (((newInstance != null) ? newInstance.transform : null) != null && !allStared)
			{
				foreach (SolverManager solverManager in solvers)
				{
					allStared = ((solverManager != null) ? new bool?(solverManager.esSolverIniciado) : null).GetValueOrDefault(true);
					if (!allStared)
					{
						break;
					}
				}
				yield return null;
			}
			yield return new WaitForSeconds(0.1f);
			if (((newInstance != null) ? newInstance.transform : null) == null)
			{
				yield break;
			}
			newInstance.SetPositionAndRotation(position, rotation);
			yield break;
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00008DC4 File Offset: 0x00006FC4
		public static ICharacterIdentificable GenerateRandomCharacter(Vector3 position, Quaternion rotation, bool disabledAndNotBinded, out string nuevoNombreCompleto, out string nuevoNombre, out string nuevoApellido, out Guid ID, IMaleRandomGeneratorOverrider overrides, string conjuntoID)
		{
			ID = Guid.NewGuid();
			string text = ID.ToString();
			PersonNameGenerator personNameGenerator = new PersonNameGenerator(LoaderDeNpcMasculinos.m_randomGen);
			nuevoNombre = personNameGenerator.GenerateRandomMaleFirstName();
			nuevoApellido = personNameGenerator.GenerateRandomLastName();
			nuevoNombreCompleto = nuevoNombre + " " + nuevoApellido;
			string text2 = "root/NPC/" + text;
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep(text2, true);
			jsonMemoryNode.AddData("Nombre", nuevoNombre, true);
			jsonMemoryNode.AddData("Apellido", nuevoApellido, true);
			MaleCharAparienciaMemory.Registrar(text, LoaderDeNpcMasculinos.GetFatValue(((overrides != null) ? overrides.fat : null) ?? Random.value), LoaderDeNpcMasculinos.GetThinValue(((overrides != null) ? overrides.thin : null) ?? Random.value), LoaderDeNpcMasculinos.GetMuscleValue(((overrides != null) ? overrides.muscle : null) ?? Random.value), LoaderDeNpcMasculinos.GetOldValue(((overrides != null) ? overrides.old : null) ?? Random.value), LoaderDeNpcMasculinos.GetSaturationValue(((overrides != null) ? overrides.s : null) ?? Random.value), LoaderDeNpcMasculinos.GetValueValue(((overrides != null) ? overrides.v : null) ?? Random.value), LoaderDeNpcMasculinos.GetHueValue(((overrides != null) ? overrides.h : null) ?? Random.value), LoaderDeNpcMasculinos.GetHeightValue(((overrides != null) ? overrides.height : null) ?? Random.value), LoaderDeNpcMasculinos.GetPackageValue(((overrides != null) ? overrides.package : null) ?? Random.value), LoaderDeNpcMasculinos.GetDickSizeValue(((overrides != null) ? overrides.dickSize : null) ?? Random.value), LoaderDeNpcMasculinos.GetDickGirthValue(((overrides != null) ? overrides.dickGirth : null) ?? Random.value), (((overrides != null) ? overrides.dickStiffness : null) ?? Random.value) * 100f);
			MaleCharAparienciaMemory.RegistrarPleasure(text, 100f * (((overrides != null) ? overrides.pleasureGain : null) ?? Random.value), 100f * (((overrides != null) ? overrides.pleasureInterExp : null) ?? Random.value), 100f * (((overrides != null) ? overrides.pleasureInterInc : null) ?? Random.value), 100f * (((overrides != null) ? overrides.pleasureMaxValue : null) ?? Random.value));
			MaleCharAparienciaMemory.RegistrarEyaculation(text, 100f * (((overrides != null) ? overrides.eyacTimes : null) ?? Random.value), 100f * (((overrides != null) ? overrides.eyacAmount : null) ?? Random.value));
			float num = ((overrides != null) ? overrides.clothes : null) ?? Random.value;
			LoaderDeNpcMasculinos.RandomGeneratorOverrider? randomGeneratorOverrider;
			CharacterWallet.Registrar(text, (LoaderDeNpcMasculinos.GetMoneyValue(((overrides != null) ? overrides.money : null) ?? num) * ((overrides is LoaderDeNpcMasculinos.RandomGeneratorOverrider?) ? randomGeneratorOverrider.GetValueOrDefault().moneyMod : null)) ?? 1f);
			ItemQuality itemQuality = (ItemQuality)Mathf.RoundToInt(Mathf.Lerp(4f, 11f, num));
			if (string.IsNullOrEmpty(conjuntoID))
			{
				List<Pieza> list = new List<Pieza>();
				Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales.Singleton<GeneradorDeConjuntosDeRopaAleatoriosMasculinos>.instance.GenerarRandom(list, true, itemQuality, 50f);
				MaleCharRopaMemory.Registrar(text, new ConjuntoDeRopa
				{
					piezas = list
				});
			}
			else
			{
				MapaConjuntoDeRopa conjunto = AsyncSingleton<ConjuntosDeRopa>.instance.GetConjunto(conjuntoID);
				MaleCharRopaMemory.Registrar(text, conjunto);
			}
			ICharacterIdentificable @default = LoaderDeNpcMasculinos.GetDefault(position, rotation, disabledAndNotBinded);
			if (!disabledAndNotBinded)
			{
				@default.Bind(nuevoNombreCompleto, nuevoNombre, nuevoApellido, ID);
			}
			return @default;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000938A File Offset: 0x0000758A
		public static void SaveToMemory(IMemoria memory, ICharacter character)
		{
			LoaderDeNpc.SaveToMemory(memory, character);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00009393 File Offset: 0x00007593
		public static float GetFatValue(float slimness)
		{
			return MathfExtension.LerpConMedio(40f, 15f, 0f, slimness);
		}

		// Token: 0x0600018A RID: 394 RVA: 0x000093AA File Offset: 0x000075AA
		public static float GetThinValue(float slimness)
		{
			return MathfExtension.LerpConMedio(0f, 20f, 50f, slimness);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x000093C1 File Offset: 0x000075C1
		public static float GetMuscleValue(float musculos)
		{
			return MathfExtension.LerpConMedio(0f, 20f, 100f, musculos);
		}

		// Token: 0x0600018C RID: 396 RVA: 0x000093D8 File Offset: 0x000075D8
		public static float GetOldValue(float youngness)
		{
			return MathfExtension.LerpConMedio(100f, 50f, 0f, youngness);
		}

		// Token: 0x0600018D RID: 397 RVA: 0x000093EF File Offset: 0x000075EF
		public static float GetSaturationValue(float skinColor)
		{
			return MathfExtension.LerpConMedio(0.8f, 1.2f, 1.5f, skinColor);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x00009406 File Offset: 0x00007606
		public static float GetValueValue(float skinColor)
		{
			return Mathf.Lerp(1f, 0.1f, skinColor.InPow(3f));
		}

		// Token: 0x0600018F RID: 399 RVA: 0x00009422 File Offset: 0x00007622
		public static float GetHueValue(float skinColor)
		{
			return Mathf.Lerp(0.9f, 1.1f, skinColor.OutPow(2f));
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000943E File Offset: 0x0000763E
		public static float GetHeightValue(float altura)
		{
			return MathfExtension.LerpConMedio(40f, 45f, 60f, altura);
		}

		// Token: 0x06000191 RID: 401 RVA: 0x00009455 File Offset: 0x00007655
		public static float GetPackageValue(float dickSize)
		{
			return MathfExtension.LerpConMedio(0f, 25f, 100f, dickSize);
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000946C File Offset: 0x0000766C
		public static float GetDickSizeValue(float dickSize)
		{
			return MathfExtension.LerpConMedio(12f, 50f, 59f, dickSize);
		}

		// Token: 0x06000193 RID: 403 RVA: 0x00009483 File Offset: 0x00007683
		public static float GetDickGirthValue(float dickSize)
		{
			return MathfExtension.LerpConMedio(75f, 50f, 45f, dickSize);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000949A File Offset: 0x0000769A
		public static float GetMoneyValue(float money)
		{
			return MathfExtension.LerpConMedio(150f, 750f, 2500f, money);
		}

		// Token: 0x040000E8 RID: 232
		private static Random m_randomGen = new Random(Guid.NewGuid().GetHashCode());

		// Token: 0x040000E9 RID: 233
		public const float MinMoney = 150f;

		// Token: 0x040000EA RID: 234
		public const float MedMoney = 750f;

		// Token: 0x040000EB RID: 235
		public const float MaxMoney = 2500f;

		// Token: 0x02000160 RID: 352
		public struct RandomGeneratorOverrider : IMaleRandomGeneratorOverrider
		{
			// Token: 0x1700019F RID: 415
			// (get) Token: 0x06000B96 RID: 2966 RVA: 0x0003B221 File Offset: 0x00039421
			float? IMaleRandomGeneratorOverrider.s
			{
				get
				{
					return this.s;
				}
			}

			// Token: 0x170001A0 RID: 416
			// (get) Token: 0x06000B97 RID: 2967 RVA: 0x0003B229 File Offset: 0x00039429
			float? IMaleRandomGeneratorOverrider.v
			{
				get
				{
					return this.v;
				}
			}

			// Token: 0x170001A1 RID: 417
			// (get) Token: 0x06000B98 RID: 2968 RVA: 0x0003B231 File Offset: 0x00039431
			float? IMaleRandomGeneratorOverrider.h
			{
				get
				{
					return this.h;
				}
			}

			// Token: 0x170001A2 RID: 418
			// (get) Token: 0x06000B99 RID: 2969 RVA: 0x0003B239 File Offset: 0x00039439
			float? IMaleRandomGeneratorOverrider.fat
			{
				get
				{
					return this.fat;
				}
			}

			// Token: 0x170001A3 RID: 419
			// (get) Token: 0x06000B9A RID: 2970 RVA: 0x0003B241 File Offset: 0x00039441
			float? IMaleRandomGeneratorOverrider.thin
			{
				get
				{
					return this.thin;
				}
			}

			// Token: 0x170001A4 RID: 420
			// (get) Token: 0x06000B9B RID: 2971 RVA: 0x0003B249 File Offset: 0x00039449
			float? IMaleRandomGeneratorOverrider.muscle
			{
				get
				{
					return this.muscle;
				}
			}

			// Token: 0x170001A5 RID: 421
			// (get) Token: 0x06000B9C RID: 2972 RVA: 0x0003B251 File Offset: 0x00039451
			float? IMaleRandomGeneratorOverrider.old
			{
				get
				{
					return this.old;
				}
			}

			// Token: 0x170001A6 RID: 422
			// (get) Token: 0x06000B9D RID: 2973 RVA: 0x0003B259 File Offset: 0x00039459
			float? IMaleRandomGeneratorOverrider.height
			{
				get
				{
					return this.height;
				}
			}

			// Token: 0x170001A7 RID: 423
			// (get) Token: 0x06000B9E RID: 2974 RVA: 0x0003B261 File Offset: 0x00039461
			float? IMaleRandomGeneratorOverrider.package
			{
				get
				{
					return this.package;
				}
			}

			// Token: 0x170001A8 RID: 424
			// (get) Token: 0x06000B9F RID: 2975 RVA: 0x0003B269 File Offset: 0x00039469
			float? IMaleRandomGeneratorOverrider.dickSize
			{
				get
				{
					return this.dickSize;
				}
			}

			// Token: 0x170001A9 RID: 425
			// (get) Token: 0x06000BA0 RID: 2976 RVA: 0x0003B271 File Offset: 0x00039471
			float? IMaleRandomGeneratorOverrider.dickGirth
			{
				get
				{
					return this.dickGirth;
				}
			}

			// Token: 0x170001AA RID: 426
			// (get) Token: 0x06000BA1 RID: 2977 RVA: 0x0003B279 File Offset: 0x00039479
			float? IMaleRandomGeneratorOverrider.dickStiffness
			{
				get
				{
					return this.dickStiffness;
				}
			}

			// Token: 0x170001AB RID: 427
			// (get) Token: 0x06000BA2 RID: 2978 RVA: 0x0003B281 File Offset: 0x00039481
			float? IMaleRandomGeneratorOverrider.money
			{
				get
				{
					return this.money;
				}
			}

			// Token: 0x170001AC RID: 428
			// (get) Token: 0x06000BA3 RID: 2979 RVA: 0x0003B289 File Offset: 0x00039489
			float? IMaleRandomGeneratorOverrider.clothes
			{
				get
				{
					return this.clothes;
				}
			}

			// Token: 0x170001AD RID: 429
			// (get) Token: 0x06000BA4 RID: 2980 RVA: 0x0003B291 File Offset: 0x00039491
			float? IMaleRandomGeneratorOverrider.pleasureGain
			{
				get
				{
					return this.pleasureGain;
				}
			}

			// Token: 0x170001AE RID: 430
			// (get) Token: 0x06000BA5 RID: 2981 RVA: 0x0003B299 File Offset: 0x00039499
			float? IMaleRandomGeneratorOverrider.pleasureInterExp
			{
				get
				{
					return this.pleasureInterExp;
				}
			}

			// Token: 0x170001AF RID: 431
			// (get) Token: 0x06000BA6 RID: 2982 RVA: 0x0003B2A1 File Offset: 0x000394A1
			float? IMaleRandomGeneratorOverrider.pleasureInterInc
			{
				get
				{
					return this.pleasureInterInc;
				}
			}

			// Token: 0x170001B0 RID: 432
			// (get) Token: 0x06000BA7 RID: 2983 RVA: 0x0003B2A9 File Offset: 0x000394A9
			float? IMaleRandomGeneratorOverrider.pleasureMaxValue
			{
				get
				{
					return this.pleasureMaxValue;
				}
			}

			// Token: 0x170001B1 RID: 433
			// (get) Token: 0x06000BA8 RID: 2984 RVA: 0x0003B2B1 File Offset: 0x000394B1
			float? IMaleRandomGeneratorOverrider.eyacTimes
			{
				get
				{
					return this.eyacTimes;
				}
			}

			// Token: 0x170001B2 RID: 434
			// (get) Token: 0x06000BA9 RID: 2985 RVA: 0x0003B2B9 File Offset: 0x000394B9
			float? IMaleRandomGeneratorOverrider.eyacAmount
			{
				get
				{
					return this.eyacAmount;
				}
			}

			// Token: 0x040005C7 RID: 1479
			private IMaleRandomGeneratorOverrider delete;

			// Token: 0x040005C8 RID: 1480
			public float? s;

			// Token: 0x040005C9 RID: 1481
			public float? v;

			// Token: 0x040005CA RID: 1482
			public float? h;

			// Token: 0x040005CB RID: 1483
			public float? fat;

			// Token: 0x040005CC RID: 1484
			public float? thin;

			// Token: 0x040005CD RID: 1485
			public float? muscle;

			// Token: 0x040005CE RID: 1486
			public float? old;

			// Token: 0x040005CF RID: 1487
			public float? height;

			// Token: 0x040005D0 RID: 1488
			public float? package;

			// Token: 0x040005D1 RID: 1489
			public float? dickSize;

			// Token: 0x040005D2 RID: 1490
			public float? dickGirth;

			// Token: 0x040005D3 RID: 1491
			public float? dickStiffness;

			// Token: 0x040005D4 RID: 1492
			public float? money;

			// Token: 0x040005D5 RID: 1493
			public float? clothes;

			// Token: 0x040005D6 RID: 1494
			public float? pleasureGain;

			// Token: 0x040005D7 RID: 1495
			public float? pleasureInterExp;

			// Token: 0x040005D8 RID: 1496
			public float? pleasureInterInc;

			// Token: 0x040005D9 RID: 1497
			public float? pleasureMaxValue;

			// Token: 0x040005DA RID: 1498
			public float? eyacTimes;

			// Token: 0x040005DB RID: 1499
			public float? eyacAmount;

			// Token: 0x040005DC RID: 1500
			public float? moneyMod;
		}
	}
}
