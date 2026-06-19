using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Language.Lua;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.UI
{
	// Token: 0x02000059 RID: 89
	[Obsolete("usar la version para THS")]
	public sealed class OpcionesDeDonaDeCanITodosDisponiblesQInicianDialogoTactil : OpcionesDeDonaDeCanITodosDisponibles
	{
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000298 RID: 664 RVA: 0x0000D7BC File Offset: 0x0000B9BC
		public override int TipoID
		{
			get
			{
				return (int)this.m_tipoDeEstimuloTactil;
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0000D7C4 File Offset: 0x0000B9C4
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

		// Token: 0x0600029A RID: 666 RVA: 0x0000D831 File Offset: 0x0000BA31
		protected override void OnAcceptarClicked(IUIElementoConValor boton, DonaDeInteraccionBase dona)
		{
			if (base.todosLosSelected.Count == 0)
			{
				return;
			}
			this.StartConversation();
			dona.StopDrawing();
		}

		// Token: 0x0600029B RID: 667 RVA: 0x0000D84D File Offset: 0x0000BA4D
		protected override void OnOpccionCliked(int index, int Key, IUIElementoConValor button, DonaDeInteraccionBase dona)
		{
			base.OnOpccionCliked(index, Key, button, dona);
		}

		// Token: 0x0600029C RID: 668 RVA: 0x0000D85C File Offset: 0x0000BA5C
		private void StartConversation()
		{
			if (!DialogueManager.IsConversationActive)
			{
				int[] array = base.todosLosSelected.Select((OpcionesDeDonaDeCanITodosDisponibles.CurrentToggled item) => item.key).ToArray<int>();
				OpcionesDeDonaDeCanITodosDisponiblesQInicianDialogoTactil.SetVariablesCanI(array, this.m_tipoDeEstimuloTactil);
				OpcionesDeDonaDeCanITodosDisponiblesQInicianDialogoTactil.SetVariables(this.m_Personalidad, this.m_tipoDeEstimuloTactil, array, 0, MainChar.current, this.m_owner);
				DialogueManager.Instance.StartConversation(this.m_conversation, MainChar.current.bodyAnimator.transform, this.m_owner.bodyAnimator.transform);
			}
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0000D8FC File Offset: 0x0000BAFC
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
			DialogueLua.SetVariable("PARTE_SELEC_MAIN", OpcionesDeDonaDeCanITodosDisponibles.mainSelected[num]);
			LuaTable luaTable = new LuaTable();
			for (int i = 0; i < OpcionesDeDonaDeCanITodosDisponibles.allSelected[num].Length; i++)
			{
				luaTable.AddValue(new LuaString(Convert.ToString(OpcionesDeDonaDeCanITodosDisponibles.allSelected[num][i], CultureInfo.InvariantCulture)));
			}
			DialogueLua.SetVariable("PARTES_SELEC", luaTable);
			Singleton<DialogueSystemCharacterIDVariables>.instance.ForceToSetActorsVariables(actor, conversant);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x0000DA64 File Offset: 0x0000BC64
		public static void SetLastVariables(IReadOnlyList<int> keysSelected, int lastIndex)
		{
			if (!keysSelected.ContieneIndexReadOnly(lastIndex))
			{
				throw new InvalidOperationException();
			}
			int num = keysSelected[lastIndex];
			DialogueLua.SetVariable("PARTE_LAST_SELEC_MAIN", OpcionesDeDonaDeCanITodosDisponibles.mainSelected[num]);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x0000DAA4 File Offset: 0x0000BCA4
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

		// Token: 0x060002A0 RID: 672 RVA: 0x0000DB08 File Offset: 0x0000BD08
		public static IReadOnlyList<int> GetKeySelectedVariables()
		{
			return new List<int>(DialogueLua.GetVariable("PARTE_SELEC_KEYS_CanI").AsTable.luaTable.ListValues.Select((LuaValue val) => Convert.ToInt32(val.Value)));
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x0000DB5C File Offset: 0x0000BD5C
		public static TipoDeEstimuloTactil GetTipoDeEstimuloTactil()
		{
			return DialogueLua.GetVariable("PARTE_TIPOTACTIL_CanI").AsString.ToEnum(TipoDeEstimuloTactil.None);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x0000DB81 File Offset: 0x0000BD81
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Debug: Start Conversation",
				editorTimeVisible = false
			};
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x0000DB9A File Offset: 0x0000BD9A
		protected override void OnAplicar2()
		{
			this.StartConversation();
		}

		// Token: 0x04000113 RID: 275
		public const string varNameParts = "PARTES_SELEC";

		// Token: 0x04000114 RID: 276
		public const string varNameMainPart = "PARTE_SELEC_MAIN";

		// Token: 0x04000115 RID: 277
		public const string varNameLastMainPart = "PARTE_LAST_SELEC_MAIN";

		// Token: 0x04000116 RID: 278
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;

		// Token: 0x04000117 RID: 279
		private Character m_owner;

		// Token: 0x04000118 RID: 280
		private Personalidad m_Personalidad;

		// Token: 0x04000119 RID: 281
		[SerializeField]
		private TipoDeEstimuloTactil m_tipoDeEstimuloTactil;
	}
}
