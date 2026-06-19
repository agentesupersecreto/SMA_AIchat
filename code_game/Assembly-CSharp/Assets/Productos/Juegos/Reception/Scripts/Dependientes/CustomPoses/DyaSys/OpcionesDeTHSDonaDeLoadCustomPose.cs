using System;
using System.Linq;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones;
using Assets.CustomPoses;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Drawing.Paneles.Modelos;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets.TValle.IU.Runtime.Modales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.UI;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.UI;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes.CustomPoses.DyaSys
{
	// Token: 0x020000C2 RID: 194
	[Obsolete("", true)]
	public class OpcionesDeTHSDonaDeLoadCustomPose : GenericOpcionesDeTHSDonaDeKeys<int>
	{
		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000490 RID: 1168 RVA: 0x000167C0 File Offset: 0x000149C0
		public IInteraccionesDeCharacter interacciones
		{
			get
			{
				return this.m_interacciones;
			}
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x000167C8 File Offset: 0x000149C8
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
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

		// Token: 0x06000492 RID: 1170 RVA: 0x00016891 File Offset: 0x00014A91
		protected override void LoadKeys(HashSetList<int> resultado)
		{
			resultado.Add(InteraccionPrimariaName.customA.GetInteractionID());
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x000168A1 File Offset: 0x00014AA1
		protected override int KeyDeItemKey(string key, int index)
		{
			return this.m_dibujando[index];
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x000168B0 File Offset: 0x00014AB0
		protected override string KeyDeIndex(int index)
		{
			return this.m_dibujando[index].ToString();
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x000168D4 File Offset: 0x00014AD4
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

		// Token: 0x06000496 RID: 1174 RVA: 0x0001693C File Offset: 0x00014B3C
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

		// Token: 0x06000497 RID: 1175 RVA: 0x0001696A File Offset: 0x00014B6A
		protected override void OnDonaShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			base.OnDonaShowed(currentUserData, sender);
			this.esDetener = false;
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0001697C File Offset: 0x00014B7C
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
			return flag | this.m_InteraccionTransicionController.currentStado.Ejecutandose(0);
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x00016A0C File Offset: 0x00014C0C
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			if (base.selectedKeys.Last<int>() != InteraccionPrimariaName.customA.GetInteractionID())
			{
				throw new NotSupportedException();
			}
			InteraccionDeCharacter interaccionDeCharacter = this.m_interacciones.ObtenerFirstEjecutandosePrimaria();
			this.esDetener = this.EsDetener(interaccionDeCharacter);
			if (this.esDetener)
			{
				if (interaccionDeCharacter != null)
				{
					Interaccion instancia = interaccionDeCharacter.instancia;
					if (instancia != null)
					{
						instancia.Detener(false);
					}
				}
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
						string empty = string.Empty;
						Texture2D texture2D;
						SaveLoadPoses.Cargar(item, out texture2D, ref empty);
						try
						{
							if (empty.Length == 0)
							{
								Singleton<MainCanvas>.instance.MostrartMsg("Custom Poses", "Invalid Pose File", 3f, false, null, null, null);
								return;
							}
							TargetChar instance = TargetChar.instance;
							Character character = ((instance != null) ? instance.character : null);
							if (character != null)
							{
								InteraccionPrimariaName interaccionPrimariaName;
								bool flag;
								this.m_interacciones.ObtenerNextCustom(out interaccionPrimariaName, out flag);
								SaveLoadCustomPoses.LoadSavedData(character, ref empty, interaccionPrimariaName.GetInteractionID(), null, null);
								this.GetInter(interaccionPrimariaName).instancia.ForzarEjecucion(-1f, 1f, 1f, 1f, true, flag);
							}
						}
						finally
						{
							Object.Destroy(texture2D);
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

		// Token: 0x0600049A RID: 1178 RVA: 0x00016AE2 File Offset: 0x00014CE2
		protected override void OnLoadedItems(LoaderDeTHSDona caller)
		{
		}

		// Token: 0x0600049B RID: 1179 RVA: 0x00016AE4 File Offset: 0x00014CE4
		protected override void OnUserAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x0600049C RID: 1180 RVA: 0x00016AE6 File Offset: 0x00014CE6
		protected override void OnUserGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x0400020E RID: 526
		private InteraccionesBasicasDeFemale m_interacciones;

		// Token: 0x0400020F RID: 527
		private InteraccionDeCharacterFemenino m_customInteraccionA;

		// Token: 0x04000210 RID: 528
		private InteraccionDeCharacterFemenino m_customInteraccionB;

		// Token: 0x04000211 RID: 529
		private InteraccionTransicionController m_InteraccionTransicionController;

		// Token: 0x04000212 RID: 530
		public bool esDetener;
	}
}
