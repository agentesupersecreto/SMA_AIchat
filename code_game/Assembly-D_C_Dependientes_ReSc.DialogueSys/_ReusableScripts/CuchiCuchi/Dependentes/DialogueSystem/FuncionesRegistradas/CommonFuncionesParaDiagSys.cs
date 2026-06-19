using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.FuncionesRegistradas
{
	// Token: 0x02000051 RID: 81
	public class CommonFuncionesParaDiagSys : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000267 RID: 615 RVA: 0x0000CB34 File Offset: 0x0000AD34
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("IsLegacyGoTo", this, base.GetType().GetMethod("IsLegacyGoTo"));
		}

		// Token: 0x06000268 RID: 616 RVA: 0x0000CB57 File Offset: 0x0000AD57
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("IsLegacyGoTo");
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000CB6C File Offset: 0x0000AD6C
		public bool IsLegacyGoTo()
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(DialogueLua.GetVariable("ConversantID").AsString);
				Character character = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
				ICharacterNavegable characterNavegable = ((character != null) ? character.GetComponentEnRoot<ICharacterNavegable>() : null);
				flag = Singleton<ConfiguracionGeneralDeGamePlay>.instance.current.useLegacyGoTo || characterNavegable == null;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = true;
			}
			return flag;
		}
	}
}
