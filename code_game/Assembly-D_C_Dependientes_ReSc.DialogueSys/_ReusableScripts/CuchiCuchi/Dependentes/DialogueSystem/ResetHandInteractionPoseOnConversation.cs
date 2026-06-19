using System;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Characters.Controlladores;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x0200001D RID: 29
	public class ResetHandInteractionPoseOnConversation : OnConversationBase
	{
		// Token: 0x06000105 RID: 261 RVA: 0x000058D4 File Offset: 0x00003AD4
		protected void Awake()
		{
			this.m_character = base.GetComponentInParent<Character>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.controller = base.GetComponentInChildren<HandControllerV2>();
			if (this.controller == null)
			{
				throw new ArgumentNullException("controller", "controller null reference.");
			}
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00005935 File Offset: 0x00003B35
		protected override Transform ObtenerCurrentActor()
		{
			return this.m_character.transform;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00005942 File Offset: 0x00003B42
		protected override void OnConversationComienza(Transform currentActor, Transform currentConversant)
		{
			this.m_t = 0f;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0000594F File Offset: 0x00003B4F
		protected override void OnConversationTermina(Transform currentActor, Transform currentConversant)
		{
			this.m_t = 0f;
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0000595C File Offset: 0x00003B5C
		private void Update()
		{
			if (!this.controller.enabled)
			{
				this.m_t = float.MaxValue;
				return;
			}
			if (this.m_t > 1f)
			{
				return;
			}
			Vector2 vector = new Vector2(0.5f, 0.6f);
			Vector2 currentInitialViewPosition;
			float num;
			if (base.enConversacion)
			{
				currentInitialViewPosition = new Vector2(1f, 0f);
				num = this.controller.handCameraController.depthPositionContainer.minDepth;
			}
			else
			{
				currentInitialViewPosition = this.controller.GetCurrentInitialViewPosition();
				num = 0f;
			}
			this.m_t += Time.deltaTime;
			this.controller.handCameraController.viewPortPositionContainer.viewportPosition = Vector2.Lerp(this.controller.handCameraController.viewPortPositionContainer.viewportPosition, currentInitialViewPosition, this.m_t);
			this.controller.handCameraController.viewPortPositionContainer.viewportLookAtPosition = Vector2.Lerp(this.controller.handCameraController.viewPortPositionContainer.viewportLookAtPosition, vector, this.m_t);
			this.controller.handCameraController.depthPositionContainer.depthPosition = Mathf.Lerp(this.controller.handCameraController.depthPositionContainer.depthPosition, num, this.m_t);
		}

		// Token: 0x04000079 RID: 121
		private Character m_character;

		// Token: 0x0400007A RID: 122
		private HandControllerV2 controller;

		// Token: 0x0400007B RID: 123
		[NonSerialized]
		private float m_t = float.MaxValue;
	}
}
