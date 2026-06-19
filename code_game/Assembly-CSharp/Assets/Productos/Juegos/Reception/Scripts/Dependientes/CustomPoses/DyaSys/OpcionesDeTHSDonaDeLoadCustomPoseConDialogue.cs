using System;
using System.Linq;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets.TValle.IU.Runtime.Modales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.UI;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes.CustomPoses.DyaSys
{
	// Token: 0x020000C3 RID: 195
	public sealed class OpcionesDeTHSDonaDeLoadCustomPoseConDialogue : GenericOpcionesDeTHSDonaDeKeys<int>
	{
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600049E RID: 1182 RVA: 0x00016AF0 File Offset: 0x00014CF0
		public IInteraccionesDeCharacter interacciones
		{
			get
			{
				return this.m_interacciones;
			}
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00016AF8 File Offset: 0x00014CF8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
			this.m_interacciones = this.GetComponentEnRoot(false);
			if (this.m_interacciones == null)
			{
				throw new ArgumentNullException("m_interacciones", "m_interacciones null reference.");
			}
			this.m_customInteraccionA = this.m_interacciones.Obtener(InteraccionPrimariaName.customA.GetInteractionID());
			if (this.m_customInteraccionA == null)
			{
				throw new ArgumentNullException("m_customInteraccionA", "m_customInteraccionA null reference.");
			}
			this.m_customInteraccionB = this.m_interacciones.Obtener(InteraccionPrimariaName.customB.GetInteractionID());
			if (this.m_customInteraccionB == null)
			{
				throw new ArgumentNullException("m_customInteraccionB", "m_customInteraccionB null reference.");
			}
			this.m_InteraccionTransicionController = this.GetComponentEnRoot(false);
			if (this.m_InteraccionTransicionController == null)
			{
				throw new ArgumentNullException("m_InteraccionTransicionController", "m_InteraccionTransicionController null reference.");
			}
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00016BEC File Offset: 0x00014DEC
		protected override bool IndexEsGreyOut(int index)
		{
			return base.IndexEsGreyOut(index) || this.m_InteraccionTransicionController.currentStado.Ejecutandose(0);
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00016C0A File Offset: 0x00014E0A
		protected override void LoadKeys(HashSetList<int> resultado)
		{
			resultado.Add(InteraccionPrimariaName.customA.GetInteractionID());
		}

		// Token: 0x060004A2 RID: 1186 RVA: 0x00016C1A File Offset: 0x00014E1A
		protected override int KeyDeItemKey(string key, int index)
		{
			return this.m_dibujando[index];
		}

		// Token: 0x060004A3 RID: 1187 RVA: 0x00016C28 File Offset: 0x00014E28
		protected override string KeyDeIndex(int index)
		{
			return this.m_dibujando[index].ToString();
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x00016C4C File Offset: 0x00014E4C
		protected override string TextDeKey(int key)
		{
			if (key != InteraccionPrimariaName.customA.GetInteractionID())
			{
				throw new NotSupportedException();
			}
			string text;
			try
			{
				Component instancia = this.m_customInteraccionA.instancia;
				bool flag = this.EsDetener(null);
				text = instancia.GetComponent<InteraccionStrings>().segunda.CurrentTextFormal(flag);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = key.ToString();
			}
			return text;
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x00016CB4 File Offset: 0x00014EB4
		private InteraccionDeCharacterFemenino GetInter(InteraccionPrimariaName interName)
		{
			if (interName == InteraccionPrimariaName.customA)
			{
				return this.m_customInteraccionA;
			}
			if (interName != InteraccionPrimariaName.customB)
			{
				throw new ArgumentOutOfRangeException(interName.ToString());
			}
			return this.m_customInteraccionB;
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x00016CE4 File Offset: 0x00014EE4
		private bool EsDetener(InteraccionDeCharacter inter)
		{
			bool flag = false;
			if (inter == null)
			{
				inter = this.m_interacciones.ObtenerFirstEjecutandosePrimaria();
			}
			if (inter != null)
			{
				bool? flag2;
				if (inter == null)
				{
					flag2 = null;
				}
				else
				{
					Interaccion instancia = inter.instancia;
					flag2 = ((instancia != null) ? new bool?(instancia.algunaEstaEjecutandose) : null);
				}
				bool? flag3 = flag2;
				if (flag3.GetValueOrDefault(false) && inter.id != InteraccionPrimariaName.customA.GetInteractionID() && inter.id != InteraccionPrimariaName.customB.GetInteractionID())
				{
					flag = true;
				}
			}
			return flag;
		}

		// Token: 0x060004A7 RID: 1191 RVA: 0x00016D5F File Offset: 0x00014F5F
		protected override void OnDonaShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			base.OnDonaShowed(currentUserData, sender);
			this.esDetener = false;
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x00016D70 File Offset: 0x00014F70
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			if (base.selectedKeys.Last<int>() != InteraccionPrimariaName.customA.GetInteractionID())
			{
				throw new NotSupportedException();
			}
			InteraccionDeCharacter inter = this.m_interacciones.ObtenerFirstEjecutandosePrimaria();
			this.esDetener = this.EsDetener(inter);
			if (this.esDetener)
			{
				DialogueLua.SetVariable("SELECTED_POSE_ID", inter.id);
				DialogueLua.SetVariable("SELECTED_POSE_ES_DETENER", this.esDetener);
				DialogueLua.SetVariable("SELECTED_POSE_PUEDE_EJECUTARSE", false);
				DialogueLua.SetVariable("SELECTED_POSE_FORZAR_EJECUTADO", false);
				DialogueLua.SetVariable("SELECTED_POSE_TEXTO", base.selected.Last<THSDonaController.RadialItemData>().text);
				DialogueLua.SetVariable("SELECTED_CUSTOM_POSE_CARGADA", false);
				DialogueLua.SetVariable("SELECTED_POSE_TRY_USAR_TRANSICION", false);
				this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversationDetener);
				dona.StopDrawing();
				return;
			}
			if (Singleton<ModalWindow>.instance.isShowing)
			{
				return;
			}
			PosePortraitsDialog diag = Singleton<ModalWindow>.instance.MostrarPosePortraitsDialog();
			diag.panelDePortraits.portraitsModel.staring += delegate(PortraitsModelBase<MultipleValorElemento<string, bool>> model)
			{
				if (model.protraitsDisponibles.ContieneIndex(model.currentSelected))
				{
					string item = model.protraitsDisponibles[model.currentSelected].item1;
					if (string.IsNullOrWhiteSpace(item))
					{
						if (Application.isEditor)
						{
							Debug.LogWarning("Nombre a cargar es invalido: " + item, this);
							return;
						}
						Debug.LogError("Nombre a cargar es invalido: " + item, this);
						return;
					}
					else
					{
						if (!DialogueManager.IsConversationActive)
						{
							InteraccionPrimariaName interaccionPrimariaName;
							bool flag;
							this.m_interacciones.ObtenerNextCustom(out interaccionPrimariaName, out flag);
							DialogueLua.SetVariable("SELECTED_POSE_ID", interaccionPrimariaName.GetInteractionID());
							DialogueLua.SetVariable("SELECTED_POSE_ES_DETENER", this.esDetener);
							DialogueLua.SetVariable("SELECTED_POSE_PUEDE_EJECUTARSE", false);
							DialogueLua.SetVariable("SELECTED_POSE_FORZAR_EJECUTADO", false);
							DialogueLua.SetVariable("SELECTED_POSE_TEXTO", this.selected.Last<THSDonaController.RadialItemData>().text);
							DialogueLua.SetVariable("SELECTED_CUSTOM_POSE_NAME", item);
							DialogueLua.SetVariable("SELECTED_CUSTOM_POSE_CARGADA", false);
							DialogueLua.SetVariable("SELECTED_POSE_TRY_USAR_TRANSICION", inter != null && (inter.id == InteraccionPrimariaName.customA.GetInteractionID() || inter.id == InteraccionPrimariaName.customB.GetInteractionID()));
							this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversationEjecutar);
						}
						Singleton<ModalWindow>.instance.Clear(diag);
					}
				}
			};
			diag.panelDePortraits.portraitsModel.canceling += delegate(PortraitsModelBase<MultipleValorElemento<string, bool>> model)
			{
				Singleton<ModalWindow>.instance.Clear(diag);
			};
			dona.StopDrawing();
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x00016EDE File Offset: 0x000150DE
		protected override void OnLoadedItems(LoaderDeTHSDona caller)
		{
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x00016EE0 File Offset: 0x000150E0
		protected override void OnUserAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x00016EE2 File Offset: 0x000150E2
		protected override void OnUserGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x04000213 RID: 531
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationEjecutar;

		// Token: 0x04000214 RID: 532
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversationDetener;

		// Token: 0x04000215 RID: 533
		private Character m_owner;

		// Token: 0x04000216 RID: 534
		private InteraccionesBasicasDeFemale m_interacciones;

		// Token: 0x04000217 RID: 535
		private InteraccionDeCharacterFemenino m_customInteraccionA;

		// Token: 0x04000218 RID: 536
		private InteraccionDeCharacterFemenino m_customInteraccionB;

		// Token: 0x04000219 RID: 537
		public bool esDetener;

		// Token: 0x0400021A RID: 538
		private InteraccionTransicionController m_InteraccionTransicionController;
	}
}
