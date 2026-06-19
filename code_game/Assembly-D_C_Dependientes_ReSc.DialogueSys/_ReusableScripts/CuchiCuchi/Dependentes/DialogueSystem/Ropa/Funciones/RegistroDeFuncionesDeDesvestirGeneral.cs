using System;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias.AI.Ropa;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using PixelCrushers.DialogueSystem;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Ropa.Funciones
{
	// Token: 0x0200003A RID: 58
	public class RegistroDeFuncionesDeDesvestirGeneral : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x060001A3 RID: 419 RVA: 0x00007E60 File Offset: 0x00006060
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			Lua.RegisterFunction("EstaDesnudo", this, base.GetType().GetMethod("EstaDesnudo"));
			Lua.RegisterFunction("DijoEstarDesnudo", this, base.GetType().GetMethod("DijoEstarDesnudo"));
			Lua.RegisterFunction("RegisDijoEstarDesnudo", this, base.GetType().GetMethod("RegisDijoEstarDesnudo"));
			Lua.RegisterFunction("AlgunaPrendaConsentida", this, base.GetType().GetMethod("AlgunaPrendaConsentida"));
			Lua.RegisterFunction("DijoNingunaPrendaConsentida", this, base.GetType().GetMethod("DijoNingunaPrendaConsentida"));
			Lua.RegisterFunction("RegisDijoNingunaPrendaConsentida", this, base.GetType().GetMethod("RegisDijoNingunaPrendaConsentida"));
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x00007F18 File Offset: 0x00006118
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			Lua.UnregisterFunction("EstaDesnudo");
			Lua.UnregisterFunction("DijoEstarDesnudo");
			Lua.UnregisterFunction("RegisDijoEstarDesnudo");
			Lua.UnregisterFunction("AlgunaPrendaConsentida");
			Lua.UnregisterFunction("DijoNingunaPrendaConsentida");
			Lua.UnregisterFunction("RegisDijoNingunaPrendaConsentida");
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00007F68 File Offset: 0x00006168
		private Character ObtenerCharacter(string id)
		{
			Guid guid = Guid.Parse(id);
			return Singleton<CharacteresActivos>.instance.Obtener<Character>(guid);
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00007F88 File Offset: 0x00006188
		public bool AlgunaPrendaConsentida(string id)
		{
			bool flag;
			try
			{
				flag = this.ObtenerCharacter(id).GetComponentInChildren<ConsentNecesario>().AlgunoConsentidoSinJerarquia(TipoDeEstimulo.peticionDesvestidura, DireccionDeEstimulo.recibida, null, null, null);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00007FD4 File Offset: 0x000061D4
		public bool DijoNingunaPrendaConsentida(string id)
		{
			bool flag;
			try
			{
				flag = this.ObtenerCharacter(id).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>().RegistrardaDijoNingunaPrendaConsent();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00008010 File Offset: 0x00006210
		public void RegisDijoNingunaPrendaConsentida(string id)
		{
			try
			{
				this.ObtenerCharacter(id).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>().RegistrarDijoNingunaPrendaConsent();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00008048 File Offset: 0x00006248
		public bool EstaDesnudo(string id)
		{
			bool flag;
			try
			{
				flag = this.ObtenerCharacter(id).GetComponentInChildren<IRopaManager>().CantidadPiezasCubriendo((RopaCubre)(-1), true, null) <= 0;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00008090 File Offset: 0x00006290
		public bool DijoEstarDesnudo(string id)
		{
			bool flag;
			try
			{
				flag = this.ObtenerCharacter(id).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>().RegistrardaDijoEstarDesnuda();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060001AB RID: 427 RVA: 0x000080CC File Offset: 0x000062CC
		public void RegisDijoEstarDesnudo(string id)
		{
			try
			{
				this.ObtenerCharacter(id).GetComponentInChildrenNotNull<MemoriaDeRegistroDePeticionesDeQuitarRopa>().RegistrarDijoEstarDesnuda();
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
			}
		}
	}
}
