using System;
using Assets._ReusableScripts;

namespace Assets.TValle.BeachGirl.Runtime
{
	// Token: 0x0200004B RID: 75
	public interface IControladorDeLipSync : IControllerColaDePrioridad, ICharacterHablador
	{
		// Token: 0x0600014E RID: 334
		bool PronunciarForzar(string texto);

		// Token: 0x0600014F RID: 335
		bool Pronunciar(string texto);

		// Token: 0x06000150 RID: 336
		IOrdenDeController PronunciarTexto2(string texto);
	}
}
