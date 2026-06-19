using System;
using System.Linq;
using Assets.Base.RootMotion.BeachGirl.Runtime.Controllers.Interacciones;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.UI;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Interacciones.UI
{
	// Token: 0x02000041 RID: 65
	public abstract class OpcionesDeTHSDonaDeInteraccionesDisponibles : GenericOpcionesDeTHSDonaDeKeys<int>
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060001DD RID: 477 RVA: 0x0000946F File Offset: 0x0000766F
		public IInteraccionesDeCharacter interacciones
		{
			get
			{
				return this.m_interacciones;
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060001DE RID: 478 RVA: 0x00009477 File Offset: 0x00007677
		public Personalidad personalidad
		{
			get
			{
				return this.m_personalidad;
			}
		}

		// Token: 0x060001DF RID: 479 RVA: 0x00009480 File Offset: 0x00007680
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_interacciones = this.GetComponentEnRoot(false);
			if (this.m_interacciones == null)
			{
				throw new ArgumentNullException("m_interacciones", "m_interacciones null reference.");
			}
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
			this.m_InteraccionTransicionController = this.GetComponentEnRoot(false);
			if (this.m_InteraccionTransicionController == null)
			{
				throw new ArgumentNullException("m_InteraccionTransicionController", "m_InteraccionTransicionController null reference.");
			}
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x00009514 File Offset: 0x00007714
		protected override bool IndexEsGreyOut(int index)
		{
			return base.IndexEsGreyOut(index) || this.m_InteraccionTransicionController.currentStado.Ejecutandose(0);
		}

		// Token: 0x060001E1 RID: 481
		protected abstract bool LoadOnlyEjecutandose();

		// Token: 0x060001E2 RID: 482 RVA: 0x00009534 File Offset: 0x00007734
		protected override void LoadKeys(HashSetList<int> resultado)
		{
			for (int i = 0; i < this.m_interacciones.interaccionesPrimarias.Count; i++)
			{
				InteraccionDeCharacterFemenino interaccionDeCharacterFemenino = this.m_interacciones.interaccionesPrimarias[i];
				if (interaccionDeCharacterFemenino.instancia.gameObject.activeInHierarchy)
				{
					Interaccion instancia = interaccionDeCharacterFemenino.instancia;
					if (!(((instancia != null) ? instancia.GetComponent<InteraccionStrings>() : null) == null) && !(((instancia != null) ? instancia.GetComponent<InteraccionPersonalidadData>() : null) == null))
					{
						if (instancia.algunaEstaEjecutandose)
						{
							resultado.Clear();
							resultado.Add(interaccionDeCharacterFemenino.id);
							return;
						}
						if (interaccionDeCharacterFemenino.id != InteraccionPrimariaName.customA.GetInteractionID() && interaccionDeCharacterFemenino.id != InteraccionPrimariaName.customB.GetInteractionID() && instancia.PuedeEjecutarse() && this.m_interacciones.ContieneAndIsValido(interaccionDeCharacterFemenino.id) && !this.LoadOnlyEjecutandose())
						{
							resultado.Add(interaccionDeCharacterFemenino.id);
						}
					}
				}
			}
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00009622 File Offset: 0x00007822
		protected override int KeyDeItemKey(string key, int index)
		{
			return this.m_dibujando[index];
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00009630 File Offset: 0x00007830
		protected override string KeyDeIndex(int index)
		{
			return this.m_dibujando[index].ToString();
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00009654 File Offset: 0x00007854
		protected override string TextDeKey(int key)
		{
			string text;
			try
			{
				InteraccionStrings component = this.m_interacciones.interaccionPrimariaDeID[key].instancia.GetComponent<InteraccionStrings>();
				text = component.segunda.CurrentTextFormal(component.segunda.GenericEsDetener());
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = key.ToString();
			}
			return text;
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x000096B8 File Offset: 0x000078B8
		protected override void OnDonaShowed(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			base.OnDonaShowed(currentUserData, sender);
			this.esDetener = false;
			this.ejecutarForzando = false;
			this.puedeEjecutarse = false;
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x000096D8 File Offset: 0x000078D8
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
			InteraccionDeCharacter interaccionDeCharacter = this.m_interacciones.ObtenerFirstEjecutandosePrimaria();
			bool? flag;
			if (interaccionDeCharacter == null)
			{
				flag = null;
			}
			else
			{
				Interaccion instancia = interaccionDeCharacter.instancia;
				flag = ((instancia != null) ? new bool?(instancia.algunaEstaEjecutandose) : null);
			}
			bool? flag2 = flag;
			this.esDetener = flag2.GetValueOrDefault(false);
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x0000972C File Offset: 0x0000792C
		protected void SetVariables()
		{
			DialogueLua.SetVariable("SELECTED_POSE_ID", base.selectedKeys.Last<int>());
			DialogueLua.SetVariable("SELECTED_POSE_ES_DETENER", this.esDetener);
			DialogueLua.SetVariable("SELECTED_POSE_PUEDE_EJECUTARSE", this.puedeEjecutarse);
			DialogueLua.SetVariable("SELECTED_POSE_FORZAR_EJECUTADO", this.ejecutarForzando);
			DialogueLua.SetVariable("SELECTED_POSE_TEXTO", base.selected.Last<THSDonaController.RadialItemData>().text);
			DialogueLua.SetVariable("SELECTED_POSE_TRY_USAR_TRANSICION", false);
		}

		// Token: 0x040000D9 RID: 217
		private InteraccionesBasicasDeFemale m_interacciones;

		// Token: 0x040000DA RID: 218
		private Personalidad m_personalidad;

		// Token: 0x040000DB RID: 219
		public bool esDetener;

		// Token: 0x040000DC RID: 220
		public bool ejecutarForzando;

		// Token: 0x040000DD RID: 221
		public bool puedeEjecutarse;

		// Token: 0x040000DE RID: 222
		private InteraccionTransicionController m_InteraccionTransicionController;
	}
}
