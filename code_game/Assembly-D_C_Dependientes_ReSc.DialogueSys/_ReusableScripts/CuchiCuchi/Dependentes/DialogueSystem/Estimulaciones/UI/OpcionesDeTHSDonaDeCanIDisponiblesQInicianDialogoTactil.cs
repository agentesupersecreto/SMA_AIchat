using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Language.Lua;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.UI
{
	// Token: 0x0200005C RID: 92
	public sealed class OpcionesDeTHSDonaDeCanIDisponiblesQInicianDialogoTactil : OpcionesDeTHSDonaDeCanIDisponibles
	{
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x0000E149 File Offset: 0x0000C349
		public override int TipoID
		{
			get
			{
				return (int)this.m_tipoDeEstimuloTactil;
			}
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0000E154 File Offset: 0x0000C354
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_owner = this.GetComponentEnRoot(false);
			this.m_Personalidad = this.m_owner.GetComponentInChildren<Personalidad>();
			if (this.m_owner == null)
			{
				throw new ArgumentNullException("m_owner", "m_owner null reference.");
			}
			if (this.m_Personalidad == null)
			{
				throw new ArgumentNullException("m_Personalidad", "m_Personalidad null reference.");
			}
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0000E1C4 File Offset: 0x0000C3C4
		private void StartConversation()
		{
			if (!DialogueManager.IsConversationActive)
			{
				OpcionesDeTHSDonaDeCanIDisponiblesQInicianDialogoTactil.SetVariablesCanI(base.selectedKeys, this.m_tipoDeEstimuloTactil);
				OpcionesDeTHSDonaDeCanIDisponiblesQInicianDialogoTactil.SetVariables(this.m_Personalidad, this.m_tipoDeEstimuloTactil, base.selectedKeys, 0, MainChar.current, this.m_owner);
				this.m_owner.TrySerConversarzado(MainChar.current, this.m_conversation);
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0000E223 File Offset: 0x0000C423
		protected override void OnUserAceptar(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
			if (base.selected.Count == 0)
			{
				return;
			}
			this.StartConversation();
			sender.StopDrawing();
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0000E23F File Offset: 0x0000C43F
		protected override void OnItemClicked(THSDonaController.CurrentUserData currentUserData, THSDonaController dona, THSDonaController.RadialItemData sender)
		{
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0000E241 File Offset: 0x0000C441
		protected override void OnUserGoBack(THSDonaController.CurrentUserData currentUserData, THSDonaController sender)
		{
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0000E243 File Offset: 0x0000C443
		protected override void OnLoadedItems(LoaderDeTHSDona caller)
		{
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0000E248 File Offset: 0x0000C448
		public static void SetVariables(Personalidad personalidad, TipoDeEstimuloTactil tipoDeEstimuloTactil, IReadOnlyList<int> keysSelected, int currentIndex, Character actor, Character conversant)
		{
			Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuestaDeDialogoDeHeroina = Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable;
			Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuestaDeDialogoDeHeroina2 = personalidad.ObtenerTipoDeRespuestaSegunPersonalidadYEmociones();
			string text = ObtenerDialogosUtil.ObternerStringDeTipoDeEstimuloTactil(TipoDeStringAccion.nombre, tipoDeRespuestaDeDialogoDeHeroina, DireccionDeEstimulo.recibida, tipoDeEstimuloTactil, true);
			string text2 = ObtenerDialogosUtil.ObternerStringDeTipoDeEstimuloTactil(TipoDeStringAccion.nombre, tipoDeRespuestaDeDialogoDeHeroina2, DireccionDeEstimulo.recibida, tipoDeEstimuloTactil, false);
			string text3 = ObtenerDialogosUtil.ObternerStringDeTipoDeEstimuloTactil(TipoDeStringAccion.pasado, tipoDeRespuestaDeDialogoDeHeroina, DireccionDeEstimulo.recibida, tipoDeEstimuloTactil, true);
			string text4 = ObtenerDialogosUtil.ObternerStringDeTipoDeEstimuloTactil(TipoDeStringAccion.pasado, tipoDeRespuestaDeDialogoDeHeroina2, DireccionDeEstimulo.recibida, tipoDeEstimuloTactil, false);
			string text5 = ObtenerDialogosUtil.ObternerStringDeTipoDeEstimuloTactil(TipoDeStringAccion.presente, tipoDeRespuestaDeDialogoDeHeroina, DireccionDeEstimulo.recibida, tipoDeEstimuloTactil, true);
			string text6 = ObtenerDialogosUtil.ObternerStringDeTipoDeEstimuloTactil(TipoDeStringAccion.presente, tipoDeRespuestaDeDialogoDeHeroina2, DireccionDeEstimulo.recibida, tipoDeEstimuloTactil, false);
			string text7 = ObtenerDialogosUtil.ObternerStringDeTipoDeEstimuloTactil(TipoDeStringAccion.conjugada, tipoDeRespuestaDeDialogoDeHeroina2, DireccionDeEstimulo.recibida, tipoDeEstimuloTactil, false);
			DialogueLua.SetVariable("TipoDeEstimulo", 1);
			DialogueLua.SetVariable("TipoDeEstimuloEspecifico", (int)tipoDeEstimuloTactil);
			DialogueLua.SetVariable("toHeroNombreDeAccion", text);
			DialogueLua.SetVariable("toHeroinaNombreDeAccion", text2);
			DialogueLua.SetVariable("toHeroNombreDeAccionPasado", text3);
			DialogueLua.SetVariable("toHeroinaNombreDeAccionPasado", text4);
			DialogueLua.SetVariable("toHeroNombreDeAccionPresente", text5);
			DialogueLua.SetVariable("toHeroinaNombreDeAccionPresente", text6);
			DialogueLua.SetVariable("toHeroinaNombreDeAccionesConjugado", text7);
			int num = keysSelected[currentIndex];
			DialogueLua.SetVariable("PARTE_SELEC_MAIN", OpcionesDeTHSDonaDeCanIDisponibles.mainSelected[num]);
			LuaTable luaTable = new LuaTable();
			for (int i = 0; i < OpcionesDeTHSDonaDeCanIDisponibles.allSelected[num].Length; i++)
			{
				luaTable.AddValue(new LuaString(Convert.ToString(OpcionesDeTHSDonaDeCanIDisponibles.allSelected[num][i], CultureInfo.InvariantCulture)));
			}
			DialogueLua.SetVariable("PARTES_SELEC", luaTable);
			Singleton<DialogueSystemCharacterIDVariables>.instance.ForceToSetActorsVariables(actor, conversant);
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0000E3B0 File Offset: 0x0000C5B0
		public static void SetLastVariables(IReadOnlyList<int> keysSelected, int lastIndex)
		{
			if (!keysSelected.ContieneIndexReadOnly(lastIndex))
			{
				throw new InvalidOperationException();
			}
			int num = keysSelected[lastIndex];
			DialogueLua.SetVariable("PARTE_LAST_SELEC_MAIN", OpcionesDeTHSDonaDeCanIDisponibles.mainSelected[num]);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0000E3F0 File Offset: 0x0000C5F0
		public static void SetVariablesCanI(IReadOnlyList<int> keysSelected, TipoDeEstimuloTactil tipoDeEstimuloTactil)
		{
			LuaTable luaTable = new LuaTable();
			for (int i = 0; i < keysSelected.Count; i++)
			{
				luaTable.AddValue(new LuaString(Convert.ToString(keysSelected[i], CultureInfo.InvariantCulture)));
			}
			DialogueLua.SetVariable("PARTE_SELEC_KEYS_CanI", luaTable);
			DialogueLua.SetVariable("PARTE_TIPOTACTIL_CanI", tipoDeEstimuloTactil.ToString());
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0000E454 File Offset: 0x0000C654
		public static IReadOnlyList<int> GetKeySelectedVariables()
		{
			return new List<int>(DialogueLua.GetVariable("PARTE_SELEC_KEYS_CanI").AsTable.luaTable.ListValues.Select((LuaValue val) => Convert.ToInt32(val.Value)));
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0000E4A8 File Offset: 0x0000C6A8
		public static TipoDeEstimuloTactil GetTipoDeEstimuloTactil()
		{
			return DialogueLua.GetVariable("PARTE_TIPOTACTIL_CanI").AsString.ToEnum(TipoDeEstimuloTactil.None);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0000E4CD File Offset: 0x0000C6CD
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Debug: Start Conversation",
				editorTimeVisible = false
			};
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0000E4E6 File Offset: 0x0000C6E6
		protected override void OnAplicar2()
		{
			this.StartConversation();
		}

		// Token: 0x04000121 RID: 289
		public const string varNameParts = "PARTES_SELEC";

		// Token: 0x04000122 RID: 290
		public const string varNameMainPart = "PARTE_SELEC_MAIN";

		// Token: 0x04000123 RID: 291
		public const string varNameLastMainPart = "PARTE_LAST_SELEC_MAIN";

		// Token: 0x04000124 RID: 292
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;

		// Token: 0x04000125 RID: 293
		private Character m_owner;

		// Token: 0x04000126 RID: 294
		private Personalidad m_Personalidad;

		// Token: 0x04000127 RID: 295
		[SerializeField]
		private TipoDeEstimuloTactil m_tipoDeEstimuloTactil;
	}
}
