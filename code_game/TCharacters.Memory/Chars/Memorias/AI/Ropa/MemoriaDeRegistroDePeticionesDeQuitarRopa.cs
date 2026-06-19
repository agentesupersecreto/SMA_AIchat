using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Ropa;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Memorias.AI.Ropa
{
	// Token: 0x02000010 RID: 16
	[MemoriaRelatedBehaviour]
	public class MemoriaDeRegistroDePeticionesDeQuitarRopa : AplicableBehaviour
	{
		// Token: 0x060000E3 RID: 227 RVA: 0x0000621E File Offset: 0x0000441E
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_memoria = this.GetComponentEnRoot(false);
			if (this.m_memoria == null)
			{
				throw new ArgumentNullException("m_memoria", "m_memoria null reference.");
			}
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00006251 File Offset: 0x00004451
		public void RegistrarDijoEstarDesnuda()
		{
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesEstoyDesnuda", "PeticionesEstoyDesnuda");
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00006268 File Offset: 0x00004468
		public void RegistrarDijoNingunaPrendaConsent()
		{
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesNingunaPrendaConsent", "PeticionesNingunaPrendaConsent");
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00006280 File Offset: 0x00004480
		public void RegistrarPeticion_FueraDeRango(RopaCubre cubre)
		{
			if (cubre == RopaCubre.None)
			{
				throw new InvalidOperationException();
			}
			MemoriaDeCharacterBase memoria = this.m_memoria;
			string text = "PeticionesRopaCubre_FueraDeRango";
			int num = (int)cubre;
			MemoriaDeCharacterBase.RegistrarCantidadPlus(memoria, text, num.ToString());
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x000062AF File Offset: 0x000044AF
		public void RegistrarPeticion_FueraDeRango(string nombreDePrenda)
		{
			if (nombreDePrenda == null)
			{
				throw new InvalidOperationException();
			}
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesNombreDePrenda_FueraDeRango", nombreDePrenda);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x000062CB File Offset: 0x000044CB
		public void RegistrarPeticion_FueraDeRango(int idDePrenda)
		{
			if (idDePrenda == 0)
			{
				throw new InvalidOperationException();
			}
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesIDDePrenda_FueraDeRango", idDePrenda.ToString());
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x000062F0 File Offset: 0x000044F0
		public void RegistrarPeticion_Negada(RopaCubre cubre)
		{
			if (cubre == RopaCubre.None)
			{
				throw new InvalidOperationException();
			}
			MemoriaDeCharacterBase memoria = this.m_memoria;
			string text = "PeticionesRopaCubre_Negada";
			int num = (int)cubre;
			MemoriaDeCharacterBase.RegistrarCantidadPlus(memoria, text, num.ToString());
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000631F File Offset: 0x0000451F
		public void RegistrarPeticion_Negada(string nombreDePrenda)
		{
			if (nombreDePrenda == null)
			{
				throw new InvalidOperationException();
			}
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesNombreDePrenda_Negada", nombreDePrenda);
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000633B File Offset: 0x0000453B
		public void RegistrarPeticion_Negada(int idDePrenda)
		{
			if (idDePrenda == 0)
			{
				throw new InvalidOperationException();
			}
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesIDDePrenda_Negada", idDePrenda.ToString());
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00006360 File Offset: 0x00004560
		public void RegistrarPeticion_Cumplida(RopaCubre cubre)
		{
			if (cubre == RopaCubre.None)
			{
				throw new InvalidOperationException();
			}
			MemoriaDeCharacterBase memoria = this.m_memoria;
			string text = "PeticionesRopaCubre_Cumplida";
			int num = (int)cubre;
			MemoriaDeCharacterBase.RegistrarCantidadPlus(memoria, text, num.ToString());
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000638F File Offset: 0x0000458F
		public void RegistrarPeticion_Cumplida(string nombreDePrenda)
		{
			if (nombreDePrenda == null)
			{
				throw new InvalidOperationException();
			}
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesNombreDePrenda_Cumplida", nombreDePrenda);
		}

		// Token: 0x060000EE RID: 238 RVA: 0x000063AB File Offset: 0x000045AB
		public void RegistrarPeticion_Cumplida(int idDePrenda)
		{
			if (idDePrenda == 0)
			{
				throw new InvalidOperationException();
			}
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesIDDePrenda_Cumplida", idDePrenda.ToString());
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000063CD File Offset: 0x000045CD
		public bool RegistrardaDijoEstarDesnuda()
		{
			return MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesEstoyDesnuda", "PeticionesEstoyDesnuda");
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000063E4 File Offset: 0x000045E4
		public bool RegistrardaDijoNingunaPrendaConsent()
		{
			return MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesNingunaPrendaConsent", "PeticionesNingunaPrendaConsent");
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000063FC File Offset: 0x000045FC
		public bool RegistradaPeticion_FueraDeRango(RopaCubre cubre)
		{
			if (cubre == RopaCubre.None)
			{
				return false;
			}
			MemoriaDeCharacterBase memoria = this.m_memoria;
			string text = "PeticionesRopaCubre_FueraDeRango";
			int num = (int)cubre;
			return MemoriaDeCharacterBase.CantidadFueRegistrada(memoria, text, num.ToString());
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00006427 File Offset: 0x00004627
		public bool RegistradaPeticion_FueraDeRango(string nombreDePrenda)
		{
			return nombreDePrenda != null && MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesNombreDePrenda_FueraDeRango", nombreDePrenda);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000643F File Offset: 0x0000463F
		public bool RegistradaPeticion_FueraDeRango(int idDePrenda)
		{
			return idDePrenda != 0 && MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesIDDePrenda_FueraDeRango", idDePrenda.ToString());
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x00006460 File Offset: 0x00004660
		public bool RegistradaPeticion_Negada(RopaCubre cubre)
		{
			if (cubre == RopaCubre.None)
			{
				return false;
			}
			MemoriaDeCharacterBase memoria = this.m_memoria;
			string text = "PeticionesRopaCubre_Negada";
			int num = (int)cubre;
			return MemoriaDeCharacterBase.CantidadFueRegistrada(memoria, text, num.ToString());
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000648B File Offset: 0x0000468B
		public bool RegistradaPeticion_Negada(string nombreDePrenda)
		{
			return nombreDePrenda != null && MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesNombreDePrenda_Negada", nombreDePrenda);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x000064A3 File Offset: 0x000046A3
		public bool RegistradaPeticion_Negada(int idDePrenda)
		{
			return idDePrenda != 0 && MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesIDDePrenda_Negada", idDePrenda.ToString());
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x000064C4 File Offset: 0x000046C4
		public bool RegistradaPeticion_Cumplida(RopaCubre cubre)
		{
			if (cubre == RopaCubre.None)
			{
				return false;
			}
			MemoriaDeCharacterBase memoria = this.m_memoria;
			string text = "PeticionesRopaCubre_Cumplida";
			int num = (int)cubre;
			return MemoriaDeCharacterBase.CantidadFueRegistrada(memoria, text, num.ToString());
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000064EF File Offset: 0x000046EF
		public bool RegistradaPeticion_Cumplida(string nombreDePrenda)
		{
			return nombreDePrenda != null && MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesNombreDePrenda_Cumplida", nombreDePrenda);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00006507 File Offset: 0x00004707
		public bool RegistradaPeticion_Cumplida(int idDePrenda)
		{
			return idDePrenda != 0 && MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesIDDePrenda_Cumplida", idDePrenda.ToString());
		}

		// Token: 0x0400003D RID: 61
		private const string cubreID_FueraDeRango = "PeticionesRopaCubre_FueraDeRango";

		// Token: 0x0400003E RID: 62
		private const string nombreDePrendaNombre_FueraDeRango = "PeticionesNombreDePrenda_FueraDeRango";

		// Token: 0x0400003F RID: 63
		private const string nombreDePrendaID_FueraDeRango = "PeticionesIDDePrenda_FueraDeRango";

		// Token: 0x04000040 RID: 64
		private const string cubreID_Negada = "PeticionesRopaCubre_Negada";

		// Token: 0x04000041 RID: 65
		private const string nombreDePrendaNombre_Negada = "PeticionesNombreDePrenda_Negada";

		// Token: 0x04000042 RID: 66
		private const string nombreDePrendaID_Negada = "PeticionesIDDePrenda_Negada";

		// Token: 0x04000043 RID: 67
		private const string cubreID_Cumplida = "PeticionesRopaCubre_Cumplida";

		// Token: 0x04000044 RID: 68
		private const string nombreDePrendaNombre_Cumplida = "PeticionesNombreDePrenda_Cumplida";

		// Token: 0x04000045 RID: 69
		private const string nombreDePrendaID_Cumplida = "PeticionesIDDePrenda_Cumplida";

		// Token: 0x04000046 RID: 70
		private const string estoyDesnuda = "PeticionesEstoyDesnuda";

		// Token: 0x04000047 RID: 71
		private const string ningunaPrendaConsent = "PeticionesNingunaPrendaConsent";

		// Token: 0x04000048 RID: 72
		private MemoriaDeCharacterGeneralTemporal m_memoria;
	}
}
