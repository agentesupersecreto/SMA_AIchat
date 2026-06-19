using System;
using System.Collections;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades.Loaders.Abstracts;
using Assets.TValle.Pro.Entrevista.Runtime.Economia;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.General.UI.Modelos;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Alteradores.Holders.Masculinos;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Globales.Mapas;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.Scenes;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.General.UI
{
	// Token: 0x020000B7 RID: 183
	public class PanelNewGameMenu : PanelBaseSingleModel<NewGameModel>
	{
		// Token: 0x06000698 RID: 1688 RVA: 0x0002643C File Offset: 0x0002463C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			if (this.m_MaleCharSelector == null)
			{
				throw new ArgumentNullException("m_MaleCharSelector", "m_MaleCharSelector null reference.");
			}
			this.m_AlteradoresDeMasculinos = this.m_MaleCharSelector.GetComponentEnRoot<AlteradoresDeMasculinos>();
			this.m_alteradores = this.m_MaleCharSelector.GetComponentEnRoot<AlteradoresDeCharacterMasculino>();
			this.m_alteradoresDependientes = this.m_MaleCharSelector.GetComponentEnRoot<AlteracionesDependientesDeMaleDeMeshGeneral>();
			this.m_IRopaManager = this.m_MaleCharSelector.GetComponentEnRoot<IRopaManager>();
			if (this.m_IRopaManager == null)
			{
				throw new ArgumentNullException("m_IRopaManager", "m_IRopaManager null reference.");
			}
			if (this.m_AlteradoresDeMasculinos == null)
			{
				throw new ArgumentNullException("m_AlteradoresDeMasculinos", "m_AlteradoresDeMasculinos null reference.");
			}
			if (this.m_alteradores == null)
			{
				throw new ArgumentNullException("m_alteradores", "m_alteradores null reference.");
			}
			if (this.m_alteradoresDependientes == null)
			{
				throw new ArgumentNullException("m_alteradoresDependientes", "m_alteradoresDependientes null reference.");
			}
			base.SetYieldStart();
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x00026529 File Offset: 0x00024729
		protected override IEnumerator YieldStartUnityEvent()
		{
			this.m_MaleCharSelector.gameObject.SetActive(false);
			while (!this.m_AlteradoresDeMasculinos.instanciado || !this.m_alteradores.isControlladorDeMalePielStared)
			{
				yield return null;
			}
			this.M_model_onAttreibutoAlturaChanged();
			this.M_model_onAttreibutoMoneyChanged();
			this.M_model_onAttreibutoPenisChanged();
			this.M_model_onAttreibutoShapeChanged();
			this.M_model_onSkinChanged();
			this.m_model.onAttreibutoAlturaChanged += this.M_model_onAttreibutoAlturaChanged;
			this.m_model.onAttreibutoMoneyChanged += this.M_model_onAttreibutoMoneyChanged;
			this.m_model.canChangeAttreibutoMoney += this.M_model_canChangeAttreibutoMoney;
			this.m_model.onAttreibutoPenisChanged += this.M_model_onAttreibutoPenisChanged;
			this.m_model.onAttreibutoShapeChanged += this.M_model_onAttreibutoShapeChanged;
			this.m_model.onSkinChanged += this.M_model_onSkinChanged;
			this.m_model.onPanelValuesChanged += this.M_model_onPanelValuesChanged;
			this.m_model.onCancel += this.M_model_onCancel;
			this.m_model.onStart += this.M_model_onStart;
			if (this.m_dibujarOnStart)
			{
				base.CrearYDibujar(null);
			}
			yield break;
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x00026538 File Offset: 0x00024738
		protected override void OnShowed()
		{
			base.OnShowed();
			this.m_model.isValid = false;
			this.m_MaleCharSelector.gameObject.SetActive(true);
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x0002655D File Offset: 0x0002475D
		protected override void OnHided()
		{
			base.OnHided();
			this.m_MaleCharSelector.gameObject.SetActive(false);
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00026576 File Offset: 0x00024776
		private void M_model_onStart()
		{
			base.ActualizarValoresDeModelo();
			this.m_model.isValid = false;
			this.m_model.RefreshStartButton();
			Singleton<ActividadesManager>.instance.SetUIInputsActive(false);
			base.StartCoroutine(this.WaitConjuntosToEndLoad());
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x000265AD File Offset: 0x000247AD
		private void M_model_onCancel()
		{
			base.Clear();
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x000265B8 File Offset: 0x000247B8
		private void M_model_onAttreibutoShapeChanged()
		{
			this.m_alteradores.alteradorDeFatValor = PanelNewGameMenu.GetFatValue((float)this.m_model.slimness);
			this.m_alteradores.alteradorDeThinValor = PanelNewGameMenu.GetThinValue((float)this.m_model.slimness);
			this.m_alteradores.alteradorDeMuscleValor = PanelNewGameMenu.GetMuscleValue((float)this.m_model.musculos);
			this.m_alteradores.alteradorDeOldValor = PanelNewGameMenu.GetOldValue((float)this.m_model.youngness);
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x00026638 File Offset: 0x00024838
		private void M_model_onSkinChanged()
		{
			float saturationValue = PanelNewGameMenu.GetSaturationValue((float)this.m_model.skinColor);
			float valueValue = PanelNewGameMenu.GetValueValue((float)this.m_model.skinColor);
			float hueValue = PanelNewGameMenu.GetHueValue((float)this.m_model.skinColor);
			this.m_alteradores.canBeTransparent = false;
			this.m_alteradores.skinSaturationMod = saturationValue;
			this.m_alteradores.skinValueMod = valueValue;
			this.m_alteradores.skinHueMod = hueValue;
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x000266AB File Offset: 0x000248AB
		private void M_model_onAttreibutoAlturaChanged()
		{
			this.m_alteradoresDependientes.alteradorDeEscalaValor = PanelNewGameMenu.GetHeightValue((float)this.m_model.altura);
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x000266C9 File Offset: 0x000248C9
		private void M_model_onAttreibutoPenisChanged()
		{
			this.m_alteradores.alteradorDePackageValor = PanelNewGameMenu.GetPackageValue((float)this.m_model.dickSize);
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x000266E8 File Offset: 0x000248E8
		private void M_model_onAttreibutoMoneyChanged()
		{
			IConjuntoDeRopa conjunto = PanelNewGameMenu.GetConjunto((float)(this.m_model.money + 1));
			if (conjunto != this.m_IRopaManager.loadedConjunto)
			{
				base.StartCoroutine(this.ChangeConjuntoDeRopa(conjunto));
			}
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x00026725 File Offset: 0x00024925
		private static float GetFatValue(float slimness)
		{
			return LoaderDeNpcMasculinos.GetFatValue(MathfExtension.InverseLerpConMedio(-1f, 0f, 1f, slimness));
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x00026741 File Offset: 0x00024941
		private static float GetThinValue(float slimness)
		{
			return LoaderDeNpcMasculinos.GetThinValue(MathfExtension.InverseLerpConMedio(1f, 2f, 3f, slimness));
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0002675D File Offset: 0x0002495D
		private static float GetMuscleValue(float musculos)
		{
			return LoaderDeNpcMasculinos.GetMuscleValue(MathfExtension.InverseLerpConMedio(-1f, 1f, 3f, musculos));
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00026779 File Offset: 0x00024979
		private static float GetOldValue(float youngness)
		{
			return LoaderDeNpcMasculinos.GetOldValue(MathfExtension.InverseLerpConMedio(-1f, 1f, 3f, youngness));
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00026795 File Offset: 0x00024995
		private static float GetSaturationValue(float skinColor)
		{
			return LoaderDeNpcMasculinos.GetSaturationValue(skinColor / 100f);
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x000267A3 File Offset: 0x000249A3
		private static float GetValueValue(float skinColor)
		{
			return LoaderDeNpcMasculinos.GetValueValue(skinColor / 100f);
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x000267B1 File Offset: 0x000249B1
		private static float GetHueValue(float skinColor)
		{
			return LoaderDeNpcMasculinos.GetHueValue(skinColor / 100f);
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x000267BF File Offset: 0x000249BF
		private static float GetHeightValue(float altura)
		{
			return LoaderDeNpcMasculinos.GetHeightValue(MathfExtension.InverseLerpConMedio(-1f, 0f, 3f, altura));
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x000267DB File Offset: 0x000249DB
		private static float GetPackageValue(float dickSize)
		{
			return LoaderDeNpcMasculinos.GetPackageValue(MathfExtension.InverseLerpConMedio(-1f, 1f, 3f, dickSize));
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x000267F7 File Offset: 0x000249F7
		private static float GetDickSizeValue(float dickSize)
		{
			return LoaderDeNpcMasculinos.GetDickSizeValue(MathfExtension.InverseLerpConMedio(-1f, 1f, 3f, dickSize));
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x00026813 File Offset: 0x00024A13
		private static float GetDickGirthValue(float dickSize)
		{
			return LoaderDeNpcMasculinos.GetDickGirthValue(MathfExtension.InverseLerpConMedio(-1f, 1f, 3f, dickSize));
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x0002682F File Offset: 0x00024A2F
		private static float GetMoneyValue(float money)
		{
			return LoaderDeNpcMasculinos.GetMoneyValue(MathfExtension.InverseLerpConMedio(-1f, 1f, 3f, money));
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x0002684C File Offset: 0x00024A4C
		public static IConjuntoDeRopa GetConjunto(float officeLvl)
		{
			SMAGameController instance = Singleton<SMAGameController>.instance;
			if (officeLvl <= 1f)
			{
				if (officeLvl == 0f)
				{
					return instance.conjuntosDeRopaIniciales.minusOne;
				}
				if (officeLvl == 1f)
				{
					return instance.conjuntosDeRopaIniciales.zero;
				}
			}
			else
			{
				if (officeLvl == 2f)
				{
					return instance.conjuntosDeRopaIniciales.one;
				}
				if (officeLvl == 3f)
				{
					return instance.conjuntosDeRopaIniciales.two;
				}
				if (officeLvl == 4f)
				{
					return instance.conjuntosDeRopaIniciales.three;
				}
			}
			throw new ArgumentOutOfRangeException(officeLvl.ToString());
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x000268DC File Offset: 0x00024ADC
		private bool M_model_canChangeAttreibutoMoney(int newConjuntoValue)
		{
			if (this.m_model.pointsLeft <= 0 && newConjuntoValue > this.m_model.money)
			{
				return false;
			}
			SMAGameController instance = Singleton<SMAGameController>.instance;
			switch (newConjuntoValue)
			{
			case -1:
				return !this.m_changingTo.Contains(instance.conjuntosDeRopaIniciales.minusOne);
			case 0:
				return !this.m_changingTo.Contains(instance.conjuntosDeRopaIniciales.zero);
			case 1:
				return !this.m_changingTo.Contains(instance.conjuntosDeRopaIniciales.one);
			case 2:
				return !this.m_changingTo.Contains(instance.conjuntosDeRopaIniciales.two);
			case 3:
				return !this.m_changingTo.Contains(instance.conjuntosDeRopaIniciales.three);
			default:
				throw new ArgumentOutOfRangeException(this.m_model.money.ToString());
			}
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x000269C5 File Offset: 0x00024BC5
		private IEnumerator ChangeConjuntoDeRopa(IConjuntoDeRopa conjunto)
		{
			this.m_changingTo.Add(conjunto);
			if (this.m_IRopaManager != null)
			{
				yield return this.m_IRopaManager.LoadConjuntoAsset(conjunto, true, null, false);
			}
			this.m_changingTo.Remove(conjunto);
			yield break;
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x000269DB File Offset: 0x00024BDB
		private void M_model_onPanelValuesChanged(IUIElementoConValor nameInputField)
		{
			this.m_model.isValid = !string.IsNullOrWhiteSpace(nameInputField.GetValor().ToString());
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x000269FB File Offset: 0x00024BFB
		private IEnumerator WaitConjuntosToEndLoad()
		{
			while (this.m_IRopaManager.isLoadingConjunto)
			{
				yield return null;
			}
			this.LoadStart();
			yield break;
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x00026A0A File Offset: 0x00024C0A
		private void LoadStart()
		{
			this.UnloadMainLoadEmptyEntrevista(null, delegate
			{
				string mainCharName = this.m_model.mainCharName;
				Singleton<ModalWindow>.instance.ClearAll();
				if (string.IsNullOrWhiteSpace(mainCharName))
				{
					throw new InvalidOperationException("nombre de jugador invalido");
				}
				Singleton<ConfiguracionGeneralUsuario>.instance.playerName = mainCharName;
				string text = Singleton<CollecionDeCharacteresIDs>.instance.mainID.ToGuid().ToString();
				GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("UserName", true).AddData("UserName", mainCharName, true);
				MemoriaDeNpc.SetNombres(GlobalSingletonV2<MemoriaJson>.instance, text, mainCharName, string.Empty);
				IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/NPC/MainPlayer/InitialStats", true);
				float fatValue = PanelNewGameMenu.GetFatValue((float)this.m_model.slimness);
				float thinValue = PanelNewGameMenu.GetThinValue((float)this.m_model.slimness);
				float muscleValue = PanelNewGameMenu.GetMuscleValue((float)this.m_model.musculos);
				float oldValue = PanelNewGameMenu.GetOldValue((float)this.m_model.youngness);
				float saturationValue = PanelNewGameMenu.GetSaturationValue((float)this.m_model.skinColor);
				float valueValue = PanelNewGameMenu.GetValueValue((float)this.m_model.skinColor);
				float hueValue = PanelNewGameMenu.GetHueValue((float)this.m_model.skinColor);
				float heightValue = PanelNewGameMenu.GetHeightValue((float)this.m_model.altura);
				float packageValue = PanelNewGameMenu.GetPackageValue((float)this.m_model.dickSize);
				float num = PanelNewGameMenu.GetDickSizeValue((float)this.m_model.dickSize) * MathfExtension.LerpConMedio(0.92f, 1f, 1.1f, MathfExtension.InverseLerpConMedio(-1f, 1f, 3f, (float)this.m_model.altura));
				float dickGirthValue = PanelNewGameMenu.GetDickGirthValue((float)this.m_model.dickSize);
				float moneyValue = PanelNewGameMenu.GetMoneyValue((float)this.m_model.money);
				IConjuntoDeRopa conjunto = PanelNewGameMenu.GetConjunto((float)(this.m_model.money + 1));
				int money = this.m_model.money;
				if (money - -1 > 1)
				{
					if (money - 1 > 2)
					{
						throw new ArgumentOutOfRangeException(this.m_model.money.ToString());
					}
					MemoriaDeSMAGamePlay.SetCurrentOfficeLvl(1);
				}
				else
				{
					MemoriaDeSMAGamePlay.SetCurrentOfficeLvl(0);
				}
				MapaDeMaleBlendShapes instance = MapaSingleton<MapaDeMaleBlendShapes>.instance;
				jsonMemoryNode.AddData(instance.fat, fatValue, true);
				jsonMemoryNode.AddData(instance.thin, thinValue, true);
				jsonMemoryNode.AddData(instance.muscle, muscleValue, true);
				jsonMemoryNode.AddData(instance.old, oldValue, true);
				jsonMemoryNode.AddData("S", saturationValue, true);
				jsonMemoryNode.AddData("V", valueValue, true);
				jsonMemoryNode.AddData("H", hueValue, true);
				jsonMemoryNode.AddData("Height", heightValue, true);
				jsonMemoryNode.AddData(instance.package, packageValue, true);
				jsonMemoryNode.AddData("DickSize", num, true);
				jsonMemoryNode.AddData("DickGirth", dickGirthValue, true);
				jsonMemoryNode.AddData("Conjunto", this.m_model.money + 1, true);
				jsonMemoryNode.AddData("Fiat", moneyValue, true);
				MaleCharAparienciaMemory.Registrar(text, fatValue, thinValue, muscleValue, oldValue, saturationValue, valueValue, hueValue, heightValue, packageValue, num, dickGirthValue, 50f);
				MaleCharAparienciaMemory.RegistrarBuildInOutfit(text, this.m_model.money + 1);
				CharacterWallet.Registrar(text, moneyValue);
				MaleCharRopaMemory.Registrar(text, conjunto);
			});
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x00026A20 File Offset: 0x00024C20
		private void UnloadMainLoadEmptyEntrevista(Action extraFunction, Action extraFunction2)
		{
			SceneLoader.Pedido @default = SceneLoader.Pedido.@default;
			@default.scene.index = 2;
			@default.doLoadOrDoUnload = false;
			Singleton<SceneLoader>.instance.AddPedido(@default);
			SceneLoader.Pedido default2 = SceneLoader.Pedido.@default;
			default2.scene.index = 1;
			default2.doLoadOrDoUnload = false;
			default2.onPedidoFinalizado += delegate(SceneLoader.Pedido p)
			{
				Action extraFunction3 = extraFunction;
				if (extraFunction3 != null)
				{
					extraFunction3();
				}
				Action extraFunction4 = extraFunction2;
				if (extraFunction4 != null)
				{
					extraFunction4();
				}
				Type type = GetLoaderDeNivelDeOficina.Empty(MemoriaDeSMAGamePlay.GetCurrentOfficeLvl());
				Singleton<ActividadesManager>.instance.StartActividad("ComenzarATrabajar", type, delegate(IActividadLoader loaderInstance)
				{
					((ITValleActividadEnNuevoHorarioLoader)loaderInstance).flagDontChangeTime = true;
				}, null, true);
			};
			Singleton<SceneLoader>.instance.AddPedido(default2);
		}

		// Token: 0x04000403 RID: 1027
		[SerializeField]
		private MaleChar m_MaleCharSelector;

		// Token: 0x04000404 RID: 1028
		private AlteradoresDeMasculinos m_AlteradoresDeMasculinos;

		// Token: 0x04000405 RID: 1029
		private AlteradoresDeCharacterMasculino m_alteradores;

		// Token: 0x04000406 RID: 1030
		private AlteracionesDependientesDeMaleDeMeshGeneral m_alteradoresDependientes;

		// Token: 0x04000407 RID: 1031
		private IRopaManager m_IRopaManager;

		// Token: 0x04000408 RID: 1032
		private HashSet<IConjuntoDeRopa> m_changingTo = new HashSet<IConjuntoDeRopa>();
	}
}
