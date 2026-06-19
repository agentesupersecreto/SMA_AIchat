using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Assets.Base.Plugins.Runtime;
using Assets.Productos.Juegos.Scripts.BeachGirl.UI.EditingModels.Modelos;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.MapasDeAlteradores.Runtime;
using Assets.TValle.IU.Runtime.Drawing.Elementos.Paneles.Abstracts;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Controlladores;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.Globales.Updater;
using Assets._ReusableScripts.UI.Drawing;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Drawing.Reflecciones;
using UnityEngine;

namespace Assets.Productos.Juegos.Scripts.BeachGirl.UI.EditingModels
{
	// Token: 0x02000086 RID: 134
	public class PanelDesigner : PanelBaseQuadModel<DesignerOptionsModel, DesignerEditApparenceModel, DesignerEditOutfitModel, DesignerEditOutfitTypeModel>
	{
		// Token: 0x06000278 RID: 632 RVA: 0x0000EF3F File Offset: 0x0000D13F
		protected override object ObtenerModeloAUsar(bool esParaDibujar)
		{
			if (this.m_isEditingApparence)
			{
				return this.m_b;
			}
			if (this.m_isEditingCloting)
			{
				return this.m_c;
			}
			if (this.m_isEditingClotingType)
			{
				return this.m_d;
			}
			return this.m_a;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0000EF74 File Offset: 0x0000D174
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0000EF7C File Offset: 0x0000D17C
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_camerasEnabled = Singleton<PlayerInputProxy>.instance.activoModificableActionAND.ObtenerModificadorNotNull(this);
			this.m_CheckShowingCorutine = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.CheckShowingRutine(), null);
			this.m_CheckEditingApparenceCorutine = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.CheckEditingApparenceRutine(), null);
			this.m_CheckNakedCorutine = GlobalUpdater.instancia.StartCorrutinaOnEvent(GlobalUpdater.UpdateType.update1, this, this.CheckNakedRutine(), null);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000EFF0 File Offset: 0x0000D1F0
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			GlobalUpdater.instancia.StopCorrutina(this.m_CheckShowingCorutine);
			this.m_CheckShowingCorutine = null;
			GlobalUpdater.instancia.StopCorrutina(this.m_CheckEditingApparenceCorutine);
			this.m_CheckEditingApparenceCorutine = null;
			GlobalUpdater.instancia.StopCorrutina(this.m_CheckNakedCorutine);
			this.m_CheckNakedCorutine = null;
			ModificadorDeBool camerasEnabled = this.m_camerasEnabled;
			if (camerasEnabled != null)
			{
				camerasEnabled.TryRemoverDeOwner(true);
			}
			this.m_camerasEnabled = null;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000F063 File Offset: 0x0000D263
		private IEnumerator CheckShowingRutine()
		{
			ManualCorrutina.TValleWaitForSeconds w = new ManualCorrutina.TValleWaitForSeconds(1f);
			for (;;)
			{
				this.m_camerasEnabled.valor.valor = !base.isShowing;
				yield return w;
			}
			yield break;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0000F072 File Offset: 0x0000D272
		private IEnumerator CheckEditingApparenceRutine()
		{
			ManualCorrutina.TValleWaitForSeconds w = new ManualCorrutina.TValleWaitForSeconds(4f);
			for (;;)
			{
				yield return w;
				TargetChar current = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current;
				Character character = ((current != null) ? current.character : null);
				if (!(character == null))
				{
					IRopaManager componentEnRoot = character.GetComponentEnRoot<IRopaManager>();
					if (this.m_isEditingApparence)
					{
						if (componentEnRoot != null)
						{
							componentEnRoot.ToggleTodo(true);
						}
					}
					else if (componentEnRoot != null)
					{
						componentEnRoot.ToggleTodo(false);
					}
				}
			}
			yield break;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0000F081 File Offset: 0x0000D281
		private IEnumerator CheckNakedRutine()
		{
			ManualCorrutina.TValleWaitForSeconds w = new ManualCorrutina.TValleWaitForSeconds(3f);
			for (;;)
			{
				yield return w;
				TargetChar current = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current;
				Character character = ((current != null) ? current.character : null);
				if (!(character == null))
				{
					IRopaManager componentEnRoot = character.GetComponentEnRoot<IRopaManager>();
					if (componentEnRoot != null)
					{
						bool flag = componentEnRoot.CantidadPiezasCubriendo(RopaCubre.pezones, true, null) == 0;
						bool flag2 = componentEnRoot.CantidadPiezasCubriendo(RopaCubre.vaginaHole, true, null) == 0;
						bool flag3 = componentEnRoot.CantidadPiezasCubriendo(RopaCubre.ano, true, null) == 0;
						IInteraccionesDeCharacterFemenino componentEnRoot2 = character.GetComponentEnRoot<IInteraccionesDeCharacterFemenino>();
						if (componentEnRoot2 != null)
						{
							InteraccionDeCharacterFemenino interaccionDeCharacterFemenino;
							componentEnRoot2.TryObtenerSiEsValida(InteraccionSegundariaName.taparColaConManoDerecha.GetInteractionID(), out interaccionDeCharacterFemenino);
							InteraccionDeCharacterFemenino interaccionDeCharacterFemenino2;
							componentEnRoot2.TryObtenerSiEsValida(InteraccionSegundariaName.taparVagConManoIzquierda.GetInteractionID(), out interaccionDeCharacterFemenino2);
							InteraccionDeCharacterFemenino interaccionDeCharacterFemenino3;
							componentEnRoot2.TryObtenerSiEsValida(InteraccionSegundariaName.taparSenosConManoDerecha.GetInteractionID(), out interaccionDeCharacterFemenino3);
							if (flag2)
							{
								bool? flag4;
								if (interaccionDeCharacterFemenino2 == null)
								{
									flag4 = null;
								}
								else
								{
									Interaccion instancia = interaccionDeCharacterFemenino2.instancia;
									flag4 = ((instancia != null) ? new bool?(instancia.ejecutandose) : null);
								}
								bool? flag5 = flag4;
								if (!flag5.GetValueOrDefault() && interaccionDeCharacterFemenino2 != null)
								{
									Interaccion instancia2 = interaccionDeCharacterFemenino2.instancia;
									if (instancia2 != null)
									{
										instancia2.Ejecutar(int.MaxValue, -1f, ControllerPrioridadConfig.prioridad, 1f, 0.5f, false);
									}
								}
							}
							else if (interaccionDeCharacterFemenino2 != null)
							{
								Interaccion instancia3 = interaccionDeCharacterFemenino2.instancia;
								if (instancia3 != null)
								{
									instancia3.Detener(false);
								}
							}
							if (!flag3 && flag)
							{
								bool? flag6;
								if (interaccionDeCharacterFemenino3 == null)
								{
									flag6 = null;
								}
								else
								{
									Interaccion instancia4 = interaccionDeCharacterFemenino3.instancia;
									flag6 = ((instancia4 != null) ? new bool?(instancia4.ejecutandose) : null);
								}
								bool? flag5 = flag6;
								if (!flag5.GetValueOrDefault() && interaccionDeCharacterFemenino3 != null)
								{
									Interaccion instancia5 = interaccionDeCharacterFemenino3.instancia;
									if (instancia5 != null)
									{
										instancia5.Ejecutar(int.MaxValue, -1f, ControllerPrioridadConfig.prioridad, 1f, 0.5f, false);
									}
								}
							}
							else if (interaccionDeCharacterFemenino3 != null)
							{
								Interaccion instancia6 = interaccionDeCharacterFemenino3.instancia;
								if (instancia6 != null)
								{
									instancia6.Detener(false);
								}
							}
							if (flag3)
							{
								bool? flag7;
								if (interaccionDeCharacterFemenino == null)
								{
									flag7 = null;
								}
								else
								{
									Interaccion instancia7 = interaccionDeCharacterFemenino.instancia;
									flag7 = ((instancia7 != null) ? new bool?(instancia7.ejecutandose) : null);
								}
								bool? flag5 = flag7;
								if (!flag5.GetValueOrDefault() && interaccionDeCharacterFemenino != null)
								{
									Interaccion instancia8 = interaccionDeCharacterFemenino.instancia;
									if (instancia8 != null)
									{
										instancia8.Ejecutar(int.MaxValue, -1f, ControllerPrioridadConfig.prioridad, 1f, 0.5f, false);
									}
								}
							}
							else if (interaccionDeCharacterFemenino != null)
							{
								Interaccion instancia9 = interaccionDeCharacterFemenino.instancia;
								if (instancia9 != null)
								{
									instancia9.Detener(false);
								}
							}
						}
						ControlladorDeGestosFacialesEmocionales componentEnRoot3 = character.GetComponentEnRoot<ControlladorDeGestosFacialesEmocionales>();
						if (componentEnRoot3 != null)
						{
							float num = 0f;
							if (flag)
							{
								num += 0.333f;
							}
							if (flag2)
							{
								num += 0.333f;
							}
							if (flag3)
							{
								num += 0.333f;
							}
							float num2 = 1f - num;
							if (num > 0f)
							{
								RegistroDeFuncionesDeGestos.Cara.Sonrreir.Gestuar(componentEnRoot3, 0f, 3600f);
								RegistroDeFuncionesDeGestos.Cara.Lamentar.Gestuar(componentEnRoot3, num, 3600f);
							}
							else
							{
								RegistroDeFuncionesDeGestos.Cara.Sonrreir.Gestuar(componentEnRoot3, num2, 3600f);
								RegistroDeFuncionesDeGestos.Cara.Lamentar.Gestuar(componentEnRoot3, 0f, 3600f);
							}
						}
					}
				}
			}
			yield break;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0000F08C File Offset: 0x0000D28C
		protected override void OnBinded()
		{
			base.OnBinded();
			this.m_a.editApparenceClicked += this.M_model_editApparenceClicked;
			this.m_a.editOutfitClicked += this.M_a_editOutfitClicked;
			this.m_b.onDoneClicked += this.M_b_onDoneClicked;
			this.m_b.holdersModel.itemClicked += this.HoldersModel_itemClicked;
			this.m_c.onDoneClicked += this.M_c_onDoneClicked;
			this.m_c.editTipoClicked += this.M_c_editTipoClicked;
			this.m_d.goBackClicked += this.M_d_goBackClicked;
			this.m_d.existentesModel.itemClicked += this.ExistentesModel_itemClicked;
			this.m_d.puestasModel.takeOffClicked += this.PuestasModel_onTakeOffClicked;
			this.m_d.puestasModel.materialChanged += this.PuestasModel_materialChanged;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0000F19C File Offset: 0x0000D39C
		protected override void OnClearing()
		{
			base.OnClearing();
			this.m_a.editApparenceClicked -= this.M_model_editApparenceClicked;
			this.m_a.editOutfitClicked -= this.M_a_editOutfitClicked;
			this.m_b.onDoneClicked -= this.M_b_onDoneClicked;
			this.m_b.holdersModel.itemClicked -= this.HoldersModel_itemClicked;
			this.m_c.onDoneClicked -= this.M_c_onDoneClicked;
			this.m_c.editTipoClicked -= this.M_c_editTipoClicked;
			this.m_d.goBackClicked -= this.M_d_goBackClicked;
			this.m_d.existentesModel.itemClicked -= this.ExistentesModel_itemClicked;
			this.m_d.puestasModel.takeOffClicked -= this.PuestasModel_onTakeOffClicked;
			this.m_d.puestasModel.materialChanged -= this.PuestasModel_materialChanged;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0000F2A9 File Offset: 0x0000D4A9
		private void M_model_editApparenceClicked(DesignerOptionsModel obj)
		{
			this.m_isEditingApparence = true;
			base.CrearYDibujar(null);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000F2B9 File Offset: 0x0000D4B9
		private void M_a_editOutfitClicked(DesignerOptionsModel obj)
		{
			this.m_isEditingCloting = true;
			base.CrearYDibujar(null);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000F2C9 File Offset: 0x0000D4C9
		private void M_b_onDoneClicked(DesignerEditApparenceModel obj)
		{
			this.m_isEditingApparence = false;
			base.CrearYDibujar(null);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000F2DC File Offset: 0x0000D4DC
		private void HoldersModel_itemClicked(MultipleValorElemento<string, object> arg1, int arg2, HolderDeAlteradores arg3)
		{
			if (arg3 == null)
			{
				this.m_b.alteratorsModel.title = "Alterators";
				this.m_b.alteratorsModel.currentHolder = null;
				this.m_b.alteratorsModel.currentAlteradores = null;
				this.m_b.alteratorsModel.alteratorSlidersModels = null;
				return;
			}
			List<Alterador> list = new List<Alterador>();
			arg3.ObtenerAlteradores(list);
			this.m_b.alteratorsModel.title = arg1.item1;
			this.m_b.alteratorsModel.currentHolder = arg3;
			this.m_b.alteratorsModel.currentAlteradores = list;
			this.m_b.alteratorsModel.alteratorSlidersModels = new List<DesignerEditApparenceAlteratorModel>();
			for (int i = 0; i < list.Count; i++)
			{
				Alterador alterador = list[i];
				List<float> list2 = new List<float>();
				alterador.ExportarValores(list2);
				List<MultipleValorElemento<string, float>> list3 = new List<MultipleValorElemento<string, float>>(list2.Count);
				for (int j = 0; j < list2.Count; j++)
				{
					string labelDeValorIndex = alterador.GetLabelDeValorIndex(j);
					list3.Add(new MultipleValorElemento<string, float>(labelDeValorIndex, list2[j]));
				}
				string text = alterador.nombre;
				MemberInfo memberInfo;
				if (DiccionarioDeStrings<DiccionarioDeNombresDeAlteradoresFemeninos>.memberDeNombre.TryGetValue(text, out memberInfo))
				{
					TextoLocalizadoAttribute currentLocalization = DibujadorDynamico.instance.GetCurrentLocalization<LabelLocalizadoAttribute>(memberInfo);
					if (currentLocalization != null && !string.IsNullOrWhiteSpace(currentLocalization.text))
					{
						text = currentLocalization.text;
					}
				}
				this.m_b.alteratorsModel.alteratorSlidersModels.Add(new DesignerEditApparenceAlteratorModel
				{
					currentAlterador = alterador,
					valores = list2,
					sliders = list3,
					title = text
				});
			}
			this.ReDrawAlteratorsPanel();
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000F482 File Offset: 0x0000D682
		private void M_c_editTipoClicked(DesignerEditOutfitModel arg1, MapaDeRopa.TipoDePrenda arg2)
		{
			this.m_isEditingCloting = false;
			this.m_isEditingClotingType = true;
			this.m_editingClotingType = arg2;
			this.m_d.tipo = this.m_editingClotingType;
			base.CrearYDibujar(null);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000F4B1 File Offset: 0x0000D6B1
		private void M_c_onDoneClicked(DesignerEditOutfitModel obj)
		{
			this.m_isEditingCloting = false;
			base.CrearYDibujar(null);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000F4C4 File Offset: 0x0000D6C4
		private void ExistentesModel_itemClicked(string piezaID)
		{
			IRopaManager manager = this.GetManager();
			if (manager == null || !Singleton<GeneradorDeConjuntosDeRopaAleatoriosFemeninos>.IsInScene)
			{
				return;
			}
			if (manager.piezasPuestasPorId.ContainsKey(piezaID))
			{
				return;
			}
			List<MaterialParaRopaData> list = null;
			MapaDeRopa.RopaData ropaData;
			GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerMaterialesParaPrenda(piezaID, out ropaData, ref list, ItemQuality.Common, 20f);
			Pieza pieza = GeneradorDeConjuntosDeRopaAleatoriosFemeninos.GenerarPiezaDeRopa(piezaID, list);
			base.DisableRaycaster(5f);
			base.StartCoroutine(manager.AddPiezaAsync<PiezaDeRopaBase>(pieza, delegate(PiezaDeRopaBase p)
			{
				base.EnableRaycaster();
				this.m_d.puestasModel.LoadElements(this.m_editingClotingType);
				this.ReDrawWaeringPanel();
			}, false));
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000F532 File Offset: 0x0000D732
		private void M_d_goBackClicked(DesignerEditOutfitTypeModel obj)
		{
			this.m_isEditingCloting = true;
			this.m_isEditingClotingType = false;
			base.CrearYDibujar(null);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000F549 File Offset: 0x0000D749
		private void PuestasModel_onTakeOffClicked(DesignerEditOutfitEditPrendaModel arg1, DesignerEditOutfitEditPrendasModel arg2)
		{
			arg2.LoadElements(this.m_editingClotingType);
			this.ReDrawWaeringPanel();
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000F560 File Offset: 0x0000D760
		private void PuestasModel_materialChanged(MaterialParaRopaData arg1, DesignerEditOutfitEditMaterialModel arg2, DesignerEditOutfitEditPrendaModel arg3, DesignerEditOutfitEditPrendasModel arg4)
		{
			IRopaManager manager = this.GetManager();
			if (manager == null || !Singleton<GeneradorDeConjuntosDeRopaAleatoriosFemeninos>.IsInScene)
			{
				return;
			}
			base.DisableRaycaster(5f);
			base.StartCoroutine(manager.UpdateMaterialAsync(arg3.prenda.dataDeRopa.stringId, arg1.stringId, arg2.materialIndex, arg2.color, delegate(bool r)
			{
				base.EnableRaycaster();
			}));
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000F5C8 File Offset: 0x0000D7C8
		private IRopaManager GetManager()
		{
			TargetChar current = CurrentMainCharacter<CurrentTargetChar, TargetChar>.current;
			if (current == null)
			{
				Debug.LogError("No se pudo obtener el personaje target");
				return null;
			}
			Character character = current.character;
			IRopaManager ropaManager = ((character != null) ? character.GetComponentInChildren<IRopaManager>() : null);
			if (ropaManager == null)
			{
				string text = "No se pudo obtener RopaManager de personaje ";
				Character character2 = current.character;
				Debug.LogError(text + ((character2 != null) ? character2.nombreCompleto : null), current);
				return null;
			}
			return ropaManager;
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000F62C File Offset: 0x0000D82C
		private void ReDrawWaeringPanel()
		{
			IUIPanel iuipanel = null;
			string text = "puestasModel";
			IUIElemento iuielemento;
			if (base.UIPanel.elementoPorModelo.TryGetValue(text, out iuielemento))
			{
				iuipanel = iuielemento as IUIPanel;
			}
			base.ReDrawSubModelo(this.m_d.puestasModel, text, ref iuipanel, base.UIPanel, base.UIPanel.GetParentPara(1));
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000F684 File Offset: 0x0000D884
		private void ReDrawAlteratorsPanel()
		{
			IUIPanel iuipanel = null;
			string text = "alteratorsModel";
			IUIElemento iuielemento;
			if (base.UIPanel.elementoPorModelo.TryGetValue(text, out iuielemento))
			{
				iuipanel = iuielemento as IUIPanel;
			}
			base.SaveScrollValue("holdersModel");
			base.ReDrawSubModelo(this.m_b.alteratorsModel, text, ref iuipanel, base.UIPanel, base.UIPanel.GetParentPara(1));
			base.LoadScrollValue("holdersModel", 1);
			base.LoadScrollValue("holdersModel", 2);
			base.LoadScrollValue("holdersModel", 3);
		}

		// Token: 0x0400010C RID: 268
		[ReadOnlyUI]
		[SerializeField]
		private bool m_isEditingApparence;

		// Token: 0x0400010D RID: 269
		[ReadOnlyUI]
		[SerializeField]
		private bool m_isEditingCloting;

		// Token: 0x0400010E RID: 270
		[ReadOnlyUI]
		[SerializeField]
		private bool m_isEditingClotingType;

		// Token: 0x0400010F RID: 271
		[ReadOnlyUI]
		[SerializeField]
		private MapaDeRopa.TipoDePrenda m_editingClotingType;

		// Token: 0x04000110 RID: 272
		private GlobalUpdater.Corrutina m_CheckShowingCorutine;

		// Token: 0x04000111 RID: 273
		private GlobalUpdater.Corrutina m_CheckEditingApparenceCorutine;

		// Token: 0x04000112 RID: 274
		private GlobalUpdater.Corrutina m_CheckNakedCorutine;

		// Token: 0x04000113 RID: 275
		[SerializeReference]
		private ModificadorDeBool m_camerasEnabled;
	}
}
