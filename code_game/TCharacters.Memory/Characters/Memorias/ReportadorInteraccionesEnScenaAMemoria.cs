using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets._ReusableScripts.CuchiCuchi.Scenas;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Memorias
{
	// Token: 0x02000008 RID: 8
	public class ReportadorInteraccionesEnScenaAMemoria : CustomMonobehaviour
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000037 RID: 55 RVA: 0x00003558 File Offset: 0x00001758
		// (remove) Token: 0x06000038 RID: 56 RVA: 0x00003590 File Offset: 0x00001790
		public event OnRegistroChangedHandler onRegistroRecibidoChanged;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000039 RID: 57 RVA: 0x000035C8 File Offset: 0x000017C8
		// (remove) Token: 0x0600003A RID: 58 RVA: 0x00003600 File Offset: 0x00001800
		public event OnRegistroChangedHandler onRegistroDadoChanged;

		// Token: 0x0600003B RID: 59 RVA: 0x00003635 File Offset: 0x00001835
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_ownSceneCharacter = this.GetComponentEnRoot(false);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x0000364A File Offset: 0x0000184A
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			if (Singleton<InteraccionesEnScena>.IsInScene)
			{
				Singleton<InteraccionesEnScena>.instance.onRegister += this.Instance_onRegister;
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x0000366F File Offset: 0x0000186F
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (Singleton<InteraccionesEnScena>.IsInScene)
			{
				Singleton<InteraccionesEnScena>.instance.onRegister -= this.Instance_onRegister;
			}
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00003698 File Offset: 0x00001898
		private void Instance_onRegister(ref Interaction register, ICharactersSceneInteractions Interactions, SceneCharacter from, SceneCharacter to, ISceneInteractions sender)
		{
			if (this.m_ownSceneCharacter == from)
			{
				OnRegistroChangedHandler onRegistroChangedHandler = this.onRegistroDadoChanged;
				if (onRegistroChangedHandler != null)
				{
					onRegistroChangedHandler(ref register);
				}
			}
			if (this.m_ownSceneCharacter == to)
			{
				OnRegistroChangedHandler onRegistroChangedHandler2 = this.onRegistroRecibidoChanged;
				if (onRegistroChangedHandler2 == null)
				{
					return;
				}
				onRegistroChangedHandler2(ref register);
			}
		}

		// Token: 0x04000016 RID: 22
		private SceneCharacter m_ownSceneCharacter;
	}
}
