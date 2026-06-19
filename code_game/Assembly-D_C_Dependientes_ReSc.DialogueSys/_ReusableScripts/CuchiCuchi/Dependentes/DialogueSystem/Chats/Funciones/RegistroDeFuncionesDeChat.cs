using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Chats.Funciones
{
	// Token: 0x0200006E RID: 110
	public class RegistroDeFuncionesDeChat : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x0600032D RID: 813 RVA: 0x000107C5 File Offset: 0x0000E9C5
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("ConoceMainCharacter", this, base.GetType().GetMethod("ConoceMainCharacter"));
			Lua.RegisterFunction("RegistrarComoDescritoVisualmente", this, base.GetType().GetMethod("RegistrarComoDescritoVisualmente"));
		}

		// Token: 0x0600032E RID: 814 RVA: 0x00010803 File Offset: 0x0000EA03
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("ConoceMainCharacter");
			Lua.UnregisterFunction("RegistrarComoDescritoVisualmente");
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00010820 File Offset: 0x0000EA20
		public bool ConoceMainCharacter(string id)
		{
			bool flag;
			try
			{
				Guid guid = Guid.Parse(id);
				flag = Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<MemoriaDeCharacterGeneralPermanente>().ConoceACurrentMainCharacter();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = true;
			}
			return flag;
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00010868 File Offset: 0x0000EA68
		public void RegistrarComoDescritoVisualmente(string id)
		{
			try
			{
				Guid guid = Guid.Parse(id);
				MemoriaDeCharacterBase.Registrar(Singleton<CharacteresActivos>.instance.Obtener<Character>(guid).GetComponentInChildren<MemoriaDeCharacterGeneralTemporal>(), "DescritaVisualmente", "General", true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x0400014A RID: 330
		public const string descritaVisualmente = "DescritaVisualmente";

		// Token: 0x0400014B RID: 331
		public const string generalmente = "General";
	}
}
