using System;
using Assets.Base.Tiempo.Runtime.Eventos;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Eventos
{
	// Token: 0x020000CD RID: 205
	[MemoriaRelatedBehaviour]
	public class EmailsInbox : EventosUnicosLocales<Character, EmailRecivedEvento>
	{
		// Token: 0x060007A8 RID: 1960 RVA: 0x0002C21C File Offset: 0x0002A41C
		public static void Add(EmailRecivedEvento email, string emailsInboxOwnerID, Object context)
		{
			IJsonMemoryNode jsonMemoryNode = (IJsonMemoryNode)MemoriaDeCharacterBase.GetPermanentMemoria(MemoriaDeCharacterBase.GetRutaCompleta(MemoriaDeCharacterBase.defaultRuta, emailsInboxOwnerID, MemoriaDeCharacterGeneral.selfMemKeyNameOfMemoriaDeCharacterGeneral)).FindChildNotNull("EmailsInbox");
			EventosUnicosLocales<Character, EmailRecivedEvento, EventosLocales<EmailRecivedEvento>, AconteciendoLocalmente<EmailRecivedEvento>>.SaveToMemory(email, jsonMemoryNode, context);
		}

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x060007A9 RID: 1961 RVA: 0x0002C256 File Offset: 0x0002A456
		protected override IJsonMemoryNode memoria
		{
			get
			{
				return this.m_memoria;
			}
		}

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x060007AA RID: 1962 RVA: 0x0002C25E File Offset: 0x0002A45E
		protected override bool checkEndDateOnLoad
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x0002C264 File Offset: 0x0002A464
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_memoriaPermanente = base.owner.GetComponentInChildren<MemoriaDeCharacterGeneralPermanente>();
			if (this.m_memoriaPermanente == null)
			{
				throw new ArgumentNullException("memoriaPermanente", "memoriaPermanente null reference.");
			}
			this.m_BuffDeCharacter = base.owner.GetComponentInChildren<BuffDeCharacter>();
			if (this.m_BuffDeCharacter == null)
			{
				throw new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference.");
			}
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x0002C2D5 File Offset: 0x0002A4D5
		protected override bool WasMemoryLoaded()
		{
			return this.m_BuffDeCharacter.isStared && base.owner.isMemoryLoaded;
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x0002C2F1 File Offset: 0x0002A4F1
		protected override void OnMemoryLoaded()
		{
			this.m_memoria = MemoriaDeCharacterBase.LeerDeep(this.m_memoriaPermanente, "EmailsInbox", true);
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x0002C30A File Offset: 0x0002A50A
		protected override EmailRecivedEvento ProducirInstanciaDesdeMemoria(IJsonMemoryNode eventoMem, string eventoID)
		{
			return Activator.CreateInstance(new SerializableType(eventoMem.FindData("type"))) as EmailRecivedEvento;
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x0002C32B File Offset: 0x0002A52B
		protected override void ShowLoadingPanel(string msg)
		{
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x0002C32D File Offset: 0x0002A52D
		protected override void HideLoadingPanel()
		{
		}

		// Token: 0x0400045F RID: 1119
		public const string MemID = "EmailsInbox";

		// Token: 0x04000460 RID: 1120
		private IJsonMemoryNode m_memoria;

		// Token: 0x04000461 RID: 1121
		private MemoriaDeCharacterGeneralPermanente m_memoriaPermanente;

		// Token: 0x04000462 RID: 1122
		private BuffDeCharacter m_BuffDeCharacter;
	}
}
