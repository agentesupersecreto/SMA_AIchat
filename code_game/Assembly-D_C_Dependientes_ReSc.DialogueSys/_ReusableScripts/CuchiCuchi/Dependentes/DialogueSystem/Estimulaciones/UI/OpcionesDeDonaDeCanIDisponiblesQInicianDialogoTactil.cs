using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.UI
{
	// Token: 0x02000057 RID: 87
	[Obsolete("usar la version para THS")]
	public sealed class OpcionesDeDonaDeCanIDisponiblesQInicianDialogoTactil : OpcionesDeDonaDeCanIDisponibles
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000288 RID: 648 RVA: 0x0000D007 File Offset: 0x0000B207
		public override int TipoID
		{
			get
			{
				return (int)this.m_tipoDeEstimuloTactil;
			}
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000D010 File Offset: 0x0000B210
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

		// Token: 0x0600028A RID: 650 RVA: 0x0000D07D File Offset: 0x0000B27D
		protected override void OnOpccionCliked(int index, int Key, IUIElementoConValor button, DonaDeInteraccionBase dona)
		{
			base.OnOpccionCliked(index, Key, button, dona);
			this.StartConversation();
			dona.StopDrawing();
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000D098 File Offset: 0x0000B298
		private void StartConversation()
		{
			if (!DialogueManager.IsConversationActive)
			{
				Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuestaDeDialogoDeHeroina = Personalidad.TipoDeRespuestaDeDialogoDeHeroina.amable;
				Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuestaDeDialogoDeHeroina2 = this.m_Personalidad.ObtenerTipoDeRespuestaSegunPersonalidadYEmociones();
				string text = ObtenerDialogosUtil.ObternerStringDeTipoDeEstimuloTactil(TipoDeStringAccion.nombre, tipoDeRespuestaDeDialogoDeHeroina, DireccionDeEstimulo.recibida, this.m_tipoDeEstimuloTactil, true);
				string text2 = ObtenerDialogosUtil.ObternerStringDeTipoDeEstimuloTactil(TipoDeStringAccion.nombre, tipoDeRespuestaDeDialogoDeHeroina2, DireccionDeEstimulo.recibida, this.m_tipoDeEstimuloTactil, false);
				string text3 = ObtenerDialogosUtil.ObternerStringDeTipoDeEstimuloTactil(TipoDeStringAccion.presente, tipoDeRespuestaDeDialogoDeHeroina2, DireccionDeEstimulo.recibida, this.m_tipoDeEstimuloTactil, false);
				string text4 = ObtenerDialogosUtil.ObternerStringDeTipoDeEstimuloTactil(TipoDeStringAccion.pasado, tipoDeRespuestaDeDialogoDeHeroina2, DireccionDeEstimulo.recibida, this.m_tipoDeEstimuloTactil, false);
				string text5 = ObtenerDialogosUtil.ObternerStringDeTipoDeEstimuloTactil(TipoDeStringAccion.conjugada, tipoDeRespuestaDeDialogoDeHeroina2, DireccionDeEstimulo.recibida, this.m_tipoDeEstimuloTactil, false);
				DialogueLua.SetVariable("TipoDeEstimulo", 1);
				DialogueLua.SetVariable("TipoDeEstimuloEspecifico", (int)this.m_tipoDeEstimuloTactil);
				DialogueLua.SetVariable("toHeroNombreDeAccion", text);
				DialogueLua.SetVariable("toHeroinaNombreDeAccion", text2);
				DialogueLua.SetVariable("toHeroinaNombreDeAccionPresente", text3);
				DialogueLua.SetVariable("toHeroinaNombreDeAccionPasado", text4);
				DialogueLua.SetVariable("toHeroinaNombreDeAccionesConjugado", text5);
				Singleton<DialogueSystemCharacterIDVariables>.instance.ForceToSetActorsVariables(MainChar.current, this.m_owner);
				DialogueManager.Instance.StartConversation(this.m_conversation, MainChar.current.bodyAnimator.transform, this.m_owner.bodyAnimator.transform);
			}
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000D1B3 File Offset: 0x0000B3B3
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Debug: Start Conversation",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0000D1CC File Offset: 0x0000B3CC
		protected override void OnAplicar2()
		{
			this.StartConversation();
		}

		// Token: 0x04000109 RID: 265
		[ConversationPopup(false)]
		[SerializeField]
		private string m_conversation;

		// Token: 0x0400010A RID: 266
		private Character m_owner;

		// Token: 0x0400010B RID: 267
		private Personalidad m_Personalidad;

		// Token: 0x0400010C RID: 268
		[SerializeField]
		private TipoDeEstimuloTactil m_tipoDeEstimuloTactil;
	}
}
