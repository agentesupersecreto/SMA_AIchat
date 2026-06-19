using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Abstracts;
using Assets.TValle.IU.Runtime.Drawing.Elementos;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets.TValle.IU.Runtime.Drawing.PortraitsYAcionesParaPortraits.Modelos;
using Assets.TValle.IU.Runtime.Drawing.PortraitsYAcionesParaPortraits.Paneles;
using Assets.TValle.IU.Runtime.Modales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.General.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.General.UI;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos;
using Assets.TValle.Pro.Entrevista.Runtime.Trabajos.Clases;
using Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas.Modelos;
using Assets.TValle.Tools.Runtime.Moddding;
using Assets.TValle.Tools.Runtime.SMA.Moddding.Jobs.Maps;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.UI;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;
using Assets._ReusableScripts.UI.Modales.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.UI.Entrevistas
{
	// Token: 0x02000044 RID: 68
	[RequireComponent(typeof(PanelDePortraitsEInformacionGeneral))]
	public class PanelModelAssignmentsLoader : AplicableBehaviour, IPanelOfModel
	{
		// Token: 0x06000223 RID: 547 RVA: 0x0000D455 File Offset: 0x0000B655
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_PanelToDraw = base.GetComponent<PanelDePortraitsEInformacionGeneral>();
		}

		// Token: 0x06000224 RID: 548 RVA: 0x0000D46C File Offset: 0x0000B66C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_PanelToDraw.loading += this.M_PanelDePortraitsEInformacionGeneral_loading;
			this.m_PanelToDraw.loadingItems += this.M_PanelDePortraitsEInformacionGeneral_loadingItems;
			this.m_PanelToDraw.itemsFavoriteStateChanged += this.M_PanelDePortraitsEInformacionGeneral_itemsFavoriteStateChanged;
			this.m_PanelToDraw.loadingInformacionGeneraDePortrait += this.M_PanelDePortraitsEInformacionGeneral_loadingInformacionGeneraDePortrait;
			this.m_PanelToDraw.onCleared += this.M_PanelDePortraitsEInformacionGeneral_onCleared;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x0000D4F4 File Offset: 0x0000B6F4
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_PanelToDraw != null)
			{
				this.m_PanelToDraw.loading -= this.M_PanelDePortraitsEInformacionGeneral_loading;
				this.m_PanelToDraw.loadingItems -= this.M_PanelDePortraitsEInformacionGeneral_loadingItems;
				this.m_PanelToDraw.itemsFavoriteStateChanged -= this.M_PanelDePortraitsEInformacionGeneral_itemsFavoriteStateChanged;
				this.m_PanelToDraw.loadingInformacionGeneraDePortrait -= this.M_PanelDePortraitsEInformacionGeneral_loadingInformacionGeneraDePortrait;
				this.m_PanelToDraw.onCleared -= this.M_PanelDePortraitsEInformacionGeneral_onCleared;
			}
		}

		// Token: 0x06000226 RID: 550 RVA: 0x0000D58C File Offset: 0x0000B78C
		private void M_PanelDePortraitsEInformacionGeneral_loading(ref InformacionGeneralDePortraitModelo modelo, PanelDePortraitsEInformacionGeneral sender)
		{
			modelo.informacionGeneral = new ModelAssignmentModelo();
			ModelAssignmentModelo modelAssignmentModelo = (ModelAssignmentModelo)modelo.informacionGeneral;
			modelAssignmentModelo.onDeployClicked -= this.InformacionGeneralModel_onDeployClicked;
			modelAssignmentModelo.onDeployClicked += this.InformacionGeneralModel_onDeployClicked;
			modelAssignmentModelo.modelInfo.portrait.portrait = Object.Instantiate<Texture2D>(Singleton<SMAGameController>.instance.defaultFemaleProtraitTexture);
			modelAssignmentModelo.assignmentInfo.portrait.portrait = Singleton<SMAGameController>.instance.defaultJobProtraitTexture;
			modelo.title = "Talent Deployment";
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/Hired/", true);
			modelo.portraitsLista.soloFavoritos = jsonMemoryNode.FindDataBool("soloFavoritos", false);
			jsonMemoryNode.TryFindDataArrayEmpty("m_historialSeleccionados", out this.m_historialSeleccionados);
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0000D654 File Offset: 0x0000B854
		private void M_PanelDePortraitsEInformacionGeneral_loadingItems(bool soloFavoritos, string buscando, ref InformacionGeneralDePortraitModelo modelo, PanelDePortraitsEInformacionGeneral sender)
		{
			MemoriaJson mem = GlobalSingletonV2<MemoriaJson>.instance;
			IJsonMemoryNode contratadasMEM = mem.LeerDeep("root/Hired/", false);
			IEnumerable<IMemoryNode<string, string>> enumerable = (from a in this.m_historialSeleccionados.Select((string id) => contratadasMEM.children.FirstOrDefault((IMemoryNode<string, string> a) => a.nodeID == id)).Distinct<IMemoryNode<string, string>>()
				where a != null && !string.IsNullOrWhiteSpace(a.nodeID)
				select a).Concat(contratadasMEM.children).Distinct<IMemoryNode<string, string>>();
			contratadasMEM.AddData("soloFavoritos", soloFavoritos, true);
			IEnumerable<IMemoryNode<string, string>> enumerable2 = enumerable.Where(delegate(IMemoryNode<string, string> ag)
			{
				bool flag = contratadasMEM.FindChildNotNull<IJsonMemoryNode>(ag.nodeID).FindDataBool("Fav", false);
				if (soloFavoritos && !flag)
				{
					return false;
				}
				string text;
				string text2;
				string text3;
				MemoriaDeSMAModelosFemeninas.GetNombres(mem, ag.nodeID, out text, out text2, out text3);
				return !text3.Filtrado(buscando);
			});
			enumerable2 = enumerable2.Where((IMemoryNode<string, string> ag) => !contratadasMEM.FindChildNotNull<IJsonMemoryNode>(ag.nodeID).FindDataBool("wasAssigned", false)).Concat(enumerable2).Distinct<IMemoryNode<string, string>>();
			IEnumerable<PortraitsListaModelo.Item> enumerable3 = enumerable2.Select(delegate(IMemoryNode<string, string> ag)
			{
				IJsonMemoryNode jsonMemoryNode = contratadasMEM.FindChildNotNull<IJsonMemoryNode>(ag.nodeID);
				string text4;
				string text5;
				string text6;
				MemoriaDeSMAModelosFemeninas.GetNombres(mem, ag.nodeID, out text4, out text5, out text6);
				return new PortraitsListaModelo.Item(ag.nodeID, text6, new SelectablePortraitCargarThumbnailHandler(PanelModelAssignmentsLoader.CargarThumbnail), (!jsonMemoryNode.FindDataBool("wasAssigned", false)) ? "New!" : null, jsonMemoryNode.FindDataBool("Fav", false));
			});
			modelo.portraitsLista.items.Clear();
			modelo.portraitsLista.items.AddRange(enumerable3);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x0000D769 File Offset: 0x0000B969
		private static void CargarThumbnail(string idDeProtrait, string nombreDeProtrait, ref Texture2D loadedTexture)
		{
			loadedTexture = MemoriaDeSMAModelosFemeninas.GetPortrait(GlobalSingletonV2<MemoriaJson>.instance, idDeProtrait);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x0000D778 File Offset: 0x0000B978
		private void M_PanelDePortraitsEInformacionGeneral_itemsFavoriteStateChanged(bool newValue, PortraitsListaModelo.Item portraitsData, PanelDePortraitsEInformacionGeneral sender)
		{
			GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/Hired/" + portraitsData.ID, true).AddData("Fav", newValue, true);
		}

		// Token: 0x0600022A RID: 554 RVA: 0x0000D7A4 File Offset: 0x0000B9A4
		private void M_PanelDePortraitsEInformacionGeneral_loadingInformacionGeneraDePortrait(PortraitsListaModelo.Item portraitsData, int index, ref object subModeloInformacionGeneralDePortrait, PanelDePortraitsEInformacionGeneral sender)
		{
			ModelAssignmentModelo modelAssignmentModelo = subModeloInformacionGeneralDePortrait as ModelAssignmentModelo;
			modelAssignmentModelo.modelInfo.id = portraitsData.ID;
			if (modelAssignmentModelo.modelInfo.portrait.portrait != null)
			{
				Object.Destroy(modelAssignmentModelo.modelInfo.portrait.portrait);
			}
			modelAssignmentModelo.modelInfo.portrait.portrait = MemoriaDeSMAModelosFemeninas.GetPortrait(GlobalSingletonV2<MemoriaJson>.instance, portraitsData.ID);
			float num;
			float num2;
			MemoriaDeSMAModelosFemeninas.GetModeSalaryAndCommission(GlobalSingletonV2<MemoriaJson>.instance, portraitsData.ID, out num, out num2);
			float fatigue = MemoriaDeNpc.GetFatigue(GlobalSingletonV2<MemoriaJson>.instance, portraitsData.ID, 0f);
			string text = ((fatigue < 10f) ? "<color=green>" : ("<color=#" + ColorUtility.ToHtmlStringRGBA(MathfExtension.LerpConMedio(Color.green, Color.yellow, Color.red, Mathf.InverseLerp(10f, 100f, fatigue).OutPow(3f), 1f, 1f)) + ">"));
			modelAssignmentModelo.modelInfo.modelName = new LabelParData("Name", portraitsData.nombreCompleto, string.Empty);
			modelAssignmentModelo.modelInfo.salary = new LabelParData("Salary", num.ToString("C0"), string.Empty);
			modelAssignmentModelo.modelInfo.commission = new LabelParData("Comm.", num2.ToString() + "%", string.Empty);
			modelAssignmentModelo.modelInfo.fatigue = new LabelParData("Fatigue", text + (fatigue / 100f).ToString("P0") + "</color>", string.Empty);
			StringBuilder stringBuilder = new StringBuilder();
			float num3;
			float num4;
			float num5;
			MemoriaDeSMAModelosFemeninas.GetJobIntereses(GlobalSingletonV2<MemoriaJson>.instance, portraitsData.ID, out num3, out num4, out num5);
			string text2;
			if (num5 > 0f)
			{
				text2 = TextoLocalizadoAttribute.Localizado<TraitHumano>(TraitHumano.gustoPorTratoExplicitoDeClientes, "US").FirstLetterOrDefaultToUpperCaseOthersToLower();
				stringBuilder.Append(TextoLocalizadoAttribute.Localizado<TraitHumano>(TraitHumano.gustoPorTratoDeClientes, "US").FirstLetterOrDefaultToUpperCaseOthersToLower());
				stringBuilder.Append(' ');
				stringBuilder.Append("<color=green>");
				stringBuilder.Append("Interested");
				stringBuilder.AppendLine("</color>");
				stringBuilder.Append(TextoLocalizadoAttribute.Localizado<TraitHumano>(TraitHumano.gustoPorTratoEspecialDeClientes, "US").FirstLetterOrDefaultToUpperCaseOthersToLower());
				stringBuilder.Append(' ');
				stringBuilder.Append("<color=green>");
				stringBuilder.Append("Interested");
				stringBuilder.AppendLine("</color>");
				stringBuilder.Append(text2);
				stringBuilder.Append(' ');
				stringBuilder.Append("<color=green>");
				stringBuilder.Append("Interested");
				stringBuilder.AppendLine("</color>");
			}
			else if (num4 > 0f)
			{
				text2 = TextoLocalizadoAttribute.Localizado<TraitHumano>(TraitHumano.gustoPorTratoEspecialDeClientes, "US").FirstLetterOrDefaultToUpperCaseOthersToLower();
				stringBuilder.Append(TextoLocalizadoAttribute.Localizado<TraitHumano>(TraitHumano.gustoPorTratoDeClientes, "US").FirstLetterOrDefaultToUpperCaseOthersToLower());
				stringBuilder.Append(' ');
				stringBuilder.Append("<color=green>");
				stringBuilder.Append("Interested");
				stringBuilder.AppendLine("</color>");
				stringBuilder.Append(text2);
				stringBuilder.Append(' ');
				stringBuilder.Append("<color=green>");
				stringBuilder.Append("Interested");
				stringBuilder.AppendLine("</color>");
				stringBuilder.Append(TextoLocalizadoAttribute.Localizado<TraitHumano>(TraitHumano.gustoPorTratoExplicitoDeClientes, "US").FirstLetterOrDefaultToUpperCaseOthersToLower());
				stringBuilder.Append(' ');
				stringBuilder.Append("<color=red>");
				stringBuilder.Append("Not Interested");
				stringBuilder.AppendLine("</color>");
			}
			else if (num3 > 0f)
			{
				text2 = TextoLocalizadoAttribute.Localizado<TraitHumano>(TraitHumano.gustoPorTratoDeClientes, "US").FirstLetterOrDefaultToUpperCaseOthersToLower();
				stringBuilder.Append(text2);
				stringBuilder.Append(' ');
				stringBuilder.Append("<color=green>");
				stringBuilder.Append("Interested");
				stringBuilder.AppendLine("</color>");
				stringBuilder.Append(TextoLocalizadoAttribute.Localizado<TraitHumano>(TraitHumano.gustoPorTratoEspecialDeClientes, "US").FirstLetterOrDefaultToUpperCaseOthersToLower());
				stringBuilder.Append(' ');
				stringBuilder.Append("<color=red>");
				stringBuilder.Append("Not Interested");
				stringBuilder.AppendLine("</color>");
				stringBuilder.Append(TextoLocalizadoAttribute.Localizado<TraitHumano>(TraitHumano.gustoPorTratoExplicitoDeClientes, "US").FirstLetterOrDefaultToUpperCaseOthersToLower());
				stringBuilder.Append(' ');
				stringBuilder.Append("<color=red>");
				stringBuilder.Append("Not Interested");
				stringBuilder.AppendLine("</color>");
			}
			else
			{
				text2 = "None";
				stringBuilder.Append(TextoLocalizadoAttribute.Localizado<TraitHumano>(TraitHumano.gustoPorTratoDeClientes, "US").FirstLetterOrDefaultToUpperCaseOthersToLower());
				stringBuilder.Append(' ');
				stringBuilder.Append("<color=red>");
				stringBuilder.Append("Not Interested");
				stringBuilder.AppendLine("</color>");
				stringBuilder.Append(TextoLocalizadoAttribute.Localizado<TraitHumano>(TraitHumano.gustoPorTratoEspecialDeClientes, "US").FirstLetterOrDefaultToUpperCaseOthersToLower());
				stringBuilder.Append(' ');
				stringBuilder.Append("<color=red>");
				stringBuilder.Append("Not Interested");
				stringBuilder.AppendLine("</color>");
				stringBuilder.Append(TextoLocalizadoAttribute.Localizado<TraitHumano>(TraitHumano.gustoPorTratoExplicitoDeClientes, "US").FirstLetterOrDefaultToUpperCaseOthersToLower());
				stringBuilder.Append(' ');
				stringBuilder.Append("<color=red>");
				stringBuilder.Append("Not Interested");
				stringBuilder.AppendLine("</color>");
			}
			modelAssignmentModelo.modelInfo.JobInterests = new LabelParData("Interests", text2, stringBuilder.ToString());
			string jobOfFemale = MemoriaDeSMAModelosFemeninas.GetJobOfFemale(GlobalSingletonV2<MemoriaJson>.instance, portraitsData.ID);
			if (string.IsNullOrWhiteSpace(jobOfFemale) || !AsyncSingleton<JobsGetter>.instance.jobsDisponibles.ContainsKey(jobOfFemale))
			{
				modelAssignmentModelo.assignmentInfo.id = string.Empty;
				modelAssignmentModelo.assignmentInfo.portrait.portrait = Singleton<SMAGameController>.instance.defaultJobProtraitTexture;
				modelAssignmentModelo.assignmentInfo.portrait.onChangeJobClicked -= this.Portrait_onChangeJobClicked;
				modelAssignmentModelo.assignmentInfo.portrait.onChangeJobClicked += this.Portrait_onChangeJobClicked;
				modelAssignmentModelo.assignmentInfo.assignmentName = new LabelParData();
				modelAssignmentModelo.assignmentInfo.modelExperience = new LevelParData();
				modelAssignmentModelo.assignmentInfo.level = 0;
				modelAssignmentModelo.assignmentInfo.nivelesDisponiblesParaEsteJobParaEstaModelo = new string[] { "None" };
				modelAssignmentModelo.assignmentInfo.assignmentDesc = new LabelParData();
				modelAssignmentModelo.assignmentInfo.DescDeNivelesDisponiblesParaEsteJobParaEstaModelo = null;
				modelAssignmentModelo.assignmentInfo.assignmentSalarioAtSelectedLevel = new LabelParData();
				return;
			}
			this.SetJobDataToModel(jobOfFemale, portraitsData.ID, modelAssignmentModelo.assignmentInfo);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x0000DE5C File Offset: 0x0000C05C
		private void SetJobDataToModel(string jobID, string CharacterID, AssignmentInfoModelo modelo)
		{
			SMAJobMap jobMap = AsyncSingleton<JobsGetter>.instance.jobsDisponibles[jobID];
			int count = jobMap.levels.Count;
			bool flag = MemoriaDeSMAModelosFemeninas.AceptoModelar(GlobalSingletonV2<MemoriaJson>.instance, CharacterID);
			bool flag2 = MemoriaDeSMAModelosFemeninas.AceptoLingerie(GlobalSingletonV2<MemoriaJson>.instance, CharacterID);
			bool flag3 = MemoriaDeSMAModelosFemeninas.AceptoErotico(GlobalSingletonV2<MemoriaJson>.instance, CharacterID);
			float num;
			float num2;
			float num3;
			MemoriaDeSMAModelosFemeninas.GetJobIntereses(GlobalSingletonV2<MemoriaJson>.instance, CharacterID, out num, out num2, out num3);
			bool flag4 = num3 > 0f;
			bool flag5 = num2 > 0f;
			bool flag6 = num > 0f;
			bool[] array = new bool[count];
			string[] array2 = new string[count];
			Color[] array3 = new Color[count];
			for (int n = 0; n < count; n++)
			{
				SMAJobMap.Level level = jobMap.levels[n];
				array3[n] = level.customColor;
				bool requiresEroticModeling = level.requiresEroticModeling;
				bool flag7 = !requiresEroticModeling && level.requiresLingerieModeling;
				bool flag8 = !requiresEroticModeling && !flag7 && level.requiresModelingCareer;
				bool flag9 = !requiresEroticModeling && !flag7 && !flag8;
				bool flag10 = (requiresEroticModeling && flag3) || (flag7 && flag2) || (flag8 && flag) || flag9;
				string text = (flag10 ? "<color=green>" : "<color=red>");
				if (flag9)
				{
					array2[n] = "Modeling Requirement: " + text + "None.</color>";
				}
				if (flag8)
				{
					array2[n] = "Modeling Requirement: " + text + "Be a Model.</color>";
				}
				if (flag7)
				{
					array2[n] = "Modeling Requirement: " + text + "Be a Lingerie Model.</color>";
				}
				if (requiresEroticModeling)
				{
					array2[n] = "Modeling Requirement: " + text + "Be an Erotic Model.</color>";
				}
				bool requiresNonSexualInterest = level.requiresNonSexualInterest;
				bool flag11 = !requiresNonSexualInterest && level.requiresSoftcoreInterest;
				bool flag12 = !requiresNonSexualInterest && !flag11 && level.requiresHardcoreInterest;
				bool flag13 = !requiresNonSexualInterest && !flag11 && !flag12;
				bool flag14 = (flag12 && flag4) || (flag11 && flag5) || (requiresNonSexualInterest && flag6) || flag13;
				text = (flag14 ? "<color=green>" : "<color=red>");
				if (flag13)
				{
					string[] array4 = array2;
					int num4 = n;
					array4[num4] = array4[num4] + "\nInterest Requirement: " + text + "None.</color>";
				}
				if (requiresNonSexualInterest)
				{
					string[] array5 = array2;
					int num5 = n;
					array5[num5] = array5[num5] + "\nInterest Requirement: " + text + "Companion Services (Non-Sexual).</color>";
				}
				if (flag11)
				{
					string[] array6 = array2;
					int num6 = n;
					array6[num6] = array6[num6] + "\nInterest Requirement: " + text + "Girlfriend Services (Softcore).</color>";
				}
				if (flag12)
				{
					string[] array7 = array2;
					int num7 = n;
					array7[num7] = array7[num7] + "\nInterest Requirement: " + text + "Escort Services (Explicit).</color>";
				}
				bool flag15 = true;
				SMAJobMap smajobMap;
				if (!string.IsNullOrWhiteSpace(level.requiresJobId) && level.requiresJobLvl > 0 && AsyncSingleton<JobsGetter>.instance.jobsDisponibles.TryGetValue(level.requiresJobId, out smajobMap))
				{
					string ingameName = smajobMap.GetIngameName(AsyncSingleton<JobsManager>.instance.gameLanguage);
					if (!string.IsNullOrWhiteSpace(ingameName))
					{
						flag15 = AsyncSingleton<JobsManager>.instance.GetCharacterInMemory(level.requiresJobId, CharacterID).FindDataFloat("Exp", 0f) > (float)(level.requiresJobLvl - 1);
						text = (flag15 ? "<color=green>" : "<color=red>");
						string text2 = (flag15 ? "Cleared" : "Pending");
						ref string ptr = ref array2[n];
						ptr = string.Concat(new string[]
						{
							ptr,
							"\n",
							ingameName,
							" Lvl ",
							level.requiresJobLvl.ToString(),
							" ",
							text,
							text2,
							"</color>"
						});
					}
				}
				array[n] = flag10 && flag14 && flag15;
			}
			float num8 = MemoriaDeSMAModelosFemeninas.TryGetJobExp(CharacterID, jobID, 0f);
			if (num8 > 0f)
			{
				num8 += 0.0001f;
			}
			int num9 = Mathf.Min(count, Mathf.FloorToInt(num8) + 1);
			bool[] array8 = new bool[count];
			for (int j = 0; j < count; j++)
			{
				array8[j] = false;
			}
			for (int k = 0; k < num9; k++)
			{
				array8[k] = true;
			}
			int num10 = 0;
			for (int l = 0; l < count; l++)
			{
				if (array8[l] && array[l])
				{
					num10 = l + 1;
				}
			}
			modelo.id = jobID;
			modelo.portrait.portrait = AsyncSingleton<JobsGetter>.instance.portraitDeJobs[jobID];
			modelo.portrait.onChangeJobClicked -= this.Portrait_onChangeJobClicked;
			modelo.portrait.onChangeJobClicked += this.Portrait_onChangeJobClicked;
			bool flag16;
			modelo.assignmentName = new LabelParData("Name", jobMap.GetIngameName(AsyncSingleton<JobsManager>.instance.gameLanguage, out flag16), string.Empty);
			modelo.modelExperience = new LevelParData(count, num8, array2, array3);
			modelo.levelIsValid = num10 > 0;
			modelo.level = Mathf.Clamp(MemoriaDeSMAModelosFemeninas.TryGetJobLevelAssigned(CharacterID, jobID, 0), 0, count);
			modelo.nivelesDisponiblesParaEsteJobParaEstaModelo = new string[num10];
			for (int m = 0; m < num10; m++)
			{
				modelo.nivelesDisponiblesParaEsteJobParaEstaModelo[m] = jobMap.GetLevelDesc(m, AsyncSingleton<JobsManager>.instance.gameLanguage).name;
			}
			string text3 = "Description";
			string text4;
			if (num10 != 0)
			{
				InGameNameDesc levelDesc = jobMap.GetLevelDesc(modelo.level, AsyncSingleton<JobsManager>.instance.gameLanguage);
				text4 = ((levelDesc != null) ? levelDesc.desciption : null);
			}
			else
			{
				text4 = "<color=red>Requirements are not met. Try persuading her to switch modeling type, or have her work on the required job until its level is reached. If she is not interested in this type of job, nothing can be done.</color>";
			}
			modelo.assignmentDesc = new LabelParData(text3, text4, string.Empty);
			modelo.DescDeNivelesDisponiblesParaEsteJobParaEstaModelo = jobMap.levels.Select((SMAJobMap.Level lvl, int i) => jobMap.GetLevelDesc(i, AsyncSingleton<JobsManager>.instance.gameLanguage).desciption).ToArray<string>();
			float incomeMod = CalculadorDeIncomeDeJobSession.GetIncomeMod(CharacterID, jobID);
			Color incomeColor = CalculadorDeIncomeDeJobSession.GetIncomeColor(incomeMod);
			modelo.incomes = jobMap.levels.Select((SMAJobMap.Level lvl, int i) => lvl.incomePerSession * incomeMod).ToArray<float>();
			string[] array9 = modelo.incomes.Select((float inc) => string.Concat(new string[]
			{
				"<color=#",
				ColorUtility.ToHtmlStringRGB(incomeColor),
				">",
				inc.ToString("C0"),
				"</color>"
			})).ToArray<string>();
			string text5 = ((num10 == 0) ? null : array9[modelo.level]);
			modelo.assignmentSalarioAtSelectedLevel = new LabelParData("Income", text5, "Warning: The more you use this job or model, the lower the profit; however, the income returns to normal every weekend.");
			modelo.SalarioDeNivelesDisponiblesParaEsteJobParaEstaModelo = array9;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x0000E4C0 File Offset: 0x0000C6C0
		private void Portrait_onChangeJobClicked(JobImageModelo obj)
		{
			PanelDePortraitsEInformacionGeneral panelToDraw = this.m_PanelToDraw;
			object obj2;
			if (panelToDraw == null)
			{
				obj2 = null;
			}
			else
			{
				InformacionGeneralDePortraitModelo currentModel = panelToDraw.currentModel;
				obj2 = ((currentModel != null) ? currentModel.informacionGeneral : null);
			}
			ModelAssignmentModelo modelAssignmentModelo = obj2 as ModelAssignmentModelo;
			if (modelAssignmentModelo != null)
			{
				ModelInfoModelo modelInfo = modelAssignmentModelo.modelInfo;
				if (!string.IsNullOrWhiteSpace((modelInfo != null) ? modelInfo.id : null))
				{
					if (!DialogueManager.IsConversationActive)
					{
						CurrentAvailableJobsPortraitsDialog diag = Singleton<ModalWindow>.instance.MostrarCurrentAvailableJobsPortraitsDialog();
						diag.GetComponentNotNull<CurrentAvailableJobsPortraitsGetter>();
						diag.panelDePortraits.portraitsModel.staring += delegate(PortraitsModelBase<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> model)
						{
							Singleton<ModalWindow>.instance.Clear(diag);
						};
						diag.panelDePortraits.portraitsModel.canceling += delegate(PortraitsModelBase<MultipleValorElemento<string, string, SelectablePortraitCargarThumbnailHandler, bool>> model)
						{
							Singleton<ModalWindow>.instance.Clear(diag);
						};
						diag.panelDePortraits.portraitsModel.onPortraitClicked += delegate(string jobID)
						{
							Singleton<ModalWindow>.instance.Clear(diag);
							this.ChangeJob(jobID);
						};
					}
					return;
				}
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x0000E5A4 File Offset: 0x0000C7A4
		private void ChangeJob(string jobID)
		{
			PanelDePortraitsEInformacionGeneral panelToDraw = this.m_PanelToDraw;
			object obj;
			if (panelToDraw == null)
			{
				obj = null;
			}
			else
			{
				InformacionGeneralDePortraitModelo currentModel = panelToDraw.currentModel;
				obj = ((currentModel != null) ? currentModel.informacionGeneral : null);
			}
			ModelAssignmentModelo modelAssignmentModelo = obj as ModelAssignmentModelo;
			if (modelAssignmentModelo != null)
			{
				ModelInfoModelo modelInfo = modelAssignmentModelo.modelInfo;
				if (!string.IsNullOrWhiteSpace((modelInfo != null) ? modelInfo.id : null))
				{
					ModelInfoModelo modelInfo2 = modelAssignmentModelo.modelInfo;
					this.SetJobDataToModel(jobID, (modelInfo2 != null) ? modelInfo2.id : null, modelAssignmentModelo.assignmentInfo);
					this.m_PanelToDraw.ReDrawDetalles();
					return;
				}
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x0000E61C File Offset: 0x0000C81C
		private void InformacionGeneralModel_onDeployClicked(ModelAssignmentModelo obj)
		{
			string text;
			if (obj == null)
			{
				text = null;
			}
			else
			{
				ModelInfoModelo modelInfo = obj.modelInfo;
				text = ((modelInfo != null) ? modelInfo.id : null);
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				Singleton<MainCanvas>.instance.MostrartMsg("Talent Deployment", "Please select a model first.", 3f, false, null, null, null);
				return;
			}
			string text2;
			if (obj == null)
			{
				text2 = null;
			}
			else
			{
				AssignmentInfoModelo assignmentInfo = obj.assignmentInfo;
				text2 = ((assignmentInfo != null) ? assignmentInfo.id : null);
			}
			if (string.IsNullOrWhiteSpace(text2))
			{
				Singleton<MainCanvas>.instance.MostrartMsg("Talent Deployment", "Please select a job first.", 3f, false, null, null, null);
				return;
			}
			bool? flag;
			if (obj == null)
			{
				flag = null;
			}
			else
			{
				AssignmentInfoModelo assignmentInfo2 = obj.assignmentInfo;
				flag = ((assignmentInfo2 != null) ? new bool?(assignmentInfo2.levelIsValid) : null);
			}
			bool? flag2 = flag;
			if (!flag2.GetValueOrDefault())
			{
				Singleton<MainCanvas>.instance.MostrartMsg("Talent Deployment", "The model's career choices in modeling are inappropriate for this job. Talk to her about it.", 3f, false, null, null, null);
				return;
			}
			bool flag3;
			if (obj == null)
			{
				flag3 = null != null;
			}
			else
			{
				AssignmentInfoModelo assignmentInfo3 = obj.assignmentInfo;
				flag3 = ((assignmentInfo3 != null) ? assignmentInfo3.incomes : null) != null;
			}
			if (!flag3 || obj.assignmentInfo.incomes.Length == 0)
			{
				Singleton<MainCanvas>.instance.MostrartMsg("Talent Deployment", "No Incomes Found.", 3f, false, null, null, null);
				return;
			}
			SMAJobMap smajobMap = AsyncSingleton<JobsGetter>.instance.jobsDisponibles[obj.assignmentInfo.id];
			int count = smajobMap.levels.Count;
			if (obj.assignmentInfo.level < 0 || obj.assignmentInfo.level >= count)
			{
				Singleton<MainCanvas>.instance.MostrartMsg("Talent Deployment", "Please select a valid Lvl first.", 3f, false, null, null, null);
				return;
			}
			if (!obj.assignmentInfo.incomes.ContieneIndex(obj.assignmentInfo.level))
			{
				Singleton<MainCanvas>.instance.MostrartMsg("Talent Deployment", "No Income for Selected level Found.", 3f, false, null, null, null);
				return;
			}
			GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/Hired/" + obj.modelInfo.id, true).AddData("wasAssigned", true, true);
			MemoriaDeSMAModelosFemeninas.SetJobToFemale(GlobalSingletonV2<MemoriaJson>.instance, obj.modelInfo.id, obj.assignmentInfo.id);
			MemoriaDeSMAModelosFemeninas.SetJobLevelAssigned(obj.modelInfo.id, obj.assignmentInfo.id, obj.assignmentInfo.level);
			MemoriaDeSMAModelosFemeninas.SetNextJobIncome(obj.modelInfo.id, obj.assignmentInfo.id, obj.assignmentInfo.incomes[obj.assignmentInfo.level]);
			MemoriaDeSMAModelosFemeninas.SetJobLastDate(obj.modelInfo.id, obj.assignmentInfo.id, Singleton<TiempoDeJuego>.instance.now);
			MemoriaDeSMAModelosFemeninas.SetJobLastDate(obj.assignmentInfo.id, Singleton<TiempoDeJuego>.instance.now);
			MemoriaDeSMAModelosFemeninas.SetJobLastDate(GlobalSingletonV2<MemoriaJson>.instance, obj.modelInfo.id, Singleton<TiempoDeJuego>.instance.now);
			AsyncSingleton<JobsManager>.instance.GetMemory(obj.assignmentInfo.id);
			switch (smajobMap.otherPlayerType)
			{
			case SMAJobMap.OtherPlayerType.selfAdmin:
			{
				Guid empty = Guid.Empty;
				AsyncSingleton<JobsManager>.instance.StartJob(obj.assignmentInfo.id, obj.assignmentInfo.level, empty, Guid.Parse(obj.modelInfo.id), null);
				return;
			}
			case SMAJobMap.OtherPlayerType.employer_FromPool:
				throw new NotImplementedException();
			case SMAJobMap.OtherPlayerType.client_FromPool:
				throw new NotImplementedException();
			case SMAJobMap.OtherPlayerType.stranger_FromPool:
				throw new NotImplementedException();
			default:
				throw new ArgumentOutOfRangeException(smajobMap.otherPlayerType.ToString());
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x0000E9DC File Offset: 0x0000CBDC
		private void M_PanelDePortraitsEInformacionGeneral_onCleared()
		{
			PanelDePortraitsEInformacionGeneral panelToDraw = this.m_PanelToDraw;
			object obj;
			if (panelToDraw == null)
			{
				obj = null;
			}
			else
			{
				InformacionGeneralDePortraitModelo currentModel = panelToDraw.currentModel;
				obj = ((currentModel != null) ? currentModel.informacionGeneral : null);
			}
			ModelAssignmentModelo modelAssignmentModelo = obj as ModelAssignmentModelo;
			if (modelAssignmentModelo == null)
			{
				return;
			}
			bool flag;
			if (modelAssignmentModelo == null)
			{
				flag = null != null;
			}
			else
			{
				ModelInfoModelo modelInfo = modelAssignmentModelo.modelInfo;
				flag = ((modelInfo != null) ? modelInfo.portrait : null) != null;
			}
			if (flag)
			{
				if (modelAssignmentModelo.modelInfo.portrait.portrait != null)
				{
					Object.Destroy(modelAssignmentModelo.modelInfo.portrait.portrait);
				}
				modelAssignmentModelo.modelInfo.portrait.portrait = null;
			}
			bool flag2;
			if (modelAssignmentModelo == null)
			{
				flag2 = null != null;
			}
			else
			{
				AssignmentInfoModelo assignmentInfo = modelAssignmentModelo.assignmentInfo;
				flag2 = ((assignmentInfo != null) ? assignmentInfo.portrait : null) != null;
			}
			if (flag2)
			{
				modelAssignmentModelo.assignmentInfo.portrait.portrait = null;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000230 RID: 560 RVA: 0x0000EA94 File Offset: 0x0000CC94
		public bool isShowing
		{
			get
			{
				return ((IPanelOfModel)this.m_PanelToDraw).isShowing;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000231 RID: 561 RVA: 0x0000EAA1 File Offset: 0x0000CCA1
		public bool isBinded
		{
			get
			{
				return ((IPanelOfModel)this.m_PanelToDraw).isBinded;
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000232 RID: 562 RVA: 0x0000EAAE File Offset: 0x0000CCAE
		[Obsolete("Mal hecho", true)]
		public GenericUserPanelBase genericUserPanel
		{
			get
			{
				return ((IPanelOfModel)this.m_PanelToDraw).genericUserPanel;
			}
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000EABB File Offset: 0x0000CCBB
		public void ActualizarValoresDeModelo()
		{
			((IPanelOfModel)this.m_PanelToDraw).ActualizarValoresDeModelo();
		}

		// Token: 0x06000234 RID: 564 RVA: 0x0000EAC8 File Offset: 0x0000CCC8
		public bool CanShow()
		{
			return ((IPanelOfModel)this.m_PanelToDraw).CanShow();
		}

		// Token: 0x06000235 RID: 565 RVA: 0x0000EAD5 File Offset: 0x0000CCD5
		public void Clear()
		{
			((IPanelOfModel)this.m_PanelToDraw).Clear();
		}

		// Token: 0x06000236 RID: 566 RVA: 0x0000EAE2 File Offset: 0x0000CCE2
		public void CrearYDibujar(DibujadorDynamico.ExtraData extraData = null)
		{
			((IPanelOfModel)this.m_PanelToDraw).CrearYDibujar(extraData);
		}

		// Token: 0x06000237 RID: 567 RVA: 0x0000EAF0 File Offset: 0x0000CCF0
		public object CurrentModelObjectAndState(out bool changed)
		{
			return ((IPanelOfModel)this.m_PanelToDraw).CurrentModelObjectAndState(out changed);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x0000EAFE File Offset: 0x0000CCFE
		public void Hide()
		{
			((IPanelOfModel)this.m_PanelToDraw).Hide();
		}

		// Token: 0x06000239 RID: 569 RVA: 0x0000EB0B File Offset: 0x0000CD0B
		public void Show()
		{
			((IPanelOfModel)this.m_PanelToDraw).Show();
		}

		// Token: 0x0600023A RID: 570 RVA: 0x0000EB18 File Offset: 0x0000CD18
		public object GetLastDrawModel()
		{
			return ((IPanelOfModel)this.m_PanelToDraw).GetLastDrawModel();
		}

		// Token: 0x0400016F RID: 367
		private const string ColorGreen = "<color=green>";

		// Token: 0x04000170 RID: 368
		private const string ColorRed = "<color=red>";

		// Token: 0x04000171 RID: 369
		private const string ColorEnd = "</color>";

		// Token: 0x04000172 RID: 370
		private PanelDePortraitsEInformacionGeneral m_PanelToDraw;

		// Token: 0x04000173 RID: 371
		[SerializeField]
		private List<string> m_historialSeleccionados = new List<string>();
	}
}
