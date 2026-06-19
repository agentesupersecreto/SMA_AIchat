using System;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using RootMotion.FinalIK;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Controllers.Interacciones.AI.Memoria
{
	// Token: 0x020001DB RID: 475
	[MemoriaRelatedBehaviour]
	public class MemoriaDeRegistroDePeticionesDeEjecutarPose : CustomUpdatedMonobehaviourBase
	{
		// Token: 0x06000B4C RID: 2892 RVA: 0x00037A76 File Offset: 0x00035C76
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_memoria = this.GetComponentEnRoot(false);
			if (this.m_memoria == null)
			{
				throw new ArgumentNullException("m_memoria", "m_memoria null reference.");
			}
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x00037AA9 File Offset: 0x00035CA9
		public void RegistrarDijoEstarAtadaTodas()
		{
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesAtadoTodas", "PeticionesAtadoTodas");
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x00037AC0 File Offset: 0x00035CC0
		public bool EstaRegistrardaDijoEstarAtadaTodas()
		{
			return MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesAtadoTodas", "PeticionesAtadoTodas");
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x00037AD7 File Offset: 0x00035CD7
		public void BorrarDijoTodasNegadas()
		{
			MemoriaDeCharacterBase.Borrar(this.m_memoria, "PeticionesPosesTodasNegada", "PeticionesPosesTodasNegada");
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x00037AEE File Offset: 0x00035CEE
		public void RegistrarDijoTodasNegadas()
		{
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesPosesTodasNegada", "PeticionesPosesTodasNegada");
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x00037B05 File Offset: 0x00035D05
		public bool EstaRegistrardaDijoTodasNegadas()
		{
			return MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesPosesTodasNegada", "PeticionesPosesTodasNegada");
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x00037B1C File Offset: 0x00035D1C
		public void RegistrarDijoEstarAtada(FullBodyBipedEffector effector)
		{
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesAtado", effector.ToString());
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x00037B3B File Offset: 0x00035D3B
		public bool EstaRegistrardaDijoEstarAtada(FullBodyBipedEffector effector)
		{
			return MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesAtado", effector.ToString());
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x00037B5A File Offset: 0x00035D5A
		public void RegistrarPoseNegadaV2(int poseID)
		{
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesPoseNegada", poseID.ToString());
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x00037B73 File Offset: 0x00035D73
		public void BorrarPoseNegadaV2(int poseID)
		{
			MemoriaDeCharacterBase.Borrar(this.m_memoria, "PeticionesPoseNegada", poseID.ToString());
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x00037B8C File Offset: 0x00035D8C
		public bool EstaRegistrardaPoseNegadaV2(int poseID)
		{
			return MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesPoseNegada", poseID.ToString());
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x00037BA5 File Offset: 0x00035DA5
		public void RegistrarPoseAceptadaV2(int poseID)
		{
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesPoseAceptada", poseID.ToString());
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x00037BBE File Offset: 0x00035DBE
		public bool EstaRegistrardaPoseAceptadaV2(int poseID)
		{
			return MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesPoseAceptada", poseID.ToString());
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x00037BD7 File Offset: 0x00035DD7
		public void RegistrarPoseNegadaV2(string poseNombre)
		{
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesPoseNegada", poseNombre);
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x00037BEA File Offset: 0x00035DEA
		public void BorrarPoseNegadaV2(string poseNombre)
		{
			MemoriaDeCharacterBase.Borrar(this.m_memoria, "PeticionesPoseNegada", poseNombre);
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x00037BFD File Offset: 0x00035DFD
		public bool EstaRegistrardaPoseNegadaV2(string poseNombre)
		{
			return MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesPoseNegada", poseNombre);
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x00037C10 File Offset: 0x00035E10
		public void RegistrarPoseAceptadaV2(string poseNombre)
		{
			MemoriaDeCharacterBase.RegistrarCantidadPlus(this.m_memoria, "PeticionesPoseAceptada", poseNombre);
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x00037C23 File Offset: 0x00035E23
		public bool EstaRegistrardaPoseAceptadaV2(string poseNombre)
		{
			return MemoriaDeCharacterBase.CantidadFueRegistrada(this.m_memoria, "PeticionesPoseAceptada", poseNombre);
		}

		// Token: 0x04000882 RID: 2178
		private const string poseNegadaTodas = "PeticionesPosesTodasNegada";

		// Token: 0x04000883 RID: 2179
		private const string poseNegada = "PeticionesPoseNegada";

		// Token: 0x04000884 RID: 2180
		private const string poseAceptada = "PeticionesPoseAceptada";

		// Token: 0x04000885 RID: 2181
		private const string estoyAtado = "PeticionesAtado";

		// Token: 0x04000886 RID: 2182
		private const string estoyAtadoTodas = "PeticionesAtadoTodas";

		// Token: 0x04000887 RID: 2183
		private MemoriaDeCharacterGeneralTemporal m_memoria;
	}
}
